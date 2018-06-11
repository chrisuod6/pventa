using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Actividad.Models;
using Actividad.Viewmodels;

namespace Actividad.Controllers
{
    public class UsuariosController : Controller
    {
        //objetos de solo lectura que sera instancia de las clases repositorios

        private readonly IUsuariosRepositorio _usuariosRepositorios;
        private readonly INivelUsuariosRepositorio _nivelusuariosRepositorio;


        //constructor de esta clase controller
        public UsuariosController(IUsuariosRepositorio usuariosRepositorios, INivelUsuariosRepositorio nivelusuariosrepositorios)
        {
            _nivelusuariosRepositorio = nivelusuariosrepositorios;
            _usuariosRepositorios = usuariosRepositorios;
        }//Fin del constructor

        //metodo para devolver la vista con datos inyectados

        public ViewResult ListaUsuarios(string nivusu)
        {
            IEnumerable<Usuarios> usuarios;
            string nivelActual = string.Empty;
            if (string.IsNullOrEmpty(nivusu))
            {
                usuarios = _usuariosRepositorios.Usuarios.OrderBy(u => u.CodigoUsuario);
                nivelActual = "Todos los usuarios";
            }
            else
            {
                usuarios = _usuariosRepositorios.Usuarios.Where(u => u.NivelUsuarios.NombreNivel == nivusu).OrderBy(u => u.CodigoUsuario);
                nivelActual = _nivelusuariosRepositorio.NivelUsuarios.FirstOrDefault(n => n.NombreNivel == nivusu).NombreNivel;
            }
            return View(new UsuariosViewModel
            {
                Usuarios = usuarios,
                NivelesUsuarios = nivelActual,
                Titulo= "Usuarios",
                subtitulo="Lista de usuarios con sus respectivos niveles"

            });
        }//fin del metodo ListaUsuarios


    }
}