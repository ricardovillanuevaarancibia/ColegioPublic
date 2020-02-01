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
            base.q = base.q.Trim();
            var query = context._context.Matricula.Where(x => x.EstadoId==1).AsQueryable();
            if (!string.IsNullOrEmpty(model.q))
              query = query.Where(x => x.AlumnoId ==(Convert.ToInt32(model.q.Trim()))|| x.Alumno.Dni.Contains(model.q));

            LstRegistro = query.OrderBy(x => x.GradoAcademicoId).ToPagedList(this.p, 10);
        }
    }
}