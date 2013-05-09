using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SEProject.Models
{
    public class MonHoc
    {
        public int Id {get; set;}
        public string maMonHoc { get; set; }
        public string tenMonHoc {get; set;}
        public int soTinChi { get; set; }
        public int gioLyThuyet { get; set; }
        public int gioThucHanh { get; set; }
        public int gioTuHoc { get; set; }
        public string maMonKienQuyet { get; set; }

        public MonHoc()
        {

        }

        public MonHoc(int id, string maMH, string tenMH, int soTC, int gioLT, int gioTHanh, int gioTHoc, string maMKQ)
        {
            Id = id;
            maMonHoc = maMH;
            tenMonHoc = tenMH;
            soTinChi = soTC;
            gioLyThuyet = gioLT;
            gioThucHanh = gioTHanh;
            gioTuHoc = gioTHoc;
            maMonKienQuyet = maMKQ;
        }
    }

    public class MonHocDBContext : DbContext
    {
        public DbSet<MonHoc> monHocs { get; set; }
    }
}