#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  AddressMap.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Context.Mapping {
    #region

    using System.Data.Entity.ModelConfiguration;

    using Domain.Members.Contacts;

    #endregion

    public class AddressMap : EntityTypeConfiguration<Address> {

        public AddressMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Address1).HasMaxLength(250);

            Property(t => t.Address2).HasMaxLength(250);

            Property(t => t.PostalCode).HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Address");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Address1).HasColumnName("Line1");
            Property(t => t.Address2).HasColumnName("Line2");
            Property(t => t.CityId).HasColumnName("CityId");
            Property(t => t.PostalCode).HasColumnName("PostalCode");
            Property(t => t.StateId).HasColumnName("StateId");
            Property(t => t.CountryId).HasColumnName("CountryId");
            Property(t => t.AddressTypeId).HasColumnName("AddressTypeId");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.SortOrder).HasColumnName("SortOrder");

            // Relationships
            HasMany(t => t.Contacts).WithMany(t => t.Addresses).Map(
                m => {
                    m.ToTable("ContactAddress");
                    m.MapLeftKey("AddressId");
                    m.MapRightKey("ContactId");
                });

            HasRequired(t => t.AddressType).WithMany(t => t.Addresses).HasForeignKey(d => d.AddressTypeId);
            HasOptional(t => t.City).WithMany(t => t.Addresses).HasForeignKey(d => d.CityId);
            HasOptional(t => t.Country).WithMany(t => t.Addresses).HasForeignKey(d => d.CountryId);
            HasOptional(t => t.State).WithMany(t => t.Addresses).HasForeignKey(d => d.StateId);
        }

    }
}