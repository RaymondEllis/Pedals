Module Devices
    Public Recording As Boolean = False

    Public RemoveOldNotes As Boolean = True

    Public InDevices As New List(Of MidiInput)
    Public OutDevices As New List(Of MidiOutput)
    Public CurrentMidiInput As MidiInput
    Public CurrentMidiOutput As MidiOutput


    Public Sub AddInputDevice(ByVal DeviceID As Integer, ByVal Channel As Integer)
        For Each dev As MidiInput In InDevices
            If dev.DeviceID = DeviceID Then
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
            If dev.DeviceID = DeviceID Then
                Status("Can not have more then one of the same device.")
                Return
            End If
        Next

        CurrentMidiInput.DeviceID = DeviceID

        frmMain.lstMidiInput.Items(CurrentMidiInput.Index) = CurrentMidiInput.ToString()

        frmMain.CheckNoteDisable()
    End Sub
    Public Sub RemoveInputDevice(ByVal Index As Integer)

        frmMain.lstMidiInput.Items.RemoveAt(Index) 'Remove the device from the list on the form.
        InDevices(Index).Dispose() 'Dispose the device.
        InDevices.RemoveAt(Index) 'Remove the device from the main list.

        'Do we have any devices left?
        If InDevices.Count = 0 Then
            CurrentMidiInput = Nothing 'There is no current device.
            frmMain.btnMidiInputRemove.Enabled = False 'Don't allow anybuddy to press the button.
            frmMain.btnMidiInputSet.Enabled = False
        Else
            'Update the indexes of the other devices.
            For n As Integer = Index To InDevices.Count - 1
                InDevices(n).Index = n
            Next

            'Set the curent device to the last one in the list.
            frmMain.lstMidiInput.SelectedIndex = Index - 1
        End If

    End Sub

    Public Sub AddOutputDevice(ByVal DeviceID As Integer, ByVal Channel As Integer)
        For Each dev As MidiOutput In OutDevices
            If dev.DeviceID = DeviceID Then
                Status("Can not have more then one of the same device.")
                Return
            End If
        Next

        Dim tmp As New MidiOutput(DeviceID, Channel)
        tmp.Index = OutDevices.Count

        'Add it to the lists.
        OutDevices.Add(tmp)
        frmMain.lstMidiOutput.Items.Add(tmp.ToString)
        frmMain.lstMidiOutput.SelectedIndex = tmp.Index

        frmMain.btnMidiOutputRemove.Enabled = True
        frmMain.btnMidiOutputSet.Enabled = True
    End Sub
    Public Sub UpdateOutputDevice(ByVal DeviceID As Integer)
        For Each dev As MidiOutput In OutDevices
            If dev.DeviceID = DeviceID Then
                Status("Can not have more then one of the same device.")
                Return
            End If
        Next

        CurrentMidiOutput.DeviceID = DeviceID

        frmMain.lstMidiOutput.Items(CurrentMidiOutput.Index) = CurrentMidiOutput.ToString()

        frmMain.CheckNoteDisable()
    End Sub
    Public Sub RemoveOutputDevice(ByVal Index As Integer)

        frmMain.lstMidiOutput.Items.RemoveAt(Index) 'Remove the device from the list on the form.
        OutDevices(Index).Dispose() 'Dispose the device.
        OutDevices.RemoveAt(Index) 'Remove the device from the main list.

        'Do we have any devices left?
        If OutDevices.Count = 0 Then
            CurrentMidiOutput = Nothing 'There is no current device.
            frmMain.btnMidiOutputRemove.Enabled = False 'Don't allow anybuddy to press the button.
            frmMain.btnMidiOutputSet.Enabled = False
        Else
            'Update the indexes of the other devices.
            For n As Integer = Index To OutDevices.Count - 1
                OutDevices(n).Index = n
            Next

            'Set the curent device to the last one in the list.
            frmMain.lstMidiOutput.SelectedIndex = Index - 1
        End If

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

End Module
