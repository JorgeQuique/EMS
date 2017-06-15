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

namespace EMS.Controllers
{
    [Authorize(Roles = "profesor")]
    public class EvaluacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Evaluacions
        public ActionResult Index()
        {
            var evaluacions = db.Evaluacions.Include(e => e.Curso).Include(e => e.User);
            return View(evaluacions.ToList());
        }

        // GET: Evaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacions.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "descripcion");
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "descripcion");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Evaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,convocatoria,Trabajo1,Trabajo2,Trabajo3,Examen,Practica,UserId,GrupoId,CursoId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Evaluacions.Add(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "descripcion", evaluacion.CursoId);
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "descripcion", evaluacion.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", evaluacion.UserId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacions.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "descripcion", evaluacion.CursoId);
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "descripcion", evaluacion.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", evaluacion.UserId);
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,convocatoria,Trabajo1,Trabajo2,Trabajo3,Examen,Practica,UserId,GrupoId,CursoId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "descripcion", evaluacion.CursoId);
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "descripcion", evaluacion.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", evaluacion.UserId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacions.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = db.Evaluacions.Find(id);
            db.Evaluacions.Remove(evaluacion);
            db.SaveChanges();
            return RedirectToAction("Index");
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
