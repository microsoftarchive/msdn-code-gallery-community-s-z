Imports System.Configuration
Imports System.Net.Configuration
''' <summary>
''' Responsible for retrieving settings for use when sending Smtp email messages in the app
''' and also in unit test.
''' </summary>
''' <remarks>
''' - variable smtpSection provides the ability to read elements from app.config or web.config
''' - MailConfigurationTest provides a unit test for testing this class.
''' </remarks>
Public Class MailConfiguration
    Private smtpSection As SmtpSection = (TryCast(ConfigurationManager.GetSection("system.net/mailSettings/smtp"), SmtpSection))
    ''' <summary>
    ''' Location of configuration file
    ''' </summary>
    Public ReadOnly Property ConfigurationFileName() As String
        Get
            Try
                Return smtpSection.ElementInformation.Source
            Catch e1 As Exception

                Return ""
            End Try

        End Get
    End Property
    ''' <summary>
    ''' Email address for the system
    ''' </summary>
    Public ReadOnly Property FromAddress() As String
        Get
            Return smtpSection.From
        End Get
    End Property
    ''' <summary>
    ''' Gets the name or IP address of the host used for SMTP transactions.
    ''' </summary>
    Public ReadOnly Property Host() As String
        Get
            Return smtpSection.Network.Host
        End Get
    End Property
    ''' <summary>
    ''' Gets the port used for SMTP transactions
    ''' </summary>
    ''' <remarks>default host is 25</remarks>
    Public ReadOnly Property Port() As Integer
        Get
            Return smtpSection.Network.Port
        End Get
    End Property
    ''' <summary>
    ''' Gets a value that specifies the amount of time after 
    ''' which a synchronous Send call times out.
    ''' </summary>
    Public ReadOnly Property TimeOut() As Integer
        Get
            Return 2000
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return "From: [" & FromAddress & "] Host: [" & Host & "] Port: [" & Port & "]"
    End Function
End Class

