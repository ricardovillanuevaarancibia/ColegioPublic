using ColegioPublic.Helper;
using ColegioPublic.ViewsModel.AlumnoVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Transactions;
using System.Web;

namespace ColegioPublic.ViewsModel.ActividadVM
{
    public class AddEditActividadViewModel
    {
        public int? ActividadId { get; set; }
        public string Nombre { get; set; }
 
        [Display(Name = "Fecha de Inicio")]
        public DateTime? FechaInicio{ get; set; }
        [Display(Name = "Fecha de Fin")]
        public DateTime? FechaFin { get; set; }
        [Display(Name ="Descripción")]
        public string descripcion { get; set; }
        public int EstadoId { get; set; }
        public void Fill(CargarDatosContext context, int? actividadId)
        {
            var actividad = context._context.Actividades.Find(actividadId);
            if (actividad != null)
            {
                this.ActividadId = actividadId;
                this.Nombre = actividad.Nombre;
                this.FechaInicio = actividad.FechaInicio;
                this.FechaFin = actividad.FechaFin;
                this.descripcion = actividad.Descripcion;
                this.EstadoId = actividad.EstadoId.Value;

            }
        }
        public void AddEdit(CargarDatosContext context, AddEditActividadViewModel model)
        {
            using (var ts = new TransactionScope())
            {
                try
                {

                    var actividad = context._context.Actividades.Find(model.ActividadId);

                    if (actividad == null)
                    {
                        actividad = new Data.Model.Actividades();
                        context._context.Actividades.Add(actividad);
                    }

                    actividad.Nombre = model.Nombre;
                    actividad.FechaInicio = model.FechaInicio;
                    actividad.FechaFin = model.FechaFin;
                    actividad.Descripcion = model.descripcion;
                    actividad.EstadoId = 1;
                    context._context.SaveChanges();
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