using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.CursoVM
{
    public class IndexCursoViewModel
    {
        [Display(Name = "Filtro")]
        public int? q { get; set; }
        public List<Curso> alumnos { get; set; }

        public void Fill(CargarDatosContext cd, IndexCursoViewModel model)
        {
            this.q = model.q;
            this.alumnos = cd._context.Curso.ToList();
        }
    }
}