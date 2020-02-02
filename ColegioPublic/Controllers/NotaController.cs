using ColegioPublic.Extensions;
using ColegioPublic.ViewsModel.NotaVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class NotaController : BaseController
    {
        // GET: Nota
        public ActionResult Index(IndexNotaViewModel model)
        {
            model.Fill(_CargarDatosContext, model);
            return View(model);
        }

        public async Task<PartialViewResult> _ListCurso(int? p, IndexNotaViewModel model)
        {
            _ListCursoViewModel listModel = new _ListCursoViewModel();
            await listModel.FillList(_CargarDatosContext, model, p);
            return PartialView(listModel);
        }

        public ActionResult AddEditNota (int CursoId,int GradoId)
        {
            AddEditNotaViewModel newNotas = new AddEditNotaViewModel();
            newNotas.Fill(_CargarDatosContext,CursoId,GradoId);
            return View(newNotas);
        }
        [HttpPost]
        public ActionResult AddEditNota(AddEditNotaViewModel model ,FormCollection formCollection)
        {
            try
            {
                AddEditNotaViewModel newNotas = new AddEditNotaViewModel();
                newNotas.AddEdit(_CargarDatosContext, model, formCollection);
                this.AddNotification($"Se Guardaron correctamente los datos", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.AddNotification($"Error al guardar Notas", NotificationType.ERROR);
                throw;
            }
   
         
   
        }

    }
}