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
    public class MetaController : Controller
    {
        private ProyectoTerminalContext db = new ProyectoTerminalContext();

        // GET: /Meta/
        public ActionResult Index(Guid pId)
        {
            var metas = db.Metas.Where(n => n.ProyectoId == pId);
            return View(metas.ToList());
        }

        // GET: /Meta/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meta meta = db.Metas.Find(id);
            if (meta == null)
            {
                return HttpNotFound();
            }
            return View(meta);
        }

        // GET: /Meta/Create
        public ActionResult Create(Guid pId)
        {
            var meta = new Meta
            {
                ProyectoId = pId,
                FechaCompletacionPlaneada = DateTime.Now

            };
            return View(meta);
        }

        // POST: /Meta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FechaCompletacionPlaneada,Nombre,FechaCompletacionActual,Completada,ProyectoId")] Meta meta)
        {
            if (ModelState.IsValid)
            {
                meta.Id = Guid.NewGuid();
                db.Metas.Add(meta);
                db.SaveChanges();
                return RedirectToAction("Index", new { pId = meta.ProyectoId });
            }

            return View(meta);
        }

        // GET: /Meta/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meta meta = db.Metas.Find(id);
            if (meta == null)
            {
                return HttpNotFound();
            }
            return View(meta);
        }

        // POST: /Meta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FechaCompletacionPlaneada,Nombre,FechaCompletacionActual,Completada,ProyectoId")] Meta meta)
        {
            if (ModelState.IsValid)
            {
                
                if (meta.FechaCompletacionActual != null)
                {
                    meta.Completada = true;
                }

                db.Entry(meta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { pId = meta.ProyectoId });
            }
            return View(meta);
        }

        // GET: /Meta/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meta meta = db.Metas.Find(id);
            if (meta == null)
            {
                return HttpNotFound();
            }
            return View(meta);
        }

        // POST: /Meta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Meta meta = db.Metas.Find(id);
            db.Metas.Remove(meta);
            db.SaveChanges();
            return RedirectToAction("Index", new { pId = meta.ProyectoId });
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