using API_Campeones.ContextBD;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static API_Campeones.Response.DificultadesResponse;

namespace API_Campeones.Repository.Interface
{
    public interface IDificultadesRepository
    {
        public Task<ListaDificultadesResponse> GetListaDificultades();
        public Task<DificultadResponse> GetDificultad(int idCampeon);
        public Task<DificultadResponse> DeleteDificultad(int idCampeon);
        public Task<DificultadResponse> PostDificultad(Tbdificultad dificultadNueva);
        public Task<DificultadResponse> PutDificultad(Tbdificultad dificultadModificada);
    }
}
