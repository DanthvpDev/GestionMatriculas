using gestionMatricula.Data;
using gestionMatricula.Models;
using gestionMatricula.Services.Estudiantes;
using Microsoft.EntityFrameworkCore;

namespace gestionMatricula.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly DBContextApp _context;

        public EstudianteService(DBContextApp context)
        {
            _context = context;
        }

        public Task<Estudiante> AgregarEstudiante(Estudiante estudiante)
        {
            throw new NotImplementedException();
        }

        public Task<Estudiante> EditarEstudiante(Estudiante estudiante)
        {
            throw new NotImplementedException();
        }

        public Task<Estudiante> EliminarEstudiante(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Estudiante> ObtenerEstudiantePorId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Estudiante>> ObtenerEstudiantes()
        {
            try
            {
                return await _context.Estudiantes.Where(e => !e.Borrado && e.Estado_E.Equals("ACT")).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
