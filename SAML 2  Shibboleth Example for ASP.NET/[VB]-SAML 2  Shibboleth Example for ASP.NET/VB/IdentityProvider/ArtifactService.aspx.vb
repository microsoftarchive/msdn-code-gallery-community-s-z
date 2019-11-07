Imports Microsoft.VisualBasic
Imports System
Imports System.Xml
Imports ComponentPro.Saml
Imports ComponentPro.Saml2
Imports ComponentPro.Saml2.Binding

Namespace SamlShibboleth.IdentityProvider
	Partial Public Class ArtifactService
		Inherits System.Web.UI.Page
		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

			Try
				' Create a new Artifact Resolve from the request stream.
				Dim artifactResolve As ArtifactResolve = ArtifactResolve.Create(Request)

				' Get the ArtifactType0004.
				Dim httpArtifact As New Saml2ArtifactType0004(artifactResolve.Artifact.ArtifactValue)

				' Remove the saved http artifact from the cache.
				Dim samlResponseXml As XmlElement = CType(SamlSettings.CacheProvider.Remove(httpArtifact.ToString()), XmlElement)

				If samlResponseXml Is Nothing Then
					Throw New ApplicationException("Invalid artifact.")
				End If

				' Create an ArtifactResponse.
				Dim artifactResponse As New ArtifactResponse()
				Dim uri As New Uri(Request.Url, ResolveUrl("~/"))

				artifactResponse.Issuer = New Issuer(uri.ToString())
				' Add the SAML response XML to the artifact response.
				artifactResponse.Message = samlResponseXml

				' Send the artifact response.
				artifactResponse.Send(Response)

			Catch exception As Exception
				Trace.Write("IdentityProvider", "An Error occurred", exception)
			End Try
		End Sub
	End Class
End Namespace