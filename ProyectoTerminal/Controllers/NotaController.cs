﻿using System;
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
    public class NotaController : Controller
    {
        private ProyectoTerminalContext db = new ProyectoTerminalContext();

        // GET: /Nota/
        public ActionResult Index(Guid pId)
        {
            var notas = db.Notas.Where(n => n.ProyectoId == pId);

            return View(notas.ToList());
        }

        // GET: /Nota/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // GET: /Nota/Create
        public ActionResult Create(Guid pId)
        {
            var nota = new Nota
            {
                ProyectoId = pId
            };
            return View(nota);
        }

        // POST: /Nota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Texto,Fecha,ProyectoId")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                nota.Id = Guid.NewGuid();
                nota.Fecha = DateTime.Now;
                db.Notas.Add(nota);
                db.SaveChanges();
                return RedirectToAction("Index", new { pId = nota.ProyectoId });
            }

            return View(nota);
        }

        // GET: /Nota/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // POST: /Nota/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Texto,Fecha,ProyectoId")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { pId = nota.ProyectoId });
            }
            return View(nota);
        }

        // GET: /Nota/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // POST: /Nota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Nota nota = db.Notas.Find(id);
            db.Notas.Remove(nota);
            db.SaveChanges();
            return RedirectToAction("Index", new { pId = nota.ProyectoId });
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
