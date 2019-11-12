Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Runtime.InteropServices.ComTypes

Namespace SolidEdge.Assembly.Relations3d
    ''' <summary>
    ''' Solid Edge utility class.
    ''' </summary>
    Friend NotInheritable Class SolidEdgeUtils

        Private Sub New()
        End Sub

        ''' <summary>
        ''' Creates and returns a new instance of Solid Edge.
        ''' </summary>
        ''' <returns>
        ''' An object of type SolidEdgeFramework.Application.
        ''' </returns>
        Public Shared Function Start() As SolidEdgeFramework.Application
            ' On a system where Solid Edge is installed, the COM ProgID will be
            ' defined in registry: HKEY_CLASSES_ROOT\SolidEdge.Application
            Dim t As Type = Type.GetTypeFromProgID(progID:="SolidEdge.Application", throwOnError:=True)

            ' Using the discovered Type, create and return a new instance of Solid Edge.
            Return CType(Activator.CreateInstance(type:=t), SolidEdgeFramework.Application)
        End Function

        ''' <summary>
        ''' Connects to a running instance of Solid Edge.
        ''' </summary>
        ''' <returns>
        ''' An object of type SolidEdgeFramework.Application.
        ''' </returns>
        Public Shared Function Connect() As SolidEdgeFramework.Application
            Return Connect(startIfNotRunning:=False)
        End Function

        ''' <summary>
        ''' Connects to a running instance of Solid Edge with an option to start if not running.
        ''' </summary>
        ''' <returns>
        ''' An object of type SolidEdgeFramework.Application.
        ''' </returns>
        Public Shared Function Connect(ByVal startIfNotRunning As Boolean) As SolidEdgeFramework.Application
            Try
                ' Attempt to connect to a running instance of Solid Edge.
                Return CType(Marshal.GetActiveObject(progID:="SolidEdge.Application"), SolidEdgeFramework.Application)
            Catch ex As System.Runtime.InteropServices.COMException
                Select Case ex.ErrorCode
                    ' Solid Edge is not running.
                    Case NativeMethods.MK_E_UNAVAILABLE
                        If startIfNotRunning Then
                            ' Start Solid Edge.
                            Return Start()
                        Else
                            ' Rethrow exception.
                            Throw
                        End If
                    Case Else
                        ' Rethrow exception.
                        Throw
                End Select
            Catch
                ' Rethrow exception.
                Throw
            End Try
        End Function

        Public Shared Function GetInstallPath() As String
            Dim installData As New SEInstallDataLib.SEInstallData()

            ' Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'.
            Dim programDirectory As New DirectoryInfo(installData.GetInstalledPath())

            ' Get path to Solid Edge installation directory.  Typically, 'C:\Program Files\Solid Edge XXX'.
            Dim installationDirectory As DirectoryInfo = programDirectory.Parent

            Return installationDirectory.FullName
        End Function

        Public Shared Function GetTrainingPath() As String
            Return Path.Combine(GetInstallPath(), "Training")
        End Function

        Public Shared Function GetInteropType(ByVal o As System.Object) As Type
            If o Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If Marshal.IsComObject(o) Then
                Dim dispatch As IDispatch = TryCast(o, IDispatch)
                If dispatch IsNot Nothing Then
                    Dim typeLib As ITypeLib = Nothing
                    Dim typeInfo As ITypeInfo = dispatch.GetTypeInfo(0, 0)
                    Dim index As Integer = 0
                    typeInfo.GetContainingTypeLib(typeLib, index)

                    Dim typeLibName As String = Marshal.GetTypeLibName(typeLib)
                    Dim typeInfoName As String = Marshal.GetTypeInfoName(typeInfo)
                    Dim typeFullName As String = String.Format("{0}.{1}", typeLibName, typeInfoName)

                    Dim assemblies() As System.Reflection.Assembly = AppDomain.CurrentDomain.GetAssemblies()
                    Dim assembly As System.Reflection.Assembly = assemblies.FirstOrDefault(Function(x) x.GetType(typeFullName) IsNot Nothing)

                    If assembly IsNot Nothing Then
                        Return assembly.GetType(typeFullName)
                    End If
                End If
            End If

            Return o.GetType()
        End Function
    End Class
End Namespace
