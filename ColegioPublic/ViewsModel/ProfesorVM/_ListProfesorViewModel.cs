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

            var query = context._context.Profesor.Where(x => x.EstadoId ==1).AsQueryable();
            if (!string.IsNullOrEmpty(model.q))
                query = query.Where(x => x.Nombre.Contains(model.q) || x.ApellidoMaterno.Contains(model.q) || x.ApellidoPaterno.Contains(model.q)|| x.Dni.Contains(model.q));
            LstRegistro = query.OrderBy(x => x.ProfesorId).ToPagedList(this.p, 10);
        }
    }
}