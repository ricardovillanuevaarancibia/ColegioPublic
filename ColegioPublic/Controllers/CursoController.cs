
using ColegioPublic.ViewsModel.CursoVM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class CursoController : BaseController
    {
        string Baseurl = "http://localhost:1478";
        // GET: Curso
        public ActionResult Index(IndexCursoViewModel model)
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
        public ActionResult AddEditCurso(int ? idCurso)
        {
            AddEditCursoViewModel model = new AddEditCursoViewModel();
            model.Fill(_CargarDatosContext, idCurso);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddEditCurso(AddEditCursoViewModel model)
        {
            List<AddEditCursoViewModel> EmpInfo = new List<AddEditCursoViewModel>();
            using (var client = new HttpClient())
            {
                model.cursoId = 0;
                model.estadoId = 1;

                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = ConfigurationManager.AppSettings["WebApiBase"] + "/api/Curso/Cursos/Create";
                var response = await client.PostAsync(url, data);
                string result = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult Delete(int CursoId)
        {

            try
            {
                AddEditCursoViewModel model = new AddEditCursoViewModel();
                model.Delete(_CargarDatosContext, CursoId);
                return Json(new { Value = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Value = false }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}