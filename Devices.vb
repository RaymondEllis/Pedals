Module Devices
    Public Recording As Boolean = False

    Public InDevices As New List(Of MidiInput)
    Public OutDevices As New List(Of MidiOutput)
    Public CurrentMidiInput As MidiInput
    Public CurrentMidiOutput As MidiOutput

    Public Sub AddInputDevice(ByVal DeviceID As Integer, ByVal Channel As Integer)
        For Each dev As MidiInput In InDevices
            If Not dev.Index = CurrentMidiInput.Index And dev.DeviceID = DeviceID Then
                Status("Can not have more then one of the same device.")
                Return
            End If
        Next

        Dim tmp As New MidiInput(DeviceID, Channel)
        tmp.Index = InDevices.Count

        'Add it to the lists.
        InDevices.Add(tmp)
        frmMain.lstMidiInput.Items.Add(tmp.ToString)
        frmMain.lstMidiInput.SelectedIndex = tmp.Index

        frmMain.btnMidiInputRemove.Enabled = True
        frmMain.btnMidiInputSet.Enabled = True
    End Sub
    Public Sub UpdateInputDevice(ByVal DeviceID As Integer)
        If CurrentMidiInput Is Nothing Then Return
        For Each dev As MidiInput In InDevices
            If Not dev.Index = CurrentMidiInput.Index And dev.DeviceID = DeviceID Then
                Status("Can not have more then one of the same device.")
                Return
            End If
        Next

        CurrentMidiInput.DeviceID = DeviceID

        frmMain.lstMidiInput.Items(CurrentMidiInput.Index) = CurrentMidiInput.ToString()
    End Sub
    Public Sub RemoveInputDevice(ByVal Index As Integer)

        frmMain.lstMidiInput.Items.RemoveAt(Index) 'Remove the device from the list on the form.
        InDevices(Index).Dispose() 'Dispose the device.
        InDevices.RemoveAt(Index) 'Remove the device from the main list.

        'Do we have any devices left?
        If InDevices.Count = 0 Then
            CurrentMidiInput = Nothing 'There is no current device.
            frmMain.btnMidiInputRemove.Enabled = False 'Don't allow anybuddy to press the button.
        Else
            'Update the indexes of the other devices.
            For n As Integer = Index To InDevices.Count - 1
                InDevices(n).Index = n
            Next

            'Set the curent device to the last one in the list.
            'CurrentMidiInput = InDevices(InDevices.Count - 1)
            frmMain.lstMidiInput.SelectedIndex = Index - 1
        End If

    End Sub

    Public Sub AddOutputDevice(ByVal DeviceID As Integer, ByVal Channel As Integer)

        Dim tmp As New MidiOutput(DeviceID, Channel)
        tmp.Index = OutDevices.Count

        'Add it to the lists.
        OutDevices.Add(tmp)
        frmMain.lstMidiOutput.Items.Add(tmp.ToString)
        frmMain.lstMidiOutput.SelectedIndex = tmp.Index

        frmMain.btnMidiOutputRemove.Enabled = True
    End Sub
    Public Sub RemoveOutputDevice(ByVal Index As Integer)

        frmMain.lstMidiOutput.Items.RemoveAt(Index) 'Remove the device from the list on the form.
        OutDevices(Index).Dispose() 'Dispose the device.
        OutDevices.RemoveAt(Index) 'Remove the device from the main list.

        'Do we have any devices left?
        If OutDevices.Count = 0 Then
            CurrentMidiOutput = Nothing 'There is no current device.
            frmMain.btnMidiOutputRemove.Enabled = False 'Don't allow anybuddy to press the button.
        Else
            'Update the indexes of the other devices.
            For n As Integer = Index To OutDevices.Count - 1
                OutDevices(n).Index = n
            Next

            'Set the curent device to the last one in the list.
            'CurrentMidiOutput = OutDevices(OutDevices.Count - 1)
            frmMain.lstMidiOutput.SelectedIndex = Index - 1
        End If

    End Sub


    Public Sub UpdateOutputDevice(ByVal DeviceID As Integer)

        CurrentMidiOutput.DeviceID = DeviceID

        frmMain.lstMidiOutput.Items(CurrentMidiOutput.Index) = CurrentMidiOutput.ToString()
    End Sub


    Public Sub DisposeDevices()
        For Each dev As MidiInput In InDevices
            dev.Dispose()
        Next
        For Each dev As MidiOutput In OutDevices
            dev.Dispose()
        Next
    End Sub


#Region "Send"
    Public Sub Send(ByVal message As Midi.ChannelMessageBuilder)

        For Each dev As MidiOutput In OutDevices
            message.MidiChannel = dev.Channel
            message.Build()
            dev.Send(message.Result)
            If Debug Then
                frmMain.AddMessageToDebug(message.Result)
            End If
        Next

        
    End Sub
    Public Sub Send(ByVal message As Midi.ChannelMessage)
        'If Not Recording Then Return 'If we are not recording then leave.

        For Each dev As MidiOutput In OutDevices
            dev.Send(message)
        Next

        If Debug Then
            frmMain.AddMessageToDebug(message)
        End If
    End Sub
    Public Sub Send(ByVal message As Midi.SysCommonMessage)
        For Each dev As MidiOutput In OutDevices
            dev.Send(message)
        Next
    End Sub
    Public Sub Send(ByVal message As Midi.SysExMessage)
        For Each dev As MidiOutput In OutDevices
            dev.Send(message)
        Next
    End Sub
    Public Sub Send(ByVal message As Midi.SysRealtimeMessage)
        For Each dev As MidiOutput In OutDevices
            dev.Send(message)
        Next
    End Sub
#End Region

    'Public WithEvents OutDevice As OutputDevice
    'Public OutDeviceID As Integer = 0
    'Public InDeviceID As Integer = 0
    'Public WithEvents InDevice As InputDevice

    'Public MidiInput As Integer
    'Public MidiOutput As Integer

    'Public SetVolumeMax As Boolean = True
    'Public RemoveOldNotes As Boolean = True
    'Public NoteOut As Boolean = True


    ' ''' <summary>
    ' ''' Will build and send a message.
    ' ''' </summary>
    ' ''' <param name="message">message to send</param>
    'Public Sub Send(ByVal message As Midi.ChannelMessageBuilder)
    '    message.Build()
    '    Send(message.Result)
    'End Sub
    'Public Sub Send(ByVal message As Midi.ChannelMessage)
    '    OutDevice.Send(message)

    '    If Debug Then
    '        frmMain.AddMessageToDebug(message)
    '        'frmMain.lstDebug.Items.Add(message.MidiChannel.ToString & vbTab & message.Command.ToString & vbTab & vbTab & message.Data1.ToString & vbTab & message.Data2.ToString)
    '        'frmMain.lstDebug.SelectedIndex = frmMain.lstDebug.Items.Count - 1
    '    End If
    'End Sub

    'Private Sub InDevice_ChannelMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.ChannelMessageEventArgs) Handles InDevice.ChannelMessageReceived
    '    'If note output is false then return
    '    If Not NoteOut Then Return

    '    'If the message is comeing from the selected midi channel.
    '    If e.Message.MidiChannel = MidiInput Then

    '        'Create a message from the input device.
    '        Dim Message As New Midi.ChannelMessageBuilder(e.Message)

    '        'Is it a note on or off?
    '        If Message.Command = ChannelCommand.NoteOn Or Message.Command = ChannelCommand.NoteOff Then

    '            'Is the note on? (volume more then 0)
    '            If Message.Data2 > 0 Then

    '                If SetVolumeMax Then 'Set the volume to max?
    '                    Message.Data2 = 127 '127 is the maximum Data2 can be. (0 is minimum)
    '                End If

    '                'If alter note for left pedal is checked then  if the pedal is down then lower the volume.
    '                If Not frmMain.radLeft.Checked Then
    '                    If LeftP Then Message.Data2 = 40
    '                End If

    '                'Pedles
    '                If Note(Message.Data1) = Notes.Sostenuto Then
    '                    If Not MiddleP Then
    '                        Note(Message.Data1) = Notes.Pressed

    '                    ElseIf RemoveOldNotes Then
    '                        ReleaseNote(Message.Data1)
    '                        Note(Message.Data1) = Notes.Sostenuto
    '                    End If

    '                ElseIf RightP Then
    '                    If frmMain.radRight.Checked Then
    '                        Note(Message.Data1) = Notes.Pressed
    '                    Else
    '                        If Note(Message.Data1) = Notes.SustainReleased And RemoveOldNotes Then
    '                            ReleaseNote(Message.Data1)
    '                        Else
    '                            SustainList.Add(Message.Data1)
    '                        End If
    '                        Note(Message.Data1) = Notes.SustainPressed
    '                    End If
    '                Else
    '                    Note(Message.Data1) = Notes.Pressed
    '                End If

    '            Else
    '                Select Case Note(Message.Data1)
    '                    Case Notes.Sostenuto
    '                        If MiddleP Then
    '                            Return
    '                        Else
    '                            Note(Message.Data1) = Notes.Released
    '                        End If

    '                    Case Notes.SustainPressed
    '                        If RightP Then
    '                            Note(Message.Data1) = Notes.SustainReleased
    '                            Return
    '                        Else
    '                            Note(Message.Data1) = Notes.Released
    '                        End If
    '                    Case Notes.SustainReleased
    '                        If RightP Then
    '                            Return
    '                        Else
    '                            Note(Message.Data1) = Notes.Released
    '                        End If

    '                    Case Notes.Pressed
    '                        Note(Message.Data1) = Notes.Released
    '                        Message.Command = ChannelCommand.NoteOff

    '                End Select
    '            End If


    '            Send(Message)
    '        End If

    '    Else
    '        Send(e.Message)
    '    End If

    'End Sub

    'Private Sub InDevice_SysCommonMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.SysCommonMessageEventArgs) Handles InDevice.SysCommonMessageReceived
    '    OutDevice.Send(e.Message)
    'End Sub
    'Private Sub InDevice_SysExMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.SysExMessageEventArgs) Handles InDevice.SysExMessageReceived
    '    OutDevice.Send(e.Message)
    'End Sub
    'Private Sub InDevice_SysRealtimeMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.SysRealtimeMessageEventArgs) Handles InDevice.SysRealtimeMessageReceived
    '    OutDevice.Send(e.Message)
    'End Sub
End Module
