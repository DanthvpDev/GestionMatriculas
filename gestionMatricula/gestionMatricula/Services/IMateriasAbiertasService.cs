using gestionMatricula.DTOs;
using gestionMatricula.Models;

namespace gestionMatricula.Services
{
    public interface IMateriasAbiertasService
    {
        public Task<IEnumerable<MateriaAbierta>> ObtenerMateriasAbiertas();
        public Task<IEnumerable<MateriasDTO>> ObtenerInfoBasicaMateriasAbiertas();
        public Task<MateriaAbierta> ObtenerMateriaAbiertaPorId(int id);
        public Task<IEnumerable<MateriasDTO>> ObtenerMateriasPorMatricula(int num_recibo);
    }
}
