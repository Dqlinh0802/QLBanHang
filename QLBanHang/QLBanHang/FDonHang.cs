using QLBanHang.BUS;
using QLBanHang.REPORT;
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
    public partial class FDonHang : Form
    {
        BUS_DonHang busDH;
        BUS_KhachHang busKH;
        BUS_NhanVien busNV;
        public FDonHang()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
            busKH = new BUS_KhachHang();
            busNV = new BUS_NhanVien();
        }

        private void HienThiDSDonHang()
        {
            gVDH.DataSource = null;
            busDH.LayDSDonHang(gVDH);

            gVDH.Columns[0].HeaderText = "Mã hóa đơn";
            gVDH.Columns[1].HeaderText = "Ngày lập hóa đơn";
            gVDH.Columns[2].HeaderText = "Tên nhân viên";
            gVDH.Columns[3].HeaderText = "Tên khách hàng";
            gVDH.Columns[4].HeaderText = "Ghi chú";

            gVDH.Columns[0].Width = (int)(gVDH.Width * 0.2);
            gVDH.Columns[1].Width = (int)(gVDH.Width * 0.2);
            gVDH.Columns[2].Width = (int)(gVDH.Width * 0.2);
            gVDH.Columns[3].Width = (int)(gVDH.Width * 0.2);
            gVDH.Columns[4].Width = (int)(gVDH.Width * 0.2);

        }

        private void FDonHang_Load(object sender, EventArgs e)
        {
            HienThiDSDonHang();
            busKH.LayDSKhachHang(cbKhachHang);
            busNV.LayDSNhanVien(cbNhanVien);
        }

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count)
            {
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["MAHOADON"].Value.ToString().Trim();
                dtpNgayDH.Text = gVDH.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txtGhiChu.Text = gVDH.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                txtMaDH.ReadOnly = true;

            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (cbKhachHang.Text == "" || cbNhanVien.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin cần thiết");
            }
            else
            {
                HOADON HD = new HOADON();
                HD.NGAYLAPHOADON = dtpNgayDH.Value;
                HD.MA_NV = Int32.Parse(cbNhanVien.SelectedValue.ToString());
                HD.MA_KH = Int32.Parse(cbKhachHang.SelectedValue.ToString());
                HD.GHICHUHD = txtGhiChu.Text.ToString();


                if (busDH.TaoDonHang(HD))
                {
                    MessageBox.Show("Tạo đơn hàng thành công");
                    busDH.LayDSDonHang(gVDH);
                }
                else
                {
                    MessageBox.Show("Tạo đơn hàng thất bại");
                }
            }

        }

        private void gVDH_DoubleClick(object sender, EventArgs e)
        {
            int ma;
            ma = int.Parse(gVDH.CurrentRow.Cells[0].Value.ToString());
            FCTDH f = new FCTDH();
            f.maHD = ma;
            f.ShowDialog();
        }

        private void btThemCTDH_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text == "")
            {
                MessageBox.Show("Mời bạn chọn đơn hàng!!!");
            }
            else
            {
                int ma;
                ma = int.Parse(gVDH.CurrentRow.Cells[0].Value.ToString());
                FCTDH f = new FCTDH();
                f.maHD = ma;
                f.ShowDialog();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text == "")
            {
                MessageBox.Show("Mời bạn chọn đơn hàng!!!");
            }
            else
            {
                HOADON d = new HOADON();
                d.MAHOADON = int.Parse(txtMaDH.Text);

                if (busDH.XoaDonHang(d))
                {
                    MessageBox.Show("Xóa đơn hàng thành công");
                    busDH.LayDSDonHang(gVDH);
                }
                else
                {
                    MessageBox.Show("Xóa đơn hàng thất bại");
                }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text == "")
            {
                MessageBox.Show("Mời bạn chọn đơn hàng!!!");
            }
            else
            {
                HOADON d = new HOADON();
                d.MAHOADON = int.Parse(txtMaDH.Text);
                d.NGAYLAPHOADON = dtpNgayDH.Value;
                d.MA_NV = int.Parse(cbNhanVien.SelectedValue.ToString());
                d.MA_KH = int.Parse(cbKhachHang.SelectedValue.ToString());
                d.GHICHUHD = txtGhiChu.Text.ToString();

                if (busDH.SuaDonHang(d))
                {
                    MessageBox.Show("Sửa đơn hàng thành công");
                    busDH.LayDSDonHang(gVDH);
                }
                else
                {
                    MessageBox.Show("Sửa đơn hàng thất bại");
                }
            }
        }
        public void clear()
        {
            txtMaDH.ReadOnly = false;
            txtMaDH.Text = "";
            txtGhiChu.Text = "";
            cbKhachHang.SelectedIndex = 0;
            cbNhanVien.SelectedIndex = 0;
            dtpNgayDH.Value = DateTime.Now;

        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cbNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void FDonHang_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btXuat_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text == "")
            {
                MessageBox.Show("Mời bạn click vào đơn hàng cần xem báo cáo");
            }
            else
            {
                rptHD r = new rptHD();
                FReport f = new FReport();

                r.SetDataSource(busDH.layDH(int.Parse(txtMaDH.Text)));
                f.crystalReportViewer1.ReportSource = r;

                f.Show();
            }
        }
    }
}
