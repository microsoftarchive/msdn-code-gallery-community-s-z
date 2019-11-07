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

namespace Microsoft.Samples.DPE.OAuth.ProtectedResource
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IdentityModel.Tokens;
    using System.Linq;

    public class DictionaryBasedKeyIdentifierClause : SecurityKeyIdentifierClause
    {
        private IDictionary<string, string> dictionary;

        public DictionaryBasedKeyIdentifierClause(IDictionary<string, string> dictionary)
            : base(null)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            this.dictionary = dictionary;
        }

        public IDictionary<string, string> Dictionary
        {
            get
            {
                return this.dictionary;
            }
        }

        public override bool Matches(SecurityKeyIdentifierClause keyIdentifierClause)
        {
            DictionaryBasedKeyIdentifierClause objB = keyIdentifierClause as DictionaryBasedKeyIdentifierClause;
            return object.ReferenceEquals(this, objB) || ((objB != null) && objB.Matches(this.dictionary));
        }

        public bool Matches(IDictionary<string, string> dictionary)
        {
            return this.dictionary.Keys.SequenceEqual(dictionary.Keys) &&
                   this.dictionary.Values.SequenceEqual(dictionary.Values);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "DictionaryBasedKeyIdentifierClause(Keys = '{0}', Values ='{1}')", string.Join(",", this.dictionary.Keys.ToArray()), string.Join(",", this.dictionary.Values.ToArray()));
        }        
    }
}
