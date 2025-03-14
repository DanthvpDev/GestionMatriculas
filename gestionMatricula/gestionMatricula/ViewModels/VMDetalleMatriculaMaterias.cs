using gestionMatricula.DTOs;
using gestionMatricula.Models;

namespace gestionMatricula.ViewModels
{
    public class VMDetalleMatriculaMaterias
    {
        public int Num_Recibo { get; set; }
        public int NotaFinal { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public int id_MateriaAbierta { get; set; }
        public IEnumerable<MateriasDTO> MateriasAbiertas { get; set; }
        public IEnumerable<MateriasDTO> MateriasMatriculadas { get; set; }
    }
}
