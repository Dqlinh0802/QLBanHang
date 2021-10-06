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
    public partial class FThongKe : Form
    {
        BUS_NhanVien bNV;
        BUS_SanPham bSP;
        BUS_KhachHang bKH;
        BUS_NCC bN;
        
        public FThongKe()
        {
            InitializeComponent();
            bNV = new BUS_NhanVien();
            bSP = new BUS_SanPham();
            bKH = new BUS_KhachHang();
            bN = new BUS_NCC();
        }

        private void btDSNV_Click(object sender, EventArgs e)
        {
            rptDSNV r = new rptDSNV();
            FReport f = new FReport();

            r.SetDataSource(bNV.LayDSNV());
            f.crystalReportViewer1.ReportSource = r;

            f.Show();
            btDSNV.Enabled = false;
        }

        private void btBC_Click(object sender, EventArgs e)
        {
            rptSPBC r = new rptSPBC();
            FReport f = new FReport();

            r.SetDataSource(bSP.laySP());
            f.crystalReportViewer1.ReportSource = r;

            f.Show();
            btBC.Enabled = false;
        }

        private void btKH_Click(object sender, EventArgs e)
        {
            rptKH r = new rptKH();
            FReport f = new FReport();

            r.SetDataSource(bKH.layKH());
            f.crystalReportViewer1.ReportSource = r;

            f.Show();
            btKH.Enabled = false;
        }

        private void btNCC_Click(object sender, EventArgs e)
        {
            rptNCC r = new rptNCC();
            FReport f = new FReport();

            r.SetDataSource(bN.layNCC());
            f.crystalReportViewer1.ReportSource = r;

            f.Show();
            btNCC.Enabled = false;
        }

        private void btNCCgv_Click(object sender, EventArgs e)
        {
            gVTong.DataSource = null;
            groupBox3.Text = "Danh sách nhà cung cấp";
            bN.hThiDSDH(gVTong);
            gVTong.Columns[0].HeaderText = "Mã NCC";
            gVTong.Columns[1].HeaderText = "Tên NCC";
            gVTong.Columns[2].HeaderText = "Số điện thoại";
            gVTong.Columns[3].HeaderText = "Địa chỉ";
            gVTong.Columns[4].HeaderText = "Email";

            gVTong.Columns[0].Width = (int)(gVTong.Width * 0.1);
            gVTong.Columns[1].Width = (int)(gVTong.Width * 0.2);
            gVTong.Columns[2].Width = (int)(gVTong.Width * 0.16);
            gVTong.Columns[3].Width = (int)(gVTong.Width * 0.25);
            gVTong.Columns[4].Width = (int)(gVTong.Width * 0.23);

            btNCC.Enabled = true;
            btKH.Enabled = false;
            btBC.Enabled = false;
            btDSNV.Enabled = false;
        }

        private void btKHgv_Click(object sender, EventArgs e)
        {
            gVTong.DataSource = null;
            bKH.HienThiKhachHang(gVTong);
            groupBox3.Text = "Danh sách khách hàng";
            gVTong.Columns[0].HeaderText = "Mã khách hàng";
            gVTong.Columns[1].HeaderText = "Tên khách hàng";
            gVTong.Columns[2].HeaderText = "Email";
            gVTong.Columns[3].HeaderText = "Số điện thoại";

            gVTong.Columns[0].Width = (int)(gVTong.Width * 0.1);
            gVTong.Columns[1].Width = (int)(gVTong.Width * 0.25);
            gVTong.Columns[2].Width = (int)(gVTong.Width * 0.35);
            gVTong.Columns[3].Width = (int)(gVTong.Width * 0.24);

            btKH.Enabled = true;
            btBC.Enabled = false;
            btDSNV.Enabled = false;
            btNCC.Enabled = false;
        }

        private void btSPgv_Click(object sender, EventArgs e)
        {
            gVTong.DataSource = null;
            bSP.LayDSSanPham(gVTong);
            groupBox3.Text = "Danh sách sản phẩm";
            gVTong.Columns[0].HeaderText = "Mã SP";
            gVTong.Columns[1].HeaderText = "Tên SP";
            gVTong.Columns[2].HeaderText = "Số lượng";
            gVTong.Columns[3].HeaderText = "Đơn giá";
            gVTong.Columns[4].HeaderText = "Nhóm SP";

            gVTong.Columns[0].Width = (int)(gVTong.Width * 0.1);
            gVTong.Columns[1].Width = (int)(gVTong.Width * 0.2);
            gVTong.Columns[2].Width = (int)(gVTong.Width * 0.2);
            gVTong.Columns[3].Width = (int)(gVTong.Width * 0.2);
            gVTong.Columns[4].Width = (int)(gVTong.Width * 0.23);

            btBC.Enabled = true;
            btDSNV.Enabled = false;
            btNCC.Enabled = false;
            btKH.Enabled = false;
        }

        private void btNVgv_Click(object sender, EventArgs e)
        {
            gVTong.DataSource = null;
            bNV.LayDSNhanVien(gVTong);
            groupBox3.Text = "Danh sách nhân viên";
            gVTong.Columns[0].HeaderText = "Mã nhân viên";
            gVTong.Columns[1].HeaderText = "Tên nhân viên";
            gVTong.Columns[2].HeaderText = "Email";
            gVTong.Columns[3].HeaderText = "Số điện thoại";
            gVTong.Columns[4].HeaderText = "Năm sinh";
            gVTong.Columns[5].HeaderText = "CCCD";
            gVTong.Columns[6].HeaderText = "Địa chỉ";
            gVTong.Columns[7].HeaderText = "Ghi chú";

            gVTong.Columns[0].Width = (int)(gVTong.Width * 0.06);
            gVTong.Columns[1].Width = (int)(gVTong.Width * 0.1);
            gVTong.Columns[2].Width = (int)(gVTong.Width * 0.20);
            gVTong.Columns[3].Width = (int)(gVTong.Width * 0.13);
            gVTong.Columns[4].Width = (int)(gVTong.Width * 0.1);
            gVTong.Columns[5].Width = (int)(gVTong.Width * 0.1);
            gVTong.Columns[6].Width = (int)(gVTong.Width * 0.1);
            gVTong.Columns[7].Width = (int)(gVTong.Width * 0.155);

            btDSNV.Enabled = true;
            btNCC.Enabled = false;
            btKH.Enabled = false;
            btBC.Enabled = false;
        }
    }
}
