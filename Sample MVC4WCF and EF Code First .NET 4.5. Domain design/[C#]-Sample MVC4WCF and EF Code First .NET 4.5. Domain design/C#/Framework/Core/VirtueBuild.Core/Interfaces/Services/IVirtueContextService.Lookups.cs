#region File Attributes

// AdminWeb  Project: VirtueBuild.Core
// File:  IVirtueContextService.Lookups.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Core.Interfaces.Services {
    #region

    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Domain.Files;
    using Domain.Lookups;

    #endregion

    [ServiceKnownType(typeof (Image))]
    public partial interface IVirtueContextService {
        #region Get Types

        [OperationContract]
        ICollection<HomeType> GetHomeTypes(bool all = false);

        [OperationContract]
        ICollection<OrganizationType> GetOrganizationTypes(bool all = false);

        [OperationContract]
        ICollection<PhoneType> GetPhoneTypes(bool all = false);

        [OperationContract]
        ICollection<SupplierType> GetSupplierTypes(bool all = false);

        [OperationContract]
        ICollection<UnitOfMeasure> GetUnitOfMeasureTypes(bool all = false);

        [OperationContract]
        ICollection<VendorType> GetVendorTypes(bool all = false);

        [OperationContract]
        ICollection<Brand> GetBrands(bool all = false);

        [OperationContract]
        ICollection<ContactType> GetContactTypes(bool all = false);

        #endregion

        #region Create Types

        [OperationContract]
        void CreateHomeType(HomeType model);

        [OperationContract]
        void CreateBrandType(Brand model);

        [OperationContract]
        void CreateContactType(ContactType model);

        [OperationContract]
        void CreateOrganizationType(OrganizationType model);

        [OperationContract]
        void CreatePhoneType(PhoneType model);

        [OperationContract]
        void CreateSupplierType(SupplierType model);

        [OperationContract]
        void CreateVendorType(VendorType model);

        [OperationContract]
        void CreateMeasureType(UnitOfMeasure model);

        #endregion

        #region Update Types

        [OperationContract]
        void UpdateHomeType(HomeType model);

        [OperationContract]
        void UpdateBrandType(Brand model);

        [OperationContract]
        void UpdateContactType(ContactType model);

        [OperationContract]
        void UpdateOrganizationType(OrganizationType model);

        [OperationContract]
        void UpdatePhoneType(PhoneType model);

        [OperationContract]
        void UpdateSupplierType(SupplierType model);

        [OperationContract]
        void UpdateVendorType(VendorType model);

        [OperationContract]
        void UpdateMeasureType(UnitOfMeasure model);

        #endregion

        [OperationContract]
        Image GetImage(Guid imageGuid);

    }
}