Module Devices
	Public WithEvents OutDevice As OutputDevice
	Public OutDeviceID As Integer = 0
	Public InDeviceID As Integer = 0
	Public WithEvents InDevice As InputDevice

	Public MidiInput As Integer
	Public MidiOutput As Integer

	Public SetVolumeMax As Boolean = True
	Public RemoveOldNotes As Boolean = True


	''' <summary>
	''' Will build and send a message.
	''' </summary>
	''' <param name="message">message to send</param>
	Public Sub Send(ByVal message As Midi.ChannelMessageBuilder)
		message.Build()
		Send(message.Result)
	End Sub
	Public Sub Send(ByVal message As Midi.ChannelMessage)
		OutDevice.Send(message)

		If Debug Then
			frmMain.lstDebug.Items.Add(message.MidiChannel.ToString & vbTab & message.Command.ToString & vbTab & vbTab & message.Data1.ToString & vbTab & message.Data2.ToString)
			frmMain.lstDebug.SelectedIndex = frmMain.lstDebug.Items.Count - 1
		End If
	End Sub

	Private Sub InDevice_ChannelMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.ChannelMessageEventArgs) Handles InDevice.ChannelMessageReceived


		'If the message is comeing from the selected midi channel.
		If e.Message.MidiChannel = MidiInput Then

			Dim Message As New Midi.ChannelMessageBuilder(e.Message)

			'Is it a note on or off?
			If Message.Command = ChannelCommand.NoteOn Or Message.Command = ChannelCommand.NoteOff Then

				'Is the note on? (volume more then 0)
				If Message.Data2 > 0 Then

					If SetVolumeMax Then
						Message.Data2 = 127
					End If

					'If alter note for left pedal is checked then  if the pedal is down then lower the volume.
					If Not frmMain.radLeft.Checked Then
						If LeftP Then Message.Data2 = 20
					End If

					'Pedles
					If Note(Message.Data1) = Notes.Sostenuto Then
						If Not MiddleP Then
							Note(Message.Data1) = Notes.Pressed

						ElseIf RemoveOldNotes Then
							ReleaseNote(Message.Data1)
							Note(Message.Data1) = Notes.Sostenuto
						End If

					ElseIf RightP Then
						If frmMain.radRight.Checked Then
							Note(Message.Data1) = Notes.Pressed
						Else
							If Note(Message.Data1) = Notes.SustainReleased And RemoveOldNotes Then
								ReleaseNote(Message.Data1)
							Else
								SustainList.Add(Message.Data1)
							End If
							Note(Message.Data1) = Notes.SustainPressed
						End If
					Else
						Note(Message.Data1) = Notes.Pressed
					End If

				Else
					Select Case Note(Message.Data1)
						Case Notes.Sostenuto
							If MiddleP Then
								Return
							Else
								Note(Message.Data1) = Notes.Released
							End If

						Case Notes.SustainPressed
							If RightP Then
								Note(Message.Data1) = Notes.SustainReleased
								Return
							Else
								Note(Message.Data1) = Notes.Released
							End If
						Case Notes.SustainReleased
							If RightP Then
								Return
							Else
								Note(Message.Data1) = Notes.Released
							End If

						Case Notes.Pressed
							Note(Message.Data1) = Notes.Released
							Message.Command = ChannelCommand.NoteOff

					End Select
				End If


				Send(Message)
			End If

		Else
			Send(e.Message)
		End If

	End Sub

	Private Sub InDevice_SysCommonMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.SysCommonMessageEventArgs) Handles InDevice.SysCommonMessageReceived
		OutDevice.Send(e.Message)
	End Sub
	Private Sub InDevice_SysExMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.SysExMessageEventArgs) Handles InDevice.SysExMessageReceived
		OutDevice.Send(e.Message)
	End Sub
	Private Sub InDevice_SysRealtimeMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.SysRealtimeMessageEventArgs) Handles InDevice.SysRealtimeMessageReceived
		OutDevice.Send(e.Message)
	End Sub
End Module
