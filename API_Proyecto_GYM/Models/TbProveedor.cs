using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
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
