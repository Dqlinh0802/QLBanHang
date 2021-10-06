using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using QLBanHang.BUS;
using QLBanHang.REPORT;

namespace QLBanHang
{
    public partial class qlNhanVien : Form
    {
        BUS_NhanVien busNhanVien;
        public qlNhanVien()
        {
            InitializeComponent();
            busNhanVien = new BUS_NhanVien();
        }
        public void HienThiDSNhanVien()
        {
            gVNV.DataSource = null;
            busNhanVien.LayDSNhanVien(gVNV);
            gVNV.Columns[0].HeaderText = "Mã nhân viên";
            gVNV.Columns[1].HeaderText = "Tên nhân viên";
            gVNV.Columns[2].HeaderText = "Email";
            gVNV.Columns[3].HeaderText = "Số điện thoại";
            gVNV.Columns[4].HeaderText = "Năm sinh";
            gVNV.Columns[5].HeaderText = "CCCD";
            gVNV.Columns[6].HeaderText = "Địa chỉ";
            gVNV.Columns[7].HeaderText = "Ghi chú";

            gVNV.Columns[0].Width = (int)(gVNV.Width * 0.06);
            gVNV.Columns[1].Width = (int)(gVNV.Width * 0.1);
            gVNV.Columns[2].Width = (int)(gVNV.Width * 0.20);
            gVNV.Columns[3].Width = (int)(gVNV.Width * 0.13);
            gVNV.Columns[4].Width = (int)(gVNV.Width * 0.1);
            gVNV.Columns[5].Width = (int)(gVNV.Width * 0.1);
            gVNV.Columns[6].Width = (int)(gVNV.Width * 0.1);
            gVNV.Columns[7].Width = (int)(gVNV.Width * 0.12);
        }
        public void clear()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtSDT.Text = "";
            txtGhiChu.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtCCCD.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
        }

        private void gVNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            clear();


            if (e.RowIndex >= 0 && e.RowIndex < gVNV.Rows.Count)
            {
                txtMaNV.Enabled = false;
                txtMaNV.Text = gVNV.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (gVNV.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    txtTenNV.Text = gVNV.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                }
                if (gVNV.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    txtEmail.Text = gVNV.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                }
                if (gVNV.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    txtSDT.Text = gVNV.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                }
                if (gVNV.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    dtpNgaySinh.Text = gVNV.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                }
                if (gVNV.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    txtCCCD.Text = gVNV.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                }
                if (gVNV.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    txtDiaChi.Text = gVNV.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                }
                if (gVNV.Rows[e.RowIndex].Cells[7].Value != null)
                {
                    txtGhiChu.Text = gVNV.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
                }

            }
            btThem.Enabled = false;
        }

        private void btThem_Click(object sender, EventArgs e)
        {

            if (txtTenNV.Text == "" || txtCCCD.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin cần thiết");
            }
            else
            {
                NHANVIEN nhanVien = new NHANVIEN();
                nhanVien.TEN_NV = txtTenNV.Text;
                nhanVien.SDT_NV = txtSDT.Text;
                nhanVien.NAMSINH = dtpNgaySinh.Value;
                nhanVien.GHICHU_NV = txtGhiChu.Text;
                nhanVien.EMAIL_NV = txtEmail.Text;
                nhanVien.DIACHI_NV = txtDiaChi.Text;
                nhanVien.CCCD_NV = txtCCCD.Text;

                if (busNhanVien.TaoNhanVien(nhanVien))
                {
                    MessageBox.Show("Tạo nhân viên thành công");
                    busNhanVien.LayDSNhanVien(gVNV);
                }
                else
                {
                    MessageBox.Show("Tạo nhân viên thất bại");
                }
                clear();
            }
        }


        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Chưa có mục chọn nào được chọn để sửa");
            }
            else
            {
                NHANVIEN d = new NHANVIEN();

                d.MA_NV = Int32.Parse(txtMaNV.Text);
                d.TEN_NV = txtTenNV.Text;
                d.SDT_NV = txtSDT.Text;
                d.EMAIL_NV = txtEmail.Text;
                d.GHICHU_NV = txtGhiChu.Text;
                d.DIACHI_NV = txtDiaChi.Text;
                d.CCCD_NV = txtCCCD.Text;
                d.NAMSINH = dtpNgaySinh.Value;

                if (busNhanVien.SuaNV(d))
                {
                    MessageBox.Show("Sửa thông tin nhân viên thành công");
                    busNhanVien.LayDSNhanVien(gVNV);
                }
                else
                {
                    MessageBox.Show("Sửa thông tin nhân viên thất bại");
                }
                clear();
            }
        }

        private void qlNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDSNhanVien();
            txtMaNV.Enabled = false;
            txtTenNV.Focus();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Mời chọn mục để xóa");
            }
            else
            {

                NHANVIEN d = new NHANVIEN();
                d.MA_NV = Int32.Parse(txtMaNV.Text);

                if (busNhanVien.XoaNV(d))
                {
                    MessageBox.Show("Xóa nhân viên thành công");
                    busNhanVien.LayDSNhanVien(gVNV);
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại");
                }
                clear();
            }
        }

        private void qlNhanVien_Click(object sender, EventArgs e)
        {
            clear();
            txtTenNV.Focus();
            btThem.Enabled = true;
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            busNhanVien.TimNV(gVNV, txtTimKiem.Text.Trim());
        }



        private void btThongKe_Click(object sender, EventArgs e)
        {

            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Mời bạn click vào nhân viên cần xem báo cáo");
            }
            else
            {
                int n = int.Parse(txtMaNV.Text);

                rptNV r = new rptNV();
                FReport f = new FReport();
                r.SetDataSource(busNhanVien.LayNV(n));
                f.crystalReportViewer1.ReportSource = r;
                f.Show();
            }
        }
    }
}
