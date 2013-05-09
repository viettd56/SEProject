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
    public class DaoTaoController : Controller
    {
        private DaoTaoDBContext db = new DaoTaoDBContext();
        private MonHocDBContext dbMH = new MonHocDBContext();
        private GiangVienDBContext dbGV = new GiangVienDBContext();

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
            var dsMonHoc = new List<string>();

            var monHocQry = from dM in dbMH.monHocs
                            orderby dM.tenMonHoc
                            select dM.tenMonHoc;
            dsMonHoc.AddRange(monHocQry.Distinct());
            ViewBag.listMonHoc = new SelectList(dsMonHoc);

            var dsGiangVien = new List<string>();

            var giangVienQry = from dG in dbGV.giangViens
                               orderby dG.hoTen
                               select dG.hoTen;
            dsGiangVien.AddRange(giangVienQry.Distinct());
            ViewBag.listGiangVien = new SelectList(dsGiangVien);

            var dsNganhHoc = new List<string>();

            dsNganhHoc.Add("Công nghệ thông tin");
            dsNganhHoc.Add("Khoa học máy tính");
            dsNganhHoc.Add("Hệ thống thông tin");
            dsNganhHoc.Add("Mạng máy tính");
            
            ViewBag.listNganhHoc = new SelectList(dsNganhHoc);

            return View();
        }

        //
        // POST: /DaoTao/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string tenMonHoc, string tenGiangVien, int khoaHoc, string nganhHoc)
        {
            var daotao = new DaoTao(tenMonHoc, tenGiangVien, khoaHoc, nganhHoc);
            if (ModelState.IsValid)
            {
                db.daoTaos.Add(daotao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(daotao);
        }

        public ActionResult _Create(DaoTao dT)
        {
            if (ModelState.IsValid)
            {
                db.daoTaos.Add(dT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dT);
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

        public ActionResult SearchDaoTao(string nganh, int? khoa)
        {
            var dsnganh = new List<string>();
            var nganhQry = from d in db.daoTaos
                           orderby d.nganhHoc
                           select d.nganhHoc;
            dsnganh.AddRange(nganhQry.Distinct());
            ViewBag.listchuyenNganh = new SelectList(dsnganh);
            
            var dskhoa = new List<int>();
            var khoaQry = from d in db.daoTaos
                          orderby d.khoaHoc
                          select d.khoaHoc;
            dskhoa.AddRange(khoaQry.Distinct());
            ViewBag.listkhoaHoc = new SelectList(dskhoa);
            
            var monhocs = from m in db.daoTaos
                             select m;

            if (!String.IsNullOrEmpty(nganh))
                return View(monhocs.Where(x => x.nganhHoc == nganh));
            if (khoa != null)
                return View(monhocs.Where(x => x.khoaHoc == khoa));
            else
            {
                return View();
            }
        }
    }
}