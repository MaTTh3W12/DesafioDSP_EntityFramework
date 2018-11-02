using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesafioEntityFramework;

namespace DesafioEntityFramework.Controllers
{
    public class profesorController : Controller
    {
        private DesafioEntities db = new DesafioEntities();

        // GET: profesor
        public ActionResult Index()
        {
            var profesor = db.profesor.Include(p => p.areaConocimiento);
            return View(profesor.ToList());
        }

        // GET: profesor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesor profesor = db.profesor.Find(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        // GET: profesor/Create
        public ActionResult Create()
        {
            ViewBag.id_area_conocimiento = new SelectList(db.areaConocimiento, "id_area_conocimiento", "narea_conocimiento");
            return View();
        }

        // POST: profesor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_profesor,nombre,apellido,despacho,horario_Consultas,id_area_conocimiento")] profesor profesor)
        {
            if (ModelState.IsValid)
            {
                db.profesor.Add(profesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_area_conocimiento = new SelectList(db.areaConocimiento, "id_area_conocimiento", "narea_conocimiento", profesor.id_area_conocimiento);
            return View(profesor);
        }

        // GET: profesor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesor profesor = db.profesor.Find(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_area_conocimiento = new SelectList(db.areaConocimiento, "id_area_conocimiento", "narea_conocimiento", profesor.id_area_conocimiento);
            return View(profesor);
        }

        // POST: profesor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_profesor,nombre,apellido,despacho,horario_Consultas,id_area_conocimiento")] profesor profesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_area_conocimiento = new SelectList(db.areaConocimiento, "id_area_conocimiento", "narea_conocimiento", profesor.id_area_conocimiento);
            return View(profesor);
        }

        // GET: profesor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesor profesor = db.profesor.Find(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        // POST: profesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            profesor profesor = db.profesor.Find(id);
            db.profesor.Remove(profesor);
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
