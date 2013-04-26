using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEProject.Models;
using SEProject.Controllers;
using System.Web.Mvc;
using Assert = NUnit.Framework.Assert;

namespace SEProject.Tests.Controllers
{
    [TestClass]
    public class DaoTaoControlerTest
    {
        int ID = 10;
        string tenGiangVien = "test";
        string tenMonHoc = "test";

        [TestMethod]
        public void TestCreatDaoTao()
        {
            var daoTao = new DaoTao(tenMonHoc, tenGiangVien);
            var _daoTaoControler = new DaoTaoController();
            var result = _daoTaoControler.Create(tenMonHoc, tenGiangVien) as RedirectToRouteResult;
            //Them
            Assert.NotNull(result);
            Assert.AreEqual("Index",result.RouteValues["action"]);

            _daoTaoControler.Delete(daoTao.ID);
            //Xoa
        }
    }
}
