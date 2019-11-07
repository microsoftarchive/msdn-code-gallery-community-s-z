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
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace OAuth2Common
{
    /// <summary>
    /// A utility class to convert between dictionaries and query strings or JSON.
    /// </summary>
    public static class DictionaryExtension
    {
        public static void Decode(this IDictionary<string, string> self, string encodedDictionary)
        {
            if (encodedDictionary == null) throw new ArgumentNullException("encodedDictionary");

            foreach (string nameValue in encodedDictionary.Split('&'))
            {
                string[] keyValueArray = nameValue.Split('=');

                if ((keyValueArray.Length == 1 || keyValueArray.Length > 2)
                    && !String.IsNullOrEmpty(keyValueArray[0]))
                {
                    throw new ArgumentException("The request is not properly formatted.", "encodedDictionary");
                }

                if (keyValueArray.Length != 2)
                {
                    throw new ArgumentException("The request is not properly formatted.", "encodedDictionary");
                }

                string key = HttpUtility.UrlDecode(keyValueArray[0].Trim());
                string value = HttpUtility.UrlDecode(keyValueArray[1].Trim().Trim('"'));

                self.Add(key, value);
            }
        }

        public static string Encode(this IDictionary<string, string> self)
        {
            StringBuilder result = new StringBuilder();

            foreach (KeyValuePair<string, string> keyValue in self)
            {
                if (result.Length != 0)
                    result.Append('&');

                result.AppendFormat("{0}={1}", HttpUtility.UrlEncode(keyValue.Key), HttpUtility.UrlEncode(keyValue.Value));
            }

            return result.ToString();
        }

        public static string EncodeToJson(this IDictionary<string, string> self)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(self);
        }

        public static void DecodeFromJson(this IDictionary<string, string> self, string encodedDictionary)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            Dictionary<string, object> decodedDictionary = serializer.DeserializeObject(encodedDictionary) as Dictionary<string, object>;

            if (decodedDictionary == null)
            {
                throw new ArgumentException("Invalid request format.", "encodedDictionary");
            }

            foreach (KeyValuePair<string, object> keyValue in decodedDictionary)
            {
                self.Add(keyValue.Key, keyValue.Value as string);
            }
        }
    }
}
