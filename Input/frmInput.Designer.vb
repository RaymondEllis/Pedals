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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInput))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.lblAxis = New System.Windows.Forms.Label()
        Me.chkRev = New System.Windows.Forms.CheckBox()
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.numSwitchOn = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.comControllerType = New System.Windows.Forms.ComboBox()
        Me.comController = New System.Windows.Forms.ComboBox()
        Me.lblSwitch = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.chkAutoName = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkSwitch = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblAutoName = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.numSwitchOn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(376, 109)
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
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(6, 57)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "Search"
        Me.ToolTips.SetToolTip(Me.btnFind, "Wait for you to move an input device.")
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'lblAxis
        '
        Me.lblAxis.Location = New System.Drawing.Point(76, 39)
        Me.lblAxis.Name = "lblAxis"
        Me.lblAxis.Size = New System.Drawing.Size(30, 13)
        Me.lblAxis.TabIndex = 3
        Me.lblAxis.Text = "127"
        '
        'chkRev
        '
        Me.chkRev.AutoSize = True
        Me.chkRev.Location = New System.Drawing.Point(112, 39)
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
        Me.numSwitchOn.Location = New System.Drawing.Point(183, 65)
        Me.numSwitchOn.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numSwitchOn.Name = "numSwitchOn"
        Me.numSwitchOn.Size = New System.Drawing.Size(49, 20)
        Me.numSwitchOn.TabIndex = 5
        Me.ToolTips.SetToolTip(Me.numSwitchOn, "If axis position is more then or equal to Switch On then turn on the switch. ")
        Me.numSwitchOn.Value = New Decimal(New Integer() {125, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Axis position:"
        '
        'comControllerType
        '
        Me.comControllerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comControllerType.FormattingEnabled = True
        Me.comControllerType.Location = New System.Drawing.Point(85, 12)
        Me.comControllerType.Name = "comControllerType"
        Me.comControllerType.Size = New System.Drawing.Size(185, 21)
        Me.comControllerType.TabIndex = 7
        Me.ToolTips.SetToolTip(Me.comControllerType, resources.GetString("comControllerType.ToolTip"))
        '
        'comController
        '
        Me.comController.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comController.FormattingEnabled = True
        Me.comController.Location = New System.Drawing.Point(85, 39)
        Me.comController.Name = "comController"
        Me.comController.Size = New System.Drawing.Size(185, 21)
        Me.comController.TabIndex = 7
        '
        'lblSwitch
        '
        Me.lblSwitch.BackColor = System.Drawing.Color.Black
        Me.lblSwitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSwitch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSwitch.Location = New System.Drawing.Point(183, 12)
        Me.lblSwitch.Name = "lblSwitch"
        Me.lblSwitch.Size = New System.Drawing.Size(50, 50)
        Me.lblSwitch.TabIndex = 8
        Me.lblSwitch.Text = "Switch Off"
        Me.lblSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Controller type:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Controller:"
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(59, 108)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(185, 20)
        Me.txtName.TabIndex = 10
        '
        'chkAutoName
        '
        Me.chkAutoName.AutoSize = True
        Me.chkAutoName.Checked = True
        Me.chkAutoName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoName.Location = New System.Drawing.Point(250, 114)
        Me.chkAutoName.Name = "chkAutoName"
        Me.chkAutoName.Size = New System.Drawing.Size(77, 17)
        Me.chkAutoName.TabIndex = 11
        Me.chkAutoName.Text = "Auto name"
        Me.chkAutoName.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 115)
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
        Me.chkSwitch.Location = New System.Drawing.Point(85, 67)
        Me.chkSwitch.Name = "chkSwitch"
        Me.chkSwitch.Size = New System.Drawing.Size(138, 17)
        Me.chkSwitch.TabIndex = 12
        Me.chkSwitch.Text = "Use controller as switch"
        Me.chkSwitch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chkSwitch)
        Me.GroupBox1.Controls.Add(Me.comController)
        Me.GroupBox1.Controls.Add(Me.comControllerType)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(257, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(277, 90)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MIDI Output"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(108, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Switch on at:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblAutoName)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblAxis)
        Me.GroupBox2.Controls.Add(Me.chkRev)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.numSwitchOn)
        Me.GroupBox2.Controls.Add(Me.btnFind)
        Me.GroupBox2.Controls.Add(Me.lblSwitch)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(239, 90)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Input"
        '
        'lblAutoName
        '
        Me.lblAutoName.Location = New System.Drawing.Point(6, 20)
        Me.lblAutoName.Name = "lblAutoName"
        Me.lblAutoName.Size = New System.Drawing.Size(171, 13)
        Me.lblAutoName.TabIndex = 6
        Me.lblAutoName.Text = "<Input info>"
        '
        'frmInput
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(534, 150)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkAutoName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInput"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Get input"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.numSwitchOn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
	Friend WithEvents lblAxis As System.Windows.Forms.Label
	Friend WithEvents chkRev As System.Windows.Forms.CheckBox
	Friend WithEvents tmr As System.Windows.Forms.Timer
	Friend WithEvents numSwitchOn As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAutoName As System.Windows.Forms.Label

End Class
