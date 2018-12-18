using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Dados.Migrations
{
    public partial class Relacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Batalhas_BatalhaId",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_BatalhaId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "Samurais");

            migrationBuilder.CreateTable(
                name: "BatalhaSamurai",
                columns: table => new
                {
                    BatalhaId = table.Column<int>(nullable: false),
                    SamuraiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatalhaSamurai", x => new { x.BatalhaId, x.SamuraiId });
                    table.ForeignKey(
                        name: "FK_BatalhaSamurai_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatalhaSamurai_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentidadeSecreta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeReal = table.Column<string>(nullable: true),
                    SamuraiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentidadeSecreta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentidadeSecreta_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaSamurai_SamuraiId",
                table: "BatalhaSamurai",
                column: "SamuraiId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadeSecreta_SamuraiId",
                table: "IdentidadeSecreta",
                column: "SamuraiId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatalhaSamurai");

            migrationBuilder.DropTable(
                name: "IdentidadeSecreta");

            migrationBuilder.AddColumn<int>(
                name: "BatalhaId",
                table: "Samurais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_BatalhaId",
                table: "Samurais",
                column: "BatalhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Batalhas_BatalhaId",
                table: "Samurais",
                column: "BatalhaId",
                principalTable: "Batalhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
