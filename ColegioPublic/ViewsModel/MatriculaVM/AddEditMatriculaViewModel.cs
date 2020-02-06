using ColegioPublic.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.ViewsModel.MatriculaVM
{
    public class AddEditMatriculaViewModel
    {
        public int ? matriculaId { get; set; }
        [Required]
        [Display(Name ="Código Matricula")]
        public string codigoMatricula { get; set; }
        public int ? alumnoId { get; set; }
        [Display(Name="Apellidos")]
        [JsonIgnore]
        public string ApellidosCompletos { get; set; }
        [JsonIgnore]
        [Display(Name="Dni")]
        public string dniAlumno { get; set; }
        [Required]
        [Display(Name="Grado Academico")]
        public int gradoAcademicoId { get; set; }
        [Display(Name="Fecha de Creación")]
        public DateTime fechaCreacion { get; set; }
        [Display(Name="Estado")]
        public int estadoId { get; set; }
        [JsonIgnore]
        public List<SelectListItem> LstGradoAcademico { get; set; } = new List<SelectListItem>();

        public void Fill(CargarDatosContext context, int? matriculaId)
        {
            var matricula = context._context.Matricula.Find(matriculaId);
            if (matricula != null)
            {

            }
            LstGradoAcademico = context._context.GradoAcademico.Select(x => new SelectListItem { Value = x.GradoAcademicoId.ToString(), Text = x.Nombre }).ToList();

        }
        public void FillByAlumno(CargarDatosContext context, int? alumnoId)
        {
            var matricula = context._context.Matricula.Include("Alumno").Where(x => x.AlumnoId ==alumnoId);
            var alumno = context._context.Alumno.Find(alumnoId);
            if (matricula != null)
            {
              
            }
            if (alumno != null)
            {
                this.alumnoId = alumno.AlumnoId;
                this.dniAlumno = alumno.Dni;
                this.ApellidosCompletos = $"{alumno.ApellidoPaterno} {alumno.ApellidoMaterno}";
            }
            LstGradoAcademico = context._context.GradoAcademico.Select(x => new SelectListItem { Value = x.GradoAcademicoId.ToString(), Text = x.Nombre }).ToList();

        }

        public void Delete(CargarDatosContext context, int matriculaId)
        {
            var matricula = context._context.Matricula.Find(matriculaId);
            if (matricula != null)
                matricula.EstadoId = 0;
            context._context.SaveChanges();


        }
    }
}