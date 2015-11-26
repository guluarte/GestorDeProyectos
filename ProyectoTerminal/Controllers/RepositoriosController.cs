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
    public class RepositoriosController : Controller
    {
        private ProyectoTerminalContext db = new ProyectoTerminalContext();

        // GET: /Repositorios/
        public ActionResult Index(Guid pId)
        {
            var repos = db.Repositorios.Where(n => n.ProyectoId == pId);
            return View(repos.ToList());
        }

        // GET: /Repositorios/Details/5
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

        // GET: /Repositorios/Create
        public ActionResult Create(Guid pId)
        {
            var repo = new Repositorio
            {
                ProyectoId = pId
            };
            return View(repo);
        }

        // POST: /Repositorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Url,ProyectoId")] Repositorio repositorio)
        {
            if (ModelState.IsValid)
            {
                repositorio.Id = Guid.NewGuid();
                db.Repositorios.Add(repositorio);
                db.SaveChanges();
                return RedirectToAction("Index", new { pId = repositorio.ProyectoId });
            }

            return View(repositorio);
        }

        // GET: /Repositorios/Edit/5
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

        // POST: /Repositorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Url,ProyectoId")] Repositorio repositorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repositorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { pId = repositorio.ProyectoId });
            }
            return View(repositorio);
        }

        // GET: /Repositorios/Delete/5
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

        // POST: /Repositorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Repositorio repositorio = db.Repositorios.Find(id);
            db.Repositorios.Remove(repositorio);
            db.SaveChanges();
            return RedirectToAction("Index", new { pId = repositorio.ProyectoId });
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