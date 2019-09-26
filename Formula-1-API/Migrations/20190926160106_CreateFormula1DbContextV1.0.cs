using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula_1_API.Migrations
{
    public partial class CreateFormula1DbContextV10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Circuits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ref = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Lng = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Constructor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ref = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constructor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstructorResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(nullable: false),
                    ConstructorId = table.Column<int>(nullable: false),
                    Points = table.Column<float>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructorResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstructorStandings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(nullable: false),
                    Points = table.Column<float>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    PositionText = table.Column<string>(nullable: true),
                    Wins = table.Column<int>(nullable: false),
                    ConstructorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructorStandings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ref = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Forename = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Dob = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverStandings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(nullable: false),
                    Points = table.Column<float>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    PositionText = table.Column<string>(nullable: true),
                    Wins = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverStandings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LapTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    Lap = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Milliseconds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LapTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PitStop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(nullable: true),
                    DriverId = table.Column<int>(nullable: true),
                    Stop = table.Column<int>(nullable: true),
                    Lap = table.Column<int>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Milliseconds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitStop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    ConstructorId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Q1 = table.Column<string>(nullable: true),
                    Q2 = table.Column<string>(nullable: true),
                    Q3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(nullable: false),
                    ConstructorId = table.Column<int>(nullable: false),
                    Points = table.Column<float>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Grid = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    PositionText = table.Column<string>(nullable: true),
                    PositionOrder = table.Column<int>(nullable: false),
                    Laps = table.Column<int>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Milliseconds = table.Column<string>(nullable: true),
                    FastestLap = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    FastestLapTime = table.Column<string>(nullable: true),
                    FastestLapSpeed = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<string>(nullable: true),
                    Round = table.Column<string>(nullable: true),
                    CircuitId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Circuits",
                columns: new[] { "Id", "Country", "Lat", "Lng", "Location", "Name", "Ref", "Url" },
                values: new object[,]
                {
                    { 1, "Australia", "-37.8497", "144.968", "Melbourne", "Albert Park Grand Prix Circuit", "albert_park", "http://en.wikipedia.org/wiki/Melbourne_Grand_Prix_Circuit" },
                    { 2, "Malaysia", "2.76083", "101.738", "Kuala Lumpur", "Sepang International Circuit", "sepang", "http://en.wikipedia.org/wiki/Sepang_International_Circuit" },
                    { 3, "Bahrain", "26.0325", "50.5106", "Sakhir", "Bahrain International Circuit", "bahrain", "http://en.wikipedia.org/wiki/Bahrain_International_Circuit" },
                    { 4, "Spain", "41.57", "2.26111", "Montmel�_", "Circuit de Barcelona-Catalunya", "catalunya", "http://en.wikipedia.org/wiki/Circuit_de_Barcelona-Catalunya" },
                    { 5, "Turkey", "40.9517", "29.405", "Istanbul", "Istanbul Park", "istanbul", "http://en.wikipedia.org/wiki/Istanbul_Park" },
                    { 6, "Monaco", "43.7347", "7.42056", "Monte-Carlo", "Circuit de Monaco", "monaco", "http://en.wikipedia.org/wiki/Circuit_de_Monaco" },
                    { 7, "Canada", "45.5", "-73.5228", "Montreal", "Circuit Gilles Villeneuve", "villeneuve", "http://en.wikipedia.org/wiki/Circuit_Gilles_Villeneuve" },
                    { 8, "France", "46.8642", "3.16361", "Magny Cours", "Circuit de Nevers Magny-Cours", "magny_cours", "http://en.wikipedia.org/wiki/Circuit_de_Nevers_Magny-Cours" },
                    { 9, "UK", "52.0786", "-1.01694", "Silverstone", "Silverstone Circuit", "silverstone", "http://en.wikipedia.org/wiki/Silverstone_Circuit" },
                    { 10, "Germany", "49.3278", "8.56583", "Hockenheim", "Hockenheimring", "hockenheimring", "http://en.wikipedia.org/wiki/Hockenheimring" }
                });

            migrationBuilder.InsertData(
                table: "Constructor",
                columns: new[] { "Id", "Name", "Nationality", "Ref", "Url" },
                values: new object[,]
                {
                    { 10, "Force India", "Indian", "force_india", "http://en.wikipedia.org/wiki/Force_India" },
                    { 9, "Red Bull", "Austrian", "red_bull", "http://en.wikipedia.org/wiki/Red_Bull_Racing" },
                    { 7, "Toyota", "Japanese", "toyota", "http://en.wikipedia.org/wiki/Toyota_Racing" },
                    { 6, "Ferrari", "Italian", "ferrari", "http://en.wikipedia.org/wiki/Scuderia_Ferrari" },
                    { 8, "Super Aguri", "Japanese", "super_aguri", "http://en.wikipedia.org/wiki/Super_Aguri_F1" },
                    { 4, "Renault", "French", "renault", "http://en.wikipedia.org/wiki/Renault_F1" },
                    { 3, "Williams", "British", "williams", "http://en.wikipedia.org/wiki/Williams_Grand_Prix_Engineering" },
                    { 2, "BMW Sauber", "German", "bmw_sauber", "http://en.wikipedia.org/wiki/BMW_Sauber" },
                    { 1, "McLaren", "British", "mclaren", "http://en.wikipedia.org/wiki/McLaren" },
                    { 5, "Toro Rosso", "Italian", "toro_rosso", "http://en.wikipedia.org/wiki/Scuderia_Toro_Rosso" }
                });

            migrationBuilder.InsertData(
                table: "ConstructorResults",
                columns: new[] { "Id", "ConstructorId", "Points", "RaceId", "Status" },
                values: new object[,]
                {
                    { 10, 10, 0f, 18, "NULL" },
                    { 9, 9, 0f, 18, "NULL" },
                    { 8, 8, 0f, 18, "NULL" },
                    { 7, 7, 0f, 18, "NULL" },
                    { 6, 6, 1f, 18, "NULL" },
                    { 5, 5, 2f, 18, "NULL" },
                    { 3, 3, 9f, 18, "NULL" },
                    { 2, 2, 8f, 18, "NULL" },
                    { 1, 1, 14f, 18, "NULL" },
                    { 4, 4, 5f, 18, "NULL" }
                });

            migrationBuilder.InsertData(
                table: "ConstructorStandings",
                columns: new[] { "Id", "ConstructorId", "Points", "Position", "PositionText", "RaceId", "Wins" },
                values: new object[,]
                {
                    { 7, 1, 24f, 1, "1", 19, 1 },
                    { 10, 4, 6f, 5, "5", 19, 0 },
                    { 9, 3, 9f, 4, "4", 19, 0 },
                    { 8, 2, 19f, 2, "2", 19, 0 },
                    { 6, 6, 1f, 6, "6", 18, 0 },
                    { 3, 3, 9f, 2, "2", 18, 0 },
                    { 4, 4, 5f, 4, "4", 18, 0 },
                    { 2, 2, 8f, 3, "3", 18, 0 },
                    { 1, 1, 14f, 1, "1", 18, 1 },
                    { 5, 5, 2f, 5, "5", 18, 0 }
                });

            migrationBuilder.InsertData(
                table: "DriverStandings",
                columns: new[] { "Id", "DriverId", "Points", "Position", "PositionText", "RaceId", "Wins" },
                values: new object[,]
                {
                    { 10, 2, 11f, 3, "3", 19, 0 },
                    { 9, 1, 14f, 1, "1", 19, 1 },
                    { 8, 8, 1f, 8, "8", 18, 0 },
                    { 7, 7, 2f, 7, "7", 18, 0 },
                    { 6, 6, 3f, 6, "6", 18, 0 },
                    { 5, 5, 4f, 5, "5", 18, 0 },
                    { 4, 4, 5f, 4, "4", 18, 0 },
                    { 3, 3, 6f, 3, "3", 18, 0 },
                    { 2, 2, 8f, 2, "2", 18, 0 },
                    { 1, 1, 10f, 1, "1", 18, 1 }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Code", "Dob", "Forename", "Nationality", "Number", "Ref", "Surname", "Url" },
                values: new object[,]
                {
                    { 9, "KUB", "07/12/1984", "Robert", "Polish", null, "kubica", "Kubica", "http://en.wikipedia.org/wiki/Robert_Kubica" },
                    { 8, "RAI", "17/10/1979", "Kimi", "Finnish", 7, "raikkonen", "R�_ikk̦nen", "http://en.wikipedia.org/wiki/Kimi_R%C3%A4ikk%C3%B6nen" },
                    { 7, "BOU", "28/02/1979", "S̩bastien", "French", null, "bourdais", "Bourdais", "http://en.wikipedia.org/wiki/S%C3%A9bastien_Bourdais" },
                    { 6, "NAK", "11/01/1985", "Kazuki", "Japanese", null, "nakajima", "Nakajima", "http://en.wikipedia.org/wiki/Kazuki_Nakajima" },
                    { 5, "KOV", "19/10/1981", "Heikki", "Finnish", null, "kovalainen", "Kovalainen", "http://en.wikipedia.org/wiki/Heikki_Kovalainen" },
                    { 4, "ALO", "29/07/1981", "Fernando", "Spanish", 14, "alonso", "Alonso", "http://en.wikipedia.org/wiki/Fernando_Alonso" },
                    { 3, "ROS", "27/06/1985", "Nico", "German", 6, "rosberg", "Rosberg", "http://en.wikipedia.org/wiki/Nico_Rosberg" },
                    { 2, "HEI", "10/05/1977", "Nick", "German", null, "heidfeld", "Heidfeld", "http://en.wikipedia.org/wiki/Nick_Heidfeld" },
                    { 1, "HAM", "07/01/1985", "Lewis", "British", 44, "hamilton", "Hamilton", "http://en.wikipedia.org/wiki/Lewis_Hamilton" },
                    { 10, "GLO", "18/03/1982", "Timo", "German", null, "glock", "Glock", "http://en.wikipedia.org/wiki/Timo_Glock" }
                });

            migrationBuilder.InsertData(
                table: "LapTimes",
                columns: new[] { "Id", "DriverId", "Lap", "Milliseconds", "Position", "RaceId", "Time" },
                values: new object[,]
                {
                    { 7, 20, "7", 92502, 1, 841, "1:32.502" },
                    { 10, 20, "10", 92572, 1, 841, "1:32.572" },
                    { 9, 20, "9", 93240, 1, 841, "1:33.240" },
                    { 8, 20, "8", 92537, 1, 841, "1:32.537" },
                    { 6, 20, "6", 92605, 1, 841, "1:32.605" },
                    { 5, 20, "5", 92342, 1, 841, "1:32.342" },
                    { 4, 20, "4", 92803, 1, 841, "1:32.803" },
                    { 3, 20, "3", 92713, 1, 841, "1:32.713" },
                    { 2, 20, "2", 93006, 1, 841, "1:33.006" },
                    { 1, 20, "1", 98109, 1, 841, "1:38.109" }
                });

            migrationBuilder.InsertData(
                table: "PitStop",
                columns: new[] { "Id", "DriverId", "Duration", "Lap", "Milliseconds", "RaceId", "Stop", "Time" },
                values: new object[,]
                {
                    { 10, 67, "25.342", 15, "25342", 841, 1, "17:27:34" },
                    { 9, 816, "25.259", 14, "25259", 841, 1, "17:26:50" },
                    { 8, 814, "24.863", 14, "24863", 841, 1, "17:26:03" },
                    { 7, 20, "22.603", 14, "22603", 841, 1, "17:25:17" },
                    { 6, 22, "23.643", 13, "23643", 841, 1, "17:24:29" },
                    { 4, 4, "23.251", 12, "23251", 841, 1, "17:22:34" },
                    { 3, 17, "23.426", 11, "23426", 841, 1, "17:20:48" },
                    { 2, 30, "25.021", 1, "25021", 841, 1, "17:05:52" },
                    { 1, 153, "26.898", 1, "26898", 841, 1, "17:05:23" },
                    { 5, 13, "23.842", 13, "23842", 841, 1, "17:24:10" }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "ConstructorId", "DriverId", "Number", "Position", "Q1", "Q2", "Q3", "RaceId" },
                values: new object[,]
                {
                    { 7, 3, 3, 7, 7, "1:26.295", "1:26.059", "1:28.687", 18 },
                    { 10, 5, 20, 15, 10, "1:26.702", "1:25.842", "NULL", 18 },
                    { 9, 7, 10, 12, 9, "1:26.919", "1:26.164", "1:29.593", 18 },
                    { 8, 9, 14, 9, 8, "1:26.381", "1:26.063", "1:29.041", 18 },
                    { 6, 7, 15, 11, 6, "1:26.427", "1:26.101", "1:28.527", 18 },
                    { 3, 1, 5, 23, 3, "1:25.664", "1:25.452", "1:27.079", 18 },
                    { 4, 6, 13, 2, 4, "1:25.994", "1:25.691", "1:27.178", 18 },
                    { 2, 2, 9, 4, 2, "1:26.103", "1:25.315", "1:26.869", 18 },
                    { 1, 1, 1, 22, 1, "1:26.572", "1:25.187", "1:26.714", 18 },
                    { 5, 2, 2, 3, 5, "1:25.960", "1:25.518", "1:27.236", 18 }
                });

            migrationBuilder.InsertData(
                table: "RaceResults",
                columns: new[] { "Id", "ConstructorId", "DriverId", "FastestLap", "FastestLapSpeed", "FastestLapTime", "Grid", "Laps", "Milliseconds", "Number", "Points", "Position", "PositionOrder", "PositionText", "RaceId", "Rank", "StatusId", "Time" },
                values: new object[,]
                {
                    { 2, 2, 2, "41", "217.586", "01:27.7", 5, 58, "5696094", "3", 8f, "2", 2, "2", 18, "3", 1, "5.478" },
                    { 10, 7, 10, "23", "213.166", "01:29.6", 18, 43, "", "12", 0f, "", 10, "R", 18, "13", 3, "" },
                    { 9, 2, 9, "15", "215.1", "01:28.8", 2, 47, "", "4", 0f, "", 9, "R", 18, "9", 4, "" },
                    { 8, 6, 8, "20", "217.18", "01:27.9", 15, 53, "", "1", 1f, "8", 8, "8", 18, "4", 5, "" },
                    { 7, 5, 7, "22", "213.224", "01:29.5", 17, 55, "", "14", 2f, "7", 7, "7", 18, "12", 5, "" },
                    { 6, 3, 6, "50", "212.974", "01:29.6", 13, 57, "", "8", 3f, "6", 6, "6", 18, "14", 11, "" },
                    { 5, 1, 5, "43", "218.385", "01:27.4", 3, 58, "5708630", "23", 4f, "5", 5, "5", 18, "1", 1, "18.014" },
                    { 4, 4, 4, "58", "215.464", "01:28.6", 11, 58, "5707797", "5", 5f, "4", 4, "4", 18, "7", 1, "17.181" },
                    { 3, 3, 3, "41", "216.719", "01:28.1", 7, 58, "5698779", "7", 6f, "3", 3, "3", 18, "5", 1, "8.163" },
                    { 1, 1, 1, "39", "218.3", "01:27.5", 1, 58, "5690616", "22", 10f, "1", 1, "1", 18, "2", 1, "34:50.6" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "CircuitId", "Date", "Name", "Round", "Time", "Url", "Year" },
                values: new object[,]
                {
                    { 8, 9, "2009-06-21", "British Grand Prix", "8", "12:00:00", "http://en.wikipedia.org/wiki/2009_British_Grand_Prix", "2009" },
                    { 9, 20, "2009-07-12", "German Grand Prix", "9", "12:00:00", "http://en.wikipedia.org/wiki/2009_German_Grand_Prix", "2009" },
                    { 7, 5, "2009-06-07", "Turkish Grand Prix", "7", "12:00:00", "http://en.wikipedia.org/wiki/2009_Turkish_Grand_Prix", "2009" },
                    { 6, 6, "2009-05-24", "Monaco Grand Prix", "6", "12:00:00", "http://en.wikipedia.org/wiki/2009_Monaco_Grand_Prix", "2009" },
                    { 5, 4, "2009-05-10", "Spanish Grand Prix", "5", "12:00:00", "http://en.wikipedia.org/wiki/2009_Spanish_Grand_Prix", "2009" },
                    { 4, 3, "2009-04-26", "Bahrain Grand Prix", "4", "12:00:00", "http://en.wikipedia.org/wiki/2009_Bahrain_Grand_Prix", "2009" },
                    { 3, 17, "2009-04-19", "Chinese Grand Prix", "3", "07:00:00", "http://en.wikipedia.org/wiki/2009_Chinese_Grand_Prix", "2009" },
                    { 2, 2, "2009-04-05", "Malaysian Grand Prix", "2", "09:00:00", "http://en.wikipedia.org/wiki/2009_Malaysian_Grand_Prix", "2009" },
                    { 1, 1, "2009-03-29", "Australian Grand Prix", "1", "06:00:00", "http://en.wikipedia.org/wiki/2009_Australian_Grand_Prix", "2009" },
                    { 10, 11, "2009-07-26", "Hungarian Grand Prix", "10", "12:00:00", "http://en.wikipedia.org/wiki/2009_Hungarian_Grand_Prix", "2009" }
                });

            migrationBuilder.InsertData(
                table: "ResultStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 10, "Electrical" },
                    { 9, "Hydraulics" },
                    { 8, "Clutch" },
                    { 7, "Transmission" },
                    { 6, "Gearbox" },
                    { 4, "Collision" },
                    { 3, "Accident" },
                    { 2, "Disqualified" },
                    { 1, "Finished" },
                    { 5, "Engine" }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "Url", "Year" },
                values: new object[,]
                {
                    { 9, "http://en.wikipedia.org/wiki/2001_Formula_One_season", 2001 },
                    { 1, "http://en.wikipedia.org/wiki/2009_Formula_One_season", 2009 },
                    { 2, "http://en.wikipedia.org/wiki/2008_Formula_One_season", 2008 },
                    { 3, "http://en.wikipedia.org/wiki/2007_Formula_One_season", 2007 },
                    { 4, "http://en.wikipedia.org/wiki/2006_Formula_One_season", 2006 },
                    { 5, "http://en.wikipedia.org/wiki/2005_Formula_One_season", 2005 },
                    { 6, "http://en.wikipedia.org/wiki/2004_Formula_One_season", 2004 },
                    { 7, "http://en.wikipedia.org/wiki/2003_Formula_One_season", 2003 },
                    { 8, "http://en.wikipedia.org/wiki/2002_Formula_One_season", 2002 },
                    { 10, "http://en.wikipedia.org/wiki/2000_Formula_One_season", 2000 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Circuits");

            migrationBuilder.DropTable(
                name: "Constructor");

            migrationBuilder.DropTable(
                name: "ConstructorResults");

            migrationBuilder.DropTable(
                name: "ConstructorStandings");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "DriverStandings");

            migrationBuilder.DropTable(
                name: "LapTimes");

            migrationBuilder.DropTable(
                name: "PitStop");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "RaceResults");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "ResultStatus");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
