using API_Campeones.ContextBD;
using API_Campeones.Repository.Interface;
using API_Campeones.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Campeones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTRepository _jwtRepository;
        public LoginController(IJWTRepository jWTRepository) 
        {
            this._jwtRepository = jWTRepository;
        }

        [HttpPost]
        public IActionResult Get(UsuarioRequest usuario)
        {
            var res = _jwtRepository.Login(usuario).Result;
            return Ok(res);
        }
    }
}
