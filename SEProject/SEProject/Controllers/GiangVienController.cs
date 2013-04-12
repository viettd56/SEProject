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
    public class GiangVienController : Controller
    {
        private GiangVienDBContext db = new GiangVienDBContext();

        //
        // GET: /GiangVien/

        public ActionResult Index()
        {
            return View(db.giangViens.ToList());
        }

        //
        // GET: /GiangVien/Details/5

        public ActionResult Details(int id = 0)
        {
            GiangVien giangvien = db.giangViens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }

        //
        // GET: /GiangVien/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GiangVien/Create

        [HttpPost]
        public ActionResult Create(GiangVien giangvien)
        {
            if (ModelState.IsValid)
            {
                db.giangViens.Add(giangvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giangvien);
        }

        //
        // GET: /GiangVien/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GiangVien giangvien = db.giangViens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }

        //
        // POST: /GiangVien/Edit/5

        [HttpPost]
        public ActionResult Edit(GiangVien giangvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giangvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giangvien);
        }

        //
        // GET: /GiangVien/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GiangVien giangvien = db.giangViens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }

        //
        // POST: /GiangVien/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GiangVien giangvien = db.giangViens.Find(id);
            db.giangViens.Remove(giangvien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult SearchGiangVien(string searchgv, string nganh)
        {
            var dsnganh = new List<string>();

            var nganhQry = from d in db.giangViens
                           orderby d.chuyenNganh
                           select d.chuyenNganh;
            dsnganh.AddRange(nganhQry.Distinct());
            ViewBag.chuyenNganh = new SelectList(dsnganh);

            var giangviens = from m in db.giangViens
                         select m;

            if (!String.IsNullOrEmpty(searchgv))
            {
                giangviens = giangviens.Where(s => s.hoTen.Contains(searchgv));
            }

            if (string.IsNullOrEmpty(nganh))
                return View(giangviens);
            else
            {
                return View(giangviens.Where(x => x.chuyenNganh == nganh));
            } 
        }
    }
}