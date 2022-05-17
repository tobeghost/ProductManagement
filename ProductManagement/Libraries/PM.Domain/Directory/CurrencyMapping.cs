using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PM.Domain.Directory
{
    public class CurrencyMapping : IEntityTypeConfiguration<Currency>
    {
        public CurrencyMapping()
        {
        }

        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            //Key
            builder.HasKey(t => t.Id);

            //Properties  
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.CurrencyCode).IsRequired();
            builder.Property(t => t.Rate).IsRequired();
            builder.Property(t => t.NumberDecimal).IsRequired();
            builder.Property(t => t.Active).IsRequired();

            //Table  
            builder.ToTable("Currencies");
        }
    }
}
