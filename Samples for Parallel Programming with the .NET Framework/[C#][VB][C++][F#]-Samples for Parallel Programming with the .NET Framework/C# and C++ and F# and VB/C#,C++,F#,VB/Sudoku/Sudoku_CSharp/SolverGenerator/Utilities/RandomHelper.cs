//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: RandomHelper.cs
//
//  Description: Random number utility methods
// 
//--------------------------------------------------------------------------

using System;
using System.Security.Cryptography;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities
{
	/// <summary>Random number utilities.</summary>
	internal static class RandomHelper
	{
		/// <summary>The random number generator.</summary>
		private static RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();

		/// <summary>Gets a random non-negative integer stricly less than the specified maximum.</summary>
		/// <param name="max">The maximum integer that is strictly greater than the maximum value to be returned.</param>
		/// <returns>The random value.</returns>
		public static int GetRandomNumber(int max)
		{
			byte [] data = new byte[4];
			_rng.GetBytes(data); // thread-safe; no lock necessary
			return (int)(BitConverter.ToUInt32(data, 0) % max);
		}

		/// <summary>Gets a random non-negative integer stricly less than the specified maximum and greater than or equal to the specified minimum.</summary>
		/// <param name="min">The minimum integer that is less than or equal to the value to be returned.</param>
		/// <param name="max">The maximum integer that is strictly greater than the maximum value to be returned.</param>
		public static int GetRandomNumber(int min, int max)
		{
			int range = max - min;
			return GetRandomNumber(range) + min;
		}
	}
}