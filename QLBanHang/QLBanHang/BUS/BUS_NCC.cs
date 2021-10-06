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
    class BUS_NCC
    {
        DAO_NCC dN;

        public BUS_NCC()
        {
            dN = new DAO_NCC();
        }

        public dynamic layNCC()
        {
            return dN.layNCCReport();
        }

        public void hThiDSDH(DataGridView dg)
        {
            dg.DataSource = dN.layDSNCC();
        }

        public bool themNCC(NHACUNGCAP n)
        {
            try
            {
                dN.themNCC(n);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }



        public bool suaNCC(NHACUNGCAP n)
        {
            if (dN.checkNCC(n))
            {
                try
                {
                    dN.suaNCC(n);
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
        public bool xoaNCC(NHACUNGCAP n)
        {
            if (dN.checkNCC(n))
            {
                try
                {
                    dN.xoaNCC(n);
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
