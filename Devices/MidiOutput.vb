Public Class MidiOutput
    Inherits MidiBaseDevice

    Public WithEvents Device As OutputDevice


#Region "Base"
    Public Sub New(ByVal DeviceID As Integer, ByVal Channel As Integer)
        Me.DeviceID = DeviceID
        Me.Channel = Channel
    End Sub

    Public Overrides Function ToString() As String
        If DeviceID = -1 Then Return "No device selected!"
        Return frmMain.comOutput.Items(DeviceID)
    End Function

    Public Sub Dispose()
        Recording = False

        If Device IsNot Nothing Then
            Device.Close()
            Device = Nothing
        End If
    End Sub
#End Region



    Public Function Start() As Boolean


        'First lets check to see if we have a device.
        If DeviceID = -1 Then Return False

        'Find the device and create one if there is none being used.
        'Search to see if any others are using the same IDs.
        Dim FoundOutput As Boolean = False
        If Device IsNot Nothing Then If DeviceID = Device.DeviceID Then FoundOutput = True 'Do we already have a output device?

        'If we don't have a device then find it.
        If Not FoundOutput Then
            For Each dev As MidiOutput In OutDevices
                If Not dev.Index = Index Then
                    If DeviceID = dev.DeviceID And Not FoundOutput Then

                        If Device IsNot Nothing Then Device.Close()


                        Device = dev.Device
                        FoundOutput = True
                    End If
                End If
            Next

            'Did we find the devices.
            If Not FoundOutput Then
                Try
                    'We did not find the output device.
                    Device = New OutputDevice(DeviceID)
                Catch ex As Exception
                    If ex.Message = "The specified device is already in use.  Wait until it is free, and then try again." Then
                        Status("Could not load output(" & ToString() & "(. You may need to restart your computer.", True)
                        Device = Nothing
                        Return False
                    End If
                End Try

            End If

        End If



        Return True
    End Function


    Public Sub Send(ByVal message As Midi.ChannelMessage)
        Device.Send(message)
    End Sub
    Public Sub Send(ByVal message As Midi.SysCommonMessage)
        Device.Send(message)
    End Sub
    Public Sub Send(ByVal message As Midi.SysExMessage)
        Device.Send(message)
    End Sub
    Public Sub Send(ByVal message As Midi.SysRealtimeMessage)
        Device.Send(message)
    End Sub
End Class
