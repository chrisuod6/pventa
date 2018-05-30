using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Actividad.Models
{
    public static class DataInicio
    {
        public static void AgregarData(IApplicationBuilder ab)
        {
            AppDbContext contexto = ab.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!contexto.NivelesUsuarios.Any())
            {
                //NivelUsuariosIniciales es una coleccion local
                contexto.NivelesUsuarios.AddRange(NivelesUsuariosIniciales.Select(c => c.Value));
            }
            if (!contexto.Usuarios.Any())
            {
                contexto.AddRange
                (
                    new Usuarios { NombreUsuario = "Christopher", ApellidoUsuario = "Olmedo",CuentaUsuario="christopher@progra.sv", ClaveUsuario="olmedo123", NivelUsuarios = NivelesUsuariosIniciales["Administrador"]  },
                    new Usuarios { NombreUsuario = "Javier", ApellidoUsuario = "Ramirez", CuentaUsuario="javier@progra.sv", ClaveUsuario="ramirez123", NivelUsuarios= NivelesUsuariosIniciales["Administrador"] },
                    new Usuarios { NombreUsuario = "Roberto", ApellidoUsuario = "Chavez" , CuentaUsuario="roberto@progra.sv", ClaveUsuario="chavez123", NivelUsuarios= NivelesUsuariosIniciales["Editor"]},
                    new Usuarios { NombreUsuario = "Jose", ApellidoUsuario = "Perez" , CuentaUsuario="jose@progra.sv", ClaveUsuario="perez123", NivelUsuarios=NivelesUsuariosIniciales["Consultor"]},
                    new Usuarios {  NombreUsuario = "Carlos", ApellidoUsuario = "Solis", CuentaUsuario="calos@progra.sv", ClaveUsuario="solis123", NivelUsuarios= NivelesUsuariosIniciales["Editor"] },
                    new Usuarios {  NombreUsuario = "Baudilio", ApellidoUsuario = "Escamilla", CuentaUsuario="baudilio@progra.sv", ClaveUsuario="escamilla123", NivelUsuarios=NivelesUsuariosIniciales["Consultor"] },
                    new Usuarios {  NombreUsuario = "Alexis", ApellidoUsuario = "Fabian", CuentaUsuario="alexis@progra.sv" , ClaveUsuario="fabian123", NivelUsuarios= NivelesUsuariosIniciales["Editor"]},
                    new Usuarios {  NombreUsuario = "Franklin", ApellidoUsuario = "Bermudez", CuentaUsuario="Franklin@progra.sv", ClaveUsuario="bermudez123", NivelUsuarios= NivelesUsuariosIniciales["Consultor"] },
                    new Usuarios {  NombreUsuario = "Kevin", ApellidoUsuario = "Najarro", CuentaUsuario="kevin@progra.sv", ClaveUsuario="najarro123", NivelUsuarios= NivelesUsuariosIniciales["Editor"] },
                    new Usuarios {  NombreUsuario = "Rafael", ApellidoUsuario = "Argueta", CuentaUsuario="rafael@progra.sv", ClaveUsuario="argueta123", NivelUsuarios= NivelesUsuariosIniciales["Consultor"] }

                );
            }

            contexto.SaveChanges();
        }//fin de agregarData

        //se hace referencia a la clase dominio NivelUsuarios
        public static Dictionary<string, NivelUsuarios> nivusuariosiniciales;
        public static Dictionary<string, NivelUsuarios> NivelesUsuariosIniciales
        {

        get
            {
                if(nivusuariosiniciales == null)
                {
                    var listadoNiveles  = new NivelUsuarios[]
                    {
                     new NivelUsuarios { NombreNivel= "Administrador", DescripcionNivel=" Usuario autorizado para administrar todo el sistema"},
                     new NivelUsuarios { NombreNivel= "Editor", DescripcionNivel=" Usuario autorizado para editar datos"},
                     new NivelUsuarios { NombreNivel="Consultor", DescripcionNivel="Usuarios autorizado para consultar datos"  }
                    };
                   nivusuariosiniciales = new Dictionary<string, NivelUsuarios>();

                    foreach( NivelUsuarios nivusuini in listadoNiveles)
                    {
                         nivusuariosiniciales.Add(nivusuini.NombreNivel, nivusuini);
                    }//fin del foreach
}
                return nivusuariosiniciales;
            }//fin del metodo get
        }//fin de diccionar
        }
}
