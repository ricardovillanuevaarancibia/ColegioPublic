using ColegioPublic.Helper;
using Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ColegioPublic.ViewsModel.UserVM
{
    public class _ListUserViewModel : IndexUserViewModel
    {
        public int p { get; set; }

        public IPagedList<User> LstRegistro { get; set; }

        public async Task FillList(CargarDatosContext context, IndexUserViewModel model, int? p)
        {
            this.p = p ?? 1;
            base.q = model.q;

            var query = context._context.User.Where(x => x.EstadoId == 1).AsQueryable();
            if (!string.IsNullOrEmpty(model.q))
                query = query.Where(x => x.UserName.Contains(model.q) || x.Rol.Contains(model.q));
            LstRegistro = query.OrderBy(x => x.UserId).ToPagedList(this.p, 10);
        }
    }
}