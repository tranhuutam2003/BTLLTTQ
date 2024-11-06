namespace BTL_LTTQ_VIP
{
    partial class QuanLyKhachHang
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.themKH = new System.Windows.Forms.Button();
            this.suaKH = new System.Windows.Forms.Button();
            this.xoaKH = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(811, 391);
            this.dataGridView1.TabIndex = 0;
            // 
            // themKH
            // 
            this.themKH.FlatAppearance.BorderSize = 0;
            this.themKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.themKH.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.themKH.Image = global::BTL_LTTQ_VIP.Properties.Resources.add;
            this.themKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.themKH.Location = new System.Drawing.Point(12, 1);
            this.themKH.Name = "themKH";
            this.themKH.Size = new System.Drawing.Size(194, 60);
            this.themKH.TabIndex = 3;
            this.themKH.Text = "Thêm khách hàng";
            this.themKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.themKH.UseVisualStyleBackColor = true;
            this.themKH.Click += new System.EventHandler(this.themKH_Click);
            // 
            // suaKH
            // 
            this.suaKH.FlatAppearance.BorderSize = 0;
            this.suaKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.suaKH.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.suaKH.Image = global::BTL_LTTQ_VIP.Properties.Resources.sua;
            this.suaKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.suaKH.Location = new System.Drawing.Point(241, 5);
            this.suaKH.Name = "suaKH";
            this.suaKH.Size = new System.Drawing.Size(162, 52);
            this.suaKH.TabIndex = 4;
            this.suaKH.Text = "Sửa thông tin";
            this.suaKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.suaKH.UseVisualStyleBackColor = true;
            this.suaKH.Click += new System.EventHandler(this.suaKH_Click);
            // 
            // xoaKH
            // 
            this.xoaKH.FlatAppearance.BorderSize = 0;
            this.xoaKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xoaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.xoaKH.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.xoaKH.Image = global::BTL_LTTQ_VIP.Properties.Resources.delete;
            this.xoaKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xoaKH.Location = new System.Drawing.Point(459, 3);
            this.xoaKH.Name = "xoaKH";
            this.xoaKH.Size = new System.Drawing.Size(180, 57);
            this.xoaKH.TabIndex = 5;
            this.xoaKH.Text = "Xóa khách hàng";
            this.xoaKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xoaKH.UseVisualStyleBackColor = true;
            this.xoaKH.Click += new System.EventHandler(this.xoaKH_Click);
            // 
            // exit
            // 
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exit.Image = global::BTL_LTTQ_VIP.Properties.Resources.undo;
            this.exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exit.Location = new System.Drawing.Point(666, 1);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(120, 63);
            this.exit.TabIndex = 6;
            this.exit.Text = "Trở lại";
            this.exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.exit);
            this.panel1.Controls.Add(this.themKH);
            this.panel1.Controls.Add(this.xoaKH);
            this.panel1.Controls.Add(this.suaKH);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 66);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // QuanLyKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 459);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "QuanLyKhachHang";
            this.Text = "QuanLyKhachHang";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button themKH;
        private System.Windows.Forms.Button suaKH;
        private System.Windows.Forms.Button xoaKH;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Panel panel1;
    }
}