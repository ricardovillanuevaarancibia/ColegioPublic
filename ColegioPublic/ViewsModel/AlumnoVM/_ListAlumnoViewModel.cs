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

            var query = context._context.Alumno.Where(x => x.EstadoId==1).AsQueryable();
            if (!string.IsNullOrEmpty(model.q))
                query = query.Where(x => x.Nombre.Contains(model.q)||x.ApellidoPaterno.Contains(model.q)||x.ApellidoMaterno.Contains(model.q)|| x.Dni.Contains(model.q));
            LstRegistro = query.OrderBy(x => x.AlumnoId).ToPagedList(this.p, 10);
        }
    }
}