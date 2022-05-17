using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace PM.Domain.Customers
{
    public class CustomerAddressMapping : EntityTypeConfiguration<CustomerAddress>
    {
        public CustomerAddressMapping()
        {
            //Key
            HasKey(t => t.Id);

            //Properties  
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CustomerId).IsRequired();
            Property(t => t.FirstName).IsRequired();
            Property(t => t.LastName).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.CountryId).IsRequired();
            Property(t => t.StateProvinceId).IsRequired();
            Property(t => t.City).IsRequired();
            Property(t => t.Address).IsRequired();
            Property(t => t.ZipPostalCode).IsRequired();
            Property(t => t.PhoneNumber).IsRequired();
            Property(t => t.Active).IsRequired();

            //Table  
            ToTable("CustomerAddress");

            //Relationship
            HasRequired(t => t.Customer).WithMany(c => c.Address).HasForeignKey(t => t.CustomerId).WillCascadeOnDelete(false);
            HasRequired(t => t.Country).WithMany(c => c.CustomerAddress).HasForeignKey(t => t.CountryId).WillCascadeOnDelete(false);
            HasRequired(t => t.StateProvince).WithMany(c => c.CustomerAddress).HasForeignKey(t => t.StateProvinceId).WillCascadeOnDelete(false);
        }
    }
}
