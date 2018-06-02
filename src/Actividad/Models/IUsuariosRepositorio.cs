using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad.Models
{
    public interface IUsuariosRepositorio
    {
        IEnumerable<Usuarios> Usuarios { get; }
        IEnumerable<Usuarios> UsuariosPorCodigo(int CodigoUsuario);
    }
}
