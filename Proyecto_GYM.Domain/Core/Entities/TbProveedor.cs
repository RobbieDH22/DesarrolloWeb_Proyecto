using System;
using System.Collections.Generic;

namespace Proyecto_GYM.Domain.Core.Entities
{
    public partial class TbProveedor
    {
        public TbProveedor()
        {
            TbCompra = new HashSet<TbCompra>();
        }

        public int CodigoProv { get; set; }
        public string Nombre { get; set; } = null!;
        public int Telefono { get; set; }
        public int? Correo { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<TbCompra> TbCompra { get; set; }
    }
}
