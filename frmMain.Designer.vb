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
		Me.lblLeft = New System.Windows.Forms.Label()
		Me.lblMiddle = New System.Windows.Forms.Label()
		Me.lblRight = New System.Windows.Forms.Label()
		Me.grpLeft = New System.Windows.Forms.GroupBox()
		Me.btnLeftInput = New System.Windows.Forms.Button()
		Me.comLeft = New System.Windows.Forms.ComboBox()
		Me.radLeft2 = New System.Windows.Forms.RadioButton()
		Me.radLeft = New System.Windows.Forms.RadioButton()
		Me.grpMiddle = New System.Windows.Forms.GroupBox()
		Me.btnMiddleInput = New System.Windows.Forms.Button()
		Me.comMiddle = New System.Windows.Forms.ComboBox()
		Me.radMiddle2 = New System.Windows.Forms.RadioButton()
		Me.radMiddle = New System.Windows.Forms.RadioButton()
		Me.grpRight = New System.Windows.Forms.GroupBox()
		Me.btnRightInput = New System.Windows.Forms.Button()
		Me.comRight = New System.Windows.Forms.ComboBox()
		Me.radRight2 = New System.Windows.Forms.RadioButton()
		Me.radRight = New System.Windows.Forms.RadioButton()
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
		Me.tmr = New System.Windows.Forms.Timer(Me.components)
		Me.chkMaxVolume = New System.Windows.Forms.CheckBox()
		Me.grpMisc = New System.Windows.Forms.GroupBox()
		Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
		Me.btnTest = New System.Windows.Forms.Button()
		Me.tmrTest = New System.Windows.Forms.Timer(Me.components)
		Me.grpLeft.SuspendLayout()
		Me.grpMiddle.SuspendLayout()
		Me.grpRight.SuspendLayout()
		Me.grpOutput.SuspendLayout()
		CType(Me.numOutputChannel, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grpInput.SuspendLayout()
		CType(Me.numInputChannel, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.panDebug.SuspendLayout()
		Me.grpMisc.SuspendLayout()
		Me.SuspendLayout()
		'
		'lblLeft
		'
		Me.lblLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblLeft.Location = New System.Drawing.Point(559, 9)
		Me.lblLeft.Name = "lblLeft"
		Me.lblLeft.Size = New System.Drawing.Size(70, 100)
		Me.lblLeft.TabIndex = 3
		Me.lblLeft.Text = "Left" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Soft)"
		Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ToolTips.SetToolTip(Me.lblLeft, "Just a visual pedal for you to look at.")
		'
		'lblMiddle
		'
		Me.lblMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblMiddle.Location = New System.Drawing.Point(635, 9)
		Me.lblMiddle.Name = "lblMiddle"
		Me.lblMiddle.Size = New System.Drawing.Size(70, 100)
		Me.lblMiddle.TabIndex = 3
		Me.lblMiddle.Text = "Middle" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Sostenuto)"
		Me.lblMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ToolTips.SetToolTip(Me.lblMiddle, "Just a visual pedal for you to look at.")
		'
		'lblRight
		'
		Me.lblRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblRight.Location = New System.Drawing.Point(711, 9)
		Me.lblRight.Name = "lblRight"
		Me.lblRight.Size = New System.Drawing.Size(70, 100)
		Me.lblRight.TabIndex = 3
		Me.lblRight.Text = "Right" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Sustain)"
		Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ToolTips.SetToolTip(Me.lblRight, "Just a visual pedal for you to look at.")
		'
		'grpLeft
		'
		Me.grpLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.grpLeft.Controls.Add(Me.btnLeftInput)
		Me.grpLeft.Controls.Add(Me.comLeft)
		Me.grpLeft.Controls.Add(Me.radLeft2)
		Me.grpLeft.Controls.Add(Me.radLeft)
		Me.grpLeft.Enabled = False
		Me.grpLeft.Location = New System.Drawing.Point(450, 112)
		Me.grpLeft.Name = "grpLeft"
		Me.grpLeft.Size = New System.Drawing.Size(179, 96)
		Me.grpLeft.TabIndex = 4
		Me.grpLeft.TabStop = False
		Me.grpLeft.Text = "Left"
		'
		'btnLeftInput
		'
		Me.btnLeftInput.Location = New System.Drawing.Point(97, 14)
		Me.btnLeftInput.Name = "btnLeftInput"
		Me.btnLeftInput.Size = New System.Drawing.Size(75, 23)
		Me.btnLeftInput.TabIndex = 2
		Me.btnLeftInput.Text = "Set input"
		Me.ToolTips.SetToolTip(Me.btnLeftInput, "Set the joystick axis.")
		Me.btnLeftInput.UseVisualStyleBackColor = True
		'
		'comLeft
		'
		Me.comLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comLeft.FormattingEnabled = True
		Me.comLeft.Location = New System.Drawing.Point(7, 66)
		Me.comLeft.Name = "comLeft"
		Me.comLeft.Size = New System.Drawing.Size(165, 21)
		Me.comLeft.TabIndex = 1
		Me.ToolTips.SetToolTip(Me.comLeft, "This is the MIDI controller to ouput to.")
		'
		'radLeft2
		'
		Me.radLeft2.AutoSize = True
		Me.radLeft2.Location = New System.Drawing.Point(7, 43)
		Me.radLeft2.Name = "radLeft2"
		Me.radLeft2.Size = New System.Drawing.Size(75, 17)
		Me.radLeft2.TabIndex = 0
		Me.radLeft2.Text = "Alter notes"
		Me.ToolTips.SetToolTip(Me.radLeft2, "Will alter the notes as they come in. To simulate pedals")
		Me.radLeft2.UseVisualStyleBackColor = True
		'
		'radLeft
		'
		Me.radLeft.AutoSize = True
		Me.radLeft.Checked = True
		Me.radLeft.Location = New System.Drawing.Point(7, 20)
		Me.radLeft.Name = "radLeft"
		Me.radLeft.Size = New System.Drawing.Size(70, 17)
		Me.radLeft.TabIndex = 0
		Me.radLeft.TabStop = True
		Me.radLeft.Text = "Use MIDI"
		Me.ToolTips.SetToolTip(Me.radLeft, "Use MIDI controller in the drop down box below.")
		Me.radLeft.UseVisualStyleBackColor = True
		'
		'grpMiddle
		'
		Me.grpMiddle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.grpMiddle.Controls.Add(Me.btnMiddleInput)
		Me.grpMiddle.Controls.Add(Me.comMiddle)
		Me.grpMiddle.Controls.Add(Me.radMiddle2)
		Me.grpMiddle.Controls.Add(Me.radMiddle)
		Me.grpMiddle.Enabled = False
		Me.grpMiddle.Location = New System.Drawing.Point(526, 214)
		Me.grpMiddle.Name = "grpMiddle"
		Me.grpMiddle.Size = New System.Drawing.Size(179, 96)
		Me.grpMiddle.TabIndex = 4
		Me.grpMiddle.TabStop = False
		Me.grpMiddle.Text = "Middle"
		'
		'btnMiddleInput
		'
		Me.btnMiddleInput.Location = New System.Drawing.Point(97, 14)
		Me.btnMiddleInput.Name = "btnMiddleInput"
		Me.btnMiddleInput.Size = New System.Drawing.Size(75, 23)
		Me.btnMiddleInput.TabIndex = 2
		Me.btnMiddleInput.Text = "Set input"
		Me.ToolTips.SetToolTip(Me.btnMiddleInput, "Set the joystick axis.")
		Me.btnMiddleInput.UseVisualStyleBackColor = True
		'
		'comMiddle
		'
		Me.comMiddle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comMiddle.FormattingEnabled = True
		Me.comMiddle.Location = New System.Drawing.Point(7, 66)
		Me.comMiddle.Name = "comMiddle"
		Me.comMiddle.Size = New System.Drawing.Size(165, 21)
		Me.comMiddle.TabIndex = 1
		Me.ToolTips.SetToolTip(Me.comMiddle, "This is the MIDI controller to ouput to.")
		'
		'radMiddle2
		'
		Me.radMiddle2.AutoSize = True
		Me.radMiddle2.Location = New System.Drawing.Point(7, 43)
		Me.radMiddle2.Name = "radMiddle2"
		Me.radMiddle2.Size = New System.Drawing.Size(75, 17)
		Me.radMiddle2.TabIndex = 0
		Me.radMiddle2.Text = "Alter notes"
		Me.ToolTips.SetToolTip(Me.radMiddle2, "Will alter the notes as they come in. To simulate pedals")
		Me.radMiddle2.UseVisualStyleBackColor = True
		'
		'radMiddle
		'
		Me.radMiddle.AutoSize = True
		Me.radMiddle.Checked = True
		Me.radMiddle.Location = New System.Drawing.Point(7, 20)
		Me.radMiddle.Name = "radMiddle"
		Me.radMiddle.Size = New System.Drawing.Size(70, 17)
		Me.radMiddle.TabIndex = 0
		Me.radMiddle.TabStop = True
		Me.radMiddle.Text = "Use MIDI"
		Me.ToolTips.SetToolTip(Me.radMiddle, "Use MIDI controller in the drop down box below.")
		Me.radMiddle.UseVisualStyleBackColor = True
		'
		'grpRight
		'
		Me.grpRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.grpRight.Controls.Add(Me.btnRightInput)
		Me.grpRight.Controls.Add(Me.comRight)
		Me.grpRight.Controls.Add(Me.radRight2)
		Me.grpRight.Controls.Add(Me.radRight)
		Me.grpRight.Enabled = False
		Me.grpRight.Location = New System.Drawing.Point(602, 316)
		Me.grpRight.Name = "grpRight"
		Me.grpRight.Size = New System.Drawing.Size(179, 96)
		Me.grpRight.TabIndex = 4
		Me.grpRight.TabStop = False
		Me.grpRight.Text = "Right"
		'
		'btnRightInput
		'
		Me.btnRightInput.Location = New System.Drawing.Point(97, 14)
		Me.btnRightInput.Name = "btnRightInput"
		Me.btnRightInput.Size = New System.Drawing.Size(75, 23)
		Me.btnRightInput.TabIndex = 2
		Me.btnRightInput.Text = "Set input"
		Me.ToolTips.SetToolTip(Me.btnRightInput, "Set the joystick axis.")
		Me.btnRightInput.UseVisualStyleBackColor = True
		'
		'comRight
		'
		Me.comRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comRight.FormattingEnabled = True
		Me.comRight.Location = New System.Drawing.Point(7, 66)
		Me.comRight.Name = "comRight"
		Me.comRight.Size = New System.Drawing.Size(165, 21)
		Me.comRight.TabIndex = 1
		Me.ToolTips.SetToolTip(Me.comRight, "This is the MIDI controller to ouput to.")
		'
		'radRight2
		'
		Me.radRight2.AutoSize = True
		Me.radRight2.Location = New System.Drawing.Point(7, 43)
		Me.radRight2.Name = "radRight2"
		Me.radRight2.Size = New System.Drawing.Size(75, 17)
		Me.radRight2.TabIndex = 0
		Me.radRight2.Text = "Alter notes"
		Me.ToolTips.SetToolTip(Me.radRight2, "Will alter the notes as they come in. To simulate pedals")
		Me.radRight2.UseVisualStyleBackColor = True
		'
		'radRight
		'
		Me.radRight.AutoSize = True
		Me.radRight.Checked = True
		Me.radRight.Location = New System.Drawing.Point(7, 20)
		Me.radRight.Name = "radRight"
		Me.radRight.Size = New System.Drawing.Size(70, 17)
		Me.radRight.TabIndex = 0
		Me.radRight.TabStop = True
		Me.radRight.Text = "Use MIDI"
		Me.ToolTips.SetToolTip(Me.radRight, "Use MIDI controller in the drop down box below.")
		Me.radRight.UseVisualStyleBackColor = True
		'
		'grpOutput
		'
		Me.grpOutput.Controls.Add(Me.chkNoteOut)
		Me.grpOutput.Controls.Add(Me.numOutputChannel)
		Me.grpOutput.Controls.Add(Me.Label5)
		Me.grpOutput.Controls.Add(Me.comOutput)
		Me.grpOutput.Enabled = False
		Me.grpOutput.Location = New System.Drawing.Point(241, 12)
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
		Me.numOutputChannel.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
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
		Me.grpInput.Location = New System.Drawing.Point(12, 9)
		Me.grpInput.Name = "grpInput"
		Me.grpInput.Size = New System.Drawing.Size(223, 70)
		Me.grpInput.TabIndex = 5
		Me.grpInput.TabStop = False
		Me.grpInput.Text = "Input device"
		'
		'numInputChannel
		'
		Me.numInputChannel.Location = New System.Drawing.Point(86, 42)
		Me.numInputChannel.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
		Me.numInputChannel.Name = "numInputChannel"
		Me.numInputChannel.Size = New System.Drawing.Size(39, 20)
		Me.numInputChannel.TabIndex = 3
		'
		'comInput
		'
		Me.comInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comInput.FormattingEnabled = True
		Me.comInput.Location = New System.Drawing.Point(6, 21)
		Me.comInput.Name = "comInput"
		Me.comInput.Size = New System.Drawing.Size(209, 21)
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
		Me.chkDebug.Location = New System.Drawing.Point(31, 121)
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
		Me.panDebug.Location = New System.Drawing.Point(12, 135)
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
		Me.btnSS.Location = New System.Drawing.Point(12, 382)
		Me.btnSS.Name = "btnSS"
		Me.btnSS.Size = New System.Drawing.Size(75, 23)
		Me.btnSS.TabIndex = 19
		Me.btnSS.Text = "Start"
		Me.btnSS.UseVisualStyleBackColor = True
		'
		'lblStatus
		'
		Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
		Me.lblStatus.Location = New System.Drawing.Point(93, 388)
		Me.lblStatus.Name = "lblStatus"
		Me.lblStatus.Size = New System.Drawing.Size(434, 17)
		Me.lblStatus.TabIndex = 20
		Me.lblStatus.Text = "Status: Loading..."
		Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tmr
		'
		Me.tmr.Interval = 10
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
		Me.grpMisc.Location = New System.Drawing.Point(399, 316)
		Me.grpMisc.Name = "grpMisc"
		Me.grpMisc.Size = New System.Drawing.Size(128, 66)
		Me.grpMisc.TabIndex = 23
		Me.grpMisc.TabStop = False
		Me.grpMisc.Text = "Misc"
		'
		'btnTest
		'
		Me.btnTest.Enabled = False
		Me.btnTest.Location = New System.Drawing.Point(321, 135)
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
		'frmMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(793, 418)
		Me.Controls.Add(Me.btnTest)
		Me.Controls.Add(Me.grpMisc)
		Me.Controls.Add(Me.lblStatus)
		Me.Controls.Add(Me.btnSS)
		Me.Controls.Add(Me.chkDebug)
		Me.Controls.Add(Me.panDebug)
		Me.Controls.Add(Me.grpInput)
		Me.Controls.Add(Me.grpOutput)
		Me.Controls.Add(Me.grpRight)
		Me.Controls.Add(Me.grpMiddle)
		Me.Controls.Add(Me.grpLeft)
		Me.Controls.Add(Me.lblRight)
		Me.Controls.Add(Me.lblMiddle)
		Me.Controls.Add(Me.lblLeft)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Pedals"
		Me.grpLeft.ResumeLayout(False)
		Me.grpLeft.PerformLayout()
		Me.grpMiddle.ResumeLayout(False)
		Me.grpMiddle.PerformLayout()
		Me.grpRight.ResumeLayout(False)
		Me.grpRight.PerformLayout()
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
	Friend WithEvents lblLeft As System.Windows.Forms.Label
	Friend WithEvents lblMiddle As System.Windows.Forms.Label
	Friend WithEvents lblRight As System.Windows.Forms.Label
	Friend WithEvents grpLeft As System.Windows.Forms.GroupBox
	Friend WithEvents comLeft As System.Windows.Forms.ComboBox
	Friend WithEvents radLeft2 As System.Windows.Forms.RadioButton
	Friend WithEvents radLeft As System.Windows.Forms.RadioButton
	Friend WithEvents grpMiddle As System.Windows.Forms.GroupBox
	Friend WithEvents comMiddle As System.Windows.Forms.ComboBox
	Friend WithEvents radMiddle2 As System.Windows.Forms.RadioButton
	Friend WithEvents radMiddle As System.Windows.Forms.RadioButton
	Friend WithEvents grpRight As System.Windows.Forms.GroupBox
	Friend WithEvents comRight As System.Windows.Forms.ComboBox
	Friend WithEvents radRight2 As System.Windows.Forms.RadioButton
	Friend WithEvents radRight As System.Windows.Forms.RadioButton
	Friend WithEvents grpOutput As System.Windows.Forms.GroupBox
	Friend WithEvents comOutput As System.Windows.Forms.ComboBox
	Friend WithEvents grpInput As System.Windows.Forms.GroupBox
	Friend WithEvents comInput As System.Windows.Forms.ComboBox
	Friend WithEvents btnLeftInput As System.Windows.Forms.Button
	Friend WithEvents btnMiddleInput As System.Windows.Forms.Button
	Friend WithEvents btnRightInput As System.Windows.Forms.Button
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
	Friend WithEvents tmr As System.Windows.Forms.Timer
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

End Class
