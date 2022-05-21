using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain.Catalog;

namespace PM.Domain.Data.Configurations
{
    public class SeedProductCategoryData : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(new ProductCategory()
            {
                Id = 1,
                ProductId = 1,
                CategoryId = 1,
            });

            builder.HasData(new ProductCategory()
            {
                Id = 2,
                ProductId = 2,
                CategoryId = 1,
            });

            builder.HasData(new ProductCategory()
            {
                Id = 3,
                ProductId = 3,
                CategoryId = 3,
            });
        }
    }
}
