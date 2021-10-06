using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.DAO
{
    class DAO_NhapHang
    {
        QLBanHangEntities12 db;
        public DAO_NhapHang()
        {
            db = new QLBanHangEntities12();
        }

        public dynamic layNHReport(int n)
        {
            var ds = db.spHDN(n).ToList();
            return ds;
        }


        public dynamic LayDSPhieuNhap()
        {
            var ds = db.HOADONNHAPs.Select(s => new
            {
                s.MANHAPHANG,
                s.GHICHUNHAPHANG,
                s.NGAYNHAPHANG,
                s.NHANVIEN.TEN_NV,
                s.NHACUNGCAP.TEN_NCC


            }).ToList();
            return ds;
        }

        public dynamic LayDSCTPN(int maPN)
        {
            var ds = db.CT_NHAPHANG.Where(s => s.MANHAPHANG == maPN)
                .Select(s => new
            {
                    s.MA_HH,
                    s.HANGHOA.TEN_HH,
                s.DONGIANHAP,
                s.SOLUONGHANGNHAP


            }).ToList();
            return ds;
        }
    public void ThemCTPhieuNhap(CT_NHAPHANG d)
        {

            db.CT_NHAPHANG.Add(d);
            db.SaveChanges();
        }
        public void ThemPhieuNhap(HOADONNHAP d)
        {

            db.HOADONNHAPs.Add(d);
            db.SaveChanges();
        }

        public void CapNhatTonKhoXoa( CT_NHAPHANG c)
        {
            db.dh_CapNhatTonKho(c.MA_HH, c.SOLUONGHANGNHAP);
            db.SaveChanges();
        }

        public void CapNhatTonKhoThem( CT_NHAPHANG c)
        {
            db.dh_CapNhatTonKhoXoa(c.MA_HH, c.SOLUONGHANGNHAP);
            db.SaveChanges();
        }
        public void XoaCTPhieuNhap(CT_NHAPHANG d)
        {
            CT_NHAPHANG o = db.CT_NHAPHANG.Where(p =>
            p.MANHAPHANG == d.MANHAPHANG && p.MA_HH == d.MA_HH).SingleOrDefault();
            db.CT_NHAPHANG.Remove(o);
            db.SaveChanges();
        }
        public void SuaCTPhieuNhap(CT_NHAPHANG d)
        {
            CT_NHAPHANG o = db.CT_NHAPHANG.Find(d.MANHAPHANG, d.MA_HH);
            o.DONGIANHAP = d.DONGIANHAP;
            o.SOLUONGHANGNHAP = d.SOLUONGHANGNHAP;
            db.SaveChanges();
        }


        public bool KTCTPhieuNhap(CT_NHAPHANG d)
        {
            CT_NHAPHANG o = db.CT_NHAPHANG.Find(d.MANHAPHANG, d.MA_HH);
            if (d != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public dynamic LayDSNV()
        {
            var ds = db.NHANVIENs.Select(s => new
            {
                s.MA_NV,
                s.TEN_NV

            }).ToList();
            return ds;
        }
        public dynamic LayDSNCC()
        {
            var ds = db.NHACUNGCAPs.Select(s => new
            {
                s.MA_NCC,
                s.TEN_NCC

            }).ToList();
            return ds;
        }

        public bool KTPhieuNhap(HOADONNHAP p)
        {
            HOADONNHAP o = db.HOADONNHAPs.Find(p.MANHAPHANG);
            if (p != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SuaPhieuNhap(HOADONNHAP p)
        {
            HOADONNHAP o = db.HOADONNHAPs.Find(p.MANHAPHANG);

            o.NGAYNHAPHANG = p.NGAYNHAPHANG;
            o.GHICHUNHAPHANG = p.GHICHUNHAPHANG;
            o.MA_NCC = p.MA_NCC;
            o.MA_NV = p.MA_NV;
            db.SaveChanges();
        }
        public void XoaPhieuNhap(HOADONNHAP p)
        {
            HOADONNHAP o = db.HOADONNHAPs.Find(p.MANHAPHANG);
            db.HOADONNHAPs.Remove(o);
            db.SaveChanges();
        }
    }
}
