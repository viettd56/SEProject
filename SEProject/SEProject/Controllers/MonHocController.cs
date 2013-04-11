using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEProject.Models;

namespace SEProject.Controllers
{
    public class MonHocController : Controller
    {
        private MonHocDBContext db = new MonHocDBContext();

        //
        // GET: /MonHoc/

        public ActionResult Index()
        {
            return View(db.monHocs.ToList());
        }

        //
        // GET: /MonHoc/Details/5

        public ActionResult Details(int id = 0)
        {
            MonHoc monhoc = db.monHocs.Find(id);
            if (monhoc == null)
            {
                return HttpNotFound();
            }
            return View(monhoc);
        }

        //
        // GET: /MonHoc/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MonHoc/Create

        [HttpPost]
        public ActionResult Create(MonHoc monhoc)
        {
            if (ModelState.IsValid)
            {
                db.monHocs.Add(monhoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monhoc);
        }

        //
        // GET: /MonHoc/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MonHoc monhoc = db.monHocs.Find(id);
            if (monhoc == null)
            {
                return HttpNotFound();
            }
            return View(monhoc);
        }

        //
        // POST: /MonHoc/Edit/5

        [HttpPost]
        public ActionResult Edit(MonHoc monhoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monhoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monhoc);
        }

        //
        // GET: /MonHoc/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MonHoc monhoc = db.monHocs.Find(id);
            if (monhoc == null)
            {
                return HttpNotFound();
            }
            return View(monhoc);
        }

        //
        // POST: /MonHoc/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MonHoc monhoc = db.monHocs.Find(id);
            db.monHocs.Remove(monhoc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult SearchMonHoc(string searchmh) 
        {           
            var monhocs = from m in db.monHocs 
                        select m; 
 
            if (!String.IsNullOrEmpty(searchmh)) 
            { 
                monhocs = monhocs.Where(s => s.tenMonHoc.Contains(searchmh)); 
            } 
 
            return View(monhocs);
        }
    }
}