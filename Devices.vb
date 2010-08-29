Module Devices
    Public Device As New List(Of MidiDevice)
    Public CurrentDevice As MidiDevice

    Public Sub AddDevice(ByVal InDeviceID As Integer, ByVal OutDeviceID As Integer, ByVal InChannel As Integer, ByVal OutChannel As Integer)

        Dim tmp As New MidiDevice(InChannel, OutChannel)
        tmp.Index = Device.Count

        'Search to see if any others are using the same ID's
        For Each dev As MidiDevice In Device
            If Not dev.Index = tmp.Index Then
                If InDeviceID = dev.InDeviceID Then
                    tmp.InDevice = dev.InDevice
                    tmp.InDeviceID = InDeviceID
                End If
                If OutDeviceID = dev.OutDeviceID Then
                    tmp.OutDevice = dev.OutDevice
                    tmp.OutDeviceID = OutDeviceID
                End If
            End If
        Next

        'Did we find the devices.
        If tmp.InDeviceID = -1 Then
            'We did not find the input device.
            tmp.InDevice = New InputDevice(InDeviceID)
            tmp.InDeviceID = InDeviceID
        End If
        If tmp.OutDeviceID = -1 Then
            'We did not find the output device.
            tmp.OutDevice = New OutputDevice(OutDeviceID)
            tmp.OutDeviceID = OutDeviceID
        End If



        'Add it to the lists.
        Device.Add(tmp)
        frmMain.lstDevices.Items.Add(tmp.ToString)
        frmMain.lstDevices.SelectedIndex = tmp.Index
    End Sub

    Public Sub UpdateDevice(Optional ByVal InDeviceID As Integer = -1, Optional ByVal OutDeviceID As Integer = -1)
        If InDeviceID = -1 Then InDeviceID = CurrentDevice.InDeviceID
        If OutDeviceID = -1 Then OutDeviceID = CurrentDevice.OutDeviceID


        'Search to see if any others are using the same ID's
        For Each dev As MidiDevice In Device
            If Not dev.Index = CurrentDevice.Index Then
                If InDeviceID = dev.InDeviceID Then
                    CurrentDevice.InDevice = dev.InDevice
                    CurrentDevice.InDeviceID = InDeviceID
                End If
                If OutDeviceID = dev.OutDeviceID Then
                    CurrentDevice.OutDevice = dev.OutDevice
                    CurrentDevice.OutDeviceID = OutDeviceID
                End If
            End If
        Next

        'Did we find the devices.
        If CurrentDevice.InDeviceID <> InDeviceID Then
            'We did not find the input device.
            CurrentDevice.InDevice = New InputDevice(InDeviceID)
            CurrentDevice.InDeviceID = InDeviceID
        End If
        If CurrentDevice.OutDeviceID <> OutDeviceID Then
            'We did not find the output device.
            CurrentDevice.OutDevice = New OutputDevice(OutDeviceID)
            CurrentDevice.OutDeviceID = OutDeviceID
        End If

        frmMain.lstDevices.Items(CurrentDevice.Index) = CurrentDevice.ToString()
    End Sub

    Public Sub AddInput(ByVal Input As InputData)
        Input.Device = CurrentDevice
        CurrentDevice.Input.Add(Input)
        frmMain.lstInput.Items.Add(Input)
    End Sub

    Public Sub DisposeDevices()
        For Each dev As MidiDevice In Device
            dev.Dispose()
        Next
    End Sub

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
