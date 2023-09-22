using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce_API.Migrations
{
    /// <inheritdoc />
    public partial class _20092023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ClienteId",
                table: "Avaliacoes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Clientes_ClienteId",
                table: "Avaliacoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id_Client",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Clientes_ClienteId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_ClienteId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Avaliacoes");
        }
    }
}
