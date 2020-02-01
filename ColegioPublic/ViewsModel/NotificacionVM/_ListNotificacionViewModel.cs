using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.NotificacionVM
{
    public class _ListNotificacionViewModel
    {
        public List<Notificacion> LstRegistro { get; set; } = new List<Notificacion>();

        public void Fill(CargarDatosContext context ,int usuarioId)
        {
            this.LstRegistro = context._context.Notificacion.Where(x => x.UsuarioSendId == usuarioId && x.EstadoId==1).ToList();
        }


    }
}