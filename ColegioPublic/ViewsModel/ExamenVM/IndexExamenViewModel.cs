﻿using ColegioPublic.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.ViewsModel.ExamenVM
{
    public class IndexExamenViewModel
    {
        public List<SelectListItem> LstGradoAcademico { get; set; }
        public int GradoAcademicoId { get; set; }
        public List<SelectListItem> LstCursoByGradoAcademico { get; set; } = new List<SelectListItem>();
        public int CursoId { get; set; }
        public DateTime test { get; set; }
        public void Fill(CargarDatosContext context, int? GradoAcademicoId)
        {
            this.LstGradoAcademico = context._context.GradoAcademico.Select(x => new SelectListItem() { Value = x.GradoAcademicoId.ToString(), Text = x.Nombre }).ToList();

        }
        public void FillCursoBgGradoAcademico(CargarDatosContext context, int GradoAcademicoId)
        {
            this.LstCursoByGradoAcademico = context._context.GradoAcademicoCurso.Where(x => x.GradoAcademicoId == GradoAcademicoId).Select(x => new SelectListItem() { Value = x.GradoAcademicoCursoId.ToString(), Text = x.Curso.Nombre }).ToList();
        }
    }
}