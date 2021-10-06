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
using QLBanHang.REPORT;
namespace QLBanHang
{
    public partial class FNhapHang : Form
    {
        BUS_NhapHang busNP;
        public FNhapHang()
        {
            InitializeComponent();
            busNP = new BUS_NhapHang();
        }


        private void HienThiDSPhieuNhap()
        {
            gvPhieuNhap.DataSource = null;
            busNP.LayDSPhieuNhap(gvPhieuNhap);

            gvPhieuNhap.Columns[0].HeaderText = "Mã nhập hàng";
            gvPhieuNhap.Columns[1].HeaderText = "Ghi chú nhập hàng";
            gvPhieuNhap.Columns[2].HeaderText = "Ngày nhập hàng";
            gvPhieuNhap.Columns[3].HeaderText = "Tên nhân viên";
            gvPhieuNhap.Columns[4].HeaderText = "Tên nhà cung cấp";

            gvPhieuNhap.Columns[0].Width = (int)(gvPhieuNhap.Width * 0.15);
            gvPhieuNhap.Columns[1].Width = (int)(gvPhieuNhap.Width * 0.3);
            gvPhieuNhap.Columns[2].Width = (int)(gvPhieuNhap.Width * 0.15);
            gvPhieuNhap.Columns[3].Width = (int)(gvPhieuNhap.Width * 0.2);
            gvPhieuNhap.Columns[4].Width = (int)(gvPhieuNhap.Width * 0.15);

        }
        private void FNhapHang_Load(object sender, EventArgs e)
        {
            HienThiDSPhieuNhap();
            busNP.LayDSNV(cbNhanVien);
            busNP.LayDSNCC(cbNCC);

        }

        private void clear()
        {
            txtMaNhapHang.Text = "";
            txtGhiChu.Text = "";
            cbNCC.SelectedIndex = 0;
            cbNhanVien.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbNCC.Text == "" || cbNhanVien.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin cần thiết");
            }
            else
            {
                HOADONNHAP d = new HOADONNHAP();
                d.NGAYNHAPHANG = dptNgayNhap.Value;
                d.GHICHUNHAPHANG = txtGhiChu.Text.ToString();
                d.MA_NCC = Int32.Parse(cbNCC.SelectedValue.ToString());
                d.MA_NV = Int32.Parse(cbNhanVien.SelectedValue.ToString());

                if (busNP.ThemPhieuNhap(d))
                {
                    MessageBox.Show("Thêm phiếu nhập thành công");
                    busNP.HienThiDSPhieuNhap(gvPhieuNhap);
                }
                else
                {
                    MessageBox.Show("Thêm phiếu nhập thất bại");
                }
                clear();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNhapHang.Text == "")
            {
                MessageBox.Show("Chưa có mục chọn nào được chọn để sửa");
            }
            else
            {
                HOADONNHAP d = new HOADONNHAP();

                d.MANHAPHANG = int.Parse(txtMaNhapHang.Text.ToString());
                d.NGAYNHAPHANG = dptNgayNhap.Value;
                d.GHICHUNHAPHANG = txtGhiChu.Text.ToString();
                d.MA_NCC = Int32.Parse(cbNCC.SelectedValue.ToString());
                d.MA_NV = Int32.Parse(cbNhanVien.SelectedValue.ToString());

                if (busNP.SuaPhieuNhap(d))
                {
                    MessageBox.Show("Sửa phiếu nhập thành công");
                    busNP.LayDSPhieuNhap(gvPhieuNhap);
                }
                else
                {
                    MessageBox.Show("Sửa phiếu nhập thất bại");
                }

                clear();
            }
        }

        private void gvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < gvPhieuNhap.Rows.Count) // dòng 0 đến dòng số cuối
            {
                txtMaNhapHang.Enabled = false;
                txtMaNhapHang.Text = gvPhieuNhap.Rows[e.RowIndex].Cells["MANHAPHANG"].Value.ToString().Trim();
                if (gvPhieuNhap.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    txtGhiChu.Text = gvPhieuNhap.Rows[e.RowIndex].Cells["GHICHUNHAPHANG"].Value.ToString().Trim();
                }
                if (gvPhieuNhap.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    dptNgayNhap.Text = gvPhieuNhap.Rows[e.RowIndex].Cells["NGAYNHAPHANG"].Value.ToString().Trim();
                }
                if (gvPhieuNhap.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    cbNhanVien.Text = gvPhieuNhap.Rows[e.RowIndex].Cells["TEN_NV"].Value.ToString().Trim();
                }
                if (gvPhieuNhap.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    cbNCC.Text = gvPhieuNhap.Rows[e.RowIndex].Cells["TEN_NCC"].Value.ToString();
                }
            }
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhapHang.Text == "")
            {
                MessageBox.Show("Mời chọn mục để xóa");
            }
            else
            {
                HOADONNHAP p = new HOADONNHAP();
                p.MANHAPHANG = Int32.Parse(txtMaNhapHang.Text.ToString());

                if (busNP.XoaPhieuNhap(p))
                {
                    MessageBox.Show("Xóa phiếu nhập thành công");
                    busNP.LayDSPhieuNhap(gvPhieuNhap);
                }
                else
                {
                    MessageBox.Show("Xóa phiếu nhập thất bại");
                }
                clear();
            }
        }

        private void gvPhieuNhap_DoubleClick(object sender, EventArgs e)
        {
            int ma;

            ma = int.Parse(gvPhieuNhap.CurrentRow.Cells[0].Value.ToString());

            FCTNhapHang f = new FCTNhapHang();
            f.maNH = ma;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FNhapHang_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            clear();
            txtGhiChu.Focus();
        }

        private void cbNCC_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cbNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void btPN_Click(object sender, EventArgs e)
        {
            if (txtMaNhapHang.Text == "")
            {
                MessageBox.Show("Mời bạn click vào phiếu nhập cần xem báo cáo");
            }
            else
            {
                rptPNH r = new rptPNH();
                FReport f = new FReport();

                r.SetDataSource(busNP.layNH(int.Parse(txtMaNhapHang.Text)));
                f.crystalReportViewer1.ReportSource = r;

                f.Show();
            }
        }
    }
}
