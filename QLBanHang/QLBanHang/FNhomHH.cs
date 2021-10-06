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
    public partial class FNhomHH : Form
    {
        BUS_SanPham busHH;

        public FNhomHH()
        {
            InitializeComponent();
            busHH = new BUS_SanPham();
        }

        private void HienThiDSNhomHH()
        {
            gVNhomHH.DataSource = null;
            busHH.LayDSNhomHH(gVNhomHH);
            gVNhomHH.Columns[0].HeaderText = "Mã nhóm hàng hóa";
            gVNhomHH.Columns[1].HeaderText = "Tên nhóm hàng hóa";


            gVNhomHH.Columns[0].Width = (int)(gVNhomHH.Width * 0.45);
            gVNhomHH.Columns[1].Width = (int)(gVNhomHH.Width * 0.5);

        }



        private void FNhomHH_Load(object sender, EventArgs e)
        {
            HienThiDSNhomHH();
            txtmaNhom.Enabled = false;
        }

        private void btnThemHH_Click(object sender, EventArgs e)
        {
            NHOMHH d = new NHOMHH();


            d.TENNHOM_HH = txttenNhom.Text.ToString();

            if (busHH.ThemNhomHangHoa(d))
            {
                MessageBox.Show("Thêm nhóm hàng hóa thành công");
                HienThiDSNhomHH();
            }
            else
            {
                MessageBox.Show("Thêm nhóm hàng hóa thất bại");
            }
        }

        private void btnSuaHH_Click(object sender, EventArgs e)
        {
            NHOMHH d = new NHOMHH();

            d.MANHOM_HH = int.Parse(txtmaNhom.Text.ToString());
            d.TENNHOM_HH = txttenNhom.Text.ToString();


            if (busHH.SuaNhomHH(d))
            {
                MessageBox.Show("Sửa nhóm hàng hóa thành công");
                busHH.LayDSNhomHH(gVNhomHH);
            }
            else
            {
                MessageBox.Show("Sửa nhóm hàng hóa thất bại");
            }
        }

        private void btnXoaHH_Click(object sender, EventArgs e)
        {
            NHOMHH p = new NHOMHH();
            p.MANHOM_HH = int.Parse(txtmaNhom.Text);

            if (busHH.XoaNhomHangHoa(p))
            {
                MessageBox.Show("Xóa nhóm hàng hóa thành công");
                busHH.LayDSNhomHH(gVNhomHH);
            }
            else
            {
                MessageBox.Show("Xóa nhóm hàng hóa thất bại");
            }
            clear();
        }

        public void clear()
        {
            txtmaNhom.Text = "";
            txttenNhom.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gVNhomHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVNhomHH.Rows.Count) // dòng 0 đến dòng số cuối
            {
                if (gVNhomHH.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    txtmaNhom.Text = gVNhomHH.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                }
                if (gVNhomHH.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    txttenNhom.Text = gVNhomHH.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                }
            }
            btnThemHH.Enabled = false;
        }

        private void FNhomHH_Click(object sender, EventArgs e)
        {
            clear();
            txttenNhom.Focus();
            btnThemHH.Enabled = true;
        }
    }
}
