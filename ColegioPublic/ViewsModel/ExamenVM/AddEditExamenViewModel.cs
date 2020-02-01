using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.ViewsModel.ExamenVM
{
    public class AddEditExamenViewModel
    {
        [Display(Name = "Horario")]
        public int HorarioId { get; set; }
        [Display(Name ="Grado Academico")]
        public int ? GradoAcademicoCursoId { get; set; }
        [Display(Name="Curso")]
        public int CursoId { get; set; }
        public List<Examenes> LstExamenes { get; set; }
        [Display(Name="Fecha de Examen")]
        public DateTime FechaExamen { get; set; }

        public void cargarExamen(CargarDatosContext context, int gradoAcademicoCursoId)
        {
            var examen = context._context.Examen.Where(x => x.GradoAcademicoCursoId == GradoAcademicoCursoId);
            if (examen != null)
            {
      
                this.GradoAcademicoCursoId = gradoAcademicoCursoId;
                this.LstExamenes = examen.Select(x => new Examenes()
                {
                    ExamenId = x.ExamenId,
                    GradoAcademicoCursoId = x.GradoAcademicoCursoId,
                    FechaExamen = x.FechaExamen,
                    TipoExamenId = x.TipoExamenId,
                    TipoExamenNombre =x.TipoGenerico.Nombre,
                    EstadoId = x.EstadoId,
                    LstTipoExamen = context._context.TipoGenerico.Where(y => y.TipoGenericoPadreId == 1).Select(y => new SelectListItem() { Value = y.TipoGenericoId.ToString(), Text = y.Nombre }).ToList()

                }).ToList();

            }
        }
        public void GuardarExamen(CargarDatosContext context, IndexExamenViewModel model)
        {
            var examen = new Examen();
            if (examen == null)
            {
                examen = new Data.Model.Examen();
         
            }
            context._context.Examen.Add(examen);
            examen.FechaExamen = model.FechaExamen;
            examen.GradoAcademicoCursoId = model.GradoAcademicoId;
            examen.TipoExamenId = model.TipoExamenId;
            examen.EstadoId = 1;
            context._context.SaveChanges();
        }
        public void Delete(CargarDatosContext context, int examenId)
        {
            var examen = context._context.Examen.Find(examenId);
            if (examen != null)
                examen.EstadoId = 0;
            context._context.SaveChanges();


        }


    }
    public class Examenes
    {
        public int? ExamenId { get; set; }
        public int? GradoAcademicoCursoId { get; set; }
        public DateTime? FechaExamen { get; set; }
        public List<SelectListItem> LstTipoExamen { get; set; }
        public int ?TipoExamenId { get; set; }
        public string NombreTipoExamen { get; set; }
        public int? EstadoId { get; set; }
        public string TipoExamenNombre { get; set; }

        public void Fill(CargarDatosContext context)
        {
            this.LstTipoExamen = context._context.TipoGenerico.Where(x => x.TipoGenericoPadreId == 1).Select(x => new SelectListItem() {Value =x.TipoGenericoId.ToString(),Text =x.Nombre }).ToList();
        }

    }
}