using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.AulaVM
{
    public class IndexAulaViewModel
    {
        [Display(Name = "Filtro")]
        public string q { get; set; }
        public List<Aula> aula { get; set; }
        internal void Fill(CargarDatosContext cd, IndexAulaViewModel model)
        {
            this.q = model.q;
            this.aula = cd._context.Aula.ToList();
        }
    }
}