using ColegioPublic.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.ViewsModel.ExamenVM
{
    public class AddEditExamenViewModel
    {
        public int HorarioId { get; set; }
        public int ? GradoAcademicoCursoId { get; set; }
        public int CursoId { get; set; }
        public List<Examenes> LstExamenes { get; set; }

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
                    EstadoId = x.EstadoId,
                    LstTipoExamen = context._context.TipoGenerico.Where(y => y.TipoGenericoPadreId == 1).Select(y => new SelectListItem() { Value = y.TipoGenericoId.ToString(), Text = y.Nombre }).ToList()

                }).ToList();

            }
        }
        public void GuardarExamen(CargarDatosContext context, AddEditExamenViewModel model)
        {
            var horario = context._context.Horario.Find(model.HorarioId);
            if (horario == null)
            {
                horario = new Data.Model.Horario();
                context._context.Horario.Add(horario);
            }
            horario.CursoId = model.CursoId;
            horario.GradoAcademicoId = model.GradoAcademicoCursoId;

            horario.EstadoId = 1;
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
        public int? EstadoId { get; set; }

        public void Fill(CargarDatosContext context)
        {
            this.LstTipoExamen = context._context.TipoGenerico.Where(x => x.TipoGenericoPadreId == 1).Select(x => new SelectListItem() {Value =x.TipoGenericoId.ToString(),Text =x.Nombre }).ToList();
        }

    }
}