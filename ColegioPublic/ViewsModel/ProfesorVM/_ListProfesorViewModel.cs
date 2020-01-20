using ColegioPublic.Helper;
using Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ColegioPublic.ViewsModel.ProfesorVM
{
    public class _ListProfesorViewModel : IndexProfesorViewModel
    {

        public int p { get; set; }

        public IPagedList<Profesor> LstRegistro { get; set; }

        public async Task FillList(CargarDatosContext context, IndexProfesorViewModel model, int? p)
        {
            this.p = p ?? 1;
            base.q = model.q;

            var query = context._context.Profesor.AsQueryable();
            if (model.q.HasValue)
                query = query.Where(x => x.ProfesorId == this.q);
            LstRegistro = query.OrderBy(x => x.ProfesorId).ToPagedList(this.p, 10);
        }
    }
}