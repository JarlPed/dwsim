<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditingForm_EnergySplitter
    Inherits SharedClasses.ObjectEditorForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditingForm_EnergySplitter))
        Me.SuspendLayout()
        '
        'EditingForm_EnergySplitter
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "EditingForm_EnergySplitter"
        Me.ToolTipValues.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Public WithEvents chkActive As System.Windows.Forms.CheckBox
    Public WithEvents lblConnectedTo As System.Windows.Forms.Label
    Public WithEvents lblStatus As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Public WithEvents rtbAnnotations As Extended.Windows.Forms.RichTextBoxExtended
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents cbCalcMode As System.Windows.Forms.ComboBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btnDisconnectOutlet1 As System.Windows.Forms.Button
    Public WithEvents btnDisconnect1 As System.Windows.Forms.Button
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents cbOutlet1 As System.Windows.Forms.ComboBox
    Public WithEvents cbInlet1 As System.Windows.Forms.ComboBox
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents lblTag As System.Windows.Forms.TextBox
    Public WithEvents cbFlowSpec2 As System.Windows.Forms.ComboBox
    Public WithEvents tbFlowSpec2 As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents cbFlowSpec1 As System.Windows.Forms.ComboBox
    Public WithEvents tbFlowSpec1 As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Public WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Public WithEvents btnDisconnectOutlet3 As System.Windows.Forms.Button
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents cbOutlet3 As System.Windows.Forms.ComboBox
    Public WithEvents btnDisconnectOutlet2 As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents cbOutlet2 As System.Windows.Forms.ComboBox
    Public WithEvents btnCreateAndConnectInlet1 As System.Windows.Forms.Button
    Public WithEvents btnCreateAndConnectOutlet3 As System.Windows.Forms.Button
    Public WithEvents btnCreateAndConnectOutlet2 As System.Windows.Forms.Button
    Public WithEvents btnCreateAndConnectOutlet1 As System.Windows.Forms.Button
    Public WithEvents tbRatio2 As TextBox
    Public WithEvents tbRatio1 As TextBox
    Friend WithEvents ToolTipChangeTag As ToolTip
End Class
