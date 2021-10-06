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
    public partial class trangChu : Form
    {
        public trangChu()
        {
            InitializeComponent();
        }


        private void qlNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNCC f = new QLNCC();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void qlNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlNhanVien f = new qlNhanVien();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void trangChu_Load(object sender, EventArgs e)
        {
            FHienThi f = new FHienThi();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void qlSanPham_Click(object sender, EventArgs e)
        {
            FQuanLySanPham f = new FQuanLySanPham();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }


        private void qlKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLKhachHang f = new QLKhachHang();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void nhapHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNhapHang f = new FNhapHang();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void qlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDonHang f = new FDonHang();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void thoatToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thongKe_Click(object sender, EventArgs e)
        {
            FThongKe f = new FThongKe();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
