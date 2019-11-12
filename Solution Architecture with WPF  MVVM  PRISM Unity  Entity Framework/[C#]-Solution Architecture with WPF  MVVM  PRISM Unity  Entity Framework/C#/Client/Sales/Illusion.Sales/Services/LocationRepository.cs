namespace Illusion.Sales.Services
{
    using System.Collections.Generic;
    using Illusion.Sales.BL;
    using Illusion.Sales.BLInterface;
    using Illusion.Sales.EDM;
    using Illusion.UI.Entities;

    /// <summary>
    /// Location Repository class
    /// </summary>
    public class LocationRepository : ILocationRepository
    {
        /// <summary>
        /// Gets all locations.
        /// </summary>
        /// <returns>
        /// Get All Locations
        /// </returns>
        public IEnumerable<LocationEntity> GetAllLocations()
        {
            List<LocationEntity> result = new List<LocationEntity>();
            ICountryRegionBL countryRegion = new CountryRegionBL();
            foreach (Country source in countryRegion.GetAllCountryRegion())
            {
                LocationEntity target = new LocationEntity();
                target.CountryID = source.CountryID;
                target.Store = source.Store;
                target.State = source.State;
                target.Country = source.CountryRegion;
                result.Add(target);
            }
            return result;
        }
    }
}
