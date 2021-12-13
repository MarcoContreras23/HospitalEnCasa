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
    public class AsignarEnfermeroPacienteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsignarEnfermeroPaciente
        public ActionResult Index()
        {
            var asignarEnfermeroPaciente = db.AsignarEnfermeroPaciente.Include(a => a.IdentificacionEnfermero).Include(a => a.IdentificacionPaciente);
            return View(asignarEnfermeroPaciente.ToList());
        }

        // GET: AsignarEnfermeroPaciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarEnfermeroPaciente asignarEnfermeroPaciente = db.AsignarEnfermeroPaciente.Find(id);
            if (asignarEnfermeroPaciente == null)
            {
                return HttpNotFound();
            }
            return View(asignarEnfermeroPaciente);
        }

        // GET: AsignarEnfermeroPaciente/Create
        public ActionResult Create()
        {
            ViewBag.IdentificacionEnfemeroFK = new SelectList(db.Enfermero, "Identificacion", "Identificacion");
            ViewBag.IdentificacionPacienteFK = new SelectList(db.Paciente, "Identificacion", "Identificacion");
            return View();
        }

        // POST: AsignarEnfermeroPaciente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdentificacionAsignacion,IdentificacionEnfemeroFK,IdentificacionPacienteFK")] AsignarEnfermeroPaciente asignarEnfermeroPaciente)
        {
            if (ModelState.IsValid)
            {
                db.AsignarEnfermeroPaciente.Add(asignarEnfermeroPaciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdentificacionEnfemeroFK = new SelectList(db.Enfermero, "Identificacion", "Identificacion", asignarEnfermeroPaciente.IdentificacionEnfemeroFK);
            ViewBag.IdentificacionPacienteFK = new SelectList(db.Paciente, "Identificacion", "Identificacion", asignarEnfermeroPaciente.IdentificacionPacienteFK);
            return View(asignarEnfermeroPaciente);
        }

        // GET: AsignarEnfermeroPaciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarEnfermeroPaciente asignarEnfermeroPaciente = db.AsignarEnfermeroPaciente.Find(id);
            if (asignarEnfermeroPaciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdentificacionEnfemeroFK = new SelectList(db.Enfermero, "Identificacion", "Identificacion", asignarEnfermeroPaciente.IdentificacionEnfemeroFK);
            ViewBag.IdentificacionPacienteFK = new SelectList(db.Paciente, "Identificacion", "Identificacion", asignarEnfermeroPaciente.IdentificacionPacienteFK);
            return View(asignarEnfermeroPaciente);
        }

        // POST: AsignarEnfermeroPaciente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdentificacionAsignacion,IdentificacionEnfemeroFK,IdentificacionPacienteFK")] AsignarEnfermeroPaciente asignarEnfermeroPaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignarEnfermeroPaciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdentificacionEnfemeroFK = new SelectList(db.Enfermero, "Identificacion", "Identificacion", asignarEnfermeroPaciente.IdentificacionEnfemeroFK);
            ViewBag.IdentificacionPacienteFK = new SelectList(db.Paciente, "Identificacion", "Identificacion", asignarEnfermeroPaciente.IdentificacionPacienteFK);
            return View(asignarEnfermeroPaciente);
        }

        // GET: AsignarEnfermeroPaciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarEnfermeroPaciente asignarEnfermeroPaciente = db.AsignarEnfermeroPaciente.Find(id);
            if (asignarEnfermeroPaciente == null)
            {
                return HttpNotFound();
            }
            return View(asignarEnfermeroPaciente);
        }

        // POST: AsignarEnfermeroPaciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignarEnfermeroPaciente asignarEnfermeroPaciente = db.AsignarEnfermeroPaciente.Find(id);
            db.AsignarEnfermeroPaciente.Remove(asignarEnfermeroPaciente);
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
