﻿// <auto-generated />
using System;
using CabManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CabManagement.Migrations
{
    [DbContext(typeof(CabManagementDBContext))]
    [Migration("20221004031331_initialmigration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CabManagement.Models.Cars", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TravelManagerManagerId")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("TravelManagerManagerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CabManagement.Models.Route", b =>
                {
                    b.Property<int>("RouteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TravelManagerManagerId")
                        .HasColumnType("int");

                    b.HasKey("RouteID");

                    b.HasIndex("CarId");

                    b.HasIndex("TravelManagerManagerId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("CabManagement.Models.TravelManager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManagerId");

                    b.ToTable("TravelManagers");
                });

            modelBuilder.Entity("CabManagement.Models.driver", b =>
                {
                    b.Property<int>("driverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarsCarId")
                        .HasColumnType("int");

                    b.Property<int?>("TravelManagerManagerId")
                        .HasColumnType("int");

                    b.Property<int>("driverAge")
                        .HasColumnType("int");

                    b.Property<string>("driverGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("driverName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("driverId");

                    b.HasIndex("CarsCarId");

                    b.HasIndex("TravelManagerManagerId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("CabManagement.Models.Cars", b =>
                {
                    b.HasOne("CabManagement.Models.TravelManager", null)
                        .WithMany("cars")
                        .HasForeignKey("TravelManagerManagerId");
                });

            modelBuilder.Entity("CabManagement.Models.Route", b =>
                {
                    b.HasOne("CabManagement.Models.Cars", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("CabManagement.Models.TravelManager", null)
                        .WithMany("Routes")
                        .HasForeignKey("TravelManagerManagerId");
                });

            modelBuilder.Entity("CabManagement.Models.driver", b =>
                {
                    b.HasOne("CabManagement.Models.Cars", null)
                        .WithMany("Driver")
                        .HasForeignKey("CarsCarId");

                    b.HasOne("CabManagement.Models.TravelManager", null)
                        .WithMany("drivers")
                        .HasForeignKey("TravelManagerManagerId");
                });
#pragma warning restore 612, 618
        }
    }
}
