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
    class BUS_NhanVien
    {
        DAO_NhanVien dNhanVien;

        public BUS_NhanVien()
        {
            dNhanVien = new DAO_NhanVien();
        }

        public void LayDSNhanVien(DataGridView dg)
        {
            dg.DataSource = dNhanVien.LayDSNhanVien();
        }
        public void LayDSNhanVien(ComboBox cb)
        {
            cb.DataSource = dNhanVien.LayDSNhanVien1();
            cb.DisplayMember = "TEN_NV";
            cb.ValueMember = "MA_NV";
        }
        public bool TaoNhanVien(NHANVIEN d)
        {
            try
            {
                dNhanVien.ThemNhanVien(d);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public void TimNV(DataGridView dg, String tenNV)
        {
            dg.DataSource = dNhanVien.TimNV(tenNV);
        }
        public bool SuaNV(NHANVIEN d)
        {

            if (dNhanVien.KiemTraNV(d))
            {
                //Sua

                try
                {
                    dNhanVien.SuaNV(d);
                    return true;
                }
                catch (DbUpdateException ex)
                {

                    MessageBox.Show(ex.Message);
                    return false;
                }


            }
            else
                return false;
        }

        public bool XoaNV(NHANVIEN d)
        {
            if (dNhanVien.KiemTraNV(d))
            {
                //Sua

                try
                {
                    dNhanVien.XoaNV(d);
                    return true;
                }
                catch (DbUpdateException ex)
                {

                    MessageBox.Show(ex.Message);
                    return false;
                }


            }
            else
                return false;
        }


        public dynamic LayDSNV()
        {
            return dNhanVien.LayDSNVReport();
        }

        public dynamic LayNV(int n)
        {
            return dNhanVien.LayNVReport(n);
        }
    }
}
