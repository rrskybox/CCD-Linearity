<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CCDLinearityForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Me.MoveToStarButton = New System.Windows.Forms.Button()
        Me.TestButton = New System.Windows.Forms.Button()
        Me.FluxChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.AbortButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.MagnitudeSetting = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusReport = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SampleCountSetting = New System.Windows.Forms.NumericUpDown()
        CType(Me.FluxChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MagnitudeSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusReport.SuspendLayout()
        CType(Me.SampleCountSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MoveToStarButton
        '
        Me.MoveToStarButton.Location = New System.Drawing.Point(18, 289)
        Me.MoveToStarButton.Name = "MoveToStarButton"
        Me.MoveToStarButton.Size = New System.Drawing.Size(68, 42)
        Me.MoveToStarButton.TabIndex = 0
        Me.MoveToStarButton.Text = "Pick Star"
        Me.MoveToStarButton.UseVisualStyleBackColor = True
        '
        'TestButton
        '
        Me.TestButton.Location = New System.Drawing.Point(349, 289)
        Me.TestButton.Name = "TestButton"
        Me.TestButton.Size = New System.Drawing.Size(68, 42)
        Me.TestButton.TabIndex = 1
        Me.TestButton.Text = "Run Test"
        Me.TestButton.UseVisualStyleBackColor = True
        '
        'FluxChart
        '
        ChartArea1.AxisX.Title = "Peak ADU"
        ChartArea1.AxisY.Title = "Total ADU/second"
        ChartArea1.Name = "FluxChartArea"
        Me.FluxChart.ChartAreas.Add(ChartArea1)
        Me.FluxChart.Location = New System.Drawing.Point(18, 31)
        Me.FluxChart.Name = "FluxChart"
        Me.FluxChart.Size = New System.Drawing.Size(635, 227)
        Me.FluxChart.TabIndex = 2
        Me.FluxChart.Text = "Chart1"
        '
        'AbortButton
        '
        Me.AbortButton.Location = New System.Drawing.Point(489, 289)
        Me.AbortButton.Name = "AbortButton"
        Me.AbortButton.Size = New System.Drawing.Size(68, 42)
        Me.AbortButton.TabIndex = 3
        Me.AbortButton.Text = "Abort"
        Me.AbortButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(585, 289)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(68, 42)
        Me.CloseButton.TabIndex = 4
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'MagnitudeSetting
        '
        Me.MagnitudeSetting.DecimalPlaces = 1
        Me.MagnitudeSetting.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.MagnitudeSetting.Location = New System.Drawing.Point(110, 311)
        Me.MagnitudeSetting.Maximum = New Decimal(New Integer() {89, 0, 0, 65536})
        Me.MagnitudeSetting.Minimum = New Decimal(New Integer() {60, 0, 0, 65536})
        Me.MagnitudeSetting.Name = "MagnitudeSetting"
        Me.MagnitudeSetting.Size = New System.Drawing.Size(60, 20)
        Me.MagnitudeSetting.TabIndex = 5
        Me.MagnitudeSetting.Value = New Decimal(New Integer() {80, 0, 0, 65536})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(113, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Magnitude"
        '
        'StatusReport
        '
        Me.StatusReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel})
        Me.StatusReport.Location = New System.Drawing.Point(0, 354)
        Me.StatusReport.Name = "StatusReport"
        Me.StatusReport.Size = New System.Drawing.Size(682, 22)
        Me.StatusReport.TabIndex = 7
        Me.StatusReport.Text = "StatusStrip1"
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(74, 17)
        Me.StatusLabel.Text = "StatusReport"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(234, 289)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Samples/Exposure"
        '
        'SampleCountSetting
        '
        Me.SampleCountSetting.Location = New System.Drawing.Point(260, 311)
        Me.SampleCountSetting.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.SampleCountSetting.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SampleCountSetting.Name = "SampleCountSetting"
        Me.SampleCountSetting.Size = New System.Drawing.Size(45, 20)
        Me.SampleCountSetting.TabIndex = 8
        Me.SampleCountSetting.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CCDLinearityForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 376)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SampleCountSetting)
        Me.Controls.Add(Me.StatusReport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MagnitudeSetting)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.AbortButton)
        Me.Controls.Add(Me.FluxChart)
        Me.Controls.Add(Me.TestButton)
        Me.Controls.Add(Me.MoveToStarButton)
        Me.Name = "CCDLinearityForm"
        Me.Text = "CCD LInearity Tool Rev 1.0"
        CType(Me.FluxChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MagnitudeSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusReport.ResumeLayout(False)
        Me.StatusReport.PerformLayout()
        CType(Me.SampleCountSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MoveToStarButton As System.Windows.Forms.Button
    Friend WithEvents TestButton As System.Windows.Forms.Button
    Friend WithEvents FluxChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents AbortButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents MagnitudeSetting As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusReport As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SampleCountSetting As System.Windows.Forms.NumericUpDown

End Class
