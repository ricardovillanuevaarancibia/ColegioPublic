//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AlumnoAula
    {
        public int AlumnoAulaId { get; set; }
        public Nullable<int> AulaId { get; set; }
        public Nullable<int> AlumnoId { get; set; }
        public Nullable<int> EstadoId { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual Aula Aula { get; set; }
    }
}
