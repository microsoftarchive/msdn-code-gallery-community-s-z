Imports Microsoft.VisualBasic
Imports System
Imports System.Xml
Imports ComponentPro.Saml
Imports ComponentPro.Saml2
Imports ComponentPro.Saml2.Binding

Namespace SamlShibboleth.ServiceProvider
	Partial Public Class ArtifactService
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Try
				' Get the artifact resolve request.
				Dim artifactResolve As ArtifactResolve = ArtifactResolve.Create(Request)

				' Create a new artifact.
				Dim httpArtifact As New Saml2ArtifactType0004(artifactResolve.Artifact.ArtifactValue)

				' Remove the artifact state from the cache.
				Dim samlResponseXml As XmlElement = CType(SamlSettings.CacheProvider.Remove(httpArtifact.ToString()), XmlElement)
				If samlResponseXml Is Nothing Then
					Throw New ApplicationException("Invalid artifact.")
				End If

				' Create an artifact response containing the cached SAML message.
				Dim artifactResponse As New ArtifactResponse()
				artifactResponse.Issuer = New Issuer(Util.GetAbsoluteUrl(Me, "~/"))
				artifactResponse.Message = samlResponseXml

				' Send the artifact response.
				artifactResponse.Send(Response)

			Catch exception As Exception
				Trace.Write("ServiceProvider", "An Error occurred", exception)
			End Try
		End Sub
	End Class
End Namespace