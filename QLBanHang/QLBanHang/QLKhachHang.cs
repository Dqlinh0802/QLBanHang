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
    public partial class QLKhachHang : Form
    {
        BUS_KhachHang busKH;
        public QLKhachHang()
        {
            InitializeComponent();
            busKH = new BUS_KhachHang();
        }
        private void HienThiDSTTKhachHang()
        {
            gVTTKhachHang.DataSource = null;
            busKH.HienThiKhachHang(gVTTKhachHang);
            gVTTKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            gVTTKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            gVTTKhachHang.Columns[2].HeaderText = "Email";
            gVTTKhachHang.Columns[3].HeaderText = "Số điện thoại";

            gVTTKhachHang.Columns[0].Width = (int)(gVTTKhachHang.Width * 0.1);
            gVTTKhachHang.Columns[1].Width = (int)(gVTTKhachHang.Width * 0.2);
            gVTTKhachHang.Columns[2].Width = (int)(gVTTKhachHang.Width * 0.35);
            gVTTKhachHang.Columns[3].Width = (int)(gVTTKhachHang.Width * 0.2);

        }

        private void clear()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtEmailKH.Text = "";
            txtSdtKH.Text = "";
        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDSTTKhachHang();
            txtMaKH.Enabled = false;
        }

        private void gVTTKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
            if (e.RowIndex >= 0 && e.RowIndex <= gVTTKhachHang.Rows.Count)
            {
                txtMaKH.Enabled = false;
                txtMaKH.Text = gVTTKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                if (gVTTKhachHang.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    txtTenKH.Text = gVTTKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                }
                if (gVTTKhachHang.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    txtEmailKH.Text = gVTTKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                }
                if (gVTTKhachHang.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    txtSdtKH.Text = gVTTKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                }
            }
            btThem.Enabled = false;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "" || txtEmailKH.Text == "" || txtSdtKH.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin cần thiết");
            }
            else
            {
                KHACHHANG khachHang = new KHACHHANG();
                khachHang.TEN_KH = txtTenKH.Text;
                khachHang.EMAIL_KH = txtEmailKH.Text;
                khachHang.SDT_KH = txtSdtKH.Text;
                //khachHang.NamSinh = dTimeKH.Value;

                if (busKH.ThemTTKH(khachHang))
                {
                    MessageBox.Show("Thêm Thông Tin Khách Hàng Thành Công");
                    busKH.HienThiKhachHang(gVTTKhachHang);
                }
                else
                {
                    MessageBox.Show("Thêm Thông Tin Khách Hàng Thất Bại");
                }
                clear();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Chưa có mục chọn nào được chọn để sửa");
            }
            else
            {
                KHACHHANG khachHang = new KHACHHANG();
                khachHang.MA_KH = Int32.Parse(txtMaKH.Text);
                khachHang.TEN_KH = txtTenKH.Text;
                khachHang.EMAIL_KH = txtEmailKH.Text;
                khachHang.SDT_KH = txtSdtKH.Text;

                if (busKH.SuaTTKH(khachHang))
                {
                    MessageBox.Show("Sửa Thông Tin Khách Hàng Thành Công");
                    busKH.HienThiKhachHang(gVTTKhachHang);
                }
                else
                {
                    MessageBox.Show("Sửa Thông Tin Khách Hàng Thất Bại");
                }
                clear();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Mời chọn mục để xóa");
            }
            else
            {
                KHACHHANG khachHang = new KHACHHANG();
                khachHang.MA_KH = Int32.Parse(txtMaKH.Text);

                if (busKH.XoaTTKH(khachHang))
                {
                    MessageBox.Show("Xóa Thông Tin Khách Hàng Thành Công");
                    busKH.HienThiKhachHang(gVTTKhachHang);
                }
                else
                {
                    MessageBox.Show("Xóa Thông Tin Khách Hàng Thất Bại");
                }
                clear();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QLKhachHang_Click(object sender, EventArgs e)
        {
            clear();
            txtTenKH.Focus();
            btThem.Enabled = true;
        }

        private void txtSdtKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
