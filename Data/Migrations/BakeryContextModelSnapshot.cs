﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bageriapi.Data.Migrations
{
    [DbContext(typeof(BakeryContext))]
    partial class BakeryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArticleNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ArticleNumber = "1001",
                            Name = "Mjöl"
                        },
                        new
                        {
                            ProductId = 2,
                            ArticleNumber = "1002",
                            Name = "Socker"
                        });
                });

            modelBuilder.Entity("Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            Address = "Gata 1",
                            ContactPerson = "Lilja",
                            Email = "lilja@liten.se",
                            Name = "Bageri liten",
                            PhoneNumber = "0701234567"
                        },
                        new
                        {
                            SupplierId = 2,
                            Address = "Gata 2",
                            ContactPerson = "Dalija",
                            Email = "dalija@mat.se",
                            Name = "Matleverantör AB",
                            PhoneNumber = "0707654321"
                        });
                });

            modelBuilder.Entity("SupplierProduct", b =>
                {
                    b.Property<int>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PricePerKg")
                        .HasColumnType("TEXT");

                    b.HasKey("SupplierId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("SupplierProducts");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            ProductId = 1,
                            PricePerKg = 15.50m
                        },
                        new
                        {
                            SupplierId = 2,
                            ProductId = 1,
                            PricePerKg = 14.00m
                        },
                        new
                        {
                            SupplierId = 1,
                            ProductId = 2,
                            PricePerKg = 10.00m
                        });
                });

            modelBuilder.Entity("SupplierProduct", b =>
                {
                    b.HasOne("Product", "Product")
                        .WithMany("SupplierProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Supplier", "Supplier")
                        .WithMany("SupplierProducts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Navigation("SupplierProducts");
                });

            modelBuilder.Entity("Supplier", b =>
                {
                    b.Navigation("SupplierProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
