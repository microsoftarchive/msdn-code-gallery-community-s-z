#region File Attributes

// AdminWeb  Project: VirtueBuild.ContextService
// File:  VirtueContextService.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.ContextService {
    #region

    using System;
    using System.Collections.Generic;
    using System.Transactions;

    using AutoMapper;

    using Core.Interfaces.Services;

    using Data.Infrastructure.UnitsOfWork;

    using Domain;
    using Domain.Files;
    using Domain.Lookups;
    using Domain.Members;

    using Security;

    #endregion

    public class VirtueContextService : IVirtueContextService {
        #region Implementation of IVirtueContextService

        public ICollection<HomeType> GetHomeTypes(bool all = false)
        {
            var result = new List<HomeType>();

            using (var uow = new LookupsUnitOfWork()) {
                var raw = uow.LookupsRespository.GetHomeTypes(all);
                Mapper.CreateMap<HomeType, HomeType>();
                //Mapper.CreateMap<Image, Image>();
                result = Mapper.Map<ICollection<HomeType>, List<HomeType>>(raw);
            }

            return result;
        }

        public ICollection<OrganizationType> GetOrganizationTypes(bool all = false)
        {
            using (var uow = new LookupsUnitOfWork()) {
                var result = uow.LookupsRespository.GetOrganizationTypes(all);
                Mapper.CreateMap<OrganizationType, OrganizationType>();
                return Mapper.Map<ICollection<OrganizationType>, List<OrganizationType>>(result);
            }
        }

        public ICollection<PhoneType> GetPhoneTypes(bool all = false)
        {
            using (var uow = new LookupsUnitOfWork()) {
                Mapper.CreateMap<PhoneType, PhoneType>();
                return Mapper.Map<ICollection<PhoneType>, List<PhoneType>>(uow.LookupsRespository.GetPhoneTypes(all));
            }
        }

        public ICollection<SupplierType> GetSupplierTypes(bool all = false)
        {
            using (var uow = new LookupsUnitOfWork()) {
                Mapper.CreateMap<SupplierType, SupplierType>();
                return
                    Mapper.Map<ICollection<SupplierType>, List<SupplierType>>(
                        uow.LookupsRespository.GetSupplierTypes(all));
            }
        }

        public ICollection<UnitOfMeasure> GetUnitOfMeasureTypes(bool all = false)
        {
            using (var uow = new LookupsUnitOfWork()) {
                Mapper.CreateMap<UnitOfMeasure, UnitOfMeasure>();
                return
                    Mapper.Map<ICollection<UnitOfMeasure>, List<UnitOfMeasure>>(
                        uow.LookupsRespository.GetUnitOfMeasureTypes(all));
            }
        }

        public ICollection<VendorType> GetVendorTypes(bool all = false)
        {
            using (var uow = new LookupsUnitOfWork()) {
                Mapper.CreateMap<VendorType, VendorType>();
                return Mapper.Map<ICollection<VendorType>, List<VendorType>>(uow.LookupsRespository.GetVendorTypes(all));
            }
        }

        public ICollection<Brand> GetBrands(bool all = false)
        {
            using (var uow = new LookupsUnitOfWork()) {
                Mapper.CreateMap<Brand, Brand>();
                return Mapper.Map<ICollection<Brand>, List<Brand>>(uow.LookupsRespository.GetBrands(all));
            }
        }

        public ICollection<ContactType> GetContactTypes(bool all = false)
        {
            using (var uow = new LookupsUnitOfWork()) {
                Mapper.CreateMap<ContactType, ContactType>();
                return
                    Mapper.Map<ICollection<ContactType>, List<ContactType>>(uow.LookupsRespository.GetContactTypes(all));
            }
        }

        public void CreateHomeType(HomeType model)
        {
            using (var uow = new LookupsUnitOfWork()) {
                uow.LookupsRespository.CreateHomeType(model);
                uow.Save();
            }
        }

        public void CreateBrandType(Brand model)
        {
            throw new NotImplementedException();
        }

        public void CreateContactType(ContactType model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrganizationType(OrganizationType model)
        {
            throw new NotImplementedException();
        }

        public void CreatePhoneType(PhoneType model)
        {
            throw new NotImplementedException();
        }

        public void CreateSupplierType(SupplierType model)
        {
            throw new NotImplementedException();
        }

        public void CreateVendorType(VendorType model)
        {
            throw new NotImplementedException();
        }

        public void CreateMeasureType(UnitOfMeasure model)
        {
            throw new NotImplementedException();
        }

        public void UpdateMeasureType(UnitOfMeasure model)
        {
            throw new NotImplementedException();
        }

        public Image GetImage(Guid imageGuid)
        {
            using (var uow = new LookupsUnitOfWork()) {
                return uow.LookupsRespository.GetImage(imageGuid);
            }
        }

        public void UpdateHomeType(HomeType model)
        {
            using (var uow = new LookupsUnitOfWork()) {
                uow.LookupsRespository.UpdateHomeType(model);
                uow.Save();
            }
        }

        public void UpdateBrandType(Brand model)
        {
            using (var uow = new LookupsUnitOfWork()) {
                uow.LookupsRespository.UpdateBrandType(model);
                uow.Save();
            }
        }

        public void UpdateContactType(ContactType model)
        {
            using (var uow = new LookupsUnitOfWork()) {
                uow.LookupsRespository.UpdateContactType(model);
                uow.Save();
            }
        }

        public void UpdateOrganizationType(OrganizationType model)
        {
            using (var uow = new LookupsUnitOfWork()) {
                uow.LookupsRespository.UpdateOrganizationType(model);
                uow.Save();
            }
        }

        public void UpdatePhoneType(PhoneType model)
        {
            using (var uow = new LookupsUnitOfWork()) {
                uow.LookupsRespository.UpdatePhoneType(model);
                uow.Save();
            }
        }

        public void UpdateSupplierType(SupplierType model)
        {
            using (var uow = new LookupsUnitOfWork()) {
                uow.LookupsRespository.UpdateSupplierType(model);
                uow.Save();
            }
        }

        public void UpdateVendorType(VendorType model)
        {
            using (var uow = new LookupsUnitOfWork()) {
                uow.LookupsRespository.UpdateVendorType(model);
                uow.Save();
            }
        }

        #endregion

        #region Implementation of IVirtueContextService

        public Guid CreateCustomer(User customer)
        {
            var securSettings = new SecuritySettings();
            var encryptionService = new EncryptionService(securSettings);
            var salt = encryptionService.CreateSaltKey();
            customer.Salt = salt;
            customer.Password = encryptionService.CreatePasswordHash(customer.Password, salt);
            customer.PasswordFormat = 1; //"SHA1"
            customer.CreatedOn = DateTime.UtcNow;
            customer.CreatedBy = customer.CreatedBy == Guid.Empty
                                     ? new Guid(Constants.SystemAccountGuid)
                                     : customer.CreatedBy;

            using (var scope = new TransactionScope()) {
                using (var coreUow = new MemberUnitOfWork()) {
                    coreUow.CreateMember(customer);
                    coreUow.Save();
                    scope.Complete();
                    return customer.UserGuid;
                }
            }
        }

        #endregion

        #region Implementation of IVirtueContextService

        public void UpdateUserInfo(User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}