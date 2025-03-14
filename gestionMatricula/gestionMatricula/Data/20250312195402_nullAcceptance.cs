using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestionMatricula.Migrations
{
    /// <inheritdoc />
    public partial class nullAcceptance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Periodo_PeriodoId",
                table: "Matriculas");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodoId",
                table: "Matriculas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Periodo_PeriodoId",
                table: "Matriculas",
                column: "PeriodoId",
                principalTable: "Periodo",
                principalColumn: "id_Periodo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Periodo_PeriodoId",
                table: "Matriculas");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodoId",
                table: "Matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Periodo_PeriodoId",
                table: "Matriculas",
                column: "PeriodoId",
                principalTable: "Periodo",
                principalColumn: "id_Periodo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
