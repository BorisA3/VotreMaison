using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaisonVotre.Data;
using MaisonVotre.Models;

namespace MaisonVotre.Controllers
{
    public class EmpresasController : Controller
    {
        private MaisonVotreContext db = new MaisonVotreContext();

        // GET: Empresas
        public ActionResult Index()
        {
            var empresas = db.Empresas.Include(e => e.Categorias).Include(e => e.Ciudades);
            return View(empresas.ToList());
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNombre");
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "CiudadNombre");
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpresaId,EmpresaNombre,EmpresaImagen,EmpresaDescripcion,EmpresaLogo,EmpresaTipo,CiudadId,CategoriaId")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Empresas.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNombre", empresa.CategoriaId);
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "CiudadNombre", empresa.CiudadId);
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNombre", empresa.CategoriaId);
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "CiudadNombre", empresa.CiudadId);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpresaId,EmpresaNombre,EmpresaImagen,EmpresaDescripcion,EmpresaLogo,EmpresaTipo,CiudadId,CategoriaId")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "CategoriaNombre", empresa.CategoriaId);
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "CiudadNombre", empresa.CiudadId);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.Empresas.Find(id);
            db.Empresas.Remove(empresa);
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

        public ActionResult ViewEmpresas()
        {
            var empresas = db.Empresas.Include(e => e.Ciudades);
            return View(empresas.ToList());
        }

    }
}
