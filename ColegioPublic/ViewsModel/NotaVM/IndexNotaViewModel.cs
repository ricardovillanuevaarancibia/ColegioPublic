using ColegioPublic.Helper;
using ColegioPublic.ViewsModel.CursoVM;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.ViewsModel.NotaVM
{
    public class IndexNotaViewModel
    {
        [Display(Name = "Filtro")]
        public int? q { get; set; }
        public int ?GradoId { get; set; }
        public int ?SeccionId { get; set; }
        public List<SelectListItem> LstGrados;
        public List<SelectListItem> LstSeccion;
        public List<Curso> curso { get; set; }
        public void Fill(CargarDatosContext cd, IndexNotaViewModel model)
        {
            this.q = model.q;
            this.curso = cd._context.Curso.ToList();
            this.LstGrados = cd._context.GradoAcademico.Select(x => new SelectListItem() {Value=x.GradoAcademicoId.ToString(),Text=x.Nombre }).ToList();
           LstSeccion=cd._context.Aula.Select(x => new SelectListItem() {Value = x.AulaId.ToString() ,Text = x.CodigoAula  }).ToList();
    }
    }
}