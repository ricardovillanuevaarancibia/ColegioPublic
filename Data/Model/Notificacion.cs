//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notificacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notificacion()
        {
            this.NotificacionRespuesta = new HashSet<NotificacionRespuesta>();
        }
    
        public int NotificacionId { get; set; }
        public string Comentario { get; set; }
        public Nullable<int> TipoNotificacionId { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<int> UsuarioSendId { get; set; }
        public Nullable<int> UsuarioRegistroId { get; set; }
        public Nullable<int> EstadoId { get; set; }
        public string Titulo { get; set; }
    
        public virtual TipoGenerico TipoGenerico { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotificacionRespuesta> NotificacionRespuesta { get; set; }
    }
}
