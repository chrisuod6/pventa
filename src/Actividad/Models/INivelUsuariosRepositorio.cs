using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad.Models
{
    public interface INivelUsuariosRepositorio
    {
        IEnumerable<NivelUsuarios> NivelUsuarios { get; }
    }
}
