#region Copyright © 2005 Noogen Technologies Inc.
// Author:
//	Tommy Noogen (tom@noogen.net)
//
// (C) 2005 Noogen Technologies Inc. (http://www.noogen.net)
// 
// MIT X.11 LICENSE
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
#endregion

using System;

namespace Noogen.Validation
{
	/// <summary>
	/// Operations that can be perform in Compare Validation.
	/// </summary>
	public enum ValidationCompareOperator 
	{
		/// <summary>
		/// Default - Check component DataType.
		/// </summary>
		DataTypeCheck,
		/// <summary>
		/// Compare is equal to ValueToCompare.
		/// </summary>
		Equal,
		/// <summary>
		/// Compare is greater than ValueToCompare.
		/// </summary>
		GreaterThan,
		/// <summary>
		/// Compare greater than or equal to ValueToCompare.
		/// </summary>
		GreaterThanEqual,
		/// <summary>
		/// Compare is less than ValueToCompare.
		/// </summary>
		LessThan,
		/// <summary>
		/// Compare is greater than ValueToCompare.
		/// </summary>
		LessThanEqual,
		/// <summary>
		/// Compare is not equal to ValueToCompare.
		/// </summary>
		NotEqual
	}
}
