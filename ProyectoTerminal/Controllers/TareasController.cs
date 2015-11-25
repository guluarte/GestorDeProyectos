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
    public class TareasController : Controller
    {
        private ProyectoTerminalContext db = new ProyectoTerminalContext();

        // GET: /Tareas/
        public ActionResult Index(Guid pId)
        {
            var tareas = db.Tareas.Where(n => n.ProyectoId == pId);
            return View(tareas.ToList());
        }

        // GET: /Tareas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tareas.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // GET: /Tareas/Create
        public ActionResult Create(Guid pId)
        {
            var tarea = new Tarea
            {
                ProyectoId = pId
            };
            return View(tarea);
        }

        // POST: /Tareas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Descripcion,ProyectoId,Activa")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                tarea.Id = Guid.NewGuid();
                tarea.Activa = true;
                db.Tareas.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index", new { pId = tarea.ProyectoId });
            }

            return View(tarea);
        }

        // GET: /Tareas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tareas.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: /Tareas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Descripcion,ProyectoId,Activa")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { pId = tarea.ProyectoId });
            }
            return View(tarea);
        }

        // GET: /Tareas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tareas.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: /Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tarea tarea = db.Tareas.Find(id);
            db.Tareas.Remove(tarea);
            db.SaveChanges();
            return RedirectToAction("Index", new { pId = tarea.ProyectoId });
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
