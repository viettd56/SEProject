using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using SEProject.Controllers;
using SEProject.Models;
using System.Web.Mvc;

namespace SEProject.Tests.Controllers
{
    [TestClass]
    public class GiangVienControllerTest
    {
        int _id = 100;
        string hoTen = "test";
        string chucDanh = "test";
        string chuyenNganh = "test";
        string donVi = "test";

        [TestMethod]
        public void TestCreateGiangVien()
        {
            //Test chuc nang them giang vien vao database
            var giangVien = new GiangVien( _id, hoTen, chucDanh, chuyenNganh, donVi);

            var _giangVienController = new GiangVienController();
            var result = _giangVienController.Create(giangVien) as RedirectToRouteResult;
            //Them giang vien vao database
            Assert.NotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            _giangVienController.Delete(giangVien.Id);
            //Xoa giang vien da them
        }

        [TestMethod]

        public void TestDeleteGiangVien()
        {
            //Test chuc nang xoa giang vien khoi database
            var giangVien = new GiangVien(_id, hoTen, chucDanh, chuyenNganh, donVi);

            var _giangVienController = new GiangVienController();
            _giangVienController.Create(giangVien);

            var result = _giangVienController.Delete(giangVien.Id) as ViewResult;
            var gV = (GiangVien)result.ViewData.Model;
            Assert.AreEqual(hoTen, gV.hoTen);
        }

        [TestMethod]
        public void TestDetailGiangVien()
        {
            var giangVien = new GiangVien(_id, hoTen, chucDanh, chuyenNganh, donVi);

            var _giangVienController = new GiangVienController();
            _giangVienController.Create(giangVien);
            var result = _giangVienController.Details(giangVien.Id) as ViewResult;
            var gV = (GiangVien)result.ViewData.Model;
            Assert.AreEqual(hoTen, gV.hoTen);
            _giangVienController.Delete(giangVien.Id);
        }

        [TestMethod]
        public void TestEditGiangVien()
        {
            var giangVien = new GiangVien(_id, hoTen, chucDanh, chuyenNganh, donVi);

            var _giangVienController = new GiangVienController();
            _giangVienController.Create(giangVien);
            var result = _giangVienController.Edit(giangVien.Id) as ViewResult;
            var gV = (GiangVien)result.ViewData.Model;
            Assert.AreEqual(hoTen, gV.hoTen);
            _giangVienController.Delete(giangVien.Id);
        }

        [TestMethod]
        public void TestSearchGiangVien()
        {
            var giangVien = new GiangVien(_id, hoTen, chucDanh, chuyenNganh, donVi);

            var _giangVienController = new GiangVienController();
            _giangVienController.Create(giangVien);

            var result = _giangVienController.SearchGiangVien(giangVien.hoTen, "") as ViewResult;
            Assert.NotNull(result);
            _giangVienController.Delete(giangVien.Id);
        }
    }
}
