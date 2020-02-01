using ColegioPublic.ViewsModel.NotificacionVM;
using ColegioPublic.ViewsModel.UsuarioMovilVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class NotificacionController : BaseController
    {
        public ActionResult Index(IndexUsuarioMovilViewModel model)
        {
            model.Fill(_CargarDatosContext, model);
            return View(model);
        }

        public async Task<PartialViewResult> _ListUsuarioMovil(int? p, IndexUsuarioMovilViewModel model)
        {
            _ListUsuarioMovilViewModel listModel = new _ListUsuarioMovilViewModel();
            await listModel.FillList(_CargarDatosContext, model, p);
            return PartialView(listModel);
        }
        public ActionResult _ListNotificacion(int usuarioId)
        {
            try
            {
                _ListNotificacionViewModel model = new _ListNotificacionViewModel();
                model.Fill(_CargarDatosContext, usuarioId);
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult AddNotification(int usuarioId)
        {
            try
            {
                AddEditNotificacionViewModel model = new AddEditNotificacionViewModel();
                model.Fill(_CargarDatosContext,usuarioId);
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
    
        }
        [HttpPost]
        public ActionResult AddNotification(AddEditNotificacionViewModel model)
        {
            try
            {
                AddEditNotificacionViewModel addNotificacion = new AddEditNotificacionViewModel();
                addNotificacion.AddEditNotificacion(_CargarDatosContext, model);
                return View("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Delete(int NotificacionId)
        {

            try
            {
                AddEditNotificacionViewModel model = new AddEditNotificacionViewModel();
                model.Delete(_CargarDatosContext, NotificacionId);
                return Json(new { Value = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Value = false }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}