using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad.Models
{
    public class Solicitados
    {
        private readonly AppDbContext _appDbContext;
        private Solicitados(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public string sesionSolicitado { get; set; }
        public List<SolicitadosItems> SolicitadosItems { get; set; }

        public static Solicitados GetSolicitados (IServiceProvider services)
        {
            ISession sesion = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var contexto = services.GetService<AppDbContext>();
            string sesionsoli = sesion.GetString("sesionsoli") ?? Guid.NewGuid().ToString();
            sesion.SetString("sesionsoli", sesionsoli);

            return new Solicitados(contexto) { sesionSolicitado = sesionsoli };
        }

        public void AgregarItemSolicitado(Usuarios usuarios, int cantidad)
        {
            var solicitadoItem = _appDbContext.SolicitadosItems.SingleOrDefault(si => si.Usuarios.CodigoUsuario == usuarios.CodigoUsuario && si.SesionSolicitado == sesionSolicitado);
            if (solicitadoItem == null)
            {
                solicitadoItem = new SolicitadosItems
                {
                    SesionSolicitado = sesionSolicitado,
                    Usuarios = usuarios,
                    cantidadUsuarioSolicitado = 1
                };
                _appDbContext.SolicitadosItems.Add(solicitadoItem);
            }
            else
            {
                solicitadoItem.cantidadUsuarioSolicitado++;
            }
                _appDbContext.SaveChanges();
            }

        public int EliminarItemSolicitado(Usuarios usuarios)
        {
            var solicitadoItem = _appDbContext.SolicitadosItems.SingleOrDefault(si => si.Usuarios.CodigoUsuario == usuarios.CodigoUsuario && si.SesionSolicitado == sesionSolicitado);
            var item = 0;

            if(solicitadoItem != null)
            {
                if(solicitadoItem.cantidadUsuarioSolicitado > 1)
                {
                    solicitadoItem.cantidadUsuarioSolicitado--;
                    item = solicitadoItem.cantidadUsuarioSolicitado;
                }
                else
                {
                    _appDbContext.SolicitadosItems.Remove(solicitadoItem);
                }
            }
            _appDbContext.SaveChanges();
            return item;
        }
        
        public List<SolicitadosItems> GetSolicitadosItems()
        {
            return SolicitadosItems ??
                (SolicitadosItems =
                _appDbContext.SolicitadosItems.Where(si => si.SesionSolicitado == sesionSolicitado).Include(sii => sii.Usuarios).ToList()
                );
        }

        public void LimpiarSolicitados()
        {
            var soliItems = _appDbContext.SolicitadosItems.Where(soli => soli.SesionSolicitado == sesionSolicitado);
            _appDbContext.SolicitadosItems.RemoveRange(soliItems);
            _appDbContext.SaveChanges();
        }

        public int GetSolicitadosTotal()
        {
            var totalSolicitados = _appDbContext.SolicitadosItems.Where(ts => ts.SesionSolicitado == sesionSolicitado)
                .Select(ts => ts.cantidadUsuarioSolicitado).Sum();
            return totalSolicitados;
        }
    }
}
