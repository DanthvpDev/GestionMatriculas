using gestionMatricula.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace gestionMatricula.Data
{
    public class DBContextApp : DbContext
    {
        public DBContextApp(DbContextOptions<DBContextApp> options) : base(options){}

        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Canton> Cantones { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<DetalleMatricula> Detalles_Matricula { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaAbierta> Materias_Abiertas { get; set; }
        public DbSet<MateriaCarrera> Materias_Carreras { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Provincia> Provincias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Relación uno a muchos entre DetallesMatricula - Matricula y DetallesMatricula - MateriasAbiertas
            modelBuilder.Entity<DetalleMatricula>()
                .HasKey(dm => new { dm.Num_Recibo, dm.id_MateriaAbierta });
            
            modelBuilder.Entity<DetalleMatricula>()
                .HasOne(dm => dm.Matricula)
                .WithMany(m => m.DetalleMatriculas)
                .HasForeignKey(dm => dm.Num_Recibo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DetalleMatricula>()
                .HasOne(dm => dm.MateriaAbierta)
                .WithMany(ma => ma.DetallesMatriculas)
                .HasForeignKey(dm => dm.id_MateriaAbierta)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MateriaCarrera>()
                .HasOne(mc => mc.Materia)
                .WithMany(m => m.MateriasCarreras)
                .HasForeignKey(mc => mc.Id_Materia)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MateriaCarrera>()
               .HasOne(mc => mc.Carrera)
               .WithMany(c => c.MateriasCarreras)
               .HasForeignKey(mc => mc.Id_Carrera);

            modelBuilder.Entity<MateriaCarrera>()
                 .HasOne(mc => mc.Requisito)
                 .WithMany()
                 .HasForeignKey(mc => mc.Id_Requisito)
                 .OnDelete(DeleteBehavior.NoAction);


            //Constraints
            modelBuilder.Entity<Carrera>()
                .ToTable(c => c.HasCheckConstraint("CHK_TOTAL_CREDITOS_CARRERA", "[Total_Creditos] >= 0 AND [Total_Creditos] <= 1000"));

            modelBuilder.Entity<DetalleMatricula>()
                .ToTable(dm => dm.HasCheckConstraint("CHK_NOTA_FINAL_DETALLE_M", "[Nota_Final] >= 0 AND [Nota_Final] <= 100"));

            modelBuilder.Entity<Materia>()
                .ToTable(m => m.HasCheckConstraint("CHK_CREDITOS_MATERIA", "[Creditos] >= 0 AND [Creditos] <= 12"));

            modelBuilder.Entity<MateriaAbierta>()
                .ToTable(ma =>
                {
                    ma.HasCheckConstraint("CHK_COSTO_MATERIA_ABIERTA", "[Costo] >= 0");
                    ma.HasCheckConstraint("CHK_DESCUENTO_MATERIA_ABIERTA", "[Descuento] >= 0 AND [Descuento] <= 100");   
                });

            modelBuilder.Entity<Matricula>()
                .ToTable(m =>
                {
                    m.HasCheckConstraint("CHK_COSTO_MATRICULA", "[Costo_Matricula] >= 0");
                    m.HasCheckConstraint("CHK_DESCUENTO_MATRICULA", "[Descuento] >= 0 AND [Descuento] <= 100");
                });

            modelBuilder.Entity<Periodo>() 
                .ToTable(p =>
                 {
                     p.HasCheckConstraint("CHK_FECHA_INICIO_PERIODO", "[FechaI_Extraordinaria] < [FechaF_Extraordinaria]");
                     p.HasCheckConstraint("CHK_FECHA_FIN_PERIODO", "[FechaF_Extraordinaria] > [FechaI_Extraordinaria]");
                 });                
        }
    }
}
