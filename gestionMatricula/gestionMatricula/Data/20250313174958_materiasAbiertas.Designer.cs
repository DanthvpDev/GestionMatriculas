﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gestionMatricula.Data;

#nullable disable

namespace gestionMatricula.Migrations
{
    [DbContext(typeof(DBContextApp))]
    [Migration("20250313174958_materiasAbiertas")]
    partial class materiasAbiertas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gestionMatricula.Models.Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("gestionMatricula.Models.Canton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("provinciaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("provinciaID");

                    b.ToTable("Cantones");
                });

            modelBuilder.Entity("gestionMatricula.Models.Carrera", b =>
                {
                    b.Property<int>("Id_Carrera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Carrera"));

                    b.Property<bool>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Estado_C")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Grado")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Nombre_Carrera")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Total_Creditos")
                        .HasColumnType("int");

                    b.HasKey("Id_Carrera");

                    b.ToTable("Carreras", t =>
                        {
                            t.HasCheckConstraint("CHK_TOTAL_CREDITOS_CARRERA", "[Total_Creditos] >= 0 AND [Total_Creditos] <= 1000");
                        });
                });

            modelBuilder.Entity("gestionMatricula.Models.DetalleMatricula", b =>
                {
                    b.Property<int>("Num_Recibo")
                        .HasColumnType("int");

                    b.Property<int>("id_MateriaAbierta")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<decimal>("Nota_Final")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Num_Recibo", "id_MateriaAbierta");

                    b.HasIndex("id_MateriaAbierta");

                    b.ToTable("Detalles_Matricula", t =>
                        {
                            t.HasCheckConstraint("CHK_NOTA_FINAL_DETALLE_M", "[Nota_Final] >= 0 AND [Nota_Final] <= 100");
                        });
                });

            modelBuilder.Entity("gestionMatricula.Models.Distrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cantonID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cantonID");

                    b.ToTable("Distritos");
                });

            modelBuilder.Entity("gestionMatricula.Models.Estudiante", b =>
                {
                    b.Property<string>("Id_Estudiante")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Apellido1_E")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Apellido2_E")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Correo_E")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("DistritoID")
                        .HasColumnType("int");

                    b.Property<string>("Estado_E")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("Fecha_Ingreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Otras_Senias")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Telefono1_E")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Telefono2_E")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id_Estudiante");

                    b.HasIndex("DistritoID");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("gestionMatricula.Models.Materia", b =>
                {
                    b.Property<string>("Id_Materia")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Borrado")
                        .HasColumnType("bit");

                    b.Property<int>("Creditos")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Materia")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id_Materia");

                    b.ToTable("Materias", t =>
                        {
                            t.HasCheckConstraint("CHK_CREDITOS_MATERIA", "[Creditos] >= 0 AND [Creditos] <= 12");
                        });
                });

            modelBuilder.Entity("gestionMatricula.Models.MateriaAbierta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_MateriaAbierta");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AulaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Cupos")
                        .HasColumnType("int");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("Grupo")
                        .HasColumnType("int");

                    b.Property<int?>("MateriaCarreraId")
                        .HasColumnType("int");

                    b.Property<int?>("PeriodoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfesorCod_Profesor")
                        .HasColumnType("int");

                    b.Property<int>("id_Aula")
                        .HasColumnType("int");

                    b.Property<int>("id_MateriaCarrera")
                        .HasColumnType("int");

                    b.Property<int>("id_Periodo")
                        .HasColumnType("int");

                    b.Property<int>("id_Profesor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AulaId");

                    b.HasIndex("MateriaCarreraId");

                    b.HasIndex("PeriodoId");

                    b.HasIndex("ProfesorCod_Profesor");

                    b.ToTable("Materias_Abiertas", t =>
                        {
                            t.HasCheckConstraint("CHK_COSTO_MATERIA_ABIERTA", "[Costo] >= 0");

                            t.HasCheckConstraint("CHK_DESCUENTO_MATERIA_ABIERTA", "[Descuento] >= 0 AND [Descuento] <= 100");
                        });
                });

            modelBuilder.Entity("gestionMatricula.Models.MateriaCarrera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_MateriaCarrera");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Borrado")
                        .HasColumnType("bit");

                    b.Property<int>("Id_Carrera")
                        .HasColumnType("int");

                    b.Property<string>("Id_Materia")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Id_Requisito")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Carrera");

                    b.HasIndex("Id_Materia");

                    b.HasIndex("Id_Requisito");

                    b.ToTable("Materias_Carreras");
                });

            modelBuilder.Entity("gestionMatricula.Models.Matricula", b =>
                {
                    b.Property<int>("Num_Recibo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Num_Recibo"));

                    b.Property<decimal>("Costo_Matricula")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("EstudianteId_Estudiante")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Fecha_Matricula")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PeriodoId")
                        .HasColumnType("int");

                    b.Property<string>("id_Estudiante")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("id_Periodo")
                        .HasColumnType("int");

                    b.HasKey("Num_Recibo");

                    b.HasIndex("EstudianteId_Estudiante");

                    b.HasIndex("PeriodoId");

                    b.ToTable("Matriculas", t =>
                        {
                            t.HasCheckConstraint("CHK_COSTO_MATRICULA", "[Costo_Matricula] >= 0");

                            t.HasCheckConstraint("CHK_DESCUENTO_MATRICULA", "[Descuento] >= 0 AND [Descuento] <= 100");
                        });
                });

            modelBuilder.Entity("gestionMatricula.Models.Periodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_Periodo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaF_Extraordinaria")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaF_Matricula")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaI_Extraordinaria")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaI_Matricula")
                        .HasColumnType("datetime2");

                    b.Property<int>("Num_Periodo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Periodo", t =>
                        {
                            t.HasCheckConstraint("CHK_FECHA_FIN_PERIODO", "[FechaF_Extraordinaria] > [FechaI_Extraordinaria]");

                            t.HasCheckConstraint("CHK_FECHA_INICIO_PERIODO", "[FechaI_Extraordinaria] < [FechaF_Extraordinaria]");
                        });
                });

            modelBuilder.Entity("gestionMatricula.Models.Profesor", b =>
                {
                    b.Property<int>("Cod_Profesor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Profesor"));

                    b.Property<string>("Apellido1_P")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Apellido2_P")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Correo_E")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Estado_P")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Id_Profesor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Telefono_P")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Cod_Profesor");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("gestionMatricula.Models.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("gestionMatricula.Models.Canton", b =>
                {
                    b.HasOne("gestionMatricula.Models.Provincia", "Provincia")
                        .WithMany("Cantones")
                        .HasForeignKey("provinciaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("gestionMatricula.Models.DetalleMatricula", b =>
                {
                    b.HasOne("gestionMatricula.Models.Matricula", "Matricula")
                        .WithMany("DetalleMatriculas")
                        .HasForeignKey("Num_Recibo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("gestionMatricula.Models.MateriaAbierta", "MateriaAbierta")
                        .WithMany("DetallesMatriculas")
                        .HasForeignKey("id_MateriaAbierta")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MateriaAbierta");

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("gestionMatricula.Models.Distrito", b =>
                {
                    b.HasOne("gestionMatricula.Models.Canton", "Canton")
                        .WithMany("Distritos")
                        .HasForeignKey("cantonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Canton");
                });

            modelBuilder.Entity("gestionMatricula.Models.Estudiante", b =>
                {
                    b.HasOne("gestionMatricula.Models.Distrito", "Distrito")
                        .WithMany("Estudiantes")
                        .HasForeignKey("DistritoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distrito");
                });

            modelBuilder.Entity("gestionMatricula.Models.MateriaAbierta", b =>
                {
                    b.HasOne("gestionMatricula.Models.Aula", "Aula")
                        .WithMany()
                        .HasForeignKey("AulaId");

                    b.HasOne("gestionMatricula.Models.MateriaCarrera", "MateriaCarrera")
                        .WithMany("MateriasAbiertas")
                        .HasForeignKey("MateriaCarreraId");

                    b.HasOne("gestionMatricula.Models.Periodo", "Periodo")
                        .WithMany()
                        .HasForeignKey("PeriodoId");

                    b.HasOne("gestionMatricula.Models.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorCod_Profesor");

                    b.Navigation("Aula");

                    b.Navigation("MateriaCarrera");

                    b.Navigation("Periodo");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("gestionMatricula.Models.MateriaCarrera", b =>
                {
                    b.HasOne("gestionMatricula.Models.Carrera", "Carrera")
                        .WithMany("MateriasCarreras")
                        .HasForeignKey("Id_Carrera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gestionMatricula.Models.Materia", "Materia")
                        .WithMany("MateriasCarreras")
                        .HasForeignKey("Id_Materia")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("gestionMatricula.Models.Materia", "Requisito")
                        .WithMany()
                        .HasForeignKey("Id_Requisito")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Carrera");

                    b.Navigation("Materia");

                    b.Navigation("Requisito");
                });

            modelBuilder.Entity("gestionMatricula.Models.Matricula", b =>
                {
                    b.HasOne("gestionMatricula.Models.Estudiante", "Estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteId_Estudiante");

                    b.HasOne("gestionMatricula.Models.Periodo", "Periodo")
                        .WithMany()
                        .HasForeignKey("PeriodoId");

                    b.Navigation("Estudiante");

                    b.Navigation("Periodo");
                });

            modelBuilder.Entity("gestionMatricula.Models.Canton", b =>
                {
                    b.Navigation("Distritos");
                });

            modelBuilder.Entity("gestionMatricula.Models.Carrera", b =>
                {
                    b.Navigation("MateriasCarreras");
                });

            modelBuilder.Entity("gestionMatricula.Models.Distrito", b =>
                {
                    b.Navigation("Estudiantes");
                });

            modelBuilder.Entity("gestionMatricula.Models.Materia", b =>
                {
                    b.Navigation("MateriasCarreras");
                });

            modelBuilder.Entity("gestionMatricula.Models.MateriaAbierta", b =>
                {
                    b.Navigation("DetallesMatriculas");
                });

            modelBuilder.Entity("gestionMatricula.Models.MateriaCarrera", b =>
                {
                    b.Navigation("MateriasAbiertas");
                });

            modelBuilder.Entity("gestionMatricula.Models.Matricula", b =>
                {
                    b.Navigation("DetalleMatriculas");
                });

            modelBuilder.Entity("gestionMatricula.Models.Provincia", b =>
                {
                    b.Navigation("Cantones");
                });
#pragma warning restore 612, 618
        }
    }
}
