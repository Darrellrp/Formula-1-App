﻿using System;
using Formula_1_App.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.IO;
using Formula_1_App.Utils;
using System.Collections.Generic;
using Formula_1_App.Utils.ClassMaps;
using Formula_1_App.Seeders;

namespace Formula_1_App.Context;

public class Formula1DbContext : DbContext
{
    public DbSet<Circuit> Circuits => Set<Circuit>();
    public DbSet<ConstructorResult> ConstructorResults => Set<ConstructorResult>();
    public DbSet<Constructor> Constructors => Set<Constructor>();
    public DbSet<ConstructorStanding> ConstructorStandings => Set<ConstructorStanding>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<DriverStanding> DriverStandings => Set<DriverStanding>();
    public DbSet<LapTime> LapTimes => Set<LapTime>();
    public DbSet<PitStop> PitStops => Set<PitStop>();
    public DbSet<Qualification> Qualifications => Set<Qualification>();
    public DbSet<Race> Races => Set<Race>();
    public DbSet<RaceResult> RaceResults => Set<RaceResult>();
    public DbSet<ResultStatus> ResultStatus => Set<ResultStatus>();
    public DbSet<Season> Seasons => Set<Season>();          
}