﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditingForm_EnergySwitch
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditingForm_EnergySwitch))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblTag = New System.Windows.Forms.TextBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.lblConnectedTo = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rtbAnnotations = New Extended.Windows.Forms.RichTextBoxExtended()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCreateAndConnectOutlet2 = New System.Windows.Forms.Button()
        Me.btnCreateAndConnectOutlet1 = New System.Windows.Forms.Button()
        Me.btnCreateAndConnectInlet1 = New System.Windows.Forms.Button()
        Me.btnDisconnectOutlet2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbOutlet2 = New System.Windows.Forms.ComboBox()
        Me.btnDisconnectOutlet1 = New System.Windows.Forms.Button()
        Me.btnDisconnect1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbOutlet1 = New System.Windows.Forms.ComboBox()
        Me.cbInlet1 = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbExpressionField = New System.Windows.Forms.TextBox()
        Me.ToolTipChangeTag = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Controls.Add(Me.lblTag)
        Me.GroupBox5.Controls.Add(Me.chkActive)
        Me.GroupBox5.Controls.Add(Me.lblConnectedTo)
        Me.GroupBox5.Controls.Add(Me.lblStatus)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        Me.ToolTipChangeTag.SetToolTip(Me.GroupBox5, resources.GetString("GroupBox5.ToolTip"))
        Me.ToolTipValues.SetToolTip(Me.GroupBox5, resources.GetString("GroupBox5.ToolTip1"))
        Me.ToolTip1.SetToolTip(Me.GroupBox5, resources.GetString("GroupBox5.ToolTip2"))
        '
        'lblTag
        '
        resources.ApplyResources(Me.lblTag, "lblTag")
        Me.lblTag.Name = "lblTag"
        Me.ToolTipValues.SetToolTip(Me.lblTag, resources.GetString("lblTag.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.lblTag, resources.GetString("lblTag.ToolTip1"))
        Me.ToolTipChangeTag.SetToolTip(Me.lblTag, resources.GetString("lblTag.ToolTip2"))
        '
        'chkActive
        '
        resources.ApplyResources(Me.chkActive, "chkActive")
        Me.chkActive.Image = Global.DWSIM.UnitOperations.My.Resources.Resources.bullet_tick
        Me.chkActive.Name = "chkActive"
        Me.ToolTip1.SetToolTip(Me.chkActive, resources.GetString("chkActive.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.chkActive, resources.GetString("chkActive.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.chkActive, resources.GetString("chkActive.ToolTip2"))
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'lblConnectedTo
        '
        resources.ApplyResources(Me.lblConnectedTo, "lblConnectedTo")
        Me.lblConnectedTo.Name = "lblConnectedTo"
        Me.ToolTip1.SetToolTip(Me.lblConnectedTo, resources.GetString("lblConnectedTo.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.lblConnectedTo, resources.GetString("lblConnectedTo.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.lblConnectedTo, resources.GetString("lblConnectedTo.ToolTip2"))
        '
        'lblStatus
        '
        resources.ApplyResources(Me.lblStatus, "lblStatus")
        Me.lblStatus.Name = "lblStatus"
        Me.ToolTip1.SetToolTip(Me.lblStatus, resources.GetString("lblStatus.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.lblStatus, resources.GetString("lblStatus.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.lblStatus, resources.GetString("lblStatus.ToolTip2"))
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        Me.ToolTip1.SetToolTip(Me.Label13, resources.GetString("Label13.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.Label13, resources.GetString("Label13.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.Label13, resources.GetString("Label13.ToolTip2"))
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        Me.ToolTip1.SetToolTip(Me.Label12, resources.GetString("Label12.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.Label12, resources.GetString("Label12.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.Label12, resources.GetString("Label12.ToolTip2"))
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        Me.ToolTip1.SetToolTip(Me.Label11, resources.GetString("Label11.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.Label11, resources.GetString("Label11.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.Label11, resources.GetString("Label11.ToolTip2"))
        '
        'GroupBox4
        '
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Controls.Add(Me.rtbAnnotations)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        Me.ToolTipChangeTag.SetToolTip(Me.GroupBox4, resources.GetString("GroupBox4.ToolTip"))
        Me.ToolTipValues.SetToolTip(Me.GroupBox4, resources.GetString("GroupBox4.ToolTip1"))
        Me.ToolTip1.SetToolTip(Me.GroupBox4, resources.GetString("GroupBox4.ToolTip2"))
        '
        'rtbAnnotations
        '
        resources.ApplyResources(Me.rtbAnnotations, "rtbAnnotations")
        Me.rtbAnnotations.Name = "rtbAnnotations"
        Me.rtbAnnotations.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1046{\fonttbl{\f0\fnil Microsoft " &
    "Sans Serif;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{\*\generator Riched20 10.0.19041}\viewkind4\uc1 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\pard\f0\fs17\" &
    "par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rtbAnnotations.ShowRedo = False
        Me.rtbAnnotations.ShowUndo = False
        Me.ToolTipValues.SetToolTip(Me.rtbAnnotations, resources.GetString("rtbAnnotations.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.rtbAnnotations, resources.GetString("rtbAnnotations.ToolTip1"))
        Me.ToolTipChangeTag.SetToolTip(Me.rtbAnnotations, resources.GetString("rtbAnnotations.ToolTip2"))
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.btnCreateAndConnectOutlet2)
        Me.GroupBox1.Controls.Add(Me.btnCreateAndConnectOutlet1)
        Me.GroupBox1.Controls.Add(Me.btnCreateAndConnectInlet1)
        Me.GroupBox1.Controls.Add(Me.btnDisconnectOutlet2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbOutlet2)
        Me.GroupBox1.Controls.Add(Me.btnDisconnectOutlet1)
        Me.GroupBox1.Controls.Add(Me.btnDisconnect1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbOutlet1)
        Me.GroupBox1.Controls.Add(Me.cbInlet1)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        Me.ToolTipChangeTag.SetToolTip(Me.GroupBox1, resources.GetString("GroupBox1.ToolTip"))
        Me.ToolTipValues.SetToolTip(Me.GroupBox1, resources.GetString("GroupBox1.ToolTip1"))
        Me.ToolTip1.SetToolTip(Me.GroupBox1, resources.GetString("GroupBox1.ToolTip2"))
        '
        'btnCreateAndConnectOutlet2
        '
        resources.ApplyResources(Me.btnCreateAndConnectOutlet2, "btnCreateAndConnectOutlet2")
        Me.btnCreateAndConnectOutlet2.BackgroundImage = Global.DWSIM.UnitOperations.My.Resources.Resources.bullet_lightning
        Me.btnCreateAndConnectOutlet2.Name = "btnCreateAndConnectOutlet2"
        Me.ToolTip1.SetToolTip(Me.btnCreateAndConnectOutlet2, resources.GetString("btnCreateAndConnectOutlet2.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.btnCreateAndConnectOutlet2, resources.GetString("btnCreateAndConnectOutlet2.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.btnCreateAndConnectOutlet2, resources.GetString("btnCreateAndConnectOutlet2.ToolTip2"))
        Me.btnCreateAndConnectOutlet2.UseVisualStyleBackColor = True
        '
        'btnCreateAndConnectOutlet1
        '
        resources.ApplyResources(Me.btnCreateAndConnectOutlet1, "btnCreateAndConnectOutlet1")
        Me.btnCreateAndConnectOutlet1.BackgroundImage = Global.DWSIM.UnitOperations.My.Resources.Resources.bullet_lightning
        Me.btnCreateAndConnectOutlet1.Name = "btnCreateAndConnectOutlet1"
        Me.ToolTip1.SetToolTip(Me.btnCreateAndConnectOutlet1, resources.GetString("btnCreateAndConnectOutlet1.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.btnCreateAndConnectOutlet1, resources.GetString("btnCreateAndConnectOutlet1.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.btnCreateAndConnectOutlet1, resources.GetString("btnCreateAndConnectOutlet1.ToolTip2"))
        Me.btnCreateAndConnectOutlet1.UseVisualStyleBackColor = True
        '
        'btnCreateAndConnectInlet1
        '
        resources.ApplyResources(Me.btnCreateAndConnectInlet1, "btnCreateAndConnectInlet1")
        Me.btnCreateAndConnectInlet1.BackgroundImage = Global.DWSIM.UnitOperations.My.Resources.Resources.bullet_lightning
        Me.btnCreateAndConnectInlet1.Name = "btnCreateAndConnectInlet1"
        Me.ToolTip1.SetToolTip(Me.btnCreateAndConnectInlet1, resources.GetString("btnCreateAndConnectInlet1.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.btnCreateAndConnectInlet1, resources.GetString("btnCreateAndConnectInlet1.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.btnCreateAndConnectInlet1, resources.GetString("btnCreateAndConnectInlet1.ToolTip2"))
        Me.btnCreateAndConnectInlet1.UseVisualStyleBackColor = True
        '
        'btnDisconnectOutlet2
        '
        resources.ApplyResources(Me.btnDisconnectOutlet2, "btnDisconnectOutlet2")
        Me.btnDisconnectOutlet2.Image = Global.DWSIM.UnitOperations.My.Resources.Resources.disconnect
        Me.btnDisconnectOutlet2.Name = "btnDisconnectOutlet2"
        Me.ToolTip1.SetToolTip(Me.btnDisconnectOutlet2, resources.GetString("btnDisconnectOutlet2.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.btnDisconnectOutlet2, resources.GetString("btnDisconnectOutlet2.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.btnDisconnectOutlet2, resources.GetString("btnDisconnectOutlet2.ToolTip2"))
        Me.btnDisconnectOutlet2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip2"))
        '
        'cbOutlet2
        '
        resources.ApplyResources(Me.cbOutlet2, "cbOutlet2")
        Me.cbOutlet2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOutlet2.FormattingEnabled = True
        Me.cbOutlet2.Name = "cbOutlet2"
        Me.ToolTip1.SetToolTip(Me.cbOutlet2, resources.GetString("cbOutlet2.ToolTip"))
        Me.ToolTipValues.SetToolTip(Me.cbOutlet2, resources.GetString("cbOutlet2.ToolTip1"))
        Me.ToolTipChangeTag.SetToolTip(Me.cbOutlet2, resources.GetString("cbOutlet2.ToolTip2"))
        '
        'btnDisconnectOutlet1
        '
        resources.ApplyResources(Me.btnDisconnectOutlet1, "btnDisconnectOutlet1")
        Me.btnDisconnectOutlet1.Image = Global.DWSIM.UnitOperations.My.Resources.Resources.disconnect
        Me.btnDisconnectOutlet1.Name = "btnDisconnectOutlet1"
        Me.ToolTip1.SetToolTip(Me.btnDisconnectOutlet1, resources.GetString("btnDisconnectOutlet1.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.btnDisconnectOutlet1, resources.GetString("btnDisconnectOutlet1.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.btnDisconnectOutlet1, resources.GetString("btnDisconnectOutlet1.ToolTip2"))
        Me.btnDisconnectOutlet1.UseVisualStyleBackColor = True
        '
        'btnDisconnect1
        '
        resources.ApplyResources(Me.btnDisconnect1, "btnDisconnect1")
        Me.btnDisconnect1.Image = Global.DWSIM.UnitOperations.My.Resources.Resources.disconnect
        Me.btnDisconnect1.Name = "btnDisconnect1"
        Me.ToolTip1.SetToolTip(Me.btnDisconnect1, resources.GetString("btnDisconnect1.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.btnDisconnect1, resources.GetString("btnDisconnect1.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.btnDisconnect1, resources.GetString("btnDisconnect1.ToolTip2"))
        Me.btnDisconnect1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        Me.ToolTip1.SetToolTip(Me.Label7, resources.GetString("Label7.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.Label7, resources.GetString("Label7.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.Label7, resources.GetString("Label7.ToolTip2"))
        '
        'cbOutlet1
        '
        resources.ApplyResources(Me.cbOutlet1, "cbOutlet1")
        Me.cbOutlet1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOutlet1.FormattingEnabled = True
        Me.cbOutlet1.Name = "cbOutlet1"
        Me.ToolTip1.SetToolTip(Me.cbOutlet1, resources.GetString("cbOutlet1.ToolTip"))
        Me.ToolTipValues.SetToolTip(Me.cbOutlet1, resources.GetString("cbOutlet1.ToolTip1"))
        Me.ToolTipChangeTag.SetToolTip(Me.cbOutlet1, resources.GetString("cbOutlet1.ToolTip2"))
        '
        'cbInlet1
        '
        resources.ApplyResources(Me.cbInlet1, "cbInlet1")
        Me.cbInlet1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInlet1.FormattingEnabled = True
        Me.cbInlet1.Name = "cbInlet1"
        Me.ToolTip1.SetToolTip(Me.cbInlet1, resources.GetString("cbInlet1.ToolTip"))
        Me.ToolTipValues.SetToolTip(Me.cbInlet1, resources.GetString("cbInlet1.ToolTip1"))
        Me.ToolTipChangeTag.SetToolTip(Me.cbInlet1, resources.GetString("cbInlet1.ToolTip2"))
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.Name = "Label19"
        Me.ToolTip1.SetToolTip(Me.Label19, resources.GetString("Label19.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.Label19, resources.GetString("Label19.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.Label19, resources.GetString("Label19.ToolTip2"))
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.tbExpressionField)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        Me.ToolTipChangeTag.SetToolTip(Me.GroupBox2, resources.GetString("GroupBox2.ToolTip"))
        Me.ToolTipValues.SetToolTip(Me.GroupBox2, resources.GetString("GroupBox2.ToolTip1"))
        Me.ToolTip1.SetToolTip(Me.GroupBox2, resources.GetString("GroupBox2.ToolTip2"))
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        Me.ToolTip1.SetToolTip(Me.Label5, resources.GetString("Label5.ToolTip"))
        Me.ToolTipChangeTag.SetToolTip(Me.Label5, resources.GetString("Label5.ToolTip1"))
        Me.ToolTipValues.SetToolTip(Me.Label5, resources.GetString("Label5.ToolTip2"))
        '
        'tbExpressionField
        '
        resources.ApplyResources(Me.tbExpressionField, "tbExpressionField")
        Me.tbExpressionField.Name = "tbExpressionField"
        Me.ToolTipValues.SetToolTip(Me.tbExpressionField, resources.GetString("tbExpressionField.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.tbExpressionField, resources.GetString("tbExpressionField.ToolTip1"))
        Me.ToolTipChangeTag.SetToolTip(Me.tbExpressionField, resources.GetString("tbExpressionField.ToolTip2"))
        '
        'ToolTipChangeTag
        '
        Me.ToolTipChangeTag.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipChangeTag.ToolTipTitle = "Info"
        '
        'EditingForm_EnergySwitch
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "EditingForm_EnergySwitch"
        Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft
        Me.ToolTipChangeTag.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.ToolTipValues.SetToolTip(Me, resources.GetString("$this.ToolTip1"))
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip2"))
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btnDisconnectOutlet1 As System.Windows.Forms.Button
    Public WithEvents btnDisconnect1 As System.Windows.Forms.Button
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents cbOutlet1 As System.Windows.Forms.ComboBox
    Public WithEvents cbInlet1 As System.Windows.Forms.ComboBox
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents lblTag As System.Windows.Forms.TextBox
    Public WithEvents btnDisconnectOutlet2 As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents cbOutlet2 As System.Windows.Forms.ComboBox
    Public WithEvents btnCreateAndConnectInlet1 As System.Windows.Forms.Button
    Public WithEvents btnCreateAndConnectOutlet2 As System.Windows.Forms.Button
    Public WithEvents btnCreateAndConnectOutlet1 As System.Windows.Forms.Button
    Friend WithEvents ToolTipChangeTag As ToolTip
    Public WithEvents GroupBox2 As GroupBox
    Public WithEvents Label5 As Label
    Public WithEvents tbExpressionField As TextBox
End Class
