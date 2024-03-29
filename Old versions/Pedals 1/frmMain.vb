﻿Public Class frmMain
	'Made by Raymond Ellis



	Private Playing As Boolean = False

	Public ContinueLoading As Boolean = True


#Region "Loading and closing"

	Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Status("Closing... Done!")
	End Sub

	Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ContinueLoading = False

        If Loaded Then Save()
		Status("Closing...")
		tmr.Enabled = False


		If OutDevice IsNot Nothing Then
			Status("Closing midi output device...")
			OutDevice.Close()
			OutDevice.Dispose()
			Status("Closing midi output device... Done!")
		End If
		If InDevice IsNot Nothing Then
			Status("Closing midi input device...")
			InDevice.Close()
			InDevice.Dispose()
			Status("Closing midi input device... Done")
		End If

		DistroyInput()

	End Sub

	Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Pedals v" & Application.ProductVersion.ToString

		'Fill boxs.
		GetDevices()

		comLeft.Items.AddRange([Enum].GetNames(GetType(Midi.ControllerType)))
		comLeft.SelectedItem = Midi.ControllerType.SoftPedal.ToString
		comMiddle.Items.AddRange([Enum].GetNames(GetType(Midi.ControllerType)))
		comMiddle.SelectedItem = Midi.ControllerType.SustenutoPedal.ToString
		comRight.Items.AddRange([Enum].GetNames(GetType(Midi.ControllerType)))
		comRight.SelectedItem = Midi.ControllerType.HoldPedal1.ToString
	End Sub

	Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
		'Init devices.

		If ContinueLoading Then

			CreateInput()

			If EnableJoysticks Then
				SetControls(True, True, True, True, True, True)

                'If System.Diagnostics.Debugger.IsAttached Then
                '	LeftInput = New InputData(0, 6)
                '	MiddleInput = New InputData(0, 1)
                '	RightInput = New InputData(0, 5)

                'End If
                Open()
			Else
				SetControls(True, True, True, False, True, True)
			End If
		End If

			Loaded = True
			CheckNoteDisable()
			Status("Loading... Done!")

	End Sub

	Public Sub SetControls(ByVal Value As Boolean, Optional ByVal StartB As Boolean = False, Optional ByVal Devices As Boolean = False, Optional ByVal Pedals As Boolean = False, Optional ByVal Misc As Boolean = False, Optional ByVal Debug As Boolean = False)
		If StartB Then btnSS.Enabled = Value
		If Devices Then
			grpInput.Enabled = Value
			grpOutput.Enabled = Value
		End If
		If Pedals Then
			grpLeft.Enabled = Value
			grpMiddle.Enabled = Value
			grpRight.Enabled = Value
		End If
		If Debug Then chkDebug.Enabled = Value
		If Misc Then grpMisc.Enabled = Value
	End Sub
#End Region

#Region "Open/Save"

    Public Sub Open()
        If Not IO.File.Exists("Pedals.cfg") Then Return

        Dim sr As New IO.StreamReader("Pedals.cfg")
        sr.ReadLine()

        Do
            Dim CurrentLine As String = sr.ReadLine
            Dim Equals As Integer = CurrentLine.IndexOf("=")
            Dim Name As String = CurrentLine.Substring(0, Equals)
            Dim Data As String = CurrentLine.Substring(Equals + 1)

            Select Case LCase(Name)
                'Input
                Case "input device"
                    comInput.SelectedItem = Data
                Case "input channel"
                    numInputChannel.Value = Data

                    'Output
                Case "output device"
                    comOutput.SelectedItem = Data
                Case "output channel"
                    numInputChannel.Value = Data
                Case "output notes"
                    chkNoteOut.Checked = Data

                    'Misc
                Case "max volume"
                    chkMaxVolume.Checked = Data
                Case "remove old notes"
                    chkOldNote.Checked = Data

                    'Left pedal
                Case "left midi"
                    radLeft.Checked = Data
                Case "left midi channel"
                    comLeft.SelectedItem = Data
                Case "left joystick"
                    LeftInput = New InputData(Data)

                    'Middle pedal
                Case "middle midi"
                    radMiddle.Checked = Data
                Case "middle midi channel"
                    comMiddle.SelectedItem = Data
                Case "middle joystick"
                    MiddleInput = New InputData(Data)

                    'Right pedal
                Case "right midi"
                    radRight.Checked = Data
                Case "right midi channel"
                    comRight.SelectedItem = Data
                Case "right joystick"
                    RightInput = New InputData(Data)

            End Select
        Loop Until sr.EndOfStream
        sr.Close()

    End Sub

    Public Sub Save()
        Status("Saving...")
        Dim tmp As String = "Pedals config file."

        'Input
        tmp &= vbNewLine & "Input device=" & comInput.SelectedItem
        tmp &= vbNewLine & "Input channel=" & numInputChannel.Value

        'Output
        tmp &= vbNewLine & "Output device=" & comOutput.SelectedItem
        tmp &= vbNewLine & "Output channel=" & numInputChannel.Value
        tmp &= vbNewLine & "Output notes=" & chkNoteOut.Checked

        'Misc
        tmp &= vbNewLine & "Max volume=" & chkMaxVolume.Checked
        tmp &= vbNewLine & "Remove old notes=" & chkOldNote.Checked


        'Left pedal.
        tmp &= vbNewLine & "Left MIDI=" & radLeft.Checked
        tmp &= vbNewLine & "Left MIDI Channel=" & comLeft.SelectedItem
        If LeftInput IsNot Nothing Then tmp &= vbNewLine & "Left joystick=" & LeftInput.ToString
        'Middle pedal.
        tmp &= vbNewLine & "Middle MIDI=" & radMiddle.Checked
        tmp &= vbNewLine & "Middle MIDI Channel=" & comMiddle.SelectedItem
        If MiddleInput IsNot Nothing Then tmp &= vbNewLine & "Middle joystick=" & MiddleInput.ToString
        'Right pedal.
        tmp &= vbNewLine & "Right MIDI=" & radRight.Checked
        tmp &= vbNewLine & "Right MIDI Channel=" & comRight.SelectedItem
        If RightInput IsNot Nothing Then tmp &= vbNewLine & "Right joystick=" & RightInput.ToString

        Dim sw As New IO.StreamWriter("Pedals.cfg")
        sw.Write(tmp)
        sw.Close()

        Status("Saved!")
    End Sub

#End Region

#Region "Get Input/Output Devices"
	Private Sub GetDevices()
		If OutputDevice.DeviceCount > 0 Then
			For i As Integer = 0 To OutputDevice.DeviceCount - 1
				comOutput.Items.Add(OutputDevice.GetDeviceCapabilities(i).name)
			Next
			comOutput.SelectedIndex = OutDeviceID
		Else
			Status("No output midi devices!", True)
			ContinueLoading = False
			Close()
		End If


		If InputDevice.DeviceCount > 0 Then
			For i As Integer = 0 To InputDevice.DeviceCount - 1
				comInput.Items.Add(InputDevice.GetDeviceCapabilities(i).name)
			Next
			comInput.SelectedIndex = InDeviceID
		Else
			Status("No input midi devices!", True)
			ContinueLoading = False
			Close()
		End If

	End Sub

	Private Sub comInput_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comInput.SelectedIndexChanged
		InDeviceID = comInput.SelectedIndex
		CheckNoteDisable()
	End Sub
	Private Sub comOutput_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comOutput.SelectedIndexChanged
		OutDeviceID = comOutput.SelectedIndex
		CheckNoteDisable()
	End Sub


	Private Sub numInputChannel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numInputChannel.ValueChanged
		MidiInput = sender.value
		CheckNoteDisable()
	End Sub
	Private Sub numOutputChannel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numOutputChannel.ValueChanged
		MidiOutput = sender.value
		CheckNoteDisable()
	End Sub

	Private Sub CheckNoteDisable() 'Used to disable alter notes and stuff.
		If Not grpOutput.Enabled Or Not Loaded Then Return

		'Is the input and output the same?
		If comInput.SelectedItem = comOutput.SelectedItem Then
			If numInputChannel.Value = numOutputChannel.Value Then
				chkNoteOut.Checked = False

			End If
		End If
	End Sub
#End Region


#Region "Debug"
	Delegate Sub AddMessageToDebugCallback(ByVal [Message] As ChannelMessage)
	Public Sub AddMessageToDebug(ByVal [Message] As ChannelMessage)
		If Me.lstDebug.InvokeRequired Then
			Dim d As New AddMessageToDebugCallback(AddressOf AddMessageToDebug)
			Me.Invoke(d, New Object() {[Message]})
		Else
			Me.lstDebug.Items.Add(Message.MidiChannel.ToString & vbTab & Message.Command.ToString & vbTab & vbTab & Message.Data1.ToString & vbTab & Message.Data2.ToString)
			Me.lstDebug.SelectedIndex = Me.lstDebug.Items.Count - 1
		End If
	End Sub

	Private Sub chkDebug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDebug.CheckedChanged
		Debug = chkDebug.Checked
		panDebug.Enabled = Debug

		If Debug = False Then
			lstDebug.Items.Clear()
		End If
	End Sub
#End Region

#Region "Pedals"

#Region "Left"
	'Private LeftP As Boolean = False
	Private LeftChanged As Boolean = True
	Private LeftInput As InputData
	Private LeftController As Integer
	Private LeftIsControllerSwitch As Boolean = True
	Private LeftDown As Color = Color.White
	Private Sub DoLeft()
		Dim Pos As Integer = LeftInput.GetAsisPosition

		If Pos = LeftInput.OldPosition Then Return

		'Press and release virtual pedal.
		If Pos >= LeftInput.SwitchOn Then
			If Not LeftP Then
				LeftP = True
				lblLeft.BackColor = LeftDown
				LeftChanged = True
			Else
				LeftChanged = False
			End If
		Else
			If LeftP Then
				LeftP = False
				lblLeft.BackColor = Color.Silver
				LeftChanged = True
			Else
				LeftChanged = False
			End If
		End If


		If radLeft.Checked Then

			Dim m As New ChannelMessageBuilder
			m.MidiChannel = MidiOutput
			m.Command = ChannelCommand.Controller
			m.Data1 = LeftController
			If LeftIsControllerSwitch And LeftChanged Then
				If LeftP Then
					m.Data2 = 127
				Else
					m.Data2 = 0
				End If
				Send(m)
			ElseIf Not LeftIsControllerSwitch Then
				m.Data2 = Pos
				Send(m)
			End If



		End If





		LeftInput.OldPosition = Pos
	End Sub

#End Region

#Region "Middle"

	Private MiddleChanged As Boolean
	Private MiddleInput As InputData
	Private MiddleController As Integer
	Private MiddleIsControllerSwitch As Boolean = True
	Private MiddleDown As Color = Color.White
	Private Sub DoMiddle()
		Dim Pos As Integer = MiddleInput.GetAsisPosition

		If Pos = MiddleInput.OldPosition Then Return

		If Pos >= MiddleInput.SwitchOn Then
			If Not MiddleP Then
				MiddleP = True
				lblMiddle.BackColor = MiddleDown
				MiddleChanged = True
			Else
				MiddleChanged = False
			End If
		Else
			If MiddleP Then
				MiddleP = False
				lblMiddle.BackColor = Color.Silver
				MiddleChanged = True
			Else
				MiddleChanged = False
			End If
		End If

		If radMiddle.Checked Then

			Dim m As New ChannelMessageBuilder
			m.MidiChannel = MidiOutput
			m.Command = ChannelCommand.Controller
			m.Data1 = MiddleController
			If MiddleIsControllerSwitch And MiddleChanged Then
				If MiddleP Then
					m.Data2 = 127
				Else
					m.Data2 = 0
				End If
				Send(m)
			ElseIf Not MiddleIsControllerSwitch Then
				m.Data2 = Pos
				Send(m)
			End If




		Else

			If Pos <= MiddleInput.SwitchOn Then
				If MiddleChanged Then
					'Check for down keys and set them to sostento.
					Parallel.For(0, Note.Length - 1, Sub(n As Integer)
														 If Note(n) = Notes.Pressed Or Note(n) = Notes.SustainPressed Then
															 Note(n) = Notes.Sostenuto
															 SostenutoList.Add(n)
														 End If
													 End Sub)

				End If

			Else 'Release pedal.
				If MiddleChanged Then

					Dim tmp As New ChannelMessageBuilder
					tmp.Command = Midi.ChannelCommand.NoteOff
					tmp.MidiChannel = 0
					tmp.Data2 = 0
					For Each n As Integer In SostenutoList
						Note(n) = Notes.Released
						tmp.Data1 = n
						Send(tmp)
					Next
					SostenutoList.Clear()

				End If
			End If


		End If



		MiddleInput.OldPosition = Pos
	End Sub

#End Region

#Region "Right"
	'Private RightP As Boolean = False
	Private RightChanged As Boolean = True
	Private RightInput As InputData
	Private RightController As Integer
	Private RightIsControllerSwitch As Boolean = True
	Private RightDown As Color = Color.White
	Private Sub DoRight()
		Dim Pos As Integer = RightInput.GetAsisPosition

		If Pos = RightInput.OldPosition Then Return

		If Pos >= RightInput.SwitchOn Then
			If Not RightP Then
				RightP = True
				lblRight.BackColor = RightDown
				RightChanged = True
			Else
				RightChanged = False
			End If
		Else
			If RightP Then
				RightP = False
				lblRight.BackColor = Color.Silver
				RightChanged = True
			Else
				RightChanged = False
			End If
		End If

		If radRight.Checked Then

			Dim m As New ChannelMessageBuilder
			m.MidiChannel = MidiOutput
			m.Command = ChannelCommand.Controller
			m.Data1 = RightController
			If RightIsControllerSwitch And RightChanged Then
				If RightP Then
					m.Data2 = 127
				Else
					m.Data2 = 0
				End If
				Send(m)
			ElseIf Not RightIsControllerSwitch Then
				m.Data2 = Pos
				Send(m)
			End If





		Else

			If Pos >= RightInput.SwitchOn Then
				If RightChanged Then
					'Check for down keys and set them to sustain.
					Parallel.For(0, Note.Length - 1, Sub(n)
														 If Note(n) = Notes.Pressed Then
															 Note(n) = Notes.SustainPressed
															 SustainList.Add(n)
														 End If
													 End Sub)

					lblRight.BackColor = RightDown
				End If

			Else 'Release pedal.
				If RightChanged Then

					Dim tmp As New ChannelMessageBuilder
					tmp.Command = Midi.ChannelCommand.NoteOff
					tmp.MidiChannel = MidiOutput
					tmp.Data2 = 0
					For Each n As Integer In SustainList
						If Note(n) = Notes.SustainReleased Then
							Note(n) = Notes.Released
							tmp.Data1 = n
							Send(tmp)
						End If
					Next
					SustainList.Clear()


					lblRight.BackColor = Color.Silver
				End If
			End If


		End If



		RightInput.OldPosition = Pos
	End Sub

#End Region

#Region "Controls"
	Private Sub radLeft_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLeft.CheckedChanged
        comLeft.Enabled = sender.checked
        If sender.checked = False Then
            radLeft2.Checked = True
        End If
	End Sub
	Private Sub radMiddle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radMiddle.CheckedChanged
        comMiddle.Enabled = sender.checked
        If sender.checked = False Then
            radMiddle2.Checked = True
        End If
		If sender.checked And MiddleP Then
			Dim tmp As New ChannelMessageBuilder
			tmp.Command = Midi.ChannelCommand.NoteOff
			tmp.MidiChannel = 0
			tmp.Data2 = 0
			For Each n As Integer In SostenutoList
				Note(n) = Notes.Released
				tmp.Data1 = n
				Send(tmp)
			Next
			SostenutoList.Clear()
		End If
	End Sub
	Private Sub radRight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radRight.CheckedChanged
        comRight.Enabled = sender.checked
        If sender.checked = False Then
            radRight2.Checked = True
        End If
		If sender.checked And RightP Then
			Dim tmp As New ChannelMessageBuilder
			tmp.Command = Midi.ChannelCommand.NoteOff
			tmp.MidiChannel = MidiOutput
			tmp.Data2 = 0
			For Each n As Integer In SustainList
				If Note(n) = Notes.SustainReleased Then
					Note(n) = Notes.Released
					tmp.Data1 = n
					Send(tmp)
				End If
			Next
			SustainList.Clear()
		End If
	End Sub

	Private Sub comLeft_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comLeft.SelectedIndexChanged
		LeftController = [Enum].Parse(GetType(Midi.ControllerType), sender.SelectedItem.ToString)
		LeftIsControllerSwitch = IsSwitch(LeftController)
	End Sub
	Private Sub comMiddle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comMiddle.SelectedIndexChanged
		MiddleController = [Enum].Parse(GetType(Midi.ControllerType), sender.SelectedItem.ToString)
		MiddleIsControllerSwitch = IsSwitch(MiddleController)
	End Sub
	Private Sub comRight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comRight.SelectedIndexChanged
		RightController = [Enum].Parse(GetType(Midi.ControllerType), sender.SelectedItem.ToString)
		RightIsControllerSwitch = IsSwitch(RightController)
	End Sub


	Public Function IsSwitch(ByVal Controller As Integer) As Boolean
		Select Case Controller
			Case 64	'Hold1
				Return True

			Case 65	'Portmento
				Return True

			Case 66	'Sostenuto
				Return True

			Case 67	'Sift
				Return True

			Case 68	'Legato
				Return True

			Case 69	'Hold 2
				Return True

			Case 122 '[Channel Mode Message] Local Control On/Off 
				Return True

		End Select

		Return False
	End Function

	Private Sub btnLeftInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftInput.Click
		If frmInput.ShowDialog(LeftInput) = System.Windows.Forms.DialogResult.OK Then
			LeftInput = frmInput.CurrentJoystick
		End If
	End Sub
	Private Sub btnMiddleInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMiddleInput.Click
		If frmInput.ShowDialog(MiddleInput) = System.Windows.Forms.DialogResult.OK Then
			MiddleInput = frmInput.CurrentJoystick
		End If
	End Sub
	Private Sub btnRightInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightInput.Click
		If frmInput.ShowDialog(RightInput) = System.Windows.Forms.DialogResult.OK Then
			RightInput = frmInput.CurrentJoystick
		End If
	End Sub

#End Region



#End Region


#Region "Input"


	Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick

		If LeftInput IsNot Nothing Then
			DoLeft()
		End If
		If MiddleInput IsNot Nothing Then
			DoMiddle()
		End If
		If RightInput IsNot Nothing Then
			DoRight()
		End If

	End Sub
#End Region

#Region "StartStop"
	Private Sub btnSS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSS.Click
		StartStop()
		If Playing Then
			btnSS.Text = "Stop"
		Else
			btnSS.Text = "Start"
		End If
	End Sub

	Public Sub StartStop()
		If Not Playing Then
			Playing = True
			tmr.Enabled = EnableJoysticks 'Will not enable the input timmer if there is no joysticks.
			SetControls(False, , True)

			InDevice = New InputDevice(InDeviceID)
			InDevice.StartRecording()
			OutDevice = New OutputDevice(OutDeviceID)

			btnTest.Enabled = True

			Status("Recording")

		Else
			btnTest.Enabled = False

			InDevice.StopRecording()
			InDevice.Close()
			InDevice.Dispose()

			OutDevice.Close()
			OutDevice.Dispose()

			ResetNotes()
			SustainList.Clear()
			SostenutoList.Clear()

			Playing = False
			tmr.Enabled = False
			SetControls(True, , True)

			Status("Stoped recording")
		End If
	End Sub
#End Region





#Region "Misc"
	Private Sub chkMaxVolume_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMaxVolume.CheckedChanged
		SetVolumeMax = sender.checked
	End Sub

	Private Sub chkOldNote_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOldNote.CheckedChanged
		RemoveOldNotes = sender.checked
	End Sub

	Private Sub chkNoteOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoteOut.CheckedChanged
		If Not Loaded Then Return 'We don't need to change anything here until we are done loading.

		NoteOut = chkNoteOut.Checked

		grpMisc.Enabled = chkNoteOut.Checked

		radLeft2.Enabled = chkNoteOut.Checked
		radMiddle2.Enabled = chkNoteOut.Checked
		radRight2.Enabled = chkNoteOut.Checked

		If NoteOut = False Then
			radLeft.Checked = True
			radMiddle.Checked = True
			radRight.Checked = True
		End If

	End Sub


#End Region

#Region "Test"
	Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
		btnTest.Enabled = False
		testL = 0
		tmrTest.Enabled = True
	End Sub

	Dim testL As Integer
	Private Sub tmrTest_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTest.Tick
		testL += 1
		Dim m As New ChannelMessageBuilder
		m.MidiChannel = MidiOutput
		m.Command = ChannelCommand.NoteOn
		m.Data1 = 72 + testL
		m.Data2 = 127
		Send(m)
		Threading.Thread.Sleep(20)
		m.Command = ChannelCommand.NoteOff
		m.Data2 = 0
		Send(m)
		Threading.Thread.Sleep(100)
		If testL > 11 Then
			tmrTest.Enabled = False
			btnTest.Enabled = True
		End If
	End Sub
#End Region

End Class
