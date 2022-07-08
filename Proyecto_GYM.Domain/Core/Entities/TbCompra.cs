using System;
using System.Collections.Generic;

namespace Proyecto_GYM.Domain.Core.Entities
{
    public partial class TbCompra
    {
        public int CodigoCompra { get; set; }
        public int CodProveedor { get; set; }
        public DateTime FechaCompra { get; set; }
        public int? CodgBien { get; set; }
        public int? CodgProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioCompra { get; set; }

        public virtual TbBienesGimnasio? CodgBienNavigation { get; set; }
        public virtual TbProveedor? CodgProducto1 { get; set; }
        public virtual TbProductos? CodgProductoNavigation { get; set; }
    }
}
