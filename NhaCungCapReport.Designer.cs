namespace BTL_LTTQ_VIP
{
    partial class NhaCungCapReport
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
            this.lbtungay = new System.Windows.Forms.Label();
            this.lbdenngay = new System.Windows.Forms.Label();
            this.btnxem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(18, 61);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1114, 455);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtptungay
            // 
            this.dtptungay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtptungay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtptungay.Location = new System.Drawing.Point(194, 25);
            this.dtptungay.Name = "dtptungay";
            this.dtptungay.Size = new System.Drawing.Size(201, 22);
            this.dtptungay.TabIndex = 1;
            // 
            // dtpdenngay
            // 
            this.dtpdenngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtpdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdenngay.Location = new System.Drawing.Point(691, 25);
            this.dtpdenngay.Name = "dtpdenngay";
            this.dtpdenngay.Size = new System.Drawing.Size(201, 22);
            this.dtpdenngay.TabIndex = 2;
            // 
            // lbtungay
            // 
            this.lbtungay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbtungay.AutoSize = true;
            this.lbtungay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbtungay.Location = new System.Drawing.Point(106, 25);
            this.lbtungay.Name = "lbtungay";
            this.lbtungay.Size = new System.Drawing.Size(60, 18);
            this.lbtungay.TabIndex = 3;
            this.lbtungay.Text = "Từ ngày";
            // 
            // lbdenngay
            // 
            this.lbdenngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbdenngay.AutoSize = true;
            this.lbdenngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbdenngay.Location = new System.Drawing.Point(596, 25);
            this.lbdenngay.Name = "lbdenngay";
            this.lbdenngay.Size = new System.Drawing.Size(70, 18);
            this.lbdenngay.TabIndex = 4;
            this.lbdenngay.Text = "Đến ngày";
            // 
            // btnxem
            // 
            this.btnxem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnxem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(208)))), ((int)(((byte)(224)))));
            this.btnxem.FlatAppearance.BorderSize = 2;
            this.btnxem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.btnxem.Location = new System.Drawing.Point(989, 13);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(143, 42);
            this.btnxem.TabIndex = 5;
            this.btnxem.Text = "Xem";
            this.btnxem.UseVisualStyleBackColor = true;
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // NhaCungCapReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 536);
            this.Controls.Add(this.btnxem);
            this.Controls.Add(this.lbdenngay);
            this.Controls.Add(this.lbtungay);
            this.Controls.Add(this.dtpdenngay);
            this.Controls.Add(this.dtptungay);
            this.Controls.Add(this.reportViewer1);
            this.Name = "NhaCungCapReport";
            this.Text = "NhaCungCapReport";
            this.Load += new System.EventHandler(this.NhaCungCapReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dtptungay;
        private System.Windows.Forms.DateTimePicker dtpdenngay;
        private System.Windows.Forms.Label lbtungay;
        private System.Windows.Forms.Label lbdenngay;
        private System.Windows.Forms.Button btnxem;
    }
}