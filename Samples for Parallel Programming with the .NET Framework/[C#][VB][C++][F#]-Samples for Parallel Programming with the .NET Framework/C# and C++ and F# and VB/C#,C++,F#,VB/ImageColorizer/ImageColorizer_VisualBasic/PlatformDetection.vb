'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: PlatformDetection.vb
'
'--------------------------------------------------------------------------

Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Security
Imports Microsoft.Ink
Imports Microsoft.StylusInput

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
	''' <summary>
	''' Utility class providing information about Tablet PC libraries and 
	''' functionality that's available for use.
	''' </summary>
	Friend NotInheritable Class PlatformDetection
		''' <summary>Prevent external instantiation.</summary>
		Private Sub New()
		End Sub

		''' <summary>Whether the correct version of the Microsoft.Ink.dll assembly is installed and available.</summary>
		Private Shared _inkAssemblyAvailable As Boolean = (LoadInkAssembly() IsNot Nothing)

		''' <summary>Loads the Microsoft.Ink.dll assembly.</summary>
		''' <returns>The Assembly instance for Microsoft.Ink if it's available; null, otherwise.</returns>
		Private Shared Function LoadInkAssembly() As System.Reflection.Assembly
			Try
				Return LoadInkAssemblyInternal()
			Catch e1 As TypeLoadException
			Catch e2 As IOException
			Catch e3 As SecurityException
			Catch e4 As BadImageFormatException
			End Try
			Return Nothing
		End Function

		''' <summary>Loads the Microsoft.Ink.dll assembly.</summary>
		''' <returns>The Assembly instance for Microsoft.Ink.</returns>
		<MethodImpl(MethodImplOptions.NoInlining)>
		Private Shared Function LoadInkAssemblyInternal() As System.Reflection.Assembly
			Return GetType(InkOverlay).Assembly
		End Function

		''' <summary>Gets whether this platform supports using ink.</summary>
		Public Shared ReadOnly Property SupportsInk() As Boolean
			Get
				Return InkAssemblyAvailable AndAlso RecognizerInstalled
			End Get
		End Property

		''' <summary>Gets whether the correct version of the Microsoft.Ink.dll assembly is installed and available.</summary>
		Public Shared ReadOnly Property InkAssemblyAvailable() As Boolean
			Get
				Return _inkAssemblyAvailable
			End Get
		End Property

		''' <summary>Gets whether a valid recognizer is installed.</summary>
		Public Shared ReadOnly Property RecognizerInstalled() As Boolean
			Get
				If Not _inkAssemblyAvailable Then
					Return False
				End If
				Return GetDefaultRecognizer() IsNot Nothing
			End Get
		End Property

		''' <summary>Gets the best recognizer for the current locale.</summary>
		''' <returns>The best recognizer for the current locale.</returns>
		<MethodImpl(MethodImplOptions.NoInlining)>
		Public Shared Function GetDefaultRecognizer() As Recognizer
			Dim recognizer As Recognizer = Nothing
			Try
				Dim recognizers As New Recognizers()
				If recognizers.Count > 1 Then
                    ' First try the current locale's recognizer.
					Try
						recognizer = recognizers.GetDefaultRecognizer()
					Catch
					End Try

                    ' Fallback to the en-US (1033) recognizer.
					If recognizer Is Nothing Then
						Try
							recognizer = recognizers.GetDefaultRecognizer(1033)
						Catch
						End Try
					End If
				End If
			Catch
			End Try
			Return recognizer
		End Function

		''' <summary>Gets whether a gesture recognizer is installed and available for use.</summary>
		Public Shared ReadOnly Property GestureRecognizerInstalled() As Boolean
			Get
				Return _inkAssemblyAvailable AndAlso GestureRecognizerInstalledInternal
			End Get
		End Property

		''' <summary>Gets whether a gesture recognizer is installed and available for use.</summary>
		''' <remarks>Should only be called if the Microsoft.Ink assembly is already known to be available.</remarks>
		Private Shared ReadOnly Property GestureRecognizerInstalledInternal() As Boolean
			<MethodImpl(MethodImplOptions.NoInlining)>
			Get
				Try
					Dim recognizers As New Recognizers()
					If recognizers.Count > 0 Then
                        Using TempGestureRecognizer = New GestureRecognizer()
                            Return True
                        End Using
					End If
				Catch
				End Try
				Return False
			End Get
		End Property
	End Class
End Namespace