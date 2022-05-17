using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.Domain.Customers
{
    public class CustomerAddressMapping : IEntityTypeConfiguration<CustomerAddress>
    {
        public CustomerAddressMapping()
        {
        }

        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            //Key
            builder.HasKey(t => t.Id);

            //Properties  
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.CustomerId).IsRequired();
            builder.Property(t => t.FirstName).IsRequired();
            builder.Property(t => t.LastName).IsRequired();
            builder.Property(t => t.Email).IsRequired();
            builder.Property(t => t.CountryId).IsRequired();
            builder.Property(t => t.StateProvinceId).IsRequired();
            builder.Property(t => t.City).IsRequired();
            builder.Property(t => t.Address).IsRequired();
            builder.Property(t => t.ZipPostalCode).IsRequired();
            builder.Property(t => t.PhoneNumber).IsRequired();
            builder.Property(t => t.Active).IsRequired();

            //Table  
            builder.ToTable("CustomerAddress");

            //Relationship
            builder.HasOne(t => t.Customer).WithMany(c => c.Address).HasForeignKey(t => t.CustomerId);
            builder.HasOne(t => t.Country).WithMany(c => c.CustomerAddress).HasForeignKey(t => t.CountryId);
            builder.HasOne(t => t.StateProvince).WithMany(c => c.CustomerAddress).HasForeignKey(t => t.StateProvinceId);
        }
    }
}
