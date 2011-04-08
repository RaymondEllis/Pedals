Module modLoad
    'Just something to hold the file name.
    Public Const SettingsFile As String = "Pedals.cfg"

    Public Sub LoadSettings()
        Status("Loading settings.")

        'If the file does not exist then tell then user and return.
        If Not IO.File.Exists(SettingsFile) Then
            Status("Could not load settings file not found.")
            Return
        End If

        'Load the settings from the settings file.
        Dim sd As New SimpleD.SimpleD(SettingsFile, True)

        'Get the pedals group.
        Dim g As SimpleD.Group = sd.GetGroup("Pedals")
        'Now we get values from the group.
        frmMain.chkDebug.Checked = g.GetValue("Debug")
        frmMain.chkRemoveOldNotes.Checked = g.GetValue("RemoveOldNotes")

        Dim MidiIn As Integer = g.GetValue("MidiInput")
        Dim MidiOut As Integer = g.GetValue("MidiOutput")
        Dim InpCount As Integer = g.GetValue("Input")


        For n As Integer = 0 To MidiIn
            g = sd.GetGroup("MidiInput_" & n)
            AddInputDevice(g.GetValue("ID"), g.GetValue("Channel") - 1)

            g.GetValue("AllChannels", CurrentMidiInput.AllChannels)
            g.GetValue("EnableNotes", CurrentMidiInput.EnableNotes)
            g.GetValue("EnableControllers", CurrentMidiInput.EnableControllers)
            g.GetValue("EnableInstrument", CurrentMidiInput.EnableInstrument)
            g.GetValue("OtherChannels", CurrentMidiInput.SendOtherChannels)
            g.GetValue("SetVolumeMax", CurrentMidiInput.SetVolumeMax)

        Next

        For n As Integer = 0 To MidiOut
            g = sd.GetGroup("MidiOutput_" & n)
            AddOutputDevice(g.GetValue("ID"), g.GetValue("Channel") - 1)
        Next

        For n As Integer = 0 To InpCount
            g = sd.GetGroup("Input_" & n)
            Dim inp As New InputData(g.GetValue("ID"), g.GetValue("Axis"), g.GetValue("Reverse"), g.GetValue("SwitchOn"))

            g.GetValue("Controller", inp.Controller)
            g.GetValue("controllerType", inp.ControllerType)
            g.GetValue("AutoName", inp.AutoName)
            g.GetValue("IsControllerSwitch", inp.IsControllerSwitch)
            g.GetValue("SwitchOn", inp.SwitchOn)
            g.GetValue("Name", inp._Name)
            g.GetValue("Input", inp.Input)

            AddInput(inp)
        Next

    End Sub

End Module
