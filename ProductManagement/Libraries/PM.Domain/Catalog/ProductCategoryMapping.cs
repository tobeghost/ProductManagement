using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PM.Domain.Catalog
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMapping()
        {
        }

        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            //Key
            builder.HasKey(t => t.Id);

            //Properties  
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.ProductId).IsRequired();
            builder.Property(t => t.CategoryId).IsRequired();

            //Table  
            builder.ToTable("ProductCategories");

            //Relationship
            builder.HasOne(t => t.Category).WithMany(c => c.Products).HasForeignKey(t => t.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(t => t.Product).WithMany(c => c.ProductCategories).HasForeignKey(t => t.ProductId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
