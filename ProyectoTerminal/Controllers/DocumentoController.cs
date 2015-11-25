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
    public class DocumentoController : Controller
    {
        private ProyectoTerminalContext db = new ProyectoTerminalContext();

        // GET: /Documento/
        public ActionResult Index()
        {
            return View(db.Documentoes.ToList());
        }

        // GET: /Documento/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documentoes.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // GET: /Documento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Documento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Texto,FechaCreacion,FechaModificacion")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                documento.Id = Guid.NewGuid();
                db.Documentoes.Add(documento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(documento);
        }

        // GET: /Documento/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documentoes.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // POST: /Documento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Texto,FechaCreacion,FechaModificacion")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documento);
        }

        // GET: /Documento/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documentoes.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // POST: /Documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Documento documento = db.Documentoes.Find(id);
            db.Documentoes.Remove(documento);
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
