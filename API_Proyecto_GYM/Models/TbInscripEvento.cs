using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
{
    public partial class TbInscripEvento
    {
        public int CodigoInscripcion { get; set; }
        public int CodEvento { get; set; }
        public int CodCliente { get; set; }
        public int CodigoInstructor { get; set; }

        public virtual TbCliente CodClienteNavigation { get; set; } = null!;
        public virtual TbEvento CodEventoNavigation { get; set; } = null!;
        public virtual TbEmpleado CodigoInstructorNavigation { get; set; } = null!;
    }
}
