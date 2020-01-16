using ColegioPublic.Filters;
using ColegioPublic.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    [FilterAuthorization]
    public class BaseController : Controller
    {

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        public CargarDatosContext _CargarDatosContext;
        public SessionHelpers _Session;

        public BaseController()
        {
            _Session = new SessionHelpers(base.Session);
            GetInstance();
        }
        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public CargarDatosContext GetInstance()
        {
            if (_CargarDatosContext == null)
            {
                _CargarDatosContext = new CargarDatosContext();
            }
            return _CargarDatosContext;
        }
    }
}