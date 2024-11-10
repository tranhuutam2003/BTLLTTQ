namespace BTL_LTTQ_VIP
{
    partial class KhachHangReport
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
            this.KhachHangRp = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbbkhachhang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnxem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KhachHangRp
            // 
            this.KhachHangRp.Location = new System.Drawing.Point(39, 84);
            this.KhachHangRp.Name = "KhachHangRp";
            this.KhachHangRp.ServerReport.BearerToken = null;
            this.KhachHangRp.Size = new System.Drawing.Size(1076, 474);
            this.KhachHangRp.TabIndex = 0;
            // 
            // cbbkhachhang
            // 
            this.cbbkhachhang.FormattingEnabled = true;
            this.cbbkhachhang.Location = new System.Drawing.Point(188, 23);
            this.cbbkhachhang.Name = "cbbkhachhang";
            this.cbbkhachhang.Size = new System.Drawing.Size(165, 24);
            this.cbbkhachhang.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên khách hàng";
            // 
            // btnxem
            // 
            this.btnxem.Location = new System.Drawing.Point(1027, 23);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(88, 34);
            this.btnxem.TabIndex = 3;
            this.btnxem.Text = "Xem";
            this.btnxem.UseVisualStyleBackColor = true;
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // KhachHangReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 577);
            this.Controls.Add(this.btnxem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbkhachhang);
            this.Controls.Add(this.KhachHangRp);
            this.Name = "KhachHangReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KhachHangReport";
            this.Load += new System.EventHandler(this.KhachHangReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer KhachHangRp;
        private System.Windows.Forms.ComboBox cbbkhachhang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnxem;
    }
}