using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Actividad.Models;
using Actividad.Viewmodels;

namespace Actividad.Componentes
{
    public class NivelesMenu : ViewComponent
    {
        private readonly INivelUsuariosRepositorio _nivelusuariosRepositorio;
        public NivelesMenu(INivelUsuariosRepositorio nivelusuariosRepositorio)
        {
            _nivelusuariosRepositorio = nivelusuariosRepositorio;
        }
        public IViewComponentResult Invoke()
        {
            var nivusu = _nivelusuariosRepositorio.NivelUsuarios.OrderBy(nu => nu.NombreNivel);
            return View(nivusu);
        }
    }
}
