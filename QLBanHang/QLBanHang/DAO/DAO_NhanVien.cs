using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.DAO
{
    
    class DAO_NhanVien
    {
        QLBanHangEntities12 db;

        public DAO_NhanVien()
        {
            db = new QLBanHangEntities12();
        }

        public dynamic LayDSNhanVien()
        {
            var ds = db.NHANVIENs.Select(n => new
            {
                n.MA_NV,
                n.TEN_NV,
                n.EMAIL_NV,
                n.SDT_NV,
                n.NAMSINH,
                n.CCCD_NV,
                n.DIACHI_NV,
                n.GHICHU_NV
            }).ToList();
            return ds;
        }

        public bool KiemTraNV(NHANVIEN d)
        {
            NHANVIEN n = db.NHANVIENs.Find(d.MA_NV);
            if (d != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void ThemNhanVien(NHANVIEN d)
        {
            db.NHANVIENs.Add(d);
            db.SaveChanges();
        }

        public void SuaNV(NHANVIEN d)
        {
            NHANVIEN n = db.NHANVIENs.Find(d.MA_NV);
            n.MA_NV = d.MA_NV;
            n.TEN_NV = d.TEN_NV;
            n.CCCD_NV = d.CCCD_NV;
            n.DIACHI_NV = d.DIACHI_NV;
            n.NAMSINH = d.NAMSINH;
            n.GHICHU_NV = d.GHICHU_NV;
            n.EMAIL_NV = d.EMAIL_NV;
            n.SDT_NV = d.SDT_NV;
            db.SaveChanges();
        }

        public void XoaNV(NHANVIEN d)
        {
            NHANVIEN n = db.NHANVIENs.Find(d.MA_NV);
            db.NHANVIENs.Remove(n);
            db.SaveChanges();
        }

        public dynamic TimNV(String tenNV)
        {
            var ds = db.NHANVIENs.Select(n => new
            {
                n.MA_NV,
                n.TEN_NV,
                n.EMAIL_NV,
                n.SDT_NV,
                n.NAMSINH,
                n.CCCD_NV,
                n.DIACHI_NV,
                n.GHICHU_NV
            }).Where(b => b.TEN_NV.Contains(tenNV)).ToList();
            return ds;
        }

        public dynamic LayDSNhanVien1()
        {
            var ds = db.NHANVIENs.Select(s => new
            {
                s.MA_NV,
                s.TEN_NV
            }).ToList();
            return ds;
        }


        public dynamic LayDSNVReport()
        {
            var s = db.spDSNV().ToList();
            return s;
        }


        public dynamic LayNVReport(int n)
        {
            var s = db.spTungNhanVien(n).ToList();
            return s;
        }

    }

}
