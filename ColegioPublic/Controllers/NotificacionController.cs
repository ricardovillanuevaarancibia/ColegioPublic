﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class NotificacionController : BaseController
    {
        // GET: Notificacion
        public ActionResult Index()
        {
            return View();
        }
    }
}