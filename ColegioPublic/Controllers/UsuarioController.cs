using ColegioPublic.ViewsModel.AlumnoVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class UsuarioController : BaseController
    {
        public ActionResult Index(IndexAlumnoViewModel model)
        {
            model.Fill(_CargarDatosContext, model);
            return View(model);
        }

        public async Task<PartialViewResult> _ListUsuario(int? p, IndexAlumnoViewModel model)
        {
            _ListAlumnoViewModel listModel = new _ListAlumnoViewModel();
            await listModel.FillList(_CargarDatosContext, model, p);
            return PartialView(listModel);
        }

        public ActionResult AddEditUsuario(int? idAlumno)
        {
            AddEditAlumnoViewModel model = new AddEditAlumnoViewModel();
            model.Fill(_CargarDatosContext, idAlumno);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEditUsuario(AddEditAlumnoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TryUpdateModel(model);
                    return View(model);
                }

                AddEditAlumnoViewModel addEdit = new AddEditAlumnoViewModel();
                addEdit.AddEdit(_CargarDatosContext, model);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Delete(int? idAlumno)
        {
            AddEditAlumnoViewModel model = new AddEditAlumnoViewModel();
            model.Fill(_CargarDatosContext, idAlumno);
            return View(model);
        }

    }
}