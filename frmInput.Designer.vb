<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInput
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.lblAxis = New System.Windows.Forms.Label()
        Me.chkRev = New System.Windows.Forms.CheckBox()
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.numSwitchOn = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.comController = New System.Windows.Forms.ComboBox()
        Me.comControllerType = New System.Windows.Forms.ComboBox()
        Me.lblSwitch = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.chkAutoName = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkSwitch = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.numSwitchOn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(389, 148)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Enabled = False
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 65)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Move an axis on your joystick. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Then click Find. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Then move the axis you want" & _
            " to set." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Onece it found your axis apply settings."
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(196, 12)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "Find"
        Me.ToolTips.SetToolTip(Me.btnFind, "Will wait for you to move an axis")
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'lblAxis
        '
        Me.lblAxis.AutoSize = True
        Me.lblAxis.Location = New System.Drawing.Point(86, 84)
        Me.lblAxis.Name = "lblAxis"
        Me.lblAxis.Size = New System.Drawing.Size(52, 13)
        Me.lblAxis.TabIndex = 3
        Me.lblAxis.Text = "<NoAxis>"
        '
        'chkRev
        '
        Me.chkRev.AutoSize = True
        Me.chkRev.Location = New System.Drawing.Point(187, 84)
        Me.chkRev.Name = "chkRev"
        Me.chkRev.Size = New System.Drawing.Size(66, 17)
        Me.chkRev.TabIndex = 4
        Me.chkRev.Text = "Reverse"
        Me.ToolTips.SetToolTip(Me.chkRev, "Reverse the axis.")
        Me.chkRev.UseVisualStyleBackColor = True
        '
        'tmr
        '
        Me.tmr.Interval = 10
        '
        'numSwitchOn
        '
        Me.numSwitchOn.Location = New System.Drawing.Point(196, 107)
        Me.numSwitchOn.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numSwitchOn.Name = "numSwitchOn"
        Me.numSwitchOn.Size = New System.Drawing.Size(80, 20)
        Me.numSwitchOn.TabIndex = 5
        Me.ToolTips.SetToolTip(Me.numSwitchOn, "Switch on position.")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Axis position:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(246, 52)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "If axis position is more then or equal to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "then turn on the switch. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "And show th" & _
            "e virtual pedal as on." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Switches are things like pedals that just on and off."
        '
        'comController
        '
        Me.comController.FormattingEnabled = True
        Me.comController.Location = New System.Drawing.Point(358, 33)
        Me.comController.Name = "comController"
        Me.comController.Size = New System.Drawing.Size(185, 21)
        Me.comController.TabIndex = 7
        '
        'comControllerType
        '
        Me.comControllerType.FormattingEnabled = True
        Me.comControllerType.Location = New System.Drawing.Point(358, 6)
        Me.comControllerType.Name = "comControllerType"
        Me.comControllerType.Size = New System.Drawing.Size(185, 21)
        Me.comControllerType.TabIndex = 7
        '
        'lblSwitch
        '
        Me.lblSwitch.BackColor = System.Drawing.Color.Black
        Me.lblSwitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSwitch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSwitch.Location = New System.Drawing.Point(264, 130)
        Me.lblSwitch.Name = "lblSwitch"
        Me.lblSwitch.Size = New System.Drawing.Size(50, 50)
        Me.lblSwitch.TabIndex = 8
        Me.lblSwitch.Text = "Switch Off"
        Me.lblSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(275, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Controller type:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(298, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Controller:"
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(358, 101)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(185, 20)
        Me.txtName.TabIndex = 10
        '
        'chkAutoName
        '
        Me.chkAutoName.AutoSize = True
        Me.chkAutoName.Checked = True
        Me.chkAutoName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoName.Location = New System.Drawing.Point(358, 127)
        Me.chkAutoName.Name = "chkAutoName"
        Me.chkAutoName.Size = New System.Drawing.Size(77, 17)
        Me.chkAutoName.TabIndex = 11
        Me.chkAutoName.Text = "Auto name"
        Me.chkAutoName.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(314, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Name:"
        '
        'chkSwitch
        '
        Me.chkSwitch.AutoSize = True
        Me.chkSwitch.Checked = True
        Me.chkSwitch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSwitch.Location = New System.Drawing.Point(358, 61)
        Me.chkSwitch.Name = "chkSwitch"
        Me.chkSwitch.Size = New System.Drawing.Size(138, 17)
        Me.chkSwitch.TabIndex = 12
        Me.chkSwitch.Text = "Use controller as switch"
        Me.chkSwitch.UseVisualStyleBackColor = True
        '
        'frmInput
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(547, 189)
        Me.Controls.Add(Me.chkSwitch)
        Me.Controls.Add(Me.chkAutoName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblSwitch)
        Me.Controls.Add(Me.comControllerType)
        Me.Controls.Add(Me.comController)
        Me.Controls.Add(Me.numSwitchOn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkRev)
        Me.Controls.Add(Me.lblAxis)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInput"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Get input"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.numSwitchOn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents btnFind As System.Windows.Forms.Button
	Friend WithEvents lblAxis As System.Windows.Forms.Label
	Friend WithEvents chkRev As System.Windows.Forms.CheckBox
	Friend WithEvents tmr As System.Windows.Forms.Timer
	Friend WithEvents numSwitchOn As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents comController As System.Windows.Forms.ComboBox
    Friend WithEvents comControllerType As System.Windows.Forms.ComboBox
    Friend WithEvents lblSwitch As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents chkAutoName As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkSwitch As System.Windows.Forms.CheckBox

End Class
