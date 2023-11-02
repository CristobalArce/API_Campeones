using API_Campeones.ContextBD;

namespace API_Campeones.Dto
{
    public class Dto
    {

        public class CampeonConRelacionesDto
        {
            public int IdCampeon { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public Tbrol Rol { get; set; }
            public Tbdificultad Dificultad { get; set; }
        }
    };
}
