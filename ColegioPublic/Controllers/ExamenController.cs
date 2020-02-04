using ColegioPublic.Extensions;

using ColegioPublic.ViewsModel.CursoVM;
using ColegioPublic.ViewsModel.ExamenVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class ExamenController : BaseController
    {

        public ActionResult IndexCurso(IndexCursoViewModel model)
        {
            model.Fill(_CargarDatosContext, model);
            return View(model);
        }
        public async Task<PartialViewResult> _ListCurso(int? p, IndexCursoViewModel model)
        {
            _ListCursoViewModel listModel = new _ListCursoViewModel();
            await listModel.FillList(_CargarDatosContext, model, p);
            return PartialView(listModel);
        }

        public ActionResult ListaExamen(int CursoId)
        {
            ListExamenViewModel model = new ListExamenViewModel();
            model.Fill(_CargarDatosContext, CursoId);
            return View(model);
        }
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

        [HttpPost]
        public ActionResult AddEditExamen(IndexExamenViewModel model)
        {
            try
            {
                var modelo = new AddEditExamenViewModel();
                modelo.GuardarExamen(_CargarDatosContext, model);
                this.AddNotification($"Se Guardaron correctamente los datos", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.AddNotification($"Error al guardar datos ", NotificationType.ERROR);
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public JsonResult getCursoByGrado(int gradoId)
        {
            var data = _CargarDatosContext._context.GradoAcademicoCurso.Where(x => x.GradoAcademicoId == gradoId).Select(x => new SelectListItem() { Value = x.GradoAcademicoCursoId.ToString(), Text = x.Curso.Nombre }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int ExamenId)
        {

            try
            {
                AddEditExamenViewModel model = new AddEditExamenViewModel();
                model.Delete(_CargarDatosContext, ExamenId);
                return Json(new { Value = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Value = false }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}