using ColegioPublic.Helper;
using ColegioPublic.ViewsModel.AlumnoVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Transactions;
using System.Web;

namespace ColegioPublic.ViewsModel.UsuarioMovilVM
{
    public class AddEditUsuarioMovilViewModel
    {
        public int? UsuarioId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        [Display(Name="Apellido Materno")]
        public string  ApellidoM { get; set; }
        [Display(Name="Apellido Paterno")]
        public string ApellidoP { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int EstadoId { get; set; }
        public void Fill(CargarDatosContext context, int? usuarioId)
        {
            var usuario = context._context.Usuario.Find(usuarioId);
            if (usuario != null)
            {
                this.UsuarioId= usuarioId;
                this.Nombre = usuario.Nombre;
                this.UserName = usuario.UserName;
                this.Password = usuario.password;
                this.ApellidoM = usuario.ApellidosM;
                this.ApellidoP = usuario.ApellidosP;
                this.Correo = usuario.Correo;
                this.Telefono = usuario.Telefono;
                this.EstadoId = usuario.EstadoId.Value;
            }
        }
        public void AddEdit(CargarDatosContext context, AddEditUsuarioMovilViewModel model)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    var usuario = context._context.Usuario.Find(model.UsuarioId);
                    if (usuario == null)
                    {
                        usuario = new Data.Model.Usuario();
                        context._context.Usuario.Add(usuario);
                    }
                    usuario.Nombre = model.Nombre;
                    usuario.ApellidosP = model.ApellidoP;
                    usuario.ApellidosM = model.ApellidoM;
                    usuario.Correo = model.Correo;
                    usuario.Telefono = model.Telefono;
                    usuario.UserName = model.UserName;
                    usuario.password = model.Password;
                    usuario.EstadoId = 1;
                    context._context.SaveChanges();
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public void Delete(CargarDatosContext context, int usuarioId)
        {
            var usuario = context._context.Usuario.Find(usuarioId);
            if (usuario != null)
                usuario.EstadoId = 0;
            context._context.SaveChanges();
        }
    }
}