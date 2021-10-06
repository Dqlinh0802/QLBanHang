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
    public partial class QLNCC : Form
    {

        BUS_NCC bN;

        public QLNCC()
        {
            InitializeComponent();
            bN = new BUS_NCC();

        }

        private void HienThiDSDonHang()
        {
            gVCTNCC.DataSource = null;
            bN.hThiDSDH(gVCTNCC);
            gVCTNCC.Columns[0].HeaderText = "Mã NCC";
            gVCTNCC.Columns[1].HeaderText = "Tên NCC";
            gVCTNCC.Columns[2].HeaderText = "Số điện thoại";
            gVCTNCC.Columns[3].HeaderText = "Địa chỉ";
            gVCTNCC.Columns[4].HeaderText = "Email";

            gVCTNCC.Columns[0].Width = (int)(gVCTNCC.Width * 0.1);
            gVCTNCC.Columns[1].Width = (int)(gVCTNCC.Width * 0.2);
            gVCTNCC.Columns[2].Width = (int)(gVCTNCC.Width * 0.2);
            gVCTNCC.Columns[3].Width = (int)(gVCTNCC.Width * 0.228);
            gVCTNCC.Columns[4].Width = (int)(gVCTNCC.Width * 0.2);

        }

        private void QLNCC_Load(object sender, EventArgs e)
        {
            HienThiDSDonHang();
            txtMaNCC.Enabled = false;
            txtTenNCC.Focus();
        }

        public void clear()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";

        }
        private void btThem_Click(object sender, EventArgs e)
        {

            if (txtTenNCC.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin cần thiết");
            }
            else
            {

                NHACUNGCAP n = new NHACUNGCAP();
                n.TEN_NCC = txtTenNCC.Text;
                n.SDT_NCC = txtSDT.Text;
                n.DIACHI_NCC = txtDiaChi.Text;
                n.EMAIL_NCC = txtEmail.Text;


                if (bN.themNCC(n))
                {
                    MessageBox.Show("Tạo đơn hàng thành công");
                    bN.hThiDSDH(gVCTNCC);
                }
                else
                {
                    MessageBox.Show("Tạo đơn hàng thất bại");
                }
                clear();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Mời chọn mục để xóa");
            }
            else
            {

                NHACUNGCAP n = new NHACUNGCAP();
                n.MA_NCC = int.Parse(txtMaNCC.Text);

                if (bN.xoaNCC(n))
                {
                    MessageBox.Show("Xóa thành công");
                    bN.hThiDSDH(gVCTNCC);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
                clear();
            }
        }

        private void gVCTNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVCTNCC.Rows.Count)
            {
                txtMaNCC.Enabled = false;
                txtMaNCC.Text = gVCTNCC.Rows[e.RowIndex].Cells["MA_NCC"].Value.ToString();
                if (gVCTNCC.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    txtTenNCC.Text = gVCTNCC.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                }
                if (gVCTNCC.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    txtSDT.Text = gVCTNCC.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                }
                if (gVCTNCC.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    txtDiaChi.Text = gVCTNCC.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                }
                if (gVCTNCC.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    txtEmail.Text = gVCTNCC.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                }
            }
                btThem.Enabled = false;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Chưa có mục chọn nào được chọn để sửa");
            }
            else
            {
                NHACUNGCAP n = new NHACUNGCAP();

                n.MA_NCC = int.Parse(txtMaNCC.Text);
                n.TEN_NCC = txtTenNCC.Text;
                n.SDT_NCC = txtSDT.Text;
                n.DIACHI_NCC = txtDiaChi.Text;
                n.EMAIL_NCC = txtEmail.Text;

                if (bN.suaNCC(n))
                {
                    MessageBox.Show("Sửa thành công");
                    bN.hThiDSDH(gVCTNCC);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
                clear();
            }
            
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QLNCC_Click(object sender, EventArgs e)
        {
            clear();
            txtTenNCC.Focus();
            btThem.Enabled = true;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
