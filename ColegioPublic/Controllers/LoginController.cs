using ColegioPublic.Helper;
using ColegioPublic.ViewsModel.UserVM;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Log(UserViewModel model)
        {
            var user =_CargarDatosContext._context.User.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
            if (user!=null) {
                Session.Add(SessionExtencion.Datos.UsuarioId.ToString(), user.UserId);
            }
            else
            {
                ViewBag.ErrorMsg = " Error";
                return RedirectToAction("Index");
            }
          return  RedirectToAction("Index","Home");
        }
    }
}