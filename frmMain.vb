Public Class frmMain
	'Made by Raymond Ellis



	Public ContinueLoading As Boolean = True


#Region "Loading and closing"

	Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Status("Closing... Done!")
	End Sub

	Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ContinueLoading = False
        EnableJoysticks = False

        If Loaded Then SaveSettings()
		Status("Closing...")
        tmrInput.Enabled = False

        DisposeDevices()


        DistroyInput()

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Pedals v" & Application.ProductVersion.ToString

        Me.Width = 697

        'Fill boxs.
        GetDevices()

        ' frmInput = New frmInput

        'frmInput.comController.Items.AddRange([Enum].GetNames(GetType(Midi.ControllerType)))
        'frmInput.comController.SelectedItem = Midi.ControllerType.HoldPedal1.ToString

        'frmInput.comControllerType.Items.AddRange([Enum].GetNames(GetType(InputStuff.ControllerType0)))
        'frmInput.comControllerType.SelectedItem = ControllerType0.MIDI.ToString
    End Sub

    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Init devices.


        If ContinueLoading Then
            

            CreateInput()

            EnableControls(True, True, True, True, True)



            LoadSettings()
        End If

        Loaded = True
        CheckNoteDisable()
        SetControls()
        Status("Loading... Done!")

    End Sub

    Public Sub EnableControls(ByVal Value As Boolean, Optional ByVal Main As Boolean = False, Optional ByVal Devices As Boolean = False, Optional ByVal Misc As Boolean = False, Optional ByVal Debug As Boolean = False)
        If Main Then
            btnSS.Enabled = Value
            grpMidiInput.Enabled = Value
            grpMidiOutput.Enabled = Value
        End If
        If Devices Then
            panMidiInput.Enabled = Value
            panMidiOutput.Enabled = Value
        End If
        If Debug Then chkDebug.Enabled = Value
        If Misc Then grpMisc.Enabled = Value
    End Sub
#End Region


#Region "Get Input/Output Devices"
    Private Sub GetDevices()
        If OutputDevice.DeviceCount > 0 Then
            For i As Integer = 0 To OutputDevice.DeviceCount - 1
                comOutput.Items.Add(OutputDevice.GetDeviceCapabilities(i).name)
            Next
            comOutput.SelectedIndex = 0
        Else
            Status("No output midi devices!", True)
            ContinueLoading = False
            Close()
        End If


        If InputDevice.DeviceCount > 0 Then
            For i As Integer = 0 To InputDevice.DeviceCount - 1
                comInput.Items.Add(InputDevice.GetDeviceCapabilities(i).name)
            Next
            comInput.SelectedIndex = 0
        Else
            Status("No input midi devices!", True)
            ContinueLoading = False
            Close()
        End If

    End Sub

   


   
#End Region


#Region "Debug"
    Delegate Sub AddMessageToDebugCallback(ByVal [Message] As ChannelMessage)
    Public Sub AddMessageToDebug(ByVal [Message] As ChannelMessage)
        If Me.lstDebug.InvokeRequired Then
            Dim d As New AddMessageToDebugCallback(AddressOf AddMessageToDebug)
            Me.Invoke(d, New Object() {[Message]})
        Else
            If Me.lstDebug.Items.Count = 18 Then
                Me.lstDebug.Items.RemoveAt(0)
            End If

            Me.lstDebug.Items.Add(Message.MidiChannel + 1 & vbTab & _
                                  Message.Command.ToString.PadRight(15) & vbTab & _
                                  Message.Data1.ToString & vbTab & _
                                  Message.Data2.ToString)

            Me.lstDebug.SelectedIndex = Me.lstDebug.Items.Count - 1
        End If
    End Sub

    Private Sub chkDebug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDebug.CheckedChanged
        Debug = chkDebug.Checked
        grpDebug.Enabled = Debug

        If Debug = False Then
            lstDebug.Items.Clear()
            Me.Width = 697
        Else
            Me.Width = 995
        End If
    End Sub
#End Region

#Region "Pedals"

#Region "Left"
    ''Private LeftP As Boolean = False
    'Private LeftChanged As Boolean = True
    'Private LeftInput As InputData
    'Private LeftController As Integer
    'Private LeftIsControllerSwitch As Boolean = True
    'Private LeftDown As Color = Color.White
    'Private Sub DoLeft()
    '       Dim Pos As Integer = LeftInput.GetAxisPosition

    '       If Pos = LeftInput.OldPosition Then Return

    '       'Press and release virtual pedal.
    '       If Pos >= LeftInput.SwitchOn Then
    '           If Not LeftP Then
    '               LeftP = True
    '               LeftChanged = True
    '           Else
    '               LeftChanged = False
    '           End If
    '       Else
    '           If LeftP Then
    '               LeftP = False
    '               LeftChanged = True
    '           Else
    '               LeftChanged = False
    '           End If
    '       End If


    '       If radLeft.Checked Then

    '           Dim m As New ChannelMessageBuilder
    '           m.Command = ChannelCommand.Controller
    '           m.Data1 = LeftController
    '           If LeftIsControllerSwitch And LeftChanged Then
    '               If LeftP Then
    '                   m.Data2 = 127
    '               Else
    '                   m.Data2 = 0
    '               End If
    '               CurrentDevice.Send(m)
    '           ElseIf Not LeftIsControllerSwitch Then
    '               m.Data2 = Pos
    '               CurrentDevice.Send(m)
    '           End If



    '       End If





    '       LeftInput.OldPosition = Pos
    '   End Sub

#End Region

#Region "Middle"

    'Private MiddleChanged As Boolean
    'Private MiddleInput As InputData
    'Private MiddleController As Integer
    'Private MiddleIsControllerSwitch As Boolean = True
    'Private Sub DoMiddle()
    '    Dim MiddleChanged As Boolean
    '    Dim Pos As Integer = MiddleInput.GetAxisPosition

    '    If Pos = MiddleInput.OldPosition Then Return

    '    If Pos >= MiddleInput.SwitchOn Then
    '        If Not MiddleP Then
    '            MiddleP = True
    '            MiddleChanged = True
    '        Else
    '            MiddleChanged = False
    '        End If
    '    Else
    '        If MiddleP Then
    '            MiddleP = False
    '            MiddleChanged = True
    '        Else
    '            MiddleChanged = False
    '        End If
    '    End If

    '    If radMiddle.Checked Then

    '        Dim m As New ChannelMessageBuilder
    '        m.Command = ChannelCommand.Controller
    '        m.Data1 = MiddleController
    '        If MiddleIsControllerSwitch And MiddleChanged Then
    '            If MiddleP Then
    '                m.Data2 = 127
    '            Else
    '                m.Data2 = 0
    '            End If
    '            CurrentDevice.Send(m)
    '        ElseIf Not MiddleIsControllerSwitch Then
    '            m.Data2 = Pos
    '            CurrentDevice.Send(m)
    '        End If




    '    Else

    '        If Pos <= MiddleInput.SwitchOn Then
    '            If MiddleChanged Then
    '                'Check for down keys and set them to sostento.
    '                Parallel.For(0, CurrentDevice.Note.Length - 1, Sub(n As Integer)
    '                                                                   If CurrentDevice.Note(n) = Notes.Pressed Or CurrentDevice.Note(n) = Notes.SustainPressed Then
    '                                                                       CurrentDevice.Note(n) = Notes.Sostenuto
    '                                                                       SostenutoList.Add(n)
    '                                                                   End If
    '                                                               End Sub)

    '            End If

    '        Else 'Release pedal.
    '            If MiddleChanged Then

    '                Dim tmp As New ChannelMessageBuilder
    '                tmp.Command = Midi.ChannelCommand.NoteOff
    '                tmp.MidiChannel = 0
    '                tmp.Data2 = 0
    '                For Each n As Integer In SostenutoList
    '                    CurrentDevice.Note(n) = Notes.Released
    '                    tmp.Data1 = n
    '                    CurrentDevice.Send(tmp)
    '                Next
    '                SostenutoList.Clear()

    '            End If
    '        End If


    '    End If



    '    MiddleInput.OldPosition = Pos
    'End Sub

#End Region

#Region "Right"
    'Private RightChanged As Boolean = True
    'Private RightInput As InputData
    'Private RightController As Integer
    'Private RightIsControllerSwitch As Boolean = True
    'Private Sub DoRight()
    '    Dim Pos As Integer = RightInput.GetAxisPosition

    '    If Pos = RightInput.OldPosition Then Return

    '    If Pos >= RightInput.SwitchOn Then
    '        If Not RightP Then
    '            RightP = True
    '            RightChanged = True
    '        Else
    '            RightChanged = False
    '        End If
    '    Else
    '        If RightP Then
    '            RightP = False
    '            RightChanged = True
    '        Else
    '            RightChanged = False
    '        End If
    '    End If

    '    If radRight.Checked Then

    '        Dim m As New ChannelMessageBuilder
    '        m.Command = ChannelCommand.Controller
    '        m.Data1 = RightController
    '        If RightIsControllerSwitch And RightChanged Then
    '            If RightP Then
    '                m.Data2 = 127
    '            Else
    '                m.Data2 = 0
    '            End If
    '            CurrentDevice.Send(m)
    '        ElseIf Not RightIsControllerSwitch Then
    '            m.Data2 = Pos
    '            CurrentDevice.Send(m)
    '        End If





    '    Else

    '        If Pos >= RightInput.SwitchOn Then
    '            If RightChanged Then
    '                'Check for down keys and set them to sustain.
    '                Parallel.For(0, CurrentDevice.Note.Length - 1, Sub(n)
    '                                                                   If CurrentDevice.Note(n) = Notes.Pressed Then
    '                                                                       CurrentDevice.Note(n) = Notes.SustainPressed
    '                                                                       SustainList.Add(n)
    '                                                                   End If
    '                                                               End Sub)


    '            End If

    '        Else 'Release pedal.
    '            If RightChanged Then

    '                Dim tmp As New ChannelMessageBuilder
    '                tmp.Command = Midi.ChannelCommand.NoteOff
    '                tmp.Data2 = 0
    '                For Each n As Integer In SustainList
    '                    If CurrentDevice.Note(n) = Notes.SustainReleased Then
    '                        CurrentDevice.Note(n) = Notes.Released
    '                        tmp.Data1 = n
    '                        CurrentDevice.Send(tmp)
    '                    End If
    '                Next
    '                SustainList.Clear()


    '            End If
    '        End If


    '    End If



    '    RightInput.OldPosition = Pos
    'End Sub

#End Region

#Region "Controls"
    'Private Sub radLeft_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    comLeft.Enabled = sender.checked
    '    If sender.checked = False Then
    '        radLeft2.Checked = True
    '    End If
    'End Sub
    'Private Sub radMiddle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    comMiddle.Enabled = sender.checked
    '    If sender.checked = False Then
    '        radMiddle2.Checked = True
    '    End If
    '    If sender.checked And MiddleP Then
    '        Dim tmp As New ChannelMessageBuilder
    '        tmp.Command = Midi.ChannelCommand.NoteOff
    '        tmp.MidiChannel = 0
    '        tmp.Data2 = 0
    '        For Each n As Integer In SostenutoList
    '            CurrentDevice.Note(n) = Notes.Released
    '            tmp.Data1 = n
    '            CurrentDevice.Send(tmp)
    '        Next
    '        SostenutoList.Clear()
    '    End If
    'End Sub
    'Private Sub radRight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    comRight.Enabled = sender.checked
    '    If sender.checked = False Then
    '        radRight2.Checked = True
    '    End If
    '    If sender.checked And RightP Then
    '        Dim tmp As New ChannelMessageBuilder
    '        tmp.Command = Midi.ChannelCommand.NoteOff
    '        tmp.Data2 = 0
    '        For Each n As Integer In SustainList
    '            If CurrentDevice.Note(n) = Notes.SustainReleased Then
    '                CurrentDevice.Note(n) = Notes.Released
    '                tmp.Data1 = n
    '                CurrentDevice.Send(tmp)
    '            End If
    '        Next
    '        SustainList.Clear()
    '    End If
    'End Sub

    'Private Sub comLeft_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LeftController = [Enum].Parse(GetType(Midi.ControllerType), sender.SelectedItem.ToString)
    '    LeftIsControllerSwitch = IsSwitch(LeftController)
    'End Sub
    'Private Sub comMiddle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MiddleController = [Enum].Parse(GetType(Midi.ControllerType), sender.SelectedItem.ToString)
    '    MiddleIsControllerSwitch = IsSwitch(MiddleController)
    'End Sub
    'Private Sub comRight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    RightController = [Enum].Parse(GetType(Midi.ControllerType), sender.SelectedItem.ToString)
    '    RightIsControllerSwitch = IsSwitch(RightController)
    'End Sub




    'Private Sub btnLeftInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If frmInput.ShowDialog(LeftInput) = System.Windows.Forms.DialogResult.OK Then
    '        LeftInput = frmInput.CurrentInput
    '    End If
    'End Sub
    'Private Sub btnMiddleInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If frmInput.ShowDialog(MiddleInput) = System.Windows.Forms.DialogResult.OK Then
    '        MiddleInput = frmInput.CurrentInput
    '    End If
    'End Sub
    'Private Sub btnRightInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If frmInput.ShowDialog(RightInput) = System.Windows.Forms.DialogResult.OK Then
    '        RightInput = frmInput.CurrentInput
    '    End If
    'End Sub

#End Region



#End Region


#Region "Input"

    Private Sub tmrInput_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrInput.Tick
        DoInput()
    End Sub

    Private Sub btnInputNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInputAdd.Click
        Dim tmp As InputData = Nothing
        If frmInput.ShowDialog(tmp) = System.Windows.Forms.DialogResult.OK Then
            AddInput(tmp)
            lstInput.SelectedIndex = lstInput.Items.Count - 1
        End If
    End Sub

    Private Sub btnInputEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInputEdit.Click
        If frmInput.ShowDialog(lstInput.SelectedIndex) = DialogResult.OK Then
            'CurrentDevice.Input(lstInput.SelectedIndex) = frmInput.CurrentInput
            lstInput.Items(lstInput.SelectedIndex) = frmInput.CurrentInput
        End If
    End Sub


    Private Sub btnInputRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInputRemove.Click
        RemoveInput(lstInput.SelectedIndex)
    End Sub
#End Region

#Region "StartStop"
    Private Sub btnSS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSS.Click
        StartStop()
        If Recording Then
            btnSS.Text = "Stop"
        Else
            btnSS.Text = "Start"
        End If
    End Sub

    Public Sub StartStop()
        If Not Recording Then

            Dim numInput As Integer
            For Each dev As MidiInput In InDevices
                If dev.StartRecording Then
                    numInput += 1
                End If
            Next
            Dim numOutput As Integer
            For Each dev As MidiOutput In OutDevices
                If dev.Start Then
                    numOutput += 1
                End If
            Next

            If numInput > 0 And numOutput > 0 Then
                'tmrInput.Enabled = True 'Will not enable the input timmer if there is no joysticks.
                EnableControls(False, , True)
                btnTest.Enabled = True
                tmrInput.Enabled = True

                Status("Recording")
                Recording = True
            End If


        Else
            tmrInput.Enabled = False
            btnTest.Enabled = False

            For Each dev As MidiInput In InDevices
                dev.StopRecording()
            Next

            ResetNotes()
            SustainList.Clear()
            SostenutoList.Clear()


            Recording = False
            EnableControls(True, , True)

            Status("Stoped recording")
        End If
    End Sub
#End Region





#Region "Misc"
    Private Sub chkMidiInputVolume_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMidiInputVolume.CheckedChanged
        If Not Loaded Then Return 'We don't need to change anything here until we are done loading.
        CurrentMidiInput.SetVolumeMax = sender.checked
    End Sub

    Private Sub chkOldNote_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRemoveOldNotes.CheckedChanged
        If Not Loaded Then Return 'We don't need to change anything here until we are done loading.
        RemoveOldNotes = sender.checked
    End Sub


#End Region

#Region "Test"
    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        btnTest.Enabled = False
        testL = 0
        tmrTest.Enabled = True
    End Sub

    Dim testL As Integer
    Private Sub tmrTest_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTest.Tick
        testL += 1
        Dim m As New ChannelMessageBuilder
        m.Command = ChannelCommand.NoteOn
        m.Data1 = 72 + testL
        m.Data2 = 127
        Send(m)
        Threading.Thread.Sleep(20)
        m.Command = ChannelCommand.NoteOff
        m.Data2 = 0
        Send(m)
        Threading.Thread.Sleep(100)
        If testL > 11 Then
            tmrTest.Enabled = False
            btnTest.Enabled = True
        End If
    End Sub
#End Region

    ''' <summary>
    ''' Updates the controls with the curent device data.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetControls()
        If Not Loaded Then Return

        'chkRemoveOldNotes.Checked = RemoveOldNotes

        If CurrentMidiInput IsNot Nothing Then
            comInput.SelectedIndex = CurrentMidiInput.DeviceID

            numMidiInputChannel.Value = CurrentMidiInput.Channel + 1

            chkMidiInputChannels.Checked = CurrentMidiInput.AllChannels

            chkMidiInputVolume.Checked = CurrentMidiInput.SetVolumeMax

            chkMidiInputNotes.Checked = CurrentMidiInput.EnableNotes

        End If

        If CurrentMidiOutput IsNot Nothing Then
            comOutput.SelectedIndex = CurrentMidiOutput.DeviceID
            numMidiOutputChannel.Value = CurrentMidiOutput.Channel + 1

        End If


        If Recording Then
            btnSS.Text = "Stop"
            EnableControls(False, , True)
            btnTest.Enabled = True
        Else
            btnSS.Text = "Start"
            EnableControls(True, , True)
            btnTest.Enabled = False
        End If
    End Sub


#Region "Midi Input/Output"
    'Input/Output lists:
    Private Sub lstMidiInput_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMidiInput.SelectedIndexChanged
        If sender.SelectedIndex < 0 Then Return
        CurrentMidiInput = InDevices(lstMidiInput.SelectedIndex)
        SetControls()
    End Sub
    Private Sub lstMidiOutput_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMidiOutput.SelectedIndexChanged
        If sender.SelectedIndex < 0 Then Return
        CurrentMidiOutput = OutDevices(lstMidiOutput.SelectedIndex)
        SetControls()
    End Sub

    'Add buttons:
    Private Sub btnMidiInputAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMidiInputAdd.Click
        AddInputDevice(comInput.SelectedIndex, numMidiInputChannel.Value)
    End Sub
    Private Sub btnMidiOutputAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMidiOutputAdd.Click
        AddOutputDevice(comOutput.SelectedIndex, numMidiOutputChannel.Value)
    End Sub

    'Remove buttons:
    Private Sub btnMidiInputRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMidiInputRemove.Click
        RemoveInputDevice(lstMidiInput.SelectedIndex)
    End Sub
    Private Sub btnMidiOutputRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMidiOutputRemove.Click
        RemoveOutputDevice(lstMidiOutput.SelectedIndex)
    End Sub

    'Set buttons:
    Private Sub btnMidiInputSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMidiInputSet.Click
        UpdateInputDevice(comInput.SelectedIndex)
    End Sub
    Private Sub btnMidiOutputSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMidiOutputSet.Click
        UpdateOutputDevice(comOutput.SelectedIndex)
    End Sub

    Private Sub chkMidiInputNotes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMidiInputNotes.CheckedChanged
        If Not Loaded Or CurrentMidiInput Is Nothing Then Return 'We don't need to change anything here until we are done loading.
        CurrentMidiInput.EnableNotes = sender.Checked
        grpMisc.Enabled = sender.Checked
    End Sub

    Private Sub chkMidiInputChannels_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMidiInputChannels.CheckedChanged
        If Not Loaded Or CurrentMidiInput Is Nothing Then Return
        CurrentMidiInput.AllChannels = chkMidiInputChannels.Checked
        numMidiInputChannel.Enabled = Not chkMidiInputChannels.Checked
    End Sub

    'Channels:
    Private Sub numMidiInputChannel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numMidiInputChannel.ValueChanged
        If Not Loaded Or CurrentMidiInput Is Nothing Then Return 'We don't need to change anything here until we are done loading.
        CurrentMidiInput.Channel = sender.value - 1
        CheckNoteDisable()
    End Sub
    Private Sub numMidiOutputChannel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numMidiOutputChannel.ValueChanged
        If Not Loaded Or CurrentMidiOutput Is Nothing Then Return 'We don't need to change anything here until we are done loading.
        CurrentMidiOutput.Channel = sender.value - 1
        CheckNoteDisable()
    End Sub

    Public Sub CheckNoteDisable() 'Used to disable alter notes and stuff.
        If Not grpMidiOutput.Enabled Or Not Loaded Then Return

        'Is the input and output the same?
        If comInput.SelectedItem = comOutput.SelectedItem Then
            If numMidiInputChannel.Value = numMidiOutputChannel.Value Then
                chkMidiInputNotes.Checked = False

            End If
        End If
    End Sub
#End Region





    
End Class
