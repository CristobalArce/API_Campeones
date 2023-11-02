using API_Campeones.ContextBD;
using API_Campeones.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Campeones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        [HttpGet]
        [Route("ObtenerRol/{id}")]
        public IActionResult GetRol(int id)
        {
            var res = _rolesRepository.GetRol(id).Result;
            return Ok(res);
        }

        [HttpGet]
        [Route("ObtenerRoles")]
        public IActionResult GetRoles()
        {
            var res = _rolesRepository.GetListaRoles().Result;
            return Ok(res);
        }

        [HttpPost]
        [Route("CrearRol")]
        public IActionResult PostRol(Tbrol rolNuevo)
        {
            var res = _rolesRepository.PostRol(rolNuevo).Result;
            return Ok(res);
        }

        [HttpDelete]
        [Route("EliminarRol/{idRol}")]
        public IActionResult DeleteRol(int idRol)
        {
            var res = _rolesRepository.DeleteRol(idRol).Result;
            return Ok(res);
        }

        [HttpPut]
        [Route("ModificarRol")]
        public IActionResult PutRol(Tbrol rolModificado)
        {
            var res = _rolesRepository.PutRol(rolModificado).Result;
            return Ok(res);
        }
    }
}
