using ColegioPublic.Extensions;
using ColegioPublic.ViewsModel.AlumnoVM;
using ColegioPublic.ViewsModel.UsuarioMovilVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class UsuarioMovilController : BaseController
    {
        // GET: UsuarioMovil
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

        public ActionResult AddEditUsuarioMovil(int? UserId)
        {
            AddEditUsuarioMovilViewModel model = new AddEditUsuarioMovilViewModel();
            model.Fill(_CargarDatosContext, UserId);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEditUsuarioMovil(AddEditUsuarioMovilViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TryUpdateModel(model);
                    return View(model);
                }

                AddEditUsuarioMovilViewModel addEdit = new AddEditUsuarioMovilViewModel();
                addEdit.AddEdit(_CargarDatosContext, model);
                this.AddNotification($"Se Guardaron correctamente los datos", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.AddNotification($"Error al guardar ", NotificationType.ERROR);
                throw;
            }
        }
        public ActionResult Delete(int  UsuarioId)
        { 
            try
            {
                AddEditUsuarioMovilViewModel model = new AddEditUsuarioMovilViewModel();
                model.Delete(_CargarDatosContext, UsuarioId);
                return Json(new { Value = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Value = false }, JsonRequestBehavior.AllowGet);
            }
           
      
        }
    }
}