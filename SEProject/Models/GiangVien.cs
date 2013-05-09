using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SEProject.Models
{
    public class GiangVien
    {
        public int Id { get; set; }
        public string hoTen { get; set; }
        public string chucDanh { get; set; }
        public string chuyenNganh { get; set; }
        public string donVi { get; set; }

        public GiangVien()
        {

        }

        public GiangVien(int id, string hoten, string chucdanh, string chuyennganh, string donvi)
        {
            Id = id;
            hoTen = hoten;
            chucDanh = chucdanh;
            chuyenNganh = chuyennganh;
            donVi = donvi;
        }

    }

    


    public class GiangVienDBContext : DbContext
    {
        public DbSet<GiangVien> giangViens { get; set; }
    }
}