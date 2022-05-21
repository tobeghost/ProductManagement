using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.Domain.Catalog;

namespace PM.Domain.Data.Configurations
{
    public class SeedProductData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product()
            {
                Id = 1,
                Name = "US Polo Assn Gri Erkek T-Shirt",
                Sku = "1111111",
                ShortDescription = "%100 Pamuk / Renk Gri",
                Quantity = 10,
                Price = 130.62M,
                OldPrice = 140,
                CatalogPrice = 130,
                CostPrice = 100,
                CurrencyId = 1,
                Active = true,
            });

            builder.HasData(new Product()
            {
                Id = 2,
                Name = "Madmext Erkek Siyah Polo Yaka Tişört",
                Sku = "22222222",
                ShortDescription = "Numune Bedeni : L Model Ölçüleri : Boy 1.91 / Kilo 88 Ürünün Kalıbı : Slim Fit Ürün İçeri : %100 Cotton Yıkama Talimatı : 30' Derecede Yıkayınız MADE IN TURKEY",
                Quantity = 15,
                Price = 123.49M,
                OldPrice = 150,
                CatalogPrice = 125,
                CostPrice = 105.5M,
                CurrencyId = 1,
                Active = true,
            });

            builder.HasData(new Product()
            {
                Id = 3,
                Name = "Apple iPhone 11 64GB Siyah Cep Telefonu",
                Sku = "333333333",
                ShortDescription = "(Apple Türkiye Garantili) Aksesuarsız Kutu",
                Quantity = 100,
                Price = 11991.55M,
                OldPrice = 12000,
                CatalogPrice = 11500,
                CostPrice = 10000,
                CurrencyId = 1,
                Active = true,
            });
        }
    }
}
