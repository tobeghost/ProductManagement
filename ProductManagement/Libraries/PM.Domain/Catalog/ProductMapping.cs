using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace PM.Domain.Catalog
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            //Key
            HasKey(t => t.Id);

            //Properties  
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired();
            Property(t => t.Sku).IsOptional();
            Property(t => t.Gtin).IsOptional();
            Property(t => t.ShortDescription).IsOptional();
            Property(t => t.FullDescription).IsOptional();
            Property(t => t.Quantity).IsRequired();
            Property(t => t.Price).IsRequired();
            Property(t => t.OldPrice).IsRequired();
            Property(t => t.CatalogPrice).IsRequired();
            Property(t => t.CostPrice).IsRequired();
            Property(t => t.CurrencyId).IsRequired();
            Property(t => t.Active).IsRequired();

            //Table  
            ToTable("Products");

            //Relationship
            HasRequired(t => t.Currency).WithMany(c => c.Products).HasForeignKey(t => t.CurrencyId).WillCascadeOnDelete(false);
        }
    }
}
