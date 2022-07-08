using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
{
    public partial class TbInscripcionMembresia
    {
        public TbInscripcionMembresia()
        {
            TbAsistencia = new HashSet<TbAsistencia>();
        }

        public int CodigoMembresia { get; set; }
        public string DniMiembro { get; set; } = null!;
        public int CodCliente { get; set; }
        public int CodEmpleadoGestor { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaInic { get; set; }
        public DateTime FechaFin { get; set; }
        public int CodServicio { get; set; }
        public int CodPlan { get; set; }
        public int CodProm { get; set; }

        public virtual TbCliente CodClienteNavigation { get; set; } = null!;
        public virtual TbEmpleado CodEmpleadoGestorNavigation { get; set; } = null!;
        public virtual TbPromocion CodPlan1 { get; set; } = null!;
        public virtual TbPlanes CodPlanNavigation { get; set; } = null!;
        public virtual TbServicios CodServicioNavigation { get; set; } = null!;
        public virtual ICollection<TbAsistencia> TbAsistencia { get; set; }
    }
}
