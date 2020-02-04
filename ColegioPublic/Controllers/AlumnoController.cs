using ColegioPublic.Extensions;
using ColegioPublic.Helper;
using ColegioPublic.ViewsModel.AlumnoVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class AlumnoController : BaseController
    {

        // GET: Alumno
        public ActionResult Index(IndexAlumnoViewModel model)
        {
      
            model.Fill(_CargarDatosContext, model);
            return View(model);
        }

        public async Task<PartialViewResult> _ListAlumno(int? p, IndexAlumnoViewModel model)
        {
            _ListAlumnoViewModel listModel = new _ListAlumnoViewModel();
            await listModel.FillList(_CargarDatosContext, model, p);
            return PartialView(listModel);
        }

        public ActionResult AddEditAlumno(int? idAlumno)
        {
            AddEditAlumnoViewModel model = new AddEditAlumnoViewModel();
            model.Fill(_CargarDatosContext,idAlumno);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEditAlumno(AddEditAlumnoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TryUpdateModel(model);
                    return View(model);
                }
                //if (model.Image != null)
                //{
                //    string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.Image.FileName).ToLower();
                //    model.Image.SaveAs(Server.MapPath("~/File/Alumno/" + archivo));
                //    model.RutaFoto = Server.MapPath("~/File/Alumno/" + archivo);
                //}

                AddEditAlumnoViewModel addEdit = new AddEditAlumnoViewModel();
                addEdit.AddEdit(_CargarDatosContext, model);
                this.AddNotification($"Se Guardaron correctamente los datos", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.AddNotification($"Error al guardar datos ", NotificationType.ERROR);
                return View(model);
            }
        }
        public ActionResult Delete(int AlumnoId)
        {

            try
            {
                AddEditAlumnoViewModel model = new AddEditAlumnoViewModel();
                model.Delete(_CargarDatosContext, AlumnoId);
                return Json(new { Value = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Value = false }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}