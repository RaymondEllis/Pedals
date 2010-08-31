Imports System.Windows.Forms

Public Class frmInput

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		If CurrentJoystick.ID = -1 Then
            CurrentJoystick = Nothing
        Else
            CurrentJoystick.ControllerType = [Enum].Parse(GetType(ControllerType0), comControllerType.SelectedItem.ToString)
            CurrentJoystick.Controller = [Enum].Parse(GetType(Midi.ControllerType), comController.SelectedItem.ToString)
            CurrentJoystick.IsControllerSwitch = IsSwitch(CurrentJoystick.Controller)
        End If
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


	Private oldJoy() As Joy0

	'Private find As Boolean = False
	Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
		btnFind.Enabled = False
        CurrentJoystick.SetData(-1, -1)

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
	End Sub

	'Public CurrentJoystick As Integer = -1
	'Public CurrentJoystick.Axis As Integer = -1
	Public CurrentJoystick As  InputData
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
		If CurrentJoystick Is Nothing Then Return

		If CurrentJoystick.Axis > -1 Then
			OK_Button.Enabled = True
			btnFind.Enabled = True
            Dim pos As Integer = CurrentJoystick.GetAxisPosition
            lblAxis.Text = pos
            CurrentJoystick.DoInput()
            If pos >= CurrentJoystick.SwitchOn Then
                lblSwitch.Text = "Switch On"
                lblSwitch.BackColor = Color.White
            Else
                lblSwitch.Text = "Switch Off"
                lblSwitch.BackColor = Color.Silver
            End If

		Else
			Dim i As Integer = -1
			For Each joy As Joystick In Joystick
				i += 1
				joy.Poll()
                Dim s As JoystickState = joy.GetCurrentState
                CurrentJoystick.ID = i
				If oldJoy(i).X <> s.X Then
					CurrentJoystick.Axis = 0
				ElseIf oldJoy(i).Y <> s.Y Then
					CurrentJoystick.Axis = 1
				ElseIf oldJoy(i).Z <> s.Z Then
					CurrentJoystick.Axis = 2

				ElseIf oldJoy(i).rX <> s.RotationX Then
					CurrentJoystick.Axis = 3
				ElseIf oldJoy(i).rY <> s.RotationY Then
					CurrentJoystick.Axis = 4
				ElseIf oldJoy(i).rZ <> s.RotationZ Then
					CurrentJoystick.Axis = 5

				ElseIf oldJoy(i).s0 <> s.GetSliders(0) Then
					CurrentJoystick.Axis = 6
				ElseIf oldJoy(i).s1 <> s.GetSliders(1) Then
                    CurrentJoystick.Axis = 7
                Else
                    CurrentJoystick.ID = -1
                End If

			Next
		End If

	End Sub

    Private Sub frmInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        For Each joy As Joystick In Joystick
            'joy.Acquire()
            joy.Poll()
        Next

        ReDim oldJoy(Joystick.Count - 1)
        'For n As Integer = 0 To oldJoy.Length - 1
        '	oldJoy(n) = New Joy0
        'Next

        If CurrentJoystick IsNot Nothing Then
            tmr.Enabled = True
        Else
            numSwitchOn.Value = CurrentJoystick.SwitchOn
            comControllerType.SelectedIndex = CurrentJoystick.ControllerType
            comController.SelectedIndex = CurrentJoystick.Controller
            chkRev.Checked = CurrentJoystick.Reverse
        End If


    End Sub

    Public Overloads Function ShowDialog(ByRef Input As InputData) As DialogResult
        If Input Is Nothing Then
            Input = New InputData(-1, -1)
        End If
        CurrentJoystick = Input
        chkRev.Checked = CurrentJoystick.Reverse
        numSwitchOn.Value = CurrentJoystick.SwitchOn
        txtName.Text = CurrentJoystick._Name
        chkAutoName.Checked = CurrentJoystick.AutoName

        Return MyBase.ShowDialog()
    End Function

	Private Sub frmInput_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
		'tmr.Enabled = True
	End Sub

	Private Sub chkRev_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRev.CheckedChanged
		CurrentJoystick.Reverse = chkRev.Checked
	End Sub

	Private Sub numSwitchOn_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numSwitchOn.ValueChanged
		CurrentJoystick.SwitchOn = numSwitchOn.Value
	End Sub

	Private Structure Joy0
		Public X, Y, Z, rX, rY, rZ, s0, s1 As Integer
	End Structure

	'Private Class joyO
	'	Public X, Y, Z, rX, rY, rZ, s0, s1 As Integer
	'End Class

    Private Sub radMIDI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' If radMIDI.Checked Then
        comController.Items.AddRange([Enum].GetNames(GetType(Midi.ControllerType)))
        'Else
        comController.Items.AddRange([Enum].GetNames(GetType(Midi.ControllerType)))
        'End If
    End Sub

    Private Sub comControllerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comControllerType.SelectedIndexChanged
        If Not Loaded Then Return
        CurrentJoystick.ControllerType = [Enum].Parse(GetType(ControllerType0), comControllerType.SelectedItem.ToString)
        If comControllerType.SelectedItem = ControllerType0.MIDI.ToString Then
            comController.Enabled = True
        Else
            comController.Enabled = False
        End If
    End Sub

    Private Sub comController_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comController.SelectedIndexChanged
        If Not Loaded Then Return
        CurrentJoystick.Controller = [Enum].Parse(GetType(Midi.ControllerType), comController.SelectedItem.ToString)
        CurrentJoystick.IsControllerSwitch = IsSwitch(CurrentJoystick.Controller)
    End Sub

    Private Sub chkAutoName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoName.CheckedChanged
        If Not Loaded Then Return
        CurrentJoystick.AutoName = chkAutoName.Checked
        txtName.Enabled = Not chkAutoName.Checked
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        If Not Loaded Then Return
        CurrentJoystick._Name = txtName.Text
    End Sub
End Class
