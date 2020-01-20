using ColegioPublic.ViewsModel.AlumnoVM;
using ColegioPublic.ViewsModel.ProfesorVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class ProfesorController : BaseController
    {
        public ActionResult Index(IndexProfesorViewModel model)
        {
            model.Fill(_CargarDatosContext, model);
            return View(model);
        }

        public async Task<PartialViewResult> _ListProfesor(int? p, IndexProfesorViewModel model)
        {
            _ListProfesorViewModel listModel = new _ListProfesorViewModel();
            await listModel.FillList(_CargarDatosContext, model, p);
            return PartialView(listModel);
        }

        public ActionResult AddEditProfesor(int? idProfesor)
        {
            AddEditProfesorViewModel model = new AddEditProfesorViewModel();
            model.Fill(_CargarDatosContext, idProfesor);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEditProfesor(AddEditProfesorViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TryUpdateModel(model);
                    return View(model);
                }
                if (model.Image != null)
                {
                    string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.Image.FileName).ToLower();
                    model.Image.SaveAs(Server.MapPath("~/File/Profesor/" + archivo));
                    model.RutaFoto = Server.MapPath("~/File/Profesor/" + archivo);
                }
                AddEditProfesorViewModel addEdit = new AddEditProfesorViewModel();
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
            AddEditProfesorViewModel model = new AddEditProfesorViewModel();
            model.Fill(_CargarDatosContext, idAlumno);
            return View(model);
        }
    }
}