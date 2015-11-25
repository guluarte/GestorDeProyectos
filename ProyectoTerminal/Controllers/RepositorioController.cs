using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoTerminal.Models;

namespace ProyectoTerminal.Controllers
{
    public class RepositorioController : Controller
    {
        private ProyectoTerminalContext db = new ProyectoTerminalContext();

        // GET: /Repositorio/
        public ActionResult Index()
        {
            return View(db.Repositorios.ToList());
        }

        // GET: /Repositorio/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repositorio repositorio = db.Repositorios.Find(id);
            if (repositorio == null)
            {
                return HttpNotFound();
            }
            return View(repositorio);
        }

        // GET: /Repositorio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Repositorio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Url")] Repositorio repositorio)
        {
            if (ModelState.IsValid)
            {
                repositorio.Id = Guid.NewGuid();
                db.Repositorios.Add(repositorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repositorio);
        }

        // GET: /Repositorio/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repositorio repositorio = db.Repositorios.Find(id);
            if (repositorio == null)
            {
                return HttpNotFound();
            }
            return View(repositorio);
        }

        // POST: /Repositorio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Url")] Repositorio repositorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repositorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repositorio);
        }

        // GET: /Repositorio/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repositorio repositorio = db.Repositorios.Find(id);
            if (repositorio == null)
            {
                return HttpNotFound();
            }
            return View(repositorio);
        }

        // POST: /Repositorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Repositorio repositorio = db.Repositorios.Find(id);
            db.Repositorios.Remove(repositorio);
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
