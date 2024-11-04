namespace BTL_LTTQ_VIP
{
    partial class TimNhanVien
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
            this.listViewKetQuaNV = new System.Windows.Forms.ListView();
            this.btnexit = new System.Windows.Forms.Button();
            this.comboBoxTenNV = new System.Windows.Forms.ComboBox();
            this.comboBoxMaNV = new System.Windows.Forms.ComboBox();
            this.buttonTimNV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewKetQuaNV
            // 
            this.listViewKetQuaNV.HideSelection = false;
            this.listViewKetQuaNV.Location = new System.Drawing.Point(17, 193);
            this.listViewKetQuaNV.Name = "listViewKetQuaNV";
            this.listViewKetQuaNV.Size = new System.Drawing.Size(838, 387);
            this.listViewKetQuaNV.TabIndex = 25;
            this.listViewKetQuaNV.UseCompatibleStateImageBehavior = false;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(543, 83);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 24;
            this.btnexit.Text = "Thoát";
            this.btnexit.UseVisualStyleBackColor = true;
            // 
            // comboBoxTenNV
            // 
            this.comboBoxTenNV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTenNV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTenNV.FormattingEnabled = true;
            this.comboBoxTenNV.Location = new System.Drawing.Point(566, 37);
            this.comboBoxTenNV.Name = "comboBoxTenNV";
            this.comboBoxTenNV.Size = new System.Drawing.Size(179, 24);
            this.comboBoxTenNV.TabIndex = 23;
            this.comboBoxTenNV.SelectedIndexChanged += new System.EventHandler(this.comboBoxTenNV_SelectedIndexChanged);
            // 
            // comboBoxMaNV
            // 
            this.comboBoxMaNV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMaNV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMaNV.FormattingEnabled = true;
            this.comboBoxMaNV.Location = new System.Drawing.Point(279, 37);
            this.comboBoxMaNV.Name = "comboBoxMaNV";
            this.comboBoxMaNV.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMaNV.TabIndex = 22;
            this.comboBoxMaNV.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaNV_SelectedIndexChanged);
            // 
            // buttonTimNV
            // 
            this.buttonTimNV.Location = new System.Drawing.Point(308, 83);
            this.buttonTimNV.Name = "buttonTimNV";
            this.buttonTimNV.Size = new System.Drawing.Size(75, 23);
            this.buttonTimNV.TabIndex = 21;
            this.buttonTimNV.Text = "Tìm ";
            this.buttonTimNV.UseVisualStyleBackColor = true;
            this.buttonTimNV.Click += new System.EventHandler(this.buttonTimNV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mã Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tên Nhân Viên";
            // 
            // TimNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 617);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewKetQuaNV);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.comboBoxTenNV);
            this.Controls.Add(this.comboBoxMaNV);
            this.Controls.Add(this.buttonTimNV);
            this.Name = "TimNhanVien";
            this.Text = "TimNhanVien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewKetQuaNV;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.ComboBox comboBoxTenNV;
        private System.Windows.Forms.ComboBox comboBoxMaNV;
        private System.Windows.Forms.Button buttonTimNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}