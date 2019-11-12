#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  ILookupsRespository.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Data.Infrastructure.Interfaces.Repository.Lookups {
    #region

    using System;
    using System.Collections.Generic;

    using Domain.Files;
    using Domain.Lookups;

    #endregion

    public interface ILookupsRespository {
        #region Get Types

        ICollection<HomeType> GetHomeTypes(bool all = false);

        ICollection<OrganizationType> GetOrganizationTypes(bool all = false);

        ICollection<PhoneType> GetPhoneTypes(bool all = false);

        ICollection<SupplierType> GetSupplierTypes(bool all = false);

        ICollection<UnitOfMeasure> GetUnitOfMeasureTypes(bool all = false);

        ICollection<VendorType> GetVendorTypes(bool all = false);

        ICollection<Brand> GetBrands(bool all = false);

        ICollection<ContactType> GetContactTypes(bool all = false);

        #endregion

        #region Create Types

        void CreateHomeType(HomeType model);

        void CreateBrandType(Brand model);

        void CreateContactType(ContactType model);

        void CreateOrganizationType(OrganizationType model);

        void CreatePhoneType(PhoneType model);

        void CreateSupplierType(SupplierType model);

        void CreateVendorType(VendorType model);

        void CreateMeasureType(UnitOfMeasure model);

        #endregion

        #region Update Types

        void UpdateHomeType(HomeType model);

        void UpdateBrandType(Brand model);

        void UpdateContactType(ContactType model);

        void UpdateOrganizationType(OrganizationType model);

        void UpdatePhoneType(PhoneType model);

        void UpdateSupplierType(SupplierType model);

        void UpdateVendorType(VendorType model);

        void UpdateMeasureType(UnitOfMeasure model);

        #endregion

        Image GetImage(Guid imageGuid);

    }
}