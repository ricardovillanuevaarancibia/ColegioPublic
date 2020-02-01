using ColegioPublic.Helper;
using Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ColegioPublic.ViewsModel.ActividadVM
{
    public class _ListActividadViewModel:IndexActividadViewModel
    {
        public int p { get; set; }

        public IPagedList<Actividades> LstRegistro { get; set; }

        public async Task FillList(CargarDatosContext context, IndexActividadViewModel model, int? p)
        {
            this.p = p ?? 1;
            base.q = model.q;

            var query = context._context.Actividades.Where(x => x.EstadoId==1).AsQueryable();
            if (!string.IsNullOrEmpty(model.q))
                query = query.Where(x => x.Nombre.Contains(model.q));
            LstRegistro = query.OrderBy(x => x.ActividadesId).ToPagedList(this.p, 10);
        }
    }
}