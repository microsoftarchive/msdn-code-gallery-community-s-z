#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  OpenFrameworkCoreContext.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Context.Sources {
    #region

    using System.Data.Entity;

    using Domain.Files;
    using Domain.Lookups;
    using Domain.Members;
    using Domain.Members.Contacts;
    using Domain.Settings;
    using Domain.Vendor;

    using Mapping;

    #endregion

    public class OpenFrameworkCoreContext : DbContext {
        #region Constractors

        public OpenFrameworkCoreContext()
            : base("Name=OpenFrameworkCoreContext") {}

        public OpenFrameworkCoreContext(string connectionString)
            : base(connectionString) {}

        #endregion

        #region DbSets - Properties

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactPhone> ContactPhones { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<UserContact> ContactUsers { get; set; }

        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        public DbSet<ELMAH_Error> ELMAH_Error { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }

        public DbSet<SiteSetting> SiteSettings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<ContactStatus> ContactStatus { get; set; }

        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<HomeType> HomeTypes { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<OrganizationType> OrganizationTypes { get; set; }

        public DbSet<PhoneType> PhoneTypes { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<SupplierType> SupplierTypes { get; set; }

        public DbSet<VendorType> VendorTypes { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new ApplicationMap());
            modelBuilder.Configurations.Add(new AttachmentMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new ContactPhoneMap());
            modelBuilder.Configurations.Add(new ContactUMap());
            modelBuilder.Configurations.Add(new UserContactMap());
            modelBuilder.Configurations.Add(new UnitOfMeasureMap());
            modelBuilder.Configurations.Add(new ELMAH_ErrorMap());
            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new OrganizationMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new SecurityQuestionMap());
            modelBuilder.Configurations.Add(new SiteSettingMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new AddressTypeMap());
            modelBuilder.Configurations.Add(new BrandMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new ContactStatuMap());
            modelBuilder.Configurations.Add(new ContactTypeMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new HomeTypeMap());
            modelBuilder.Configurations.Add(new LanguageMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new OrganizationTypeMap());
            modelBuilder.Configurations.Add(new PhoneTypeMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new VendorTypeMap());
        }

    }
}