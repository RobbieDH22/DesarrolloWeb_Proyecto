using System;
using System.Collections.Generic;

namespace Proyecto_GYM.Domain.Core.Entities
{
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbAsistencia = new HashSet<TbAsistencia>();
            TbInscripEvento = new HashSet<TbInscripEvento>();
            TbInscripcionMembresia = new HashSet<TbInscripcionMembresia>();
        }

        public int CodigoCliente { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string? Contrasena { get; set; }
        public int DniCliente { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Estado { get; set; }

        public virtual TbPersona DniClienteNavigation { get; set; } = null!;
        public virtual ICollection<TbAsistencia> TbAsistencia { get; set; }
        public virtual ICollection<TbInscripEvento> TbInscripEvento { get; set; }
        public virtual ICollection<TbInscripcionMembresia> TbInscripcionMembresia { get; set; }
    }
}
