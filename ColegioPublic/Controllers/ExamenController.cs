using ColegioPublic.ViewsModel.ExamenVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class ExamenController : BaseController
    {
        // GET: Examen
        public ActionResult Index()
        {
            var model = new IndexExamenViewModel();
            model.Fill(_CargarDatosContext, 0);
            return View(model);
        }
        public PartialViewResult Examen(int gradoCursoId)
        {
            var model = new AddEditExamenViewModel();
            model.cargarExamen(_CargarDatosContext, gradoCursoId);
            return PartialView(model);
        }


        public ActionResult AddEditExamen(AddEditExamenViewModel model)
        {
            try
            {
                var modelo = new AddEditExamenViewModel();
                modelo.GuardarExamen(_CargarDatosContext, model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public JsonResult getCursoByGrado(int gradoId)
        {
            var data = _CargarDatosContext._context.GradoAcademicoCurso.Where(x => x.GradoAcademicoId == gradoId).Select(x => new SelectListItem() { Value = x.GradoAcademicoCursoId.ToString(), Text = x.Curso.Nombre }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}