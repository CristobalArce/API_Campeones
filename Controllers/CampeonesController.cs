using API_Campeones.ContextBD;
using API_Campeones.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Campeones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonesController : ControllerBase
    {
        private readonly ICampeonesRepository _campeonesRepository;
        public CampeonesController(ICampeonesRepository campeonesRepository)
        {
            this._campeonesRepository = campeonesRepository;
        }

        [HttpGet]
        [Route("ObtenerCampeon/{id}")]
        public IActionResult GetCampeon(int id)
        {
            var res = _campeonesRepository.GetCampeon(id).Result;
            return Ok(res);
        }

        [HttpGet]
        [Route("ObtenerCampeones")]
        public IActionResult GetCampeones()
        {
            var res = _campeonesRepository.GetListaCampeones().Result;
            return Ok(res);
        }

        [HttpGet]
        [Route("ObtenerCampeonDetallado/{idCampeon}")]
        public IActionResult GetCampeonDetallado(int idCampeon)
        {
            var res = _campeonesRepository.GetCampeonDetallado(idCampeon).Result;
            return Ok(res);
        }

        [HttpGet]
        [Route("ObtenerCampeonesDetallados")]
        public IActionResult GetCampeonesDetallados()
        {
            var res = _campeonesRepository.GetCampeonesDetallados().Result;
            return Ok(res);
        }


        [HttpPost]
        [Route("CrearCampeon")]
        public IActionResult PostCampeon(Tbcampeon campeonNuevo)
        {
            var res = _campeonesRepository.PostCampeon(campeonNuevo).Result;
            return Ok(res);
        }

        [HttpDelete]
        [Route("EliminarCampeon/{idCampeon}")]
        public IActionResult DeleteCampeon(int idCampeon)
        {
            var res = _campeonesRepository.DeleteCampeon(idCampeon).Result;
            return Ok(res);
        }

        [HttpPut]
        [Route("ModificarCampeon")]
        public IActionResult PutCampeon(Tbcampeon campeonModificado)
        {
            var res = _campeonesRepository.PutCampeon(campeonModificado).Result;
            return Ok(res);
        }
    }
}
