using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ContosoAdsCommon
{
    public class ContosoAdsContext : DbContext
    {
        public ContosoAdsContext() : base("name=ContosoAdsContext")
        {
        }

        public System.Data.Entity.DbSet<Ad> Ads { get; set; }
    
    }
}
