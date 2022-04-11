﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.DAL.DbContexts;

namespace Project.DAL.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20220411174855_Cart")]
    partial class Cart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.DAL.Entities.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastIPNo")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("MailAddress")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("char(32)");

                    b.HasKey("ID");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            LastDate = new DateTime(2022, 4, 11, 20, 48, 54, 569, DateTimeKind.Local).AddTicks(5158),
                            LastIPNo = "1",
                            MailAddress = "Muhammet@gmail.com",
                            NameSurname = "Muhammet Ertem",
                            Password = "202cb962ac59075b964b07152d234b70"
                        });
                });

            modelBuilder.Entity("Project.DAL.Entities.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("text");

                    b.Property<string>("Information")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Number")
                        .HasColumnType("varchar(11)");

                    b.HasKey("ID");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("Project.DAL.Entities.AnimalPicture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("ID");

                    b.HasIndex("AnimalID");

                    b.ToTable("AnimalPicture");
                });

            modelBuilder.Entity("Project.DAL.Entities.Blog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<DateTime>("RecDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("Project.DAL.Entities.BlogPicture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("ID");

                    b.HasIndex("BlogID");

                    b.ToTable("BlogPicture");
                });

            modelBuilder.Entity("Project.DAL.Entities.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Project.DAL.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Project.DAL.Entities.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Project.DAL.Entities.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IPNo")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("MailAddress")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Message")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("NameSurname")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("RecDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Project.DAL.Entities.Distinct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Distinct");
                });

            modelBuilder.Entity("Project.DAL.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BilingAddress")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BilingCity")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("BilingDistinct")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("BilingZipCode")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("DeliveryAddress")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DeliveryCity")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DeliveryDistinct")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DeliveryZipCode")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("IPNo")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("MailAddress")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("NameSurname")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OrderNumber")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("Payment")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("RecDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaxNumber")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TaxOffice")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("OrderNumber")
                        .IsUnique()
                        .HasFilter("[OrderNumber] IS NOT NULL");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Project.DAL.Entities.OrderDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProductPicture")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Project.DAL.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<decimal>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int?>("SubCategoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.HasIndex("SubCategoryID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Project.DAL.Entities.ProductPicture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductPicture");
                });

            modelBuilder.Entity("Project.DAL.Entities.Slider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Picture")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Slogan")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("Project.DAL.Entities.SubCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("Project.DAL.Entities.AnimalPicture", b =>
                {
                    b.HasOne("Project.DAL.Entities.Animal", "Animal")
                        .WithMany("AnimalPictures")
                        .HasForeignKey("AnimalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("Project.DAL.Entities.BlogPicture", b =>
                {
                    b.HasOne("Project.DAL.Entities.Blog", "Blog")
                        .WithMany("BlogPictures")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Project.DAL.Entities.Distinct", b =>
                {
                    b.HasOne("Project.DAL.Entities.City", "City")
                        .WithMany("Distincts")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("City");
                });

            modelBuilder.Entity("Project.DAL.Entities.OrderDetail", b =>
                {
                    b.HasOne("Project.DAL.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Project.DAL.Entities.Product", b =>
                {
                    b.HasOne("Project.DAL.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Project.DAL.Entities.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryID");

                    b.Navigation("Brand");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Project.DAL.Entities.ProductPicture", b =>
                {
                    b.HasOne("Project.DAL.Entities.Product", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Project.DAL.Entities.SubCategory", b =>
                {
                    b.HasOne("Project.DAL.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Project.DAL.Entities.Animal", b =>
                {
                    b.Navigation("AnimalPictures");
                });

            modelBuilder.Entity("Project.DAL.Entities.Blog", b =>
                {
                    b.Navigation("BlogPictures");
                });

            modelBuilder.Entity("Project.DAL.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Project.DAL.Entities.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Project.DAL.Entities.City", b =>
                {
                    b.Navigation("Distincts");
                });

            modelBuilder.Entity("Project.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Project.DAL.Entities.Product", b =>
                {
                    b.Navigation("ProductPictures");
                });

            modelBuilder.Entity("Project.DAL.Entities.SubCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
