Module Misc
	Public Debug As Boolean = False

	Public Sub Status(ByVal Text As String, Optional ByVal ShowError As Boolean = False)
		frmMain.lblStatus.Text = "Status: " & Text
		If ShowError Then
			MessageBox.Show("#Error#" & vbNewLine & Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	'LeftP = LeftPedal(soft)
	Public LeftP As Boolean = False
	Public MiddleP As Boolean = False
	Public RightP As Boolean = False

	Public SostenutoList As New List(Of Integer)
	Public SustainList As New List(Of Integer)

#Region "Note holder"
	Public Note(127) As Integer

	Public Enum Notes
		Released = 0
		Pressed = 1
		Sostenuto = 2
		SustainPressed = 3
		SustainReleased = 4
	End Enum

	Public Sub ResetNotes()
		Parallel.ForEach(Note, Sub(n)
								   n = 0
								   'For Each n As Byte In Note
								   '    n = 0
								   'Next
							   End Sub)
	End Sub

	Public Sub ReleaseNote(ByVal ID As Integer)
		Dim tmp As New ChannelMessageBuilder
		tmp.Command = Midi.ChannelCommand.NoteOn
		tmp.MidiChannel = MidiOutput
		tmp.Data1 = ID
		tmp.Data2 = 0
		Note(ID) = Notes.Released
		Send(tmp)
	End Sub
#End Region
End Module
