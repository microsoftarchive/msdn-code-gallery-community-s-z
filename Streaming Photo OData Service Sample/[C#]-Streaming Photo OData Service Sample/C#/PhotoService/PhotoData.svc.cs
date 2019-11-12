using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Data.Services.Providers;
using PhotoService;

namespace PhotoService
{
    public partial class PhotoData : DataService<PhotoDataContainer>, IServiceProvider
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("PhotoInfo",
                EntitySetRights.ReadMultiple |
                EntitySetRights.ReadSingle |
                EntitySetRights.AllWrite);

            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }
    public partial class PhotoData
    {
        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IDataServiceStreamProvider))
            {
                // Return the stream provider to the data service.
                return new PhotoServiceStreamProvider(this.CurrentDataSource);
            }
            return null;
        }

        #endregion
    }
}
