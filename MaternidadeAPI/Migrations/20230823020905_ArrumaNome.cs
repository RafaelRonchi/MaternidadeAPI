using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaternidadeAPI.Migrations
{
    /// <inheritdoc />
    public partial class ArrumaNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecemNascido_Maes_MaeId",
                table: "RecemNascido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecemNascido",
                table: "RecemNascido");

            migrationBuilder.RenameTable(
                name: "RecemNascido",
                newName: "RecemNascidos");

            migrationBuilder.RenameIndex(
                name: "IX_RecemNascido_MaeId",
                table: "RecemNascidos",
                newName: "IX_RecemNascidos_MaeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecemNascidos",
                table: "RecemNascidos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecemNascidos_Maes_MaeId",
                table: "RecemNascidos",
                column: "MaeId",
                principalTable: "Maes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecemNascidos_Maes_MaeId",
                table: "RecemNascidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecemNascidos",
                table: "RecemNascidos");

            migrationBuilder.RenameTable(
                name: "RecemNascidos",
                newName: "RecemNascido");

            migrationBuilder.RenameIndex(
                name: "IX_RecemNascidos_MaeId",
                table: "RecemNascido",
                newName: "IX_RecemNascido_MaeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecemNascido",
                table: "RecemNascido",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecemNascido_Maes_MaeId",
                table: "RecemNascido",
                column: "MaeId",
                principalTable: "Maes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
