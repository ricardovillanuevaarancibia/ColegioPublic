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
    
    public partial class GradoAcademicoCurso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GradoAcademicoCurso()
        {
            this.Examen = new HashSet<Examen>();
            this.Silabo = new HashSet<Silabo>();
        }
    
        public int GradoAcademicoCursoId { get; set; }
        public int CursoId { get; set; }
        public int GradoAcademicoId { get; set; }
        public int EstadoId { get; set; }
        public string Silabos { get; set; }
    
        public virtual Curso Curso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Examen> Examen { get; set; }
        public virtual GradoAcademico GradoAcademico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Silabo> Silabo { get; set; }
    }
}
