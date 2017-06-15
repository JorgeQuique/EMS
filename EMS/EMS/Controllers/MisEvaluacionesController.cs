using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Models;
using Reingenieria_EMS.Models;
using Microsoft.AspNet.Identity;

namespace PracticaEMS.Controllers
{
    [Authorize(Roles = "alumno")]
    public class MisEvaluacionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MisEvaluaciones
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var evaluaciones = db.Evaluacions.Include(e => e.Curso).Include(e => e.User).Where(p => p.UserId == currentUserId);
            return View(evaluaciones.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}