﻿using ColegioPublic.Helper;
using ColegioPublic.ViewsModel.ActividadVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Transactions;
using System.Web;

namespace ColegioPublic.ViewsModel.AulaVM
{
    public class AddEditAulaViewModel
    {
        public int? AulaId { get; set; }
        [Required]
        [Display(Name ="Código de Aula")]
        public string CodigoAula { get; set; }
        [Required]
        [Display(Name="Capacidad Máxima")]
        public int CapacidadMax { get; set; }
        [Required]
        [Display(Name="Estado")]
        public int EstadoId {get; set;}
        public void Fill(CargarDatosContext context, int? aulaId)
        {
            var aula = context._context.Aula.Find(aulaId);
            if (aula != null)
            {
                this.AulaId = aulaId;
                this.CodigoAula = aula.CodigoAula;
                this.CapacidadMax = aula.CapacidadMax.Value;
                this.EstadoId = aula.EstadoId.Value;
            }
        }
        public void AddEdit(CargarDatosContext context, AddEditAulaViewModel model)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    var aula = context._context.Aula.Find(model.AulaId);

                    if (aula == null)
                    {
                        aula = new Data.Model.Aula();
                        context._context.Aula.Add(aula);
                    }
                    aula.CodigoAula = model.CodigoAula;
                    aula.CapacidadMax = model.CapacidadMax;
                    aula.EstadoId = 1;
                    context._context.SaveChanges();
                    ts.Complete();
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }
        public void Delete(CargarDatosContext context, int aulaId)
        {
            var aula = context._context.Aula.Find(aulaId);
            if (aula != null)
                aula.EstadoId = 0;
            context._context.SaveChanges();


        }
    }
}