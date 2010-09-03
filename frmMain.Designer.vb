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
        Me.grpMidiOutput = New System.Windows.Forms.GroupBox()
        Me.btnMidiRemove = New System.Windows.Forms.Button()
        Me.lstMidiOutput = New System.Windows.Forms.ListBox()
        Me.btnMidiOutputAdd = New System.Windows.Forms.Button()
        Me.numOutputChannel = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.comOutput = New System.Windows.Forms.ComboBox()
        Me.grpMidiInput = New System.Windows.Forms.GroupBox()
        Me.chkMidiInputVolume = New System.Windows.Forms.CheckBox()
        Me.btnMidiInputRemove = New System.Windows.Forms.Button()
        Me.chkMidiInputChannels = New System.Windows.Forms.CheckBox()
        Me.btnMidiInputAdd = New System.Windows.Forms.Button()
        Me.lstMidiInput = New System.Windows.Forms.ListBox()
        Me.chkMidiInputNotes = New System.Windows.Forms.CheckBox()
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
        Me.grpMisc = New System.Windows.Forms.GroupBox()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnTest = New System.Windows.Forms.Button()
        Me.tmrTest = New System.Windows.Forms.Timer(Me.components)
        Me.lstInput = New System.Windows.Forms.ListBox()
        Me.btnInputAdd = New System.Windows.Forms.Button()
        Me.btnInputEdit = New System.Windows.Forms.Button()
        Me.grpInput = New System.Windows.Forms.GroupBox()
        Me.btnInputRemove = New System.Windows.Forms.Button()
        Me.grpMidiOutput.SuspendLayout()
        CType(Me.numOutputChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMidiInput.SuspendLayout()
        CType(Me.numInputChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panDebug.SuspendLayout()
        Me.grpMisc.SuspendLayout()
        Me.grpInput.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpMidiOutput
        '
        Me.grpMidiOutput.Controls.Add(Me.btnMidiRemove)
        Me.grpMidiOutput.Controls.Add(Me.lstMidiOutput)
        Me.grpMidiOutput.Controls.Add(Me.btnMidiOutputAdd)
        Me.grpMidiOutput.Controls.Add(Me.numOutputChannel)
        Me.grpMidiOutput.Controls.Add(Me.Label5)
        Me.grpMidiOutput.Controls.Add(Me.comOutput)
        Me.grpMidiOutput.Enabled = False
        Me.grpMidiOutput.Location = New System.Drawing.Point(243, 11)
        Me.grpMidiOutput.Name = "grpMidiOutput"
        Me.grpMidiOutput.Size = New System.Drawing.Size(231, 167)
        Me.grpMidiOutput.TabIndex = 5
        Me.grpMidiOutput.TabStop = False
        Me.grpMidiOutput.Text = "Output device"
        '
        'btnMidiRemove
        '
        Me.btnMidiRemove.Location = New System.Drawing.Point(73, 93)
        Me.btnMidiRemove.Name = "btnMidiRemove"
        Me.btnMidiRemove.Size = New System.Drawing.Size(61, 20)
        Me.btnMidiRemove.TabIndex = 30
        Me.btnMidiRemove.Text = "Remove"
        Me.btnMidiRemove.UseVisualStyleBackColor = True
        '
        'lstMidiOutput
        '
        Me.lstMidiOutput.FormattingEnabled = True
        Me.lstMidiOutput.Location = New System.Drawing.Point(6, 18)
        Me.lstMidiOutput.Name = "lstMidiOutput"
        Me.lstMidiOutput.Size = New System.Drawing.Size(219, 69)
        Me.lstMidiOutput.TabIndex = 30
        '
        'btnMidiOutputAdd
        '
        Me.btnMidiOutputAdd.Location = New System.Drawing.Point(6, 93)
        Me.btnMidiOutputAdd.Name = "btnMidiOutputAdd"
        Me.btnMidiOutputAdd.Size = New System.Drawing.Size(61, 20)
        Me.btnMidiOutputAdd.TabIndex = 30
        Me.btnMidiOutputAdd.Text = "Add"
        Me.btnMidiOutputAdd.UseVisualStyleBackColor = True
        '
        'numOutputChannel
        '
        Me.numOutputChannel.Location = New System.Drawing.Point(86, 141)
        Me.numOutputChannel.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numOutputChannel.Name = "numOutputChannel"
        Me.numOutputChannel.Size = New System.Drawing.Size(39, 20)
        Me.numOutputChannel.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "MIDI channel:"
        '
        'comOutput
        '
        Me.comOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comOutput.FormattingEnabled = True
        Me.comOutput.Location = New System.Drawing.Point(6, 119)
        Me.comOutput.Name = "comOutput"
        Me.comOutput.Size = New System.Drawing.Size(219, 21)
        Me.comOutput.TabIndex = 1
        '
        'grpMidiInput
        '
        Me.grpMidiInput.Controls.Add(Me.chkMidiInputVolume)
        Me.grpMidiInput.Controls.Add(Me.btnMidiInputRemove)
        Me.grpMidiInput.Controls.Add(Me.chkMidiInputChannels)
        Me.grpMidiInput.Controls.Add(Me.btnMidiInputAdd)
        Me.grpMidiInput.Controls.Add(Me.lstMidiInput)
        Me.grpMidiInput.Controls.Add(Me.chkMidiInputNotes)
        Me.grpMidiInput.Controls.Add(Me.numInputChannel)
        Me.grpMidiInput.Controls.Add(Me.comInput)
        Me.grpMidiInput.Controls.Add(Me.Label6)
        Me.grpMidiInput.Enabled = False
        Me.grpMidiInput.Location = New System.Drawing.Point(12, 11)
        Me.grpMidiInput.Name = "grpMidiInput"
        Me.grpMidiInput.Size = New System.Drawing.Size(231, 200)
        Me.grpMidiInput.TabIndex = 5
        Me.grpMidiInput.TabStop = False
        Me.grpMidiInput.Text = "Input device"
        '
        'chkMidiInputVolume
        '
        Me.chkMidiInputVolume.AutoSize = True
        Me.chkMidiInputVolume.Checked = True
        Me.chkMidiInputVolume.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMidiInputVolume.Location = New System.Drawing.Point(112, 173)
        Me.chkMidiInputVolume.Name = "chkMidiInputVolume"
        Me.chkMidiInputVolume.Size = New System.Drawing.Size(113, 17)
        Me.chkMidiInputVolume.TabIndex = 22
        Me.chkMidiInputVolume.Text = "Set volume to max"
        Me.ToolTips.SetToolTip(Me.chkMidiInputVolume, "Set the volume of each note to 127(maxmum volume)")
        Me.chkMidiInputVolume.UseVisualStyleBackColor = True
        '
        'btnMidiInputRemove
        '
        Me.btnMidiInputRemove.Location = New System.Drawing.Point(76, 94)
        Me.btnMidiInputRemove.Name = "btnMidiInputRemove"
        Me.btnMidiInputRemove.Size = New System.Drawing.Size(61, 20)
        Me.btnMidiInputRemove.TabIndex = 30
        Me.btnMidiInputRemove.Text = "Remove"
        Me.btnMidiInputRemove.UseVisualStyleBackColor = True
        '
        'chkMidiInputChannels
        '
        Me.chkMidiInputChannels.AutoSize = True
        Me.chkMidiInputChannels.Location = New System.Drawing.Point(131, 147)
        Me.chkMidiInputChannels.Name = "chkMidiInputChannels"
        Me.chkMidiInputChannels.Size = New System.Drawing.Size(83, 17)
        Me.chkMidiInputChannels.TabIndex = 26
        Me.chkMidiInputChannels.Text = "All channels"
        Me.ToolTips.SetToolTip(Me.chkMidiInputChannels, "Usefull for when you have the same output and input." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "So you don't get dubble not" & _
                "es.")
        Me.chkMidiInputChannels.UseVisualStyleBackColor = True
        '
        'btnMidiInputAdd
        '
        Me.btnMidiInputAdd.Location = New System.Drawing.Point(9, 94)
        Me.btnMidiInputAdd.Name = "btnMidiInputAdd"
        Me.btnMidiInputAdd.Size = New System.Drawing.Size(61, 20)
        Me.btnMidiInputAdd.TabIndex = 30
        Me.btnMidiInputAdd.Text = "Add"
        Me.btnMidiInputAdd.UseVisualStyleBackColor = True
        '
        'lstMidiInput
        '
        Me.lstMidiInput.FormattingEnabled = True
        Me.lstMidiInput.Location = New System.Drawing.Point(9, 19)
        Me.lstMidiInput.Name = "lstMidiInput"
        Me.lstMidiInput.Size = New System.Drawing.Size(216, 69)
        Me.lstMidiInput.TabIndex = 30
        '
        'chkMidiInputNotes
        '
        Me.chkMidiInputNotes.AutoSize = True
        Me.chkMidiInputNotes.Checked = True
        Me.chkMidiInputNotes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMidiInputNotes.Location = New System.Drawing.Point(9, 173)
        Me.chkMidiInputNotes.Name = "chkMidiInputNotes"
        Me.chkMidiInputNotes.Size = New System.Drawing.Size(88, 17)
        Me.chkMidiInputNotes.TabIndex = 25
        Me.chkMidiInputNotes.Text = "Enable notes"
        Me.ToolTips.SetToolTip(Me.chkMidiInputNotes, "Usefull for when you have the same output and input." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "So you don't get dubble not" & _
                "es.")
        Me.chkMidiInputNotes.UseVisualStyleBackColor = True
        '
        'numInputChannel
        '
        Me.numInputChannel.Location = New System.Drawing.Point(86, 147)
        Me.numInputChannel.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numInputChannel.Name = "numInputChannel"
        Me.numInputChannel.Size = New System.Drawing.Size(39, 20)
        Me.numInputChannel.TabIndex = 3
        '
        'comInput
        '
        Me.comInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comInput.FormattingEnabled = True
        Me.comInput.Location = New System.Drawing.Point(6, 120)
        Me.comInput.Name = "comInput"
        Me.comInput.Size = New System.Drawing.Size(219, 21)
        Me.comInput.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 149)
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
        Me.chkDebug.Location = New System.Drawing.Point(190, 233)
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
        Me.panDebug.Location = New System.Drawing.Point(171, 247)
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
        Me.btnSS.Location = New System.Drawing.Point(480, 326)
        Me.btnSS.Name = "btnSS"
        Me.btnSS.Size = New System.Drawing.Size(75, 23)
        Me.btnSS.TabIndex = 19
        Me.btnSS.Text = "Start"
        Me.btnSS.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblStatus.Location = New System.Drawing.Point(0, 495)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(697, 19)
        Me.lblStatus.TabIndex = 20
        Me.lblStatus.Text = "Status: Loading..."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrInput
        '
        Me.tmrInput.Interval = 10
        '
        'grpMisc
        '
        Me.grpMisc.Controls.Add(Me.chkOldNote)
        Me.grpMisc.Enabled = False
        Me.grpMisc.Location = New System.Drawing.Point(561, 326)
        Me.grpMisc.Name = "grpMisc"
        Me.grpMisc.Size = New System.Drawing.Size(128, 66)
        Me.grpMisc.TabIndex = 23
        Me.grpMisc.TabStop = False
        Me.grpMisc.Text = "Misc"
        '
        'btnTest
        '
        Me.btnTest.Enabled = False
        Me.btnTest.Location = New System.Drawing.Point(480, 352)
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
        'lstInput
        '
        Me.lstInput.FormattingEnabled = True
        Me.lstInput.Location = New System.Drawing.Point(8, 18)
        Me.lstInput.Name = "lstInput"
        Me.lstInput.Size = New System.Drawing.Size(195, 238)
        Me.lstInput.TabIndex = 28
        '
        'btnInputAdd
        '
        Me.btnInputAdd.Location = New System.Drawing.Point(8, 262)
        Me.btnInputAdd.Name = "btnInputAdd"
        Me.btnInputAdd.Size = New System.Drawing.Size(61, 20)
        Me.btnInputAdd.TabIndex = 27
        Me.btnInputAdd.Text = "Add"
        Me.btnInputAdd.UseVisualStyleBackColor = True
        '
        'btnInputEdit
        '
        Me.btnInputEdit.Location = New System.Drawing.Point(75, 261)
        Me.btnInputEdit.Name = "btnInputEdit"
        Me.btnInputEdit.Size = New System.Drawing.Size(61, 21)
        Me.btnInputEdit.TabIndex = 27
        Me.btnInputEdit.Text = "Edit"
        Me.btnInputEdit.UseVisualStyleBackColor = True
        '
        'grpInput
        '
        Me.grpInput.Controls.Add(Me.btnInputRemove)
        Me.grpInput.Controls.Add(Me.lstInput)
        Me.grpInput.Controls.Add(Me.btnInputAdd)
        Me.grpInput.Controls.Add(Me.btnInputEdit)
        Me.grpInput.Location = New System.Drawing.Point(480, 11)
        Me.grpInput.Name = "grpInput"
        Me.grpInput.Size = New System.Drawing.Size(209, 295)
        Me.grpInput.TabIndex = 30
        Me.grpInput.TabStop = False
        Me.grpInput.Text = "Input"
        '
        'btnInputRemove
        '
        Me.btnInputRemove.Location = New System.Drawing.Point(142, 262)
        Me.btnInputRemove.Name = "btnInputRemove"
        Me.btnInputRemove.Size = New System.Drawing.Size(61, 20)
        Me.btnInputRemove.TabIndex = 30
        Me.btnInputRemove.Text = "Remove"
        Me.btnInputRemove.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 514)
        Me.Controls.Add(Me.grpInput)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.grpMisc)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnSS)
        Me.Controls.Add(Me.chkDebug)
        Me.Controls.Add(Me.panDebug)
        Me.Controls.Add(Me.grpMidiInput)
        Me.Controls.Add(Me.grpMidiOutput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedals"
        Me.grpMidiOutput.ResumeLayout(False)
        Me.grpMidiOutput.PerformLayout()
        CType(Me.numOutputChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMidiInput.ResumeLayout(False)
        Me.grpMidiInput.PerformLayout()
        CType(Me.numInputChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panDebug.ResumeLayout(False)
        Me.panDebug.PerformLayout()
        Me.grpMisc.ResumeLayout(False)
        Me.grpMisc.PerformLayout()
        Me.grpInput.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpMidiOutput As System.Windows.Forms.GroupBox
    Friend WithEvents comOutput As System.Windows.Forms.ComboBox
    Friend WithEvents grpMidiInput As System.Windows.Forms.GroupBox
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
    Friend WithEvents chkMidiInputVolume As System.Windows.Forms.CheckBox
    Friend WithEvents grpMisc As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents tmrTest As System.Windows.Forms.Timer
    Friend WithEvents lstInput As System.Windows.Forms.ListBox
    Friend WithEvents btnInputAdd As System.Windows.Forms.Button
    Friend WithEvents btnInputEdit As System.Windows.Forms.Button
    Friend WithEvents chkMidiInputChannels As System.Windows.Forms.CheckBox
    Friend WithEvents chkMidiInputNotes As System.Windows.Forms.CheckBox
    Friend WithEvents lstMidiInput As System.Windows.Forms.ListBox
    Friend WithEvents lstMidiOutput As System.Windows.Forms.ListBox
    Friend WithEvents btnMidiRemove As System.Windows.Forms.Button
    Friend WithEvents btnMidiOutputAdd As System.Windows.Forms.Button
    Friend WithEvents btnMidiInputRemove As System.Windows.Forms.Button
    Friend WithEvents btnMidiInputAdd As System.Windows.Forms.Button
    Friend WithEvents grpInput As System.Windows.Forms.GroupBox
    Friend WithEvents btnInputRemove As System.Windows.Forms.Button

End Class
