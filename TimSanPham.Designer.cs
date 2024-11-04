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
            this.SuspendLayout();
            // 
            // listViewKetQua
            // 
            this.listViewKetQua.HideSelection = false;
            this.listViewKetQua.Location = new System.Drawing.Point(40, 199);
            this.listViewKetQua.Name = "listViewKetQua";
            this.listViewKetQua.Size = new System.Drawing.Size(943, 387);
            this.listViewKetQua.TabIndex = 20;
            this.listViewKetQua.UseCompatibleStateImageBehavior = false;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(617, 89);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 19;
            this.btnexit.Text = "Thoát";
            this.btnexit.UseVisualStyleBackColor = true;
            // 
            // comboBoxMaHang
            // 
            this.comboBoxMaHang.FormattingEnabled = true;
            this.comboBoxMaHang.Location = new System.Drawing.Point(593, 43);
            this.comboBoxMaHang.Name = "comboBoxMaHang";
            this.comboBoxMaHang.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMaHang.TabIndex = 18;
            this.comboBoxMaHang.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaHang_SelectedIndexChanged);
            // 
            // comboBoxTenHang
            // 
            this.comboBoxTenHang.FormattingEnabled = true;
            this.comboBoxTenHang.Location = new System.Drawing.Point(392, 43);
            this.comboBoxTenHang.Name = "comboBoxTenHang";
            this.comboBoxTenHang.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTenHang.TabIndex = 17;
            this.comboBoxTenHang.SelectedIndexChanged += new System.EventHandler(this.comboBoxTenHang_SelectedIndexChanged);
            // 
            // buttonTim
            // 
            this.buttonTim.Location = new System.Drawing.Point(382, 89);
            this.buttonTim.Name = "buttonTim";
            this.buttonTim.Size = new System.Drawing.Size(75, 23);
            this.buttonTim.TabIndex = 16;
            this.buttonTim.Text = "Tìm ";
            this.buttonTim.UseVisualStyleBackColor = true;
            this.buttonTim.Click += new System.EventHandler(this.buttonTim_Click);
            // 
            // TimSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 628);
            this.Controls.Add(this.listViewKetQua);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.comboBoxMaHang);
            this.Controls.Add(this.comboBoxTenHang);
            this.Controls.Add(this.buttonTim);
            this.Name = "TimSanPham";
            this.Text = "TimSanPham";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewKetQua;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.ComboBox comboBoxMaHang;
        private System.Windows.Forms.ComboBox comboBoxTenHang;
        private System.Windows.Forms.Button buttonTim;
    }
}