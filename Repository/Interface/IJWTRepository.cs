using API_Campeones.ContextBD;
using API_Campeones.Request;
using API_Campeones.Response;
using System.Threading.Tasks;

namespace API_Campeones.Repository.Interface
{
    public interface IJWTRepository
    {
        public string CrearToken(Tbusuario usuario);
        public Task<LoginResponse> Login(UsuarioRequest usuario);
    }
}