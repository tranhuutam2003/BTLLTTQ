namespace BTL_LTTQ_VIP
{
    partial class QuanLyNhanVien
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnbaocao = new System.Windows.Forms.Button();
            this.SuaNV = new System.Windows.Forms.Button();
            this.exitNV = new System.Windows.Forms.Button();
            this.ThemNV = new System.Windows.Forms.Button();
            this.XoaNV = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.btnbaocao);
            this.panel1.Controls.Add(this.SuaNV);
            this.panel1.Controls.Add(this.exitNV);
            this.panel1.Controls.Add(this.ThemNV);
            this.panel1.Controls.Add(this.XoaNV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 344);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 66);
            this.panel1.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, -2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1161, 344);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnbaocao
            // 
            this.btnbaocao.FlatAppearance.BorderSize = 0;
            this.btnbaocao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnbaocao.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnbaocao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbaocao.Location = new System.Drawing.Point(759, 2);
            this.btnbaocao.Name = "btnbaocao";
            this.btnbaocao.Size = new System.Drawing.Size(195, 58);
            this.btnbaocao.TabIndex = 6;
            this.btnbaocao.Text = "Báo cáo nhân viên";
            this.btnbaocao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbaocao.UseVisualStyleBackColor = true;
            this.btnbaocao.Click += new System.EventHandler(this.btnbaocao_Click);
            // 
            // SuaNV
            // 
            this.SuaNV.FlatAppearance.BorderSize = 0;
            this.SuaNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SuaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.SuaNV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SuaNV.Image = global::BTL_LTTQ_VIP.Properties.Resources.sua;
            this.SuaNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SuaNV.Location = new System.Drawing.Point(237, 0);
            this.SuaNV.Name = "SuaNV";
            this.SuaNV.Size = new System.Drawing.Size(272, 62);
            this.SuaNV.TabIndex = 2;
            this.SuaNV.Text = "Sửa thông tin nhân viên";
            this.SuaNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SuaNV.UseVisualStyleBackColor = true;
            this.SuaNV.Click += new System.EventHandler(this.SuaNV_Click);
            // 
            // exitNV
            // 
            this.exitNV.FlatAppearance.BorderSize = 0;
            this.exitNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.exitNV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exitNV.Image = global::BTL_LTTQ_VIP.Properties.Resources.undo;
            this.exitNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitNV.Location = new System.Drawing.Point(991, 0);
            this.exitNV.Name = "exitNV";
            this.exitNV.Size = new System.Drawing.Size(145, 62);
            this.exitNV.TabIndex = 5;
            this.exitNV.Text = "Quay lại";
            this.exitNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitNV.UseVisualStyleBackColor = true;
            this.exitNV.Click += new System.EventHandler(this.exitNV_Click);
            // 
            // ThemNV
            // 
            this.ThemNV.FlatAppearance.BorderSize = 0;
            this.ThemNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThemNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ThemNV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ThemNV.Image = global::BTL_LTTQ_VIP.Properties.Resources.add2;
            this.ThemNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThemNV.Location = new System.Drawing.Point(27, -2);
            this.ThemNV.Name = "ThemNV";
            this.ThemNV.Size = new System.Drawing.Size(204, 66);
            this.ThemNV.TabIndex = 1;
            this.ThemNV.Text = "Thêm nhân viên";
            this.ThemNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ThemNV.UseVisualStyleBackColor = true;
            this.ThemNV.Click += new System.EventHandler(this.ThemNV_Click);
            // 
            // XoaNV
            // 
            this.XoaNV.FlatAppearance.BorderSize = 0;
            this.XoaNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XoaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.XoaNV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.XoaNV.Image = global::BTL_LTTQ_VIP.Properties.Resources.delete;
            this.XoaNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.XoaNV.Location = new System.Drawing.Point(515, 2);
            this.XoaNV.Name = "XoaNV";
            this.XoaNV.Size = new System.Drawing.Size(195, 58);
            this.XoaNV.TabIndex = 3;
            this.XoaNV.Text = "Xóa nhân viên";
            this.XoaNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.XoaNV.UseVisualStyleBackColor = true;
            this.XoaNV.Click += new System.EventHandler(this.XoaNV_Click);
            // 
            // QuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 410);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "QuanLyNhanVien";
            this.Text = "Quản Lý Nhân Viên";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ThemNV;
        private System.Windows.Forms.Button SuaNV;
        private System.Windows.Forms.Button XoaNV;
        private System.Windows.Forms.Button exitNV;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnbaocao;
    }
}

