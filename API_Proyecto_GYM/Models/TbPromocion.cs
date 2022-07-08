using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
{
    public partial class TbPromocion
    {
        public TbPromocion()
        {
            TbInscripcionMembresia = new HashSet<TbInscripcionMembresia>();
        }

        public int CodigoProm { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Descuento { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual ICollection<TbInscripcionMembresia> TbInscripcionMembresia { get; set; }
    }
}
