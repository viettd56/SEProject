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

        public DaoTao()
        {
            tenGiangVien = "";
            tenMonHoc = "";
        }

        public DaoTao(string tenMH, string tenGV)
        {
            tenMonHoc = tenMH;
            tenGiangVien = tenGV;
        }
    }



    public class DaoTaoDBContext : DbContext
    {
        public DbSet<DaoTao> daoTaos { get; set; }
    }
}