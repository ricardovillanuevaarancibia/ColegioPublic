using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.UserVM
{
    public class UserViewModel
    {
        [Display(Name ="Usuario")]
        public string UserName { get; set; }
        [Display(Name ="Contraseña")]
        public string Password { get; set; }
    }
}