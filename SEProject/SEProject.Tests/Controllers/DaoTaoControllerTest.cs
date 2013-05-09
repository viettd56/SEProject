using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEProject.Models;
using SEProject.Controllers;
using System.Web.Mvc;
using Assert = NUnit.Framework.Assert;

namespace SEProject.Tests.Controllers
{
    [TestClass]
    public class DaoTaoControllerTest
    {
        int id = 100;
        string nameMonHoc = "MonHoc";
        string nameGiangVien = "GiangVien";
        int khoa = 2013;
        string nganh = "CNTT";

        [TestMethod]
        public void TestCreateDaoTao()
        {
            DaoTao dt = new DaoTao(nameMonHoc, nameGiangVien, khoa, nganh);
            dt.ID = id;
            var daoTaoControl = new DaoTaoController();
            var result = daoTaoControl._Create(dt) as RedirectToRouteResult;

            Assert.NotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            daoTaoControl.Delete(id);
        }

        [TestMethod]
        public void TestDeleteDaoTao()
        {
            DaoTao dt = new DaoTao(nameMonHoc, nameGiangVien, khoa, nganh);
            dt.ID = id;
            var daoTaoControl = new DaoTaoController();
            daoTaoControl._Create(dt);

            var result2 = daoTaoControl.Delete(dt.ID) as ViewResult;
            var dTao = (DaoTao)result2.ViewData.Model;

            Assert.NotNull(result2);
            Assert.AreEqual(nameMonHoc, dTao.tenMonHoc);
        }

        [TestMethod]
        public void TestDetailDaoTao()
        {
            DaoTao dt = new DaoTao(nameMonHoc, nameGiangVien, khoa, nganh);
            dt.ID = id;
            var daoTaoControl = new DaoTaoController();
            daoTaoControl._Create(dt);
            var result = daoTaoControl.Details(dt.ID) as ViewResult;
            var dTao = (DaoTao)result.ViewData.Model;

            Assert.AreEqual(nameMonHoc, dTao.tenMonHoc);

            daoTaoControl.Delete(id);
        }

        [TestMethod]
        public void TestEditDaoTao()
        {
            DaoTao dt = new DaoTao(nameMonHoc, nameGiangVien, khoa, nganh);
            dt.ID = id;
            var daoTaoControl = new DaoTaoController();
            daoTaoControl._Create(dt);
            var result = daoTaoControl.Edit(dt.ID) as ViewResult;
            var dTao = (DaoTao)result.ViewData.Model;

            Assert.AreEqual(nameMonHoc, dTao.tenMonHoc);

            daoTaoControl.Delete(id);
        }

        [TestMethod]
        public void TestSearchDaoTao()
        {
            DaoTao dt = new DaoTao(nameMonHoc, nameGiangVien, khoa, nganh);
            dt.ID = id;
            var daoTaoControl = new DaoTaoController();
            daoTaoControl._Create(dt);

            var result = daoTaoControl.SearchDaoTao(nganh, khoa.ToString()) as ViewResult;
            Assert.NotNull(result);
            daoTaoControl.Delete(id);
        }
    }
}
