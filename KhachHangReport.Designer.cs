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
            this.SuspendLayout();
            // 
            // KhachHangRp
            // 
            this.KhachHangRp.Location = new System.Drawing.Point(39, 47);
            this.KhachHangRp.Name = "KhachHangRp";
            this.KhachHangRp.ServerReport.BearerToken = null;
            this.KhachHangRp.Size = new System.Drawing.Size(1076, 511);
            this.KhachHangRp.TabIndex = 0;
            // 
            // KhachHangReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 577);
            this.Controls.Add(this.KhachHangRp);
            this.Name = "KhachHangReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KhachHangReport";
            this.Load += new System.EventHandler(this.KhachHangReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer KhachHangRp;
    }
}