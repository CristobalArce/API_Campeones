using API_Campeones.ContextBD;
using System.Collections.Generic;
using static API_Campeones.Dto.Dto;

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
            public List<CampeonConRelacionesDto> ListaCampeones { get; set; }
        }
        public class CampeonDetalladoDTOResponse : GeneralResponse
        {
            public CampeonConRelacionesDto CampeonDetallado { get; set; }
        }
    }
}
