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

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Delete(int? UserId)
        {
            AddEditUserViewModel model = new AddEditUserViewModel();
            model.Fill(_CargarDatosContext, UserId);
            return View(model);
        }

    }
}