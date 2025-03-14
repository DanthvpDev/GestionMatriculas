using gestionMatricula.Models;

namespace gestionMatricula.Services.Estudiantes
{
    public interface IEstudianteService
    {
        public Task<IEnumerable<Estudiante>> ObtenerEstudiantes();
        public Task<Estudiante> ObtenerEstudiantePorId(string id);
        public Task<Estudiante> AgregarEstudiante(Estudiante estudiante);
        public Task<Estudiante> EditarEstudiante(Estudiante estudiante);
        public Task<Estudiante> EliminarEstudiante(string id);
    }
}
