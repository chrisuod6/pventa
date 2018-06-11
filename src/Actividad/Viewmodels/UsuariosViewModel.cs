using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividad.Models;

namespace Actividad.Viewmodels
{
    public class UsuariosViewModel
    {
        public IEnumerable<Usuarios> Usuarios { get; set; }
        public string NivelesUsuarios { get; set; }
        public string Titulo { get; set; }
        public string subtitulo { get; set; }



    }
}
