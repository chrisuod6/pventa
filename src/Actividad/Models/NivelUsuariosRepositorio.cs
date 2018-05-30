using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; //Operaciones con las conexiones
namespace Actividad.Models
{
    public class NivelUsuariosRepositorio : INivelUsuariosRepositorio
    {
        private readonly AppDbContext _appDbContext;

        //Metodo constructor
        public NivelUsuariosRepositorio(AppDbContext  appDbContext)
        {
            _appDbContext = appDbContext;

        }//Fin del metodo constructor

        //Extension de los metodos disponibles de la clase interface 

        public IEnumerable<NivelUsuarios> NivelUsuarios => _appDbContext.NivelesUsuarios;

     }
}
