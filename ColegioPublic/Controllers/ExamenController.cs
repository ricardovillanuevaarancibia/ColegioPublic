using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class ExamenController : BaseController
    {
        // GET: Examen
        public ActionResult Index()
        {
            return View();
        }
    }
}