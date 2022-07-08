using System;
using System.Collections.Generic;

namespace Proyecto_GYM.Domain.Core.Entities
{
    public partial class TbVenta
    {
        public int CodigoVenta { get; set; }
        public int CodProducto { get; set; }
        public DateTime FechaVenta { get; set; }
        public int DniCliente { get; set; }
        public int Cantidad { get; set; }
        public double PrecioVenta { get; set; }

        public virtual TbProductos CodProductoNavigation { get; set; } = null!;
    }
}
