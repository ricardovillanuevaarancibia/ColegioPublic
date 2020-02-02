using ColegioPublic.Helper;
using ColegioPublic.ViewsModel.AlumnoVM;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;

namespace ColegioPublic.ViewsModel.ProfesorVM
{
    public class AddEditProfesorViewModel
    {
        public int? ProfesorId { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public int EstadoId { get; set; }

        public HttpPostedFileBase Image { get; set; }
        public string RutaFoto { get; set; }

        public void Fill(CargarDatosContext context, int? profesorId)
        {
            var profesor = context._context.Profesor.Find(profesorId);
            if (profesor != null)
            {
                this.ProfesorId = profesor.ProfesorId;
                this.Nombre = profesor.Nombre;
                this.ApellidoPaterno = profesor.ApellidoPaterno;
                this.ApellidoMaterno = profesor.ApellidoMaterno;
                this.Dni = profesor.Dni;
                this.RutaFoto = profesor.RutaFoto;
  
            }
        }
        public void AddEdit(CargarDatosContext context, AddEditProfesorViewModel model)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                   

                    var profesor = context._context.Profesor.Find(model.ProfesorId);

                    if (profesor == null)
                    {
                        profesor = new Data.Model.Profesor();
                        context._context.Profesor.Add(profesor);
                    }
                    profesor.Nombre = model.Nombre;
                    profesor.ApellidoPaterno = model.ApellidoPaterno;
                    profesor.ApellidoMaterno = model.ApellidoMaterno;
                    profesor.RutaFoto = SendImage.ConvertToBase64(model.Image.InputStream);
                    profesor.EstadoId = 1;
                    context._context.SaveChanges();
                  
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
  
        public void Delete(CargarDatosContext context, int profesorId)
        {
            var profesor = context._context.Profesor.Find(profesorId);
            if (profesor != null)
                profesor.EstadoId = 0;
            context._context.SaveChanges();


        }


    }
}