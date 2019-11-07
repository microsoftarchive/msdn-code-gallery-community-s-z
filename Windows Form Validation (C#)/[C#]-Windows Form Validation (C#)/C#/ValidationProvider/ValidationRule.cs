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
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Noogen.Validation
{
	/// <summary>
	/// ValidationRule is designed to be a simple as possible to
	/// reduce overhead in run-time.  It's because each validation
	/// rule can be attach to a control, so we can have a many
	/// instances of this class.
	/// </summary>
	[TypeConverter(typeof(Noogen.Validation.Design.ValidationRuleConverter))]
	public class ValidationRule : ICloneable
	{
		#region "Basic Settings"
		internal string				ResultErrorMessage	= string.Empty;

		private string				_ErrorMessage		= "%ControlName% is invalid.";
		private string				_InitialValue		= string.Empty;
		private ValidationDataType  _DataType			= ValidationDataType.String;
		private bool				_IsValid			= true;
		private bool				_IsRequired			= false;
		private bool				_IsCaseSensitive	= true;

		/// <summary>
		/// Set validation case sensitivity.
		/// </summary>
		[DefaultValue(true), Category("Basic Settings")]
		[Description("Case sensitivity validation works best with String DataType.")]
		public bool IsCaseSensitive
		{
			get { return _IsCaseSensitive; }
			set { _IsCaseSensitive = value; }
		}

		/// <summary>
		/// Data Type of the validation.
		/// </summary>
		[DefaultValue(ValidationDataType.String), Category("Basic Settings")]
		[Description("DataType of control value.")]
		public ValidationDataType DataType
		{
			get { return _DataType; }
			set { _DataType = value; }
		}

		/// <summary>
		/// ErrorMessage result of validation.
		/// </summary>
		[DefaultValue("%ControlName% is invalid."), Category("Basic Settings")]
		[Description("Message to display/return iwhen validation failed.")]
		public string ErrorMessage
		{
			get { return _ErrorMessage; }
			set { _ErrorMessage = (value == null) ? string.Empty : value; }
		}

		/// <summary>
		/// Get validity of control value after Validate method is called.
		/// </summary>
		[DefaultValue(true), Browsable(false)]
		public bool IsValid
		{
			get { return _IsValid; }
			set { _IsValid = value; }
		}

		/// <summary>
		/// A mandatory value does not necessarily mean a value other than "". 
		/// In some cases, a default control value might be used as a prompt 
		/// e.g. using "[Choose a value]" in a DropDownList control. In this case, 
		/// the required value must be different than the initial value of 
		/// "[Choose a value]". InitialValue supports this requirement. The 
		/// default is "".
		/// </summary>
		[DefaultValue(""), Category("Basic Settings")]
		[Description("Initial value doesn't necessarily be empty string.  It might be like [Choose a value] as in a a DropDown list.")]
		public string InitialValue
		{
			get { return _InitialValue; }
			set { _InitialValue = (value == null) ? string.Empty : value; }
		}

		/// <summary>
		/// Cause validation to check if field is required.
		/// </summary>
		[DefaultValue(false), Category("Basic Settings")]
		[Description("Make it so control require a value.  Validate to false if control value matches InitialValue.")]
		public bool IsRequired
		{
			get { return _IsRequired; }
			set { _IsRequired = value; }
		}
		#endregion

		#region "Compare Validation Settings"
		private ValidationCompareOperator		_Operator			= ValidationCompareOperator.DataTypeCheck;
		private string							_ValueToCompare		= string.Empty;
		
		/// <summary>
		/// Get or set operator to use to compare.
		/// </summary>
		[DefaultValue(ValidationCompareOperator.DataTypeCheck), Category("Compare Validation")]
		[Description("Type of comparison to perform with ValueToCompare.  Default is data type checking if DataType is not String.")]
		public ValidationCompareOperator Operator
		{
			get { return _Operator; }
			set { _Operator = value; }
		}

		/// <summary>
		/// Get or set value use to compare with the control value.
		/// </summary>
		[DefaultValue(""), Category("Compare Validation")]
		[Description("This is use in combination with Operator.")]
		public string ValueToCompare
		{
			get { return _ValueToCompare; }
			set { _ValueToCompare = (value == null) ? string.Empty : value; }
		}
		#endregion

		#region "Range Validation Settings"
		private string				_MinimumValue = string.Empty;
		private string				_MaximumValue = string.Empty;

		/// <summary>
		/// RangeValidator Minimum Value.
		/// </summary>
		[DefaultValue(""), Category("Range Validation")]
		[Description("Highest value the control can have.  Remember to set DataType when range is not of type String.")]
		public string MinimumValue 
		{
			get { return _MinimumValue; }
			set 
			{
				_MinimumValue = (value == null) ? string.Empty : value; 
			}
		}

		/// <summary>
		/// RangeValidator MaximumValue Value.
		/// </summary>
		[DefaultValue(""), Category("Range Validation")]
		[Description("Lowest value the control can have.  Remember to set DataType when range is not of type String.")]
		public string MaximumValue
		{
			get { return _MaximumValue; }
			set 
			{
				_MaximumValue = (value == null) ? string.Empty : value; 
			}
		}
		#endregion

		#region "Regular Expression Validation Settings"
		private string		_RegExPattern	= string.Empty;

		/// <summary>
		/// Regular Expression Pattern to use for validation.
		/// </summary>
		[DefaultValue(""), Category("Regular Expression Validation")]
		[Description("Regular Expression Pattern to use for validation.  See accompanied regular expression bank...")]
		public string RegExPattern
		{
			get { return _RegExPattern; }
			set { _RegExPattern = (value == null) ? string.Empty : value; }
		}
		#endregion
		
		/// <summary>
		/// Allow for attachment of custom validation method.
		/// </summary>
		public event CustomValidationEventHandler CustomValidationMethod;

		/// <summary>
		/// Delegate invoking of validation method.
		/// </summary>
		/// <param name="e"></param>
		internal protected virtual void OnCustomValidationMethod(CustomValidationEventArgs e)
		{
			if (this.CustomValidationMethod != null)
				this.CustomValidationMethod(this, e);
		}

		/// <summary>
		/// Compare two values.
		/// </summary>
		/// <param name="leftText"></param>
		/// <param name="rightText"></param>
		/// <param name="op"></param>
		/// <param name="vr"></param>
		/// <returns></returns>
		public static bool Compare(	string leftText, 
									string rightText, 
									ValidationCompareOperator op, 
									ValidationRule vr)
		{
			if (false == vr.IsCaseSensitive && vr.DataType == ValidationDataType.String)
			{
				leftText = leftText.ToLower();
				rightText = rightText.ToLower();
			}
			return ValidationUtil.CompareValues(leftText, rightText, op, vr.DataType);
		}

		#region ICloneable Members

		/// <summary>
		/// ValidationRule is memberwised cloneable.
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			return this.MemberwiseClone();
		}

		#endregion
	}
}
