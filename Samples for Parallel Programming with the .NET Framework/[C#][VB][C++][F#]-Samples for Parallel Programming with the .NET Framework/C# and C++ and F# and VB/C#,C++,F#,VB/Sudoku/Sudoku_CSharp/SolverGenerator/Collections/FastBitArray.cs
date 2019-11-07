//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: FastBitArray.cs
//
//  Description: A simple bit bucket class.
// 
//--------------------------------------------------------------------------

using System;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections
{
	/// <summary>A simple bit bucket.</summary>
	[Serializable]
    public sealed class FastBitArray 
	{
		/// <summary>Maximum length of the array == sizeof(Int32)*8</summary>
		const int MAX_LENGTH = 32;
		/// <summary>The bits.</summary>
		private uint _bits;
		/// <summary>The length, less than or equal to MAX_LENGTH.</summary>
		private int _length;
		/// <summary>The number of set bits in the array.</summary>
		private int _countSet;

		/// <summary>Initializes the array.</summary>
		/// <param name="length">The length of the array, which must be less than or equal to MAX_LENGTH</param>
		public FastBitArray(int length) : this(length, false) {}

		/// <summary>Initializes the array.</summary>
		/// <param name="length">The length of the array, which must be less than or equal to MAX_LENGTH</param>
		/// <param name="defaultValue">The initial value of each element in the array.</param>
		public FastBitArray(int length, bool defaultValue) 
		{
			_length = length;
			SetAll(defaultValue);
		}

		/// <summary>Gets or sets the value at the specified index.</summary>
		public bool this[int index] 
		{
			get { return Get(index); }
			set { Set(index,value); }
		}
    
		/// <summary>Gets the value at the specified index.</summary>
		/// <param name="index">The index at which to retrieve the value.</param>
		/// <returns>The value at the specified index.</returns>
		public bool Get(int index) 
		{
			return (_bits & (1u << index)) != 0;
		}
    
		/// <summary>Sets the value at the specified index.</summary>
		/// <param name="index">The index at which to set the value.</param>
		/// <param name="value">The value to set.</param>
		public void Set(int index, bool value) 
		{
			bool curVal = Get(index);
			if (value && !curVal) 
			{
				_bits |= (1u << index);
				_countSet++;
			}
			else if (!value && curVal)
			{
				_bits &= ~(1u << index);
				_countSet--;
			}
		}
    
		/// <summary>Sets all elements in the array to the specified value.</summary>
		/// <param name="value">The value to set.</param>
		public void SetAll(bool value) 
		{
			if (value)
			{
				_bits = 0xFFFFFFFF;
				_countSet = _length;
			}
			else
			{
				_bits = 0;
				_countSet = 0;
			}
		}
    
		/// <summary>Gets the length of the array.</summary>
		public int Length { get { return _length; } }

		/// <summary>Gets the number of bits set in the array.</summary>
		public int CountSet { get { return _countSet; } }

		/// <summary>Gets an array of the values set in the bit array.</summary>
		/// <returns>An array of the values set.</returns>
		public int [] GetSetBits()
		{
			int count = this.CountSet;
			int [] bits = new int[count];
			int pos = 0;
			for(int i=0; i<this.Length; i++)
			{
				if (this[i]) bits[pos++] = i;
			}
			return bits;
		}
	}
}