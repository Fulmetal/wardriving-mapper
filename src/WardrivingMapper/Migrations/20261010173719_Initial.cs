using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrivingMapper.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MAC = table.Column<string>(type: "TEXT", nullable: false),
                    SSID = table.Column<string>(type: "TEXT", nullable: false),
                    AuthMode = table.Column<string>(type: "TEXT", nullable: false),
                    FirstSeen = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Channel = table.Column<int>(type: "INTEGER", nullable: true),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: true),
                    RSSI = table.Column<int>(type: "INTEGER", nullable: true),
                    CurrentLatitude = table.Column<double>(type: "REAL", nullable: false),
                    CurrentLongitude = table.Column<double>(type: "REAL", nullable: false),
                    AltitudeMeters = table.Column<double>(type: "REAL", nullable: false),
                    AccuracyMeters = table.Column<double>(type: "REAL", nullable: false),
                    RCOIs = table.Column<string>(type: "TEXT", nullable: true),
                    MfgrId = table.Column<int>(type: "INTEGER", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawData");
        }
    }
}
