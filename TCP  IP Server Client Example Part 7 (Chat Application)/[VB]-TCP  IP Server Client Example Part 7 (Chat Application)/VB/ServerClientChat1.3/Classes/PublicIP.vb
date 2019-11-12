Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Text
Imports System.Threading.Tasks

Namespace ServerClientChat1._3.Classes
	Friend Class PublicIP

		Public Delegate Sub PublicIPKnownHandler(ByVal PublicIP As String)
		Public Event PublicIPKnown As PublicIPKnownHandler
		Public Delegate Sub PublicIPErrorHandler(ByVal Message As String)
		Public Event PublicIPError As PublicIPErrorHandler

		Private RetryAttempts As Integer = 0

		Public Sub GetPublicIpAddress()

				Dim tGetIP As New Task(Sub() GetPublicIpAddressAsync())
				tGetIP.Start()

		End Sub

		''' <summary>
		''' Contact the ifConfig.Me webservice to get our public IP Address
		''' </summary>
		''' <returns>
		''' String indicating our public IP Address
		''' </returns>
		Private Sub GetPublicIpAddressAsync()
			Try
				Dim request = CType(WebRequest.Create("http://ifconfig.me"), HttpWebRequest)

				request.UserAgent = "curl" ' this simulate curl linux command

				Dim publicIPAddress As String

				request.Method = "GET"
				Using response As WebResponse = request.GetResponse()
					Using reader = New StreamReader(response.GetResponseStream())
						publicIPAddress = reader.ReadToEnd()
					End Using
				End Using

				RaiseEvent PublicIPKnown(publicIPAddress.Replace(vbLf, ""))
			Catch ex As Exception
				If RetryAttempts < 4 Then ' If we just keep calling ourselves without any limit we will get a StackOverFlow Error
					GetPublicIpAddressAsync()
					RetryAttempts += 1
				Else
					RaiseEvent PublicIPError(ex.Message)
				End If
			End Try


		End Sub

	End Class
End Namespace
