using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PM.Domain.Customers
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
        }

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Key
            builder.HasKey(t => t.Id);

            //Properties  
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.FirstName).IsRequired();
            builder.Property(t => t.LastName).IsRequired();
            builder.Property(t => t.Username).IsRequired();
            builder.Property(t => t.Password).IsRequired();
            builder.Property(t => t.IsAdministrator).IsRequired();
            builder.Property(t => t.Active).IsRequired();

            //Table  
            builder.ToTable("Customers");
        }
    }
}
