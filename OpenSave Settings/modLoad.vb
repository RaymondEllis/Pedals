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
        Dim sd As New SimpleD.Group(SettingsFile, True)

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

            g.GetValue("AllChannels", CurrentMidiInput.AllChannels, False)
            g.GetValue("EnableNotes", CurrentMidiInput.EnableNotes, False)
            g.GetValue("EnableControllers", CurrentMidiInput.EnableControllers, False)
            g.GetValue("EnableInstrument", CurrentMidiInput.EnableInstrument, False)
            g.GetValue("OtherChannels", CurrentMidiInput.SendOtherChannels, False)
            g.GetValue("SetVolumeMax", CurrentMidiInput.SetVolumeMax, False)

        Next

        For n As Integer = 0 To MidiOut
            g = sd.GetGroup("MidiOutput_" & n)
            AddOutputDevice(g.GetValue("ID"), g.GetValue("Channel") - 1)
        Next

        For n As Integer = 0 To InpCount
            g = sd.GetGroup("Input_" & n)
            Dim inp As New InputData(g.GetValue("ID"), g.GetValue("Axis"), g.GetValue("Reverse"), g.GetValue("SwitchOn"))

            g.GetValue("Controller", inp.Controller, False)
            g.GetValue("controllerType", inp.ControllerType, False)
            g.GetValue("AutoName", inp.AutoName, False)
            g.GetValue("IsControllerSwitch", inp.IsControllerSwitch, False)
            g.GetValue("SwitchOn", inp.SwitchOn, False)
            g.GetValue("Name", inp._Name, False)
            g.GetValue("Input", inp.Input, False)

            AddInput(inp)
        Next

    End Sub


#Region "Get/Set value to/from control v1" 'Update to https://code.google.com/p/simpled/wiki/control_helper
    ''' <summary>
    ''' Sets the value of the control to the proprety with the same name.
    ''' Known controls: TextBox,Label,CheckBox,RadioButton,NumericUpDown,ProgressBar
    ''' </summary>
    ''' <param name="Control">The control to get the property from.</param>
    ''' <param name="Group">The group to get the value from.</param>
    Public Sub GetValue(ByRef Control As Windows.Forms.Control, Group As SimpleD.Group)
        Dim [Property] As SimpleD.Property = Group.Find(Control.Name) 'Find the property from the control name.
        If [Property] Is Nothing Then Return
        Dim TempValue As String = [Property].Value
        Dim obj As Object = Control
        If TypeOf Control Is Windows.Forms.TextBox Or TypeOf Control Is Windows.Forms.Label Then
            obj.Text = TempValue
        ElseIf TypeOf Control Is Windows.Forms.CheckBox Or TypeOf Control Is Windows.Forms.RadioButton Then
            If Not Boolean.TryParse(TempValue, obj.Checked) Then Return
        ElseIf TypeOf Control Is Windows.Forms.NumericUpDown Or TypeOf Control Is Windows.Forms.ProgressBar Then
            Dim tValue As Decimal = 0
            If Decimal.TryParse(TempValue, tValue) Then
                If tValue > obj.Maximum Then
                    obj.Value = obj.Maximum
                ElseIf tValue < obj.Minimum Then
                    obj.Value = obj.Minimum
                Else
                    obj.Value = tValue
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' This sets the value of a property.
    ''' If it can not find the property it creates it.
    ''' </summary>
    Public Sub SetValue(ByVal Control As Windows.Forms.Control, Group As SimpleD.Group)
        Dim Value As String = GetValueFromControl(Control) 'Find the property from a object and set the value.
        Dim tmp As SimpleD.Property = Group.Find(Control.Name) 'Find the property.
        If tmp Is Nothing Then 'If it could not find the property then.
            Group.Properties.Add(New SimpleD.Property(Control.Name, Value)) 'Add the property.
        Else
            tmp.Value = Value 'Set the value.
        End If
    End Sub
    Private Function GetValueFromControl(ByVal Obj As Object) As String
        If TypeOf Obj Is Windows.Forms.TextBox Or TypeOf Obj Is Windows.Forms.Label Then
            Return Obj.Text
        ElseIf TypeOf Obj Is Windows.Forms.CheckBox Or TypeOf Obj Is Windows.Forms.RadioButton Then
            Return Obj.Checked
        ElseIf TypeOf Obj Is Windows.Forms.NumericUpDown Or TypeOf Obj Is Windows.Forms.ProgressBar Then
            Return Obj.Value
        End If

        'Unknown control, so lets see if we can find the right value.
        Dim Value As String = "Could_Not_Find_Value"
        Try 'Try and get the value.
            Value = Obj.Value
        Catch
            Try 'Try and get checked.
                Value = Obj.Checked
            Catch
                Try 'Try and get the text.
                    Value = Obj.Text
                Catch
                    Try
                        Value = Obj.ToString
                    Catch
                        Throw New Exception("Could not get value from object:" & Obj.name)
                    End Try
                End Try
            End Try
        End Try
        Return Value
    End Function
#End Region
End Module
