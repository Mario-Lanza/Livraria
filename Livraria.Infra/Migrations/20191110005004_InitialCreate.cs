using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false, maxLength: 150),
                    Autor = table.Column<string>(nullable: true, maxLength: 70),
                    Editora = table.Column<string>(nullable: true, maxLength: 70),
                    DataPublicacao = table.Column<DateTime?>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    QuantidadeMinimaCompra = table.Column<int?>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
