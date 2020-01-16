using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class GradoAcademicoController : BaseController
    {
        // GET: GradoAcademico
        public ActionResult Index()
        {
            return View();
        }
    }
}