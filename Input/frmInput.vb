Imports System.Windows.Forms

Public Class frmInput

    Public CurrentInput As InputData
    'Axis:
    '0=x
    '1=y
    '2=z
    '3=rX
    '4=rY
    '5=rZ
    '6=s0
    '7=s1

#Region "Dialog buttons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Loaded = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region "Search & Update"

    Public IsSearching As Boolean = False
    Private oldJoy() As Joy0

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        btnFind.Enabled = False
        CurrentInput.SetData(-1, -1)

        Keyboard.Poll()

        Dim i As Integer = -1
        For Each joy As Joystick In Joystick
            i += 1
            oldJoy(i) = New Joy0
            joy.Poll()
            Dim s As JoystickState = joy.GetCurrentState
            oldJoy(i).X = s.X
            oldJoy(i).Y = s.Y
            oldJoy(i).Z = s.Z
            oldJoy(i).rX = s.RotationX
            oldJoy(i).rY = s.RotationY
            oldJoy(i).rZ = s.RotationZ
            oldJoy(i).s0 = s.GetSliders(0)
            oldJoy(i).s1 = s.GetSliders(1)
        Next
        'find = True
        tmr.Enabled = True
        IsSearching = True
    End Sub

    Private OldPos As Integer
    Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        If CurrentInput Is Nothing Then Return

        If CurrentInput.Axis > -1 Then


            If IsSearching Then
                IsSearching = False
                btnFind.Enabled = True
                OK_Button.Enabled = True
                lblAutoName.Text = CurrentInput.GetName(True)
            End If

            Dim pos As Integer = CurrentInput.GetAxisPosition
            If pos = OldPos Then Return
            OldPos = pos

            lblAxis.Text = pos



            'If the controller is a switch then. we will display it as one.
            If CurrentInput.IsControllerSwitch Then
                If pos >= CurrentInput.SwitchOn Then
                    lblSwitch.Text = "Switch On"
                    lblSwitch.BackColor = Color.White
                Else
                    lblSwitch.Text = "Switch Off"
                    lblSwitch.BackColor = Color.Black
                End If
            Else
                lblSwitch.Text = "Position " & pos
                Dim col As Integer = (pos / 127) * 255
                lblSwitch.BackColor = Color.FromArgb(col, col, col)

            End If

            'Me.Focus()
        Else
            IsSearching = True
            Dim i As Integer = -1
            For Each joy As Joystick In Joystick
                i += 1
                joy.Poll()
                Dim s As JoystickState = joy.GetCurrentState
                CurrentInput.ID = i
                If oldJoy(i).X <> s.X Then
                    CurrentInput.Axis = 0
                ElseIf oldJoy(i).Y <> s.Y Then
                    CurrentInput.Axis = 1
                ElseIf oldJoy(i).Z <> s.Z Then
                    CurrentInput.Axis = 2

                ElseIf oldJoy(i).rX <> s.RotationX Then
                    CurrentInput.Axis = 3
                ElseIf oldJoy(i).rY <> s.RotationY Then
                    CurrentInput.Axis = 4
                ElseIf oldJoy(i).rZ <> s.RotationZ Then
                    CurrentInput.Axis = 5

                ElseIf oldJoy(i).s0 <> s.GetSliders(0) Then
                    CurrentInput.Axis = 6
                ElseIf oldJoy(i).s1 <> s.GetSliders(1) Then
                    CurrentInput.Axis = 7
                Else
                    CurrentInput.ID = -1
                End If

            Next

            Keyboard.Poll()
            For Each Key As Integer In Keyboard.GetCurrentState.PressedKeys 'SlimDX.DirectInput.Key

                CurrentInput.Input = InputDevices.Keyboard
                CurrentInput.ID = 0
                CurrentInput.Axis = Key

            Next
        End If

    End Sub

    Private Structure Joy0
        Public X, Y, Z, rX, rY, rZ, s0, s1 As Integer
    End Structure
#End Region

#Region "Load & ShowDialog"
    Public Loaded As Boolean = False
    Private IsFirstLoad As Boolean = True
    Private Sub frmInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsFirstLoad Then
            comController.Items.AddRange([Enum].GetNames(GetType(Midi.ControllerType)))
            comController.SelectedItem = Midi.ControllerType.HoldPedal1.ToString

            comControllerType.Items.AddRange([Enum].GetNames(GetType(InputStuff.InputControllerType)))
            comControllerType.SelectedItem = InputControllerType.MIDI.ToString
            IsFirstLoad = False
        End If



        ReDim oldJoy(Joystick.Count - 1)

        If CurrentInput.ID > -1 Then tmr.Enabled = True
        Loaded = True

        chkRev.Checked = CurrentInput.Reverse

        txtName.Text = CurrentInput._Name
        chkAutoName.Checked = CurrentInput.AutoName

        numSwitchOn.Value = CurrentInput.SwitchOn
        chkSwitch.Checked = CurrentInput.IsControllerSwitch

        comController.SelectedItem = DirectCast(CurrentInput.Controller, Midi.ControllerType).ToString
        comControllerType.SelectedItem = DirectCast(CurrentInput.ControllerType, InputControllerType).ToString

        lblAutoName.Text = CurrentInput.GetName(True)
    End Sub

    Public Overloads Function ShowDialog(ByVal Index As Integer) As DialogResult
        CurrentInput = Input(Index)
        OK_Button.Enabled = True
        Return MyBase.ShowDialog()
    End Function
    Public Overloads Function ShowDialog(ByRef Input As InputData) As DialogResult
        If Input Is Nothing Then
            Input = New InputData(-1, -1)
        Else
            OK_Button.Enabled = True
        End If
        CurrentInput = Input

        Return MyBase.ShowDialog()
    End Function

#End Region

#Region "Control changed"
    Private Sub chkRev_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRev.CheckedChanged
        CurrentInput.Reverse = chkRev.Checked
    End Sub

    Private Sub numSwitchOn_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numSwitchOn.ValueChanged
        If CurrentInput Is Nothing Then Return
        CurrentInput.SwitchOn = numSwitchOn.Value
    End Sub

    Private Sub comControllerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comControllerType.SelectedIndexChanged
        If comControllerType.SelectedItem = InputControllerType.MIDI.ToString Then
            comController.Enabled = True
            chkSwitch.Enabled = True
        Else
            comController.Enabled = False
            chkSwitch.Checked = True
            chkSwitch.Enabled = False
        End If

        If Not Loaded Then Return
        CurrentInput.ControllerType = [Enum].Parse(GetType(InputControllerType), comControllerType.SelectedItem.ToString)

    End Sub

    Private Sub comController_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comController.SelectedIndexChanged
        If Not Loaded Then Return
        CurrentInput.Controller = [Enum].Parse(GetType(Midi.ControllerType), comController.SelectedItem.ToString)
        chkSwitch.Checked = IsSwitch(CurrentInput.Controller)
    End Sub

    Private Sub chkAutoName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoName.CheckedChanged
        If Not Loaded Then Return
        CurrentInput.AutoName = chkAutoName.Checked
        txtName.Enabled = Not chkAutoName.Checked
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        If Not Loaded Then Return
        CurrentInput._Name = txtName.Text
    End Sub

    Private Sub chkSwitch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSwitch.CheckedChanged
        If Not Loaded Then Return
        CurrentInput.IsControllerSwitch = chkSwitch.Checked
    End Sub
#End Region

End Class
