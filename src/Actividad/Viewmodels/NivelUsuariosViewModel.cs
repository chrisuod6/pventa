using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividad.Models;

namespace Actividad.Viewmodels
{
    public class NivelUsuariosViewModel
    {
        public IEnumerable<NivelUsuarios> NivelUsuarios { get; set; }
        public string Titulo { get; set; }
        public string subtitulo { get; set; }
    }
}
