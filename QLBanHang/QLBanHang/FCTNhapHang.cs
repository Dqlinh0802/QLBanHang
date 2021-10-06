using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanHang.BUS;
namespace QLBanHang
{
    public partial class FCTNhapHang : Form
    {
        public int maNH;
        public int maDH;
        BUS_NhapHang bus;
        BUS_SanPham busSP;
        bool co = false;

        public FCTNhapHang()
        {
            InitializeComponent();
            bus = new BUS_NhapHang();
            busSP = new BUS_SanPham();
        }
        private void LayDSCTPN(int maNH)
        {
            gVCTNH.DataSource = null;
            bus.HienThiDSCTPN(gVCTNH, maNH);

            gVCTNH.Columns[0].HeaderText = "Mã sản phẩm";
            gVCTNH.Columns[1].HeaderText = "Tên sản phẩm";
            gVCTNH.Columns[2].HeaderText = "Đơn giá nhập";
            gVCTNH.Columns[3].HeaderText = "Số lượng nhập";

            gVCTNH.Columns[0].Width = (int)(gVCTNH.Width * 0.20);
            gVCTNH.Columns[1].Width = (int)(gVCTNH.Width * 0.25);
            gVCTNH.Columns[2].Width = (int)(gVCTNH.Width * 0.25);
            gVCTNH.Columns[3].Width = (int)(gVCTNH.Width * 0.25);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVCTNH.Rows.Count)
            {
                //txtMaNH.Enabled = false;
                cbHH.Text = gVCTNH.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtDonGia.Text = gVCTNH.Rows[e.RowIndex].Cells["DONGIANHAP"].Value.ToString().Trim();
                numSoLuong.Text = gVCTNH.Rows[e.RowIndex].Cells["SOLUONGHANGNHAP"].Value.ToString().Trim();

            }
        }
        private void clear()
        {
            cbHH.SelectedIndex = 0;
            txtDonGia.Text = "";
            numSoLuong.Value = 1;
        }
        private void FCTNhapHang_Load(object sender, EventArgs e)
        {
            busSP.LayDSSanPham(cbHH);
            co = true;
            LayDSCTPN(maNH);
            txtDonGia.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin cần thiết");
            }
            else
            {
                CT_NHAPHANG d = new CT_NHAPHANG();
                d.MA_HH = Int32.Parse(cbHH.SelectedValue.ToString());
                d.SOLUONGHANGNHAP = Int32.Parse(numSoLuong.Value.ToString());
                d.DONGIANHAP = Decimal.Parse(txtDonGia.Text.ToString());
                

                if (bus.ThemCTPN(maNH, d))
                {
                    MessageBox.Show("Thêm chi tiết phiếu nhập thành công");
                    LayDSCTPN(maNH);
                }
                else
                {
                    MessageBox.Show("Thêm chi tiết phiếu nhập thất bại. Thêm lại nhé!!!", "Thông báo", MessageBoxButtons.OK);
                    Close();
                }
            }
        }

        

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Mời bạn chọn thông tin cần xoá!!!");
            }
            else
            {
                int maHH;
                CT_NHAPHANG d = new CT_NHAPHANG();
                d.SOLUONGHANGNHAP = Int32.Parse(gVCTNH.CurrentRow.Cells[3].Value.ToString());
                maHH = Int32.Parse(gVCTNH.CurrentRow.Cells[0].Value.ToString());


                if (bus.XoaCTPhieuNhap(maNH, maHH, d))
                {
                    MessageBox.Show("Xóa đơn hàng thành công");
                    LayDSCTPN(maNH);
                }
                else
                {
                    MessageBox.Show("Xóa đơn hàng thất bại");
                }
            }
        }

        private void FCTNhapHang_Activated(object sender, EventArgs e)
        {
            LayDSCTPN(maNH);
            txtMaNH.Text = maNH.ToString();
            txtMaNH.ReadOnly = true;
        }

        private void cbHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (co)
            {
                HANGHOA sp;
                int maSP;

                maSP = Int32.Parse(cbHH.SelectedValue.ToString());
                sp = busSP.LayThongTinSP(maSP);
                txtDonGia.Text = sp.GIAVON.ToString();
            }
        }

        private void cbHH_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FCTNhapHang_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
