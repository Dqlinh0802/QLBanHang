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
    public partial class FHienThi : Form
    {
        public FHienThi()
        {
            InitializeComponent();
        }
        private void FHienThi_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox2;
            label1.BackColor = Color.Transparent;
            label3.Parent = pictureBox2;
            label3.BackColor = Color.Transparent;
            label4.Parent = pictureBox2;
            label4.BackColor = Color.Transparent;
            label5.Parent = pictureBox2;
            label5.BackColor = Color.Transparent;
            label6.Parent = pictureBox2;
            label6.BackColor = Color.Transparent;
            label7.Parent = pictureBox2;
            label7.BackColor = Color.Transparent;
            label8.Parent = pictureBox2;
            label8.BackColor = Color.Transparent;
        }
    }
}
