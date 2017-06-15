using EMS.Models;
using Reingenieria_EMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reingenieria.Models
{
    public class Docencia
    {
        public int Id { get; set; }

        public int CursoId { get; set; }
        public virtual Cursos Curso { get; set; }

        public int GrupoId { get; set; }
        public virtual GruposClase Grupo { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}