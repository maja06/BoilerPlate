﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoilerPlate.Migrations
{
    public partial class Prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kancelarije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kancelarije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Osobe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    KancelarijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Osobe_Kancelarije_KancelarijaId",
                        column: x => x.KancelarijaId,
                        principalTable: "Kancelarije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uredjaji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UredjajIme = table.Column<string>(nullable: true),
                    OsobaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uredjaji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uredjaji_Osobe_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OsobeUredjaji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VrijemeOd = table.Column<DateTime>(nullable: false),
                    VrijemeDo = table.Column<DateTime>(nullable: true),
                    UredjajId = table.Column<int>(nullable: false),
                    OsobaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsobeUredjaji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsobeUredjaji_Osobe_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OsobeUredjaji_Uredjaji_UredjajId",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_KancelarijaId",
                table: "Osobe",
                column: "KancelarijaId");

            migrationBuilder.CreateIndex(
                name: "IX_OsobeUredjaji_OsobaId",
                table: "OsobeUredjaji",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_OsobeUredjaji_UredjajId",
                table: "OsobeUredjaji",
                column: "UredjajId");

            migrationBuilder.CreateIndex(
                name: "IX_Uredjaji_OsobaId",
                table: "Uredjaji",
                column: "OsobaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OsobeUredjaji");

            migrationBuilder.DropTable(
                name: "Uredjaji");

            migrationBuilder.DropTable(
                name: "Osobe");

            migrationBuilder.DropTable(
                name: "Kancelarije");
        }
    }
}
