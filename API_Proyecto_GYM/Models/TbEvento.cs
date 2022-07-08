using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
{
    public partial class TbEvento
    {
        public TbEvento()
        {
            TbInscripEvento = new HashSet<TbInscripEvento>();
        }

        public int CodigoEvento { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public TimeSpan HoraIni { get; set; }
        public TimeSpan HoraFin { get; set; }
        public double CostoEntrada { get; set; }
        public int CodigoSede { get; set; }
        public int CantLimite { get; set; }
        public int CodigoServicio { get; set; }
        public int CodigoInstructor { get; set; }

        public virtual TbEmpleado CodigoInstructorNavigation { get; set; } = null!;
        public virtual TbSede CodigoSedeNavigation { get; set; } = null!;
        public virtual TbServicios CodigoServicioNavigation { get; set; } = null!;
        public virtual ICollection<TbInscripEvento> TbInscripEvento { get; set; }
    }
}
