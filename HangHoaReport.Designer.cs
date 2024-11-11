namespace BTL_LTTQ_VIP
{
    partial class HangHoaReport
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
            this.cbbsanpham = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnxem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(13, 51);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1097, 442);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // cbbsanpham
            // 
            this.cbbsanpham.FormattingEnabled = true;
            this.cbbsanpham.Location = new System.Drawing.Point(166, 24);
            this.cbbsanpham.Name = "cbbsanpham";
            this.cbbsanpham.Size = new System.Drawing.Size(201, 24);
            this.cbbsanpham.TabIndex = 1;
            this.cbbsanpham.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên sản phẩm";
            this.label1.Visible = false;
            // 
            // btnxem
            // 
            this.btnxem.Location = new System.Drawing.Point(805, 10);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(112, 38);
            this.btnxem.TabIndex = 3;
            this.btnxem.Text = "Xem";
            this.btnxem.UseVisualStyleBackColor = true;
            this.btnxem.Visible = false;
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // HangHoaReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 505);
            this.Controls.Add(this.btnxem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbsanpham);
            this.Controls.Add(this.reportViewer1);
            this.Name = "HangHoaReport";
            this.Text = "HangHoaReport";
            this.Load += new System.EventHandler(this.HangHoaReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cbbsanpham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnxem;
    }
}