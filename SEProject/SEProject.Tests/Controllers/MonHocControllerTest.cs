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
        int soTC = 2;
        int soGLT = 20;
        int soGTH = 15;
        int soGT = 10;


        [TestMethod]
        public void ThemMonHoc()
        {

           
            var monHoc = new MonHoc(id, maMH, tenMH, soTC, soGLT, soGTH, soGT, "");
            

            var _monHocController = new MonHocController();
            var result = _monHocController.Create(monHoc) as RedirectToRouteResult;
            Assert.NotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            }

        [TestMethod]

        public void XoaMonHoc()
        {
            int id = 10;
            var _monHocController = new MonHocController();
            var monHoc = new MonHoc(id, maMH, tenMH, soTC, soGLT, soGTH, soGT, "");
            _monHocController.Create(monHoc);
            var result = _monHocController.Delete(id) as ViewResult;
            var mH = (MonHoc)result.ViewData.Model;
            Assert.AreEqual("Mon hoc 1", mH.tenMonHoc);
        }
    }
}
