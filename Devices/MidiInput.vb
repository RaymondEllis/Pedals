Public Class MidiInput
    Inherits MidiBaseDevice

    Public WithEvents Device As InputDevice




    Public SetVolumeMax As Boolean = True
    Public RemoveOldNotes As Boolean = True
    Public EnableNotes As Boolean = True
    Public SendOtherChannels As Boolean = False
    Public AllChannels As Boolean = False



#Region "Base"
    Public Sub New(ByVal DeviceID As Integer, ByVal Channel As Integer)
        Me.DeviceID = DeviceID
        'Channels(Channel) = True
        Me.Channel = Channel
    End Sub

    Public Overrides Function ToString() As String
        If DeviceID = -1 Then Return "No device selected!"
        Return frmMain.comInput.Items(DeviceID)
    End Function

    Public Sub Dispose()
        If Device IsNot Nothing Then
            Device.Close()
            Device = Nothing
        End If
    End Sub

#End Region

    Public Function StartRecording() As Boolean

        'First lets check to see if we have any deviecs
        If DeviceID = -1 Then Return False

        'Find the device and create one if there is none being used.
        'Search to see if any others are using the same IDs.
        Dim FoundInput As Boolean = False
        If Device IsNot Nothing Then If DeviceID = Device.DeviceID Then FoundInput = True 'Do we already have a input device?

        'If we don't have both devices then find them.
        If Not FoundInput Then
            For Each dev As MidiInput In InDevices
                If Not dev.Index = Index Then
                    If DeviceID = dev.DeviceID And Not FoundInput Then

                        If Device IsNot Nothing Then Device.Close()

                        Device = dev.Device
                        FoundInput = True
                    End If
                End If
            Next

            'Did we find the devices.
            If Not FoundInput Then
                Try
                    'We did not find the input device.
                    Device = New InputDevice(DeviceID)
                Catch ex As Exception
                    If ex.Message = "The specified device is already in use.  Wait until it is free, and then try again." Then
                        Status("Could not load input. You may need to restart your computer.", True)
                        Device = Nothing
                        Return False
                    End If
                End Try

            End If

        End If


        Device.StartRecording()

        Return True
    End Function
    Public Sub StopRecording()
        Device.StopRecording()
    End Sub



#Region "Device events"
    Private Sub InDevice_ChannelMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.ChannelMessageEventArgs) Handles Device.ChannelMessageReceived
        If Not Recording Then Return 'If we are not recording then leave.

        

        'If the message is comeing from the selected midi channel.
        If AllChannels Or e.Message.MidiChannel = Channel Then

            'Create a message from the input device.
            Dim Message As New Midi.ChannelMessageBuilder(e.Message)

            'Is it a note (on or off)?
            If (Message.Command = ChannelCommand.NoteOn Or Message.Command = ChannelCommand.NoteOff) And EnableNotes Then

                'Is the note on? (volume more then 0)
                If Message.Data2 > 0 Then

                    If SetVolumeMax Then 'Set the volume to max?
                        Message.Data2 = 127 '127 is the maximum Data2 can be. (0 is minimum)
                    End If

                    'If alter note for left pedal is checked then  if the pedal is down then lower the volume.
                    If SoftPressed Then
                        Message.Data2 = 40
                    End If


                    'Pedals
                    If Note(Message.Data1) = Notes.Sostenuto Then
                        If Not SostenutoPressed Then
                            Note(Message.Data1) = Notes.Pressed

                        ElseIf RemoveOldNotes Then
                            ReleaseNote(Message.Data1)
                            Note(Message.Data1) = Notes.Sostenuto
                        End If

                    ElseIf SustainPressed Then
                        If Note(Message.Data1) = Notes.SustainReleased And RemoveOldNotes Then
                            ReleaseNote(Message.Data1)
                        Else
                            SustainList.Add(Message.Data1)
                        End If
                        Note(Message.Data1) = Notes.SustainPressed

                    Else
                        Note(Message.Data1) = Notes.Pressed
                    End If

                Else
                    Select Case Note(Message.Data1)
                        Case Notes.Sostenuto
                            If SostenutoPressed Then
                                Return
                            Else
                                Note(Message.Data1) = Notes.Released
                            End If

                        Case Notes.SustainPressed
                            If SustainPressed Then
                                Note(Message.Data1) = Notes.SustainReleased
                                Return
                            Else
                                Note(Message.Data1) = Notes.Released
                            End If
                        Case Notes.SustainReleased
                            If SustainPressed Then
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

            ElseIf Message.Command = ChannelCommand.Controller Then
                Send(Message)
            End If

        ElseIf SendOtherChannels Then
            Send(e.Message)
        End If

    End Sub

    Private Sub InDevice_SysCommonMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.SysCommonMessageEventArgs) Handles Device.SysCommonMessageReceived
        If Not Recording Then Return 'If we are not recording then leave
        Send(e.Message)
    End Sub
    Private Sub InDevice_SysExMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.SysExMessageEventArgs) Handles Device.SysExMessageReceived
        If Not Recording Then Return 'If we are not recording then leave.

        Send(e.Message)
    End Sub
    Private Sub InDevice_SysRealtimeMessageReceived(ByVal sender As Object, ByVal e As Sanford.Multimedia.Midi.SysRealtimeMessageEventArgs) Handles Device.SysRealtimeMessageReceived
        If Not Recording Then Return 'If we are not recording then leave.

        Send(e.Message)
    End Sub

#End Region


#Region "Input"




    
    Friend Sub PressSustain()
        'Check for down keys and set them to sustain.
        Parallel.For(0, Note.Length - 1, Sub(n)
                                             'For n As Integer = 0 To CurrentDevice.Note.Length - 1
                                             If Note(n) = Notes.Pressed Then
                                                 Note(n) = Notes.SustainPressed
                                                 SustainList.Add(n)
                                             End If
                                             'Next
                                         End Sub)
    End Sub
    Friend Sub ReleaseSustain()
        Dim tmp As New ChannelMessageBuilder
        tmp.Command = Midi.ChannelCommand.NoteOff
        tmp.Data2 = 0
        For Each n As Integer In SustainList
            If Note(n) = Notes.SustainReleased Then
                Note(n) = Notes.Released
                tmp.Data1 = n
                Send(tmp)
            End If
        Next
        SustainList.Clear()
    End Sub

    Friend Sub PressSostenuto()
        Parallel.For(0, Note.Length - 1, Sub(n As Integer)
                                             If Note(n) = Notes.Pressed Or Note(n) = Notes.SustainPressed Then
                                                 Note(n) = Notes.Sostenuto
                                                 SostenutoList.Add(n)
                                             End If
                                         End Sub)
    End Sub
    Friend Sub ReleaseSostenuto()
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
    End Sub

#End Region

End Class
