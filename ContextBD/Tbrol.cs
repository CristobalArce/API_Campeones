using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API_Campeones.ContextBD
{
    public partial class Tbrol
    {
        public Tbrol()
        {
            Tbcampeon = new HashSet<Tbcampeon>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tbcampeon> Tbcampeon { get; set; }
    }
}
