Module InputStuff
    Public Input As New List(Of InputData)

    Public Joystick As New List(Of Joystick)
    Public Keyboard As Keyboard
    Public dInput As DirectInput
    Public EnableJoysticks As Boolean = False

    Public Enum InputDevices
        Joystick
        Keyboard
        MIDI
    End Enum
    Public Enum InputControllerType
        MIDI
        AlterSustain
        AlterSostenuto
        AlterSoft
    End Enum

#Region "Create & Distroy"
    Public Sub CreateInput()

        Status("Searching for joysticks...")
        'Create direct input
        dInput = New DirectInput

        'Search for the joysticks.
        For Each Device As DeviceInstance In dInput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly)

            'Try to create the device.
            Try
                Dim joy As New Joystick(dInput, Device.InstanceGuid)
                joy.SetCooperativeLevel(frmMain, CooperativeLevel.Exclusive + CooperativeLevel.Background)
                Joystick.Add(joy)
            Catch ex As Exception
                Status(ex.Message, True)
            End Try
        Next
        If Joystick.Count = 0 Then
            Status("No attached joysticks.")
            EnableJoysticks = False
        Else
            For Each joy As Joystick In Joystick
                joy.Acquire()

                For Each deviceObject As DeviceObjectInstance In joy.GetObjects()
                    If (deviceObject.ObjectType And ObjectDeviceType.Axis) <> 0 Then
                        joy.GetObjectPropertiesById(CInt(deviceObject.ObjectType)).SetRange(0, 127)
                    End If
                Next
            Next
            EnableJoysticks = True
            Status("Found #" & Joystick.Count & " joysticks.")
        End If



        Status("Creating DirectInput keyboard.")
        Keyboard = New Keyboard(dInput)
        Keyboard.Acquire()
        Keyboard.Poll()
        Status("Created keyboard.")




    End Sub

    Public Sub DistroyInput()

        Status("Distroying joystick input...")
        Try
            If Joystick.Count > 0 Then
                For Each j As Joystick In Joystick
                    If j IsNot Nothing Then
                        j.Unacquire()
                        j.Dispose()
                    End If
                Next
            End If

            Keyboard.Unacquire()
            Keyboard.Dispose()

            If dInput IsNot Nothing Then
                dInput.Dispose()
            End If
        Catch ex As Exception
            MsgBox("Could not dispose input.")
        End Try
        Status("Distroying joystick input... Done!")
    End Sub
#End Region

#Region "Add & Remove"
    Public Sub AddInput(ByVal Inp As InputData)

        'Add the input to the lists.
        Input.Add(Inp)
        frmMain.lstInput.Items.Add(Inp)

        'Enable the input buttons.
        frmMain.btnInputRemove.Enabled = True
        frmMain.btnInputEdit.Enabled = True

        frmMain.lstInput.SelectedIndex = frmMain.lstInput.Items.Count - 1
    End Sub
    Public Sub RemoveInput(ByVal Index As Integer)
        frmMain.lstInput.Items.RemoveAt(Index)
        Input.RemoveAt(Index)

        If Input.Count = 0 Then
            frmMain.btnInputRemove.Enabled = False
            frmMain.btnInputEdit.Enabled = True
        Else
            'For n As Integer = Index To Input.Count - 1
            '    Input(n).index = Index
            'Next

            frmMain.lstInput.SelectedIndex = Index - 1
        End If
    End Sub
#End Region

#Region "DoInput & GetAxis"
    Public Sub DoInput()
        'Do the input in the list.
        For Each inp As InputData In Input
            inp.DoInput()
        Next
    End Sub

    Public Function GetAxis(ByVal JoysitckID As Integer, ByVal Axis As Integer) As Integer
        ' If Not EnableJoysticks Then Return 0

        Dim State As JoystickState = Joystick(JoysitckID).GetCurrentState
        Select Case Axis
            Case 0
                Return State.X
            Case 1
                Return State.Y
            Case 2
                Return State.Z

            Case 3
                Return State.RotationX
            Case 4
                Return State.RotationY
            Case 5
                Return State.RotationZ

            Case 6
                Return State.GetSliders(0)
            Case 7
                Return State.GetSliders(1)
        End Select

        Return 0
    End Function
#End Region


End Module


Public Class InputData
    Public Position, OldPosition As Integer
    Public Pressed, Changed As Boolean

    Public AutoName As Boolean = True
    Friend _Name As String

    'Input:
    Public Input As Integer = InputDevices.Joystick
    Public ID As Integer = -1
    Public Axis As Integer = -1
    Public Reverse As Boolean = True
    ''' <summary>
    ''' If an axis is less then or equals to SwitchOn then turn the switch on.
    ''' </summary>
    Public SwitchOn As Integer


    'Output:
    Public Controller, ControllerType As Integer
    Public IsControllerSwitch As Boolean = True

    

#Region "New & SetData"
    Public Sub New()
    End Sub
    Public Sub New(ByVal ID As Integer, ByVal Axis As Integer, Optional ByVal Reverse As Boolean = True, Optional ByVal SwitchOn As Integer = 127)
        Me.ID = ID
        Me.Axis = Axis
        Me.Reverse = Reverse
        Me.SwitchOn = SwitchOn
    End Sub

    Public Sub SetData(ByVal ID As Integer, ByVal Axis As Integer, Optional ByVal Reverse As Boolean = True, Optional ByVal SwitchOn As Integer = 127)
        Me.ID = ID
        Me.Axis = Axis
        Me.Reverse = Reverse
        Me.SwitchOn = SwitchOn
    End Sub

#End Region

#Region "Functions"

    Public Function DoInput() As Boolean
        If Not EnableJoysticks Or Not Recording Then Return False
        If ID = -1 Then Return False
        Position = GetAxisPosition()

        'Is the current position the same as the old postion?
        If Position = OldPosition Then Return False 'If so then we need to leave.
        OldPosition = Position

        If Position >= SwitchOn Then
            If Not Pressed Then
                Pressed = True
                Changed = True
            Else
                Changed = False
            End If
        Else
            If Pressed Then
                Pressed = False
                Changed = True
            Else
                Changed = False
            End If
        End If



        'What should we control?
        Select Case ControllerType
            Case InputControllerType.MIDI

                Dim m As New ChannelMessageBuilder
                m.Command = ChannelCommand.Controller
                m.Data1 = Controller
                If IsControllerSwitch And Changed Then
                    If Pressed Then
                        m.Data2 = 127
                    Else
                        m.Data2 = 0
                    End If
                    Send(m)
                ElseIf Not IsControllerSwitch Then
                    m.Data2 = Position
                    Send(m)
                End If

            Case InputControllerType.AlterSustain
                If Changed Then
                    If Pressed Then
                        PressSustain()
                    Else
                        ReleaseSustain()
                    End If
                End If
                SustainPressed = Pressed

            Case InputControllerType.AlterSostenuto
                If Changed Then
                    If Pressed Then
                        PressSostenuto()
                    Else
                        ReleaseSostenuto()
                    End If
                End If
                SostenutoPressed = Pressed

            Case InputControllerType.AlterSoft
                SoftPressed = Pressed

        End Select

        Return True
    End Function


    Public Function GetAxisPosition() As Integer
        Dim pos As Integer = 0

        Select Case Input
            Case InputDevices.Joystick
                pos = GetAxis(ID, Axis)

            Case InputDevices.MIDI
                pos = InDevices(ID).Controllers(Axis)

            Case InputDevices.Keyboard
                If Keyboard.GetCurrentState.IsPressed(Axis) Then
                    pos = 127
                Else
                    pos = 0
                End If

        End Select



        If Reverse Then
            Return (-pos) + 127
        Else
            Return pos
        End If
    End Function

    Public Overrides Function ToString() As String
        Return GetName()
    End Function

    Public Shadows Function GetName(Optional ByVal UseAutoName As Boolean = False) As String
        If AutoName Or UseAutoName Then
            Select Case Input
                Case InputDevices.Joystick
                    Return "Joystick#" & ID & "  Axis:" & Axis

                Case InputDevices.MIDI
                    Return "MIDI#" & ID & "  Controller:" & Axis

                Case InputDevices.Keyboard
                    Return "Keyboard" & "  Key:" & [Enum].Parse(GetType(SlimDX.DirectInput.Key), Axis).ToString

            End Select

        End If
        Return _Name
    End Function

#End Region

End Class
