using System.ComponentModel.DataAnnotations;

namespace API_Campeones.Response
{
    public class GeneralResponse
    {
        //0 bien, 2 error, 1 excepcion controlada

        [Required]
        public int NumeroEstado { get; set; }
        public string Estado { get; set; }
        public string Mensaje { get; set; }
    }
}
