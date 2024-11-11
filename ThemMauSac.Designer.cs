namespace BTL_LTTQ_VIP
{
    partial class ThemMauSac
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Ma = new System.Windows.Forms.TextBox();
            this.Ten = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.dgvMauSac = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMauSac)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã màu sắc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên màu sắc";
            // 
            // Ma
            // 
            this.Ma.Location = new System.Drawing.Point(16, 32);
            this.Ma.Name = "Ma";
            this.Ma.ReadOnly = true;
            this.Ma.Size = new System.Drawing.Size(250, 22);
            this.Ma.TabIndex = 3;
            this.Ma.TextChanged += new System.EventHandler(this.Ma_TextChanged);
            // 
            // Ten
            // 
            this.Ten.Location = new System.Drawing.Point(16, 80);
            this.Ten.Name = "Ten";
            this.Ten.Size = new System.Drawing.Size(250, 22);
            this.Ten.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = global::BTL_LTTQ_VIP.Properties.Resources.xacnhan;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(3, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 51);
            this.button1.TabIndex = 5;
            this.button1.Text = "Xác nhận";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.btnxoa);
            this.panel1.Controls.Add(this.btnsua);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 337);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 66);
            this.panel1.TabIndex = 7;
            // 
            // btnxoa
            // 
            this.btnxoa.FlatAppearance.BorderSize = 0;
            this.btnxoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnxoa.Image = global::BTL_LTTQ_VIP.Properties.Resources.delete;
            this.btnxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxoa.Location = new System.Drawing.Point(566, 12);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(137, 42);
            this.btnxoa.TabIndex = 7;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.FlatAppearance.BorderSize = 0;
            this.btnsua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnsua.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsua.Image = global::BTL_LTTQ_VIP.Properties.Resources.sua;
            this.btnsua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsua.Location = new System.Drawing.Point(285, 12);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(129, 42);
            this.btnsua.TabIndex = 6;
            this.btnsua.Text = "Sửa";
            this.btnsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvMauSac
            // 
            this.dgvMauSac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMauSac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMauSac.Location = new System.Drawing.Point(309, 20);
            this.dgvMauSac.Name = "dgvMauSac";
            this.dgvMauSac.RowHeadersWidth = 51;
            this.dgvMauSac.RowTemplate.Height = 24;
            this.dgvMauSac.Size = new System.Drawing.Size(394, 290);
            this.dgvMauSac.TabIndex = 8;
            // 
            // ThemMauSac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 403);
            this.Controls.Add(this.dgvMauSac);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Ten);
            this.Controls.Add(this.Ma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ThemMauSac";
            this.Text = "Thêm Màu Sắc";
            this.Load += new System.EventHandler(this.ThemMauSac_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMauSac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Ma;
        private System.Windows.Forms.TextBox Ten;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMauSac;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
    }
}