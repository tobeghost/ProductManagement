using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PM.Domain.Directory
{
    public class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public CountryMapping()
        {
        }

        public void Configure(EntityTypeBuilder<Country> builder)
        {
            //Key
            builder.HasKey(t => t.Id);

            //Properties  
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.TwoLetterIsoCode).IsRequired();
            builder.Property(t => t.Active).IsRequired();

            //Table  
            builder.ToTable("Countries");
        }
    }
}
