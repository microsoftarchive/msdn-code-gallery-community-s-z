'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: RandomHelper.vb
'
'  Description: Random number utility methods
' 
'--------------------------------------------------------------------------

Imports System.Security.Cryptography

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities
	''' <summary>Random number utilities.</summary>
	Friend NotInheritable Class RandomHelper
		''' <summary>The random number generator.</summary>
		Private Shared _rng As New RNGCryptoServiceProvider()

		''' <summary>Gets a random non-negative integer stricly less than the specified maximum.</summary>
		''' <param name="max">The maximum integer that is strictly greater than the maximum value to be returned.</param>
		''' <returns>The random value.</returns>
		Private Sub New()
		End Sub
		Public Shared Function GetRandomNumber(ByVal max As Integer) As Integer
			Dim data(3) As Byte
			_rng.GetBytes(data) ' thread-safe; no lock necessary
			Return CInt(Fix(BitConverter.ToUInt32(data, 0) Mod max))
		End Function

		''' <summary>Gets a random non-negative integer stricly less than the specified maximum and greater than or equal to the specified minimum.</summary>
		''' <param name="min">The minimum integer that is less than or equal to the value to be returned.</param>
		''' <param name="max">The maximum integer that is strictly greater than the maximum value to be returned.</param>
		Public Shared Function GetRandomNumber(ByVal min As Integer, ByVal max As Integer) As Integer
            Dim range = max - min
			Return GetRandomNumber(range) + min
		End Function
	End Class
End Namespace