using gestionMatricula.Models;

namespace gestionMatricula.Services
{
    public interface IMatriculaService
    {
        public Task<IEnumerable<Matricula>> ObtenerMatriculas();
        public Task<Matricula> ObtenerMatriculaPorId(int id);
        public Task<int> ObtenenerIdUltimaMatricula();
        public Task<int> AgregarMatricula(Matricula matricula);
        public Task<int> AgregarDetalleMatricula(DetalleMatricula detalleMatricula);
        public Task<int> EditarMatricula(Matricula matricula);
        public Task<int> EliminarMatricula(int id);
        public Task<Periodo?> ObtenerPeriodos();
        public Task<IEnumerable<DetalleMatricula>> ObtenerDetallesMatriculaActivos(int numRecibo);
        public Task<bool> EstaMateriaAprobadaOActiva(int numRecibo, int materiaAbierta);

    }
}
