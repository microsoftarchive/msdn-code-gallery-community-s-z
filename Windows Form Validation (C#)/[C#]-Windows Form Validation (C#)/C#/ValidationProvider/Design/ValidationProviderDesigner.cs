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
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Noogen.Validation.Design
{
	/// <summary>
	/// ValidationProviderDesigner add verbs for Validation setup on the PropertyGrid.
	/// </summary>
	public class ValidationProviderDesigner : System.ComponentModel.Design.ComponentDesigner
	{
		private IComponentChangeService			_ComponentChangeService = null;
		private IDesignerHost					_DesignerHost			= null;

		/// <summary>
		/// Default Ctor.
		/// </summary>
		public ValidationProviderDesigner()
		{
			this.Verbs.Add(new DesignerVerb("Edit ValidationRules...", new EventHandler(this.EditValidationRulesHandler)));
		}

		/// <summary>
		/// Handle "Edit ValidationRules..." verb event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EditValidationRulesHandler(object sender, EventArgs e)
		{
			this.CustomInitialize();
			ValidationRuleDesignForm vrdf = new ValidationRuleDesignForm(this._DesignerHost, this.Component as ValidationProvider, null);
			vrdf.ShowDialog();

		}

		/// <summary>
		/// Makes sure local variables are valid.
		/// </summary>
		private void CustomInitialize()
		{
			if (this._DesignerHost == null)
				this._DesignerHost = this.GetService(typeof(IDesignerHost)) as IDesignerHost;

			if (this._ComponentChangeService == null)
				this._ComponentChangeService = this._DesignerHost.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
		}
	}
}
