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
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tên Khách Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Mã Khách Hàng";
            // 
            // listViewKetQuaKH
            // 
            this.listViewKetQuaKH.HideSelection = false;
            this.listViewKetQuaKH.Location = new System.Drawing.Point(22, 120);
            this.listViewKetQuaKH.Name = "listViewKetQuaKH";
            this.listViewKetQuaKH.Size = new System.Drawing.Size(710, 92);
            this.listViewKetQuaKH.TabIndex = 32;
            this.listViewKetQuaKH.UseCompatibleStateImageBehavior = false;
            this.listViewKetQuaKH.SelectedIndexChanged += new System.EventHandler(this.listViewKetQuaKH_SelectedIndexChanged);
            // 
            // btnexit
            // 
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnexit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnexit.Image = global::BTL_LTTQ_VIP.Properties.Resources.undo;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(264, 3);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(183, 51);
            this.btnexit.TabIndex = 31;
            this.btnexit.Text = "Quay Lại";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // comboBoxTenKH
            // 
            this.comboBoxTenKH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTenKH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTenKH.FormattingEnabled = true;
            this.comboBoxTenKH.Location = new System.Drawing.Point(215, 60);
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
            this.comboBoxMaKH.Location = new System.Drawing.Point(215, 17);
            this.comboBoxMaKH.Name = "comboBoxMaKH";
            this.comboBoxMaKH.Size = new System.Drawing.Size(109, 24);
            this.comboBoxMaKH.TabIndex = 29;
            this.comboBoxMaKH.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaKH_SelectedIndexChanged);
            // 
            // buttonTimKH
            // 
            this.buttonTimKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTimKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonTimKH.Image = global::BTL_LTTQ_VIP.Properties.Resources.find1;
            this.buttonTimKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTimKH.Location = new System.Drawing.Point(460, 42);
            this.buttonTimKH.Name = "buttonTimKH";
            this.buttonTimKH.Size = new System.Drawing.Size(115, 42);
            this.buttonTimKH.TabIndex = 28;
            this.buttonTimKH.Text = "Tìm ";
            this.buttonTimKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTimKH.UseVisualStyleBackColor = true;
            this.buttonTimKH.Click += new System.EventHandler(this.buttonTimKH_Click);
            // 
            // listViewLichSuMua
            // 
            this.listViewLichSuMua.HideSelection = false;
            this.listViewLichSuMua.Location = new System.Drawing.Point(12, 21);
            this.listViewLichSuMua.Name = "listViewLichSuMua";
            this.listViewLichSuMua.Size = new System.Drawing.Size(710, 217);
            this.listViewLichSuMua.TabIndex = 35;
            this.listViewLichSuMua.UseCompatibleStateImageBehavior = false;
            this.listViewLichSuMua.SelectedIndexChanged += new System.EventHandler(this.listViewLichSuMua_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 66);
            this.panel1.TabIndex = 36;
            this.panel1.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(10, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 134);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewLichSuMua);
            this.groupBox2.Location = new System.Drawing.Point(10, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(735, 244);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lịch Sử Mua Hàng";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // TimKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewKetQuaKH);
            this.Controls.Add(this.comboBoxTenKH);
            this.Controls.Add(this.comboBoxMaKH);
            this.Controls.Add(this.buttonTimKH);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "TimKhachHang";
            this.Text = "TimKhachHang";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}