using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.ExamenVM
{
    public class ListExamenViewModel
    {
        public List<Examen> LstExamen { get; set; } = new List<Examen>();
        public void Fill(CargarDatosContext context, int CursoId)
        {
            this.LstExamen = context._context.Examen.Where(x => x.GradoAcademicoCurso.CursoId == CursoId).ToList();
        }
    }
}