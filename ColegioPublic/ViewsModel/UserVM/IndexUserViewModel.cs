using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.UserVM
{
    public class IndexUserViewModel
    {
        [Display(Name = "Filtro")]
        public string q { get; set; }
        public List<User> users { get; set; }
        internal void Fill(CargarDatosContext cd, IndexUserViewModel model)
        {
            this.q = model.q;
            this.users = cd._context.User.ToList();
        }
    }
}