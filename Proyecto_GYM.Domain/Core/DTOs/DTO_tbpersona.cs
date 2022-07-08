using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_GYM.Domain.Core.DTOs
{
    public class DTO_tbpersona
    {
        public int Dni { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Direccion { get; set; }
        public int? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Sexo { get; set; }
    }
}
