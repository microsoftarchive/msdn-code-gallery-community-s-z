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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.ACS.Management;

namespace ACS.Management
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // This is the OpenID identifier of the identity provider. 
            // This could be changed to be any OpenID provider.
            //
            const string siteIdentifier = "myopenid.com";
            const string providerName = "MyOpenID";

            Console.WriteLine("Attempting OpenID discovery for identifier '{0}'", siteIdentifier);

            try
            {
                IdentityProviderYadisDocument discoveryDocument = OpenIdDiscovery.DiscoverIdentityProvider(siteIdentifier);

                if (discoveryDocument != null && !string.IsNullOrEmpty(discoveryDocument.OpenIdEndpoint))
                {
                    Console.WriteLine("Successfully discovered OpenID sign-in address: '{0}'.", discoveryDocument.OpenIdEndpoint);
                    Console.WriteLine("Provider supports attribute exchange? {0}", discoveryDocument.SupportsAttributeExchange);

                    //
                    // OpenID discovery was successful. Add the discovered IdentityProvider to ACS.
                    //
                    ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

                    svc.DeleteIdentityProviderIfExists(providerName);
                    svc.SaveChangesBatch();

                    IdentityProvider idp = svc.CreateOpenIdIdentityProvider(providerName, discoveryDocument.OpenIdEndpoint);

                    //
                    // Associate this identity provider with all relying parties.
                    //
                    svc.AssociateIdentityProvidersWithRelyingParties(new[] { idp }, svc.RelyingParties.Where(rp => rp.Name != "AccessControlManagement"));
                    svc.SaveChangesBatch();

                    Console.WriteLine("\nSuccessfully added identity provider '{0}' to ACS.", providerName);

                    Console.WriteLine("Press ENTER to continue....\n");
                    Console.ReadLine();

                    //
                    // Deleting the issuer also causes the identity provider and any associated objects to be deleted.
                    //
                    svc.DeleteObject(idp.Issuer);
                    svc.SaveChanges();

                    Console.WriteLine("\nSuccessfully deleted identity provider.");
                }
                else
                {
                    Console.WriteLine("OpenID discovery failed. Ensure that the identifier is valid.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception was thrown: " + e.ToString());
            }

            Console.WriteLine("Done. Press ENTER to continue....\n");
            Console.ReadLine();
        }
    }
}
