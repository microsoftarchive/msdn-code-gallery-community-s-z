using Microsoft.IdentityModel.S2S.Protocols.OAuth2;
using System;
using System.Globalization;
using System.IO;
using System.Net;

namespace SPAPI_SAMPLE_CODE.Authentication {
    public static class TokenHelper {

        /// <summary>
        /// SharePoint principal.
        /// </summary>
        public const string SharePointPrincipal = "00000003-0000-0ff1-ce00-000000000000";

        /// <summary>
        /// Gets the application only access token.
        /// </summary>
        /// <param name="targetPrincipalName">Name of the target principal.</param>
        /// <param name="targetHost">The target host.</param>
        /// <param name="targetRealm">The target realm.</param>
        /// <param name="clientIdentifier">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <returns></returns>
        /// <exception cref="WebException"></exception>
        public static OAuth2AccessTokenResponse GetAppOnlyAccessToken(
           string targetPrincipalName,
           string targetHost,
           string targetRealm,
           string clientIdentifier,
           string clientSecret) {

            string resource = GetFormattedPrincipal(targetPrincipalName, targetHost, targetRealm);
            string clientId = GetFormattedPrincipal(clientIdentifier, string.Empty, targetRealm);

            OAuth2AccessTokenRequest oauth2Request = OAuth2MessageFactory.CreateAccessTokenRequestWithClientCredentials(clientId, clientSecret, resource);
            oauth2Request.Resource = resource;

            // Get token
            OAuth2S2SClient client = new OAuth2S2SClient();

            OAuth2AccessTokenResponse oauth2Response;
            try {
                oauth2Response =
                    client.Issue(AcsMetadataParser.GetStsUrl(targetRealm), oauth2Request) as OAuth2AccessTokenResponse;
            } catch (WebException wex) {
                using (StreamReader sr = new StreamReader(wex.Response.GetResponseStream())) {
                    string responseText = sr.ReadToEnd();
                    throw new WebException(wex.Message + " - " + responseText, wex);
                }
            }

            return oauth2Response;
        }

        /// <summary>
        /// Get authentication realm from SharePoint
        /// </summary>
        /// <param name="targetApplicationUri">Url of the target SharePoint site</param>
        /// <returns>String representation of the realm GUID</returns>
        public static string GetRealmFromTargetUrl(Uri targetApplicationUri) {
            WebRequest request = WebRequest.Create(targetApplicationUri + "/_vti_bin/client.svc");
            request.Headers.Add("Authorization: Bearer ");

            try {
                using (request.GetResponse()) {
                }
            } catch (WebException e) {
                if (e.Response == null) {
                    return null;
                }

                string bearerResponseHeader = e.Response.Headers["WWW-Authenticate"];
                if (string.IsNullOrEmpty(bearerResponseHeader)) {
                    return null;
                }

                const string bearer = "Bearer realm=\"";
                int bearerIndex = bearerResponseHeader.IndexOf(bearer, StringComparison.Ordinal);
                if (bearerIndex < 0) {
                    return null;
                }

                int realmIndex = bearerIndex + bearer.Length;

                if (bearerResponseHeader.Length >= realmIndex + 36) {
                    string targetRealm = bearerResponseHeader.Substring(realmIndex, 36);

                    Guid realmGuid;

                    if (Guid.TryParse(targetRealm, out realmGuid)) {
                        return targetRealm;
                    }
                }
            }
            return null;
        }

        private static string GetFormattedPrincipal(string principalName, string hostName, string realm) {
            if (!String.IsNullOrEmpty(hostName)) {
                return String.Format(CultureInfo.InvariantCulture, "{0}/{1}@{2}", principalName, hostName, realm);
            }

            return String.Format(CultureInfo.InvariantCulture, "{0}@{1}", principalName, realm);
        }
    }
}
