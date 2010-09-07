Module modSave

    Public Sub SaveSettings(ByVal File As String)
        Dim sd As New SimpleD.SimpleD

        Dim g As SimpleD.Group = sd.Create_Group("Pedals")

        With frmMain

            g.Add(.chkDebug)
            g.Add(.chkRemoveOldNotes)

            g.Add("MidiInput", InDevices.Count - 1)
            g.Add("MidiOutput", OutDevices.Count - 1)

            g.Add("Input", Input.Count - 1)

        End With

        'Midi input:
        Dim i As Integer = 0
        For Each dev As MidiInput In InDevices
            g = sd.Create_Group("MidiInput_" & i)
            g.Add("DeviceID", dev.DeviceID)
            g.Add("Channel", dev.Channel)
            g.Add("AllChannels", dev.AllChannels)
            g.Add("EnableNotes", dev.EnableNotes)
            g.Add("OtherChannels", dev.SendOtherChannels)
            g.Add("SetVolumeMax", dev.SetVolumeMax)


            i += 1
        Next

        'Midi output:
        i = 0
        For Each dev As MidiOutput In OutDevices
            g = sd.Create_Group("MidiOutput_" & i)
            g.Add("DeviceID", dev.DeviceID)
            g.Add("Channel", dev.Channel)

            i += 1
        Next


        'Input:
        i = 0
        For Each inp As InputData In Input
            g = sd.Create_Group("Input_" & i)
            g.Add("ID", inp.ID)
            g.Add("Axis", inp.Axis)
            g.Add("Controller", inp.Controller)
            g.Add("controllerType", inp.ControllerType)
            g.Add("AutoName", inp.AutoName)
            g.Add("IsControllerSwitch", inp.IsControllerSwitch)
            g.Add("SwitchOn", inp.SwitchOn)
            g.Add("Name", inp._Name)

            i += 1
        Next

        sd.ToFile(File)
    End Sub

End Module
