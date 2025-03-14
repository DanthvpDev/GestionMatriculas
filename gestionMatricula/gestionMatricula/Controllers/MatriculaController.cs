using AspNetCoreGeneratedDocument;
using gestionMatricula.DTOs;
using gestionMatricula.Models;
using gestionMatricula.Services;
using gestionMatricula.Services.Estudiantes;
using gestionMatricula.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace gestionMatricula.Controllers
{
    public class MatriculaController : Controller
    {

        private readonly IEstudianteService _estudiantesService;
        private readonly IMatriculaService _matriculaService;
        private readonly IMateriasAbiertasService _materiasAbiertasService;

        public MatriculaController(IEstudianteService estudiantesService, IMatriculaService matriculaService, IMateriasAbiertasService materiasAbiertasService)
        {
            _estudiantesService = estudiantesService;
            _matriculaService = matriculaService;
            _materiasAbiertasService = materiasAbiertasService;
        }

        public IActionResult Index()
        {
            return View();
        }


        //Cargar la informacion de los estudiantes
        public async Task CargarEstudiantes()
        {
            IEnumerable<Estudiante> estudiantes = await _estudiantesService.ObtenerEstudiantes();
            ViewData["Estudiantes"] = estudiantes;
        }

        [HttpGet]
        public async Task<IActionResult> Create(MatriculaViewModel? matricula)
        {
            //Si no existen periodos no abre la vista
            Periodo? periodo = await _matriculaService.ObtenerPeriodos();
            if (periodo is null) return BadRequest("No existe un periodo activo");

            //Cargar la informacion de los estudiantes y de materias abiertas
            await CargarEstudiantes();
            IEnumerable<MateriasDTO> infoMaterias = await _materiasAbiertasService.ObtenerInfoBasicaMateriasAbiertas();

            //Si no existe la matricula se crea una nueva y se retorna esta misma vista con toda la información
            // para que el usuario pueda seleccionar más de una materia
            if (matricula.Num_Recibo is null)
            {
                MatriculaViewModel matriculaVM = new MatriculaViewModel
                {
                    Costo_Matricula = 0,
                    Descuento_Matricula = 0,
                    Estado_Matricula = "ACT",
                    Fecha_Matricula = DateTime.UtcNow,
                    id_Estudiante = "",
                    id_Periodo = periodo.Id,
                    MateriasAbiertas = infoMaterias
                };
                return View(matriculaVM);
            }

            //Si ya existe la matricula se obtienen las materias matriculadas, se carga el view model con los datos obtenidos
            IEnumerable<MateriasDTO> materiasMatriculadas = await _materiasAbiertasService.ObtenerMateriasPorMatricula(matricula.Num_Recibo.Value);
            matricula.MateriasMatriculadas = materiasMatriculadas;
            matricula.MateriasAbiertas = infoMaterias;



            return View(matricula);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMatricula(MatriculaViewModel matriculaViewModel)
        {
            if (ModelState.IsValid)
            {
                if (matriculaViewModel.Num_Recibo is null)
                {
                    Matricula matricula = new Matricula
                    {
                        Costo_Matricula = matriculaViewModel.Costo_Matricula,
                        Descuento = matriculaViewModel.Descuento_Matricula,
                        Estado = matriculaViewModel.Estado_Matricula,
                        Fecha_Matricula = matriculaViewModel.Fecha_Matricula,
                        id_Estudiante = matriculaViewModel.id_Estudiante,
                        id_Periodo = matriculaViewModel.id_Periodo
                    };

                   matriculaViewModel.Num_Recibo = await _matriculaService.AgregarMatricula(matricula);
                }

                // Verificar si la materia ya esta matriculada, de estarlo se muestra un mensaje de error
                // sino se genera un nuevo detalle de matricula
                if (await _matriculaService.EstaMateriaAprobadaOActiva(matriculaViewModel.Num_Recibo.Value, matriculaViewModel.id_MateriaAbierta))
                {
                    ViewData["MostrarModal"] = true;
                    ViewData["MensajeError"] = "No se puede ingresar la misma materia";
                    return RedirectToAction("Create", matriculaViewModel);
                }
                else
                {
                    DetalleMatricula detalleMatricula = new DetalleMatricula
                    {
                        Nota_Final = 0,
                        Estado = "ACT",
                        id_MateriaAbierta = matriculaViewModel.id_MateriaAbierta,
                        Num_Recibo = matriculaViewModel.Num_Recibo.Value,
                    };
                    var resultDM = await _matriculaService.AgregarDetalleMatricula(detalleMatricula);
                    if(resultDM == -1) return BadRequest("Ha ocurrido un error al guardar la matricula");
                }
                
                return RedirectToAction("Create", matriculaViewModel);
            }
            
            return BadRequest("No se ha podido guardar la matricula");
        }
    }
}
