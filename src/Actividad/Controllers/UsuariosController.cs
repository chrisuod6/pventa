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

        //constructor de esta clase controller
        public UsuariosController( IUsuariosRepositorio usuariosRepositorios)
        {
        
            _usuariosRepositorios = usuariosRepositorios;
        }//Fin del constructor

        //metodo para devolver la vista con datos inyectados
       
        public ViewResult  ListaUsuarios()
        {
            //objetos para mostrar  usuarios

            UsuariosViewModel listausuariosViewModel = new UsuariosViewModel();
            listausuariosViewModel.Usuarios = _usuariosRepositorios.Usuarios;

            //Pasando un valor a la variable de la clase

            listausuariosViewModel.Titulo = "Listado  de Usuarios";
            listausuariosViewModel.subtitulo = "Vista donde se muestran los usuarios con sus respectivos niveles";
                     
            return View(listausuariosViewModel);
        }//fin del metodo ListaUsuarios
      
      
    }
}
