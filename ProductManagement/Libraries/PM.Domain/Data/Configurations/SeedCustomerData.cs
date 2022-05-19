using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain.Customers;

namespace PM.Domain.Data.Configurations
{
    public class SeedCustomerData : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer()
            {
                Id = 1,
                FirstName = "İSMAİL",
                LastName = "AKTI",
                Username = "demo",
                Password = "demo",
                Active = true,
                IsAdministrator = true,
            });
        }
    }
}
