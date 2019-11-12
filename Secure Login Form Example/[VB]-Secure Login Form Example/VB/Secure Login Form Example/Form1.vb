Option Strict On

Imports System.IO

Public Class Form1

#Region "Functions"

    Private Function StringtoMD5(ByVal Content As String) As String
        Dim M5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim ByteString() As Byte = System.Text.Encoding.ASCII.GetBytes(Content)
        ByteString = M5.ComputeHash(ByteString)
        Dim FinalString As String = Nothing
        For Each bt As Byte In ByteString
            FinalString &= bt.ToString("x2")
        Next
        Return FinalString.ToUpper()
    End Function

    ' Declares user and pass as Strings
    Private Function CreateUser(ByVal user As String, ByVal pass As String) As String
        ' Check to see if the MD5 hash value of user exsists as a text file
        If File.Exists(StringtoMD5(user) & ".txt") = False Then
            Try
                ' Writes the MD5 hashed values of user and pass to a file named <user>.txt
                My.Computer.FileSystem.WriteAllText(StringtoMD5(user) & ".txt", StringtoMD5(user) & Chr(32) & StringtoMD5(pass), False)

                File.SetAttributes(StringtoMD5(user) & ".txt", FileAttributes.Hidden)

                ' If it works, then we show a nice message
                MessageBox.Show("Successfully created user!")
            Catch ex As Exception
                ' If it fails to write, then we show an error message
                MessageBox.Show("Opps! Something went wrong! " & ex.Message)
            End Try
        Else
            ' If the username has already been selected
            MessageBox.Show("Username has already been selected!")
        End If

        ' Return values
        Return user
        Return pass
    End Function

#End Region

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            ' Check to see if the MD5 hashed values of UsernameTextBox and PasswordTextBox
            ' are equal to the hashed values inside the file.
            ' We find the file by using IO.File.ReadAllText to find the MD5 hashed named file of <user>.txt
            ' In a real situation, you would replace the IO.File.ReadAllText with a connection to your database, server, or website.
            If StringtoMD5(UsernameTextBox.Text) & Chr(32) & StringtoMD5(PasswordTextBox.Text) = IO.File.ReadAllText(StringtoMD5(UsernameTextBox.Text) & ".txt") Then
                ' If it works, then we can let the user login
                ' In this area, you can give a message to the database, server, or website to allow the user to connect.
                MessageBox.Show("You have entered the correct username and password!")
            Else
                ' If the credentials don't match, then they did something incorrect.
                MessageBox.Show("You have entered an incorrect username or password.")
            End If
        Catch ex As Exception
            ' If they were never registered or something else bizarrly happens, then this error message will show them what's wrong.
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        CreateUser(UsernameTextBox.Text, PasswordTextBox.Text)
    End Sub

End Class