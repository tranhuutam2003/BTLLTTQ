namespace BTL_LTTQ_VIP
{
    partial class ChiTietDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartChiTietDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelThoiGian = new System.Windows.Forms.Label();
            this.labelDoanhThuBan = new System.Windows.Forms.Label();
            this.labelDoanhThuNhap = new System.Windows.Forms.Label();
            this.labelDoanhThuThuan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartChiTietDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // chartChiTietDoanhThu
            // 
            this.chartChiTietDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chartChiTietDoanhThu.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartChiTietDoanhThu.Legends.Add(legend3);
            this.chartChiTietDoanhThu.Location = new System.Drawing.Point(2, 2);
            this.chartChiTietDoanhThu.Name = "chartChiTietDoanhThu";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "DoanhThuBan";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "DoanhThuNhap";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "DoanhThuThuần";
            this.chartChiTietDoanhThu.Series.Add(series7);
            this.chartChiTietDoanhThu.Series.Add(series8);
            this.chartChiTietDoanhThu.Series.Add(series9);
            this.chartChiTietDoanhThu.Size = new System.Drawing.Size(1180, 611);
            this.chartChiTietDoanhThu.TabIndex = 0;
            this.chartChiTietDoanhThu.Text = "chart1";
            this.chartChiTietDoanhThu.Click += new System.EventHandler(this.chartChiTietDoanhThu_Click);
            // 
            // labelThoiGian
            // 
            this.labelThoiGian.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelThoiGian.AutoSize = true;
            this.labelThoiGian.BackColor = System.Drawing.Color.White;
            this.labelThoiGian.Location = new System.Drawing.Point(466, 597);
            this.labelThoiGian.Name = "labelThoiGian";
            this.labelThoiGian.Size = new System.Drawing.Size(63, 16);
            this.labelThoiGian.TabIndex = 1;
            this.labelThoiGian.Text = "Thời gian";
            // 
            // labelDoanhThuBan
            // 
            this.labelDoanhThuBan.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDoanhThuBan.AutoSize = true;
            this.labelDoanhThuBan.BackColor = System.Drawing.Color.White;
            this.labelDoanhThuBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelDoanhThuBan.Location = new System.Drawing.Point(938, 121);
            this.labelDoanhThuBan.Name = "labelDoanhThuBan";
            this.labelDoanhThuBan.Size = new System.Drawing.Size(104, 18);
            this.labelDoanhThuBan.TabIndex = 2;
            this.labelDoanhThuBan.Text = "Doanh thu bán";
            // 
            // labelDoanhThuNhap
            // 
            this.labelDoanhThuNhap.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDoanhThuNhap.AutoSize = true;
            this.labelDoanhThuNhap.BackColor = System.Drawing.Color.White;
            this.labelDoanhThuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelDoanhThuNhap.Location = new System.Drawing.Point(938, 221);
            this.labelDoanhThuNhap.Name = "labelDoanhThuNhap";
            this.labelDoanhThuNhap.Size = new System.Drawing.Size(120, 18);
            this.labelDoanhThuNhap.TabIndex = 3;
            this.labelDoanhThuNhap.Text = "Doanh Thu Nhập";
            // 
            // labelDoanhThuThuan
            // 
            this.labelDoanhThuThuan.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDoanhThuThuan.AutoSize = true;
            this.labelDoanhThuThuan.BackColor = System.Drawing.Color.White;
            this.labelDoanhThuThuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelDoanhThuThuan.Location = new System.Drawing.Point(938, 312);
            this.labelDoanhThuThuan.Name = "labelDoanhThuThuan";
            this.labelDoanhThuThuan.Size = new System.Drawing.Size(126, 18);
            this.labelDoanhThuThuan.TabIndex = 4;
            this.labelDoanhThuThuan.Text = "Doanh Thu Thuần";
            // 
            // ChiTietDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 617);
            this.Controls.Add(this.labelDoanhThuThuan);
            this.Controls.Add(this.labelDoanhThuNhap);
            this.Controls.Add(this.labelDoanhThuBan);
            this.Controls.Add(this.labelThoiGian);
            this.Controls.Add(this.chartChiTietDoanhThu);
            this.Name = "ChiTietDoanhThu";
            this.Text = "ChiTietDoanhThu";
            this.Load += new System.EventHandler(this.ChiTietDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartChiTietDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartChiTietDoanhThu;
        private System.Windows.Forms.Label labelThoiGian;
        private System.Windows.Forms.Label labelDoanhThuBan;
        private System.Windows.Forms.Label labelDoanhThuNhap;
        private System.Windows.Forms.Label labelDoanhThuThuan;
    }
}