﻿// <auto-generated />
using System;
using CarRentalSystem.Persistence.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRentalSystem.Persistence.Data.Migrations
{
    [DbContext(typeof(CarRentalSystemContext))]
    [Migration("20210504073702_SeedAdminOwnerData")]
    partial class SeedAdminOwnerData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.AdditionalWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdditionalWorks");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AverageFuelConsumption")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CostPerHour")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentOrderId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("PointOfRentalId")
                        .HasColumnType("int");

                    b.Property<string>("TransmissionType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentOrderId")
                        .IsUnique()
                        .HasFilter("[CurrentOrderId] IS NOT NULL");

                    b.HasIndex("PointOfRentalId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentCustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentCustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.PointOfRental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PointOfRentals");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("RefreshTokenId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RefreshTokenId")
                        .IsUnique()
                        .HasFilter("[RefreshTokenId] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "adminOwner",
                            Name = "Admin",
                            PasswordHash = new byte[] { 236, 83, 207, 234, 107, 183, 178, 235, 166, 37, 73, 3, 69, 250, 25, 139, 237, 88, 24, 144, 154, 43, 140, 3, 116, 205, 159, 235, 172, 100, 166, 237, 130, 13, 39, 28, 149, 131, 118, 215, 27, 116, 66, 237, 58, 51, 125, 55, 77, 87, 40, 208, 230, 112, 4, 132, 61, 19, 104, 240, 224, 48, 57, 72 },
                            PasswordSalt = new byte[] { 14, 110, 170, 218, 186, 70, 217, 136, 77, 83, 71, 165, 242, 201, 18, 58, 197, 46, 178, 62, 217, 12, 246, 81, 148, 6, 55, 21, 83, 24, 91, 64, 221, 67, 186, 42, 152, 164, 203, 128, 99, 178, 87, 160, 70, 142, 68, 61, 111, 110, 161, 230, 190, 153, 178, 119, 8, 119, 183, 168, 122, 125, 106, 142, 146, 234, 114, 54, 118, 9, 194, 13, 246, 243, 42, 205, 101, 144, 99, 68, 131, 24, 142, 82, 208, 85, 98, 236, 44, 117, 123, 69, 114, 57, 102, 45, 57, 171, 32, 170, 83, 20, 68, 93, 239, 227, 58, 163, 20, 108, 120, 212, 227, 228, 37, 97, 236, 229, 143, 16, 184, 15, 52, 19, 25, 168, 4, 217 },
                            Role = "AdminOwner",
                            SurName = "Owner"
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Support.OrderAdditionalWork", b =>
                {
                    b.Property<int>("AdditionalServiceId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("AdditionalServiceId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderAdditionalWorks");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Support.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.Car", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Entities.Main.Order", "CurrentOrder")
                        .WithOne("Car")
                        .HasForeignKey("CarRentalSystem.Domain.Entities.Main.Car", "CurrentOrderId");

                    b.HasOne("CarRentalSystem.Domain.Entities.Main.PointOfRental", "PointOfRental")
                        .WithMany("Cars")
                        .HasForeignKey("PointOfRentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentOrder");

                    b.Navigation("PointOfRental");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.Order", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Entities.Main.User", "CurrentCustomer")
                        .WithMany("Orders")
                        .HasForeignKey("CurrentCustomerId");

                    b.Navigation("CurrentCustomer");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.User", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Entities.Support.RefreshToken", "RefreshToken")
                        .WithOne("User")
                        .HasForeignKey("CarRentalSystem.Domain.Entities.Main.User", "RefreshTokenId");

                    b.Navigation("RefreshToken");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Support.OrderAdditionalWork", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Entities.Main.AdditionalWork", "AdditionalService")
                        .WithMany("OrderAdditionalWorks")
                        .HasForeignKey("AdditionalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalSystem.Domain.Entities.Main.Order", "Order")
                        .WithMany("OrderAdditionalWorks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalService");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.AdditionalWork", b =>
                {
                    b.Navigation("OrderAdditionalWorks");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.Order", b =>
                {
                    b.Navigation("Car");

                    b.Navigation("OrderAdditionalWorks");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.PointOfRental", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Main.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Support.RefreshToken", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}