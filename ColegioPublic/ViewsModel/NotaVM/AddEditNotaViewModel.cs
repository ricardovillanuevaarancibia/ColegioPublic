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
        [Display(Name="Curso")]
        public int? CursoId { get; set; }
        public List<SelectListItem> LstExamen { get; set; }
        [Display(Name ="Examen")]
        public int? ExamenId { get; set; }
        public List<Alumno> LstAlumno { get; set; }
        public void Fill(CargarDatosContext context, int? cursoId,int ? gradroAcademicoId)
        {
            this.CursoId = cursoId;
            LstExamen = context._context.Examen.Where(x => x.GradoAcademicoCurso.CursoId == cursoId).Select( x => new SelectListItem() {Value =x.ExamenId.ToString(),Text= x.TipoGenerico.Nombre +"-" +x.FechaExamen }).ToList();
            LstAlumno = context._context.Matricula.Where(x =>x.GradoAcademicoId == gradroAcademicoId.Value &&  x.EstadoId ==1).Select(x => x.Alumno).ToList();
        }
        public void AddEdit(CargarDatosContext context, AddEditNotaViewModel model, FormCollection  formCollection)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    var keySplit = formCollection.AllKeys.Where(x => x.StartsWith("Nota") && x.Contains("Nota"));
                    foreach (var item in keySplit)
                    {
                        var Split = item.Split('-');
                        var keyItem = Split[1];
                        var valor = Convert.ToInt32(formCollection[item]);
                        var alumnoId = keyItem;
                        var nota = new Nota();
                        var notaAlfabeto = (valor >= 18) ? "AD" : (valor >= 13) ? "A" : (valor >= 8)?"B":"C";
                        nota.ExamenId = model.ExamenId;
                        nota.AlumnoId =Convert.ToInt32(alumnoId);
                        nota.Nota1 = valor;
                        nota.NotaAlfabeto = notaAlfabeto;
                        nota.TipoNotaId = 1;
                        nota.UsuarioRegistroId = 1;
                        nota.EstadoId = 1;
                        context._context.Nota.Add(nota);
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