using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PM.Domain.Catalog
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Key
            builder.HasKey(t => t.Id);

            //Properties  
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.ParentCategoryId).IsRequired();
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Active).IsRequired();

            //Table  
            builder.ToTable("Categories");
        }
    }
}
