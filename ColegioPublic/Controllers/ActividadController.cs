using ColegioPublic.Extensions;
using ColegioPublic.ViewsModel.ActividadVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class ActividadController : BaseController
    {
        // GET: Actividad
        public ActionResult Index(IndexActividadViewModel model)
        {
            model.Fill(_CargarDatosContext, model);
            return View(model);
        }

        public async Task<PartialViewResult> _ListActividad(int? p, IndexActividadViewModel model)
        {
            _ListActividadViewModel listModel = new _ListActividadViewModel();
            await listModel.FillList(_CargarDatosContext, model, p);
            return PartialView(listModel);
        }

        public ActionResult AddEditActividad(int? ActividadId)
        {
            AddEditActividadViewModel model = new AddEditActividadViewModel();
            model.Fill(_CargarDatosContext, ActividadId);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEditActividad(AddEditActividadViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TryUpdateModel(model);
                    return View(model);
                }
                AddEditActividadViewModel addEdit = new AddEditActividadViewModel();
                addEdit.AddEdit(_CargarDatosContext, model);
                this.AddNotification($"Se Guardaron correctamente los datos", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
              
                return View(model);
            }
        }
        public JsonResult Delete(int ActividadId)
        {
            try
            {
                AddEditActividadViewModel model = new AddEditActividadViewModel();
                model.Delete(_CargarDatosContext, ActividadId);
                return Json(new {Value=true}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new {Value=false}, JsonRequestBehavior.AllowGet);
            }
       
        }

    }
}