using QLBanHang.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;
using System.Data;

namespace QLBanHang.BUS
{
    class BUS_DonHang
    {
        DAO_DonHang dDonHang;
        public BUS_DonHang()
        {
            dDonHang = new DAO_DonHang();
        }

        public void LayDSDonHang(DataGridView dg)
        {
            dg.DataSource = dDonHang.LayDSDonHang();
        }

        public dynamic layDH(int n)
        {
            return dDonHang.layDHReport(n);
        }

        public bool TaoDonHang(HOADON hd)
        {
            try
            {
                if (dDonHang.KiemTraDHTonTai(hd))
                {
                    dDonHang.ThemDonHang(hd);
                    return true;
                }
                else
                {
                    throw new Exception("Đơn hàng đã tồn tại " + hd.MAHOADON);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool XoaDonHang(HOADON hd)
        {
            if (dDonHang.KTDonHang(hd))
            {
                try
                {
                    dDonHang.XoaDonHang(hd);
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

        public void KTTonKho(HANGHOA sp)
        {
            
                if(!dDonHang.KTTonKho(sp))
                {
                    MessageBox.Show("Tồn kho của sản phẩm thấp: " + sp.SOLUONG_HH);
                }    
           
            
        }

        public bool XoaCTDonHang(int maHD, int maHH, CHITIETHOADON hd)
        {
            if (dDonHang.KTCTDonHang(hd))
            {
                try
                {
                    int sl = (int)hd.SOLUONGHANGBAN;
                    hd.MA_HH = maHH;
                    hd.MAHOADON = maHD;
                    dDonHang.XoaCTDonHang(hd);
                    dDonHang.CapNhatTonKhoXoa(sl,hd);
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

        public bool SuaDonHang(HOADON d)
        {
            if (dDonHang.KTDonHang(d))
            {
                try
                {
                    dDonHang.SuaDonHang(d);
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

        public bool SuaCTDonHang(int sl, CHITIETHOADON d)
        {
            if (dDonHang.KTCTDonHang(d))
            {
                try
                {
                    if (sl < d.SOLUONGHANGBAN)
                    {
                        sl = (int)d.SOLUONGHANGBAN - sl;
                        dDonHang.SuaCTDonHang(d);
                        dDonHang.CapNhatTonKhoBan(sl,d);
                        return true;
                    }
                    else if(sl > d.SOLUONGHANGBAN)
                    {
                        sl = sl - (int)d.SOLUONGHANGBAN ;
                        dDonHang.SuaCTDonHang(d);
                        dDonHang.CapNhatTonKhoXoa(sl,d);
                        return true;
                    }
                    else
                    {
                        dDonHang.SuaCTDonHang(d);
                        return true;
                    }
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

        public void LayDSCTDonHang(DataGridView dg, int maDH)
        {
            dg.DataSource = dDonHang.LayDSCTDH(maDH);
        }


        public bool TaoCTDonHang(int maHD, CHITIETHOADON hd)
        {
            try
            {
                int sl = (int)hd.SOLUONGHANGBAN;
                hd.MAHOADON = maHD;
                if (dDonHang.KiemTraCTDHTonTai(hd))
                {
                    dDonHang.ThemCTDonHang(hd);
                    dDonHang.CapNhatTonKhoBan(sl, hd);
                    return true;
                }
                else
                {
                    throw new Exception("Sản phẩm đã tồn tại " + hd.MA_HH);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        

    }

}
