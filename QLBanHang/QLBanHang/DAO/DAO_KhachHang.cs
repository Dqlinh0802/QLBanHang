using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.DAO
{
    class DAO_KhachHang
    {
        QLBanHangEntities12 db;

        public DAO_KhachHang()
        {
            db = new QLBanHangEntities12();
        }
        public dynamic LayDSKhachHang()
        {
            var ds = db.KHACHHANGs.Select(s => new
            {
                s.MA_KH,
                s.TEN_KH,
                s.EMAIL_KH,
                s.SDT_KH
            }).ToList();
            return ds;
        }

        public dynamic layKHReport()
        {
            var ds = db.spKH().ToList();
            return ds;
        }
        public dynamic LayDSKhachHang1()
        {
            var ds = db.KHACHHANGs.Select(s => new
            {
                s.MA_KH,
                s.TEN_KH
            }).ToList();
            return ds;
        }
        public void ThemTTKhachHang(KHACHHANG kh)
        {
            db.KHACHHANGs.Add(kh);
            db.SaveChanges();
        }
        public bool KiemTraTTKhachHang(KHACHHANG kh)
        {
            KHACHHANG k = db.KHACHHANGs.Find(kh.MA_KH);
            if (k != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SuaTTKhachHang(KHACHHANG kh)
        {
            KHACHHANG k = db.KHACHHANGs.Find(kh.MA_KH);
            //k.MA_KH = kh.MA_KH;
            k.TEN_KH = kh.TEN_KH;
            k.EMAIL_KH = kh.EMAIL_KH;
            k.SDT_KH = kh.SDT_KH;
            db.SaveChanges();
        }
        public void XoaTTKhachHang(KHACHHANG kh)
        {
            KHACHHANG k = db.KHACHHANGs.Find(kh.MA_KH);
            db.KHACHHANGs.Remove(k);
            db.SaveChanges();
        }
    }
}
