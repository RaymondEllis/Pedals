Imports System.Windows.Forms

Public Class frmInput

    Public IsSearching As Boolean = False

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'If CurrentInput.ID = -1 Then
        '    CurrentInput = Nothing
        'Else
        '    CurrentInput.ControllerType = [Enum].Parse(GetType(ControllerType0), comControllerType.SelectedItem.ToString)
        '    CurrentInput.Controller = [Enum].Parse(GetType(Midi.ControllerType), comController.SelectedItem.ToString)
        '    CurrentInput.IsControllerSwitch = IsSwitch(CurrentInput.Controller)
        'End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private oldJoy() As Joy0

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        btnFind.Enabled = False
        CurrentInput.SetData(-1, -1)

        Dim i As Integer = -1
        For Each joy As Joystick In Joystick
            i += 1
            oldJoy(i) = New Joy0
            'joy.Acquire()
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


    Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        If CurrentInput Is Nothing Then Return

        If CurrentInput.Axis > -1 Then
            IsSearching = False
            OK_Button.Enabled = True
            btnFind.Enabled = True
            Dim pos As Integer = CurrentInput.GetAxisPosition
            lblAxis.Text = pos
            CurrentInput.DoInput()

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
        End If

    End Sub

    Private Sub frmInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'For Each joy As Joystick In Joystick
        '    joy.Poll()
        'Next

        ReDim oldJoy(Joystick.Count - 1)

        'If CurrentInput IsNot Nothing Then
        tmr.Enabled = True

        chkRev.Checked = CurrentInput.Reverse

        txtName.Text = CurrentInput._Name
        chkAutoName.Checked = CurrentInput.AutoName

        numSwitchOn.Value = CurrentInput.SwitchOn
        chkSwitch.Checked = CurrentInput.IsControllerSwitch

        comController.SelectedItem = DirectCast(CurrentInput.Controller, Midi.ControllerType).ToString
        comControllerType.SelectedItem = DirectCast(CurrentInput.ControllerType, ControllerType0).ToString
        'End If


    End Sub

    Public Overloads Function ShowDialog(ByVal Index As Integer) As DialogResult
        CurrentInput = Input(Index)
        Return MyBase.ShowDialog()
    End Function
    Public Overloads Function ShowDialog(ByRef Input As InputData) As DialogResult
        If Input Is Nothing Then
            Input = New InputData(-1, -1)
        End If
        CurrentInput = Input

        Return MyBase.ShowDialog()
    End Function

    Private Sub chkRev_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRev.CheckedChanged
        CurrentInput.Reverse = chkRev.Checked
    End Sub

    Private Sub numSwitchOn_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numSwitchOn.ValueChanged
        CurrentInput.SwitchOn = numSwitchOn.Value
    End Sub

    Private Structure Joy0
        Public X, Y, Z, rX, rY, rZ, s0, s1 As Integer
    End Structure


    Private Sub comControllerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comControllerType.SelectedIndexChanged
        If Not Loaded Then Return
        CurrentInput.ControllerType = [Enum].Parse(GetType(ControllerType0), comControllerType.SelectedItem.ToString)
        If comControllerType.SelectedItem = ControllerType0.MIDI.ToString Then
            comController.Enabled = True
            chkSwitch.Enabled = True
        Else
            comController.Enabled = False
            chkSwitch.Checked = True
            chkSwitch.Enabled = False
        End If
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
End Class
