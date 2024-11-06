namespace BTL_LTTQ_VIP
{
    partial class ThemCongDung
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ma = new System.Windows.Forms.TextBox();
            this.Ten = new System.Windows.Forms.TextBox();
            this.exit = new System.Windows.Forms.Button();
            this.xacnhan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã công dụng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên công dụng";
            // 
            // Ma
            // 
            this.Ma.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ma.Location = new System.Drawing.Point(114, 47);
            this.Ma.Multiline = true;
            this.Ma.Name = "Ma";
            this.Ma.Size = new System.Drawing.Size(237, 50);
            this.Ma.TabIndex = 2;
            // 
            // Ten
            // 
            this.Ten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ten.Location = new System.Drawing.Point(114, 179);
            this.Ten.Multiline = true;
            this.Ten.Name = "Ten";
            this.Ten.Size = new System.Drawing.Size(237, 50);
            this.Ten.TabIndex = 3;
            // 
            // exit
            // 
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exit.Image = global::BTL_LTTQ_VIP.Properties.Resources.undo;
            this.exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exit.Location = new System.Drawing.Point(256, 3);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(178, 60);
            this.exit.TabIndex = 5;
            this.exit.Text = "Quay Lại";
            this.exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // xacnhan
            // 
            this.xacnhan.FlatAppearance.BorderSize = 0;
            this.xacnhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.xacnhan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.xacnhan.Image = global::BTL_LTTQ_VIP.Properties.Resources.xacnhan;
            this.xacnhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xacnhan.Location = new System.Drawing.Point(26, 3);
            this.xacnhan.Name = "xacnhan";
            this.xacnhan.Size = new System.Drawing.Size(158, 60);
            this.xacnhan.TabIndex = 6;
            this.xacnhan.Text = "Xác Nhận";
            this.xacnhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xacnhan.UseVisualStyleBackColor = true;
            this.xacnhan.Click += new System.EventHandler(this.xacnhan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.exit);
            this.panel1.Controls.Add(this.xacnhan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 66);
            this.panel1.TabIndex = 7;
            // 
            // ThemCongDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 341);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Ten);
            this.Controls.Add(this.Ma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThemCongDung";
            this.Text = "Thêm Công Dụng";
            this.Load += new System.EventHandler(this.ThemCongDung_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Ma;
        private System.Windows.Forms.TextBox Ten;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button xacnhan;
        private System.Windows.Forms.Panel panel1;
    }
}