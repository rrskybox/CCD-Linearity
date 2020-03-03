Public Class CCDSample

    'Class for taking and averaging exposures of target star's maximum pixel and total flux
    Private subframesize As Integer
    Private CCDexposure As Double
    Private CCDmaxpixel As Integer
    Private CCDtotalADU As Integer
    Private CCDfluxpersec As Double


    Public Sub New(exposure As Double, samplecount As Integer)
        'Set up subframe
        SubFrameTenth()
        'Take photo
        CCDexposure = exposure
        CCDtotalADU = 0
        CCDmaxpixel = 0
        CCDfluxpersec = 0
        Dim tsxcc = CreateObject("TheSkyX.ccdsoftCamera")
        Dim tsxim = CreateObject("TheSkyX.ccdsoftImage")
        tsxcc.Frame = TheSkyXLib.ccdsoftImageFrame.cdLight
        tsxcc.ImageReduction = TheSkyXLib.ccdsoftImageReduction.cdNone
        tsxcc.ExposureTime = exposure
        tsxcc.asynchronous = True
        For i = 1 To samplecount

            tsxcc.TakeImage()
            Do While tsxcc.State <> TheSkyXLib.ccdsoftCameraState.cdStateNone
                Application.DoEvents()
                System.Threading.Thread.Sleep(1000)
                If CCDLinearityForm.abortflag Then
                    Return
                End If
            Loop
            CCDmaxpixel += tsxcc.MaximumPixel
            tsxim.AttachToActiveImager()
            For h = 0 To tsxim.HeightInPixels - 1
                Dim pixs = tsxim.Scanline(h)
                For Each p In pixs
                    CCDtotalADU += p
                Next
            Next
            CCDfluxpersec += CCDtotalADU / CCDexposure
        Next

        CCDtotalADU /= samplecount
        CCDmaxpixel /= samplecount
        CCDfluxpersec /= samplecount

        tsxcc.subframe = False

        tsxcc = Nothing
        tsxim = Nothing

        Return

    End Sub


    Public Property TotalADU() As Double
        Get
            Return CCDtotalADU
        End Get
        Set(value As Double)
            Return
        End Set
    End Property

    Public Property Maxpixel() As Double
        Get
            Return CCDmaxpixel
        End Get
        Set(value As Double)
            Return
        End Set
    End Property

    Public Property Fluxpersec As Double
        Get
            Return CCDfluxpersec
        End Get
        Set(value As Double)
            Return
        End Set
    End Property

    Private Sub SubFrameTenth()
     
        'Set the main camera subframe to a square the size of "value"
        Dim tsxcc = CreateObject("TheSkyX.ccdsoftCamera")
        Dim iwidth = tsxcc.WidthInPixels
        Dim iheight = tsxcc.HeightInPixels
        Dim halfsubframeside = iheight / 20
        tsxcc.subframeleft = (iwidth / 2) - halfsubframeside
        tsxcc.subframeright = (iwidth / 2) + halfsubframeside
        tsxcc.subframetop = (iheight / 2) - halfsubframeside
        tsxcc.subframebottom = (iheight / 2) + halfsubframeside
        subframesize = halfsubframeside * 2
        tsxcc.subframe = True
        tsxcc = Nothing
        Return

    End Sub


End Class
