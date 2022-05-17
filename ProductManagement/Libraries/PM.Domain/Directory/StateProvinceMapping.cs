using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PM.Domain.Directory
{
    public class StateProvinceMapping : IEntityTypeConfiguration<StateProvince>
    {
        public StateProvinceMapping()
        {
        }

        public void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            //Key
            builder.HasKey(t => t.Id);

            //Properties  
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.CountryId).IsRequired();
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Active).IsRequired();

            //Table  
            builder.ToTable("StateProvinces");

            //Relationship
            builder.HasOne(t => t.Country).WithMany(c => c.StateProvinces).HasForeignKey(t => t.CountryId);
        }
    }
}
