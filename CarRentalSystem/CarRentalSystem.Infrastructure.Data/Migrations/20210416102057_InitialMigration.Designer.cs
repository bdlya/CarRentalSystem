﻿using System;
using CarRentalSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Infrastructure.Data.Migrations
{
    [DbContext(typeof(CarRentalSystemContext))]
    [Migration("20210416102057_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            CurrentOrderId = 1,
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
                            CurrentOrderId = 2,
                            NumberOfSeats = 4,
                            PointOfRentalId = 1,
                            TransmissionType = "Automatic"
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John",
                            SurName = "Mars"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Arthur",
                            SurName = "Morgan"
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CurrentCustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PointOfRentalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentCustomerId");

                    b.HasIndex("PointOfRentalId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            CurrentCustomerId = 1,
                            EndDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            PointOfRentalId = 1,
                            StartDate = new DateTime(2021, 4, 16, 13, 20, 56, 678, DateTimeKind.Local).AddTicks(9770),
                            TotalCost = 0
                        },
                        new
                        {
                            Id = 2,
                            CarId = 2,
                            CurrentCustomerId = 2,
                            EndDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            PointOfRentalId = 1,
                            StartDate = new DateTime(2021, 4, 16, 13, 20, 56, 680, DateTimeKind.Local).AddTicks(1815),
                            TotalCost = 0
                        });
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

                    b.HasData(
                        new
                        {
                            AdditionalServiceId = 1,
                            OrderId = 1,
                            Id = 1
                        },
                        new
                        {
                            AdditionalServiceId = 2,
                            OrderId = 1,
                            Id = 2
                        },
                        new
                        {
                            AdditionalServiceId = 1,
                            OrderId = 2,
                            Id = 3
                        });
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

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Car", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Entities.Order", "CurrentOrder")
                        .WithOne("Car")
                        .HasForeignKey("CarRentalSystem.Domain.Entities.Car", "CurrentOrderId");

                    b.HasOne("CarRentalSystem.Domain.Entities.PointOfRental", "PointOfRental")
                        .WithMany("Cars")
                        .HasForeignKey("PointOfRentalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CurrentOrder");

                    b.Navigation("PointOfRental");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Order", b =>
                {
                    b.HasOne("CarRentalSystem.Domain.Entities.Customer", "CurrentCustomer")
                        .WithMany("Orders")
                        .HasForeignKey("CurrentCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalSystem.Domain.Entities.PointOfRental", "PointOfRental")
                        .WithMany("Orders")
                        .HasForeignKey("PointOfRentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentCustomer");

                    b.Navigation("PointOfRental");
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

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.AdditionalService", b =>
                {
                    b.Navigation("OrderAdditionalServices");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.Order", b =>
                {
                    b.Navigation("Car");

                    b.Navigation("OrderAdditionalServices");
                });

            modelBuilder.Entity("CarRentalSystem.Domain.Entities.PointOfRental", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
