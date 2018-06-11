using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Actividad.Models;
using Actividad.Viewmodels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Actividad.Controllers
{
    public class SolicitadosController : Controller
    {
        private readonly IUsuariosRepositorio _usuariosRepositorios;
        private readonly Solicitados _solicitados;

        public SolicitadosController(IUsuariosRepositorio usuariosRepositorios, Solicitados solicitados)
        {
            _usuariosRepositorios = usuariosRepositorios;
            _solicitados = solicitados;
        }

        public ViewResult Index()
        {
            var soliItems = _solicitados.GetSolicitadosItems();
            _solicitados.SolicitadosItems = soliItems;

            var solicitadosViewModel = new SolicitadosViewModel
            {
                Solicitados = _solicitados,
                SolicitadosTotal = _solicitados.GetSolicitadosTotal()
            };
            return View(solicitadosViewModel);
        }

        public RedirectToActionResult AgregarASolicitados (int codigoUsuario)
        {
            var usuarioSeleccionado = _usuariosRepositorios.Usuarios.FirstOrDefault(u => u.CodigoUsuario == codigoUsuario);
            if(usuarioSeleccionado != null)
            {
                _solicitados.AgregarItemSolicitado(usuarioSeleccionado, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult EliminarDeSolicitados( int codigoUsuario)
        {
            var usuarioSeleccionado = _usuariosRepositorios.Usuarios.FirstOrDefault(u => u.CodigoUsuario == codigoUsuario);
            if (usuarioSeleccionado != null)
            {
                _solicitados.EliminarItemSolicitado(usuarioSeleccionado);
            }
            return RedirectToAction("Index");
        }
    }
}
