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
using Microsoft.AspNet.Identity;

namespace EMS.Controllers
{
    [Authorize(Roles = "profesor")]
    public class MatriculasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // FILTER: Matriculas
        private int getGrupoClase()
        {
            string currentUserId = User.Identity.GetUserId();
            var grupos = db.Docencias.Where(p => p.UserId == currentUserId).ToList();
            if (grupos.Count == 0)
                return -1;
            else return grupos.First().Grupo.Id;
        }

        // GET: Matriculas
        public ActionResult Index()
        {
            int grupo = getGrupoClase();
            var matriculas = db.Matriculas.Include(m => m.Curso).Include(m => m.Grupo).Include(m => m.User).Where(p => p.GrupoId == grupo).ToList();
            return View(matriculas.ToList());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "descripcion");
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "descripcion");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Matriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CursoId,GrupoId,UserId")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "descripcion", matricula.CursoId);
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "descripcion", matricula.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", matricula.UserId);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "descripcion", matricula.CursoId);
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "descripcion", matricula.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", matricula.UserId);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CursoId,GrupoId,UserId")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "descripcion", matricula.CursoId);
            ViewBag.GrupoId = new SelectList(db.GruposClases, "Id", "descripcion", matricula.GrupoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", matricula.UserId);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = db.Matriculas.Find(id);
            db.Matriculas.Remove(matricula);
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
