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
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Reflection;
using System.ComponentModel.Design;

namespace Noogen.Validation
{
	/// <summary>
	/// Provider validation properties to controls that can be validated.
	/// </summary>
	[ProvideProperty("ValidationRule", typeof(Control))]
	[Designer(typeof(Noogen.Validation.Design.ValidationProviderDesigner))]
	[ToolboxBitmap(typeof(Noogen.Validation.ValidationProvider), "Validation.ico")]
	public class ValidationProvider : System.ComponentModel.Component, IExtenderProvider
	{
		private Hashtable					_ValidationRules		= new Hashtable();
		private ValidationRule				_DefaultValidationRule	= new ValidationRule();
		private ErrorProvider				_ErrorProvider			= new ErrorProvider();

		#region "public Validation Methods"
		/// <summary>
		/// Perform validation on all controls.
		/// </summary>
		/// <returns>False if any control contains invalid data.</returns>
		public bool Validate()
		{
			bool bIsValid = true;
			ValidationRule vr = null;
			foreach(Control ctrl in _ValidationRules.Keys)
			{
				this.Validate(ctrl);

				vr = this.GetValidationRule(ctrl);
				if (vr != null && vr.IsValid == false) bIsValid = false;
			}
			return bIsValid;
		}

		/// <summary>
		/// Get validation error messages.
		/// </summary>
		public string ValidationMessages(bool showErrorIcon)
		{
			StringBuilder sb = new StringBuilder();
			ValidationRule vr = null;
			foreach(Control ctrl in _ValidationRules.Keys)
			{
				vr = this.GetValidationRule(ctrl);
				if (vr != null) 
				{
					if (vr.IsValid == false) 
					{
						vr.ResultErrorMessage += vr.ErrorMessage.Replace("%ControlName%", ctrl.Name);
						sb.Append(vr.ResultErrorMessage);
						sb.Append(Environment.NewLine);
					}
					if (showErrorIcon)
						this._ErrorProvider.SetError(ctrl, vr.ResultErrorMessage);
					else
						this._ErrorProvider.SetError(ctrl, null);
				}
			}
			return sb.ToString();
		}
		#endregion

		#region "private helper methods"
		/// <summary>
		/// Perform validation on specific control.
		/// </summary>
		/// <param name="ctrl"></param>
		/// <returns></returns>
		private bool Validate(Control ctrl)
		{
			ValidationRule vr = this.GetValidationRule(ctrl);

			if (vr != null) 
			{
				vr.ResultErrorMessage = string.Empty;
				vr.IsValid = true;
			}

			if (vr == null || vr.IsValid)
				vr = this.DataTypeValidate(ctrl);

			if (vr == null || vr.IsValid)
				vr = this.CompareValidate(ctrl);

			if (vr == null || vr.IsValid)
				vr = this.CustomValidate(ctrl);

			if (vr == null || vr.IsValid)
				vr = this.RangeValidate(ctrl);

			if (vr == null || vr.IsValid)
				vr = this.RegularExpressionValidate(ctrl);

			if (vr == null || vr.IsValid)
				vr = this.RequiredFieldValidate(ctrl);

			return (vr == null) ? true : vr.IsValid;
		}

		/// <summary>
		/// Validate Data Type.
		/// </summary>
		/// <param name="ctrl"></param>
		/// <returns></returns>
		private ValidationRule DataTypeValidate(Control ctrl)
		{
			ValidationRule vr = this._ValidationRules[ctrl] as ValidationRule;

			if (vr != null && vr.Operator.Equals(ValidationCompareOperator.DataTypeCheck))
			{
				if (vr.DataType.Equals(this._DefaultValidationRule.DataType)) return vr;

				System.Web.UI.WebControls.ValidationDataType vdt = 
					(System.Web.UI.WebControls.ValidationDataType)Enum.Parse(
					typeof(System.Web.UI.WebControls.ValidationDataType), 
					vr.DataType.ToString());

				vr.IsValid = ValidationUtil.CanConvert(ctrl.Text, vdt);
			}

			return vr;
		}

		/// <summary>
		/// Perform CompareValidate on a specific control.
		/// </summary>
		/// <param name="ctrl"></param>
		/// <returns>true if control has no validation rule.</returns>
		private ValidationRule CompareValidate(Control ctrl)
		{
			ValidationRule vr = _ValidationRules[ctrl] as ValidationRule;

			if (vr != null)
			{
				if (this._DefaultValidationRule.ValueToCompare.Equals(vr.ValueToCompare)
					&& this._DefaultValidationRule.Operator.Equals(vr.Operator)) return vr;

				vr.IsValid = ValidationRule.Compare(ctrl.Text, vr.ValueToCompare, vr.Operator, vr);
			}
			
			return vr;
		}

		/// <summary>
		/// Perform Custom Validation on specific control.
		/// </summary>
		/// <param name="ctrl"></param>
		/// <returns></returns>
		private ValidationRule CustomValidate(Control ctrl)
		{
			ValidationRule vr = _ValidationRules[ctrl] as ValidationRule;

			if (vr != null)
			{
				CustomValidationEventArgs e = new CustomValidationEventArgs(ctrl.Text, vr);
				vr.OnCustomValidationMethod(e);
			}
			return vr;
		}


		/// <summary>
		/// Perform Range Validation on specific control.
		/// </summary>
		/// <param name="ctrl"></param>
		/// <returns></returns>
		private ValidationRule RangeValidate(Control ctrl)
		{
			ValidationRule vr = _ValidationRules[ctrl] as ValidationRule;

			if (vr != null)
			{
				if (this.IsDefaultRange(vr)) return vr;

				vr.IsValid = ValidationRule.Compare(ctrl.Text, vr.MinimumValue, ValidationCompareOperator.GreaterThanEqual, vr);

				if (vr.IsValid)
					vr.IsValid = ValidationRule.Compare(ctrl.Text, vr.MaximumValue, ValidationCompareOperator.LessThanEqual, vr);
			}
			return vr;
		}

		/// <summary>
		/// Check if validation rule range is default.
		/// </summary>
		/// <param name="vr"></param>
		/// <returns></returns>
		private bool IsDefaultRange(ValidationRule vr)
		{
			return (this._DefaultValidationRule.MinimumValue.Equals(vr.MinimumValue)
				&& this._DefaultValidationRule.MaximumValue.Equals(vr.MaximumValue));
			
		}

		/// <summary>
		/// Perform Regular Expression Validation on a specific control.
		/// </summary>
		/// <param name="ctrl"></param>
		/// <returns></returns>
		private ValidationRule RegularExpressionValidate(Control ctrl)
		{
			ValidationRule vr = _ValidationRules[ctrl] as ValidationRule;

			if (vr != null)
			{
				try
				{
					if (this._DefaultValidationRule.RegExPattern.Equals(vr.RegExPattern)) return vr;

					vr.IsValid = ValidationUtil.ValidateRegEx(ctrl.Text, vr.RegExPattern);
				}
				catch(Exception ex)
				{
					vr.ResultErrorMessage = "RegEx Validation Exception: " + ex.Message + Environment.NewLine;
					vr.IsValid = false;
				}
			}
			return vr;
		}

		/// <summary>
		/// Perform RequiredField Validation on a specific control.
		/// </summary>
		/// <param name="ctrl"></param>
		/// <returns></returns>
		private ValidationRule RequiredFieldValidate(Control ctrl)
		{
			ValidationRule vr = _ValidationRules[ctrl] as ValidationRule;

			if (vr != null && vr.IsRequired) 
			{
				ValidationRule vr2 = new ValidationRule();
				vr.IsValid = !ValidationRule.Compare(ctrl.Text, vr.InitialValue, ValidationCompareOperator.Equal, vr);
			}

			return vr;
		}
		#endregion

		#region "Properties"
		/// <summary>
		/// Set validation rule.
		/// </summary>
		/// <param name="inputComponent"></param>
		/// <param name="vr"></param>
		public void SetValidationRule(object inputComponent, ValidationRule vr)
		{
			if (inputComponent != null)
			{
				// only throw error in DesignMode
				if (base.DesignMode) 
				{
					if (!this.CanExtend(inputComponent))
						throw new InvalidOperationException(inputComponent.GetType().ToString() 
							+ " is not supported by the validation provider.");

					if (!this.IsDefaultRange(vr) 
						&& ValidationRule.Compare(vr.MinimumValue, vr.MaximumValue, ValidationCompareOperator.GreaterThanEqual, vr))
						throw new ArgumentException("MinimumValue must not be greater than or equal to MaximumValue.");
				}

				ValidationRule vrOld = this._ValidationRules[inputComponent] as ValidationRule;

				// if new rule is valid and in not DesignMode, clone rule
				if ((vr != null) && !base.DesignMode)
				{
					vr = vr.Clone() as ValidationRule;
				} 
				
				
				if (vr == null)	// if new is null, no more validation
				{
					this._ValidationRules.Remove(inputComponent);
				}
				else if (vrOld == null)
				{
					this._ValidationRules.Add(inputComponent, vr);
				}
				else if ((vr != null) && (vrOld != null))
				{
					this._ValidationRules[inputComponent] = vr;
				}

			}
		}

		/// <summary>
		/// Get validation rule.
		/// </summary>
		/// <param name="inputComponent"></param>
		/// <returns></returns>
		[DefaultValue(null), Category("Data")]
		[Editor(typeof(Noogen.Validation.Design.ValidationRuleEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public ValidationRule GetValidationRule(object inputComponent)
		{
			return (this._ValidationRules[inputComponent] as ValidationRule);
		}
		#endregion

		#region "ErrorProvider properties delegation"
		/// <summary>
		/// Icon display when validation failed.
		/// </summary>
		[Category("Appearance"), Description("Icon display when validation failed."), Localizable(true)]
		public Icon Icon
		{
			get { return this._ErrorProvider.Icon; }
			set { this._ErrorProvider.Icon = value; }
		}

		/// <summary>
		/// BlinkRate of ErrorIcon.
		/// </summary>
		[RefreshProperties(RefreshProperties.Repaint), Description("BlinkRate of ErrorIcon."), Category("Behavior"), DefaultValue(250)]
		public int BlinkRate
		{
			get { return this._ErrorProvider.BlinkRate;}
			set { this._ErrorProvider.BlinkRate = value; }
		}

		/// <summary>
		/// Get or set Blink Behavior.
		/// </summary>
		[DefaultValue(0), Category("Behavior"), Description("Blink Behavior.")]
		public ErrorBlinkStyle BlinkStyle
		{
			get { return this._ErrorProvider.BlinkStyle; }
			set { this._ErrorProvider.BlinkStyle = value; }
		}
 
		/// <summary>
		/// Get Error Icon alignment.
		/// </summary>
		/// <param name="control"></param>
		/// <returns></returns>
		[DefaultValue(3), Category("Appearance"), Localizable(true), Description("Get Error Icon alignment.")]
		public ErrorIconAlignment GetIconAlignment(Control control)
		{
			return this._ErrorProvider.GetIconAlignment(control);
		}
 
		/// <summary>
		/// Get Error Icon padding.
		/// </summary>
		/// <param name="control"></param>
		/// <returns></returns>
		[Description("Get Error Icon padding."), DefaultValue(0), Localizable(true), Category("Appearance")]
		public int GetIconPadding(Control control)
		{
			return this._ErrorProvider.GetIconPadding(control);
		}
 
		/// <summary>
		/// Set Error Icon alignment.
		/// </summary>
		/// <param name="control"></param>
		/// <param name="value"></param>
		public void SetIconAlignment(Control control, ErrorIconAlignment value)
		{
			this._ErrorProvider.SetIconAlignment(control, value);
		}
 
		/// <summary>
		/// Set Error Icon padding.
		/// </summary>
		/// <param name="control"></param>
		/// <param name="padding"></param>
		public void SetIconPadding(Control control, int padding)
		{
			this._ErrorProvider.SetIconPadding(control, padding);
		}
		#endregion

		#region "Component Construction"
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Designer Ctor.
		/// </summary>
		/// <param name="container"></param>
		public ValidationProvider(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		/// <summary>
		/// Default Ctor.
		/// </summary>
		public ValidationProvider()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region IExtenderProvider Members

		/// <summary>
		/// Determine if ValidationProvider support a component.
		/// </summary>
		/// <param name="extendee"></param>
		/// <returns></returns>
		public bool CanExtend(object extendee)
		{
			if ((extendee is TextBox) 
				|| (extendee is ComboBox)) return true;

			return false;
		}

		#endregion
	}
}
