Public Class frmMain
	'Made by Raymond Ellis



	Private Playing As Boolean = False

	Private ContinueLoading As Boolean = True

#Region "Loading and closing"

	Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		tmr.Enabled = False
		Status("Closeing...")

		If OutDevice IsNot Nothing Then
			OutDevice.Close()
			OutDevice.Dispose()
		End If
		If InDevice IsNot Nothing Then
			InDevice.Close()
			InDevice.Dispose()
		End If
		DistroyInput()
	End Sub
	Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


			SetControls(True, True, True, True, True, True)

			RightID = 0
			RightAxis = 5
			MiddleID = 0
			MiddleAxis = 1
			LeftID = 0
			LeftAxis = 6
		End If


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

#Region "Get Input/Output Devices"
	Private Sub GetDevices()
		If OutputDevice.DeviceCount > 0 Then
			For i As Integer = 0 To OutputDevice.DeviceCount - 1
				comOutput.Items.Add(OutputDevice.GetDeviceCapabilities(i).name)
			Next
			comOutput.SelectedIndex = OutDeviceID
		Else
			Status("No output devices!", True)
			ContinueLoading = False
		End If


		If InputDevice.DeviceCount > 0 Then
			For i As Integer = 0 To InputDevice.DeviceCount - 1
				comInput.Items.Add(InputDevice.GetDeviceCapabilities(i).name)
			Next
			comInput.SelectedIndex = InDeviceID
		Else
			Status("No input devices!", True)
			ContinueLoading = False
		End If

	End Sub

	Private Sub comInput_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comInput.SelectedIndexChanged
		InDeviceID = comInput.SelectedIndex
	End Sub
	Private Sub comOutput_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comOutput.SelectedIndexChanged
		OutDeviceID = comOutput.SelectedIndex
	End Sub


	Private Sub numInputChannel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numInputChannel.ValueChanged
		MidiInput = sender.value
	End Sub
	Private Sub numOutputChannel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numOutputChannel.ValueChanged
		MidiOutput = sender.value
	End Sub
#End Region


#Region "Debug"
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
	Private LeftID, LeftAxis, LeftConroller, LeftOldPos As Integer
	Private LeftDown As Color = Color.White
	Private Sub DoLeft()
		Dim Pos As Integer = GetAxis(leftID, leftAxis)

		If Pos = leftOldPos Then Return

		If radLeft.Checked Then

			Dim m As New ChannelMessageBuilder
			m.MidiChannel = MidiOutput
			m.Command = ChannelCommand.Controller
			m.Data1 = leftConroller
			m.Data2 = (-Pos) + 127
			Send(m)

			If Pos < 64 Then
				If Not leftP Then
					leftP = True
					lblLeft.BackColor = leftDown
				End If
			Else
				If leftP Then
					leftP = False
					lblLeft.BackColor = Color.Silver
				End If
			End If

		Else

			If Pos = 0 Then
				If Not leftP Then
					leftP = True

					lblLeft.BackColor = leftDown
				End If

			Else 'Release pedal.
				If leftP Then
					leftP = False

					lblLeft.BackColor = Color.Silver
				End If
			End If


		End If



		leftOldPos = Pos
	End Sub

#End Region

#Region "Middle"

	Private MiddleID, MiddleAxis, MiddleConroller, MiddleOldPos As Integer
	Private MiddleDown As Color = Color.White
	Private Sub DoMiddle()
		Dim Pos As Integer = GetAxis(MiddleID, MiddleAxis)

		If Pos = MiddleOldPos Then Return

		If radMiddle.Checked Then

			Dim m As New ChannelMessageBuilder
			m.MidiChannel = MidiOutput
			m.Command = ChannelCommand.Controller
			m.Data1 = MiddleConroller
			m.Data2 = (-Pos) + 127
			Send(m)

			If Pos < 64 Then
				If Not MiddleP Then
					MiddleP = True
					lblMiddle.BackColor = MiddleDown
				End If
			Else
				If MiddleP Then
					MiddleP = False
					lblMiddle.BackColor = Color.Silver
				End If
			End If

		Else

			If Pos = 0 Then
				If Not MiddleP Then
					MiddleP = True
					'Check for down keys and set them to sostento.
					Parallel.For(0, Note.Length - 1, Sub(n As Integer)
														 If Note(n) = Notes.Pressed Or Note(n) = Notes.SustainPressed Then
															 Note(n) = Notes.Sostenuto
															 SostenutoList.Add(n)
														 End If
													 End Sub)
					
					lblMiddle.BackColor = MiddleDown
				End If

			Else 'Release pedal.
				If MiddleP Then
					MiddleP = False

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


					lblMiddle.BackColor = Color.Silver
				End If
			End If


		End If



		MiddleOldPos = Pos
	End Sub

#End Region

#Region "Right"
	'Private RightP As Boolean = False
	Private RightID, RightAxis, RightConroller, RightOldPos As Integer
	Private RightDown As Color = Color.White
	Private Sub DoRight()
		Dim Pos As Integer = GetAxis(RightID, RightAxis)

		If Pos = RightOldPos Then Return

		If radRight.Checked Then

			Dim m As New ChannelMessageBuilder
			m.MidiChannel = MidiOutput
			m.Command = ChannelCommand.Controller
			m.Data1 = RightConroller
			m.Data2 = (-Pos) + 127
			Send(m)

			If Pos < 64 Then
				If Not RightP Then
					RightP = True
					lblRight.BackColor = RightDown
				End If
			Else
				If RightP Then
					RightP = False
					lblRight.BackColor = Color.Silver
				End If
			End If

		Else

			If Pos = 0 Then
				If Not RightP Then
					RightP = True
					'Check for down keys and set them to sustain.
					Parallel.For(0, Note.Length - 1, Sub(n)
														 Note(n) = Notes.SustainPressed
														 SustainList.Add(n)
													 End Sub)
					lblRight.BackColor = RightDown
				End If

			Else 'Release pedal.
				If RightP Then
					RightP = False

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



		RightOldPos = Pos
	End Sub

#End Region

#Region "Controls"
	Private Sub radLeft_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLeft.CheckedChanged
		comLeft.Enabled = sender.checked
	End Sub
	Private Sub radMiddle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radMiddle.CheckedChanged
		comMiddle.Enabled = sender.checked
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
		LeftConroller = [Enum].Parse(GetType(Midi.ControllerType), sender.SelectedItem.ToString)
	End Sub
	Private Sub comRight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comRight.SelectedIndexChanged
		RightConroller = [Enum].Parse(GetType(Midi.ControllerType), sender.SelectedItem.ToString)
	End Sub
	Private Sub comMiddle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comMiddle.SelectedIndexChanged
		MiddleConroller = [Enum].Parse(GetType(Midi.ControllerType), sender.SelectedItem.ToString)
	End Sub

	Private Sub btnLeftInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftInput.Click
		If frmInput.ShowDialog = System.Windows.Forms.DialogResult.OK Then
			LeftID = frmInput.CurrentJoystick
			LeftAxis = frmInput.CurrentAxis
		End If
	End Sub
	Private Sub btnMiddleInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMiddleInput.Click
		If frmInput.ShowDialog = System.Windows.Forms.DialogResult.OK Then
			MiddleID = frmInput.CurrentJoystick
			MiddleAxis = frmInput.CurrentAxis
		End If
	End Sub
	Private Sub btnRightInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightInput.Click
		If frmInput.ShowDialog = System.Windows.Forms.DialogResult.OK Then
			RightID = frmInput.CurrentJoystick
			RightAxis = frmInput.CurrentAxis
		End If
	End Sub

#End Region



#End Region


#Region "Input"


	Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick

		If LeftID > -1 Then
			DoLeft()
		End If
		If MiddleID > -1 Then
			DoMiddle()
		End If
		If RightID > -1 Then
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
			tmr.Enabled = True
			SetControls(False, , True)

			InDevice = New InputDevice(InDeviceID)
			InDevice.StartRecording()
			OutDevice = New OutputDevice(OutDeviceID)

			Status("Recording")

		Else
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
#End Region
End Class
