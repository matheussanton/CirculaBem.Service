﻿// <auto-generated />
using System;
using CirculaBem.Service.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CirculaBem.Service.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241130194158_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.AddressEntityDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("cep");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("complement");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("neighborhood");

                    b.Property<short>("Number")
                        .HasColumnType("smallint")
                        .HasColumnName("number");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("street");

                    b.Property<string>("UserRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("userregistrationnumber");

                    b.HasKey("Id");

                    b.HasIndex("UserRegistrationNumber");

                    b.ToTable("adresses");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.CategoryEntityDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.ProductAvailabilityEntityDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<short>("Availability")
                        .HasColumnType("int2")
                        .HasColumnName("availability");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("productid");

                    b.HasKey("Id");

                    b.ToTable("productavailability");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.ProductEntityDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("categoryid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("OwnerRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("ownerregistrationnumber");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(8, 2)")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerRegistrationNumber");

                    b.ToTable("product");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.ProductImageEntityDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("imageurl");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("productid");

                    b.HasKey("Id");

                    b.ToTable("productimage");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.RentEntityDomain", b =>
                {
                    b.Property<string>("UserRegistrationNumber")
                        .HasColumnType("varchar")
                        .HasColumnName("userRegistrationNumber");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("productid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.HasKey("UserRegistrationNumber", "ProductId", "StartDate", "EndDate");

                    b.HasIndex("ProductId");

                    b.ToTable("rent");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.UserEntityDomain", b =>
                {
                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("varchar")
                        .HasColumnName("registrationnumber");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("firstname");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bool")
                        .HasColumnName("isverified");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("password");

                    b.HasKey("RegistrationNumber");

                    b.ToTable("user");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.AddressEntityDomain", b =>
                {
                    b.HasOne("CirculaBem.Service.Domain.Entities.UserEntityDomain", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserRegistrationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.ProductEntityDomain", b =>
                {
                    b.HasOne("CirculaBem.Service.Domain.Entities.CategoryEntityDomain", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CirculaBem.Service.Domain.Entities.UserEntityDomain", "User")
                        .WithMany("Products")
                        .HasForeignKey("OwnerRegistrationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.RentEntityDomain", b =>
                {
                    b.HasOne("CirculaBem.Service.Domain.Entities.ProductEntityDomain", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CirculaBem.Service.Domain.Entities.UserEntityDomain", "User")
                        .WithMany()
                        .HasForeignKey("UserRegistrationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.CategoryEntityDomain", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CirculaBem.Service.Domain.Entities.UserEntityDomain", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
