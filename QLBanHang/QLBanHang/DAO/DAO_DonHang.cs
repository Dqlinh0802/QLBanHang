using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.DAO
{
    class DAO_DonHang
    {
        QLBanHangEntities12 db;
        public DAO_DonHang()
        {
            db = new QLBanHangEntities12();
        }

        public dynamic layDHReport(int m)
        {
            var ds = db.spHD(m).ToList();
            return ds;
        }
        public dynamic LayDSDonHang()
        {
            var ds = db.HOADONs.Select(s => new
            {
                s.MAHOADON,
                s.NGAYLAPHOADON,
                s.NHANVIEN.TEN_NV,
                s.KHACHHANG.TEN_KH,
                s.GHICHUHD
            }).ToList();
            return ds;
        }

        public void ThemDonHang(HOADON hd)
        {
            db.HOADONs.Add(hd);
            db.SaveChanges();
        }

        public void ThemCTDonHang(CHITIETHOADON hd)
        {
            db.CHITIETHOADONs.Add(hd);
            db.SaveChanges();
        }

        public bool KTDonHang(HOADON hd)
        {
            HOADON o = db.HOADONs.Find(hd.MAHOADON);
            if (hd != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool KTCTDonHang(CHITIETHOADON hd)
        {
            CHITIETHOADON o = db.CHITIETHOADONs.Find(hd.MAHOADON, hd.MA_HH);
            if (hd != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void XoaDonHang(HOADON hd)
        {

            HOADON o = db.HOADONs.Find(hd.MAHOADON);
            db.CHITIETHOADONs.RemoveRange(db.CHITIETHOADONs.Where(c => c.MAHOADON == hd.MAHOADON));
            db.HOADONs.Remove(o);
            db.SaveChanges();
        }

        public void XoaCTDonHang(CHITIETHOADON hd)
        {
            CHITIETHOADON o = db.CHITIETHOADONs.Where(p =>
            p.MAHOADON == hd.MAHOADON && p.MA_HH == hd.MA_HH).SingleOrDefault();
            db.CHITIETHOADONs.Remove(o);
            db.SaveChanges();
        }

        public void SuaDonHang(HOADON d)
        {
            HOADON o = db.HOADONs.Find(d.MAHOADON);
            o.NGAYLAPHOADON = d.NGAYLAPHOADON;
            o.MA_KH = d.MA_KH;
            o.MA_NV = d.MA_NV;
            o.GHICHUHD = d.GHICHUHD;
            db.SaveChanges();
        }

        public void SuaCTDonHang(CHITIETHOADON d)
        {
            CHITIETHOADON o = db.CHITIETHOADONs.Find(d.MAHOADON, d.MA_HH);
            o.DONGIABAN = d.DONGIABAN;
            o.SOLUONGHANGBAN = d.SOLUONGHANGBAN;
            o.UUDAI = d.UUDAI;
            db.SaveChanges();
        }

        public dynamic LayDSCTDH(int maDH)
        {
            var ds = db.CHITIETHOADONs.Where(s => s.MAHOADON == maDH)
                .Select(s => new {
                    s.MA_HH,
                    s.HANGHOA.TEN_HH,
                    s.DONGIABAN,
                    s.SOLUONGHANGBAN,
                    s.UUDAI
                }).ToList();
            return ds;
        }

        //abc
        public bool KiemTraDHTonTai(HOADON hd)
        {
            int? sl;
            sl = db.dh_KiemTraDonHang(hd.MAHOADON).FirstOrDefault();
            if (sl != 0)
                return false;
            else
                return true;
        }

        public bool KiemTraCTDHTonTai(CHITIETHOADON hd)
        {
            int? sl;
            sl = db.dh_KiemTraCTDonHang(hd.MAHOADON, hd.MA_HH).FirstOrDefault();
            if (sl != 0)
                return false;
            else
                return true;
        }

        public void CapNhatTonKhoBan(int sl,CHITIETHOADON hd)
        {
            db.dh_CapNhatTonKho(hd.MA_HH, sl);
            db.SaveChanges();
        }

        public void CapNhatTonKhoXoa(int sl, CHITIETHOADON hd)
        {
            db.dh_CapNhatTonKhoXoa(hd.MA_HH, sl);
            db.SaveChanges();
        }

        public bool KTTonKho(HANGHOA sp)
        {
            if(sp.SOLUONG_HH <= 0)
            {
                return false;
            }    
            else
            {
                return true;
            }    
        }
    }
}
