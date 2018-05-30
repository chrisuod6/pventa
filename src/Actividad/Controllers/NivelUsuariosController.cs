using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Actividad.Models;
using Actividad.Viewmodels;
namespace Actividad.Controllers
{
    public class NivelUsuariosController : Controller
    {

        private readonly INivelUsuariosRepositorio _nivelusuariosRepositorios;

        public NivelUsuariosController (INivelUsuariosRepositorio nivelusuariosRepositorio)
        {
            _nivelusuariosRepositorios = nivelusuariosRepositorio;
        }
        public ViewResult ListaNivelUsuarios()
        {
            NivelUsuariosViewModel nivelusuariosViewModel =new NivelUsuariosViewModel();
            nivelusuariosViewModel.NivelUsuarios = _nivelusuariosRepositorios.NivelUsuarios;
            nivelusuariosViewModel.Titulo = "Lista de niveles de usuarios";
            nivelusuariosViewModel.subtitulo = "Vista donde su muestran los niveles que se otorgan a los usuarios";
            return View(nivelusuariosViewModel);
        }

    }
}
