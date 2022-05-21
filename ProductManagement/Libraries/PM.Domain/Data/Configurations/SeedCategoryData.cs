using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain.Catalog;

namespace PM.Domain.Data.Configurations
{
    public class SeedCategoryData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category()
            {
                Id = 1,
                ParentCategoryId = 0,
                Name = "Giyim",
                Active = true,
            });

            builder.HasData(new Category()
            {
                Id = 2,
                ParentCategoryId = 0,
                Name = "Aksesuar",
                Active = true,
            });

            builder.HasData(new Category()
            {
                Id = 3,
                ParentCategoryId = 0,
                Name = "Elektronik",
                Active = true,
            });
        }
    }
}
