using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.AlumnoVM
{
    public class IndexAlumnoViewModel
    {
        [Display(Name = "Filtro")]
        public int? q { get; set; }
        public List<Alumno>alumnos{get;set;}

        public void Fill(CargarDatosContext cd, IndexAlumnoViewModel model)
        {
            this.q = model.q;
            this.alumnos = cd._context.Alumno.ToList();
        }

    }
}