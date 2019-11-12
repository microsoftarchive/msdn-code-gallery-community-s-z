Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization
Imports System.Web.Mvc
Imports System.Web.Security

Namespace Saml2IdPInitiatedMvc.Providers
	Public Class CustomMembershipProvider
		Inherits MembershipProvider
		Public Overrides Function ValidateUser(ByVal username As String, ByVal password As String) As Boolean
			' This is where you should validate your user credentials against your database.

			Return (username = "suser" AndAlso password = "password")
		End Function

		Public Overrides Function GetPassword(ByVal username As String, ByVal answer As String) As String
			Throw New NotImplementedException()
		End Function

		Public Overrides Function GetNumberOfUsersOnline() As Integer
			Throw New NotImplementedException()
		End Function

		Public Overrides Function GetAllUsers(ByVal pageIndex As Integer, ByVal pageSize As Integer, <System.Runtime.InteropServices.Out()> ByRef totalRecords As Integer) As MembershipUserCollection
			Throw New NotImplementedException()
		End Function

		Public Overrides Function FindUsersByEmail(ByVal emailToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, <System.Runtime.InteropServices.Out()> ByRef totalRecords As Integer) As MembershipUserCollection
			Throw New NotImplementedException()
		End Function

		Public Overrides Function FindUsersByName(ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, <System.Runtime.InteropServices.Out()> ByRef totalRecords As Integer) As MembershipUserCollection
			Throw New NotImplementedException()
		End Function

		Public Overrides Function ChangePassword(ByVal username As String, ByVal oldPassword As String, ByVal newPassword As String) As Boolean
			Throw New NotImplementedException()
		End Function

		Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Overrides ReadOnly Property PasswordFormat() As MembershipPasswordFormat
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Overrides Property ApplicationName() As String
			Get
				Throw New NotImplementedException()
			End Get
			Set(ByVal value As String)
				Throw New NotImplementedException()
			End Set
		End Property

		Public Overrides Function DeleteUser(ByVal username As String, ByVal deleteAllRelatedData As Boolean) As Boolean
			Throw New NotImplementedException()
		End Function

		Public Overrides Function ChangePasswordQuestionAndAnswer(ByVal username As String, ByVal password As String, ByVal newPasswordQuestion As String, ByVal newPasswordAnswer As String) As Boolean
			Throw New NotImplementedException()
		End Function

		Public Overrides Function GetUserNameByEmail(ByVal email As String) As String
			Throw New NotImplementedException()
		End Function

		Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Overrides Function ResetPassword(ByVal username As String, ByVal answer As String) As String
			Throw New NotImplementedException()
		End Function

		Public Overrides Sub UpdateUser(ByVal user As MembershipUser)
			Throw New NotImplementedException()
		End Sub

		Public Overrides Function UnlockUser(ByVal userName As String) As Boolean
			Throw New NotImplementedException()
		End Function

		Public Overrides Function CreateUser(ByVal username As String, ByVal password As String, ByVal email As String, ByVal passwordQuestion As String, ByVal passwordAnswer As String, ByVal isApproved As Boolean, ByVal providerUserKey As Object, <System.Runtime.InteropServices.Out()> ByRef status As MembershipCreateStatus) As MembershipUser
			Throw New NotImplementedException()
		End Function

		Public Overrides Function GetUser(ByVal username As String, ByVal userIsOnline As Boolean) As MembershipUser
			Throw New NotImplementedException()
		End Function

		Public Overrides Function GetUser(ByVal providerUserKey As Object, ByVal userIsOnline As Boolean) As MembershipUser
			Throw New NotImplementedException()
		End Function

		Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
			Get
				Throw New NotImplementedException()
			End Get
		End Property
	End Class
End Namespace