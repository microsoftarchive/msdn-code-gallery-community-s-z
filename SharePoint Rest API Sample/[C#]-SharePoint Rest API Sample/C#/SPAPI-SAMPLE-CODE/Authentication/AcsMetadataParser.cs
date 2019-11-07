using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SPAPI_SAMPLE_CODE.Authentication {
    public static class AcsMetadataParser {
        private const string AcsMetadataEndPointRelativeUrl = "metadata/json/1";
        private static string GlobalEndPointPrefix = "accounts";
        private static string AcsHostUrl = "accesscontrol.windows.net";
        private const string S2SProtocol = "OAuth2";
        private const string DelegationIssuance = "DelegationIssuance1.0";

        public static X509Certificate2 GetAcsSigningCert(string realm) {
            JsonMetadataDocument document = GetMetadataDocument(realm);

            if (null != document.keys && document.keys.Count > 0) {
                JsonKey signingKey = document.keys[0];

                if (null != signingKey && null != signingKey.keyValue) {
                    return new X509Certificate2(Encoding.UTF8.GetBytes(signingKey.keyValue.value));
                }
            }

            throw new Exception("Metadata document does not contain ACS signing certificate.");
        }

        public static string GetDelegationServiceUrl(string realm) {
            JsonMetadataDocument document = GetMetadataDocument(realm);

            JsonEndpoint delegationEndpoint = document.endpoints.SingleOrDefault(e => e.protocol == DelegationIssuance);

            if (null != delegationEndpoint) {
                return delegationEndpoint.location;
            }
            throw new Exception("Metadata document does not contain Delegation Service endpoint Url");
        }

        private static JsonMetadataDocument GetMetadataDocument(string realm) {
            string acsMetadataEndpointUrlWithRealm = String.Format(CultureInfo.InvariantCulture, "{0}?realm={1}",
                                                                   GetAcsMetadataEndpointUrl(),
                                                                   realm);
            byte[] acsMetadata;
            using (WebClient webClient = new WebClient()) {

                acsMetadata = webClient.DownloadData(acsMetadataEndpointUrlWithRealm);
            }
            string jsonResponseString = Encoding.UTF8.GetString(acsMetadata);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            JsonMetadataDocument document = serializer.Deserialize<JsonMetadataDocument>(jsonResponseString);

            if (null == document) {
                throw new Exception("No metadata document found at the global endpoint " + acsMetadataEndpointUrlWithRealm);
            }

            return document;
        }

        public static string GetStsUrl(string realm) {
            JsonMetadataDocument document = GetMetadataDocument(realm);

            JsonEndpoint s2sEndpoint = document.endpoints.SingleOrDefault(e => e.protocol == S2SProtocol);

            if (null != s2sEndpoint) {
                return s2sEndpoint.location;
            }

            throw new Exception("Metadata document does not contain STS endpoint url");
        }

        private class JsonMetadataDocument {
            public string serviceName { get; set; }
            public List<JsonEndpoint> endpoints { get; set; }
            public List<JsonKey> keys { get; set; }
        }

        private class JsonEndpoint {
            public string location { get; set; }
            public string protocol { get; set; }
            public string usage { get; set; }
        }

        private class JsonKeyValue {
            public string type { get; set; }
            public string value { get; set; }
        }

        private class JsonKey {
            public string usage { get; set; }
            public JsonKeyValue keyValue { get; set; }
        }

        private static string GetAcsMetadataEndpointUrl() {
            return Path.Combine(GetAcsGlobalEndpointUrl(), AcsMetadataEndPointRelativeUrl);
        }

        private static string GetAcsGlobalEndpointUrl() {
            return String.Format(CultureInfo.InvariantCulture, "https://{0}.{1}/", GlobalEndPointPrefix, AcsHostUrl);
        }
    }
}
