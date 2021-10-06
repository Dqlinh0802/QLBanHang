using QLBanHang.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class FCTDH : Form
    {
        public int maHD;
        BUS_DonHang busDH;
        BUS_SanPham busSP;
        bool co = false;

        public FCTDH()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
            busSP = new BUS_SanPham();
        }
        private void LayDSCTDH(int ma)
        {
            gVCTDH.DataSource = null;
            busDH.LayDSCTDonHang(gVCTDH, ma);
            gVCTDH.Columns[0].Width = (int)(gVCTDH.Width * 0.2);
            gVCTDH.Columns[1].Width = (int)(gVCTDH.Width * 0.2);
            gVCTDH.Columns[2].Width = (int)(gVCTDH.Width * 0.2);
            gVCTDH.Columns[3].Width = (int)(gVCTDH.Width * 0.2);
            gVCTDH.Columns[4].Width = (int)(gVCTDH.Width * 0.2);

        }

        private void FCTDH_Load(object sender, EventArgs e)
        {
            busSP.LayDSSanPham(cbTenSP);
            co = true;

            LayDSCTDH(maHD);

        }

        private void FCTDH_Activated(object sender, EventArgs e)
        {
            LayDSCTDH(maHD);

            txtMaDH.Text = maHD.ToString();
            txtMaDH.ReadOnly = true;
        }

        private void cbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (co)
            {
                HANGHOA sp;
                int maSP;

                maSP = Int32.Parse(cbTenSP.SelectedValue.ToString());
                sp = busSP.LayThongTinSP(maSP);
                txtLoaiSP.Text = sp.NHOMHH.TENNHOM_HH.ToString();
                //txtNCC.Text = p.Supplier.CompanyName.ToString();
                txtDonGia.Text = sp.GIAVON.ToString();
                busDH.KTTonKho(sp);
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin cần thiết");
            }
            else
            {
                CHITIETHOADON d = new CHITIETHOADON();

                d.MA_HH = Int32.Parse(cbTenSP.SelectedValue.ToString());
                d.DONGIABAN = Decimal.Parse(txtDonGia.Text.ToString());
                d.SOLUONGHANGBAN = Int32.Parse(numSoLuong.Value.ToString());
                d.UUDAI = Double.Parse(txtGiamGia.Text.ToString());

                if (busDH.TaoCTDonHang(maHD, d))
                {
                    MessageBox.Show("Đặt hàng thành công");
                    LayDSCTDH(maHD);
                   
                }
                else
                {
                    MessageBox.Show("Đặt hàng thất bại");
                }

            }

        }

        private void gVCTDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < gVCTDH.Rows.Count)
            {
                txtMaDH.Text = maHD.ToString();
                cbTenSP.Text = gVCTDH.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtDonGia.Text = gVCTDH.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                numSoLuong.Text = gVCTDH.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txtGiamGia.Text = gVCTDH.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();

            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Mời bạn chọn thông tin cần sửa!!!");
            }
            else
            {
                int sltruoc = Int32.Parse(gVCTDH.CurrentRow.Cells[3].Value.ToString());
                CHITIETHOADON d = new CHITIETHOADON();
                d.MAHOADON = Int32.Parse(txtMaDH.Text);
                d.MA_HH = Int32.Parse(cbTenSP.SelectedValue.ToString());
                d.DONGIABAN = Decimal.Parse(txtDonGia.Text.ToString());
                d.SOLUONGHANGBAN = Int32.Parse(numSoLuong.Value.ToString());
                d.UUDAI = Double.Parse(txtGiamGia.Text.ToString());

                if (busDH.SuaCTDonHang(sltruoc,d))
                {
                    MessageBox.Show("Sửa đơn hàng thành công");
                    LayDSCTDH(maHD);
                }
                else
                {
                    MessageBox.Show("Sửa đơn hàng thất bại");
                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Mời bạn chọn thông tin cần xoá!!!");
            }
            else
            {
                int maHH;
                CHITIETHOADON d = new CHITIETHOADON();

                maHH = Int32.Parse(gVCTDH.CurrentRow.Cells[0].Value.ToString());
                d.SOLUONGHANGBAN = Int32.Parse(gVCTDH.CurrentRow.Cells[3].Value.ToString());

                if (busDH.XoaCTDonHang(maHD, maHH, d))
                {
                    MessageBox.Show("Xóa đơn hàng thành công");
                    LayDSCTDH(maHD);
                }
                else
                {
                    MessageBox.Show("Xóa đơn hàng thất bại");
                }
            }
        }

        private void cbTenSP_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
