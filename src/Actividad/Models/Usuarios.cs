using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Actividad.Models
{
    public class Usuarios
    {
        [Key]
        public int CodigoUsuario { get; set; }

        public string NombreUsuario { get; set; }

        public string ApellidoUsuario { get; set; }
  

        public string CuentaUsuario { get; set; }

        public string ClaveUsuario { get; set; }

        public virtual NivelUsuarios NivelUsuarios { get; set; }
    }
}
