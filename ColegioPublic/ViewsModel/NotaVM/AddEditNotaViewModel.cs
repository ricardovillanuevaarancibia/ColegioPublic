using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.ViewsModel.NotaVM
{
    public class AddEditNotaViewModel
    {
        public int? CursoId { get; set; }
        public List<SelectListItem> LstExamen { get; set; }
        public int? ExamenId { get; set; }
        public List<Alumno> LstAlumno { get; set; }

        public void Fill(CargarDatosContext context, int? cursoId)
        {
            this.CursoId = cursoId;
            LstExamen = context._context.Examen.Where(x => x.GradoAcademicoCurso.CursoId == cursoId).Select( x => new SelectListItem() {Value =x.ExamenId.ToString(),Text= x.TipoGenerico.Nombre +"-" +x.FechaExamen }).ToList();
            LstAlumno = context._context.Alumno.Where(x => x.EstadoId == 1).ToList();
        }
        public void AddEdit(CargarDatosContext context, AddEditNotaViewModel model, FormCollection  formCollection)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var nota = new Nota();
                        nota.ExamenId = 1;
                        nota.AlumnoId = 1;
                        nota.Nota1 = 1;
                        nota.Nota1 = 'a';
                        nota.TipoNotaId = 1;
                        nota.UsuarioRegistroId = 1;
                        nota.EstadoId = 1;
                        context._context.SaveChanges();
            
                    }
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public void Delete(CargarDatosContext context, int actividadId)
        {
            var actividad = context._context.Actividades.Find(actividadId);
            if (actividad != null)
                actividad.EstadoId = 0;
            context._context.SaveChanges();


        }
    }
}