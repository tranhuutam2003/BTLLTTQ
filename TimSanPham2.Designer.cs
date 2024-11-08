namespace BTL_LTTQ_VIP
{
    partial class TimSanPham2
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
            this.dataGridViewKQ = new System.Windows.Forms.DataGridView();
            this.chkTen = new System.Windows.Forms.CheckBox();
            this.cmbHinhDang = new System.Windows.Forms.ComboBox();
            this.chkMauSac = new System.Windows.Forms.CheckBox();
            this.chkChatLieu = new System.Windows.Forms.CheckBox();
            this.cmbMauSac = new System.Windows.Forms.ComboBox();
            this.cmbTen = new System.Windows.Forms.ComboBox();
            this.cmbChatLieu = new System.Windows.Forms.ComboBox();
            this.chkHinhDang = new System.Windows.Forms.CheckBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnexit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKQ)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewKQ
            // 
            this.dataGridViewKQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKQ.Location = new System.Drawing.Point(0, 316);
            this.dataGridViewKQ.Name = "dataGridViewKQ";
            this.dataGridViewKQ.RowHeadersWidth = 51;
            this.dataGridViewKQ.RowTemplate.Height = 24;
            this.dataGridViewKQ.Size = new System.Drawing.Size(956, 317);
            this.dataGridViewKQ.TabIndex = 0;
            // 
            // chkTen
            // 
            this.chkTen.AutoSize = true;
            this.chkTen.Location = new System.Drawing.Point(42, 48);
            this.chkTen.Name = "chkTen";
            this.chkTen.Size = new System.Drawing.Size(102, 20);
            this.chkTen.TabIndex = 1;
            this.chkTen.Text = "Tìm theo tên";
            this.chkTen.UseVisualStyleBackColor = true;
            this.chkTen.CheckedChanged += new System.EventHandler(this.chkTen_CheckedChanged);
            // 
            // cmbHinhDang
            // 
            this.cmbHinhDang.FormattingEnabled = true;
            this.cmbHinhDang.Location = new System.Drawing.Point(281, 208);
            this.cmbHinhDang.Name = "cmbHinhDang";
            this.cmbHinhDang.Size = new System.Drawing.Size(179, 24);
            this.cmbHinhDang.TabIndex = 2;
            // 
            // chkMauSac
            // 
            this.chkMauSac.AutoSize = true;
            this.chkMauSac.Location = new System.Drawing.Point(42, 105);
            this.chkMauSac.Name = "chkMauSac";
            this.chkMauSac.Size = new System.Drawing.Size(135, 20);
            this.chkMauSac.TabIndex = 4;
            this.chkMauSac.Text = "Tìm theo màu sắc";
            this.chkMauSac.UseVisualStyleBackColor = true;
            this.chkMauSac.CheckedChanged += new System.EventHandler(this.chkMauSac_CheckedChanged);
            // 
            // chkChatLieu
            // 
            this.chkChatLieu.AutoSize = true;
            this.chkChatLieu.Location = new System.Drawing.Point(42, 161);
            this.chkChatLieu.Name = "chkChatLieu";
            this.chkChatLieu.Size = new System.Drawing.Size(133, 20);
            this.chkChatLieu.TabIndex = 6;
            this.chkChatLieu.Text = "Tìm theo chất liệu";
            this.chkChatLieu.UseVisualStyleBackColor = true;
            this.chkChatLieu.CheckedChanged += new System.EventHandler(this.chkChatLieu_CheckedChanged);
            // 
            // cmbMauSac
            // 
            this.cmbMauSac.FormattingEnabled = true;
            this.cmbMauSac.Location = new System.Drawing.Point(281, 101);
            this.cmbMauSac.Name = "cmbMauSac";
            this.cmbMauSac.Size = new System.Drawing.Size(179, 24);
            this.cmbMauSac.TabIndex = 7;
            this.cmbMauSac.CursorChanged += new System.EventHandler(this.cmbMauSac_CursorChanged);
            // 
            // cmbTen
            // 
            this.cmbTen.FormattingEnabled = true;
            this.cmbTen.Location = new System.Drawing.Point(281, 44);
            this.cmbTen.Name = "cmbTen";
            this.cmbTen.Size = new System.Drawing.Size(179, 24);
            this.cmbTen.TabIndex = 8;
            // 
            // cmbChatLieu
            // 
            this.cmbChatLieu.FormattingEnabled = true;
            this.cmbChatLieu.Location = new System.Drawing.Point(281, 157);
            this.cmbChatLieu.Name = "cmbChatLieu";
            this.cmbChatLieu.Size = new System.Drawing.Size(179, 24);
            this.cmbChatLieu.TabIndex = 9;
            // 
            // chkHinhDang
            // 
            this.chkHinhDang.AutoSize = true;
            this.chkHinhDang.Location = new System.Drawing.Point(42, 210);
            this.chkHinhDang.Name = "chkHinhDang";
            this.chkHinhDang.Size = new System.Drawing.Size(167, 20);
            this.chkHinhDang.TabIndex = 10;
            this.chkHinhDang.Text = "Tìm theo hình dạng mắt";
            this.chkHinhDang.UseVisualStyleBackColor = true;
            this.chkHinhDang.CheckedChanged += new System.EventHandler(this.chkHinhDang_CheckedChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(208)))), ((int)(((byte)(224)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 2;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimKiem.Image = global::BTL_LTTQ_VIP.Properties.Resources.find1;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(733, 75);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(121, 40);
            this.btnTimKiem.TabIndex = 11;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 312);
            this.panel1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMauSac);
            this.groupBox1.Controls.Add(this.cmbHinhDang);
            this.groupBox1.Controls.Add(this.chkHinhDang);
            this.groupBox1.Controls.Add(this.chkTen);
            this.groupBox1.Controls.Add(this.cmbChatLieu);
            this.groupBox1.Controls.Add(this.cmbTen);
            this.groupBox1.Controls.Add(this.chkChatLieu);
            this.groupBox1.Controls.Add(this.cmbMauSac);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 260);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lựa chọn tìm kiếm";
            // 
            // btnexit
            // 
            this.btnexit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(208)))), ((int)(((byte)(224)))));
            this.btnexit.FlatAppearance.BorderSize = 2;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnexit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnexit.Image = global::BTL_LTTQ_VIP.Properties.Resources.undo;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(733, 172);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(121, 40);
            this.btnexit.TabIndex = 13;
            this.btnexit.Text = "Trở Lại";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // TimSanPham2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 631);
            this.Controls.Add(this.dataGridViewKQ);
            this.Controls.Add(this.panel1);
            this.Name = "TimSanPham2";
            this.Text = "TimSanPham2";
            this.Load += new System.EventHandler(this.TimSanPham2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKQ)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewKQ;
        private System.Windows.Forms.CheckBox chkTen;
        private System.Windows.Forms.ComboBox cmbHinhDang;
        private System.Windows.Forms.CheckBox chkMauSac;
        private System.Windows.Forms.CheckBox chkChatLieu;
        private System.Windows.Forms.ComboBox cmbMauSac;
        private System.Windows.Forms.ComboBox cmbTen;
        private System.Windows.Forms.ComboBox cmbChatLieu;
        private System.Windows.Forms.CheckBox chkHinhDang;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}