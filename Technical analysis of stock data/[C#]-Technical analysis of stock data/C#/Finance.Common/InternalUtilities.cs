using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Finance.Common
{
	public static class InternalUtilities
	{
		public static Boolean CompareArrays<T>(T[] arrA, T[] arrB)
		{
			if (null == arrA)
			{
				throw new ArgumentNullException("arrA");
			}

			if (null == arrB)
			{
				throw new ArgumentNullException("arrB");
			}

			if (arrA.Length != arrB.Length)
			{
				return false;
			}

			for (Int32 q = 0; q < arrA.Length; q++)
			{
				if (!arrA[q].Equals(arrB[q]))
				{
					return false;
				}
			}

			return true;
		}

		public static Boolean CompareArrays<T>(T[] arrA, T[] arrB, Int32 indexA, Int32 indexB, Int32 length)
		{
			if (null == arrA)
			{
				throw new ArgumentNullException("arrA");
			}

			if (null == arrB)
			{
				throw new ArgumentNullException("arrB");
			}

			if (indexA < 0 || indexB < 0 || length <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}

			if (arrA.Length < indexA + length)
			{
				throw new ArgumentOutOfRangeException();
			}

			if (arrB.Length < indexB + length)
			{
				throw new ArgumentOutOfRangeException();
			}

			for (Int32 q = 0; q < length; q++)
			{
				if (!arrA[indexA + q].Equals(arrB[indexB + q]))
				{
					return false;
				}
			}

			return true;
		}

		public static Int32 ApplyLimits(Int32 value, Int32 min, Int32 max)
		{
			if (value < min)
			{
				value = min;
			}

			if (value > max)
			{
				value = max;
			}

			return value;
		}

		public static String ExecPath
		{
			get
			{
				return Assembly.GetEntryAssembly().ManifestModule.FullyQualifiedName;
			}
		}

		public static UInt32 ApplyLimits(UInt32 value, UInt32 min, UInt32 max)
		{
			if (value < min)
			{
				value = min;
			}

			if (value > max)
			{
				value = max;
			}

			return value;
		}
	}

	public static class EmptyArrayTemplate<T>
	{
		private static readonly T[] instance = new T[0];

		public static T[] Instance
		{
			get
			{
				return instance;
			}
		}
	}
}
