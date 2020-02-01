using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColegioPublic.Helper
{
    public class CargarDatosContext
    {
        public ColegioBdEntities _context;
        public HttpSessionStateBase _session;


        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.

        public CargarDatosContext(HttpSessionStateBase  sesion)
        {
            GetInstance();
            GetSession(sesion);
        }
        public ColegioBdEntities GetInstance()
        {
            if (_context == null)
            {
                _context = new ColegioBdEntities();
            }
            return _context;
        }
        public HttpSessionStateBase GetSession(HttpSessionStateBase session)
        {
            if (_session == null)
            {
                _session = session;
            }
            return _session;
        }
    }
}