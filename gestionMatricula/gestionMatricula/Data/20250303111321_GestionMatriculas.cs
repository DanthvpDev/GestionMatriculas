using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestionMatricula.Migrations
{
    /// <inheritdoc />
    public partial class GestionMatriculas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id_Carrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Carrera = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Total_Creditos = table.Column<int>(type: "int", nullable: false),
                    Grado = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Estado_C = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Borrado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id_Carrera);
                    table.CheckConstraint("CHK_TOTAL_CREDITOS_CARRERA", "[Total_Creditos] >= 0 AND [Total_Creditos] <= 1000");
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id_Materia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre_Materia = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false),
                    Borrado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id_Materia);
                    table.CheckConstraint("CHK_CREDITOS_MATERIA", "[Creditos] >= 0 AND [Creditos] <= 12");
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    id_Periodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Periodo = table.Column<int>(type: "int", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    FechaI_Matricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaF_Matricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaI_Extraordinaria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaF_Extraordinaria = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.id_Periodo);
                    table.CheckConstraint("CHK_FECHA_FIN_PERIODO", "[FechaF_Extraordinaria] > [FechaI_Extraordinaria]");
                    table.CheckConstraint("CHK_FECHA_INICIO_PERIODO", "[FechaI_Extraordinaria] < [FechaF_Extraordinaria]");
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Cod_Profesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Profesor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido1_P = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido2_P = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Telefono_P = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Correo_E = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Estado_P = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Borrado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Cod_Profesor);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias_Carreras",
                columns: table => new
                {
                    Id_MateriaCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Materia = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Id_Carrera = table.Column<int>(type: "int", nullable: false),
                    Id_Requisito = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias_Carreras", x => x.Id_MateriaCarrera);
                    table.ForeignKey(
                        name: "FK_Materias_Carreras_Carreras_Id_Carrera",
                        column: x => x.Id_Carrera,
                        principalTable: "Carreras",
                        principalColumn: "Id_Carrera",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Carreras_Materias_Id_Materia",
                        column: x => x.Id_Materia,
                        principalTable: "Materias",
                        principalColumn: "Id_Materia");
                    table.ForeignKey(
                        name: "FK_Materias_Carreras_Materias_Id_Requisito",
                        column: x => x.Id_Requisito,
                        principalTable: "Materias",
                        principalColumn: "Id_Materia");
                });

            migrationBuilder.CreateTable(
                name: "Cantones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    provinciaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cantones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cantones_Provincias_provinciaID",
                        column: x => x.provinciaID,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materias_Abiertas",
                columns: table => new
                {
                    id_MateriaAbierta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grupo = table.Column<int>(type: "int", nullable: false),
                    Cupos = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    id_Periodo = table.Column<int>(type: "int", nullable: false),
                    PeriodoId = table.Column<int>(type: "int", nullable: false),
                    id_Profesor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfesorCod_Profesor = table.Column<int>(type: "int", nullable: false),
                    id_Aula = table.Column<int>(type: "int", nullable: false),
                    AulaId = table.Column<int>(type: "int", nullable: false),
                    id_MateriaCarrera = table.Column<int>(type: "int", nullable: false),
                    MateriaCarreraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias_Abiertas", x => x.id_MateriaAbierta);
                    table.CheckConstraint("CHK_COSTO_MATERIA_ABIERTA", "[Costo] >= 0");
                    table.CheckConstraint("CHK_DESCUENTO_MATERIA_ABIERTA", "[Descuento] >= 0 AND [Descuento] <= 100");
                    table.ForeignKey(
                        name: "FK_Materias_Abiertas_Aulas_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Abiertas_Materias_Carreras_MateriaCarreraId",
                        column: x => x.MateriaCarreraId,
                        principalTable: "Materias_Carreras",
                        principalColumn: "Id_MateriaCarrera",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Abiertas_Periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodo",
                        principalColumn: "id_Periodo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Abiertas_Profesores_ProfesorCod_Profesor",
                        column: x => x.ProfesorCod_Profesor,
                        principalTable: "Profesores",
                        principalColumn: "Cod_Profesor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distritos_Cantones_cantonID",
                        column: x => x.cantonID,
                        principalTable: "Cantones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id_Estudiante = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido1_E = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido2_E = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Telefono1_E = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Telefono2_E = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Correo_E = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Otras_Senias = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DistritoID = table.Column<int>(type: "int", nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado_E = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Borrado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id_Estudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Distritos_DistritoID",
                        column: x => x.DistritoID,
                        principalTable: "Distritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Num_Recibo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Estudiante = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstudianteId_Estudiante = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Fecha_Matricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_Periodo = table.Column<int>(type: "int", nullable: false),
                    PeriodoId = table.Column<int>(type: "int", nullable: false),
                    Costo_Matricula = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Num_Recibo);
                    table.CheckConstraint("CHK_COSTO_MATRICULA", "[Costo_Matricula] >= 0");
                    table.CheckConstraint("CHK_DESCUENTO_MATRICULA", "[Descuento] >= 0 AND [Descuento] <= 100");
                    table.ForeignKey(
                        name: "FK_Matriculas_Estudiantes_EstudianteId_Estudiante",
                        column: x => x.EstudianteId_Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "Id_Estudiante");
                    table.ForeignKey(
                        name: "FK_Matriculas_Periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodo",
                        principalColumn: "id_Periodo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalles_Matricula",
                columns: table => new
                {
                    Num_Recibo = table.Column<int>(type: "int", nullable: false),
                    id_MateriaAbierta = table.Column<int>(type: "int", nullable: false),
                    Nota_Final = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalles_Matricula", x => new { x.Num_Recibo, x.id_MateriaAbierta });
                    table.CheckConstraint("CHK_NOTA_FINAL_DETALLE_M", "[Nota_Final] >= 0 AND [Nota_Final] <= 100");
                    table.ForeignKey(
                        name: "FK_Detalles_Matricula_Materias_Abiertas_id_MateriaAbierta",
                        column: x => x.id_MateriaAbierta,
                        principalTable: "Materias_Abiertas",
                        principalColumn: "id_MateriaAbierta");
                    table.ForeignKey(
                        name: "FK_Detalles_Matricula_Matriculas_Num_Recibo",
                        column: x => x.Num_Recibo,
                        principalTable: "Matriculas",
                        principalColumn: "Num_Recibo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cantones_provinciaID",
                table: "Cantones",
                column: "provinciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_Matricula_id_MateriaAbierta",
                table: "Detalles_Matricula",
                column: "id_MateriaAbierta");

            migrationBuilder.CreateIndex(
                name: "IX_Distritos_cantonID",
                table: "Distritos",
                column: "cantonID");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_DistritoID",
                table: "Estudiantes",
                column: "DistritoID");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Abiertas_AulaId",
                table: "Materias_Abiertas",
                column: "AulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Abiertas_MateriaCarreraId",
                table: "Materias_Abiertas",
                column: "MateriaCarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Abiertas_PeriodoId",
                table: "Materias_Abiertas",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Abiertas_ProfesorCod_Profesor",
                table: "Materias_Abiertas",
                column: "ProfesorCod_Profesor");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Carreras_Id_Carrera",
                table: "Materias_Carreras",
                column: "Id_Carrera");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Carreras_Id_Materia",
                table: "Materias_Carreras",
                column: "Id_Materia");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Carreras_Id_Requisito",
                table: "Materias_Carreras",
                column: "Id_Requisito");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_EstudianteId_Estudiante",
                table: "Matriculas",
                column: "EstudianteId_Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_PeriodoId",
                table: "Matriculas",
                column: "PeriodoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalles_Matricula");

            migrationBuilder.DropTable(
                name: "Materias_Abiertas");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Materias_Carreras");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Distritos");

            migrationBuilder.DropTable(
                name: "Cantones");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}
