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
    class BUS_SanPham
    {
        DAO_SanPham dSanPham;
        public BUS_SanPham()
        {
            dSanPham = new DAO_SanPham();
        }
        public void LayDSSanPham(DataGridView dg)
        {
            dg.DataSource = dSanPham.LayDSSanPham();
        }

        public dynamic laySP()
        {
            return dSanPham.laySPReport();
        }

        public void LayDSNhomHH(DataGridView dg)
        {
            dg.DataSource = dSanPham.LayDSMaNhomSP();
        }

        public void LayDSMaNhomSP(ComboBox cb)
        {
            cb.DataSource = dSanPham.LayDSMaNhomSP();
            cb.DisplayMember = "TENNHOM_HH";
            cb.ValueMember = "MANHOM_HH";
        }
        public void HienThiDSSP(DataGridView dg)
        {
            dg.DataSource = dSanPham.LayDSSanPham();

        }
        public void LayDSSanPham(ComboBox cb)
        {
            cb.DataSource = dSanPham.LayDSSanPham();
            cb.DisplayMember = "TEN_HH";
            cb.ValueMember = "MA_HH";
        }

        public HANGHOA LayThongTinSP(int maSP)
        {
            return dSanPham.LayThongTinSP(maSP);
        }

        public bool ThemNhomHangHoa(NHOMHH d)
        {
            try
            {
                dSanPham.ThemNhomHangHoa(d);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool SuaNhomHH(NHOMHH p)
        {
            if (dSanPham.KTNhomHH(p))
            {
                try
                {
                    dSanPham.SuaNhomHH(p);
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

        public bool XoaNhomHangHoa(NHOMHH p)
        {
            if (dSanPham.KTNhomHH(p))
            {
                try
                {
                    dSanPham.XoaNhomHH(p);
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


        public bool ThemSanPham(HANGHOA d)
        {
            try
            {
                dSanPham.ThemSanPham(d);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool XoaSanPham(HANGHOA p)
        {
            if (dSanPham.KTSanPham(p))
            {
                try
                {
                    dSanPham.XoaSanPham(p);
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

        public bool SuaSanPham(HANGHOA p)
        {
            if (dSanPham.KTSanPham(p))
            {
                try
                {
                    dSanPham.SuaSanPham(p);
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

