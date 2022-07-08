using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
{
    public partial class TbPlanes
    {
        public TbPlanes()
        {
            TbInscripcionMembresia = new HashSet<TbInscripcionMembresia>();
        }

        public int CodigoPlan { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public double Precio { get; set; }

        public virtual ICollection<TbInscripcionMembresia> TbInscripcionMembresia { get; set; }
    }
}
