using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PM.Domain.Catalog
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Key
            builder.HasKey(t => t.Id);

            //Properties  
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Sku);
            builder.Property(t => t.Gtin);
            builder.Property(t => t.ShortDescription);
            builder.Property(t => t.FullDescription);
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.Price).IsRequired();
            builder.Property(t => t.OldPrice).IsRequired();
            builder.Property(t => t.CatalogPrice).IsRequired();
            builder.Property(t => t.CostPrice).IsRequired();
            builder.Property(t => t.CurrencyId).IsRequired();
            builder.Property(t => t.Active).IsRequired();

            //Table  
            builder.ToTable("Products");

            //Relationship
            builder.HasOne(t => t.Currency).WithMany(c => c.Products).HasForeignKey(t => t.CurrencyId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
