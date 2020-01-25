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
    
    public partial class Matricula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Matricula()
        {
            this.MatriculaAula = new HashSet<MatriculaAula>();
            this.MatriculaCursoProfesor = new HashSet<MatriculaCursoProfesor>();
        }
    
        public int MatriculaId { get; set; }
        public string CodigoMatricula { get; set; }
        public Nullable<int> AlumnoId { get; set; }
        public Nullable<int> GradoAcademicoId { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> EstadoId { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual GradoAcademico GradoAcademico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatriculaAula> MatriculaAula { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatriculaCursoProfesor> MatriculaCursoProfesor { get; set; }
    }
}
