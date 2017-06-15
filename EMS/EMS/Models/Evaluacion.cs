using EMS.Models;
using Reingenieria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reingenieria_EMS.Models
{
    public class Evaluacion
    {
        public int Id { get; set; }

        public enum ConvocatoriaType
        {
            Ordinaria,
            Extraordinaria
        }
        public ConvocatoriaType convocatoria { get; set; }
        public int Trabajo1 { get; set; }
        public int Trabajo2 { get; set; }
        public int Trabajo3 { get; set; }
        public int Examen { get; set; }
        public int Practica { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int CursoId { get; set; }
        public virtual Cursos Curso { get; set; }

        public int GrupoId { get; set; }
        public virtual GruposClase Grupo { get; set; }

    }
}