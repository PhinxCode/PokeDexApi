using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitCM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Naturaleza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PS = table.Column<byte>(type: "tinyint", nullable: false),
                    Ataque = table.Column<byte>(type: "tinyint", nullable: false),
                    Defensa = table.Column<byte>(type: "tinyint", nullable: false),
                    AtaqueEspecial = table.Column<byte>(type: "tinyint", nullable: false),
                    DefensaEspecial = table.Column<byte>(type: "tinyint", nullable: false),
                    Velocidad = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ataques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poder = table.Column<byte>(type: "tinyint", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ataques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ataques_Pokemones_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsPasiva = table.Column<bool>(type: "bit", nullable: false),
                    Slot = table.Column<byte>(type: "tinyint", nullable: false),
                    PokemonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habilidades_Pokemones_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ataques_PokemonId",
                table: "Ataques",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_PokemonId",
                table: "Habilidades",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ataques");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "Pokemones");
        }
    }
}
