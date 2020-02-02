using ColegioPublic.Extensions;
using ColegioPublic.ViewsModel.HorarioVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class HorarioController : BaseController
    {
        // GET: Horario
        public ActionResult Index()
        {
           var model = new  IndexHorarioViewModel();
            model.Fill(_CargarDatosContext,0) ;
            return View(model);
        }
        public PartialViewResult Horario(int gradoId,int cursoId)
        {
            var model = new AddEditHorarioViewModel();
            model.cargarHorario(_CargarDatosContext, gradoId, cursoId);
            return PartialView(model);
        }

        public ActionResult AddEditHorario(AddEditHorarioViewModel model)
        {
            try
            {
                var modelo = new AddEditHorarioViewModel();
                modelo.GuardarHorario(_CargarDatosContext, model);
                this.AddNotification($"Se Guardaron correctamente los datos", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.AddNotification($"Error al guardar datos ", NotificationType.ERROR);
                return RedirectToAction("Index");
            }
  
        }
        [HttpPost]
        public JsonResult getCursoByGrado(int gradoId)
        {
            var data = _CargarDatosContext._context.GradoAcademicoCurso.Where(x => x.GradoAcademicoId == gradoId).Select(x => new SelectListItem() { Value = x.CursoId.ToString(), Text = x.Curso.Nombre }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}