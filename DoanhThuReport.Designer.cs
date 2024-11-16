namespace BTL_LTTQ_VIP
{
    partial class DoanhThuReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtptungay = new System.Windows.Forms.DateTimePicker();
            this.dtpdenngay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnxem = new System.Windows.Forms.Button();
            this.doanhThuTableTableAdapter1 = new BTL_LTTQ_VIP.DataSetTableAdapters.DoanhThuTableTableAdapter();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(12, 82);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1055, 383);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtptungay
            // 
            this.dtptungay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtptungay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtptungay.Location = new System.Drawing.Point(158, 29);
            this.dtptungay.Name = "dtptungay";
            this.dtptungay.Size = new System.Drawing.Size(262, 22);
            this.dtptungay.TabIndex = 1;
            // 
            // dtpdenngay
            // 
            this.dtpdenngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtpdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdenngay.Location = new System.Drawing.Point(638, 29);
            this.dtpdenngay.Name = "dtpdenngay";
            this.dtpdenngay.Size = new System.Drawing.Size(262, 22);
            this.dtpdenngay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(51, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(529, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến ngày";
            // 
            // btnxem
            // 
            this.btnxem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnxem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(208)))), ((int)(((byte)(224)))));
            this.btnxem.FlatAppearance.BorderSize = 2;
            this.btnxem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.btnxem.Location = new System.Drawing.Point(939, 16);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(128, 53);
            this.btnxem.TabIndex = 5;
            this.btnxem.Text = "Xem";
            this.btnxem.UseVisualStyleBackColor = true;
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // doanhThuTableTableAdapter1
            // 
            this.doanhThuTableTableAdapter1.ClearBeforeFill = true;
            // 
            // DoanhThuReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 477);
            this.Controls.Add(this.btnxem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpdenngay);
            this.Controls.Add(this.dtptungay);
            this.Controls.Add(this.reportViewer1);
            this.Name = "DoanhThuReport";
            this.Text = "DoanhThuReport";
            this.Load += new System.EventHandler(this.DoanhThuReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dtptungay;
        private System.Windows.Forms.DateTimePicker dtpdenngay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DataSetTableAdapters.DoanhThuTableTableAdapter doanhThuTableTableAdapter1;
        private System.Windows.Forms.Button btnxem;
    }
}