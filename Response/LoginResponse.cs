using API_Campeones.ContextBD;

namespace API_Campeones.Response
{
    public class LoginResponse : GeneralResponse
    {
        public Tbusuario Usuario { get; set; }
        public string Token { get; set; }
    }
}
