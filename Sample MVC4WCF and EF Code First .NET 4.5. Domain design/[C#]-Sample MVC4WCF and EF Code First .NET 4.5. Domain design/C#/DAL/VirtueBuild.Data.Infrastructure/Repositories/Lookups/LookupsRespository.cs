#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  LookupsRespository.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Data.Infrastructure.Repositories.Lookups {
    #region

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;

    using Context.Sources;

    using Domain.Files;
    using Domain.Lookups;

    using Interfaces.Repository.Lookups;

    #endregion

    public class LookupsRespository : ILookupsRespository {

        private readonly OpenFrameworkCoreContext _context;

        public LookupsRespository(OpenFrameworkCoreContext context)
        {
            _context = context;
        }

        public OpenFrameworkCoreContext Context { get { return _context; } }

        #region ILookupsRespository Members

        public ICollection<HomeType> GetHomeTypes(bool all = false)
        {
            return all ? _context.HomeTypes.ToList() : _context.HomeTypes.Where(t => t.IsActive).ToList();
        }

        public ICollection<OrganizationType> GetOrganizationTypes(bool all = false)
        {
            return all
                       ? _context.OrganizationTypes.ToList()
                       : _context.OrganizationTypes.Where(t => t.IsActive).ToList();
        }

        public ICollection<PhoneType> GetPhoneTypes(bool all = false)
        {
            return all ? _context.PhoneTypes.ToList() : _context.PhoneTypes.Where(t => t.IsActive).ToList();
        }

        public ICollection<SupplierType> GetSupplierTypes(bool all = false)
        {
            return all ? _context.SupplierTypes.ToList() : _context.SupplierTypes.Where(t => t.IsActive).ToList();
        }

        public ICollection<UnitOfMeasure> GetUnitOfMeasureTypes(bool all = false)
        {
            return all ? _context.UnitOfMeasures.ToList() : _context.UnitOfMeasures.Where(t => t.IsActive).ToList();
        }

        public ICollection<VendorType> GetVendorTypes(bool all = false)
        {
            return all ? _context.VendorTypes.ToList() : _context.VendorTypes.Where(t => t.IsActive).ToList();
        }

        public ICollection<Brand> GetBrands(bool all = false)
        {
            return all ? _context.Brands.ToList() : _context.Brands.Where(t => t.IsActive).ToList();
        }

        public ICollection<ContactType> GetContactTypes(bool all = false)
        {
            return all ? _context.ContactTypes.ToList() : _context.ContactTypes.Where(t => t.IsActive).ToList();
        }

        public void CreateBrandType(Brand model)
        {
            AddEntityImage(model);
            _context.Brands.Add(model);
        }

        public void CreateContactType(ContactType model)
        {
            _context.ContactTypes.Add(model);
        }

        public void CreateOrganizationType(OrganizationType model)
        {
            _context.OrganizationTypes.Add(model);
        }

        public void CreatePhoneType(PhoneType model)
        {
            _context.PhoneTypes.Add(model);
        }

        public void CreateSupplierType(SupplierType model)
        {
            _context.SupplierTypes.Add(model);
        }

        public void CreateVendorType(VendorType model)
        {
            _context.VendorTypes.Add(model);
        }

        public void CreateMeasureType(UnitOfMeasure model)
        {
            _context.UnitOfMeasures.Add(model);
        }

        public void CreateHomeType(HomeType model)
        {
            AddEntityImage(model);
            _context.HomeTypes.Add(model);
        }

        public void UpdateMeasureType(UnitOfMeasure model)
        {
            _context.UnitOfMeasures.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public Image GetImage(Guid imageGuid)
        {
            return _context.Images.FirstOrDefault(i => i.ImageGuid == imageGuid);
        }

        public void UpdateHomeType(HomeType model)
        {
            RemoveEntityImage(model);
            AddEntityImage(model);

            _context.HomeTypes.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public void UpdateBrandType(Brand model)
        {
            RemoveEntityImage(model);
            AddEntityImage(model);

            _context.Brands.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public void UpdateContactType(ContactType model)
        {
            _context.ContactTypes.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public void UpdateOrganizationType(OrganizationType model)
        {
            _context.OrganizationTypes.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public void UpdatePhoneType(PhoneType model)
        {
            _context.PhoneTypes.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public void UpdateSupplierType(SupplierType model)
        {
            _context.SupplierTypes.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public void UpdateVendorType(VendorType model)
        {
            RemoveEntityImage(model);
            AddEntityImage(model);

            _context.VendorTypes.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        #endregion

        private void AddEntityImage(IVisualImage model)
        {
            if (model.Image != null) {
                _context.Images.Add(model.Image);
                model.Image = null;
            }
        }

        private void RemoveEntityImage(IVisualImage model)
        {
            var img = _context.Images.FirstOrDefault(i => i.ImageGuid == model.ImageGuid);
            if (img != null) {
                _context.Images.Remove(img);
                _context.Entry(img).State = EntityState.Deleted;
            }
        }

    }
}