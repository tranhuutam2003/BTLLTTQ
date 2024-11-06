namespace BTL_LTTQ_VIP
{
    partial class TimSanPham
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
            this.listViewKetQua = new System.Windows.Forms.ListView();
            this.btnexit = new System.Windows.Forms.Button();
            this.comboBoxMaHang = new System.Windows.Forms.ComboBox();
            this.comboBoxTenHang = new System.Windows.Forms.ComboBox();
            this.buttonTim = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewKetQua
            // 
            this.listViewKetQua.HideSelection = false;
            this.listViewKetQua.Location = new System.Drawing.Point(0, 131);
            this.listViewKetQua.Name = "listViewKetQua";
            this.listViewKetQua.Size = new System.Drawing.Size(851, 194);
            this.listViewKetQua.TabIndex = 20;
            this.listViewKetQua.UseCompatibleStateImageBehavior = false;
            // 
            // btnexit
            // 
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnexit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnexit.Image = global::BTL_LTTQ_VIP.Properties.Resources.undo;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(319, 0);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(161, 60);
            this.btnexit.TabIndex = 19;
            this.btnexit.Text = "Thoát";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // comboBoxMaHang
            // 
            this.comboBoxMaHang.FormattingEnabled = true;
            this.comboBoxMaHang.Location = new System.Drawing.Point(178, 29);
            this.comboBoxMaHang.Name = "comboBoxMaHang";
            this.comboBoxMaHang.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMaHang.TabIndex = 18;
            this.comboBoxMaHang.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaHang_SelectedIndexChanged);
            // 
            // comboBoxTenHang
            // 
            this.comboBoxTenHang.FormattingEnabled = true;
            this.comboBoxTenHang.Location = new System.Drawing.Point(178, 88);
            this.comboBoxTenHang.Name = "comboBoxTenHang";
            this.comboBoxTenHang.Size = new System.Drawing.Size(202, 24);
            this.comboBoxTenHang.TabIndex = 17;
            this.comboBoxTenHang.SelectedIndexChanged += new System.EventHandler(this.comboBoxTenHang_SelectedIndexChanged);
            // 
            // buttonTim
            // 
            this.buttonTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonTim.Image = global::BTL_LTTQ_VIP.Properties.Resources.find1;
            this.buttonTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTim.Location = new System.Drawing.Point(477, 69);
            this.buttonTim.Name = "buttonTim";
            this.buttonTim.Size = new System.Drawing.Size(121, 43);
            this.buttonTim.TabIndex = 16;
            this.buttonTim.Text = "Tìm ";
            this.buttonTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTim.UseVisualStyleBackColor = true;
            this.buttonTim.Click += new System.EventHandler(this.buttonTim_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 329);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 66);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Mã Sản Phẩm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tên Sản Phẩm";
            // 
            // TimSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 395);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewKetQua);
            this.Controls.Add(this.comboBoxMaHang);
            this.Controls.Add(this.comboBoxTenHang);
            this.Controls.Add(this.buttonTim);
            this.Name = "TimSanPham";
            this.Text = "TimSanPham";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewKetQua;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.ComboBox comboBoxMaHang;
        private System.Windows.Forms.ComboBox comboBoxTenHang;
        private System.Windows.Forms.Button buttonTim;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}