using ColegioPublic.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Transactions;
using System.Web;

namespace ColegioPublic.ViewsModel.CursoVM
{
    public class AddEditCursoViewModel
    {
        public int? cursoId { get; set; }
        [Display(Name ="Nombre")]
        public string nombre { get; set; }
        [Display(Name ="Imagen")]
        public string image { get; set; }
        public int estadoId { get; set; }
        public void Fill(CargarDatosContext context, int? cursoId)
        {
            var curso = context._context.Curso.Find(cursoId);
            if (curso != null)
            {
                this.cursoId =cursoId;
                this.nombre = curso.Nombre;
                this.image = curso.Image;
                this.estadoId = curso.EstadoId;
            }
        }
        public void AddEdit(CargarDatosContext context, AddEditCursoViewModel model)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    var curso = context._context.Curso.Find(model.cursoId);

                    if (curso == null)
                    {
                        curso = new Data.Model.Curso();
                        context._context.Curso.Add(curso);
                    }

                    curso.Nombre = model.nombre;
                    curso.EstadoId = 1; 
                    curso.Image = model.image;
                    context._context.SaveChanges();
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }
        public void Delete(CargarDatosContext context, int cursoId)
        {
            var curso = context._context.Curso.Find(cursoId);
            if (curso != null)
                curso.EstadoId = 0;
            context._context.SaveChanges();


        }

    }
}