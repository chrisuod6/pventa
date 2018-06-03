using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad.Models
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly AppDbContext _appDbContext;
        //Metodo constructor
        public UsuariosRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //metodos disponibles de la clase interface

        public IEnumerable<Usuarios> Usuarios => _appDbContext.Usuarios;

        IEnumerable<Usuarios> IUsuariosRepositorio.UsuariosPorCodigo(int CodigoUsuario)
        {
            yield return _appDbContext.Usuarios.FirstOrDefault(u => u.CodigoUsuario == CodigoUsuario);
        }


    }

   

}
