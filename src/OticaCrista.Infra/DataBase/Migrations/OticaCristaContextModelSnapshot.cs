﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OticaCrista.Infra.DataBase;

#nullable disable

namespace OticaCrista.Infra.Migrations
{
    [DbContext(typeof(OticaCristaContext))]
    partial class OticaCristaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProductModelSaleModel", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("SalesId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "SalesId");

                    b.HasIndex("SalesId");

                    b.ToTable("ProductModelSaleModel");
                });

            modelBuilder.Entity("SaleModelServiceModel", b =>
                {
                    b.Property<int>("SalesId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("SalesId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("SaleModelServiceModel");
                });

            modelBuilder.Entity("SistOtica.Models.Client.ClientContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("SistOtica.Models.Client.ClientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressComplement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Negativated")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ocupation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SpouseName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SistOtica.Models.Client.ClientReferences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("References");
                });

            modelBuilder.Entity("SistOtica.Models.Product.BrandModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SistOtica.Models.Product.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Addition")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SistOtica.Models.Sale.PaymentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("double");

                    b.Property<double>("DownPayment")
                        .HasColumnType("double");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("Installments")
                        .HasColumnType("int");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SaleId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SistOtica.Models.Sale.SaleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Adicao")
                        .HasColumnType("double");

                    b.Property<string>("Book")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("CentroOtico")
                        .HasColumnType("double");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Discount")
                        .HasColumnType("double");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("FinalPrice")
                        .HasColumnType("double");

                    b.Property<int>("ItemQt")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("OdCilindrico")
                        .HasColumnType("double");

                    b.Property<double>("OdDnp")
                        .HasColumnType("double");

                    b.Property<double>("OdEixo")
                        .HasColumnType("double");

                    b.Property<double>("OdEsferico")
                        .HasColumnType("double");

                    b.Property<double>("OeCilindrico")
                        .HasColumnType("double");

                    b.Property<double>("OeDnp")
                        .HasColumnType("double");

                    b.Property<double>("OeEixo")
                        .HasColumnType("double");

                    b.Property<double>("OeEsferico")
                        .HasColumnType("double");

                    b.Property<string>("Page")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ref")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("SaleDate")
                        .HasColumnType("date");

                    b.Property<int>("ServiceOrder")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("SistOtica.Models.Service.ServiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ProductModelSaleModel", b =>
                {
                    b.HasOne("SistOtica.Models.Product.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistOtica.Models.Sale.SaleModel", null)
                        .WithMany()
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaleModelServiceModel", b =>
                {
                    b.HasOne("SistOtica.Models.Sale.SaleModel", null)
                        .WithMany()
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistOtica.Models.Service.ServiceModel", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistOtica.Models.Client.ClientContact", b =>
                {
                    b.HasOne("SistOtica.Models.Client.ClientModel", "Client")
                        .WithMany("Contacts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SistOtica.Models.Client.ClientReferences", b =>
                {
                    b.HasOne("SistOtica.Models.Client.ClientModel", "Client")
                        .WithMany("References")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SistOtica.Models.Product.ProductModel", b =>
                {
                    b.HasOne("SistOtica.Models.Product.BrandModel", "brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("brand");
                });

            modelBuilder.Entity("SistOtica.Models.Sale.PaymentModel", b =>
                {
                    b.HasOne("SistOtica.Models.Sale.SaleModel", "Sale")
                        .WithOne("Payment")
                        .HasForeignKey("SistOtica.Models.Sale.PaymentModel", "SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("SistOtica.Models.Sale.SaleModel", b =>
                {
                    b.HasOne("SistOtica.Models.Client.ClientModel", "Client")
                        .WithMany("Sales")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SistOtica.Models.Client.ClientModel", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("References");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("SistOtica.Models.Product.BrandModel", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SistOtica.Models.Sale.SaleModel", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
