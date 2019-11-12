// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace Microsoft.Samples.DPE.OAuth.Tokens
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.IdentityModel.Tokens;

    public class SimpleWebToken : SecurityToken
    {
        private static readonly TimeSpan DefaultValidity = new TimeSpan(1, 0, 0);

        private string id;
        private NameValueCollection parameters;
        private DateTime timestamp;
        
        public SimpleWebToken(string issuer)            
        {
            this.Issuer = issuer;
            this.timestamp = DateTime.UtcNow;
            this.id = Guid.NewGuid().ToString().Remove(8);
            this.parameters = new NameValueCollection();
            this.TokenValidity = DefaultValidity;
        }               

        public override string Id
        {
            get { return this.id; }            
        }
                
        public override ReadOnlyCollection<SecurityKey> SecurityKeys
        {
            get { return EmptyReadOnlyCollection<SecurityKey>.Instance; }
        }

        public override DateTime ValidFrom
        {
            get 
            { 
                // TODO: Implement
                return DateTime.MinValue;
            }
        }

        public override DateTime ValidTo
        {
            get { return this.timestamp + this.TokenValidity; }
        }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public byte[] Signature { get; set; }

        public string SignatureAlgorithm { get; set; }

        public string RawToken { get; set; }

        public TimeSpan TokenValidity { get; set; }

        public NameValueCollection Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        public void SetId(string id)
        {
            this.id = id;
        }

        public void AddClaim(string name, string value)
        {
            this.parameters.Add(name, value);
        }
    }

    internal static class EmptyReadOnlyCollection<T>
    {
        public static ReadOnlyCollection<T> Instance 
        {
            get
            {
                return new ReadOnlyCollection<T>(new List<T>());
            }
        }
    }
}