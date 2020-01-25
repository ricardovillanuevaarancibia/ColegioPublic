using ColegioPublic.Helper;
using ColegioPublic.ViewsModel.AlumnoVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Transactions;
using System.Web;

namespace ColegioPublic.ViewsModel.UserVM
{
    public class AddEditUserViewModel
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public int EstadoId { get; set; }
   
        public void Fill(CargarDatosContext context, int? userId)
        {
            var user = context._context.User.Find(userId);
            if (user != null)
            {
                this.UserId = userId;
                this.UserName = user.UserName;
                this.Password = user.Password;
                this.Rol = user.Rol;
                this.EstadoId = user.EstadoId.Value;
            }
        }
        public void AddEdit(CargarDatosContext context, AddEditUserViewModel model)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    var user = context._context.User.Find(model.UserId);

                    if (user == null)
                    {
                        user = new Data.Model.User();
                        context._context.User.Add(user);
                    }
                    user.UserName = model.UserName;
                    user.Password = model.Password;
                    user.Rol = model.Rol;
                    user.EstadoId = 1;
                    context._context.SaveChanges();
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }
        public void Delete(CargarDatosContext context, int userId)
        {
            var user = context._context.User.Find(userId);
            if (user != null)
                user.EstadoId = 0;
            context._context.SaveChanges();


        }
    }
}