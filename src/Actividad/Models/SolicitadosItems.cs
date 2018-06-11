using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Actividad.Models
{
    public class SolicitadosItems
    {
      [Key]
      public int Correlativo { get; set; }
        public Usuarios Usuarios { get; set; }
        public int cantidadUsuarioSolicitado { get; set; }
        public string SesionSolicitado { get; set; }

    }
}
