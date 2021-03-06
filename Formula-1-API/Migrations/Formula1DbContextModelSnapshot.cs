﻿// <auto-generated />
using System;
using Formula_1_API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Formula_1_API.Migrations
{
    [DbContext(typeof(Formula1DbContext))]
    partial class Formula1DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Formula_1_API.Models.Circuit", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Lat");

                    b.Property<string>("Lng");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("Ref");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Circuits");
                });

            modelBuilder.Entity("Formula_1_API.Models.Constructor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.Property<string>("Ref");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Constructors");
                });

            modelBuilder.Entity("Formula_1_API.Models.ConstructorResult", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConstructorId");

                    b.Property<float>("Points");

                    b.Property<int>("RaceId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("ConstructorResults");
                });

            modelBuilder.Entity("Formula_1_API.Models.ConstructorStanding", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConstructorId");

                    b.Property<float>("Points");

                    b.Property<int>("Position");

                    b.Property<string>("PositionText");

                    b.Property<int>("RaceId");

                    b.Property<int>("Wins");

                    b.HasKey("Id");

                    b.ToTable("ConstructorStandings");
                });

            modelBuilder.Entity("Formula_1_API.Models.Driver", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Dob");

                    b.Property<string>("Forename");

                    b.Property<string>("Nationality");

                    b.Property<int?>("Number");

                    b.Property<string>("Ref");

                    b.Property<string>("Surname");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Formula_1_API.Models.DriverStanding", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DriverId");

                    b.Property<float>("Points");

                    b.Property<int>("Position");

                    b.Property<string>("PositionText");

                    b.Property<int>("RaceId");

                    b.Property<int>("Wins");

                    b.HasKey("Id");

                    b.ToTable("DriverStandings");
                });

            modelBuilder.Entity("Formula_1_API.Models.LapTime", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DriverId");

                    b.Property<string>("Lap");

                    b.Property<int>("Milliseconds");

                    b.Property<int>("Position");

                    b.Property<int>("RaceId");

                    b.Property<string>("Time");

                    b.HasKey("Id");

                    b.ToTable("LapTimes");
                });

            modelBuilder.Entity("Formula_1_API.Models.PitStop", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DriverId");

                    b.Property<string>("Duration");

                    b.Property<int?>("Lap");

                    b.Property<string>("Milliseconds");

                    b.Property<int?>("RaceId");

                    b.Property<int?>("Stop");

                    b.Property<string>("Time");

                    b.HasKey("Id");

                    b.ToTable("PitStops");
                });

            modelBuilder.Entity("Formula_1_API.Models.Qualification", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConstructorId");

                    b.Property<int>("DriverId");

                    b.Property<int>("Number");

                    b.Property<int>("Position");

                    b.Property<string>("Q1");

                    b.Property<string>("Q2");

                    b.Property<string>("Q3");

                    b.Property<int>("RaceId");

                    b.HasKey("Id");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("Formula_1_API.Models.Race", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CircuitId");

                    b.Property<string>("Date");

                    b.Property<string>("Name");

                    b.Property<string>("Round");

                    b.Property<string>("Time");

                    b.Property<string>("Url");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Formula_1_API.Models.RaceResult", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConstructorId");

                    b.Property<int>("DriverId");

                    b.Property<string>("FastestLap");

                    b.Property<string>("FastestLapSpeed");

                    b.Property<string>("FastestLapTime");

                    b.Property<int>("Grid");

                    b.Property<int>("Laps");

                    b.Property<string>("Milliseconds");

                    b.Property<string>("Number");

                    b.Property<float>("Points");

                    b.Property<string>("Position");

                    b.Property<int>("PositionOrder");

                    b.Property<string>("PositionText");

                    b.Property<int>("RaceId");

                    b.Property<string>("Rank");

                    b.Property<int>("StatusId");

                    b.Property<string>("Time");

                    b.HasKey("Id");

                    b.ToTable("RaceResults");
                });

            modelBuilder.Entity("Formula_1_API.Models.ResultStatus", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("ResultStatus");
                });

            modelBuilder.Entity("Formula_1_API.Models.Season", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });
#pragma warning restore 612, 618
        }
    }
}
