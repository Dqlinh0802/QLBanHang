using QLBanHang.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang.BUS
{


    class BUS_KhachHang
    {
        DAO_KhachHang dKhachHang;

        public BUS_KhachHang()
        {
            dKhachHang = new DAO_KhachHang();
        }
        public void HienThiKhachHang(DataGridView dg)
        {
            dg.DataSource = dKhachHang.LayDSKhachHang();
        }

        public dynamic layKH()
        {
            return dKhachHang.layKHReport();
        }

        public bool ThemTTKH(KHACHHANG kh)
        {
            try
            {
                dKhachHang.ThemTTKhachHang(kh);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SuaTTKH(KHACHHANG kh)
        {
            if (dKhachHang.KiemTraTTKhachHang(kh))
            {
                try
                {
                    dKhachHang.SuaTTKhachHang(kh);
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
        public void LayDSKhachHang(ComboBox cb)
        {
            cb.DataSource = dKhachHang.LayDSKhachHang1();
            cb.DisplayMember = "TEN_KH";
            cb.ValueMember = "MA_KH";
        }
        public bool XoaTTKH(KHACHHANG kh)
        {
            if (dKhachHang.KiemTraTTKhachHang(kh))
            {
                try
                {
                    dKhachHang.XoaTTKhachHang(kh);
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
