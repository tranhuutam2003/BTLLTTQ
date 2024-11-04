namespace BTL_LTTQ_VIP
{
    partial class TimKhachHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.listViewKetQuaKH = new System.Windows.Forms.ListView();
            this.btnexit = new System.Windows.Forms.Button();
            this.comboBoxTenKH = new System.Windows.Forms.ComboBox();
            this.comboBoxMaKH = new System.Windows.Forms.ComboBox();
            this.buttonTimKH = new System.Windows.Forms.Button();
            this.listViewLichSuMua = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tên Nhân Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Mã Nhân Viên";
            // 
            // listViewKetQuaKH
            // 
            this.listViewKetQuaKH.HideSelection = false;
            this.listViewKetQuaKH.Location = new System.Drawing.Point(41, 213);
            this.listViewKetQuaKH.Name = "listViewKetQuaKH";
            this.listViewKetQuaKH.Size = new System.Drawing.Size(896, 131);
            this.listViewKetQuaKH.TabIndex = 32;
            this.listViewKetQuaKH.UseCompatibleStateImageBehavior = false;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(595, 114);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 31;
            this.btnexit.Text = "Thoát";
            this.btnexit.UseVisualStyleBackColor = true;
            // 
            // comboBoxTenKH
            // 
            this.comboBoxTenKH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTenKH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTenKH.FormattingEnabled = true;
            this.comboBoxTenKH.Location = new System.Drawing.Point(618, 68);
            this.comboBoxTenKH.Name = "comboBoxTenKH";
            this.comboBoxTenKH.Size = new System.Drawing.Size(179, 24);
            this.comboBoxTenKH.TabIndex = 30;
            this.comboBoxTenKH.SelectedIndexChanged += new System.EventHandler(this.comboBoxTenKH_SelectedIndexChanged);
            // 
            // comboBoxMaKH
            // 
            this.comboBoxMaKH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMaKH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMaKH.FormattingEnabled = true;
            this.comboBoxMaKH.Location = new System.Drawing.Point(331, 68);
            this.comboBoxMaKH.Name = "comboBoxMaKH";
            this.comboBoxMaKH.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMaKH.TabIndex = 29;
            this.comboBoxMaKH.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaKH_SelectedIndexChanged);
            // 
            // buttonTimKH
            // 
            this.buttonTimKH.Location = new System.Drawing.Point(360, 114);
            this.buttonTimKH.Name = "buttonTimKH";
            this.buttonTimKH.Size = new System.Drawing.Size(75, 23);
            this.buttonTimKH.TabIndex = 28;
            this.buttonTimKH.Text = "Tìm ";
            this.buttonTimKH.UseVisualStyleBackColor = true;
            this.buttonTimKH.Click += new System.EventHandler(this.buttonTimKH_Click);
            // 
            // listViewLichSuMua
            // 
            this.listViewLichSuMua.HideSelection = false;
            this.listViewLichSuMua.Location = new System.Drawing.Point(41, 380);
            this.listViewLichSuMua.Name = "listViewLichSuMua";
            this.listViewLichSuMua.Size = new System.Drawing.Size(896, 208);
            this.listViewLichSuMua.TabIndex = 35;
            this.listViewLichSuMua.UseCompatibleStateImageBehavior = false;
            // 
            // TimKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 679);
            this.Controls.Add(this.listViewLichSuMua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewKetQuaKH);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.comboBoxTenKH);
            this.Controls.Add(this.comboBoxMaKH);
            this.Controls.Add(this.buttonTimKH);
            this.Name = "TimKhachHang";
            this.Text = "TimKhachHang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewKetQuaKH;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.ComboBox comboBoxTenKH;
        private System.Windows.Forms.ComboBox comboBoxMaKH;
        private System.Windows.Forms.Button buttonTimKH;
        private System.Windows.Forms.ListView listViewLichSuMua;
    }
}