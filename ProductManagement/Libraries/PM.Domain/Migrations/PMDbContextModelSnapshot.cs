﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PM.Domain.Data;

namespace PM.Domain.Migrations
{
    [DbContext(typeof(PMDbContext))]
    partial class PMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PM.Domain.Catalog.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Name = "Giyim",
                            ParentCategoryId = 0
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Name = "Aksesuar",
                            ParentCategoryId = 0
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Name = "Elektronik",
                            ParentCategoryId = 0
                        });
                });

            modelBuilder.Entity("PM.Domain.Catalog.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<decimal>("CatalogPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("FullDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gtin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sku")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CatalogPrice = 130m,
                            CostPrice = 100m,
                            CurrencyId = 1,
                            Name = "US Polo Assn Gri Erkek T-Shirt",
                            OldPrice = 140m,
                            Price = 130.62m,
                            Quantity = 10,
                            ShortDescription = "%100 Pamuk / Renk Gri",
                            Sku = "1111111"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CatalogPrice = 125m,
                            CostPrice = 105.5m,
                            CurrencyId = 1,
                            Name = "Madmext Erkek Siyah Polo Yaka Tişört",
                            OldPrice = 150m,
                            Price = 123.49m,
                            Quantity = 15,
                            ShortDescription = "Numune Bedeni : L Model Ölçüleri : Boy 1.91 / Kilo 88 Ürünün Kalıbı : Slim Fit Ürün İçeri : %100 Cotton Yıkama Talimatı : 30' Derecede Yıkayınız MADE IN TURKEY",
                            Sku = "22222222"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CatalogPrice = 11500m,
                            CostPrice = 10000m,
                            CurrencyId = 1,
                            Name = "Apple iPhone 11 64GB Siyah Cep Telefonu",
                            OldPrice = 12000m,
                            Price = 11991.55m,
                            Quantity = 100,
                            ShortDescription = "(Apple Türkiye Garantili) Aksesuarsız Kutu",
                            Sku = "333333333"
                        });
                });

            modelBuilder.Entity("PM.Domain.Catalog.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("PM.Domain.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdministrator")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            FirstName = "İSMAİL",
                            IsAdministrator = true,
                            LastName = "AKTI",
                            Password = "demo",
                            Username = "demo"
                        });
                });

            modelBuilder.Entity("PM.Domain.Customers.CustomerAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("ZipPostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StateProvinceId");

                    b.ToTable("CustomerAddress");
                });

            modelBuilder.Entity("PM.Domain.Directory.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwoLetterIsoCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Name = "Türkiye",
                            TwoLetterIsoCode = "TR"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Name = "Denmark",
                            TwoLetterIsoCode = "DK"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Name = "Sweden",
                            TwoLetterIsoCode = "SE"
                        });
                });

            modelBuilder.Entity("PM.Domain.Directory.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberDecimal")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CurrencyCode = "TRY",
                            Name = "Türk Lirası",
                            NumberDecimal = 2,
                            Rate = 0m
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CurrencyCode = "USD",
                            Name = "Amerikan Doları",
                            NumberDecimal = 2,
                            Rate = 0m
                        });
                });

            modelBuilder.Entity("PM.Domain.Directory.StateProvince", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("StateProvinces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CountryId = 1,
                            Name = "Antalya"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CountryId = 1,
                            Name = "İstanbul"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CountryId = 1,
                            Name = "İzmir"
                        });
                });

            modelBuilder.Entity("PM.Domain.Catalog.Product", b =>
                {
                    b.HasOne("PM.Domain.Directory.Currency", "Currency")
                        .WithMany("Products")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("PM.Domain.Catalog.ProductCategory", b =>
                {
                    b.HasOne("PM.Domain.Catalog.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PM.Domain.Catalog.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PM.Domain.Customers.CustomerAddress", b =>
                {
                    b.HasOne("PM.Domain.Directory.Country", "Country")
                        .WithMany("CustomerAddress")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PM.Domain.Customers.Customer", "Customer")
                        .WithMany("Address")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PM.Domain.Directory.StateProvince", "StateProvince")
                        .WithMany("CustomerAddress")
                        .HasForeignKey("StateProvinceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Customer");

                    b.Navigation("StateProvince");
                });

            modelBuilder.Entity("PM.Domain.Directory.StateProvince", b =>
                {
                    b.HasOne("PM.Domain.Directory.Country", "Country")
                        .WithMany("StateProvinces")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PM.Domain.Catalog.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PM.Domain.Catalog.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("PM.Domain.Customers.Customer", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("PM.Domain.Directory.Country", b =>
                {
                    b.Navigation("CustomerAddress");

                    b.Navigation("StateProvinces");
                });

            modelBuilder.Entity("PM.Domain.Directory.Currency", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PM.Domain.Directory.StateProvince", b =>
                {
                    b.Navigation("CustomerAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
