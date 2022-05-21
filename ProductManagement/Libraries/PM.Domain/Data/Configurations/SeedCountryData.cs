using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain.Directory;

namespace PM.Domain.Data.Configurations
{
    public class SeedCountryData : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new Country()
            {
                Id = 1,
                Name = "Türkiye",
                TwoLetterIsoCode = "TR",
                Active = true,
            });

            builder.HasData(new Country()
            {
                Id = 2,
                Name = "Denmark",
                TwoLetterIsoCode = "DK",
                Active = true,
            });

            builder.HasData(new Country()
            {
                Id = 3,
                Name = "Sweden",
                TwoLetterIsoCode = "SE",
                Active = true,
            });
        }
    }
}
