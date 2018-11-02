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
    public class materiasController : Controller
    {
        private DesafioEntities db = new DesafioEntities();

        // GET: materias
        public ActionResult Index()
        {
            var materia = db.materia.Include(m => m.titulacion).Include(m => m.tipoMateria);
            return View(materia.ToList());
        }

        // GET: materias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materia materia = db.materia.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // GET: materias/Create
        public ActionResult Create()
        {
            ViewBag.id_titulacion = new SelectList(db.titulacion, "id_titulacion", "ntitulacion");
            ViewBag.id_tipo_materia = new SelectList(db.tipoMateria, "id_tipo_materia", "ntipo_materia");
            return View();
        }

        // POST: materias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_materia,nmateria,codigo_materia,curso,id_tipo_materia,id_titulacion,creditos_teoricos,creditos_laboratorio,duracion,limiteAdmision,gruposTeoria,gruposLaboratorio")] materia materia)
        {
            if (ModelState.IsValid)
            {
                db.materia.Add(materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_titulacion = new SelectList(db.titulacion, "id_titulacion", "ntitulacion", materia.id_titulacion);
            ViewBag.id_tipo_materia = new SelectList(db.tipoMateria, "id_tipo_materia", "ntipo_materia", materia.id_tipo_materia);
            return View(materia);
        }

        // GET: materias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materia materia = db.materia.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_titulacion = new SelectList(db.titulacion, "id_titulacion", "ntitulacion", materia.id_titulacion);
            ViewBag.id_tipo_materia = new SelectList(db.tipoMateria, "id_tipo_materia", "ntipo_materia", materia.id_tipo_materia);
            return View(materia);
        }

        // POST: materias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_materia,nmateria,codigo_materia,curso,id_tipo_materia,id_titulacion,creditos_teoricos,creditos_laboratorio,duracion,limiteAdmision,gruposTeoria,gruposLaboratorio")] materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_titulacion = new SelectList(db.titulacion, "id_titulacion", "ntitulacion", materia.id_titulacion);
            ViewBag.id_tipo_materia = new SelectList(db.tipoMateria, "id_tipo_materia", "ntipo_materia", materia.id_tipo_materia);
            return View(materia);
        }

        // GET: materias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materia materia = db.materia.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // POST: materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            materia materia = db.materia.Find(id);
            db.materia.Remove(materia);
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
