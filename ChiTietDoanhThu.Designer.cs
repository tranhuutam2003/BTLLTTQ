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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            chartArea1.Name = "ChartArea1";
            this.chartChiTietDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartChiTietDoanhThu.Legends.Add(legend1);
            this.chartChiTietDoanhThu.Location = new System.Drawing.Point(2, 2);
            this.chartChiTietDoanhThu.Name = "chartChiTietDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThuBan";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "DoanhThuNhap";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "DoanhThuThuần";
            this.chartChiTietDoanhThu.Series.Add(series1);
            this.chartChiTietDoanhThu.Series.Add(series2);
            this.chartChiTietDoanhThu.Series.Add(series3);
            this.chartChiTietDoanhThu.Size = new System.Drawing.Size(1133, 564);
            this.chartChiTietDoanhThu.TabIndex = 0;
            this.chartChiTietDoanhThu.Text = "chart1";
            this.chartChiTietDoanhThu.Click += new System.EventHandler(this.chartChiTietDoanhThu_Click);
            // 
            // labelThoiGian
            // 
            this.labelThoiGian.AutoSize = true;
            this.labelThoiGian.Location = new System.Drawing.Point(536, 538);
            this.labelThoiGian.Name = "labelThoiGian";
            this.labelThoiGian.Size = new System.Drawing.Size(63, 16);
            this.labelThoiGian.TabIndex = 1;
            this.labelThoiGian.Text = "Thời gian";
            // 
            // labelDoanhThuBan
            // 
            this.labelDoanhThuBan.AutoSize = true;
            this.labelDoanhThuBan.Location = new System.Drawing.Point(884, 133);
            this.labelDoanhThuBan.Name = "labelDoanhThuBan";
            this.labelDoanhThuBan.Size = new System.Drawing.Size(93, 16);
            this.labelDoanhThuBan.TabIndex = 2;
            this.labelDoanhThuBan.Text = "Doanh thu bán";
            // 
            // labelDoanhThuNhap
            // 
            this.labelDoanhThuNhap.AutoSize = true;
            this.labelDoanhThuNhap.Location = new System.Drawing.Point(884, 228);
            this.labelDoanhThuNhap.Name = "labelDoanhThuNhap";
            this.labelDoanhThuNhap.Size = new System.Drawing.Size(109, 16);
            this.labelDoanhThuNhap.TabIndex = 3;
            this.labelDoanhThuNhap.Text = "Doanh Thu Nhập";
            // 
            // labelDoanhThuThuan
            // 
            this.labelDoanhThuThuan.AutoSize = true;
            this.labelDoanhThuThuan.Location = new System.Drawing.Point(884, 322);
            this.labelDoanhThuThuan.Name = "labelDoanhThuThuan";
            this.labelDoanhThuThuan.Size = new System.Drawing.Size(114, 16);
            this.labelDoanhThuThuan.TabIndex = 4;
            this.labelDoanhThuThuan.Text = "Doanh Thu Thuần";
            // 
            // ChiTietDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 566);
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