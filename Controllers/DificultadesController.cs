using API_Campeones.ContextBD;
using API_Campeones.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Campeones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DificultadesController : ControllerBase
    {
        private readonly IDificultadesRepository _dificultadesRepository;

        public DificultadesController(IDificultadesRepository dificultadesRepository)
        {
            this._dificultadesRepository = dificultadesRepository;
        }

        [HttpGet]
        [Route("ObtenerDificultad/{id}")]
        public IActionResult GetDificultad(int id)
        {
            var res = _dificultadesRepository.GetDificultad(id).Result;
            return Ok(res);
        }

        [HttpGet]
        [Route("ObtenerDificultades")]
        public IActionResult GetDificultades()
        {
            var res = _dificultadesRepository.GetListaDificultades().Result;
            return Ok(res);
        }

        [HttpPost]
        [Route("CrearDificultad")]
        public IActionResult PostDificultad(Tbdificultad dificultadNueva)
        {
            var res = _dificultadesRepository.PostDificultad(dificultadNueva).Result;
            return Ok(res);
        }

        [HttpDelete]
        [Route("EliminarDificultad/{idDificultad}")]
        public IActionResult DeleteDificultad(int idDificultad)
        {
            var res = _dificultadesRepository.DeleteDificultad(idDificultad).Result;
            return Ok(res);
        }

        [HttpPut]
        [Route("ModificarDificultad")]
        public IActionResult PutDificultad(Tbdificultad dificultadModificada)
        {
            var res = _dificultadesRepository.PutDificultad(dificultadModificada).Result;
            return Ok(res);
        }
    }
}
