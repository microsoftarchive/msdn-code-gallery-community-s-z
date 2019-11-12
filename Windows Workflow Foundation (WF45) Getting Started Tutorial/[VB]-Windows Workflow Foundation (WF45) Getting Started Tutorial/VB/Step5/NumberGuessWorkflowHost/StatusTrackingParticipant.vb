Imports System.Activities.Tracking
Imports System.IO

Public Class StatusTrackingParticipant
    Inherits TrackingParticipant

    Protected Overrides Sub Track(record As TrackingRecord, timeout As TimeSpan)
        Dim asr As ActivityStateRecord = TryCast(record, ActivityStateRecord)

        If Not asr Is Nothing Then
            If asr.State = ActivityStates.Executing And _
            asr.Activity.TypeName = "System.Activities.Statements.WriteLine" Then

                'Append the WriteLine output to the tracking
                'file for this instance.
                Using writer As StreamWriter = File.AppendText(record.InstanceId.ToString())
                    writer.WriteLine(asr.Arguments("Text"))
                    writer.Close()
                End Using
            End If
        End If
    End Sub
End Class
