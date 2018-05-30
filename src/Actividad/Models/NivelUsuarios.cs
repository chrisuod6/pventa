using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Actividad.Models
{
    public class NivelUsuarios
    {
       [Key] public int CodigoNivel { get; set; }

        public string NombreNivel { get; set; }

        public string DescripcionNivel { get; set; }

        public List<Usuarios> Usuarios { get; set; }

    }
}
