using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.ViewsModel.NotificacionVM
{
    public class AddEditNotificacionViewModel
    {
        
        public int ? NotificacionId { get; set; }
        public string Comentario { get; set; }
        [Display(Name="Tipo de Notificación")]
        public int? TipoNotificacionId { get; set; }
        public List<SelectListItem> LstTipoNotificacion{get;set;}
        [Display(Name="Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name ="Usuario Movil")]
        public int UsuarioSendId { get; set; }
        [Display(Name="Usuario Registro")]
        public int UsuarioRegistro { get; set; }
        public string Titulo { get; set; }
        public int EstadoId { get; set; }

        public void Fill(CargarDatosContext context,int usuarioMovilId,int ? NotificacionId)
        {
            try
            {
                this.UsuarioSendId = usuarioMovilId;
                var notificacion = context._context.Notificacion.Find(NotificacionId);
                if (notificacion != null)
                {
                    this.NotificacionId = notificacion.NotificacionId;
                    this.TipoNotificacionId = notificacion.TipoNotificacionId;
                    this.Titulo = notificacion.Titulo;
                    this.Comentario = notificacion.Comentario;
                }

                this.LstTipoNotificacion = context._context.TipoGenerico.Where(x => x.TipoGenericoPadreId == 7).Select(x => new SelectListItem() {Value=x.TipoGenericoId.ToString(),Text = x.Nombre }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void AddEditNotificacion(CargarDatosContext context , AddEditNotificacionViewModel model)
        {
            try
            {
                var notificacion = context._context.Notificacion.Find(model.NotificacionId);
                if (notificacion == null)
                {
                    notificacion = new Notificacion();
                    notificacion.FechaRegistro = DateTime.Now;
                    context._context.Notificacion.Add(notificacion);
                }
                notificacion.Comentario = model.Comentario;
                notificacion.TipoNotificacionId = model.TipoNotificacionId??1;
         
                notificacion.UsuarioRegistroId = context._session.Get<int>(SessionExtencion.Datos.UsuarioId);
                notificacion.UsuarioSendId = model.UsuarioSendId;
                notificacion.Titulo = model.Titulo;
                notificacion.EstadoId = 1;
              
                var telefonoUserMessage = context._context.Usuario.Find(model.UsuarioSendId).Telefono;
                if(!string.IsNullOrEmpty(telefonoUserMessage))
                    SendImage.EnviarWhatsap(telefonoUserMessage);

                context._context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Delete(CargarDatosContext context, int notificacionId)
        {
            var notificacion = context._context.Notificacion.Find(notificacionId);
            if (notificacion != null)
                notificacion.EstadoId = 0;
            context._context.SaveChanges();


        }
    }
}