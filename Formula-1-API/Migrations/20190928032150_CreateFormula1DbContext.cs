using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula_1_API.Migrations
{
    public partial class CreateFormula1DbContext : Migration
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
                name: "Constructors",
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
                    table.PrimaryKey("PK_Constructors", x => x.Id);
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
                name: "PitStops",
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
                    table.PrimaryKey("PK_PitStops", x => x.Id);
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
                    { 28, "Japan", "34.915", "134.221", "Okayama", "Okayama International Circuit", "okayama", "http://en.wikipedia.org/wiki/TI_Circuit" },
                    { 29, "Australia", "-34.9272", "138.617", "Adelaide", "Adelaide Street Circuit", "adelaide", "http://en.wikipedia.org/wiki/Adelaide_Street_Circuit" },
                    { 30, "South Africa", "-25.9894", "28.0767", "Midrand", "Kyalami", "kyalami", "http://en.wikipedia.org/wiki/Kyalami" },
                    { 31, "UK", "52.8306", "-1.37528", "Castle Donington", "Donington Park", "donington", "http://en.wikipedia.org/wiki/Donington_Park" },
                    { 32, "Mexico", "19.4042", "-99.0907", "Mexico City", "Aut�_dromo Hermanos Rodr�_guez", "rodriguez", "http://en.wikipedia.org/wiki/Aut%C3%B3dromo_Hermanos_Rodr%C3%ADguez" },
                    { 33, "USA", "33.4479", "-112.075", "Phoenix", "Phoenix street circuit", "phoenix", "http://en.wikipedia.org/wiki/Phoenix_street_circuit" },
                    { 34, "France", "43.2506", "5.79167", "Le Castellet", "Circuit Paul Ricard", "ricard", "http://en.wikipedia.org/wiki/Paul_Ricard_Circuit" },
                    { 35, "Korea", "34.7333", "126.417", "Yeongam County", "Korean International Circuit", "yeongam", "http://en.wikipedia.org/wiki/Korean_International_Circuit" },
                    { 36, "Brazil", "-22.9756", "-43.395", "Rio de Janeiro", "Aut�_dromo Internacional Nelson Piquet", "jacarepagua", "http://en.wikipedia.org/wiki/Aut%C3%B3dromo_Internacional_Nelson_Piquet" },
                    { 37, "USA", "42.3298", "-83.0401", "Detroit", "Detroit Street Circuit", "detroit", "http://en.wikipedia.org/wiki/Detroit_street_circuit" },
                    { 27, "Portugal", "38.7506", "-9.39417", "Estoril", "Aut�_dromo do Estoril", "estoril", "http://en.wikipedia.org/wiki/Aut%C3%B3dromo_do_Estoril" },
                    { 38, "UK", "51.3569", "0.263056", "Kent", "Brands Hatch", "brands_hatch", "http://en.wikipedia.org/wiki/Brands_Hatch" },
                    { 40, "Belgium", "50.9894", "5.25694", "Heusden-Zolder", "Zolder", "zolder", "http://en.wikipedia.org/wiki/Zolder" },
                    { 41, "France", "47.3625", "4.89913", "Dijon", "Dijon-Prenois", "dijon", "http://en.wikipedia.org/wiki/Dijon-Prenois" },
                    { 42, "USA", "32.7774", "-96.7587", "Dallas", "Fair Park", "dallas", "http://en.wikipedia.org/wiki/Fair_Park" },
                    { 43, "USA", "33.7651", "-118.189", "California", "Long Beach", "long_beach", "http://en.wikipedia.org/wiki/Long_Beach,_California" },
                    { 44, "USA", "36.1162", "-115.174", "Nevada", "Las Vegas Street Circuit", "las_vegas", "http://en.wikipedia.org/wiki/Las_Vegas,_Nevada" },
                    { 45, "Spain", "40.6171", "-3.58558", "Madrid", "Jarama", "jarama", "http://en.wikipedia.org/wiki/Circuito_Permanente_Del_Jarama" },
                    { 46, "USA", "42.3369", "-76.9272", "New York State", "Watkins Glen", "watkins_glen", "http://en.wikipedia.org/wiki/Watkins_Glen_International" },
                    { 47, "Sweden", "57.2653", "13.6042", "Anderstorp", "Scandinavian Raceway", "anderstorp", "http://en.wikipedia.org/wiki/Scandinavian_Raceway" },
                    { 48, "Canada", "44.0481", "-78.6756", "Ontario", "Mosport International Raceway", "mosport", "http://en.wikipedia.org/wiki/Mosport" },
                    { 50, "Belgium", "50.6211", "4.32694", "Brussels", "Nivelles-Baulers", "nivelles", "http://en.wikipedia.org/wiki/Nivelles-Baulers" },
                    { 39, "Netherlands", "52.3888", "4.54092", "Zandvoort", "Circuit Park Zandvoort", "zandvoort", "http://en.wikipedia.org/wiki/Circuit_Zandvoort" },
                    { 26, "Spain", "36.7083", "-6.03417", "Jerez de la Frontera", "Circuito de Jerez", "jerez", "http://en.wikipedia.org/wiki/Circuito_Permanente_de_Jerez" },
                    { 49, "Spain", "41.3664", "2.15167", "Barcelona", "Montju��c", "montjuic", "http://en.wikipedia.org/wiki/Montju%C3%AFc_circuit" },
                    { 24, "UAE", "24.4672", "54.6031", "Abu Dhabi", "Yas Marina Circuit", "yas_marina", "http://en.wikipedia.org/wiki/Yas_Marina_Circuit" },
                    { 25, "Argentina", "-34.6943", "-58.4593", "Buenos Aires", "Aut�_dromo Juan y Oscar G��lvez", "galvez", "http://en.wikipedia.org/wiki/Aut%C3%B3dromo_Oscar_Alfredo_G%C3%A1lvez" },
                    { 3, "Bahrain", "26.0325", "50.5106", "Sakhir", "Bahrain International Circuit", "bahrain", "http://en.wikipedia.org/wiki/Bahrain_International_Circuit" },
                    { 4, "Spain", "41.57", "2.26111", "Montmel�_", "Circuit de Barcelona-Catalunya", "catalunya", "http://en.wikipedia.org/wiki/Circuit_de_Barcelona-Catalunya" },
                    { 5, "Turkey", "40.9517", "29.405", "Istanbul", "Istanbul Park", "istanbul", "http://en.wikipedia.org/wiki/Istanbul_Park" },
                    { 6, "Monaco", "43.7347", "7.42056", "Monte-Carlo", "Circuit de Monaco", "monaco", "http://en.wikipedia.org/wiki/Circuit_de_Monaco" },
                    { 7, "Canada", "45.5", "-73.5228", "Montreal", "Circuit Gilles Villeneuve", "villeneuve", "http://en.wikipedia.org/wiki/Circuit_Gilles_Villeneuve" },
                    { 8, "France", "46.8642", "3.16361", "Magny Cours", "Circuit de Nevers Magny-Cours", "magny_cours", "http://en.wikipedia.org/wiki/Circuit_de_Nevers_Magny-Cours" },
                    { 9, "UK", "52.0786", "-1.01694", "Silverstone", "Silverstone Circuit", "silverstone", "http://en.wikipedia.org/wiki/Silverstone_Circuit" },
                    { 10, "Germany", "49.3278", "8.56583", "Hockenheim", "Hockenheimring", "hockenheimring", "http://en.wikipedia.org/wiki/Hockenheimring" },
                    { 11, "Hungary", "47.5789", "19.2486", "Budapest", "Hungaroring", "hungaroring", "http://en.wikipedia.org/wiki/Hungaroring" },
                    { 12, "Spain", "39.4589", "-0.331667", "Valencia", "Valencia Street Circuit", "valencia", "http://en.wikipedia.org/wiki/Valencia_Street_Circuit" },
                    { 2, "Malaysia", "2.76083", "101.738", "Kuala Lumpur", "Sepang International Circuit", "sepang", "http://en.wikipedia.org/wiki/Sepang_International_Circuit" },
                    { 14, "Italy", "45.6156", "9.28111", "Monza", "Autodromo Nazionale di Monza", "monza", "http://en.wikipedia.org/wiki/Autodromo_Nazionale_Monza" },
                    { 15, "Singapore", "1.2914", "103.864", "Marina Bay", "Marina Bay Street Circuit", "marina_bay", "http://en.wikipedia.org/wiki/Marina_Bay_Street_Circuit" },
                    { 16, "Japan", "35.3717", "138.927", "Oyama", "Fuji Speedway", "fuji", "http://en.wikipedia.org/wiki/Fuji_Speedway" },
                    { 17, "China", "31.3389", "121.22", "Shanghai", "Shanghai International Circuit", "shanghai", "http://en.wikipedia.org/wiki/Shanghai_International_Circuit" },
                    { 18, "Brazil", "-23.7036", "-46.6997", "Ṣo Paulo", "Aut�_dromo Jos̩ Carlos Pace", "interlagos", "http://en.wikipedia.org/wiki/Aut%C3%B3dromo_Jos%C3%A9_Carlos_Pace" },
                    { 19, "USA", "39.795", "-86.2347", "Indianapolis", "Indianapolis Motor Speedway", "indianapolis", "http://en.wikipedia.org/wiki/Indianapolis_Motor_Speedway" },
                    { 20, "Germany", "50.3356", "6.9475", "N�_rburg", "N�_rburgring", "nurburgring", "http://en.wikipedia.org/wiki/N%C3%BCrburgring" },
                    { 21, "Italy", "44.3439", "11.7167", "Imola", "Autodromo Enzo e Dino Ferrari", "imola", "http://en.wikipedia.org/wiki/Autodromo_Enzo_e_Dino_Ferrari" },
                    { 22, "Japan", "34.8431", "136.541", "Suzuka", "Suzuka Circuit", "suzuka", "http://en.wikipedia.org/wiki/Suzuka_Circuit" },
                    { 23, "Austria", "47.2197", "14.7647", "Spielburg", "A1-Ring", "osterreichring", "http://en.wikipedia.org/wiki/A1-Ring" },
                    { 13, "Belgium", "50.4372", "5.97139", "Spa", "Circuit de Spa-Francorchamps", "spa", "http://en.wikipedia.org/wiki/Circuit_de_Spa-Francorchamps" }
                });

            migrationBuilder.InsertData(
                table: "ConstructorResults",
                columns: new[] { "Id", "ConstructorId", "Points", "RaceId", "Status" },
                values: new object[,]
                {
                    { 14, 1, 10f, 19, "NULL" },
                    { 15, 7, 5f, 19, "NULL" },
                    { 16, 9, 2f, 19, "NULL" },
                    { 21, 8, 0f, 19, "NULL" },
                    { 18, 11, 0f, 19, "NULL" },
                    { 19, 10, 0f, 19, "NULL" },
                    { 20, 3, 0f, 19, "NULL" },
                    { 22, 5, 0f, 19, "NULL" },
                    { 17, 4, 1f, 19, "NULL" },
                    { 13, 2, 11f, 19, "NULL" },
                    { 8, 8, 0f, 18, "NULL" },
                    { 11, 11, 0f, 18, "NULL" },
                    { 10, 10, 0f, 18, "NULL" },
                    { 9, 9, 0f, 18, "NULL" },
                    { 7, 7, 0f, 18, "NULL" },
                    { 6, 6, 1f, 18, "NULL" },
                    { 5, 5, 2f, 18, "NULL" },
                    { 4, 4, 5f, 18, "NULL" },
                    { 3, 3, 9f, 18, "NULL" },
                    { 23, 6, 18f, 20, "NULL" },
                    { 2, 2, 8f, 18, "NULL" },
                    { 12, 6, 10f, 19, "NULL" },
                    { 24, 2, 11f, 20, "NULL" },
                    { 36, 2, 5f, 21, "NULL" },
                    { 26, 7, 3f, 20, "NULL" },
                    { 1, 1, 14f, 18, "NULL" },
                    { 47, 2, 9f, 22, "NULL" },
                    { 46, 1, 8f, 22, "NULL" },
                    { 45, 6, 16f, 22, "NULL" },
                    { 44, 5, 0f, 21, "NULL" },
                    { 43, 4, 0f, 21, "NULL" },
                    { 42, 8, 0f, 21, "NULL" },
                    { 41, 10, 0f, 21, "NULL" },
                    { 40, 7, 1f, 21, "NULL" },
                    { 39, 3, 2f, 21, "NULL" },
                    { 38, 11, 3f, 21, "NULL" },
                    { 37, 9, 4f, 21, "NULL" },
                    { 35, 1, 6f, 21, "NULL" },
                    { 34, 6, 18f, 21, "NULL" },
                    { 33, 8, 0f, 20, "NULL" },
                    { 32, 5, 0f, 20, "NULL" },
                    { 31, 10, 0f, 20, "NULL" },
                    { 30, 11, 0f, 20, "NULL" },
                    { 29, 4, 0f, 20, "NULL" },
                    { 28, 3, 1f, 20, "NULL" },
                    { 27, 9, 2f, 20, "NULL" },
                    { 25, 1, 4f, 20, "NULL" },
                    { 50, 3, 1f, 22, "NULL" },
                    { 49, 9, 2f, 22, "NULL" },
                    { 48, 4, 3f, 22, "NULL" }
                });

            migrationBuilder.InsertData(
                table: "ConstructorStandings",
                columns: new[] { "Id", "ConstructorId", "Points", "Position", "PositionText", "RaceId", "Wins" },
                values: new object[,]
                {
                    { 2, 2, 8f, 3, "3", 18, 0 },
                    { 29, 1, 34f, 3, "3", 21, 1 },
                    { 30, 2, 35f, 2, "2", 21, 0 },
                    { 31, 3, 12f, 4, "4", 21, 0 },
                    { 32, 4, 6f, 7, "7", 21, 0 },
                    { 33, 5, 2f, 9, "9", 21, 0 },
                    { 34, 6, 47f, 1, "1", 21, 3 },
                    { 35, 7, 9f, 5, "5", 21, 0 },
                    { 36, 9, 8f, 6, "6", 21, 0 },
                    { 37, 11, 3f, 8, "8", 21, 0 },
                    { 38, 10, 0f, 10, "10", 21, 0 },
                    { 39, 8, 0f, 11, "11", 21, 0 },
                    { 41, 2, 44f, 2, "2", 22, 0 },
                    { 42, 3, 13f, 4, "4", 22, 0 },
                    { 43, 4, 9f, 7, "7", 22, 0 },
                    { 44, 5, 2f, 9, "9", 22, 0 },
                    { 45, 6, 63f, 1, "1", 22, 4 },
                    { 46, 7, 9f, 6, "6", 22, 0 },
                    { 47, 9, 10f, 5, "5", 22, 0 },
                    { 48, 11, 3f, 8, "8", 22, 0 },
                    { 49, 10, 0f, 10, "10", 22, 0 },
                    { 50, 8, 0f, 11, "11", 22, 0 },
                    { 40, 1, 42f, 3, "3", 22, 1 },
                    { 28, 8, 0f, 11, "11", 20, 0 },
                    { 27, 10, 0f, 10, "10", 20, 0 },
                    { 25, 9, 4f, 7, "7", 20, 0 },
                    { 3, 3, 9f, 2, "2", 18, 0 },
                    { 4, 4, 5f, 4, "4", 18, 0 },
                    { 5, 5, 2f, 5, "5", 18, 0 },
                    { 6, 6, 1f, 6, "6", 18, 0 },
                    { 7, 1, 24f, 1, "1", 19, 1 },
                    { 8, 2, 19f, 2, "2", 19, 0 },
                    { 9, 3, 9f, 4, "4", 19, 0 },
                    { 10, 4, 6f, 5, "5", 19, 0 },
                    { 11, 5, 2f, 8, "8", 19, 0 },
                    { 12, 6, 11f, 3, "3", 19, 1 },
                    { 14, 9, 2f, 7, "7", 19, 0 },
                    { 15, 11, 0f, 9, "9", 19, 0 },
                    { 16, 10, 0f, 10, "10", 19, 0 },
                    { 17, 8, 0f, 11, "11", 19, 0 },
                    { 18, 1, 28f, 3, "3", 20, 1 },
                    { 19, 2, 30f, 1, "1", 20, 0 },
                    { 20, 3, 10f, 4, "4", 20, 0 },
                    { 21, 4, 6f, 6, "6", 20, 0 },
                    { 22, 5, 2f, 8, "8", 20, 0 },
                    { 23, 6, 29f, 2, "2", 20, 2 },
                    { 24, 7, 8f, 5, "5", 20, 0 },
                    { 1, 1, 14f, 1, "1", 18, 1 },
                    { 26, 11, 0f, 9, "9", 20, 0 },
                    { 13, 7, 5f, 6, "6", 19, 0 }
                });

            migrationBuilder.InsertData(
                table: "Constructors",
                columns: new[] { "Id", "Name", "Nationality", "Ref", "Url" },
                values: new object[,]
                {
                    { 50, "RAM", "British", "ram", "http://en.wikipedia.org/wiki/RAM_Racing" },
                    { 22, "Benetton", "Italian", "benetton", "http://en.wikipedia.org/wiki/Benetton_Formula" },
                    { 21, "Arrows", "British", "arrows", "http://en.wikipedia.org/wiki/Arrows_Grand_Prix_International" },
                    { 20, "Prost", "French", "prost", "http://en.wikipedia.org/wiki/Prost_Grand_Prix" },
                    { 19, "Jaguar", "British", "jaguar", "http://en.wikipedia.org/wiki/Jaguar_Racing" },
                    { 18, "Minardi", "Italian", "minardi", "http://en.wikipedia.org/wiki/Minardi" },
                    { 17, "Jordan", "Irish", "jordan", "http://en.wikipedia.org/wiki/Jordan_Grand_Prix" },
                    { 16, "BAR", "British", "bar", "http://en.wikipedia.org/wiki/British_American_Racing" },
                    { 15, "Sauber", "Swiss", "sauber", "http://en.wikipedia.org/wiki/Sauber" },
                    { 14, "Spyker MF1", "Dutch", "spyker_mf1", "http://en.wikipedia.org/wiki/Midland_F1_Racing" },
                    { 13, "MF1", "Russian", "mf1", "http://en.wikipedia.org/wiki/Midland_F1_Racing" },
                    { 23, "Brawn", "British", "brawn", "http://en.wikipedia.org/wiki/Brawn_GP" },
                    { 12, "Spyker", "Dutch", "spyker", "http://en.wikipedia.org/wiki/Spyker_F1" },
                    { 10, "Force India", "Indian", "force_india", "http://en.wikipedia.org/wiki/Force_India" },
                    { 9, "Red Bull", "Austrian", "red_bull", "http://en.wikipedia.org/wiki/Red_Bull_Racing" },
                    { 8, "Super Aguri", "Japanese", "super_aguri", "http://en.wikipedia.org/wiki/Super_Aguri_F1" },
                    { 7, "Toyota", "Japanese", "toyota", "http://en.wikipedia.org/wiki/Toyota_Racing" },
                    { 6, "Ferrari", "Italian", "ferrari", "http://en.wikipedia.org/wiki/Scuderia_Ferrari" },
                    { 5, "Toro Rosso", "Italian", "toro_rosso", "http://en.wikipedia.org/wiki/Scuderia_Toro_Rosso" },
                    { 4, "Renault", "French", "renault", "http://en.wikipedia.org/wiki/Renault_F1" },
                    { 3, "Williams", "British", "williams", "http://en.wikipedia.org/wiki/Williams_Grand_Prix_Engineering" },
                    { 2, "BMW Sauber", "German", "bmw_sauber", "http://en.wikipedia.org/wiki/BMW_Sauber" },
                    { 51, "Alfa Romeo", "Italian", "alfa", "http://en.wikipedia.org/wiki/Alfa_Romeo_(Formula_One)" },
                    { 11, "Honda", "Japanese", "honda", "http://en.wikipedia.org/wiki/Honda_Racing_F1" },
                    { 24, "Stewart", "British", "stewart", "http://en.wikipedia.org/wiki/Stewart_Grand_Prix" },
                    { 1, "McLaren", "British", "mclaren", "http://en.wikipedia.org/wiki/McLaren" },
                    { 26, "Lola", "British", "lola", "http://en.wikipedia.org/wiki/MasterCard_Lola" },
                    { 25, "Tyrrell", "British", "tyrrell", "http://en.wikipedia.org/wiki/Tyrrell_Racing" },
                    { 48, "Rial", "German", "rial", "http://en.wikipedia.org/wiki/Rial_%28racing_team%29" },
                    { 47, "Life", "Italian", "life", "http://en.wikipedia.org/wiki/Life_(Racing_Team)" },
                    { 46, "Onyx", "British", "onyx", "http://en.wikipedia.org/wiki/Onyx_(racing_team)" },
                    { 45, "Osella", "Italian", "osella", "http://en.wikipedia.org/wiki/Osella" },
                    { 44, "Euro Brun", "Italian", "eurobrun", "http://en.wikipedia.org/wiki/Euro_Brun" },
                    { 42, "Coloni", "Italian", "coloni", "http://en.wikipedia.org/wiki/Enzo_Coloni_Racing_Car_Systems" },
                    { 49, "Zakspeed", "German", "zakspeed", "http://en.wikipedia.org/wiki/Zakspeed" },
                    { 40, "Lambo", "Italian", "lambo", "http://en.wikipedia.org/wiki/Modena_(racing_team)" },
                    { 39, "AGS", "French", "ags", "http://en.wikipedia.org/wiki/Automobiles_Gonfaronnaises_Sportives" },
                    { 38, "Andrea Moda", "Italian", "moda", "http://en.wikipedia.org/wiki/Andrea_Moda_Formula" },
                    { 41, "Leyton House", "British", "leyton", "http://en.wikipedia.org/wiki/Leyton_House" },
                    { 37, "March", "British", "march", "http://en.wikipedia.org/wiki/March_Engineering" },
                    { 36, "Fondmetal", "Italian", "fondmetal", "http://en.wikipedia.org/wiki/Fondmetal" },
                    { 35, "Dallara", "Italian", "dallara", "http://en.wikipedia.org/wiki/Dallara" },
                    { 34, "Brabham", "British", "brabham", "http://en.wikipedia.org/wiki/Brabham" },
                    { 33, "Larrousse", "French", "larrousse", "http://en.wikipedia.org/wiki/Larrousse" },
                    { 32, "Team Lotus", "British", "team_lotus", "http://en.wikipedia.org/wiki/Team_Lotus" },
                    { 31, "Simtek", "British", "simtek", "http://en.wikipedia.org/wiki/Simtek" },
                    { 30, "Pacific", "British", "pacific", "http://en.wikipedia.org/wiki/Pacific_Racing" },
                    { 29, "Footwork", "British", "footwork", "http://en.wikipedia.org/wiki/Footwork_Arrows" },
                    { 28, "Forti", "Italian", "forti", "http://en.wikipedia.org/wiki/Forti" },
                    { 27, "Ligier", "French", "ligier", "http://en.wikipedia.org/wiki/Ligier" }
                });

            migrationBuilder.InsertData(
                table: "DriverStandings",
                columns: new[] { "Id", "DriverId", "Points", "Position", "PositionText", "RaceId", "Wins" },
                values: new object[,]
                {
                    { 15, 7, 2f, 10, "10", 19, 0 },
                    { 16, 8, 11f, 2, "2", 19, 1 },
                    { 17, 9, 8f, 5, "5", 19, 0 },
                    { 22, 12, 0f, 14, "14", 19, 0 },
                    { 19, 17, 2f, 11, "11", 19, 0 },
                    { 20, 14, 0f, 12, "12", 19, 0 },
                    { 21, 18, 0f, 13, "13", 19, 0 },
                    { 23, 21, 0f, 15, "15", 19, 0 },
                    { 18, 15, 5f, 8, "8", 19, 0 },
                    { 14, 6, 3f, 9, "9", 19, 0 },
                    { 4, 4, 5f, 4, "4", 18, 0 },
                    { 12, 4, 6f, 7, "7", 19, 0 },
                    { 11, 3, 6f, 6, "6", 19, 0 },
                    { 10, 2, 11f, 3, "3", 19, 0 },
                    { 9, 1, 14f, 1, "1", 19, 1 },
                    { 8, 8, 1f, 8, "8", 18, 0 },
                    { 7, 7, 2f, 7, "7", 18, 0 },
                    { 6, 6, 3f, 6, "6", 18, 0 },
                    { 5, 5, 4f, 5, "5", 18, 0 },
                    { 24, 22, 0f, 16, "16", 19, 0 },
                    { 3, 3, 6f, 3, "3", 18, 0 },
                    { 13, 5, 10f, 4, "4", 19, 0 },
                    { 25, 19, 0f, 17, "17", 19, 0 },
                    { 37, 17, 4f, 10, "10", 20, 0 },
                    { 27, 1, 14f, 3, "3", 20, 1 },
                    { 50, 3, 7f, 9, "9", 21, 0 },
                    { 2, 2, 8f, 2, "2", 18, 0 },
                    { 49, 2, 16f, 5, "5", 21, 0 },
                    { 48, 1, 20f, 2, "2", 21, 1 },
                    { 47, 16, 0f, 21, "21", 20, 0 },
                    { 46, 10, 0f, 14, "14", 20, 0 },
                    { 45, 13, 10f, 6, "6", 20, 1 },
                    { 44, 11, 0f, 20, "20", 20, 0 },
                    { 43, 19, 0f, 19, "19", 20, 0 },
                    { 42, 22, 0f, 16, "16", 20, 0 },
                    { 41, 21, 0f, 18, "18", 20, 0 },
                    { 40, 12, 0f, 17, "17", 20, 0 },
                    { 39, 18, 0f, 15, "15", 20, 0 },
                    { 38, 14, 0f, 13, "13", 20, 0 },
                    { 36, 15, 8f, 7, "7", 20, 0 },
                    { 35, 9, 14f, 4, "4", 20, 0 },
                    { 34, 8, 19f, 1, "1", 20, 1 },
                    { 33, 7, 2f, 12, "12", 20, 0 },
                    { 32, 6, 3f, 11, "11", 20, 0 },
                    { 31, 5, 14f, 5, "5", 20, 0 },
                    { 30, 4, 6f, 9, "9", 20, 0 },
                    { 29, 3, 7f, 8, "8", 20, 0 },
                    { 28, 2, 16f, 2, "2", 20, 0 },
                    { 26, 11, 0f, 18, "18", 19, 0 },
                    { 1, 1, 10f, 1, "1", 18, 1 }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Code", "Dob", "Forename", "Nationality", "Number", "Ref", "Surname", "Url" },
                values: new object[,]
                {
                    { 38, "DOO", "23/09/1981", "Robert", "Dutch", null, "doornbos", "Doornbos", "http://en.wikipedia.org/wiki/Robert_Doornbos" },
                    { 49, "", "18/05/1967", "Heinz-Harald", "German", null, "frentzen", "Frentzen", "http://en.wikipedia.org/wiki/Heinz-Harald_Frentzen" },
                    { 21, "FIS", "14/01/1973", "Giancarlo", "Italian", null, "fisichella", "Fisichella", "http://en.wikipedia.org/wiki/Giancarlo_Fisichella" },
                    { 20, "VET", "03/07/1987", "Sebastian", "German", 5, "vettel", "Vettel", "http://en.wikipedia.org/wiki/Sebastian_Vettel" },
                    { 19, "DAV", "18/04/1979", "Anthony", "British", null, "davidson", "Davidson", "http://en.wikipedia.org/wiki/Anthony_Davidson" },
                    { 18, "BUT", "19/01/1980", "Jenson", "British", 22, "button", "Button", "http://en.wikipedia.org/wiki/Jenson_Button" },
                    { 17, "WEB", "27/08/1976", "Mark", "Australian", null, "webber", "Webber", "http://en.wikipedia.org/wiki/Mark_Webber" },
                    { 16, "SUT", "11/01/1983", "Adrian", "German", 99, "sutil", "Sutil", "http://en.wikipedia.org/wiki/Adrian_Sutil" },
                    { 15, "TRU", "13/07/1974", "Jarno", "Italian", null, "trulli", "Trulli", "http://en.wikipedia.org/wiki/Jarno_Trulli" },
                    { 14, "COU", "27/03/1971", "David", "British", null, "coulthard", "Coulthard", "http://en.wikipedia.org/wiki/David_Coulthard" },
                    { 13, "MAS", "25/04/1981", "Felipe", "Brazilian", 19, "massa", "Massa", "http://en.wikipedia.org/wiki/Felipe_Massa" },
                    { 50, "", "04/03/1972", "Jos", "Dutch", null, "verstappen", "Verstappen", "http://en.wikipedia.org/wiki/Jos_Verstappen" },
                    { 11, "SAT", "28/01/1977", "Takuma", "Japanese", null, "sato", "Sato", "http://en.wikipedia.org/wiki/Takuma_Sato" },
                    { 10, "GLO", "18/03/1982", "Timo", "German", null, "glock", "Glock", "http://en.wikipedia.org/wiki/Timo_Glock" },
                    { 9, "KUB", "07/12/1984", "Robert", "Polish", null, "kubica", "Kubica", "http://en.wikipedia.org/wiki/Robert_Kubica" },
                    { 8, "RAI", "17/10/1979", "Kimi", "Finnish", 7, "raikkonen", "R�_ikk̦nen", "http://en.wikipedia.org/wiki/Kimi_R%C3%A4ikk%C3%B6nen" },
                    { 7, "BOU", "28/02/1979", "S̩bastien", "French", null, "bourdais", "Bourdais", "http://en.wikipedia.org/wiki/S%C3%A9bastien_Bourdais" },
                    { 6, "NAK", "11/01/1985", "Kazuki", "Japanese", null, "nakajima", "Nakajima", "http://en.wikipedia.org/wiki/Kazuki_Nakajima" },
                    { 5, "KOV", "19/10/1981", "Heikki", "Finnish", null, "kovalainen", "Kovalainen", "http://en.wikipedia.org/wiki/Heikki_Kovalainen" },
                    { 4, "ALO", "29/07/1981", "Fernando", "Spanish", 14, "alonso", "Alonso", "http://en.wikipedia.org/wiki/Fernando_Alonso" },
                    { 3, "ROS", "27/06/1985", "Nico", "German", 6, "rosberg", "Rosberg", "http://en.wikipedia.org/wiki/Nico_Rosberg" },
                    { 2, "HEI", "10/05/1977", "Nick", "German", null, "heidfeld", "Heidfeld", "http://en.wikipedia.org/wiki/Nick_Heidfeld" },
                    { 1, "HAM", "07/01/1985", "Lewis", "British", 44, "hamilton", "Hamilton", "http://en.wikipedia.org/wiki/Lewis_Hamilton" },
                    { 22, "BAR", "23/05/1972", "Rubens", "Brazilian", null, "barrichello", "Barrichello", "http://en.wikipedia.org/wiki/Rubens_Barrichello" },
                    { 23, "SCH", "30/06/1975", "Ralf", "German", null, "ralf_schumacher", "Schumacher", "http://en.wikipedia.org/wiki/Ralf_Schumacher" },
                    { 12, "PIQ", "25/07/1985", "Nelson", "Brazilian", null, "piquet_jr", "Piquet Jr.", "http://en.wikipedia.org/wiki/Nelson_Piquet,_Jr." },
                    { 25, "WUR", "15/02/1974", "Alexander", "Austrian", null, "wurz", "Wurz", "http://en.wikipedia.org/wiki/Alexander_Wurz" },
                    { 24, "LIU", "06/08/1980", "Vitantonio", "Italian", null, "liuzzi", "Liuzzi", "http://en.wikipedia.org/wiki/Vitantonio_Liuzzi" },
                    { 48, "", "29/03/1974", "Marc", "Spanish", null, "gene", "Gen̩", "http://en.wikipedia.org/wiki/Marc_Gen%C3%A9" },
                    { 47, "", "01/01/1981", "Zsolt", "Hungarian", null, "baumgartner", "Baumgartner", "http://en.wikipedia.org/wiki/Zsolt_Baumgartner" },
                    { 46, "", "30/05/1981", "Gianmaria", "Italian", null, "bruni", "Bruni", "http://en.wikipedia.org/wiki/Gianmaria_Bruni" },
                    { 45, "", "04/02/1979", "Giorgio", "Italian", null, "pantano", "Pantano", "http://en.wikipedia.org/wiki/Giorgio_Pantano" },
                    { 44, "", "02/09/1966", "Olivier", "French", null, "panis", "Panis", "http://en.wikipedia.org/wiki/Olivier_Panis" },
                    { 42, "PIZ", "11/09/1980", "Ant̫nio", "Brazilian", null, "pizzonia", "Pizzonia", "http://en.wikipedia.org/wiki/Ant%C3%B4nio_Pizzonia" },
                    { 41, "ZON", "23/03/1976", "Ricardo", "Brazilian", null, "zonta", "Zonta", "http://en.wikipedia.org/wiki/Ricardo_Zonta" },
                    { 40, "FRI", "26/09/1980", "Patrick", "Austrian", null, "friesacher", "Friesacher", "http://en.wikipedia.org/wiki/Patrick_Friesacher" },
                    { 39, "KAR", "14/01/1977", "Narain", "Indian", null, "karthikeyan", "Karthikeyan", "http://en.wikipedia.org/wiki/Narain_Karthikeyan" },
                    { 37, "DLR", "24/02/1971", "Pedro", "Spanish", null, "rosa", "de la Rosa", "http://en.wikipedia.org/wiki/Pedro_de_la_Rosa" },
                    { 43, "", "19/09/1973", "Cristiano", "Brazilian", null, "matta", "da Matta", "http://en.wikipedia.org/wiki/Cristiano_da_Matta" },
                    { 35, "VIL", "09/04/1971", "Jacques", "Canadian", null, "villeneuve", "Villeneuve", "http://en.wikipedia.org/wiki/Jacques_Villeneuve" },
                    { 34, "IDE", "21/01/1975", "Yuji", "Japanese", null, "ide", "Ide", "http://en.wikipedia.org/wiki/Yuji_Ide" },
                    { 33, "TMO", "24/07/1976", "Tiago", "Portuguese", null, "monteiro", "Monteiro", "http://en.wikipedia.org/wiki/Tiago_Monteiro" },
                    { 32, "KLI", "07/02/1983", "Christian", "Austrian", null, "klien", "Klien", "http://en.wikipedia.org/wiki/Christian_Klien" },
                    { 31, "MON", "20/09/1975", "Juan", "Colombian", null, "montoya", "Pablo Montoya", "http://en.wikipedia.org/wiki/Juan_Pablo_Montoya" },
                    { 30, "MSC", "03/01/1969", "Michael", "German", null, "michael_schumacher", "Schumacher", "http://en.wikipedia.org/wiki/Michael_Schumacher" },
                    { 29, "YAM", "09/07/1982", "Sakon", "Japanese", null, "yamamoto", "Yamamoto", "http://en.wikipedia.org/wiki/Sakon_Yamamoto" },
                    { 28, "WIN", "13/06/1980", "Markus", "German", null, "markus_winkelhock", "Winkelhock", "http://en.wikipedia.org/wiki/Markus_Winkelhock" },
                    { 27, "ALB", "16/04/1979", "Christijan", "Dutch", null, "albers", "Albers", "http://en.wikipedia.org/wiki/Christijan_Albers" },
                    { 36, "FMO", "05/01/1978", "Franck", "French", null, "montagny", "Montagny", "http://en.wikipedia.org/wiki/Franck_Montagny" },
                    { 26, "SPE", "24/01/1983", "Scott", "American", null, "speed", "Speed", "http://en.wikipedia.org/wiki/Scott_Speed" }
                });

            migrationBuilder.InsertData(
                table: "LapTimes",
                columns: new[] { "Id", "DriverId", "Lap", "Milliseconds", "Position", "RaceId", "Time" },
                values: new object[,]
                {
                    { 36, 20, "36", 113737, 1, 841, "1:53.737" },
                    { 35, 20, "35", 92597, 1, 841, "1:32.597" },
                    { 34, 20, "34", 91871, 1, 841, "1:31.871" },
                    { 33, 20, "33", 91406, 1, 841, "1:31.406" },
                    { 28, 20, "28", 91113, 1, 841, "1:31.113" },
                    { 31, 20, "31", 91707, 1, 841, "1:31.707" }
                });

            migrationBuilder.InsertData(
                table: "LapTimes",
                columns: new[] { "Id", "DriverId", "Lap", "Milliseconds", "Position", "RaceId", "Time" },
                values: new object[,]
                {
                    { 30, 20, "30", 91054, 1, 841, "1:31.054" },
                    { 29, 20, "29", 91339, 1, 841, "1:31.339" },
                    { 37, 20, "37", 99321, 1, 841, "1:39.321" },
                    { 32, 20, "32", 91611, 1, 841, "1:31.611" },
                    { 38, 20, "38", 93632, 1, 841, "1:33.632" },
                    { 50, 20, "50", 90732, 1, 841, "1:30.732" },
                    { 40, 20, "40", 90530, 1, 841, "1:30.530" },
                    { 41, 20, "41", 90140, 1, 841, "1:30.140" },
                    { 42, 20, "42", 90419, 1, 841, "1:30.419" },
                    { 43, 20, "43", 90503, 1, 841, "1:30.503" },
                    { 44, 20, "44", 89844, 1, 841, "1:29.844" },
                    { 45, 20, "45", 90470, 1, 841, "1:30.470" },
                    { 46, 20, "46", 90669, 1, 841, "1:30.669" },
                    { 47, 20, "47", 90297, 1, 841, "1:30.297" },
                    { 48, 20, "48", 90471, 1, 841, "1:30.471" },
                    { 49, 20, "49", 90710, 1, 841, "1:30.710" },
                    { 27, 20, "27", 91568, 1, 841, "1:31.568" },
                    { 39, 20, "39", 91005, 1, 841, "1:31.005" },
                    { 26, 20, "26", 91328, 1, 841, "1:31.328" },
                    { 25, 20, "25", 91699, 1, 841, "1:31.699" },
                    { 24, 20, "24", 92240, 1, 841, "1:32.240" },
                    { 2, 20, "2", 93006, 1, 841, "1:33.006" },
                    { 3, 20, "3", 92713, 1, 841, "1:32.713" },
                    { 4, 20, "4", 92803, 1, 841, "1:32.803" },
                    { 5, 20, "5", 92342, 1, 841, "1:32.342" },
                    { 6, 20, "6", 92605, 1, 841, "1:32.605" },
                    { 7, 20, "7", 92502, 1, 841, "1:32.502" },
                    { 8, 20, "8", 92537, 1, 841, "1:32.537" },
                    { 9, 20, "9", 93240, 1, 841, "1:33.240" },
                    { 10, 20, "10", 92572, 1, 841, "1:32.572" },
                    { 11, 20, "11", 92669, 1, 841, "1:32.669" },
                    { 12, 20, "12", 92902, 1, 841, "1:32.902" },
                    { 1, 20, "1", 98109, 1, 841, "1:38.109" },
                    { 14, 20, "14", 112075, 3, 841, "1:52.075" },
                    { 15, 20, "15", 98385, 4, 841, "1:38.385" },
                    { 16, 20, "16", 91548, 2, 841, "1:31.548" },
                    { 17, 20, "17", 90800, 1, 841, "1:30.800" },
                    { 18, 20, "18", 91810, 1, 841, "1:31.810" },
                    { 19, 20, "19", 91018, 1, 841, "1:31.018" },
                    { 20, 20, "20", 91055, 1, 841, "1:31.055" },
                    { 21, 20, "21", 91288, 1, 841, "1:31.288" },
                    { 22, 20, "22", 91084, 1, 841, "1:31.084" },
                    { 23, 20, "23", 90875, 1, 841, "1:30.875" },
                    { 13, 20, "13", 93698, 1, 841, "1:33.698" }
                });

            migrationBuilder.InsertData(
                table: "PitStops",
                columns: new[] { "Id", "DriverId", "Duration", "Lap", "Milliseconds", "RaceId", "Stop", "Time" },
                values: new object[,]
                {
                    { 37, 814, "24.332", 36, "24332", 841, 2, "18:00:48" },
                    { 36, 808, "25.683", 36, "25683", 841, 2, "17:59:47" },
                    { 35, 153, "26.348", 35, "26348", 841, 3, "17:59:45" },
                    { 34, 1, "23.199", 36, "23199", 841, 2, "17:59:29" },
                    { 29, 67, "23.100", 29, "23100", 841, 2, "17:49:47" },
                    { 32, 155, "24.192", 32, "24192", 841, 2, "17:54:21" },
                    { 31, 13, "24.500", 31, "24500", 841, 2, "17:52:28" },
                    { 30, 2, "25.098", 30, "25098", 841, 2, "17:51:32" },
                    { 38, 18, "22.681", 37, "22681", 841, 3, "18:01:49" },
                    { 33, 20, "24.036", 36, "24036", 841, 2, "17:59:17" },
                    { 39, 16, "23.871", 37, "23871", 841, 2, "18:02:15" },
                    { 44, 4, "24.181", 42, "24181", 841, 3, "18:09:08" },
                    { 41, 816, "26.446", 38, "26446", 841, 2, "18:06:53" },
                    { 42, 17, "26.230", 41, "26230", 841, 3, "18:07:37" },
                    { 43, 22, "26.309", 40, "26309", 841, 4, "18:08:03" },
                    { 45, 13, "24.095", 48, "24095", 841, 3, "18:18:54" },
                    { 46, 16, "31.694", 3, "31694", 842, 1, "16:09:07" },
                    { 47, 22, "32.978", 3, "32978", 842, 1, "16:10:04" },
                    { 48, 17, "22.572", 10, "22572", 842, 1, "16:21:21" },
                    { 49, 814, "22.773", 11, "22773", 842, 1, "16:23:16" },
                    { 50, 1, "22.552", 12, "22552", 842, 1, "16:24:40" },
                    { 28, 22, "16.892", 28, "16892", 841, 3, "17:49:07" },
                    { 40, 15, "24.848", 37, "24848", 841, 2, "18:03:55" },
                    { 27, 4, "24.733", 27, "24733", 841, 2, "17:46:04" },
                    { 26, 17, "22.520", 26, "22520", 841, 2, "17:44:29" },
                    { 1, 153, "26.898", 1, "26898", 841, 1, "17:05:23" },
                    { 25, 22, "37.856", 23, "37856", 841, 2, "17:40:45" },
                    { 2, 30, "25.021", 1, "25021", 841, 1, "17:05:52" },
                    { 3, 17, "23.426", 11, "23426", 841, 1, "17:20:48" },
                    { 4, 4, "23.251", 12, "23251", 841, 1, "17:22:34" },
                    { 5, 13, "23.842", 13, "23842", 841, 1, "17:24:10" },
                    { 6, 22, "23.643", 13, "23643", 841, 1, "17:24:29" },
                    { 7, 20, "22.603", 14, "22603", 841, 1, "17:25:17" },
                    { 9, 816, "25.259", 14, "25259", 841, 1, "17:26:50" },
                    { 10, 67, "25.342", 15, "25342", 841, 1, "17:27:34" },
                    { 11, 2, "22.994", 15, "22994", 841, 1, "17:27:41" },
                    { 12, 1, "23.227", 16, "23227", 841, 1, "17:28:24" },
                    { 8, 814, "24.863", 14, "24863", 841, 1, "17:26:03" },
                    { 14, 3, "23.716", 16, "23716", 841, 1, "17:29:00" },
                    { 13, 808, "24.535", 16, "24535", 841, 1, "17:28:39" },
                    { 23, 18, "23.303", 19, "23303", 841, 2, "17:33:53" },
                    { 22, 10, "23.792", 18, "23792", 841, 1, "17:33:02" },
                    { 21, 30, "23.988", 17, "23988", 841, 2, "17:32:08" },
                    { 20, 5, "24.865", 17, "24865", 841, 1, "17:31:11" },
                    { 24, 815, "23.438", 23, "23438", 841, 1, "17:40:27" },
                    { 18, 18, "16.867", 17, "16867", 841, 1, "17:30:24" },
                    { 17, 15, "24.899", 16, "24899", 841, 1, "17:29:49" },
                    { 16, 16, "25.978", 16, "25978", 841, 1, "17:29:08" },
                    { 15, 155, "24.064", 16, "24064", 841, 1, "17:29:06" },
                    { 19, 153, "24.463", 17, "24463", 841, 2, "17:31:06" }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "ConstructorId", "DriverId", "Number", "Position", "Q1", "Q2", "Q3", "RaceId" },
                values: new object[,]
                {
                    { 37, 5, 20, 15, 15, "1:36.111", "1:35.648", "NULL", 19 },
                    { 28, 2, 9, 4, 6, "1:35.794", "1:34.811", "1:36.727", 19 },
                    { 29, 2, 2, 3, 7, "1:35.729", "1:34.648", "1:36.753", 19 },
                    { 30, 9, 17, 10, 8, "1:35.440", "1:34.967", "1:37.009", 19 },
                    { 31, 4, 4, 5, 9, "1:35.983", "1:35.140", "1:38.450", 19 },
                    { 32, 7, 10, 12, 10, "1:35.891", "1:35.000", "1:39.656", 19 },
                    { 33, 11, 18, 16, 11, "1:35.847", "1:35.208", "NULL", 19 },
                    { 34, 9, 14, 9, 12, "1:36.058", "1:35.408", "NULL", 19 },
                    { 35, 4, 12, 6, 13, "1:36.074", "1:35.562", "NULL", 19 },
                    { 36, 11, 22, 17, 14, "1:36.198", "1:35.622", "NULL", 19 },
                    { 38, 3, 3, 7, 16, "1:35.843", "1:35.670", "NULL", 19 },
                    { 27, 7, 15, 11, 5, "1:35.205", "1:34.960", "1:36.711", 19 },
                    { 40, 3, 6, 8, 18, "1:36.388", " ", "NULL", 19 },
                    { 41, 5, 7, 14, 19, "1:36.677", " ", "NULL", 19 },
                    { 42, 8, 11, 18, 20, "1:37.087", " ", "NULL", 19 },
                    { 43, 10, 16, 20, 21, "1:37.101", " ", "NULL", 19 },
                    { 44, 8, 19, 19, 22, "1:37.481", " ", "NULL", 19 },
                    { 45, 2, 9, 4, 1, "1:32.893", "1:31.745", "1:33.096", 20 },
                    { 46, 6, 13, 2, 2, "1:31.937", "1:31.188", "1:33.123", 20 },
                    { 47, 1, 1, 22, 3, "1:32.750", "1:31.922", "1:33.292", 20 },
                    { 48, 6, 8, 1, 4, "1:32.652", "1:31.933", "1:33.418", 20 },
                    { 49, 1, 5, 23, 5, "1:33.057", "1:31.718", "1:33.488", 20 },
                    { 50, 2, 2, 3, 6, "1:33.137", "1:31.909", "1:33.737", 20 },
                    { 39, 10, 21, 21, 17, "1:36.240", " ", "NULL", 19 },
                    { 26, 1, 1, 22, 4, "1:35.392", "1:34.627", "1:36.709", 19 },
                    { 13, 11, 18, 16, 13, "1:26.712", "1:26.259", "NULL", 18 },
                    { 24, 6, 8, 1, 2, "1:35.645", "1:34.188", "1:36.230", 19 },
                    { 25, 1, 5, 23, 3, "1:35.227", "1:34.759", "1:36.613", 19 },
                    { 2, 2, 9, 4, 2, "1:26.103", "1:25.315", "1:26.869", 18 },
                    { 3, 1, 5, 23, 3, "1:25.664", "1:25.452", "1:27.079", 18 },
                    { 4, 6, 13, 2, 4, "1:25.994", "1:25.691", "1:27.178", 18 },
                    { 5, 2, 2, 3, 5, "1:25.960", "1:25.518", "1:27.236", 18 },
                    { 6, 7, 15, 11, 6, "1:26.427", "1:26.101", "1:28.527", 18 },
                    { 7, 3, 3, 7, 7, "1:26.295", "1:26.059", "1:28.687", 18 },
                    { 8, 9, 14, 9, 8, "1:26.381", "1:26.063", "1:29.041", 18 },
                    { 9, 7, 10, 12, 9, "1:26.919", "1:26.164", "1:29.593", 18 },
                    { 10, 5, 20, 15, 10, "1:26.702", "1:25.842", "NULL", 18 },
                    { 11, 11, 22, 17, 11, "1:26.369", "1:26.173", "NULL", 18 },
                    { 1, 1, 1, 22, 1, "1:26.572", "1:25.187", "1:26.714", 18 },
                    { 14, 3, 6, 8, 14, "1:26.891", "1:26.413", "NULL", 18 },
                    { 15, 9, 17, 10, 15, "1:26.914", " ", "NULL", 18 },
                    { 16, 6, 8, 1, 16, "1:26.140", " ", "NULL", 18 },
                    { 17, 10, 21, 21, 17, "1:27.207", " ", "NULL", 18 },
                    { 18, 5, 7, 14, 18, "1:27.446", " ", "NULL", 18 },
                    { 19, 10, 16, 20, 19, "1:27.859", " ", "NULL", 18 },
                    { 20, 8, 11, 18, 20, "1:28.208", " ", "NULL", 18 },
                    { 21, 4, 12, 6, 21, "1:28.330", " ", "NULL", 18 },
                    { 22, 8, 19, 19, 22, "1:29.059", " ", "NULL", 18 },
                    { 23, 6, 13, 2, 1, "1:35.347", "1:34.412", "1:35.748", 19 },
                    { 12, 4, 4, 5, 12, "1:26.907", "1:26.188", "NULL", 18 }
                });

            migrationBuilder.InsertData(
                table: "RaceResults",
                columns: new[] { "Id", "ConstructorId", "DriverId", "FastestLap", "FastestLapSpeed", "FastestLapTime", "Grid", "Laps", "Milliseconds", "Number", "Points", "Position", "PositionOrder", "PositionText", "RaceId", "Rank", "StatusId", "Time" },
                values: new object[,]
                {
                    { 3, 3, 3, "41", "216.719", "01:28.1", 7, 58, "5698779", "7", 6f, "3", 3, "3", 18, "5", 1, "8.163" },
                    { 16, 10, 16, "8", "207.461", "01:32.0", 22, 8, "", "20", 0f, "", 16, "R", 18, "17", 9, "" },
                    { 17, 9, 17, "", "", "", 14, 0, "", "10", 0f, "", 17, "R", 18, "", 4, "" },
                    { 18, 11, 18, "", "", "", 12, 0, "", "16", 0f, "", 18, "R", 18, "", 4, "" },
                    { 24, 2, 9, "39", "208.033", "01:35.9", 4, 56, "5498125", "4", 8f, "2", 2, "2", 19, "6", 1, "19.57" },
                    { 20, 5, 20, "", "", "", 9, 0, "", "15", 0f, "", 20, "R", 18, "", 4, "" },
                    { 21, 10, 21, "", "", "", 16, 0, "", "21", 0f, "", 21, "R", 18, "", 4, "" },
                    { 22, 11, 22, "44", "215.141", "01:28.7", 10, 58, "", "17", 0f, "", 22, "D", 18, "8", 2, "" },
                    { 23, 6, 8, "37", "209.158", "01:35.4", 2, 56, "5478555", "1", 10f, "1", 1, "1", 19, "2", 1, "31:18.6" },
                    { 19, 8, 19, "", "", "", 21, 0, "", "19", 0f, "", 19, "R", 18, "", 4, "" },
                    { 15, 7, 15, "18", "213.758", "01:29.3", 6, 19, "", "11", 0f, "", 15, "R", 18, "10", 10, "" },
                    { 10, 7, 10, "23", "213.166", "01:29.6", 18, 43, "", "12", 0f, "", 10, "R", 18, "13", 3, "" },
                    { 13, 6, 13, "23", "216.51", "01:28.2", 4, 29, "", "2", 0f, "", 13, "R", 18, "6", 5, "" },
                    { 12, 4, 12, "20", "208.907", "01:31.4", 20, 30, "", "6", 0f, "", 12, "R", 18, "16", 8, "" },
                    { 11, 8, 11, "24", "210.038", "01:30.9", 19, 32, "", "18", 0f, "", 11, "R", 18, "15", 7, "" },
                    { 9, 2, 9, "15", "215.1", "01:28.8", 2, 47, "", "4", 0f, "", 9, "R", 18, "9", 4, "" },
                    { 8, 6, 8, "20", "217.18", "01:27.9", 15, 53, "", "1", 1f, "8", 8, "8", 18, "4", 5, "" },
                    { 7, 5, 7, "22", "213.224", "01:29.5", 17, 55, "", "14", 2f, "7", 7, "7", 18, "12", 5, "" },
                    { 6, 3, 6, "50", "212.974", "01:29.6", 13, 57, "", "8", 3f, "6", 6, "6", 18, "14", 11, "" },
                    { 5, 1, 5, "43", "218.385", "01:27.4", 3, 58, "5708630", "23", 4f, "5", 5, "5", 18, "1", 1, "18.014" },
                    { 4, 4, 4, "58", "215.464", "01:28.6", 11, 58, "5707797", "5", 5f, "4", 4, "4", 18, "7", 1, "17.181" },
                    { 25, 1, 5, "19", "208.031", "01:35.9", 8, 56, "5517005", "23", 6f, "3", 3, "3", 19, "7", 1, "38.45" },
                    { 14, 9, 14, "21", "213.3", "01:29.5", 8, 25, "", "9", 0f, "", 14, "R", 18, "11", 4, "" },
                    { 26, 7, 15, "53", "207.715", "01:36.1", 3, 56, "5524387", "11", 5f, "4", 4, "4", 19, "8", 1, "45.832" },
                    { 38, 8, 11, "53", "202.578", "01:38.5", 19, 54, "", "18", 0f, "16", 16, "16", 19, "19", 12, "" },
                    { 28, 2, 2, "55", "209.244", "01:35.4", 5, 56, "5528388", "3", 3f, "6", 6, "6", 19, "1", 1, "49.833" },
                    { 2, 2, 2, "41", "217.586", "01:27.7", 5, 58, "5696094", "3", 8f, "2", 2, "2", 18, "3", 1, "5.478" },
                    { 50, 7, 15, "45", "206.819", "01:34.2", 7, 57, "5508284", "11", 3f, "6", 6, "6", 20, "7", 1, "41.314" },
                    { 49, 1, 5, "49", "209.062", "01:33.2", 5, 57, "5493759", "23", 4f, "5", 5, "5", 20, "1", 1, "26.789" },
                    { 48, 2, 2, "48", "208.231", "01:33.6", 6, 57, "5475379", "3", 5f, "4", 4, "4", 20, "2", 1, "8.409" },
                    { 47, 2, 9, "55", "207.765", "01:33.8", 1, 57, "5471968", "4", 6f, "3", 3, "3", 20, "5", 1, "4.998" },
                    { 46, 6, 8, "35", "207.911", "01:33.7", 4, 57, "5470309", "1", 8f, "2", 2, "2", 20, "4", 1, "3.339" },
                    { 45, 6, 13, "38", "208.153", "01:33.6", 2, 57, "5466970", "2", 10f, "1", 1, "1", 20, "3", 1, "31:07.0" },
                    { 44, 5, 7, "", "", "", 18, 0, "", "14", 0f, "", 22, "R", 19, "", 20, "" },
                    { 43, 7, 10, "", "", "", 10, 1, "", "12", 0f, "", 21, "R", 19, "", 4, "" },
                    { 42, 10, 16, "3", "198.891", "01:40.3", 20, 5, "", "20", 0f, "", 20, "R", 19, "20", 9, "" },
                    { 27, 1, 1, "53", "209.033", "01:35.5", 9, 56, "5525103", "22", 4f, "5", 5, "5", 19, "3", 1, "46.548" },
                    { 41, 6, 13, "15", "208.048", "01:35.9", 1, 30, "", "2", 0f, "", 19, "R", 19, "5", 20, "" },
                    { 39, 3, 6, "19", "204.222", "01:37.7", 22, 54, "", "8", 0f, "17", 17, "17", 19, "17", 12, "" },
                    { 37, 8, 19, "55", "203.265", "01:38.2", 21, 55, "", "19", 0f, "15", 15, "15", 19, "18", 11, "" },
                    { 36, 3, 3, "55", "206.182", "01:36.8", 16, 55, "", "7", 0f, "14", 14, "14", 19, "13", 11, "" },
                    { 35, 11, 22, "55", "206.372", "01:36.7", 14, 55, "", "17", 0f, "13", 13, "13", 19, "11", 11, "" },
                    { 34, 10, 21, "52", "205.8", "01:37.0", 17, 55, "", "21", 0f, "12", 12, "12", 19, "16", 11, "" },
                    { 33, 4, 12, "52", "205.812", "01:37.0", 13, 56, "5570757", "6", 0f, "11", 11, "11", 19, "15", 1, "+1:32.202" },
                    { 32, 11, 18, "56", "208.481", "01:35.7", 11, 56, "5564769", "16", 0f, "10", 10, "10", 19, "4", 1, "+1:26.214" },
                    { 31, 9, 14, "55", "207.417", "01:36.2", 12, 56, "5554775", "9", 0f, "9", 9, "9", 19, "9", 1, "+1:16.220" },
                    { 30, 4, 4, "40", "207.24", "01:36.3", 7, 56, "5548596", "5", 1f, "8", 8, "8", 19, "10", 1, "+1:10.041" },
                    { 29, 9, 17, "53", "206.366", "01:36.7", 6, 56, "5546685", "10", 2f, "7", 7, "7", 19, "12", 1, "+1:08.130" },
                    { 40, 5, 20, "37", "205.995", "01:36.9", 15, 39, "", "15", 0f, "", 18, "R", 19, "14", 5, "" },
                    { 1, 1, 1, "39", "218.3", "01:27.5", 1, 58, "5690616", "22", 10f, "1", 1, "1", 18, "2", 1, "34:50.6" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "CircuitId", "Date", "Name", "Round", "Time", "Url", "Year" },
                values: new object[,]
                {
                    { 38, 3, "2007-04-15", "Bahrain Grand Prix", "3", "11:30:00", "http://en.wikipedia.org/wiki/2007_Bahrain_Grand_Prix", "2007" },
                    { 49, 13, "2007-09-16", "Belgian Grand Prix", "14", "12:00:00", "http://en.wikipedia.org/wiki/2007_Belgian_Grand_Prix", "2007" },
                    { 22, 5, "2008-05-11", "Turkish Grand Prix", "5", "12:00:00", "http://en.wikipedia.org/wiki/2008_Turkish_Grand_Prix", "2008" },
                    { 21, 4, "2008-04-27", "Spanish Grand Prix", "4", "12:00:00", "http://en.wikipedia.org/wiki/2008_Spanish_Grand_Prix", "2008" },
                    { 20, 3, "2008-04-06", "Bahrain Grand Prix", "3", "11:30:00", "http://en.wikipedia.org/wiki/2008_Bahrain_Grand_Prix", "2008" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "CircuitId", "Date", "Name", "Round", "Time", "Url", "Year" },
                values: new object[,]
                {
                    { 19, 2, "2008-03-23", "Malaysian Grand Prix", "2", "07:00:00", "http://en.wikipedia.org/wiki/2008_Malaysian_Grand_Prix", "2008" },
                    { 18, 1, "2008-03-16", "Australian Grand Prix", "1", "04:30:00", "http://en.wikipedia.org/wiki/2008_Australian_Grand_Prix", "2008" },
                    { 17, 24, "2009-11-01", "Abu Dhabi Grand Prix", "17", "11:00:00", "http://en.wikipedia.org/wiki/2009_Abu_Dhabi_Grand_Prix", "2009" },
                    { 16, 18, "2009-10-18", "Brazilian Grand Prix", "16", "16:00:00", "http://en.wikipedia.org/wiki/2009_Brazilian_Grand_Prix", "2009" },
                    { 15, 22, "2009-10-04", "Japanese Grand Prix", "15", "05:00:00", "http://en.wikipedia.org/wiki/2009_Japanese_Grand_Prix", "2009" },
                    { 14, 15, "2009-09-27", "Singapore Grand Prix", "14", "12:00:00", "http://en.wikipedia.org/wiki/2009_Singapore_Grand_Prix", "2009" },
                    { 12, 13, "2009-08-30", "Belgian Grand Prix", "12", "12:00:00", "http://en.wikipedia.org/wiki/2009_Belgian_Grand_Prix", "2009" },
                    { 11, 12, "2009-08-23", "European Grand Prix", "11", "12:00:00", "http://en.wikipedia.org/wiki/2009_European_Grand_Prix", "2009" },
                    { 10, 11, "2009-07-26", "Hungarian Grand Prix", "10", "12:00:00", "http://en.wikipedia.org/wiki/2009_Hungarian_Grand_Prix", "2009" },
                    { 9, 20, "2009-07-12", "German Grand Prix", "9", "12:00:00", "http://en.wikipedia.org/wiki/2009_German_Grand_Prix", "2009" },
                    { 8, 9, "2009-06-21", "British Grand Prix", "8", "12:00:00", "http://en.wikipedia.org/wiki/2009_British_Grand_Prix", "2009" },
                    { 7, 5, "2009-06-07", "Turkish Grand Prix", "7", "12:00:00", "http://en.wikipedia.org/wiki/2009_Turkish_Grand_Prix", "2009" },
                    { 6, 6, "2009-05-24", "Monaco Grand Prix", "6", "12:00:00", "http://en.wikipedia.org/wiki/2009_Monaco_Grand_Prix", "2009" },
                    { 5, 4, "2009-05-10", "Spanish Grand Prix", "5", "12:00:00", "http://en.wikipedia.org/wiki/2009_Spanish_Grand_Prix", "2009" },
                    { 4, 3, "2009-04-26", "Bahrain Grand Prix", "4", "12:00:00", "http://en.wikipedia.org/wiki/2009_Bahrain_Grand_Prix", "2009" },
                    { 3, 17, "2009-04-19", "Chinese Grand Prix", "3", "07:00:00", "http://en.wikipedia.org/wiki/2009_Chinese_Grand_Prix", "2009" },
                    { 2, 2, "2009-04-05", "Malaysian Grand Prix", "2", "09:00:00", "http://en.wikipedia.org/wiki/2009_Malaysian_Grand_Prix", "2009" },
                    { 1, 1, "2009-03-29", "Australian Grand Prix", "1", "06:00:00", "http://en.wikipedia.org/wiki/2009_Australian_Grand_Prix", "2009" },
                    { 23, 6, "2008-05-25", "Monaco Grand Prix", "6", "12:00:00", "http://en.wikipedia.org/wiki/2008_Monaco_Grand_Prix", "2008" },
                    { 24, 7, "2008-06-08", "Canadian Grand Prix", "7", "17:00:00", "http://en.wikipedia.org/wiki/2008_Canadian_Grand_Prix", "2008" },
                    { 13, 14, "2009-09-13", "Italian Grand Prix", "13", "12:00:00", "http://en.wikipedia.org/wiki/2009_Italian_Grand_Prix", "2009" },
                    { 26, 9, "2008-07-06", "British Grand Prix", "9", "12:00:00", "http://en.wikipedia.org/wiki/2008_British_Grand_Prix", "2008" },
                    { 25, 8, "2008-06-22", "French Grand Prix", "8", "12:00:00", "http://en.wikipedia.org/wiki/2008_French_Grand_Prix", "2008" },
                    { 47, 5, "2007-08-26", "Turkish Grand Prix", "12", "12:00:00", "http://en.wikipedia.org/wiki/2007_Turkish_Grand_Prix", "2007" },
                    { 46, 11, "2007-08-05", "Hungarian Grand Prix", "11", "12:00:00", "http://en.wikipedia.org/wiki/2007_Hungarian_Grand_Prix", "2007" },
                    { 45, 20, "2007-07-22", "European Grand Prix", "10", "12:00:00", "http://en.wikipedia.org/wiki/2007_European_Grand_Prix", "2007" },
                    { 44, 9, "2007-07-08", "British Grand Prix", "9", "12:00:00", "http://en.wikipedia.org/wiki/2007_British_Grand_Prix", "2007" },
                    { 43, 8, "2007-07-01", "French Grand Prix", "8", "12:00:00", "http://en.wikipedia.org/wiki/2007_French_Grand_Prix", "2007" },
                    { 42, 19, "2007-06-17", "United States Grand Prix", "7", "17:00:00", "http://en.wikipedia.org/wiki/2007_United_States_Grand_Prix", "2007" },
                    { 41, 7, "2007-06-10", "Canadian Grand Prix", "6", "17:00:00", "http://en.wikipedia.org/wiki/2007_Canadian_Grand_Prix", "2007" },
                    { 40, 6, "2007-05-27", "Monaco Grand Prix", "5", "12:00:00", "http://en.wikipedia.org/wiki/2007_Monaco_Grand_Prix", "2007" },
                    { 39, 4, "2007-05-13", "Spanish Grand Prix", "4", "12:00:00", "http://en.wikipedia.org/wiki/2007_Spanish_Grand_Prix", "2007" },
                    { 37, 2, "2007-04-08", "Malaysian Grand Prix", "2", "07:00:00", "http://en.wikipedia.org/wiki/2007_Malaysian_Grand_Prix", "2007" },
                    { 48, 14, "2007-09-09", "Italian Grand Prix", "13", "12:00:00", "http://en.wikipedia.org/wiki/2007_Italian_Grand_Prix", "2007" },
                    { 50, 16, "2007-09-30", "Japanese Grand Prix", "15", "04:30:00", "http://en.wikipedia.org/wiki/2007_Japanese_Grand_Prix", "2007" },
                    { 28, 11, "2008-08-03", "Hungarian Grand Prix", "11", "12:00:00", "http://en.wikipedia.org/wiki/2008_Hungarian_Grand_Prix", "2008" },
                    { 29, 12, "2008-08-24", "European Grand Prix", "12", "12:00:00", "http://en.wikipedia.org/wiki/2008_European_Grand_Prix", "2008" },
                    { 30, 13, "2008-09-07", "Belgian Grand Prix", "13", "12:00:00", "http://en.wikipedia.org/wiki/2008_Belgian_Grand_Prix", "2008" },
                    { 31, 14, "2008-09-14", "Italian Grand Prix", "14", "12:00:00", "http://en.wikipedia.org/wiki/2008_Italian_Grand_Prix", "2008" },
                    { 27, 10, "2008-07-20", "German Grand Prix", "10", "12:00:00", "http://en.wikipedia.org/wiki/2008_German_Grand_Prix", "2008" },
                    { 33, 16, "2008-10-12", "Japanese Grand Prix", "16", "04:30:00", "http://en.wikipedia.org/wiki/2008_Japanese_Grand_Prix", "2008" },
                    { 34, 17, "2008-10-19", "Chinese Grand Prix", "17", "07:00:00", "http://en.wikipedia.org/wiki/2008_Chinese_Grand_Prix", "2008" },
                    { 35, 18, "2008-11-02", "Brazilian Grand Prix", "18", "17:00:00", "http://en.wikipedia.org/wiki/2008_Brazilian_Grand_Prix", "2008" },
                    { 36, 1, "2007-03-18", "Australian Grand Prix", "1", "03:00:00", "http://en.wikipedia.org/wiki/2007_Australian_Grand_Prix", "2007" },
                    { 32, 15, "2008-09-28", "Singapore Grand Prix", "15", "12:00:00", "http://en.wikipedia.org/wiki/2008_Singapore_Grand_Prix", "2008" }
                });

            migrationBuilder.InsertData(
                table: "ResultStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 37, "Throttle" },
                    { 28, "Driver Seat" },
                    { 29, "Puncture" },
                    { 30, "Driveshaft" },
                    { 31, "Retired" },
                    { 32, "Fuel pressure" },
                    { 33, "Front wing" },
                    { 34, "Water pressure" },
                    { 35, "Refuelling" },
                    { 36, "Wheel" },
                    { 38, "Steering" },
                    { 43, "Exhaust" },
                    { 40, "Electronics" },
                    { 41, "Broken wing" },
                    { 42, "Heat shield fire" },
                    { 27, "Tyre" },
                    { 44, "Oil leak" },
                    { 45, "+11 Laps" },
                    { 46, "Wheel rim" },
                    { 47, "Water leak" },
                    { 48, "Fuel pump" },
                    { 49, "Track rod" },
                    { 39, "Technical" },
                    { 50, "+17 Laps" },
                    { 26, "Mechanical" },
                    { 24, "Differential" },
                    { 1, "Finished" },
                    { 2, "Disqualified" },
                    { 3, "Accident" },
                    { 4, "Collision" },
                    { 5, "Engine" },
                    { 6, "Gearbox" },
                    { 25, "Overheating" },
                    { 8, "Clutch" },
                    { 9, "Hydraulics" },
                    { 10, "Electrical" },
                    { 11, "+1 Lap" },
                    { 7, "Transmission" },
                    { 13, "+3 Laps" },
                    { 12, "+2 Laps" },
                    { 22, "Suspension" },
                    { 21, "Radiator" },
                    { 20, "Spun off" },
                    { 19, "+9 Laps" },
                    { 23, "Brakes" },
                    { 17, "+7 Laps" },
                    { 16, "+6 Laps" },
                    { 15, "+5 Laps" },
                    { 14, "+4 Laps" },
                    { 18, "+8 Laps" }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "Url", "Year" },
                values: new object[,]
                {
                    { 27, "http://en.wikipedia.org/wiki/1984_Formula_One_season", 1984 },
                    { 28, "http://en.wikipedia.org/wiki/1983_Formula_One_season", 1983 },
                    { 29, "http://en.wikipedia.org/wiki/1982_Formula_One_season", 1982 },
                    { 30, "http://en.wikipedia.org/wiki/1981_Formula_One_season", 1981 },
                    { 31, "http://en.wikipedia.org/wiki/1980_Formula_One_season", 1980 },
                    { 32, "http://en.wikipedia.org/wiki/1979_Formula_One_season", 1979 },
                    { 33, "http://en.wikipedia.org/wiki/1978_Formula_One_season", 1978 },
                    { 34, "http://en.wikipedia.org/wiki/1977_Formula_One_season", 1977 },
                    { 35, "http://en.wikipedia.org/wiki/1976_Formula_One_season", 1976 },
                    { 36, "http://en.wikipedia.org/wiki/1975_Formula_One_season", 1975 },
                    { 48, "http://en.wikipedia.org/wiki/1963_Formula_One_season", 1963 },
                    { 38, "http://en.wikipedia.org/wiki/1973_Formula_One_season", 1973 },
                    { 39, "http://en.wikipedia.org/wiki/1972_Formula_One_season", 1972 },
                    { 40, "http://en.wikipedia.org/wiki/1971_Formula_One_season", 1971 },
                    { 41, "http://en.wikipedia.org/wiki/1970_Formula_One_season", 1970 },
                    { 42, "http://en.wikipedia.org/wiki/1969_Formula_One_season", 1969 },
                    { 43, "http://en.wikipedia.org/wiki/1968_Formula_One_season", 1968 },
                    { 44, "http://en.wikipedia.org/wiki/1967_Formula_One_season", 1967 },
                    { 45, "http://en.wikipedia.org/wiki/1966_Formula_One_season", 1966 },
                    { 46, "http://en.wikipedia.org/wiki/1965_Formula_One_season", 1965 },
                    { 47, "http://en.wikipedia.org/wiki/1964_Formula_One_season", 1964 },
                    { 26, "http://en.wikipedia.org/wiki/1985_Formula_One_season", 1985 },
                    { 37, "http://en.wikipedia.org/wiki/1974_Formula_One_season", 1974 },
                    { 25, "http://en.wikipedia.org/wiki/1986_Formula_One_season", 1986 },
                    { 13, "http://en.wikipedia.org/wiki/1997_Formula_One_season", 1997 },
                    { 23, "http://en.wikipedia.org/wiki/1988_Formula_One_season", 1988 },
                    { 49, "http://en.wikipedia.org/wiki/1962_Formula_One_season", 1962 },
                    { 1, "http://en.wikipedia.org/wiki/2009_Formula_One_season", 2009 },
                    { 2, "http://en.wikipedia.org/wiki/2008_Formula_One_season", 2008 },
                    { 3, "http://en.wikipedia.org/wiki/2007_Formula_One_season", 2007 },
                    { 4, "http://en.wikipedia.org/wiki/2006_Formula_One_season", 2006 },
                    { 5, "http://en.wikipedia.org/wiki/2005_Formula_One_season", 2005 },
                    { 6, "http://en.wikipedia.org/wiki/2004_Formula_One_season", 2004 },
                    { 7, "http://en.wikipedia.org/wiki/2003_Formula_One_season", 2003 },
                    { 8, "http://en.wikipedia.org/wiki/2002_Formula_One_season", 2002 },
                    { 9, "http://en.wikipedia.org/wiki/2001_Formula_One_season", 2001 },
                    { 24, "http://en.wikipedia.org/wiki/1987_Formula_One_season", 1987 },
                    { 10, "http://en.wikipedia.org/wiki/2000_Formula_One_season", 2000 },
                    { 12, "http://en.wikipedia.org/wiki/1998_Formula_One_season", 1998 },
                    { 14, "http://en.wikipedia.org/wiki/1996_Formula_One_season", 1996 },
                    { 15, "http://en.wikipedia.org/wiki/1995_Formula_One_season", 1995 },
                    { 16, "http://en.wikipedia.org/wiki/1994_Formula_One_season", 1994 },
                    { 17, "http://en.wikipedia.org/wiki/1993_Formula_One_season", 1993 },
                    { 18, "http://en.wikipedia.org/wiki/1992_Formula_One_season", 1992 },
                    { 19, "http://en.wikipedia.org/wiki/1991_Formula_One_season", 1991 },
                    { 20, "http://en.wikipedia.org/wiki/1990_Formula_One_season", 1990 },
                    { 21, "http://en.wikipedia.org/wiki/2010_Formula_One_season", 2010 },
                    { 22, "http://en.wikipedia.org/wiki/1989_Formula_One_season", 1989 },
                    { 11, "http://en.wikipedia.org/wiki/1999_Formula_One_season", 1999 },
                    { 50, "http://en.wikipedia.org/wiki/1961_Formula_One_season", 1961 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Circuits");

            migrationBuilder.DropTable(
                name: "ConstructorResults");

            migrationBuilder.DropTable(
                name: "Constructors");

            migrationBuilder.DropTable(
                name: "ConstructorStandings");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "DriverStandings");

            migrationBuilder.DropTable(
                name: "LapTimes");

            migrationBuilder.DropTable(
                name: "PitStops");

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
