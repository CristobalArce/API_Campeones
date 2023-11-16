using API_Campeones.ContextBD;
using API_Campeones.Repository.Interface;
using API_Campeones.Request;
using API_Campeones.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_Campeones.Repository
{
    public class JWTRepository : IJWTRepository
    {
        private readonly IConfiguration _configuration;
        private readonly CampeonesContext _campeonesContext;
        public JWTRepository(IConfiguration configuration, CampeonesContext campeonesContext) 
        {
            this._configuration = configuration;
            this._campeonesContext = campeonesContext;
        }
        public string CrearToken(Tbusuario usuario)
        {
            //Le asigno un token al usuario con respecto a su correo
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email)
            };

            //Asigno la llave para que encripte/desencripte
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("My jwt secret ACCESS TO API CAMPEONES"));
            //Le agrego en que formato encriptara Hmac... asociando la llave 
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            //Configuro token
            var tokenDescripcion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credenciales,
            };

            //Creo el capturador de token
            var tokenManejador = new JwtSecurityTokenHandler();
            //Inicializo la token con su configuracion y la capturo en la variable
            var token = tokenManejador.CreateToken(tokenDescripcion);
            return tokenManejador.WriteToken(token);
        }

        async public Task<LoginResponse> Login(UsuarioRequest usuario)
        {
            var res = new LoginResponse
            {
                Estado = "OK",
                Mensaje = "El login se realizo correctamente",
                NumeroEstado = 0,
            };
            var query = await (from ca in _campeonesContext.Tbusuario
                                    where usuario.Email == ca.Email select ca)
                                    .FirstOrDefaultAsync();

            if (query == null)
            {
                res.Estado = "NOK";
                res.Mensaje = "No se encontro el usuario";
                res.NumeroEstado = 1;
                res.Token = null;
            }
            else
            {
                var token = CrearToken(query);
                res.Usuario = query;
                res.Token = token;
            }

            return res;    
        }
    }
}
