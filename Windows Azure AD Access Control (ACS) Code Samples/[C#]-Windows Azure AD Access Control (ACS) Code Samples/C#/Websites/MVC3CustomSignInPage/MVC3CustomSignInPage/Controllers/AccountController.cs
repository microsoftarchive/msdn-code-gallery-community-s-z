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

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using ASPNETSimpleMVC3.Hrd;
using ASPNETSimpleMVC3.Models;
using Microsoft.IdentityModel.Protocols.WSFederation;
using Microsoft.IdentityModel.Web;

namespace ASPNETSimpleMVC3.Controllers
{
    public class AccountController : Controller
    {
        private HrdClient hrdClient;
   
        public AccountController(HrdClient client)
        {
            hrdClient = client;
        }

        public AccountController():this(new HrdClient())
        {
        }

        //
        // This is the endpoint where the WS-Federation message will be posted. We are disabling the validation
        // here because we are expecting the form to have the xml WS-Federation message in it.
        //
        // POST: /Account/SignIn
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SignIn(FormCollection forms)
        {
            // We use return url as context
            string returnUrl = GetUrlFromContext(forms);

            // If there is a return URL, Redirect to it. Otherwise, Redirect to Home.   
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /Account/SignOut
        [HttpGet]
        public ActionResult SignOut()
        {
            WSFederationAuthenticationModule fam = FederatedAuthentication.WSFederationAuthenticationModule;

            try
            {
                FormsAuthentication.SignOut();
            }
            finally
            {
                fam.SignOut(true); 
            }

            // Return to home after LogOff
            return RedirectToAction("Index", "Home");
        }

        //
        // Shows how to use the client side code to get the identity providers data
        //
        [ChildActionOnly]
        public PartialViewResult IdentityProvidersWithClientSideCode()
        {
            WSFederationAuthenticationModule fam = FederatedAuthentication.WSFederationAuthenticationModule;
            HrdRequest request = new HrdRequest(fam.Issuer, fam.Realm, context: Request.Url.AbsoluteUri);

            return PartialView("_IdentityProvidersWithClientSideCode", request);
        }

        //
        // Shows how to use server side code to get the identity providers data 
        //
        [OutputCache(Duration = 10)]
        [ChildActionOnly]
        public PartialViewResult IdentityProvidersWithServerSideCode()
        {
            WSFederationAuthenticationModule fam = FederatedAuthentication.WSFederationAuthenticationModule;
            HrdRequest request = new HrdRequest(fam.Issuer, fam.Realm, context: Request.Url.AbsoluteUri);

            IEnumerable<HrdIdentityProvider> hrdIdentityProviders = hrdClient.GetHrdResponse(request);

            return PartialView("_IdentityProvidersWithServerSideCode", hrdIdentityProviders);
        }

        /// <summary>
        /// Gets from the form the context
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        private static string GetUrlFromContext(FormCollection form)
        {
            WSFederationMessage message = WSFederationMessage.CreateFromNameValueCollection(new Uri("http://www.notused.com"), form);
            return (message != null ? message.Context : null);
        }
    }
}
