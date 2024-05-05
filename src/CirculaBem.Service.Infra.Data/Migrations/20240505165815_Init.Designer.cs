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
    [Migration("20240505165815_Init")]
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

                    b.Property<string>("OwnerRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("ownerregistrationnumber");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(8, 2)")
                        .HasColumnName("price");

                    b.HasKey("Id");

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
#pragma warning restore 612, 618
        }
    }
}
