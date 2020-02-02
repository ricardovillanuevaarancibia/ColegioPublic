using ColegioPublic.Helper;
using Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ColegioPublic.ViewsModel.UsuarioMovilVM
{
    public class _ListUsuarioMovilViewModel:IndexUsuarioMovilViewModel
    {
        public int p { get; set; }

        public IPagedList<Usuario> LstRegistro { get; set; }

        public async Task FillList(CargarDatosContext context, IndexUsuarioMovilViewModel model, int? p)
        {
            this.p = p ?? 1;
            base.q = model.q;

            var query = context._context.Usuario.Where(x => x.EstadoId == 1).AsQueryable();
            if (!string.IsNullOrEmpty(model.q))
                query = query.Where(x => x.UserName.Contains(model.q) || x.Nombre.Contains(model.q)|| x.ApellidosM.Contains(model.q)|| x.ApellidosP.Contains(model.q)|| x.Correo.Contains(model.q)|| x.Telefono.Contains(model.q));
            LstRegistro = query.OrderBy(x => x.UsuarioId).ToPagedList(this.p, 10);
        }
    }
}