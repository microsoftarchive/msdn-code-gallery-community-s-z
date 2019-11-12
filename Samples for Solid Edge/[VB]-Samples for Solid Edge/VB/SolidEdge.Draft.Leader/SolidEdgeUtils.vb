Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Draft.Leader
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
			Dim t As Type = Type.GetTypeFromProgID(progID:= "SolidEdge.Application", throwOnError:= True)

			' Using the discovered Type, create and return a new instance of Solid Edge.
			Return CType(Activator.CreateInstance(type:= t), SolidEdgeFramework.Application)
		End Function

		''' <summary>
		''' Connects to a running instance of Solid Edge.
		''' </summary>
		''' <returns>
		''' An object of type SolidEdgeFramework.Application.
		''' </returns>
		Public Shared Function Connect() As SolidEdgeFramework.Application
			Return Connect(startIfNotRunning:= False)
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
				Return CType(Marshal.GetActiveObject(progID:= "SolidEdge.Application"), SolidEdgeFramework.Application)
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
	End Class
End Namespace
