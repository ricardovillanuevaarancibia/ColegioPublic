using ColegioPublic.Helper;
using Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ColegioPublic.ViewsModel.CursoVM
{
    public class _ListCursoViewModel:IndexCursoViewModel
    {
        public int p { get; set; }

        public IPagedList<Curso> LstRegistro { get; set; }

        public async Task FillList(CargarDatosContext context, IndexCursoViewModel model, int? p)
        {
            this.p = p ?? 1;
            base.q = model.q;

            var query = context._context.Curso.Where(x => x.EstadoId == 1).AsQueryable();
            if (!string.IsNullOrEmpty(model.q))
                query = query.Where(x => x.Nombre.Contains(model.q));
            LstRegistro = query.OrderBy(x => x.Nombre).ToPagedList(this.p, 10);
        }
    }
}