using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.ProfesorVM
{
    public class IndexProfesorViewModel
    {
        [Display(Name = "Filtro")]
        public string q { get; set; }
        public List<Profesor> alumnos { get; set; }

        public void Fill(CargarDatosContext cd, IndexProfesorViewModel model)
        {
            this.q = model.q;
            this.alumnos = cd._context.Profesor.ToList();
        }
    }
}