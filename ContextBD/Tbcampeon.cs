using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API_Campeones.ContextBD
{
    public partial class Tbcampeon
    {
        public int IdCampeon { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdDificultad { get; set; }
        public int IdRol { get; set; }

        public virtual Tbdificultad IdDificultadNavigation { get; set; }
        public virtual Tbrol IdRolNavigation { get; set; }
    }
}
