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
    [Authorize(Roles = "admin")]
    public class GruposClasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GruposClases
        public ActionResult Index()
        {
            return View(db.GruposClases.ToList());
        }

        // GET: GruposClases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposClase gruposClase = db.GruposClases.Find(id);
            if (gruposClase == null)
            {
                return HttpNotFound();
            }
            return View(gruposClase);
        }

        // GET: GruposClases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GruposClases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion,numAlumnos")] GruposClase gruposClase)
        {
            if (ModelState.IsValid)
            {
                db.GruposClases.Add(gruposClase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gruposClase);
        }

        // GET: GruposClases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposClase gruposClase = db.GruposClases.Find(id);
            if (gruposClase == null)
            {
                return HttpNotFound();
            }
            return View(gruposClase);
        }

        // POST: GruposClases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion,numAlumnos")] GruposClase gruposClase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gruposClase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gruposClase);
        }

        // GET: GruposClases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposClase gruposClase = db.GruposClases.Find(id);
            if (gruposClase == null)
            {
                return HttpNotFound();
            }
            return View(gruposClase);
        }

        // POST: GruposClases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GruposClase gruposClase = db.GruposClases.Find(id);
            db.GruposClases.Remove(gruposClase);
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
