using ColegioPublic.Helper;
using Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ColegioPublic.ViewsModel.AulaVM
{
    public class _ListAulaViewModel:IndexAulaViewModel
    {
        public int p { get; set; }

        public IPagedList<Aula> LstRegistro { get; set; }

        public async Task FillList(CargarDatosContext context, IndexAulaViewModel model, int? p)
        {
            this.p = p ?? 1;
            base.q = model.q;

            var query = context._context.Aula.Where(x => x.EstadoId ==1).AsQueryable();
            if (!string.IsNullOrEmpty(model.q))
                query = query.Where(x => x.CodigoAula.Contains(model.q));
            LstRegistro = query.OrderBy(x => x.CodigoAula).ToPagedList(this.p, 10);
        }
    }
}