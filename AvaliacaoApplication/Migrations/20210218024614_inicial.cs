using Microsoft.EntityFrameworkCore.Migrations;

namespace AvaliacaoApi.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoOrigem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentidoVia = table.Column<int>(type: "int", nullable: false),
                    SentidoLeitura = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
