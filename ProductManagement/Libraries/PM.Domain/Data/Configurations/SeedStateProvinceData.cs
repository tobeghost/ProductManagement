using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain.Directory;

namespace PM.Domain.Data.Configurations
{
    public class SeedStateProvinceData : IEntityTypeConfiguration<StateProvince>
    {
        public void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            builder.HasData(new StateProvince()
            {
                Id = 1,
                CountryId = 1,
                Name = "Antalya",
                Active = true,
            });

            builder.HasData(new StateProvince()
            {
                Id = 2,
                CountryId = 1,
                Name = "İstanbul",
                Active = true,
            });

            builder.HasData(new StateProvince()
            {
                Id = 3,
                CountryId = 1,
                Name = "İzmir",
                Active = true,
            });
        }
    }
}
