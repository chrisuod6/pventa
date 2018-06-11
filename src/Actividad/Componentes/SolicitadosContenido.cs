using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividad.Models;
using Actividad.Viewmodels;

namespace Actividad.Componentes
{
    public class SolicitadosContenido: ViewComponent
    {
        private readonly Solicitados _solicitados;

        public SolicitadosContenido(Solicitados solicitados)
        {
            _solicitados = solicitados;
        }

        public IViewComponentResult Invoke()
        {
            var usuariosSolicitados = _solicitados.GetSolicitadosItems();
            _solicitados.SolicitadosItems = usuariosSolicitados;
            var solicitadosViewModel = new SolicitadosViewModel
            {
                Solicitados = _solicitados,
                SolicitadosTotal = _solicitados.GetSolicitadosTotal()
            };
            return View(solicitadosViewModel);
        }
    }
}
