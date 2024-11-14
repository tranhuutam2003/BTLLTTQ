namespace BTL_LTTQ_VIP
{
    partial class DoanhThuTheoThang
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
            this.chartdoanhthu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartdoanhthu)).BeginInit();
            this.SuspendLayout();
            // 
            // chartdoanhthu
            // 
            this.chartdoanhthu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartdoanhthu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartdoanhthu.Legends.Add(legend1);
            this.chartdoanhthu.Location = new System.Drawing.Point(0, 0);
            this.chartdoanhthu.Name = "chartdoanhthu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThuBan";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "DoanhThuNhap";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "DoanhThuThuần";
            this.chartdoanhthu.Series.Add(series1);
            this.chartdoanhthu.Series.Add(series2);
            this.chartdoanhthu.Series.Add(series3);
            this.chartdoanhthu.Size = new System.Drawing.Size(1078, 593);
            this.chartdoanhthu.TabIndex = 0;
            this.chartdoanhthu.Text = "chart1";
            this.chartdoanhthu.Click += new System.EventHandler(this.doanhthu_Click);
            // 
            // DoanhThuTheoThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 591);
            this.Controls.Add(this.chartdoanhthu);
            this.Name = "DoanhThuTheoThang";
            this.Text = "DoanhThuTheoThang";
            this.Load += new System.EventHandler(this.DoanhThuTheoThang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartdoanhthu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartdoanhthu;
    }
}