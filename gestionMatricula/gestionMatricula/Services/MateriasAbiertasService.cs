using gestionMatricula.Data;
using gestionMatricula.DTOs;
using gestionMatricula.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionMatricula.Services
{
    public class MateriasAbiertasService : IMateriasAbiertasService
    {

        private readonly DBContextApp _context;

        public MateriasAbiertasService(DBContextApp context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MateriasDTO>> ObtenerInfoBasicaMateriasAbiertas()
        {
            try
            {
                return await (from ma in _context.Materias_Abiertas
                       join mc in _context.Materias_Carreras on ma.id_MateriaCarrera equals mc.Id
                       join m in _context.Materias on mc.Id_Materia equals m.Id_Materia
                       join c in _context.Carreras on mc.Id_Carrera equals c.Id_Carrera
                       where ma.Estado.Equals("ACT") && c.Estado_C.Equals("ACT") &&
                             m.Borrado == false && c.Borrado == false && mc.Borrado == false
                       select new MateriasDTO
                       {
                           Id_MateriaAbierta = ma.Id,
                           NombreMateriaCarrera = $"{m.Nombre_Materia} - {c.Nombre_Carrera}",
                           CreditosMateria = m.Creditos,
                           CodMateria = m.Id_Materia,
                       }).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<MateriaAbierta> ObtenerMateriaAbiertaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MateriaAbierta>> ObtenerMateriasAbiertas()
        {
            try
            {
                return await _context.Materias_Abiertas.Where(ma => ma.Estado.Equals("ACT")).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<MateriasDTO>> ObtenerMateriasPorMatricula(int num_recibo)
        {
            try
            {
                return await(from dm in _context.Detalles_Matricula 
                             join ma in _context.Materias_Abiertas on dm.id_MateriaAbierta equals ma.Id
                             join mc in _context.Materias_Carreras on ma.id_MateriaCarrera equals mc.Id
                             join m in _context.Materias on mc.Id_Materia equals m.Id_Materia
                             join c in _context.Carreras on mc.Id_Carrera equals c.Id_Carrera
                             where ma.Estado.Equals("ACT") && c.Estado_C.Equals("ACT") &&
                                   m.Borrado == false && c.Borrado == false && mc.Borrado == false && dm.Num_Recibo == num_recibo
                             select new MateriasDTO
                             {
                                 Id_MateriaAbierta = ma.Id,
                                 NombreMateriaCarrera = $"{m.Nombre_Materia} - {c.Nombre_Carrera}",
                                 CreditosMateria = m.Creditos,
                                 CodMateria = m.Id_Materia,
                             }).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
