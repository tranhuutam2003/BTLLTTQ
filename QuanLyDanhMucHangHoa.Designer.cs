namespace BTL_LTTQ_VIP
{
    partial class QuanLyDanhMucHangHoa
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
            this.Exit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Them = new System.Windows.Forms.Button();
            this.Sua = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.Xoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1399, 441);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // Exit
            // 
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Exit.Image = global::BTL_LTTQ_VIP.Properties.Resources.undo;
            this.Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Exit.Location = new System.Drawing.Point(1244, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(129, 59);
            this.Exit.TabIndex = 5;
            this.Exit.Text = "Trở lại";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.Them);
            this.panel1.Controls.Add(this.Sua);
            this.panel1.Controls.Add(this.Exit);
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.Xoa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 443);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1398, 66);
            this.panel1.TabIndex = 8;
            // 
            // Them
            // 
            this.Them.FlatAppearance.BorderSize = 0;
            this.Them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Them.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Them.Image = global::BTL_LTTQ_VIP.Properties.Resources.add1;
            this.Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Them.Location = new System.Drawing.Point(12, 0);
            this.Them.Name = "Them";
            this.Them.Size = new System.Drawing.Size(200, 59);
            this.Them.TabIndex = 2;
            this.Them.Text = "Thêm hàng hóa";
            this.Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Them.UseVisualStyleBackColor = true;
            this.Them.Click += new System.EventHandler(this.Them_Click);
            // 
            // Sua
            // 
            this.Sua.FlatAppearance.BorderSize = 0;
            this.Sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Sua.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Sua.Image = global::BTL_LTTQ_VIP.Properties.Resources.sua;
            this.Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Sua.Location = new System.Drawing.Point(314, 0);
            this.Sua.Name = "Sua";
            this.Sua.Size = new System.Drawing.Size(187, 59);
            this.Sua.TabIndex = 3;
            this.Sua.Text = "Sửa hàng hóa";
            this.Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Sua.UseVisualStyleBackColor = true;
            this.Sua.Click += new System.EventHandler(this.Sua_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXuatExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXuatExcel.Image = global::BTL_LTTQ_VIP.Properties.Resources.excel;
            this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatExcel.Location = new System.Drawing.Point(932, 0);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(187, 59);
            this.btnXuatExcel.TabIndex = 7;
            this.btnXuatExcel.Text = "Xuất File Excel";
            this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // Xoa
            // 
            this.Xoa.FlatAppearance.BorderSize = 0;
            this.Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Xoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Xoa.Image = global::BTL_LTTQ_VIP.Properties.Resources.delete;
            this.Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Xoa.Location = new System.Drawing.Point(610, -2);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(184, 62);
            this.Xoa.TabIndex = 4;
            this.Xoa.Text = "Xóa hàng hóa";
            this.Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Xoa.UseVisualStyleBackColor = true;
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // QuanLyDanhMucHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 509);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QuanLyDanhMucHangHoa";
            this.Text = "Quản Lý Danh Mục Hàng Hóa";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Them;
        private System.Windows.Forms.Button Sua;
        private System.Windows.Forms.Button Xoa;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Panel panel1;
    }
}