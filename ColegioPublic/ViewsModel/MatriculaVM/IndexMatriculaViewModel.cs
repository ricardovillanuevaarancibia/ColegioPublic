using ColegioPublic.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.MatriculaVM
{
    public class IndexMatriculaViewModel
    {
        [Display(Name = "Filtro")]
        public string q { get; set; }

        public void Fill(CargarDatosContext cd, IndexMatriculaViewModel model)
        {
            this.q = model.q;

        }
    }
}