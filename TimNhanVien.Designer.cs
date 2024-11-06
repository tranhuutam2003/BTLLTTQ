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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewKetQuaNV
            // 
            this.listViewKetQuaNV.HideSelection = false;
            this.listViewKetQuaNV.Location = new System.Drawing.Point(0, 133);
            this.listViewKetQuaNV.Name = "listViewKetQuaNV";
            this.listViewKetQuaNV.Size = new System.Drawing.Size(797, 169);
            this.listViewKetQuaNV.TabIndex = 25;
            this.listViewKetQuaNV.UseCompatibleStateImageBehavior = false;
            // 
            // btnexit
            // 
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnexit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnexit.Image = global::BTL_LTTQ_VIP.Properties.Resources.undo;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(290, 3);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(158, 60);
            this.btnexit.TabIndex = 24;
            this.btnexit.Text = "Quay Lại";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // comboBoxTenNV
            // 
            this.comboBoxTenNV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTenNV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTenNV.FormattingEnabled = true;
            this.comboBoxTenNV.Location = new System.Drawing.Point(211, 79);
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
            this.comboBoxMaNV.Location = new System.Drawing.Point(211, 20);
            this.comboBoxMaNV.Name = "comboBoxMaNV";
            this.comboBoxMaNV.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMaNV.TabIndex = 22;
            this.comboBoxMaNV.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaNV_SelectedIndexChanged);
            // 
            // buttonTimNV
            // 
            this.buttonTimNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTimNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonTimNV.Image = global::BTL_LTTQ_VIP.Properties.Resources.find1;
            this.buttonTimNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTimNV.Location = new System.Drawing.Point(415, 60);
            this.buttonTimNV.Name = "buttonTimNV";
            this.buttonTimNV.Size = new System.Drawing.Size(121, 43);
            this.buttonTimNV.TabIndex = 21;
            this.buttonTimNV.Text = "Tìm ";
            this.buttonTimNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTimNV.UseVisualStyleBackColor = true;
            this.buttonTimNV.Click += new System.EventHandler(this.buttonTimNV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mã Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tên Nhân Viên";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(55)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 306);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 66);
            this.panel1.TabIndex = 28;
            // 
            // TimNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 372);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewKetQuaNV);
            this.Controls.Add(this.comboBoxTenNV);
            this.Controls.Add(this.comboBoxMaNV);
            this.Controls.Add(this.buttonTimNV);
            this.Name = "TimNhanVien";
            this.Text = "TimNhanVien";
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
    }
}