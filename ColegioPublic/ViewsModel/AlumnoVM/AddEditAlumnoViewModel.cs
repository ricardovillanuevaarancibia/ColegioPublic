using ColegioPublic.Helper;
using System;

using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;

namespace ColegioPublic.ViewsModel.AlumnoVM
{
    public class AddEditAlumnoViewModel
    {
        public int? AlumnoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Required]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }
        public int EstadoId { get; set; }
        [Required]
        public HttpPostedFileBase Image { get; set; }
    
        [Display(Name="Ruta de Foto")]
        public string RutaFoto { get; set; }
        public void Fill(CargarDatosContext context,int ? alumnoId)
        {
            var alumno = context._context.Alumno.Find(alumnoId);
            if (alumno!=null)
            {
                this.AlumnoId = alumnoId;
                this.Nombre = alumno.Nombre;
                this.ApellidoPaterno = alumno.ApellidoPaterno;
                this.ApellidoMaterno = alumno.ApellidoMaterno;
                this.Dni = alumno.Dni;
                this.FechaNacimiento = alumno.FechaNacimiento.Value;
                this.RutaFoto = alumno.RutaFoto;
            }
        }
        public void AddEdit(CargarDatosContext context, AddEditAlumnoViewModel model)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    var alumno = context._context.Alumno.Find(model.AlumnoId);

                    if (alumno == null)
                    {
                        alumno = new Data.Model.Alumno();
                        context._context.Alumno.Add(alumno);
                    }
                  
                    alumno.Nombre = model.Nombre;
                    alumno.ApellidoPaterno = model.ApellidoPaterno;
                    alumno.ApellidoMaterno = model.ApellidoMaterno;
                    alumno.Dni = model.Dni;
                    alumno.FechaNacimiento = model.FechaNacimiento;
                    alumno.RutaFoto = SendImage.ConvertToBase64(model.Image.InputStream);
                    alumno.EstadoId = 1;
                    context._context.SaveChanges();
                    ts.Complete();
                }
                catch (Exception ex)
                {

                    throw;
                }
               
            }
        }
        public void Delete(CargarDatosContext context,int alumnoId)
        {
            var alumno = context._context.Alumno.Find(alumnoId);
            if (alumno != null)
                alumno.EstadoId = 0;
            context._context.SaveChanges();


        }

       
    }
}