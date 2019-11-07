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
	/// Delegate for custom validation methods.
	/// </summary>
	public delegate	void CustomValidationEventHandler(object sender, CustomValidationEventArgs e);

	/// <summary>
	/// Arguments of validation event.
	/// </summary>
	public class CustomValidationEventArgs : EventArgs
	{
		private object			_Value = null;
		private ValidationRule	_ValidationRule = null;

		/// <summary>
		/// Default Ctor.
		/// </summary>
		/// <param name="Value"></param>
		/// <param name="vr"></param>
		public CustomValidationEventArgs(object Value, ValidationRule vr)
		{
			this._Value = Value;
			this._ValidationRule = vr;
		}

		/// <summary>
		/// Value to validate.
		/// </summary>
		public object Value
		{
			get { return _Value; }
		}

		/// <summary>
		/// Get or set validity of attached validation rule.
		/// </summary>
		public bool IsValid
		{
			get { return this._ValidationRule.IsValid; }
			set { this._ValidationRule.IsValid = value; }
		}

		/// <summary>
		/// Get or set error message to display when validation fail.
		/// </summary>
		public string ErrorMessage
		{
			get { return this._ValidationRule.ErrorMessage; }
			set { this._ValidationRule.ErrorMessage = value; }
		}

		/// <summary>
		/// Allow custom validation class to set IsValid and ErrorMessage
		/// value.
		/// </summary>
		public ValidationRule ValidationRule
		{
			get { return this._ValidationRule;}
		}
	}
}
