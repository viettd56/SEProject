using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using SEProject.Controllers;
using SEProject.Models;
using System.Web.Mvc;

namespace SEProject.Tests.Controllers
{
    [TestClass]
    public class MonHocControllerTest
    {
        int id = 100;
        string maMH = "INT123";
        string tenMH = "Mon hoc 1";
        int soTC = 0;
        int soGLT = 0;
        int soGTH = 0;
        int soGT = 0;


        [TestMethod]
        public void TestCreateMonHoc()
        {
            //Test chuc nang them mon hoc vao database
           
            var monHoc = new MonHoc(id, maMH, tenMH, soTC, soGLT, soGTH, soGT, "");
            

            var _monHocController = new MonHocController();
            var result = _monHocController.Create(monHoc) as RedirectToRouteResult;
            //Them mon hoc vao database
            Assert.NotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            _monHocController.Delete(monHoc.Id);
            //Xoa mon hoc da them

            }

        [TestMethod]

        public void TestDeleteMonHoc()
        {
            //Test chuc nang xoa Mon hoc khoi database

            var _monHocController = new MonHocController();
            var monHoc = new MonHoc(id, maMH, tenMH, soTC, soGLT, soGTH, soGT, "");
            _monHocController.Create(monHoc);

            var result = _monHocController.Delete(monHoc.Id) as ViewResult;
            var mH = (MonHoc)result.ViewData.Model;
            Assert.AreEqual("Mon hoc 1", mH.tenMonHoc);
        }

        [TestMethod]
        public void TestDetailMonHoc()
        {
            var _monHocController = new MonHocController();
            var monHoc = new MonHoc(id, maMH, tenMH, soTC, soGLT, soGTH, soGT, "");
            _monHocController.Create(monHoc);
            var result = _monHocController.Details(monHoc.Id) as ViewResult;
            var mH = (MonHoc)result.ViewData.Model;
            Assert.AreEqual("Mon hoc 1", mH.tenMonHoc);
            _monHocController.Delete(monHoc.Id);
        }

        [TestMethod]
        public void TestEditMonHoc()
        {
            var _monHocController = new MonHocController();
            var monHoc = new MonHoc(id, maMH, tenMH, soTC, soGLT, soGTH, soGT, "");
            _monHocController.Create(monHoc);
            var result = _monHocController.Edit(monHoc.Id) as ViewResult;
            var mH = (MonHoc)result.ViewData.Model;
            Assert.AreEqual("Mon hoc 1", mH.tenMonHoc);
            _monHocController.Delete(monHoc.Id);
        }

        [TestMethod]
        public void TestSearchMonHoc()
        {
            var _monHocController = new MonHocController();
            var monHoc = new MonHoc(id, maMH, tenMH, soTC, soGLT, soGTH, soGT, "");
            _monHocController.Create(monHoc);

            var result = _monHocController.SearchMonHoc(monHoc.tenMonHoc) as ViewResult;
            Assert.NotNull(result);
            _monHocController.Delete(monHoc.Id);
        }
    }
}
