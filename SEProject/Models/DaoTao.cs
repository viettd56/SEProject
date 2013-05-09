using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SEProject.Models
{
    public class DaoTao
    {
        public int ID { get; set; }
        public string tenMonHoc { get; set; }
        public string tenGiangVien { get; set; }
        public int khoaHoc { get; set; }
        public string nganhHoc { get; set; }

        public DaoTao()
        {
            tenGiangVien = "";
            tenMonHoc = "";
            khoaHoc = 0;
            nganhHoc = "";
        }

        public DaoTao(string tenMH, string tenGV, int khoa = 0, string nganh = "")
        {
            tenMonHoc = tenMH;
            tenGiangVien = tenGV;
            khoaHoc = khoa;
            nganhHoc = nganh;
        }
    }



    public class DaoTaoDBContext : DbContext
    {
        public DbSet<DaoTao> daoTaos { get; set; }
    }
}