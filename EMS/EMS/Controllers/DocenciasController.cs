using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Models;
using Reingenieria.Models;

namespace EMS.Controllers
{
    [Authorize(Roles = "admin")]
    public class DocenciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Docencias
        public ActionResult Index()
        {
            var docencias = db.Docencias.Include(d => d.Curso).Include(d => d.Grupo).Include(d => d.User);
            return View(docencias.ToList());
        }

        // GET: Docencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docencia docencia = db.Docencias.Find(id);
            if (docencia == null)
            {
                return HttpNotFound();
            }
            return View(docencia);
        }

        // GET: Docencias/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Curso");
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "Grupo");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Docencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CursoId,GrupoId,UserId")] Docencia docencia)
        {
            if (ModelState.IsValid)
            {
                db.Docencias.Add(docencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Curso", docencia.CursoId);
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "Grupo", docencia.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", docencia.UserId);
            return View(docencia);
        }

        // GET: Docencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docencia docencia = db.Docencias.Find(id);
            if (docencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Curso", docencia.CursoId);
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "Grupo", docencia.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Profesor", docencia.UserId);
            return View(docencia);
        }

        // POST: Docencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CursoId,GrupoId,UserId")] Docencia docencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Curso", docencia.CursoId);
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "Grupo", docencia.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Profesor", docencia.UserId);
            return View(docencia);
        }

        // GET: Docencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docencia docencia = db.Docencias.Find(id);
            if (docencia == null)
            {
                return HttpNotFound();
            }
            return View(docencia);
        }

        // POST: Docencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Docencia docencia = db.Docencias.Find(id);
            db.Docencias.Remove(docencia);
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