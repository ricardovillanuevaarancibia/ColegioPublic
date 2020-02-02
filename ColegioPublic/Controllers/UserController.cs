using ColegioPublic.Extensions;
using ColegioPublic.ViewsModel.AlumnoVM;
using ColegioPublic.ViewsModel.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Index(IndexUserViewModel model)
        {
            model.Fill(_CargarDatosContext, model);
            return View(model);
        }

        public async Task<PartialViewResult> _ListUser(int? p, IndexUserViewModel model)
        {
            _ListUserViewModel listModel = new _ListUserViewModel();
            await listModel.FillList(_CargarDatosContext, model, p);
            return PartialView(listModel);
        }

        public ActionResult AddEditUser(int? UserId)
        {
            AddEditUserViewModel model = new AddEditUserViewModel();
            model.Fill(_CargarDatosContext, UserId);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEditUser(AddEditUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TryUpdateModel(model);
                    return View(model);
                }

                AddEditUserViewModel addEdit = new AddEditUserViewModel();
                addEdit.AddEdit(_CargarDatosContext, model);
                this.AddNotification($"Se Guardaron correctamente los datos", NotificationType.SUCCESS);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.AddNotification("Error al guardar ", NotificationType.ERROR);
                return View(model);
            }
        }
        public ActionResult Delete(int UserId)
        {

            try
            {
                AddEditUserViewModel model = new AddEditUserViewModel();
                model.Delete(_CargarDatosContext, UserId);
                return Json(new { Value = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Value = false }, JsonRequestBehavior.AllowGet);
            }


        }

    }
}