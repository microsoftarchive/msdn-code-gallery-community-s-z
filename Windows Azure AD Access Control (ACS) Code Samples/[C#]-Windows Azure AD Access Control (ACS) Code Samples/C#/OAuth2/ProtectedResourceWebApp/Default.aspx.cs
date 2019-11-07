//---------------------------------------------------------------------------------
// Copyright 2010 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License"); 
// You may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR 
// CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, 
// MERCHANTABLITY OR NON-INFRINGEMENT. 

// See the Apache 2 License for the specific language governing 
// permissions and limitations under the License.
//---------------------------------------------------------------------------------

using System;
using System.Text;
using System.Web;
using Microsoft.IdentityModel.Claims;

namespace ProtectedResourceWebApp
{
    /// <summary>
    /// A simple page. If the user is authenticated, the claims are shown in a text box.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IClaimsPrincipal claimsPrincipal = HttpContext.Current.User as IClaimsPrincipal;
            if (claimsPrincipal != null)
            {
                IClaimsIdentity claimsIdentity = claimsPrincipal.Identity as IClaimsIdentity;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("User is authenticated!");

                foreach (Claim claim in claimsIdentity.Claims)
                {
                    sb.AppendLine(claim.ToString());
                }
                this.TokenTextBox.Text = sb.ToString();
            }
        }
    }
}