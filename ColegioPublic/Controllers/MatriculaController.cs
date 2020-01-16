using ColegioPublic.ViewsModel.MatriculaVM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class MatriculaController : BaseController
    {
        string Baseurl = "http://localhost:1478";
        // GET: Matricula
        public ActionResult Index(IndexMatriculaViewModel model)
        {
            model.Fill(_CargarDatosContext, model);
            return View(model);
        }
        public async Task<PartialViewResult> _ListMatricula(int? p, IndexMatriculaViewModel model)
        {
            _ListMatriculaViewModel listModel = new _ListMatriculaViewModel();
            await listModel.FillList(_CargarDatosContext, model, p);
            return PartialView(listModel);
        }
        public ActionResult AddEditMatricula(int? idAlumno,int? idMatricula)
        {
            AddEditMatriculaViewModel model = new AddEditMatriculaViewModel();
            model.FillByAlumno(_CargarDatosContext, idAlumno);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AddEditMatricula(AddEditMatriculaViewModel model)
        {

            List<AddEditMatriculaViewModel> EmpInfo = new List<AddEditMatriculaViewModel>();
            using (var client = new HttpClient())
            {
                model.matriculaId = 0;
                model.estadoId = 1;
                model.fechaCreacion = DateTime.Now;

                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = ConfigurationManager.AppSettings["WebApiBase"] + "/api/Matricula/Matricula/Create";
                var response = await client.PostAsync(url, data);
                string result = response.Content.ReadAsStringAsync().Result;

                return  RedirectToAction("Index");
            }
        }
    }
}