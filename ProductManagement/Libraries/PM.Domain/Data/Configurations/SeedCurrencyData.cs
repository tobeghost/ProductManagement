using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain.Directory;

namespace PM.Domain.Data.Configurations
{
    public class SeedCurrencyData : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasData(new Currency()
            {
                Id = 1,
                Name = "Türk Lirası",
                CurrencyCode = "TRY",
                NumberDecimal = 2,
                Rate = 0,
                Active = true,
            });

            builder.HasData(new Currency()
            {
                Id = 2,
                Name = "Amerikan Doları",
                CurrencyCode = "USD",
                NumberDecimal = 2,
                Rate = 0,
                Active = true,
            });
        }
    }
}
