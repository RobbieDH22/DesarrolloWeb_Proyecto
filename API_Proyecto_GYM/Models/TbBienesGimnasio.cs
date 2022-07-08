using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
{
    public partial class TbBienesGimnasio
    {
        public TbBienesGimnasio()
        {
            TbCompra = new HashSet<TbCompra>();
        }

        public int CodigoBien { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<TbCompra> TbCompra { get; set; }
    }
}
