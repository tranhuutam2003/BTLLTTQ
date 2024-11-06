namespace BTL_LTTQ_VIP
{
    partial class DoanhThu
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
            this.dtpngayketthuc = new System.Windows.Forms.DateTimePicker();
            this.dtpngaybatdau = new System.Windows.Forms.DateTimePicker();
            this.btnxemdoanhthu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnexit = new System.Windows.Forms.Button();
            this.lblTongDoanhThuThuan = new System.Windows.Forms.Label();
            this.lblTongDoanhThuNhap = new System.Windows.Forms.Label();
            this.lblTongDoanhThuBan = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnxemdoanhthutheothang = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpngayketthuc
            // 
            this.dtpngayketthuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngayketthuc.Location = new System.Drawing.Point(538, 212);
            this.dtpngayketthuc.Name = "dtpngayketthuc";
            this.dtpngayketthuc.Size = new System.Drawing.Size(250, 22);
            this.dtpngayketthuc.TabIndex = 0;
            this.dtpngayketthuc.ValueChanged += new System.EventHandler(this.dtpngayketthuc_ValueChanged);
            // 
            // dtpngaybatdau
            // 
            this.dtpngaybatdau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngaybatdau.Location = new System.Drawing.Point(134, 214);
            this.dtpngaybatdau.Name = "dtpngaybatdau";
            this.dtpngaybatdau.Size = new System.Drawing.Size(250, 22);
            this.dtpngaybatdau.TabIndex = 1;
            // 
            // btnxemdoanhthu
            // 
            this.btnxemdoanhthu.FlatAppearance.BorderSize = 0;
            this.btnxemdoanhthu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxemdoanhthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxemdoanhthu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnxemdoanhthu.Image = global::BTL_LTTQ_VIP.Properties.Resources.seedetail;
            this.btnxemdoanhthu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxemdoanhthu.Location = new System.Drawing.Point(3, 3);
            this.btnxemdoanhthu.Name = "btnxemdoanhthu";
            this.btnxemdoanhthu.Size = new System.Drawing.Size(169, 60);
            this.btnxemdoanhthu.TabIndex = 2;
            this.btnxemdoanhthu.Text = "Xem doanh thu";
            this.btnxemdoanhthu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnxemdoanhthu.UseVisualStyleBackColor = true;
            this.btnxemdoanhthu.Click += new System.EventHandler(this.btnxemdoanhthu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(797, 194);
            this.dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(-3, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ngày bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(407, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày kết thúc";
            // 
            // btnexit
            // 
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnexit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnexit.Image = global::BTL_LTTQ_VIP.Properties.Resources.undo;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(682, 2);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(106, 61);
            this.btnexit.TabIndex = 6;
            this.btnexit.Text = "Trở lại";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // lblTongDoanhThuThuan
            // 
            this.lblTongDoanhThuThuan.AutoSize = true;
            this.lblTongDoanhThuThuan.Location = new System.Drawing.Point(576, 249);
            this.lblTongDoanhThuThuan.Name = "lblTongDoanhThuThuan";
            this.lblTongDoanhThuThuan.Size = new System.Drawing.Size(154, 16);
            this.lblTongDoanhThuThuan.TabIndex = 9;
            this.lblTongDoanhThuThuan.Text = "lblTongDoanhThuThuan";
            this.lblTongDoanhThuThuan.Visible = false;
            // 
            // lblTongDoanhThuNhap
            // 
            this.lblTongDoanhThuNhap.AutoSize = true;
            this.lblTongDoanhThuNhap.Location = new System.Drawing.Point(408, 249);
            this.lblTongDoanhThuNhap.Name = "lblTongDoanhThuNhap";
            this.lblTongDoanhThuNhap.Size = new System.Drawing.Size(149, 16);
            this.lblTongDoanhThuNhap.TabIndex = 8;
            this.lblTongDoanhThuNhap.Text = "lblTongDoanhThuNhap";
            this.lblTongDoanhThuNhap.Visible = false;
            // 
            // lblTongDoanhThuBan
            // 
            this.lblTongDoanhThuBan.AutoSize = true;
            this.lblTongDoanhThuBan.Location = new System.Drawing.Point(217, 249);
            this.lblTongDoanhThuBan.Name = "lblTongDoanhThuBan";
            this.lblTongDoanhThuBan.Size = new System.Drawing.Size(140, 16);
            this.lblTongDoanhThuBan.TabIndex = 7;
            this.lblTongDoanhThuBan.Text = "lblTongDoanhThuBan";
            this.lblTongDoanhThuBan.Visible = false;
            this.lblTongDoanhThuBan.Click += new System.EventHandler(this.lblTongDoanhThuBan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnxemdoanhthutheothang);
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Controls.Add(this.btnxemdoanhthu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 66);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnxemdoanhthutheothang
            // 
            this.btnxemdoanhthutheothang.FlatAppearance.BorderSize = 0;
            this.btnxemdoanhthutheothang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxemdoanhthutheothang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxemdoanhthutheothang.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnxemdoanhthutheothang.Image = global::BTL_LTTQ_VIP.Properties.Resources.seedetail;
            this.btnxemdoanhthutheothang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxemdoanhthutheothang.Location = new System.Drawing.Point(220, -1);
            this.btnxemdoanhthutheothang.Name = "btnxemdoanhthutheothang";
            this.btnxemdoanhthutheothang.Size = new System.Drawing.Size(255, 66);
            this.btnxemdoanhthutheothang.TabIndex = 10;
            this.btnxemdoanhthutheothang.Text = "Xem doanh thu theo tháng";
            this.btnxemdoanhthutheothang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnxemdoanhthutheothang.UseVisualStyleBackColor = true;
            this.btnxemdoanhthutheothang.Click += new System.EventHandler(this.btnxemdoanhthutheothang_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(481, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 66);
            this.button1.TabIndex = 11;
            this.button1.Text = "Báo cáo doanh thu";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.lblTongDoanhThuThuan);
            this.Controls.Add(this.lblTongDoanhThuNhap);
            this.Controls.Add(this.lblTongDoanhThuBan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtpngaybatdau);
            this.Controls.Add(this.dtpngayketthuc);
            this.Controls.Add(this.panel1);
            this.Name = "DoanhThu";
            this.Text = "DoanhThu";
            this.Load += new System.EventHandler(this.DoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpngayketthuc;
        private System.Windows.Forms.DateTimePicker dtpngaybatdau;
        private System.Windows.Forms.Button btnxemdoanhthu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnxemdoanhthutheothang;
        private System.Windows.Forms.Label lblTongDoanhThuThuan;
        private System.Windows.Forms.Label lblTongDoanhThuNhap;
        private System.Windows.Forms.Label lblTongDoanhThuBan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}