using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
{
    public partial class TbEmpleado
    {
        public TbEmpleado()
        {
            TbEvento = new HashSet<TbEvento>();
            TbInscripEvento = new HashSet<TbInscripEvento>();
            TbInscripcionMembresia = new HashSet<TbInscripcionMembresia>();
        }

        public int CodigoEmp { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public int DniPersona { get; set; }
        public string? Contrasena { get; set; }
        public DateTime FechaIng { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Cargo { get; set; }
        public string? Estado { get; set; }

        public virtual TbPersona DniPersonaNavigation { get; set; } = null!;
        public virtual ICollection<TbEvento> TbEvento { get; set; }
        public virtual ICollection<TbInscripEvento> TbInscripEvento { get; set; }
        public virtual ICollection<TbInscripcionMembresia> TbInscripcionMembresia { get; set; }
    }
}
