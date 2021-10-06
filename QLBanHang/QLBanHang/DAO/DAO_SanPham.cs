using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.DAO
{
    class DAO_SanPham
    {
        QLBanHangEntities12 db;
        public DAO_SanPham()
        {
            db = new QLBanHangEntities12();
        }


        public dynamic laySPReport()
        {
            var ds = db.spSPBC().ToList();
            return ds;
        }


        public dynamic LayDSSanPham()
        {
            var ds = db.HANGHOAs.Select(s => new
            {
                s.MA_HH,
                s.TEN_HH,
                s.SOLUONG_HH,
                s.GIAVON,
                s.NHOMHH.TENNHOM_HH


            }).ToList();
            return ds;
        }
        public dynamic LayDSMaNhomSP()
        {
            var ds = db.NHOMHHs.Select(s => new
            {
                s.MANHOM_HH,
                s.TENNHOM_HH

            }).ToList();
            return ds;
        }

        public void ThemSanPham(HANGHOA d)
        {

            db.HANGHOAs.Add(d);
            db.SaveChanges();
        }

        public void ThemNhomHangHoa(NHOMHH d)
        {

            db.NHOMHHs.Add(d);
            db.SaveChanges();
        }

        public bool KTNhomHH(NHOMHH p)
        {
            NHOMHH o = db.NHOMHHs.Find(p.MANHOM_HH);
            if (p != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SuaNhomHH(NHOMHH p)
        {

            NHOMHH o = db.NHOMHHs.Find(p.MANHOM_HH);
            o.TENNHOM_HH = p.TENNHOM_HH;

            db.SaveChanges();
        }

        public void XoaNhomHH(NHOMHH p)
        {
            NHOMHH o = db.NHOMHHs.Find(p.MANHOM_HH);
            db.NHOMHHs.Remove(o);
            db.SaveChanges();
        }


        public HANGHOA LayThongTinSP(int maSP)
        {
            HANGHOA p = db.HANGHOAs.Where(s => s.MA_HH == maSP).FirstOrDefault();

            return p;
        }



        public bool KTSanPham(HANGHOA p)
        {
            HANGHOA o = db.HANGHOAs.Find(p.MA_HH);
            if (p != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void XoaSanPham(HANGHOA p)
        {
            HANGHOA o = db.HANGHOAs.Find(p.MA_HH);
            db.HANGHOAs.Remove(o);
            db.SaveChanges();
        }

        public void SuaSanPham(HANGHOA p)
        {
            
            HANGHOA o = db.HANGHOAs.Find(p.MA_HH);

            o.MA_HH = p.MA_HH;
            o.TEN_HH = p.TEN_HH;
            o.SOLUONG_HH = p.SOLUONG_HH;
            o.GIAVON = p.GIAVON;
            o.MANHOM_HH = p.MANHOM_HH;
            db.SaveChanges();
        }

    }
}
