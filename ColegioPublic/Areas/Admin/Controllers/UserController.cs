using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _List()
        {
            return PartialView();
        }
        public ActionResult AddEdit(int ? id)
        {
            return View();
        }
        public ActionResult AddEdit()
        {
            return View();
        }
        public ActionResult _Delete() {
            return View();
        }


    }
}