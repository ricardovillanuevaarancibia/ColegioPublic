using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.ActividadVM
{
    public class IndexActividadViewModel
    {
        [Display(Name = "Filtro")]
        public string q { get; set; }
        public List<Actividades> actividades { get; set; }
        internal void Fill(CargarDatosContext cd, IndexActividadViewModel model)
        {
            this.q = model.q;
            this.actividades = cd._context.Actividades.ToList();
        }
    }
}