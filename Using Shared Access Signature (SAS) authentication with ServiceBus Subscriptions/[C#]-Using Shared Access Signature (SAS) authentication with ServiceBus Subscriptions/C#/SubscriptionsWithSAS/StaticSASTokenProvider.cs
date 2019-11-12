//---------------------------------------------------------------------------------
// Microsoft (R)  Windows Azure SDK
// Software Development Kit
// 
// Copyright (c) Microsoft Corporation. All rights reserved.  
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------

namespace Microsoft.Samples.SubscriptionsWithSAS
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IdentityModel.Tokens;
    using System.Threading;
    using System.Web;
    using Microsoft.ServiceBus;

    sealed public class StaticSASTokenProvider : TokenProvider
    {
        readonly string rawToken;
        readonly DateTime expiresIn;

        public StaticSASTokenProvider(string rawToken)
            : base(false, true)
        {
            this.rawToken = rawToken;
            this.expiresIn = ExtractExpiresIn(rawToken);
        }

        protected override IAsyncResult OnBeginGetToken(string appliesTo, string action, TimeSpan timeout, AsyncCallback callback, object state)
        {
            SharedAccessSignatureToken token = new SharedAccessSignatureToken(this.rawToken, this.expiresIn);
            return new CompletedAsyncResult<SharedAccessSignatureToken>(token, callback, state);
        }

        protected override IAsyncResult OnBeginGetWebToken(string appliesTo, string action, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return OnBeginGetToken(appliesTo, action, timeout, callback, state);
        }

        protected override SecurityToken OnEndGetToken(IAsyncResult ar, out DateTime cacheUntil)
        {
            SharedAccessSignatureToken token = CompletedAsyncResult<SharedAccessSignatureToken>.End(ar);
            cacheUntil = token.ValidTo;
            return token;
        }

        protected override string OnEndGetWebToken(IAsyncResult ar, out DateTime cacheUntil)
        {
            SharedAccessSignatureToken token = CompletedAsyncResult<SharedAccessSignatureToken>.End(ar);
            cacheUntil = token.ValidTo;
            return string.Format(CultureInfo.InvariantCulture, "{0} {1}=\"{2}\"", TokenConstants.WrapAuthenticationType, TokenConstants.WrapAuthorizationHeaderKey, token.Token);
        }

        class CompletedAsyncResult<T> : IAsyncResult
        {
            WaitHandle asyncWaitHandle;
            AsyncCallback callback;
            object state;
            T result;

            public CompletedAsyncResult(T result, AsyncCallback callback, object state)
            {
                asyncWaitHandle = new ManualResetEvent(true);
                this.callback = callback;
                this.state = state;
                this.result = result;

                if (this.callback != null)
                {
                    this.callback(this);
                }
            }

            public object AsyncState { get { return this.state; } }

            public WaitHandle AsyncWaitHandle { get { return this.asyncWaitHandle; } }

            public bool CompletedSynchronously { get { return true; } }

            public bool IsCompleted { get { return true; } }

            public static T End(IAsyncResult ar)
            {
                return ((CompletedAsyncResult<T>)ar).result;
            }
        }

        static DateTime ExtractExpiresIn(string sasToken)
        {
            DateTime expiration = DateTime.MinValue;

            if (string.IsNullOrWhiteSpace(sasToken))
            {
                throw new ArgumentException("Null, empty, or whitespace", "simpleWebToken");
            }

            IDictionary<string, string> decodedToken = Decode(sasToken);
            // The signed-expiry parameter in the SAS token is "se"
            string expiresOn = decodedToken["se"];

            if (string.IsNullOrEmpty(expiresOn))
            {
                throw new ArgumentException("Token is missing expiration");
            }

            expiration = new DateTime(1970, 1, 1) + TimeSpan.FromSeconds(double.Parse(HttpUtility.UrlDecode(expiresOn.Trim()), CultureInfo.InvariantCulture));

            return expiration;
        }

        static IDictionary<string, string> Decode(string encodedString)
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(encodedString))
            {
                IEnumerable<string> valueEncodedPairs = encodedString.Split(new char[] { TokenConstants.UrlParameterSeparator }, StringSplitOptions.None);
                foreach (string valueEncodedPair in valueEncodedPairs)
                {
                    string[] pair = valueEncodedPair.Split(new char[] { TokenConstants.KeyValueSeparator }, StringSplitOptions.None);
                    if (pair.Length != 2)
                    {
                        throw new FormatException("Invalid encoding");
                    }

                    dictionary.Add(HttpUtility.UrlDecode(pair[0]), HttpUtility.UrlDecode(pair[1]));
                }
            }

            return dictionary;
        }
    }
}
