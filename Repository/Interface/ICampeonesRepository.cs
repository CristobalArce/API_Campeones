using API_Campeones.ContextBD;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static API_Campeones.Dto.Dto;
using static API_Campeones.Response.CampeonesResponse;

namespace API_Campeones.Repository.Interface
{
    public interface ICampeonesRepository
    {
        public Task<CampeonResponse> GetCampeon(int idCampeon);
        public Task<ListaCampeonesResponse> GetListaCampeones();
        public Task<CampeonResponse> DeleteCampeon(int idCampeon);
        public Task<CampeonResponse> PostCampeon(Tbcampeon campeonNuevo);
        public Task<CampeonResponse> PutCampeon(Tbcampeon campeonModificado);
        public Task<CampeonDetalladoDTOResponse> GetCampeonDetallado(int idCampeon);
        public Task<ListaCampeonesDetalladosDTOResponse> GetCampeonesDetallados();
    }
}
