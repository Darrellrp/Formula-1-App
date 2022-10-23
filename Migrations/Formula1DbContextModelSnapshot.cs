﻿// <auto-generated />
using System;
using Formula_1_App.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Formula_1_App.Migrations
{
    [DbContext(typeof(Formula1DbContext))]
    partial class Formula1DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Formula_1_App.Models.Circuit", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lat")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lng")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ref")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Circuits");
                });

            modelBuilder.Entity("Formula_1_App.Models.Constructor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ref")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Constructors");
                });

            modelBuilder.Entity("Formula_1_App.Models.ConstructorResult", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ConstructorId")
                        .HasColumnType("int");

                    b.Property<float>("Points")
                        .HasColumnType("float");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ConstructorResults");
                });

            modelBuilder.Entity("Formula_1_App.Models.ConstructorStanding", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ConstructorId")
                        .HasColumnType("int");

                    b.Property<float>("Points")
                        .HasColumnType("float");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("PositionText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ConstructorStandings");
                });

            modelBuilder.Entity("Formula_1_App.Models.Driver", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Dob")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Forename")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Ref")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Formula_1_App.Models.DriverStanding", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<float>("Points")
                        .HasColumnType("float");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("PositionText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DriverStandings");
                });

            modelBuilder.Entity("Formula_1_App.Models.LapTime", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("Lap")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Milliseconds")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LapTimes");
                });

            modelBuilder.Entity("Formula_1_App.Models.PitStop", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Lap")
                        .HasColumnType("int");

                    b.Property<string>("Milliseconds")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("RaceId")
                        .HasColumnType("int");

                    b.Property<int?>("Stop")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PitStops");
                });

            modelBuilder.Entity("Formula_1_App.Models.Qualification", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ConstructorId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Q1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Q2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Q3")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("Formula_1_App.Models.Race", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CircuitId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Round")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Formula_1_App.Models.RaceResult", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ConstructorId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("FastestLap")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FastestLapSpeed")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FastestLapTime")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Grid")
                        .HasColumnType("int");

                    b.Property<int>("Laps")
                        .HasColumnType("int");

                    b.Property<string>("Milliseconds")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Points")
                        .HasColumnType("float");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PositionOrder")
                        .HasColumnType("int");

                    b.Property<string>("PositionText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RaceResults");
                });

            modelBuilder.Entity("Formula_1_App.Models.ResultStatus", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ResultStatus");
                });

            modelBuilder.Entity("Formula_1_App.Models.Season", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });
#pragma warning restore 612, 618
        }
    }
}