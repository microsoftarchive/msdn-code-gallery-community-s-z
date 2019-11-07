Imports Microsoft.VisualBasic
Imports System

Namespace SamlShibboleth.ServiceProvider
	Partial Public Class AssertionService
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Dim samlResponse As ComponentPro.Saml2.Response = Nothing
				Dim relayState As String = Nothing

				' Get and process the SAML response.
				Util.ProcessResponse(Me, samlResponse, relayState)

				' If the SAML response indicates success.
				If samlResponse.IsSuccess() Then
					Util.SamlSuccessRedirect(Me, samlResponse, relayState)
				Else
					Util.SamlErrorRedirect(Me, samlResponse)
				End If

			Catch exception As Exception
				Trace.Write("ServiceProvider", "An Error occurred", exception)
			End Try
		End Sub
	End Class
End Namespace