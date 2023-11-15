using API_Campeones.ContextBD;
using API_Campeones.Dto;
using System.Collections.Generic;

namespace API_Campeones.Response
{
    public class CampeonesResponse : GeneralResponse
    {
        public class ListaCampeonesResponse : GeneralResponse
        {
            public List<Tbcampeon> ListaCampeones { get; set; }
        }

        public class CampeonResponse : GeneralResponse
        {
            public Tbcampeon Campeon { get; set; }
        }

        public class ListaCampeonesDetalladosDTOResponse : GeneralResponse
        {
            public List<CampeonDto> ListaCampeones { get; set; }
        }
        public class CampeonDetalladoDTOResponse : GeneralResponse
        {
            public CampeonDto CampeonDetallado { get; set; }
        }
    }
}
