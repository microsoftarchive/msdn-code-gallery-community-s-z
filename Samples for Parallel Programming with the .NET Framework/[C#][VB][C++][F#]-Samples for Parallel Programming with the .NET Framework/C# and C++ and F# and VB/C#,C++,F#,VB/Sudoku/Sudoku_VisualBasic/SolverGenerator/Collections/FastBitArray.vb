'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: FastBitArray.vb
'
'  Description: A simple bit bucket class.
' 
'--------------------------------------------------------------------------


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections
	''' <summary>A simple bit bucket.</summary>
	<Serializable>
	Public NotInheritable Class FastBitArray
		''' <summary>Maximum length of the array == sizeof(Int32)*8</summary>
		Private Const MAX_LENGTH As Integer = 32
		''' <summary>The bits.</summary>
		Private _bits As UInteger
		''' <summary>The length, less than or equal to MAX_LENGTH.</summary>
		Private _length As Integer
		''' <summary>The number of set bits in the array.</summary>
		Private _countSet As Integer

		''' <summary>Initializes the array.</summary>
		''' <param name="length">The length of the array, which must be less than or equal to MAX_LENGTH</param>
		Public Sub New(ByVal length As Integer)
			Me.New(length, False)
		End Sub

		''' <summary>Initializes the array.</summary>
		''' <param name="length">The length of the array, which must be less than or equal to MAX_LENGTH</param>
		''' <param name="defaultValue">The initial value of each element in the array.</param>
		Public Sub New(ByVal length As Integer, ByVal defaultValue As Boolean)
			_length = length
			SetAll(defaultValue)
		End Sub

		''' <summary>Gets or sets the value at the specified index.</summary>
		Default Public Property Item(ByVal index As Integer) As Boolean
			Get
				Return [Get](index)
			End Get
			Set(ByVal value As Boolean)
				[Set](index,value)
			End Set
		End Property

		''' <summary>Gets the value at the specified index.</summary>
		''' <param name="index">The index at which to retrieve the value.</param>
		''' <returns>The value at the specified index.</returns>
		Public Function [Get](ByVal index As Integer) As Boolean
			Return (_bits And (1UI << index)) <> 0
		End Function

		''' <summary>Sets the value at the specified index.</summary>
		''' <param name="index">The index at which to set the value.</param>
		''' <param name="value">The value to set.</param>
		Public Sub [Set](ByVal index As Integer, ByVal value As Boolean)
            Dim curVal = [Get](index)
			If value AndAlso (Not curVal) Then
				_bits = _bits Or (1UI << index)
				_countSet += 1
			ElseIf (Not value) AndAlso curVal Then
				_bits = _bits And Not(1UI << index)
				_countSet -= 1
			End If
		End Sub

		''' <summary>Sets all elements in the array to the specified value.</summary>
		''' <param name="value">The value to set.</param>
		Public Sub SetAll(ByVal value As Boolean)
			If value Then
				_bits = &HFFFFFFFFL
				_countSet = _length
			Else
				_bits = 0
				_countSet = 0
			End If
		End Sub

		''' <summary>Gets the length of the array.</summary>
		Public ReadOnly Property Length() As Integer
			Get
				Return _length
			End Get
		End Property

		''' <summary>Gets the number of bits set in the array.</summary>
		Public ReadOnly Property CountSet() As Integer
			Get
				Return _countSet
			End Get
		End Property

		''' <summary>Gets an array of the values set in the bit array.</summary>
		''' <returns>An array of the values set.</returns>
		Public Function GetSetBits() As Integer()
            Dim count = Me.CountSet
			Dim bits(count - 1) As Integer
            Dim pos = 0
            For i = 0 To Me.Length - 1
                If Me(i) Then
                    bits(pos) = i
                    pos += 1
                End If
            Next i
			Return bits
		End Function
	End Class
End Namespace