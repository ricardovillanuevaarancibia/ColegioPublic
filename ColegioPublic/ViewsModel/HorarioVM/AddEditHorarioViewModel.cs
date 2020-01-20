using ColegioPublic.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColegioPublic.ViewsModel.HorarioVM
{
    public class AddEditHorarioViewModel
    {

        public int HorarioId { get; set; }
        public int GradoAcademicoId { get; set; }
        public int CursoId { get; set; }
        public DateTime? LuneshoraInicio { get; set; }
        public DateTime? LunesHoraFin { get; set; }
        public DateTime? MartesHoraInicio { get; set; }
        public DateTime? MartesHoraFin { get; set; }

        public DateTime? MiercolesHoraInicio { get; set; }
        public DateTime? MiercolesHoraFin { get; set; }
        public DateTime? JuevesHoraInicio { get; set; }

        public DateTime? JuevesHoraFin { get; set; }
        public DateTime? ViernesHoraInicio { get; set; }
        public DateTime? ViernesHoraFin { get; set; }
        public DateTime? SabadoHoraInicio { get; set; }
        public DateTime? SabadoHoraFin { get; set; }
        public DateTime? DomingoHoraInicio { get; set; }
        public DateTime? DomingoHoraFin { get; set; }

        public void cargarHorario(CargarDatosContext context ,int gradoAcademicoId,int cursoId)
        {
            var horario = context._context.Horario.Where(x => x.GradoAcademicoId == gradoAcademicoId && x.CursoId == cursoId).FirstOrDefault();
            if (horario!=null)
            {
                this.HorarioId = HorarioId;
          
                this.LuneshoraInicio = horario.LunesHoraInicio.Value;
                this.LunesHoraFin = horario.LunesHoraFin.Value;
                this.MartesHoraInicio = horario.MartesHoraInicio.Value;
                this.MartesHoraFin = horario.MartesHoraFin.Value;
                this.MiercolesHoraInicio = horario.MiercolesHoraInicio.Value;
                this.MiercolesHoraFin = horario.MiercolesHoraFin.Value;
                this.JuevesHoraInicio = horario.JuevesHoraInicio.Value;
                this.JuevesHoraFin = horario.JuevesHoraFin.Value;
                this.ViernesHoraInicio = horario.ViernesHoraInicio.Value;
                this.ViernesHoraFin = horario.ViernesHoraFin.Value;
                this.SabadoHoraInicio = horario.SabadoHoraInicio.Value;
                this.SabadoHoraFin = horario.SabadoHoraFin.Value;
                this.DomingoHoraInicio = horario.DomingoHoraInicio.Value;
                this.DomingoHoraFin = horario.DomingoHoraFIn.Value;
            }
            this.CursoId = cursoId;
            this.GradoAcademicoId = gradoAcademicoId;
        }

        public void GuardarHorario(CargarDatosContext context , AddEditHorarioViewModel model)
        {
            var horario =context._context.Horario.Find(model.HorarioId);
            if(horario== null)
            {
                horario = new Data.Model.Horario();
                context._context.Horario.Add(horario);
            }
            horario.CursoId = model.CursoId;
            horario.GradoAcademicoId = model.GradoAcademicoId;
            horario.LunesHoraInicio = model.LuneshoraInicio.Value;
            horario.LunesHoraFin = model.LunesHoraFin.Value;
            horario.MartesHoraInicio = model.MartesHoraInicio.Value;
            horario.MartesHoraFin = model.MartesHoraFin.Value;
            horario.MiercolesHoraInicio = model.MiercolesHoraInicio.Value;
            horario.MiercolesHoraFin = model.MiercolesHoraFin.Value;
            horario.JuevesHoraInicio = model.JuevesHoraInicio.Value;
            horario.JuevesHoraFin = model.JuevesHoraFin.Value;
            horario.ViernesHoraInicio = model.ViernesHoraInicio.Value;
            horario.ViernesHoraFin = model.ViernesHoraFin.Value;
            horario.SabadoHoraInicio = model.SabadoHoraInicio.Value;
            horario.SabadoHoraFin = model.SabadoHoraFin.Value;
            horario.DomingoHoraInicio = model.DomingoHoraInicio.Value;
            horario.DomingoHoraFIn = model.DomingoHoraFin.Value;
            horario.EstadoId = 1;
            context._context.SaveChanges();
        }

    }
}