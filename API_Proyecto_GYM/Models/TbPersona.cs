using System;
using System.Collections.Generic;

namespace API_Proyecto_GYM.Models
{
    public partial class TbPersona
    {
        public TbPersona()
        {
            TbCliente = new HashSet<TbCliente>();
            TbEmpleado = new HashSet<TbEmpleado>();
        }

        public int Dni { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Direccion { get; set; }
        public int? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Sexo { get; set; }

        public virtual ICollection<TbCliente> TbCliente { get; set; }
        public virtual ICollection<TbEmpleado> TbEmpleado { get; set; }
    }
}
