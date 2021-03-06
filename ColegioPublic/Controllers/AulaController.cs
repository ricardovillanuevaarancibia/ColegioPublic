﻿using ColegioPublic.Extensions;
using ColegioPublic.ViewsModel.AulaVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ColegioPublic.Controllers
{
    public class AulaController : BaseController
    {
        // GET: Aula
        public ActionResult Index(IndexAulaViewModel model)
        {
            model.Fill(_CargarDatosContext, model);
            return View(model);
        }

        public async Task<PartialViewResult> _ListAula(int? p, IndexAulaViewModel model)
        {
            _ListAulaViewModel listModel = new _ListAulaViewModel();
            await listModel.FillList(_CargarDatosContext, model, p);
            return PartialView(listModel);
        }

        public ActionResult AddEditAula(int? AulaId)
        {
            AddEditAulaViewModel model = new AddEditAulaViewModel();
            model.Fill(_CargarDatosContext, AulaId);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEditAula(AddEditAulaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TryUpdateModel(model);
                    return View(model);
                }

                AddEditAulaViewModel addEdit = new AddEditAulaViewModel();
                addEdit.AddEdit(_CargarDatosContext, model);
                this.AddNotification($"Se Guardaron correctamente los datos", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.AddNotification($"Error al guardar datos ", NotificationType.ERROR);
                return View(model);
            }
        }

        public ActionResult Delete(int AulaId)
        {

            try
            {
                AddEditAulaViewModel model = new AddEditAulaViewModel();
                model.Delete(_CargarDatosContext, AulaId);
                return Json(new { Value = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Value = false }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}