using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAPITestBE.Migrations
{
    public partial class InitialsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "ID", "CreatedAt", "Description", "Image", "Rating", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1,new DateTime(2022, 8, 1, 10, 56, 31, DateTimeKind.Unspecified), "Pengabdi Setan adalah sebuah film horor Indonesia tahun 2022, yang disutradarai dan ditulis oleh Joko Anwar sebagai sekuel dari film tahun 2017", "", 7f, "Pengabdi Setan 2 Comunion",new DateTime(2022, 8, 1, 10, 56, 31, DateTimeKind.Unspecified) },
                    { 2,new DateTime(2022, 8, 1, 10, 56, 31, DateTimeKind.Unspecified), "Pengabdi Setan adalah sebuah film horor Indonesia tahun 2022, yang disutradarai dan ditulis oleh Joko Anwar sebagai sekuel dari film tahun 2017", "", 8f, "Pengabdi Setan",new DateTime(2022, 8, 1, 10, 56, 31, DateTimeKind.Unspecified) },
                    { 3,new DateTime(2022, 8, 1, 10, 56, 31, DateTimeKind.Unspecified), "Wakaf. Sebuah film yang menceritakan perebutan kepemilikan tanah wakaf", "", 8.6f, "Wakaf",new DateTime(2022, 8, 1, 10, 56, 31, DateTimeKind.Unspecified) },
                    { 4,new DateTime(2022, 8, 1, 10, 56, 31, DateTimeKind.Unspecified), "Sebuah film dengan kisah kejahatan barat yang epik, di mana cinta sejati melintasi jalan dengan pengkhianatan yang tak terkatakan.", "", 8.5f, "Killers of the flower moon",new DateTime(2022, 8, 1, 10, 56, 31, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
