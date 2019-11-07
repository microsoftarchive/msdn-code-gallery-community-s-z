Imports Microsoft.VisualBasic
Imports System
Imports ComponentPro.Saml2

Namespace SamlShibboleth.IdentityProvider
	''' <summary>
	''' Represents the state saved during a local login.
	''' </summary>
	Public Class SsoAuthnState
		Private authnRequest_Renamed As AuthnRequest
		Private state_Renamed As String

		Public Property AuthnRequest() As AuthnRequest
			Get
				Return authnRequest_Renamed
			End Get
			Set(ByVal value As AuthnRequest)
				authnRequest_Renamed = value
			End Set
		End Property

		Public Property State() As String
			Get
				Return state_Renamed
			End Get
			Set(ByVal value As String)
				state_Renamed = value
			End Set
		End Property
	End Class
End Namespace