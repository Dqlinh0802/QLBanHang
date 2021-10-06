using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.DAO
{
    class DAO_NCC
    {

        QLBanHangEntities12 db;

        public DAO_NCC()
        {
            db = new QLBanHangEntities12();
        }

        public dynamic layNCCReport()
        {
            var ds = db.spSLHNNCC().ToList();
            return ds;
        }

        public dynamic layDSNCC()
        {
            var ds = db.NHACUNGCAPs.Select(s => new
            {
                s.MA_NCC,
                s.TEN_NCC,
                s.SDT_NCC,
                s.DIACHI_NCC,
                s.EMAIL_NCC
            }).ToList();

            return ds;
        }

        public void themNCC(NHACUNGCAP n)
        {
            db.NHACUNGCAPs.Add(n);
            db.SaveChanges();
        }

        public bool checkNCC(NHACUNGCAP n)
        {
            NHACUNGCAP o = db.NHACUNGCAPs.Find(n.MA_NCC);
            if (n != null)
            {
                return true;
            }
            else
                return false;
        }

        public void suaNCC(NHACUNGCAP n)
        {
            NHACUNGCAP c = db.NHACUNGCAPs.Find(n.MA_NCC);
            c.TEN_NCC = n.TEN_NCC;
            c.SDT_NCC = n.SDT_NCC;
            c.DIACHI_NCC = n.DIACHI_NCC;
            c.EMAIL_NCC = n.EMAIL_NCC;
            db.SaveChanges();
        }

        public void xoaNCC(NHACUNGCAP n)
        {
            NHACUNGCAP c = db.NHACUNGCAPs.Find(n.MA_NCC);
            db.NHACUNGCAPs.Remove(c);
            db.SaveChanges();
        }


    }
}
