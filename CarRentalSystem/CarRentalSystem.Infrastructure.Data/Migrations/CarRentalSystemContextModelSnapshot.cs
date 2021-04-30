﻿// <auto-generated />
using System;
using CarRentalSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRentalSystem.Infrastructure.Data.Migrations
{
    [DbContext(typeof(CarRentalSystemContext))]
    partial class CarRentalSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.AdditionalService", b =>
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

                    b.ToTable("AdditionalServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 20,
                            Name = "Baby chair"
                        },
                        new
                        {
                            Id = 2,
                            Cost = 100,
                            Name = "Fill a full tank"
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Car", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AverageFuelConsumption = 100,
                            Brand = "Nissan",
                            CostPerHour = 1000,
                            NumberOfSeats = 2,
                            PointOfRentalId = 1,
                            TransmissionType = "Mechanic"
                        },
                        new
                        {
                            Id = 2,
                            AverageFuelConsumption = 200,
                            Brand = "Toyota",
                            CostPerHour = 500,
                            NumberOfSeats = 4,
                            PointOfRentalId = 1,
                            TransmissionType = "Automatic"
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Order", b =>
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

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentCustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.OrderAdditionalService", b =>
                {
                    b.Property<int>("AdditionalServiceId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("AdditionalServiceId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderAdditionalServices");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.PointOfRental", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "First Address",
                            City = "Minsk",
                            Country = "Belarus",
                            Name = "First Point"
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.RefreshToken", b =>
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

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.User", b =>
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
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Car", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Entities.Order", "CurrentOrder")
                        .WithOne("Car")
                        .HasForeignKey("CarRentalSystem.Domain.Entities.Car", "CurrentOrderId");

                    b.HasOne("CarRentalSystem.Domain.Entities.PointOfRental", "PointOfRental")
                        .WithMany("Cars")
                        .HasForeignKey("PointOfRentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentOrder");

                    b.Navigation("PointOfRental");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Order", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Entities.User", "CurrentCustomer")
                        .WithMany("Orders")
                        .HasForeignKey("CurrentCustomerId");

                    b.Navigation("CurrentCustomer");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.OrderAdditionalService", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Entities.AdditionalService", "AdditionalService")
                        .WithMany("OrderAdditionalServices")
                        .HasForeignKey("AdditionalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalSystem.Domain.Entities.Order", "Order")
                        .WithMany("OrderAdditionalServices")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalService");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.User", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Entities.RefreshToken", "RefreshToken")
                        .WithOne("User")
                        .HasForeignKey("CarRentalSystem.Domain.Entities.User", "RefreshTokenId");

                    b.Navigation("RefreshToken");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.AdditionalService", b =>
                {
                    b.Navigation("OrderAdditionalServices");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Order", b =>
                {
                    b.Navigation("Car");

                    b.Navigation("OrderAdditionalServices");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.PointOfRental", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.RefreshToken", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
