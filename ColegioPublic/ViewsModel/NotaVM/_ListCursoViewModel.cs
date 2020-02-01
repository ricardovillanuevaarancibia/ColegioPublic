using ColegioPublic.Helper;
using Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ColegioPublic.ViewsModel.NotaVM
{
    public class _ListCursoViewModel:IndexNotaViewModel
    {
        public int p { get; set; }

        public IPagedList<GradoAcademicoCurso> LstRegistro { get; set; }

        public async Task FillList(CargarDatosContext context, IndexNotaViewModel model, int? p)
        {
            this.p = p ?? 1;
            base.q = model.q;
            base.GradoId = model.GradoId;
            base.SeccionId = model.SeccionId;

            var query = context._context.GradoAcademicoCurso.Where(x=> x.EstadoId== 1).AsQueryable();
            if (model.q.HasValue)
                query = query.Where(x => x.CursoId == this.q);
            if (model.GradoId.HasValue)
                query = query.Where(x => x.GradoAcademicoId == GradoId);

            LstRegistro = query.OrderBy(x => x.CursoId).ToPagedList(this.p, 10);
        }
    }
}