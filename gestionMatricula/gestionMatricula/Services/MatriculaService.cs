using gestionMatricula.Data;
using gestionMatricula.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionMatricula.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly DBContextApp _context;

        public MatriculaService(DBContextApp context)
        {
            _context = context;
        }

        //Verifica si ya existe el detalle de matricula, de existir retorna -1 y si no lo agrega a la base de datos
        public async Task<int> AgregarDetalleMatricula(DetalleMatricula detalleMatricula)
        {
            try
            {
                DetalleMatricula? detalle = await _context.Detalles_Matricula.FirstOrDefaultAsync(dm => dm.id_MateriaAbierta.Equals(detalleMatricula.id_MateriaAbierta) && dm.Num_Recibo == detalleMatricula.Num_Recibo);
                if (detalle != null) return -1;
                _context.Detalles_Matricula.Add(detalleMatricula);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AgregarMatricula(Matricula matricula)
        {
            try
            {
                _context.Matricula.Add(matricula);
                await _context.SaveChangesAsync();
                return matricula.Num_Recibo;
            }
            catch (Exception) { throw; }
        }

        public async Task<Periodo> ObtenerPeriodos()
        {
            try
            {
                DateTime today = DateTime.UtcNow;
                return await _context.Periodos.Where(p => p.Anio == today.Year && (p.FechaI_Matricula <= today && p.FechaF_Matricula >= today) || (p.FechaI_Extraordinaria <= today && p.FechaF_Extraordinaria >= today)).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<DetalleMatricula>> ObtenerDetallesMatriculaActivos(int numRecibo)
        {
            try
            {
                return await _context.Detalles_Matricula.Where(dm => dm.Num_Recibo == numRecibo && (dm.Estado.Equals("ACT") || dm.Estado.Equals("APR"))).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> EstaMateriaAprobadaOActiva(int numRecibo, int materiaAbierta)
        {
            try
            {
                IEnumerable<DetalleMatricula> detalles = await ObtenerDetallesMatriculaActivos(numRecibo);
                return detalles.Any(dm => dm.id_MateriaAbierta == materiaAbierta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<int> EditarMatricula(Matricula matricula)
        {
            throw new NotImplementedException();
        }

        public Task<int> EliminarMatricula(int id)
        {
            throw new NotImplementedException();
        }

        //Retorna el Numero de recibo de la ultima matricula
        public async Task<int> ObtenenerIdUltimaMatricula()
        {
            try
            {
                Matricula? matricula = await _context.Matricula.OrderBy(mat => mat.Num_Recibo).LastOrDefaultAsync();
                if(matricula != null) return matricula.Num_Recibo;
                return -1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Matricula> ObtenerMatriculaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Matricula>> ObtenerMatriculas()
        {
            throw new NotImplementedException();
        }
    }
}
