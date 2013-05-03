﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEProject.Models;

namespace SEProject.Controllers
{
    public class DaoTaoController : Controller
    {
        private DaoTaoDBContext db = new DaoTaoDBContext();

        //
        // GET: /DaoTao/

        public ActionResult Index()
        {
            return View(db.daoTaos.ToList());
        }

        //
        // GET: /DaoTao/Details/5

        public ActionResult Details(int id = 0)
        {
            DaoTao daotao = db.daoTaos.Find(id);
            if (daotao == null)
            {
                return HttpNotFound();
            }
            return View(daotao);
        }

        //
        // GET: /DaoTao/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DaoTao/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DaoTao daotao)
        {
            if (ModelState.IsValid)
            {
                db.daoTaos.Add(daotao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(daotao);
        }

        //
        // GET: /DaoTao/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DaoTao daotao = db.daoTaos.Find(id);
            if (daotao == null)
            {
                return HttpNotFound();
            }
            return View(daotao);
        }

        //
        // POST: /DaoTao/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DaoTao daotao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(daotao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(daotao);
        }

        //
        // GET: /DaoTao/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DaoTao daotao = db.daoTaos.Find(id);
            if (daotao == null)
            {
                return HttpNotFound();
            }
            return View(daotao);
        }

        //
        // POST: /DaoTao/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DaoTao daotao = db.daoTaos.Find(id);
            db.daoTaos.Remove(daotao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}