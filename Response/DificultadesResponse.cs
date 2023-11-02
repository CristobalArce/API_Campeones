using API_Campeones.ContextBD;
using System.Collections.Generic;

namespace API_Campeones.Response
{
    public class DificultadesResponse
    {
        public class ListaDificultadesResponse : GeneralResponse
        {
            public List<Tbdificultad> ListaDificultades { get; set; }
        }

        public class DificultadResponse : GeneralResponse
        {
            public Tbdificultad Dificultad { get; set; }
        }
    }
}
