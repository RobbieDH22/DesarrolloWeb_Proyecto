using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
{
    public partial class TbProductos
    {
        public TbProductos()
        {
            TbCompra = new HashSet<TbCompra>();
            TbVenta = new HashSet<TbVenta>();
        }

        public int CodigoProd { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Stock { get; set; }
        public double Precio { get; set; }
        public TimeSpan FechaIngreso { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<TbCompra> TbCompra { get; set; }
        public virtual ICollection<TbVenta> TbVenta { get; set; }
    }
}
