<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.grpOutput = New System.Windows.Forms.GroupBox()
        Me.chkNoteOut = New System.Windows.Forms.CheckBox()
        Me.numOutputChannel = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.comOutput = New System.Windows.Forms.ComboBox()
        Me.grpInput = New System.Windows.Forms.GroupBox()
        Me.numInputChannel = New System.Windows.Forms.NumericUpDown()
        Me.comInput = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkOldNote = New System.Windows.Forms.CheckBox()
        Me.chkDebug = New System.Windows.Forms.CheckBox()
        Me.panDebug = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstDebug = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSS = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.tmrInput = New System.Windows.Forms.Timer(Me.components)
        Me.chkMaxVolume = New System.Windows.Forms.CheckBox()
        Me.grpMisc = New System.Windows.Forms.GroupBox()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnTest = New System.Windows.Forms.Button()
        Me.tmrTest = New System.Windows.Forms.Timer(Me.components)
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnDeviceNew = New System.Windows.Forms.Button()
        Me.lstInput = New System.Windows.Forms.ListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnInputNew = New System.Windows.Forms.Button()
        Me.btnJoystickEdit = New System.Windows.Forms.Button()
        Me.grpOutput.SuspendLayout()
        CType(Me.numOutputChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInput.SuspendLayout()
        CType(Me.numInputChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panDebug.SuspendLayout()
        Me.grpMisc.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpOutput
        '
        Me.grpOutput.Controls.Add(Me.chkNoteOut)
        Me.grpOutput.Controls.Add(Me.numOutputChannel)
        Me.grpOutput.Controls.Add(Me.Label5)
        Me.grpOutput.Controls.Add(Me.comOutput)
        Me.grpOutput.Enabled = False
        Me.grpOutput.Location = New System.Drawing.Point(243, 100)
        Me.grpOutput.Name = "grpOutput"
        Me.grpOutput.Size = New System.Drawing.Size(225, 70)
        Me.grpOutput.TabIndex = 5
        Me.grpOutput.TabStop = False
        Me.grpOutput.Text = "Output device"
        '
        'chkNoteOut
        '
        Me.chkNoteOut.AutoSize = True
        Me.chkNoteOut.Checked = True
        Me.chkNoteOut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoteOut.Location = New System.Drawing.Point(131, 46)
        Me.chkNoteOut.Name = "chkNoteOut"
        Me.chkNoteOut.Size = New System.Drawing.Size(82, 17)
        Me.chkNoteOut.TabIndex = 24
        Me.chkNoteOut.Text = "Note output"
        Me.ToolTips.SetToolTip(Me.chkNoteOut, "Usefull for when you have the same output and input." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "So you don't get dubble not" & _
                "es.")
        Me.chkNoteOut.UseVisualStyleBackColor = True
        '
        'numOutputChannel
        '
        Me.numOutputChannel.Location = New System.Drawing.Point(86, 43)
        Me.numOutputChannel.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numOutputChannel.Name = "numOutputChannel"
        Me.numOutputChannel.Size = New System.Drawing.Size(39, 20)
        Me.numOutputChannel.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "MIDI channel:"
        '
        'comOutput
        '
        Me.comOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comOutput.FormattingEnabled = True
        Me.comOutput.Location = New System.Drawing.Point(9, 21)
        Me.comOutput.Name = "comOutput"
        Me.comOutput.Size = New System.Drawing.Size(209, 21)
        Me.comOutput.TabIndex = 1
        '
        'grpInput
        '
        Me.grpInput.Controls.Add(Me.numInputChannel)
        Me.grpInput.Controls.Add(Me.comInput)
        Me.grpInput.Controls.Add(Me.Label6)
        Me.grpInput.Enabled = False
        Me.grpInput.Location = New System.Drawing.Point(12, 100)
        Me.grpInput.Name = "grpInput"
        Me.grpInput.Size = New System.Drawing.Size(225, 70)
        Me.grpInput.TabIndex = 5
        Me.grpInput.TabStop = False
        Me.grpInput.Text = "Input device"
        '
        'numInputChannel
        '
        Me.numInputChannel.Location = New System.Drawing.Point(86, 42)
        Me.numInputChannel.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numInputChannel.Name = "numInputChannel"
        Me.numInputChannel.Size = New System.Drawing.Size(39, 20)
        Me.numInputChannel.TabIndex = 3
        '
        'comInput
        '
        Me.comInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comInput.FormattingEnabled = True
        Me.comInput.Location = New System.Drawing.Point(6, 15)
        Me.comInput.Name = "comInput"
        Me.comInput.Size = New System.Drawing.Size(212, 21)
        Me.comInput.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "MIDI channel:"
        '
        'chkOldNote
        '
        Me.chkOldNote.AutoSize = True
        Me.chkOldNote.Checked = True
        Me.chkOldNote.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOldNote.Location = New System.Drawing.Point(6, 37)
        Me.chkOldNote.Name = "chkOldNote"
        Me.chkOldNote.Size = New System.Drawing.Size(112, 17)
        Me.chkOldNote.TabIndex = 16
        Me.chkOldNote.Text = "Remove old notes"
        Me.ToolTips.SetToolTip(Me.chkOldNote, "Will depress pressed notes with Altered notes.")
        Me.chkOldNote.UseVisualStyleBackColor = True
        '
        'chkDebug
        '
        Me.chkDebug.AutoSize = True
        Me.chkDebug.Enabled = False
        Me.chkDebug.Location = New System.Drawing.Point(643, 11)
        Me.chkDebug.Name = "chkDebug"
        Me.chkDebug.Size = New System.Drawing.Size(58, 17)
        Me.chkDebug.TabIndex = 17
        Me.chkDebug.Text = "Debug"
        Me.ToolTips.SetToolTip(Me.chkDebug, "Debug all commands going out.")
        Me.chkDebug.UseVisualStyleBackColor = True
        '
        'panDebug
        '
        Me.panDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panDebug.Controls.Add(Me.Label1)
        Me.panDebug.Controls.Add(Me.lstDebug)
        Me.panDebug.Controls.Add(Me.Label2)
        Me.panDebug.Controls.Add(Me.Label3)
        Me.panDebug.Controls.Add(Me.Label4)
        Me.panDebug.Enabled = False
        Me.panDebug.Location = New System.Drawing.Point(624, 25)
        Me.panDebug.Name = "panDebug"
        Me.panDebug.Size = New System.Drawing.Size(303, 241)
        Me.panDebug.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Command:"
        '
        'lstDebug
        '
        Me.lstDebug.FormattingEnabled = True
        Me.lstDebug.Location = New System.Drawing.Point(6, 32)
        Me.lstDebug.Name = "lstDebug"
        Me.lstDebug.ScrollAlwaysVisible = True
        Me.lstDebug.Size = New System.Drawing.Size(288, 199)
        Me.lstDebug.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Channel:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(131, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Data1:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(193, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Data2:"
        '
        'btnSS
        '
        Me.btnSS.Enabled = False
        Me.btnSS.Location = New System.Drawing.Point(474, 121)
        Me.btnSS.Name = "btnSS"
        Me.btnSS.Size = New System.Drawing.Size(75, 23)
        Me.btnSS.TabIndex = 19
        Me.btnSS.Text = "Start"
        Me.btnSS.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.Location = New System.Drawing.Point(12, 521)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(434, 17)
        Me.lblStatus.TabIndex = 20
        Me.lblStatus.Text = "Status: Loading..."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrInput
        '
        Me.tmrInput.Interval = 10
        '
        'chkMaxVolume
        '
        Me.chkMaxVolume.AutoSize = True
        Me.chkMaxVolume.Checked = True
        Me.chkMaxVolume.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMaxVolume.Location = New System.Drawing.Point(6, 19)
        Me.chkMaxVolume.Name = "chkMaxVolume"
        Me.chkMaxVolume.Size = New System.Drawing.Size(113, 17)
        Me.chkMaxVolume.TabIndex = 22
        Me.chkMaxVolume.Text = "Set volume to max"
        Me.ToolTips.SetToolTip(Me.chkMaxVolume, "Set the volume of each note to 127(maxmum volume)")
        Me.chkMaxVolume.UseVisualStyleBackColor = True
        '
        'grpMisc
        '
        Me.grpMisc.Controls.Add(Me.chkMaxVolume)
        Me.grpMisc.Controls.Add(Me.chkOldNote)
        Me.grpMisc.Enabled = False
        Me.grpMisc.Location = New System.Drawing.Point(421, 176)
        Me.grpMisc.Name = "grpMisc"
        Me.grpMisc.Size = New System.Drawing.Size(128, 66)
        Me.grpMisc.TabIndex = 23
        Me.grpMisc.TabStop = False
        Me.grpMisc.Text = "Misc"
        '
        'btnTest
        '
        Me.btnTest.Enabled = False
        Me.btnTest.Location = New System.Drawing.Point(474, 147)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 24
        Me.btnTest.Text = "Test"
        Me.ToolTips.SetToolTip(Me.btnTest, "Will test the output device by playing a few notes.")
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'tmrTest
        '
        '
        'lstDevices
        '
        Me.lstDevices.FormattingEnabled = True
        Me.lstDevices.Location = New System.Drawing.Point(12, 25)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(456, 69)
        Me.lstDevices.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Input device:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(249, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Output device:"
        '
        'btnDeviceNew
        '
        Me.btnDeviceNew.Location = New System.Drawing.Point(474, 55)
        Me.btnDeviceNew.Name = "btnDeviceNew"
        Me.btnDeviceNew.Size = New System.Drawing.Size(75, 23)
        Me.btnDeviceNew.TabIndex = 27
        Me.btnDeviceNew.Text = "New"
        Me.btnDeviceNew.UseVisualStyleBackColor = True
        '
        'lstInput
        '
        Me.lstInput.FormattingEnabled = True
        Me.lstInput.Location = New System.Drawing.Point(12, 230)
        Me.lstInput.Name = "lstInput"
        Me.lstInput.Size = New System.Drawing.Size(168, 238)
        Me.lstInput.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 214)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Input:"
        '
        'btnInputNew
        '
        Me.btnInputNew.Location = New System.Drawing.Point(186, 230)
        Me.btnInputNew.Name = "btnInputNew"
        Me.btnInputNew.Size = New System.Drawing.Size(44, 23)
        Me.btnInputNew.TabIndex = 27
        Me.btnInputNew.Text = "New"
        Me.btnInputNew.UseVisualStyleBackColor = True
        '
        'btnJoystickEdit
        '
        Me.btnJoystickEdit.Location = New System.Drawing.Point(186, 259)
        Me.btnJoystickEdit.Name = "btnJoystickEdit"
        Me.btnJoystickEdit.Size = New System.Drawing.Size(44, 23)
        Me.btnJoystickEdit.TabIndex = 27
        Me.btnJoystickEdit.Text = "Edit"
        Me.btnJoystickEdit.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 547)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lstInput)
        Me.Controls.Add(Me.btnJoystickEdit)
        Me.Controls.Add(Me.btnInputNew)
        Me.Controls.Add(Me.btnDeviceNew)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lstDevices)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.grpMisc)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnSS)
        Me.Controls.Add(Me.chkDebug)
        Me.Controls.Add(Me.panDebug)
        Me.Controls.Add(Me.grpInput)
        Me.Controls.Add(Me.grpOutput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedals"
        Me.grpOutput.ResumeLayout(False)
        Me.grpOutput.PerformLayout()
        CType(Me.numOutputChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInput.ResumeLayout(False)
        Me.grpInput.PerformLayout()
        CType(Me.numInputChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panDebug.ResumeLayout(False)
        Me.panDebug.PerformLayout()
        Me.grpMisc.ResumeLayout(False)
        Me.grpMisc.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpOutput As System.Windows.Forms.GroupBox
    Friend WithEvents comOutput As System.Windows.Forms.ComboBox
    Friend WithEvents grpInput As System.Windows.Forms.GroupBox
    Friend WithEvents comInput As System.Windows.Forms.ComboBox
    Friend WithEvents chkOldNote As System.Windows.Forms.CheckBox
    Friend WithEvents chkDebug As System.Windows.Forms.CheckBox
    Friend WithEvents panDebug As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstDebug As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSS As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents tmrInput As System.Windows.Forms.Timer
    Friend WithEvents numOutputChannel As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numInputChannel As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkMaxVolume As System.Windows.Forms.CheckBox
    Friend WithEvents grpMisc As System.Windows.Forms.GroupBox
    Friend WithEvents chkNoteOut As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents tmrTest As System.Windows.Forms.Timer
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnDeviceNew As System.Windows.Forms.Button
    Friend WithEvents lstInput As System.Windows.Forms.ListBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnInputNew As System.Windows.Forms.Button
    Friend WithEvents btnJoystickEdit As System.Windows.Forms.Button

End Class
