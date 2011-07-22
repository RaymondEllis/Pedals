Module modSave

    Public Sub SaveSettings()
        'Create a new SimpleD so we can use it for saving stuff to.
        Dim sd As New SimpleD.Group

        'Create a new group.
        Dim g As SimpleD.Group = sd.CreateGroup("Pedals")

        'SetValue stuff to the group.
        With frmMain

            g.SetValue("Debug", .chkDebug.Checked)
            g.SetValue("RemoveOldNotes", .chkRemoveOldNotes.Checked)

            g.SetValue("MidiInput", InDevices.Count - 1)
            g.SetValue("MidiOutput", OutDevices.Count - 1)

            g.SetValue("Input", Input.Count - 1)

        End With

        'Midi input:
        Dim i As Integer = 0
        For Each dev As MidiInput In InDevices
            g = sd.CreateGroup("MidiInput_" & i)
            g.SetValue("ID", dev.DeviceID)
            g.SetValue("Channel", dev.Channel + 1)
            g.SetValue("AllChannels", dev.AllChannels)
            g.SetValue("EnableNotes", dev.EnableNotes)
            g.SetValue("EnableControllers", dev.EnableControllers)
            g.SetValue("EnableInstrument", dev.EnableInstrument)
            g.SetValue("OtherChannels", dev.SendOtherChannels)
            g.SetValue("SetVolumeMax", dev.SetVolumeMax)


            i += 1
        Next

        'Midi output:
        i = 0
        For Each dev As MidiOutput In OutDevices
            g = sd.CreateGroup("MidiOutput_" & i)
            g.SetValue("ID", dev.DeviceID)
            g.SetValue("Channel", dev.Channel + 1)

            i += 1
        Next


        'Input:
        i = 0
        For Each inp As InputData In Input
            g = sd.CreateGroup("Input_" & i)
            g.SetValue("ID", inp.ID)
            g.SetValue("Axis", inp.Axis)
            g.SetValue("Reverse", inp.Reverse)
            g.SetValue("Controller", inp.Controller)
            g.SetValue("controllerType", inp.ControllerType)
            g.SetValue("AutoName", inp.AutoName)
            g.SetValue("IsControllerSwitch", inp.IsControllerSwitch)
            g.SetValue("SwitchOn", inp.SwitchOn)
            g.SetValue("Name", inp._Name)
            g.SetValue("Input", inp.Input)


            i += 1
        Next

        'Save the info in the SimpleD.
        sd.ToFile(SettingsFile)
    End Sub

End Module
