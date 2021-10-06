using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanHang.DAO;
namespace QLBanHang.BUS
{
    class BUS_NhapHang
    {
        DAO_NhapHang dNhapHang;
        public BUS_NhapHang()
        {
            dNhapHang = new DAO_NhapHang();
        }

        public dynamic layNH(int n)
        {
            return dNhapHang.layNHReport(n);
        }
        public void LayDSPhieuNhap(DataGridView dg)
        {
            dg.DataSource = dNhapHang.LayDSPhieuNhap();
        }
        public void LayDSNV(ComboBox cb)
        {
            cb.DataSource = dNhapHang.LayDSNV();
            cb.DisplayMember = "TEN_NV";
            cb.ValueMember = "MA_NV";
        }
        public void LayDSNCC(ComboBox cb)
        {
            cb.DataSource = dNhapHang.LayDSNCC();
            cb.DisplayMember = "TEN_NCC";
            cb.ValueMember = "MA_NCC";
        }

        public void HienThiDSCTPN(DataGridView dg, int maPN)
        {
            dg.DataSource = dNhapHang.LayDSCTPN(maPN);
        }

        public void HienThiDSPhieuNhap(DataGridView dg)
        {
            dg.DataSource = dNhapHang.LayDSPhieuNhap();

        }
        public bool ThemCTPN(int ma, CT_NHAPHANG d)
        {
            try
            {
                d.MANHAPHANG = ma;
                dNhapHang.ThemCTPhieuNhap(d);
                dNhapHang.CapNhatTonKhoThem(d);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        

        public bool XoaCTPhieuNhap(int maPN, int maHH, CT_NHAPHANG d)
        {
            if (dNhapHang.KTCTPhieuNhap(d))
            {
                try
                {                    
                    d.MA_HH = maHH;
                    d.MANHAPHANG = maPN;
                    dNhapHang.XoaCTPhieuNhap(d);
                    dNhapHang.CapNhatTonKhoXoa(d);
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public bool ThemPhieuNhap(HOADONNHAP d)
        {
            try
            {
                dNhapHang.ThemPhieuNhap(d);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
      
        public bool SuaPhieuNhap(HOADONNHAP p)
        {
            if (dNhapHang.KTPhieuNhap(p))
            {
                try
                {
                    dNhapHang.SuaPhieuNhap(p);
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public bool XoaPhieuNhap(HOADONNHAP p)
        {
            if (dNhapHang.KTPhieuNhap(p))
            {
                try
                {
                    dNhapHang.XoaPhieuNhap(p);
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
