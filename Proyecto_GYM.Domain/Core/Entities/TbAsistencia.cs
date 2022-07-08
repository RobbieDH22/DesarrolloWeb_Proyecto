using System;
using System.Collections.Generic;

namespace Proyecto_GYM.Domain.Core.Entities
{
    public partial class TbAsistencia
    {
        public int CodigoAsistencia { get; set; }
        public DateTime Fecha { get; set; }
        public int CodCliente { get; set; }
        public int CodMembresia { get; set; }

        public virtual TbCliente CodClienteNavigation { get; set; } = null!;
        public virtual TbInscripcionMembresia CodMembresiaNavigation { get; set; } = null!;
    }
}
