using ColegioPublic.Helper;
using Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ColegioPublic.ViewsModel.AlumnoVM
{
    public class _ListAlumnoViewModel : IndexAlumnoViewModel
    {
        public int p { get; set; }

        public IPagedList<Alumno> LstRegistro { get; set; }

        public async Task FillList(CargarDatosContext context, IndexAlumnoViewModel model, int? p)
        {
            this.p = p ?? 1;
            base.q = model.q;

            var query = context._context.Alumno.AsQueryable();
            if (model.q.HasValue)
                query = query.Where(x => x.AlumnoId == this.q);
            LstRegistro = query.OrderBy(x => x.AlumnoId).ToPagedList(this.p, 10);
        }
    }
}