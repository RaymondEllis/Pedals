Imports System.Windows.Forms

Public Class frmInput

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


	Private oldJoy(Joystick.Count - 1) As joyO

	'Private find As Boolean = False
	Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
		CurrentAxis = -1
		CurrentJoystick = -1

		Dim i As Integer = -1
		For Each joy As Joystick In Joystick
			i += 1
			oldJoy(i) = New joyO
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

	Public CurrentJoystick As Integer = -1
	Public CurrentAxis As Integer = -1
	'0=x
	'1=y
	'2=z
	'3=rX
	'4=rY
	'5=rZ
	'6=s0
	'7=s1

	Private Class joyO
		Public X, Y, Z, rX, rY, rZ, s0, s1 As Integer
	End Class

	Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
		If CurrentAxis > -1 Then
			OK_Button.Enabled = True

			Joystick(CurrentJoystick).Poll()
			Dim s As JoystickState = Joystick(CurrentJoystick).GetCurrentState
			Select Case CurrentAxis
				Case 0
					lblAxis.Text = s.X
				Case 1
					lblAxis.Text = s.Y
				Case 2
					lblAxis.Text = s.Z

				Case 3
					lblAxis.Text = s.RotationX
				Case 4
					lblAxis.Text = s.RotationY
				Case 5
					lblAxis.Text = s.RotationZ

				Case 6
					lblAxis.Text = s.GetSliders(0)
				Case 7
					lblAxis.Text = s.GetSliders(1)


			End Select

		Else
			Dim i As Integer = -1
			For Each joy As Joystick In Joystick
				i += 1
				joy.Poll()
				Dim s As JoystickState = joy.GetCurrentState
				If oldJoy(i).X <> s.X Then
					CurrentJoystick = i
					CurrentAxis = 0
				ElseIf oldJoy(i).Y <> s.Y Then
					CurrentJoystick = i
					CurrentAxis = 1
				ElseIf oldJoy(i).Z <> s.Z Then
					CurrentJoystick = i
					CurrentAxis = 2

				ElseIf oldJoy(i).rX <> s.RotationX Then
					CurrentJoystick = i
					CurrentAxis = 3
				ElseIf oldJoy(i).rY <> s.RotationY Then
					CurrentJoystick = i
					CurrentAxis = 4
				ElseIf oldJoy(i).rZ <> s.RotationZ Then
					CurrentJoystick = i
					CurrentAxis = 5

				ElseIf oldJoy(i).s0 <> s.GetSliders(0) Then
					CurrentJoystick = i
					CurrentAxis = 6
				ElseIf oldJoy(i).s1 <> s.GetSliders(1) Then
					CurrentJoystick = i
					CurrentAxis = 7
				End If

			Next
		End If

	End Sub

	Private Sub frmInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		For Each joy As Joystick In Joystick
			'joy.Acquire()
			joy.Poll()
		Next
	End Sub

	Private Sub frmInput_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
		'tmr.Enabled = True
	End Sub
End Class
