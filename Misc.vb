Imports System.Threading

Module Misc
	Public Debug As Boolean = False
	Public Loaded As Boolean = False

	Public Sub Status(ByVal Text As String, Optional ByVal ShowError As Boolean = False)
		frmMain.lblStatus.Text = "Status: " & Text
		If ShowError Then
			MessageBox.Show("#Error#" & vbNewLine & Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If

#If DEBUG Then
		Dim sw As New IO.StreamWriter("debug.txt", True)
		sw.WriteLine("Status: " & Text)
		sw.Close()
		sw.Dispose()
#End If

	End Sub

	'LeftP = LeftPedal(soft)
    'Public LeftP As Boolean = False
    'Public MiddleP As Boolean = False
    'Public RightP As Boolean = False

    'Public SostenutoList As New List(Of Integer)
    'Public SustainList As New List(Of Integer)

    Public Function IsSwitch(ByVal Controller As Integer) As Boolean
        Select Case Controller
            Case 64 'Hold1
                Return True

            Case 65 'Portmento
                Return True

            Case 66 'Sostenuto
                Return True

            Case 67 'Sift
                Return True

            Case 68 'Legato
                Return True

            Case 69 'Hold 2
                Return True

            Case 122 '[Channel Mode Message] Local Control On/Off 
                Return True

        End Select

        Return False
    End Function

#Region "Note holder"
    'Public Note(127) As Integer

    Public Enum Notes
        Released = 0
        Pressed = 1
        Sostenuto = 2
        SustainPressed = 3
        SustainReleased = 4
    End Enum

    'Public Sub ResetNotes()
    '	Parallel.ForEach(Note, Sub(n)
    '							   n = 0
    '							   'For Each n As Byte In Note
    '							   '    n = 0
    '							   'Next
    '						   End Sub)
    'End Sub

    'Public Sub ReleaseNote(ByVal ID As Integer)
    '	Dim tmp As New ChannelMessageBuilder
    '	tmp.Command = Midi.ChannelCommand.NoteOn
    '	tmp.MidiChannel = MidiOutput
    '	tmp.Data1 = ID
    '	tmp.Data2 = 0
    '	Note(ID) = Notes.Released
    '	Send(tmp)
    'End Sub
#End Region

	Public Sub Close()
		frmMain.Close()
	End Sub

	Public Sub Main()

		AddHandler Application.ThreadException, AddressOf UIThreadException


		Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)

		' Add the event handler for handling non-UI thread exceptions to the event. 
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException


		'Delete the old debug file.
		If IO.File.Exists("debug.txt") Then IO.File.Delete("debug.txt")

		Application.Run(frmMain)
	End Sub

#Region "Error handling"
	Private Sub UIThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
		Dim result As DialogResult = DialogResult.Cancel

		Try
			Dim sw As New IO.StreamWriter("debug.txt", True)
			sw.WriteLine(ExceptionToString(e.Exception))
			sw.Close()
			sw.Dispose()

			result = ShowThreadExceptionDialog("Windows Forms Error", e.Exception)

		Catch
			Try
				MessageBox.Show("Fatal Windows Forms Error" & vbNewLine & "There may be more info in your debug file.", _
	 "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
			Finally
				Application.Exit()
			End Try

		End Try

		' Exits the program when the user clicks Abort.
		If result = DialogResult.Abort Then
			Application.Exit()
		End If

	End Sub

	Private Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
		Try
			Dim ex As Exception = CType(e.ExceptionObject, Exception)
			Dim sw As New IO.StreamWriter("debug.txt", True)
			sw.WriteLine(ExceptionToString(ex))
			sw.Close()
			sw.Dispose()

		Catch exc As Exception
			Try
				MessageBox.Show("Fatal Non-UI Error", "Fatal Non-UI Error. Could not write the error to the debug file. " & _
	 "Reason: " & exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Finally
				Application.Exit()
			End Try

		End Try
	End Sub

	Public Function ExceptionToString(ByVal e As Exception) As String
		Dim t As String = "You found a unhandled error!   Pleasereport it to http://code.google.com/p/pedals/issues/   With this file included."
		t &= vbNewLine & "Message: " & e.Message
		t &= vbNewLine & "StackTrace: " & e.StackTrace
		Return t
	End Function

	' Creates the error message and displays it.
	Private Function ShowThreadExceptionDialog(ByVal title As String, ByVal e As Exception) As DialogResult
		Dim errorMsg As String = "An error occurred." & _
		 " error message: " & ControlChars.Lf
		errorMsg = errorMsg & e.Message & vbNewLine & vbNewLine & "More help about this is in your debug.txt file." & vbNewLine & "Note: if you keep getting the same error then end the task with taskmanager (ctrl + shift + esc)"
		Return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
	End Function
#End Region


End Module
