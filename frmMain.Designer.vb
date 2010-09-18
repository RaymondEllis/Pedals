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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.grpMidiOutput = New System.Windows.Forms.GroupBox()
        Me.panMidiOutput = New System.Windows.Forms.Panel()
        Me.btnMidiOutputRemove = New System.Windows.Forms.Button()
        Me.btnMidiOutputSet = New System.Windows.Forms.Button()
        Me.lstMidiOutput = New System.Windows.Forms.ListBox()
        Me.comOutput = New System.Windows.Forms.ComboBox()
        Me.btnMidiOutputAdd = New System.Windows.Forms.Button()
        Me.numMidiOutputInsturment = New System.Windows.Forms.NumericUpDown()
        Me.numMidiOutputChannel = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grpMidiInput = New System.Windows.Forms.GroupBox()
        Me.panMidiInput = New System.Windows.Forms.Panel()
        Me.lstMidiInput = New System.Windows.Forms.ListBox()
        Me.btnMidiInputSet = New System.Windows.Forms.Button()
        Me.btnMidiInputRemove = New System.Windows.Forms.Button()
        Me.btnMidiInputAdd = New System.Windows.Forms.Button()
        Me.comInput = New System.Windows.Forms.ComboBox()
        Me.chkMidiInputVolume = New System.Windows.Forms.CheckBox()
        Me.chkMidiInputChannels = New System.Windows.Forms.CheckBox()
        Me.chkMidiInputNotes = New System.Windows.Forms.CheckBox()
        Me.numMidiInputChannel = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkRemoveOldNotes = New System.Windows.Forms.CheckBox()
        Me.chkDebug = New System.Windows.Forms.CheckBox()
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
        Me.grpDebug = New System.Windows.Forms.GroupBox()
        Me.chkMidiInputInstrument = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.grpMidiOutput.SuspendLayout()
        Me.panMidiOutput.SuspendLayout()
        CType(Me.numMidiOutputInsturment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMidiOutputChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMidiInput.SuspendLayout()
        Me.panMidiInput.SuspendLayout()
        CType(Me.numMidiInputChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMisc.SuspendLayout()
        Me.grpInput.SuspendLayout()
        Me.grpDebug.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpMidiOutput
        '
        Me.grpMidiOutput.Controls.Add(Me.panMidiOutput)
        Me.grpMidiOutput.Controls.Add(Me.numMidiOutputInsturment)
        Me.grpMidiOutput.Controls.Add(Me.numMidiOutputChannel)
        Me.grpMidiOutput.Controls.Add(Me.Label7)
        Me.grpMidiOutput.Controls.Add(Me.Label5)
        Me.grpMidiOutput.Enabled = False
        Me.grpMidiOutput.Location = New System.Drawing.Point(240, 12)
        Me.grpMidiOutput.Name = "grpMidiOutput"
        Me.grpMidiOutput.Size = New System.Drawing.Size(231, 200)
        Me.grpMidiOutput.TabIndex = 5
        Me.grpMidiOutput.TabStop = False
        Me.grpMidiOutput.Text = "MIDI Output device"
        '
        'panMidiOutput
        '
        Me.panMidiOutput.Controls.Add(Me.btnMidiOutputRemove)
        Me.panMidiOutput.Controls.Add(Me.btnMidiOutputSet)
        Me.panMidiOutput.Controls.Add(Me.lstMidiOutput)
        Me.panMidiOutput.Controls.Add(Me.comOutput)
        Me.panMidiOutput.Controls.Add(Me.btnMidiOutputAdd)
        Me.panMidiOutput.Enabled = False
        Me.panMidiOutput.Location = New System.Drawing.Point(6, 18)
        Me.panMidiOutput.Name = "panMidiOutput"
        Me.panMidiOutput.Size = New System.Drawing.Size(219, 124)
        Me.panMidiOutput.TabIndex = 31
        '
        'btnMidiOutputRemove
        '
        Me.btnMidiOutputRemove.Enabled = False
        Me.btnMidiOutputRemove.Location = New System.Drawing.Point(67, 75)
        Me.btnMidiOutputRemove.Name = "btnMidiOutputRemove"
        Me.btnMidiOutputRemove.Size = New System.Drawing.Size(61, 20)
        Me.btnMidiOutputRemove.TabIndex = 30
        Me.btnMidiOutputRemove.Text = "Remove"
        Me.btnMidiOutputRemove.UseVisualStyleBackColor = True
        '
        'btnMidiOutputSet
        '
        Me.btnMidiOutputSet.Enabled = False
        Me.btnMidiOutputSet.Location = New System.Drawing.Point(158, 75)
        Me.btnMidiOutputSet.Name = "btnMidiOutputSet"
        Me.btnMidiOutputSet.Size = New System.Drawing.Size(61, 20)
        Me.btnMidiOutputSet.TabIndex = 30
        Me.btnMidiOutputSet.Text = "Set"
        Me.btnMidiOutputSet.UseVisualStyleBackColor = True
        '
        'lstMidiOutput
        '
        Me.lstMidiOutput.FormattingEnabled = True
        Me.lstMidiOutput.Location = New System.Drawing.Point(0, 0)
        Me.lstMidiOutput.Name = "lstMidiOutput"
        Me.lstMidiOutput.Size = New System.Drawing.Size(219, 69)
        Me.lstMidiOutput.TabIndex = 30
        '
        'comOutput
        '
        Me.comOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comOutput.FormattingEnabled = True
        Me.comOutput.Location = New System.Drawing.Point(0, 101)
        Me.comOutput.Name = "comOutput"
        Me.comOutput.Size = New System.Drawing.Size(219, 21)
        Me.comOutput.TabIndex = 1
        '
        'btnMidiOutputAdd
        '
        Me.btnMidiOutputAdd.Location = New System.Drawing.Point(0, 75)
        Me.btnMidiOutputAdd.Name = "btnMidiOutputAdd"
        Me.btnMidiOutputAdd.Size = New System.Drawing.Size(61, 20)
        Me.btnMidiOutputAdd.TabIndex = 30
        Me.btnMidiOutputAdd.Text = "Add"
        Me.btnMidiOutputAdd.UseVisualStyleBackColor = True
        '
        'numMidiOutputInsturment
        '
        Me.numMidiOutputInsturment.Location = New System.Drawing.Point(77, 171)
        Me.numMidiOutputInsturment.Maximum = New Decimal(New Integer() {128, 0, 0, 0})
        Me.numMidiOutputInsturment.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMidiOutputInsturment.Name = "numMidiOutputInsturment"
        Me.numMidiOutputInsturment.Size = New System.Drawing.Size(48, 20)
        Me.numMidiOutputInsturment.TabIndex = 3
        Me.numMidiOutputInsturment.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numMidiOutputChannel
        '
        Me.numMidiOutputChannel.Location = New System.Drawing.Point(86, 141)
        Me.numMidiOutputChannel.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
        Me.numMidiOutputChannel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMidiOutputChannel.Name = "numMidiOutputChannel"
        Me.numMidiOutputChannel.Size = New System.Drawing.Size(39, 20)
        Me.numMidiOutputChannel.TabIndex = 3
        Me.numMidiOutputChannel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Instrument:"
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
        'grpMidiInput
        '
        Me.grpMidiInput.Controls.Add(Me.CheckBox1)
        Me.grpMidiInput.Controls.Add(Me.chkMidiInputInstrument)
        Me.grpMidiInput.Controls.Add(Me.panMidiInput)
        Me.grpMidiInput.Controls.Add(Me.chkMidiInputVolume)
        Me.grpMidiInput.Controls.Add(Me.chkMidiInputChannels)
        Me.grpMidiInput.Controls.Add(Me.chkMidiInputNotes)
        Me.grpMidiInput.Controls.Add(Me.numMidiInputChannel)
        Me.grpMidiInput.Controls.Add(Me.Label6)
        Me.grpMidiInput.Enabled = False
        Me.grpMidiInput.Location = New System.Drawing.Point(3, 12)
        Me.grpMidiInput.Name = "grpMidiInput"
        Me.grpMidiInput.Size = New System.Drawing.Size(231, 254)
        Me.grpMidiInput.TabIndex = 5
        Me.grpMidiInput.TabStop = False
        Me.grpMidiInput.Text = "MIDI Input device"
        '
        'panMidiInput
        '
        Me.panMidiInput.Controls.Add(Me.lstMidiInput)
        Me.panMidiInput.Controls.Add(Me.btnMidiInputSet)
        Me.panMidiInput.Controls.Add(Me.btnMidiInputRemove)
        Me.panMidiInput.Controls.Add(Me.btnMidiInputAdd)
        Me.panMidiInput.Controls.Add(Me.comInput)
        Me.panMidiInput.Enabled = False
        Me.panMidiInput.Location = New System.Drawing.Point(6, 18)
        Me.panMidiInput.Name = "panMidiInput"
        Me.panMidiInput.Size = New System.Drawing.Size(219, 122)
        Me.panMidiInput.TabIndex = 31
        '
        'lstMidiInput
        '
        Me.lstMidiInput.FormattingEnabled = True
        Me.lstMidiInput.Location = New System.Drawing.Point(0, 0)
        Me.lstMidiInput.Name = "lstMidiInput"
        Me.lstMidiInput.Size = New System.Drawing.Size(219, 69)
        Me.lstMidiInput.TabIndex = 30
        '
        'btnMidiInputSet
        '
        Me.btnMidiInputSet.Enabled = False
        Me.btnMidiInputSet.Location = New System.Drawing.Point(158, 75)
        Me.btnMidiInputSet.Name = "btnMidiInputSet"
        Me.btnMidiInputSet.Size = New System.Drawing.Size(61, 20)
        Me.btnMidiInputSet.TabIndex = 30
        Me.btnMidiInputSet.Text = "Set"
        Me.btnMidiInputSet.UseVisualStyleBackColor = True
        '
        'btnMidiInputRemove
        '
        Me.btnMidiInputRemove.Enabled = False
        Me.btnMidiInputRemove.Location = New System.Drawing.Point(70, 75)
        Me.btnMidiInputRemove.Name = "btnMidiInputRemove"
        Me.btnMidiInputRemove.Size = New System.Drawing.Size(61, 20)
        Me.btnMidiInputRemove.TabIndex = 30
        Me.btnMidiInputRemove.Text = "Remove"
        Me.btnMidiInputRemove.UseVisualStyleBackColor = True
        '
        'btnMidiInputAdd
        '
        Me.btnMidiInputAdd.Location = New System.Drawing.Point(3, 75)
        Me.btnMidiInputAdd.Name = "btnMidiInputAdd"
        Me.btnMidiInputAdd.Size = New System.Drawing.Size(61, 20)
        Me.btnMidiInputAdd.TabIndex = 30
        Me.btnMidiInputAdd.Text = "Add"
        Me.btnMidiInputAdd.UseVisualStyleBackColor = True
        '
        'comInput
        '
        Me.comInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comInput.FormattingEnabled = True
        Me.comInput.Location = New System.Drawing.Point(0, 101)
        Me.comInput.Name = "comInput"
        Me.comInput.Size = New System.Drawing.Size(219, 21)
        Me.comInput.TabIndex = 1
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
        'chkMidiInputChannels
        '
        Me.chkMidiInputChannels.AutoSize = True
        Me.chkMidiInputChannels.Location = New System.Drawing.Point(131, 147)
        Me.chkMidiInputChannels.Name = "chkMidiInputChannels"
        Me.chkMidiInputChannels.Size = New System.Drawing.Size(83, 17)
        Me.chkMidiInputChannels.TabIndex = 26
        Me.chkMidiInputChannels.Text = "All channels"
        Me.ToolTips.SetToolTip(Me.chkMidiInputChannels, "Recive input form all channels?")
        Me.chkMidiInputChannels.UseVisualStyleBackColor = True
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
        Me.ToolTips.SetToolTip(Me.chkMidiInputNotes, "If checked then it will not recive any notes from the selected input device.")
        Me.chkMidiInputNotes.UseVisualStyleBackColor = True
        '
        'numMidiInputChannel
        '
        Me.numMidiInputChannel.Location = New System.Drawing.Point(86, 147)
        Me.numMidiInputChannel.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
        Me.numMidiInputChannel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMidiInputChannel.Name = "numMidiInputChannel"
        Me.numMidiInputChannel.Size = New System.Drawing.Size(39, 20)
        Me.numMidiInputChannel.TabIndex = 3
        Me.numMidiInputChannel.Value = New Decimal(New Integer() {1, 0, 0, 0})
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
        'chkRemoveOldNotes
        '
        Me.chkRemoveOldNotes.AutoSize = True
        Me.chkRemoveOldNotes.Checked = True
        Me.chkRemoveOldNotes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRemoveOldNotes.Location = New System.Drawing.Point(6, 19)
        Me.chkRemoveOldNotes.Name = "chkRemoveOldNotes"
        Me.chkRemoveOldNotes.Size = New System.Drawing.Size(112, 17)
        Me.chkRemoveOldNotes.TabIndex = 16
        Me.chkRemoveOldNotes.Text = "Remove old notes"
        Me.ToolTips.SetToolTip(Me.chkRemoveOldNotes, "If you press a note twice with a altered controller. Does it remove the first not" & _
                "e?")
        Me.chkRemoveOldNotes.UseVisualStyleBackColor = True
        '
        'chkDebug
        '
        Me.chkDebug.AutoSize = True
        Me.chkDebug.Enabled = False
        Me.chkDebug.Location = New System.Drawing.Point(6, 42)
        Me.chkDebug.Name = "chkDebug"
        Me.chkDebug.Size = New System.Drawing.Size(58, 17)
        Me.chkDebug.TabIndex = 17
        Me.chkDebug.Text = "Debug"
        Me.ToolTips.SetToolTip(Me.chkDebug, "Debug all commands going out.")
        Me.chkDebug.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Command:"
        '
        'lstDebug
        '
        Me.lstDebug.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDebug.ItemHeight = 14
        Me.lstDebug.Location = New System.Drawing.Point(9, 32)
        Me.lstDebug.Name = "lstDebug"
        Me.lstDebug.Size = New System.Drawing.Size(273, 256)
        Me.lstDebug.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Channel:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(176, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Data1:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(227, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Data2:"
        '
        'btnSS
        '
        Me.btnSS.Enabled = False
        Me.btnSS.Location = New System.Drawing.Point(265, 253)
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
        Me.lblStatus.Location = New System.Drawing.Point(0, 314)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(989, 19)
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
        Me.grpMisc.Controls.Add(Me.chkRemoveOldNotes)
        Me.grpMisc.Controls.Add(Me.chkDebug)
        Me.grpMisc.Enabled = False
        Me.grpMisc.Location = New System.Drawing.Point(346, 240)
        Me.grpMisc.Name = "grpMisc"
        Me.grpMisc.Size = New System.Drawing.Size(128, 66)
        Me.grpMisc.TabIndex = 23
        Me.grpMisc.TabStop = False
        Me.grpMisc.Text = "Misc"
        '
        'btnTest
        '
        Me.btnTest.Enabled = False
        Me.btnTest.Location = New System.Drawing.Point(265, 282)
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
        Me.btnInputEdit.Enabled = False
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
        Me.grpInput.Location = New System.Drawing.Point(477, 10)
        Me.grpInput.Name = "grpInput"
        Me.grpInput.Size = New System.Drawing.Size(209, 295)
        Me.grpInput.TabIndex = 30
        Me.grpInput.TabStop = False
        Me.grpInput.Text = "Input"
        '
        'btnInputRemove
        '
        Me.btnInputRemove.Enabled = False
        Me.btnInputRemove.Location = New System.Drawing.Point(142, 262)
        Me.btnInputRemove.Name = "btnInputRemove"
        Me.btnInputRemove.Size = New System.Drawing.Size(61, 20)
        Me.btnInputRemove.TabIndex = 30
        Me.btnInputRemove.Text = "Remove"
        Me.btnInputRemove.UseVisualStyleBackColor = True
        '
        'grpDebug
        '
        Me.grpDebug.Controls.Add(Me.lstDebug)
        Me.grpDebug.Controls.Add(Me.Label2)
        Me.grpDebug.Controls.Add(Me.Label1)
        Me.grpDebug.Controls.Add(Me.Label3)
        Me.grpDebug.Controls.Add(Me.Label4)
        Me.grpDebug.Location = New System.Drawing.Point(692, 11)
        Me.grpDebug.Name = "grpDebug"
        Me.grpDebug.Size = New System.Drawing.Size(291, 295)
        Me.grpDebug.TabIndex = 31
        Me.grpDebug.TabStop = False
        Me.grpDebug.Text = "Debug"
        '
        'chkMidiInputInstrument
        '
        Me.chkMidiInputInstrument.AutoSize = True
        Me.chkMidiInputInstrument.Checked = True
        Me.chkMidiInputInstrument.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMidiInputInstrument.Location = New System.Drawing.Point(9, 228)
        Me.chkMidiInputInstrument.Name = "chkMidiInputInstrument"
        Me.chkMidiInputInstrument.Size = New System.Drawing.Size(110, 17)
        Me.chkMidiInputInstrument.TabIndex = 32
        Me.chkMidiInputInstrument.Text = "Enable instrument"
        Me.ToolTips.SetToolTip(Me.chkMidiInputInstrument, "Allow the input device to change the instrument.")
        Me.chkMidiInputInstrument.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(9, 197)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 33
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 333)
        Me.Controls.Add(Me.grpDebug)
        Me.Controls.Add(Me.grpInput)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.grpMisc)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnSS)
        Me.Controls.Add(Me.grpMidiInput)
        Me.Controls.Add(Me.grpMidiOutput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedals"
        Me.grpMidiOutput.ResumeLayout(False)
        Me.grpMidiOutput.PerformLayout()
        Me.panMidiOutput.ResumeLayout(False)
        CType(Me.numMidiOutputInsturment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMidiOutputChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMidiInput.ResumeLayout(False)
        Me.grpMidiInput.PerformLayout()
        Me.panMidiInput.ResumeLayout(False)
        CType(Me.numMidiInputChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMisc.ResumeLayout(False)
        Me.grpMisc.PerformLayout()
        Me.grpInput.ResumeLayout(False)
        Me.grpDebug.ResumeLayout(False)
        Me.grpDebug.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpMidiOutput As System.Windows.Forms.GroupBox
    Friend WithEvents comOutput As System.Windows.Forms.ComboBox
    Friend WithEvents grpMidiInput As System.Windows.Forms.GroupBox
    Friend WithEvents comInput As System.Windows.Forms.ComboBox
    Friend WithEvents chkRemoveOldNotes As System.Windows.Forms.CheckBox
    Friend WithEvents chkDebug As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSS As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents tmrInput As System.Windows.Forms.Timer
    Friend WithEvents numMidiOutputChannel As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numMidiInputChannel As System.Windows.Forms.NumericUpDown
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
    Friend WithEvents btnMidiOutputRemove As System.Windows.Forms.Button
    Friend WithEvents btnMidiOutputAdd As System.Windows.Forms.Button
    Friend WithEvents btnMidiInputRemove As System.Windows.Forms.Button
    Friend WithEvents btnMidiInputAdd As System.Windows.Forms.Button
    Friend WithEvents grpInput As System.Windows.Forms.GroupBox
    Friend WithEvents btnInputRemove As System.Windows.Forms.Button
    Friend WithEvents panMidiInput As System.Windows.Forms.Panel
    Friend WithEvents panMidiOutput As System.Windows.Forms.Panel
    Friend WithEvents grpDebug As System.Windows.Forms.GroupBox
    Friend WithEvents lstDebug As System.Windows.Forms.ListBox
    Friend WithEvents btnMidiInputSet As System.Windows.Forms.Button
    Friend WithEvents btnMidiOutputSet As System.Windows.Forms.Button
    Friend WithEvents numMidiOutputInsturment As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkMidiInputInstrument As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
