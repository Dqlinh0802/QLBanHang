namespace QLBanHang
{
    partial class FNhomHH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gVNhomHH = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSuaHH = new System.Windows.Forms.Button();
            this.btnXoaHH = new System.Windows.Forms.Button();
            this.btnThemHH = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttenNhom = new System.Windows.Forms.TextBox();
            this.hoTenNhanVienLabel = new System.Windows.Forms.Label();
            this.txtmaNhom = new System.Windows.Forms.TextBox();
            this.ngaySinhLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gVNhomHH)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gVNhomHH);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(384, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(692, 622);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết nhóm HH";
            // 
            // gVNhomHH
            // 
            this.gVNhomHH.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gVNhomHH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gVNhomHH.Location = new System.Drawing.Point(15, 33);
            this.gVNhomHH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gVNhomHH.Name = "gVNhomHH";
            this.gVNhomHH.RowHeadersWidth = 62;
            this.gVNhomHH.RowTemplate.Height = 28;
            this.gVNhomHH.Size = new System.Drawing.Size(661, 573);
            this.gVNhomHH.TabIndex = 0;
            this.gVNhomHH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gVNhomHH_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnSuaHH);
            this.groupBox2.Controls.Add(this.btnXoaHH);
            this.groupBox2.Controls.Add(this.btnThemHH);
            this.groupBox2.Location = new System.Drawing.Point(4, -9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 86);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.btnThoat.Location = new System.Drawing.Point(263, 19);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(66, 57);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSuaHH
            // 
            this.btnSuaHH.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaHH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.btnSuaHH.Location = new System.Drawing.Point(177, 19);
            this.btnSuaHH.Name = "btnSuaHH";
            this.btnSuaHH.Size = new System.Drawing.Size(66, 57);
            this.btnSuaHH.TabIndex = 2;
            this.btnSuaHH.Text = "Sửa";
            this.btnSuaHH.UseVisualStyleBackColor = true;
            this.btnSuaHH.Click += new System.EventHandler(this.btnSuaHH_Click);
            // 
            // btnXoaHH
            // 
            this.btnXoaHH.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaHH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.btnXoaHH.Location = new System.Drawing.Point(92, 19);
            this.btnXoaHH.Name = "btnXoaHH";
            this.btnXoaHH.Size = new System.Drawing.Size(66, 57);
            this.btnXoaHH.TabIndex = 1;
            this.btnXoaHH.Text = "Xóa";
            this.btnXoaHH.UseVisualStyleBackColor = true;
            this.btnXoaHH.Click += new System.EventHandler(this.btnXoaHH_Click);
            // 
            // btnThemHH
            // 
            this.btnThemHH.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.btnThemHH.Location = new System.Drawing.Point(7, 19);
            this.btnThemHH.Name = "btnThemHH";
            this.btnThemHH.Size = new System.Drawing.Size(66, 57);
            this.btnThemHH.TabIndex = 0;
            this.btnThemHH.Text = "Thêm";
            this.btnThemHH.UseVisualStyleBackColor = true;
            this.btnThemHH.Click += new System.EventHandler(this.btnThemHH_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttenNhom);
            this.groupBox1.Controls.Add(this.hoTenNhanVienLabel);
            this.groupBox1.Controls.Add(this.txtmaNhom);
            this.groupBox1.Controls.Add(this.ngaySinhLabel);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(4, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 154);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin NCC";
            // 
            // txttenNhom
            // 
            this.txttenNhom.BackColor = System.Drawing.SystemColors.Control;
            this.txttenNhom.Location = new System.Drawing.Point(142, 95);
            this.txttenNhom.Name = "txttenNhom";
            this.txttenNhom.Size = new System.Drawing.Size(188, 20);
            this.txttenNhom.TabIndex = 20;
            // 
            // hoTenNhanVienLabel
            // 
            this.hoTenNhanVienLabel.AutoSize = true;
            this.hoTenNhanVienLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoTenNhanVienLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.hoTenNhanVienLabel.Location = new System.Drawing.Point(11, 49);
            this.hoTenNhanVienLabel.Name = "hoTenNhanVienLabel";
            this.hoTenNhanVienLabel.Size = new System.Drawing.Size(118, 19);
            this.hoTenNhanVienLabel.TabIndex = 15;
            this.hoTenNhanVienLabel.Text = "Mã nhóm HH:";
            // 
            // txtmaNhom
            // 
            this.txtmaNhom.BackColor = System.Drawing.SystemColors.Control;
            this.txtmaNhom.Location = new System.Drawing.Point(142, 46);
            this.txtmaNhom.Name = "txtmaNhom";
            this.txtmaNhom.Size = new System.Drawing.Size(188, 20);
            this.txtmaNhom.TabIndex = 16;
            // 
            // ngaySinhLabel
            // 
            this.ngaySinhLabel.AutoSize = true;
            this.ngaySinhLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaySinhLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.ngaySinhLabel.Location = new System.Drawing.Point(11, 95);
            this.ngaySinhLabel.Name = "ngaySinhLabel";
            this.ngaySinhLabel.Size = new System.Drawing.Size(125, 19);
            this.ngaySinhLabel.TabIndex = 17;
            this.ngaySinhLabel.Text = "Tên nhóm HH:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(616, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 35);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nhóm hàng hóa";
            // 
            // FNhomHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 670);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FNhomHH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FNhomHH";
            this.Load += new System.EventHandler(this.FNhomHH_Load);
            this.Click += new System.EventHandler(this.FNhomHH_Click);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gVNhomHH)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gVNhomHH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSuaHH;
        private System.Windows.Forms.Button btnXoaHH;
        private System.Windows.Forms.Button btnThemHH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttenNhom;
        private System.Windows.Forms.Label hoTenNhanVienLabel;
        private System.Windows.Forms.TextBox txtmaNhom;
        private System.Windows.Forms.Label ngaySinhLabel;
        private System.Windows.Forms.Label label1;
    }
}