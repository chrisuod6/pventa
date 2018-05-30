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
       
        
    }
   

}
