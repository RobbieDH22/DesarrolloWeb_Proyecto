using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
{
    public partial class TbServicios
    {
        public TbServicios()
        {
            TbEvento = new HashSet<TbEvento>();
            TbInscripcionMembresia = new HashSet<TbInscripcionMembresia>();
        }

        public int CodigoServicio { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual ICollection<TbEvento> TbEvento { get; set; }
        public virtual ICollection<TbInscripcionMembresia> TbInscripcionMembresia { get; set; }
    }
}
