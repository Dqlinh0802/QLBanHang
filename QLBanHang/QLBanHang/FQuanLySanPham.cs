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
    public partial class FQuanLySanPham : Form
    {
        BUS_SanPham busSP;
        int maSP;
        public FQuanLySanPham()
        {
            InitializeComponent();
            busSP = new BUS_SanPham();
        }

        private void HienThiDSSanPham()
        {
            gVSanPham.DataSource = null;
            busSP.LayDSSanPham(gVSanPham);
            gVSanPham.Columns[0].HeaderText = "Mã SP";
            gVSanPham.Columns[1].HeaderText = "Tên SP";
            gVSanPham.Columns[2].HeaderText = "Số lượng";
            gVSanPham.Columns[3].HeaderText = "Đơn giá";
            gVSanPham.Columns[4].HeaderText = "Nhóm SP";

            gVSanPham.Columns[0].Width = (int)(gVSanPham.Width * 0.1);
            gVSanPham.Columns[1].Width = (int)(gVSanPham.Width * 0.2);
            gVSanPham.Columns[2].Width = (int)(gVSanPham.Width * 0.2);
            gVSanPham.Columns[3].Width = (int)(gVSanPham.Width * 0.2);
            gVSanPham.Columns[4].Width = (int)(gVSanPham.Width * 0.2);
        }

        public void clear()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            cbMaNhom.SelectedIndex = 0;
        }

        private void FQuanLySanPham_Load(object sender, EventArgs e)
        {
            HienThiDSSanPham();
            busSP.LayDSMaNhomSP(cbMaNhom);
            txtMaSP.Enabled = false;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text == "" || txtSoLuong.Text == "" || txtDonGia.Text == "" || cbMaNhom.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin cần thiết");
            }
            else
            {
                HANGHOA d = new HANGHOA();

                d.TEN_HH = txtTenSP.Text.ToString();
                d.SOLUONG_HH = Int32.Parse(txtSoLuong.Text.ToString());
                d.GIAVON = Decimal.Parse(txtDonGia.Text.ToString());
                d.MANHOM_HH = int.Parse(cbMaNhom.SelectedValue.ToString());

                if (busSP.ThemSanPham(d))
                {
                    MessageBox.Show("Thêm sản phẩm thành công");
                    busSP.HienThiDSSP(gVSanPham);
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại");
                }
                clear();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Mời chọn mục để xóa");
            }
            else
            {

                HANGHOA p = new HANGHOA();
                p.MA_HH = int.Parse(txtMaSP.Text);

                if (busSP.XoaSanPham(p))
                {
                    MessageBox.Show("Xóa sản phẩm thành công");
                    busSP.LayDSSanPham(gVSanPham);
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại");
                }
                clear();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Chưa có mục chọn nào được chọn để sửa");
            }
            else
            {
                HANGHOA d = new HANGHOA();

                d.MA_HH = Int32.Parse(txtMaSP.Text.ToString());
                d.TEN_HH = txtTenSP.Text.ToString();
                d.SOLUONG_HH = Int32.Parse(txtSoLuong.Text.ToString());
                d.GIAVON = Decimal.Parse(txtDonGia.Text.ToString());
                d.MANHOM_HH = Int32.Parse(cbMaNhom.SelectedValue.ToString());

                if (busSP.SuaSanPham(d))
                {
                    MessageBox.Show("Sửa sản phẩm thành công");
                    busSP.LayDSSanPham(gVSanPham);
                }
                else
                {
                    MessageBox.Show("Sửa sản phẩm thất bại");
                }
                clear();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gVSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Enabled = false;
            if (e.RowIndex >= 0 && e.RowIndex < gVSanPham.Rows.Count) // dòng 0 đến dòng số cuối
            {
                if (gVSanPham.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    txtMaSP.Text = gVSanPham.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                }
                if (gVSanPham.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    txtTenSP.Text = gVSanPham.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                }
                if (gVSanPham.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    txtSoLuong.Text = gVSanPham.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                }
                if (gVSanPham.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    txtDonGia.Text = gVSanPham.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                }    
                if (gVSanPham.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    cbMaNhom.Text = gVSanPham.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                }

            }
            btThem.Enabled = false;
        }

        private void FQuanLySanPham_Click(object sender, EventArgs e)
        {
            clear();
            txtTenSP.Focus();
            btThem.Enabled = true;
        }

        private void cbMaNhom_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void btAddNCC_Click(object sender, EventArgs e)
        {
            FNhomHH f = new FNhomHH();
            f.ShowDialog();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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
