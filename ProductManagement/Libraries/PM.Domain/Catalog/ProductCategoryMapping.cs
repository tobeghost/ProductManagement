using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace PM.Domain.Catalog
{
    public class ProductCategoryMapping : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMapping()
        {
            //Key
            HasKey(t => t.Id);

            //Properties  
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.ProductId).IsRequired();
            Property(t => t.CategoryId).IsRequired();

            //Table  
            ToTable("ProductCategories");

            //Relationship
            HasRequired(t => t.Category).WithMany(c => c.Products).HasForeignKey(t => t.CategoryId).WillCascadeOnDelete(false);
            HasRequired(t => t.Product).WithMany(c => c.ProductCategories).HasForeignKey(t => t.ProductId).WillCascadeOnDelete(false);
        }
    }
}
