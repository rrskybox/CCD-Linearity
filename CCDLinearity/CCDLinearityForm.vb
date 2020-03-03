Imports System.Windows.Forms.DataVisualization.Charting

Public Class CCDLinearityForm
    'Windows Visual Basic Forms Application: CCDLinearity
    '
    'Standalone application to graph CCD linearity against target exposuser time
    '
    ' ------------------------------------------------------------------------
    '
    ' Author: R.McAlister 2017)
    ' Version 1.0
    '
    ' 
    ' See CCDLinearityV1.0.docx for installation and operation informations
    '
    ' Main form....


    Const SampleSize = 1
    Const starquery = "TTFltFrmStrChsr.dbq"
    Public abortflag As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        abortflag = False

        FluxChart.Series.Add("FluxSeries")
        FluxChart.Series("FluxSeries").XValueType = ChartValueType.Double
        FluxChart.Series("FluxSeries").ChartType = SeriesChartType.Point
        FluxChart.Series("FluxSeries").ChartArea = "FluxChartArea"
        FluxChart.Series("FluxSeries").Points.Clear()
        Return

    End Sub

    Private Sub MoveToStar()
        'Method to find a star of user defined magnitude that is  somewhere above 80 degrees altitude and point the telescope at it with a closed loop slew

        ' 'Determine if search database file exists, if not, install it
        StatusUpdate("Checking on Observing List Database Query in TSX")
        If Not DBQInstalled(starquery) Then
            StatusUpdate("Installing Observing List Database Query in TSX")
            InstallDBQ(starquery)
        End If
        'Run a database querey on the star list to get a star of over 80 degrees declination and close to magnitude 9
        StatusUpdate("Running query for star magnitude")
        Dim tsxdw = CreateObject("TheSkyX.sky6DataWizard")
        tsxdw.path = "C:\Users\" + System.Environment.UserName +
            "\Documents\Software Bisque\TheSkyX Professional Edition\Database Queries\" + starquery
        tsxdw.open()
        Dim tsxoi = CreateObject("TheSkyX.sky6ObjectInformation")
        tsxoi = tsxdw.RunQuery()
        'Look through the list for the first star that is within 0.1 of the target magnitude
        tsxoi.Index = 0
        Dim starmag As Double
        Dim starname As String
        Do
            tsxoi.Property(TheSkyXLib.Sk6ObjectInformationProperty.sk6ObjInfoProp_MAG)
            starmag = tsxoi.ObjInfoPropOut
            tsxoi.Property(TheSkyXLib.Sk6ObjectInformationProperty.sk6ObjInfoProp_NAME1)
            starname = tsxoi.ObjInfoPropOut
            tsxoi.index += 1
        Loop Until (tsxoi.index = tsxoi.Count) Or AlmostTheSame(starmag, MagnitudeSetting.Value, 0.1)
        'Check that a star was actually found.  If not then announce error and return
        If tsxoi.index = tsxoi.count Then
            MsgBox("No star close to target magnitude was found above 80 degrees altitude.")
            Return
        End If
        'Set connection to star chart and perform a find on M39
        StatusUpdate("Performing CLS to star")
        Dim tsxsc = CreateObject("TheSkyX.Sky6StarChart")
        tsxsc.Find(starname)
        'Create connection to camera and connect
        Dim tsxcc = CreateObject("TheSkyX.ccdsoftCamera")
        tsxcc.Connect()
        'Set the exposure, filter to luminance and reduction, set the camera delay to 0 -- backlash
        ' should be picked up in the mount driver
        tsxcc.ImageReduction = TheSkyXLib.ccdsoftImageReduction.cdNone
        tsxcc.FilterIndexZeroBased = 3 'Luminance
        tsxcc.ExposureTime = 10
        tsxcc.Delay = 0
        tsxcc.Subframe = False
        'Create closed loop slew object
        Dim tsxcls = CreateObject("TheSkyX.ClosedLoopSlew")
        'Execute Closed Loop Slew to this target
        Try
            Dim clsstat = tsxcls.exec()
        Catch ex As Exception
            'Just close up: TSX will spawn error window
            MsgBox("Closed Loop Slew failure: " + Str(tsxcls.lastError))
        End Try
        'Take a sample of this star.  Evaluate suitability and alert user
        Dim cs = New CCDSample(1, 1)
        If cs.Maxpixel < 5000 Then
            MsgBox("You might want to choose a brighter star for a faster CCD linearity test.")
        End If
        If cs.Maxpixel > 20000 Then
            MsgBox("You might want to choose a dimmer star for more accurate CCD linearity test.")
        End If
        StatusUpdate("Star ready for CCD linearity test")

        'Clean up objects
        tsxdw = Nothing
        tsxoi = Nothing
        tsxcc = Nothing
        tsxcls = Nothing
        tsxsc = Nothing
        Return
    End Sub

    Private Sub MoveToStarButton_Click(sender As Object, e As EventArgs) Handles MoveToStarButton.Click
        MoveToStarButton.BackColor = Color.LightSalmon
        Cursor = Cursors.WaitCursor
        MoveToStar()
        MoveToStarButton.BackColor = Color.LightGreen
        Cursor = Cursors.Default
        Return
    End Sub

    Private Sub TestButton_Click(sender As Object, e As EventArgs) Handles TestButton.Click
        Dim etime As Double = 1 'start at 1 second
        Dim samples = SampleSize  'samples per loop
        Dim satlevel As Double
        TestButton.BackColor = Color.LightSalmon
        AbortButton.BackColor = Color.LightGreen
        Cursor = Cursors.WaitCursor

        StatusUpdate("Starting linearity test")
        abortflag = False
        Do
            StatusUpdate("Testing linearity at " + DoubleClip(etime, 2) + " seconds exposure")
            Dim asamp As New CCDSample(etime, SampleCountSetting.Value)
            satlevel = asamp.Maxpixel
            FluxChart.Series("FluxSeries").Points.AddXY(asamp.Maxpixel, asamp.Fluxpersec)
            etime = etime * (asamp.Maxpixel + 5000) / asamp.Maxpixel
        Loop Until (satlevel >= 65000) Or abortflag

        TestButton.BackColor = Color.LightGreen
        Cursor = Cursors.Default
        AbortButton.BackColor = Color.LightGreen

        StatusUpdate("Linearity testing complete at saturation")
        Return

    End Sub

    Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        abortflag = True
        AbortButton.BackColor = Color.LightSalmon
        Return
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
        Return
    End Sub

    Private Function AlmostTheSame(val1 As Double, val2 As Double, howclose As Double) As Boolean
        'Returns True is val1 is within howclose of val2
        If Math.Abs(val1 - val2) <= howclose Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub StatusUpdate(stext As String)
        'Simple method to write a status line.  Also usable externally.
        StatusLabel.Text = stext
        Return
    End Sub

    Public Function DoubleClip(ByVal dvalue As Double, ByVal decimals As Integer) As String
        'Converts a double value (dvalue) to a string truncated to the specified number (decimals) of decimal points, adds a leading 0 if necessary
        Dim ss As String
        Dim decpos As Integer

        'Convert the value to a simple string without leading spaces
        ss = LTrim(Str(dvalue))
        decpos = InStr(ss, ".")
        Select Case decpos
            Case 0
                'No decimal point is found in string, e.g. xxxxx
                'Use all the characters
                'If the dvalue is 0, then add a decimal point and zero's accordingly
                If dvalue = 0 Then
                    Select Case decimals
                        Case 0
                            ss = "0"
                        Case Else
                            ss = "0."
                            For i = 1 To decimals
                                ss = ss + "0"
                            Next
                    End Select
                End If
            Case 1
                'Decimal point is found in numeric string at first character, e.g. .xxxx
                'Put a zero in front of the leftmost decimals characters + 1
                ss = "0" + Strings.Left(ss, decimals + 1)
            Case Else
                'Decimal point is found in numeric string after first character
                'Save everything to the left of the decimal point + number of decimals unless
                '  the decimals is 0, then move the decpos to the left one before 
                If decimals = 0 Then
                    decpos = decpos - 1
                End If
                ss = Strings.Left(ss, decpos + decimals)

        End Select
        Return ss

    End Function



End Class
