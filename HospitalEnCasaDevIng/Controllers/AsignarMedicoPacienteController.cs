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
    public class AsignarMedicoPacienteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsignarMedicoPaciente
        public ActionResult Index()
        {
            var asignarMedicoPaciente = db.AsignarMedicoPaciente.Include(a => a.IdentificacionMedicoFK).Include(a => a.IdentificacionPacienteFK);
            return View(asignarMedicoPaciente.ToList());
        }

        // GET: AsignarMedicoPaciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarMedicoPaciente asignarMedicoPaciente = db.AsignarMedicoPaciente.Find(id);
            if (asignarMedicoPaciente == null)
            {
                return HttpNotFound();
            }
            return View(asignarMedicoPaciente);
        }

        // GET: AsignarMedicoPaciente/Create
        public ActionResult Create()
        {
            ViewBag.IdentificacionMedico = new SelectList(db.Medico, "Identificacion", "Identificacion");
            ViewBag.IdentificacionPaciente = new SelectList(db.Paciente, "Identificacion", "Identificacion");
            return View();
        }

        // POST: AsignarMedicoPaciente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdentificacionAsignacion,IdentificacionMedico,IdentificacionPaciente")] AsignarMedicoPaciente asignarMedicoPaciente)
        {
            if (ModelState.IsValid)
            {
                db.AsignarMedicoPaciente.Add(asignarMedicoPaciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdentificacionMedico = new SelectList(db.Medico, "Identificacion", "Identificacion", asignarMedicoPaciente.IdentificacionMedico);
            ViewBag.IdentificacionPaciente = new SelectList(db.Paciente, "Identificacion", "Identificacion", asignarMedicoPaciente.IdentificacionPaciente);
            return View(asignarMedicoPaciente);
        }

        // GET: AsignarMedicoPaciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarMedicoPaciente asignarMedicoPaciente = db.AsignarMedicoPaciente.Find(id);
            if (asignarMedicoPaciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdentificacionMedico = new SelectList(db.Medico, "Identificacion", "Identificacion", asignarMedicoPaciente.IdentificacionMedico);
            ViewBag.IdentificacionPaciente = new SelectList(db.Paciente, "Identificacion", "Identificacion", asignarMedicoPaciente.IdentificacionPaciente);
            return View(asignarMedicoPaciente);
        }

        // POST: AsignarMedicoPaciente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdentificacionAsignacion,IdentificacionMedico,IdentificacionPaciente")] AsignarMedicoPaciente asignarMedicoPaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignarMedicoPaciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdentificacionMedico = new SelectList(db.Medico, "Identificacion", "Identificacion", asignarMedicoPaciente.IdentificacionMedico);
            ViewBag.IdentificacionPaciente = new SelectList(db.Paciente, "Identificacion", "Identificacion", asignarMedicoPaciente.IdentificacionPaciente);
            return View(asignarMedicoPaciente);
        }

        // GET: AsignarMedicoPaciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarMedicoPaciente asignarMedicoPaciente = db.AsignarMedicoPaciente.Find(id);
            if (asignarMedicoPaciente == null)
            {
                return HttpNotFound();
            }
            return View(asignarMedicoPaciente);
        }

        // POST: AsignarMedicoPaciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignarMedicoPaciente asignarMedicoPaciente = db.AsignarMedicoPaciente.Find(id);
            db.AsignarMedicoPaciente.Remove(asignarMedicoPaciente);
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
