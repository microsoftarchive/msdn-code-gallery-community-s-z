using System;
using System.Collections.Specialized;
using System.Data.Services.Client;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.ActiveDirectory.GraphHelper;

namespace Microsoft.WindowsAzure.ActiveDirectory
{
    /// <summary>
    /// Partial class for DirectoryDataService which included a helper method that constructs the service with a token and also
    /// adds the query string for specifying the version of "2013-04-05" version which is the version this assembly supports.
    /// </summary>
    public partial class DirectoryDataService
    {
        private AADJWTToken authenticationToken;

        /// <summary>
        /// Helper method for creating DirectoryService and adding header 
        /// for subsequent requests for the service. It also adds helper properties for collections of subtypes of DirectoryObject
        /// such as users, contacts etc.
        /// </summary>
        public DirectoryDataService(string tenantName, AADJWTToken token)
            : this(new Uri(StringConstants.DirectoryServiceURL + tenantName))
        {
            this.authenticationToken = token;
            // Register the event handler that adds the headers for HTTP requests including the Authorization header.
            this.BuildingRequest += new EventHandler<BuildingRequestEventArgs>(OnBuildingRequest);
        }
        
        /// <summary>
        /// Tenant name for the tenant in DirectoryService that the requests will be sent to..
        /// </summary>
        public string TenantName { get; private set; }

        /// <summary>
        /// Attach authorization, version and other context information before sending request.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="args">Request arguments.</param>
        internal void OnBuildingRequest(object sender, BuildingRequestEventArgs args)
        {
            // Add the data contract version as a query argument
            args.RequestUri = GetRequestUriWithDataContractVersion(args.RequestUri, StringConstants.GraphServiceVersion);
            // Add an Authorization header that contains an OAuth WRAP access token to the request.
            string authzHeader = String.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", authenticationToken.TokenType, " ", authenticationToken.AccessToken);
            args.Headers.Add("Authorization", authzHeader);
        }


        private static Uri GetRequestUriWithDataContractVersion(Uri origRequestUri, string apiVersion)
        {
            // Handle the api-version query argument to specify the data contract version
            NameValueCollection queryArguments = HttpUtility.ParseQueryString(origRequestUri.Query);

            if (String.IsNullOrEmpty(queryArguments["api-version"]))
            {
                queryArguments["api-version"] = apiVersion;
            }

            UriBuilder uriBuilder = new UriBuilder(origRequestUri);
            uriBuilder.Query = queryArguments.ToString();
            return uriBuilder.Uri;
        }

        /// <summary>
        /// Collection of User type produced using the OfType filter on directoryObjects collection.
        /// </summary>
        public DataServiceQuery<User> users
        {
            get
            {
                return this.directoryObjects.OfType<User>() as DataServiceQuery<User>;
            }
        }

        /// <summary>
        /// Collection of Group type produced using the OfType filter on directoryObjects collection.
        /// </summary>
        public DataServiceQuery<Group> groups
        {
            get
            {
                return this.directoryObjects.OfType<Group>() as DataServiceQuery<Group>;
            }
        }

        /// <summary>
        /// Collection of Contact type produced using the OfType filter on directoryObjects collection.
        /// </summary>
        public DataServiceQuery<Contact> contacts
        {
            get
            {
                return this.directoryObjects.OfType<Contact>() as DataServiceQuery<Contact>;
            }
        }

        /// <summary>
        /// Collection of ServicePrincipal type produced using the OfType filter on directoryObjects collection.
        /// </summary>
        public DataServiceQuery<ServicePrincipal> servicePrincipals
        {
            get
            {
                return this.directoryObjects.OfType<ServicePrincipal>() as DataServiceQuery<ServicePrincipal>;
            }
        }

        /// <summary>
        /// Collection of Role type produced using the OfType filter on directoryObjects collection.
        /// </summary>
        public DataServiceQuery<Role> roles
        {
            get
            {
                return this.directoryObjects.OfType<Role>() as DataServiceQuery<Role>;
            }
        }

        /// <summary>
        /// Collection of TenantDetail type produced using the OfType filter on directoryObjects collection.
        /// </summary>
        public DataServiceQuery<TenantDetail> tenantDetails
        {
            get
            {
                return this.directoryObjects.OfType<TenantDetail>() as DataServiceQuery<TenantDetail>;
            }
        }

        /// <summary>
        /// Collection of Application type produced using the OfType filter on directoryObjects collection.
        /// </summary>
        public DataServiceQuery<Application> applications
        {
            get
            {
                return this.directoryObjects.OfType<Application>() as DataServiceQuery<Application>;
            }
        }

        /// <summary>
        /// Collection of Device type produced using the OfType filter on directoryObjects collection.
        /// </summary>
        public DataServiceQuery<Device> devices
        {
            get
            {
                return this.directoryObjects.OfType<Device>() as DataServiceQuery<Device>;
            }
        }


        /// <summary>
        /// Helper method for adding an object to groups collection.
        /// </summary>
        /// <param name="group"></param>
        public void AddTogroups(Group group)
        {
            base.AddObject("directoryObjects", group);
        }

        /// <summary>
        /// Helper method for adding an object to users collection.
        /// </summary>
        /// <param name="group"></param>
        public void AddTousers(User user)
        {
            base.AddObject("directoryObjects", user);
        }

        /// <summary>
        /// Helper method for adding an object to contacts collection.
        /// </summary>
        /// <param name="group"></param>
        public void AddTocontacts(Contact contact)
        {
            base.AddObject("directoryObjectss", contact);
        }

        /// <summary>
        /// Helper method for adding an object to roles collection.
        /// </summary>
        /// <param name="group"></param>
        public void AddToroles(Role role)
        {
            base.AddObject("directoryObjects", role);
        }

        /// <summary>
        /// Helper method for adding an object to servicePrincipals collection.
        /// </summary>
        /// <param name="group"></param>
        public void AddToserviceprincipals(ServicePrincipal servicePrincipal)
        {
            base.AddObject("directoryObjects", servicePrincipal);
        }

        /// <summary>
        /// Helper method for adding an object to tenantDetails collection.
        /// </summary>
        /// <param name="group"></param>
        public void AddTotenantDetails(TenantDetail tenantDetail)
        {
            base.AddObject("directoryObjects", tenantDetail);
        }
    }
}