Module Input
	Public Joystick As New List(Of Joystick)
	Private dInput As DirectInput

	Public Sub CreateInput()
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
		Else
			For Each joy As Joystick In Joystick
				joy.Acquire()

				For Each deviceObject As DeviceObjectInstance In joy.GetObjects()
					If (deviceObject.ObjectType And ObjectDeviceType.Axis) <> 0 Then
						joy.GetObjectPropertiesById(CInt(deviceObject.ObjectType)).SetRange(0, 127)
					End If
				Next
			Next
		End If


	End Sub

	Public Function GetAxis(ByVal JoysitckID As Integer, ByVal Axis As Integer) As Integer

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

	Public Sub DistroyInput()
		For Each joy As Joystick In Joystick
			joy.Unacquire()
			joy.Dispose()
		Next


		dInput.Dispose()
	End Sub

End Module
