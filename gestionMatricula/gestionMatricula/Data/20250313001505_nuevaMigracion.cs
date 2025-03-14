using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestionMatricula.Migrations
{
    /// <inheritdoc />
    public partial class nuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Abiertas_Aulas_AulaId",
                table: "Materias_Abiertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Abiertas_Materias_Carreras_MateriaCarreraId",
                table: "Materias_Abiertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Abiertas_Periodo_PeriodoId",
                table: "Materias_Abiertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Abiertas_Profesores_ProfesorCod_Profesor",
                table: "Materias_Abiertas");

            migrationBuilder.AlterColumn<int>(
                name: "ProfesorCod_Profesor",
                table: "Materias_Abiertas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodoId",
                table: "Materias_Abiertas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MateriaCarreraId",
                table: "Materias_Abiertas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AulaId",
                table: "Materias_Abiertas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Materias_Abiertas",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Abiertas_Aulas_AulaId",
                table: "Materias_Abiertas",
                column: "AulaId",
                principalTable: "Aulas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Abiertas_Materias_Carreras_MateriaCarreraId",
                table: "Materias_Abiertas",
                column: "MateriaCarreraId",
                principalTable: "Materias_Carreras",
                principalColumn: "Id_MateriaCarrera");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Abiertas_Periodo_PeriodoId",
                table: "Materias_Abiertas",
                column: "PeriodoId",
                principalTable: "Periodo",
                principalColumn: "id_Periodo");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Abiertas_Profesores_ProfesorCod_Profesor",
                table: "Materias_Abiertas",
                column: "ProfesorCod_Profesor",
                principalTable: "Profesores",
                principalColumn: "Cod_Profesor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Abiertas_Aulas_AulaId",
                table: "Materias_Abiertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Abiertas_Materias_Carreras_MateriaCarreraId",
                table: "Materias_Abiertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Abiertas_Periodo_PeriodoId",
                table: "Materias_Abiertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Abiertas_Profesores_ProfesorCod_Profesor",
                table: "Materias_Abiertas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Materias_Abiertas");

            migrationBuilder.AlterColumn<int>(
                name: "ProfesorCod_Profesor",
                table: "Materias_Abiertas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeriodoId",
                table: "Materias_Abiertas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MateriaCarreraId",
                table: "Materias_Abiertas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AulaId",
                table: "Materias_Abiertas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Abiertas_Aulas_AulaId",
                table: "Materias_Abiertas",
                column: "AulaId",
                principalTable: "Aulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Abiertas_Materias_Carreras_MateriaCarreraId",
                table: "Materias_Abiertas",
                column: "MateriaCarreraId",
                principalTable: "Materias_Carreras",
                principalColumn: "Id_MateriaCarrera",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Abiertas_Periodo_PeriodoId",
                table: "Materias_Abiertas",
                column: "PeriodoId",
                principalTable: "Periodo",
                principalColumn: "id_Periodo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Abiertas_Profesores_ProfesorCod_Profesor",
                table: "Materias_Abiertas",
                column: "ProfesorCod_Profesor",
                principalTable: "Profesores",
                principalColumn: "Cod_Profesor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
