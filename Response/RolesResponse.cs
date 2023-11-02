using API_Campeones.ContextBD;
using System.Collections.Generic;

namespace API_Campeones.Response
{
    public class RolesResponse
    {
        public class ListaRolesResponse : GeneralResponse
        {
            public List<Tbrol> ListaRoles { get; set; }
        }

        public class RolResponse : GeneralResponse
        {
            public Tbrol Rol { get; set; }
        }
        
    }
}
