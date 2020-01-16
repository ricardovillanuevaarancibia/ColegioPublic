using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class NotaController : BaseController
    {
        // GET: Nota
        public ActionResult Index()
        {
            return View();
        }
    }
}