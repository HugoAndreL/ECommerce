using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce_API.Migrations
{
    /// <inheritdoc />
    public partial class _12092023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompraProdId",
                table: "Historicos");

            migrationBuilder.AddColumn<int>(
                name: "HistoricoId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_HistoricoId",
                table: "Compras",
                column: "HistoricoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Historicos_HistoricoId",
                table: "Compras",
                column: "HistoricoId",
                principalTable: "Historicos",
                principalColumn: "Id_Historico",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Historicos_HistoricoId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_HistoricoId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "HistoricoId",
                table: "Compras");

            migrationBuilder.AddColumn<int>(
                name: "CompraProdId",
                table: "Historicos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
