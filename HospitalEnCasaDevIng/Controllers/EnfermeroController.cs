using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalEnCasaDevIng.Models;

namespace HospitalEnCasaDevIng.Controllers
{
    public class EnfermeroController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Enfermero
        public ActionResult Index()
        {
            return View(db.Enfermero.ToList());
        }

        // GET: Enfermero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermero enfermero = db.Enfermero.Find(id);
            if (enfermero == null)
            {
                return HttpNotFound();
            }
            return View(enfermero);
        }

        // GET: Enfermero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enfermero/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificacion,Nombre,Apellidos,FechaNacimiento,Sexo,Telefono,Correo,GrupoSanguineo,Eps")] Enfermero enfermero)
        {
            if (ModelState.IsValid)
            {
                db.Enfermero.Add(enfermero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enfermero);
        }

        // GET: Enfermero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermero enfermero = db.Enfermero.Find(id);
            if (enfermero == null)
            {
                return HttpNotFound();
            }
            return View(enfermero);
        }

        // POST: Enfermero/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificacion,Nombre,Apellidos,FechaNacimiento,Sexo,Telefono,Correo,GrupoSanguineo,Eps")] Enfermero enfermero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enfermero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enfermero);
        }

        // GET: Enfermero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermero enfermero = db.Enfermero.Find(id);
            if (enfermero == null)
            {
                return HttpNotFound();
            }
            return View(enfermero);
        }

        // POST: Enfermero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enfermero enfermero = db.Enfermero.Find(id);
            db.Enfermero.Remove(enfermero);
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
