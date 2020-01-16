using ColegioPublic.Helper;
using Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ColegioPublic.ViewsModel.MatriculaVM
{
    public class _ListMatriculaViewModel:IndexMatriculaViewModel
    {
        public int p { get; set; }

        public IPagedList<Matricula> LstRegistro { get; set; }

        public async Task FillList(CargarDatosContext context, IndexMatriculaViewModel model, int? p)
        {
            this.p = p ?? 1;
            base.q = model.q;

            var query = context._context.Matricula.AsQueryable();
            if (model.q.HasValue)
                query = query.Where(x => x.AlumnoId == this.q);
            LstRegistro = query.OrderBy(x => x.MatriculaId).ToPagedList(this.p, 10);
        }
    }
}