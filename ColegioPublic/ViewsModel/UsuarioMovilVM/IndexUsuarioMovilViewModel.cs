using ColegioPublic.Helper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.UsuarioMovilVM
{
    public class IndexUsuarioMovilViewModel
    {
        [Display(Name = "Filtro")]
        public int? q { get; set; }
        public List<Usuario> usuario { get; set; }
        internal void Fill(CargarDatosContext cd, IndexUsuarioMovilViewModel model)
        {
            this.q = model.q;
            this.usuario = cd._context.Usuario.ToList();
        }
    }
}