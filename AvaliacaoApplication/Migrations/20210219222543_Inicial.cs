﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace AvaliacaoApplication.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Autoincrement", true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentidoVia = table.Column<int>(type: "int", nullable: false),
                    SentidoLeitura = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
