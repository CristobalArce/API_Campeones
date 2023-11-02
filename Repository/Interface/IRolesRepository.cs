using API_Campeones.ContextBD;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static API_Campeones.Response.RolesResponse;

namespace API_Campeones.Repository.Interface
{
    public interface IRolesRepository
    {
        public Task<ListaRolesResponse> GetListaRoles();
        public Task<RolResponse> GetRol(int idRol);
        public Task<RolResponse> DeleteRol(int idRol);
        public Task<RolResponse> PostRol(Tbrol rolNuevo);
        public Task<RolResponse> PutRol(Tbrol rolModificado);
    }
}
