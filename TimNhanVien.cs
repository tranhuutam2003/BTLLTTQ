using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class TimNhanVien : Form
    {

        private BindingSource bindingSourceMaNV = new BindingSource();
        private BindingSource bindingSourceTenNV = new BindingSource();
        public TimNhanVien()
        {
            InitializeComponent();
            LoadComboBoxDataNV();

            

            // Thiết lập ListView cho nhân viên
            listViewKetQuaNV.View = View.Details;
            listViewKetQuaNV.Columns.Add("Mã NV", 80);
            listViewKetQuaNV.Columns.Add("Tên NV", 150);
            listViewKetQuaNV.Columns.Add("Giới Tính", 70);
            listViewKetQuaNV.Columns.Add("Ngày Sinh", 100);
            listViewKetQuaNV.Columns.Add("Điện Thoại", 100);
            listViewKetQuaNV.Columns.Add("Địa Chỉ", 120);
        }
        

        private void LoadComboBoxDataNV()
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT MaNV, TenNV FROM NhanVien", conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    bindingSourceMaNV.DataSource = dt;
                    bindingSourceTenNV.DataSource = dt.Copy();

                    comboBoxMaNV.DataSource = bindingSourceMaNV;
                    comboBoxMaNV.DisplayMember = "MaNV";
                    comboBoxMaNV.ValueMember = "MaNV";

                    comboBoxTenNV.DataSource = bindingSourceTenNV;
                    comboBoxTenNV.DisplayMember = "TenNV";
                    comboBoxTenNV.ValueMember = "MaNV";
                }
            }
            comboBoxMaNV.SelectedIndexChanged += comboBoxMaNV_SelectedIndexChanged;
            comboBoxTenNV.SelectedIndexChanged += comboBoxTenNV_SelectedIndexChanged;
        }
        private void buttonTimNV_Click(object sender, EventArgs e)
        {
            string maNV = comboBoxMaNV.SelectedValue?.ToString();
            string tenNV = comboBoxTenNV.Text;

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();

                // Xây dựng câu truy vấn
                string query = "SELECT MaNV, TenNV, GioiTinh, NgaySinh, DienThoai, DiaChi FROM NhanVien WHERE 1=1";
                if (!string.IsNullOrEmpty(maNV))
                {
                    query += " AND MaNV = @MaNV";
                }
                if (!string.IsNullOrEmpty(tenNV))
                {
                    query += " AND TenNV LIKE '%' + @TenNV + '%'";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(maNV))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                    }
                    if (!string.IsNullOrEmpty(tenNV))
                    {
                        cmd.Parameters.AddWithValue("@TenNV", tenNV);
                    }

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Xóa dữ liệu cũ trong ListView
                    listViewKetQuaNV.Items.Clear();

                    // Thêm dữ liệu mới vào ListView
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaNV"].ToString());
                        item.SubItems.Add(reader["TenNV"].ToString());
                        item.SubItems.Add(reader["GioiTinh"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy"));
                        item.SubItems.Add(reader["DienThoai"].ToString());
                        item.SubItems.Add(reader["DiaChi"].ToString());
                        listViewKetQuaNV.Items.Add(item);
                    }

                    reader.Close();
                }
            }
        }

        private void comboBoxMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaNV.SelectedValue != null)
            {
                string selectedMaNV = comboBoxMaNV.SelectedValue.ToString();
                DataTable dtTenNV = ((DataTable)bindingSourceTenNV.DataSource);
                for (int i = 0; i < dtTenNV.Rows.Count; i++)
                {
                    if (dtTenNV.Rows[i]["MaNV"].ToString() == selectedMaNV)
                    {
                        comboBoxTenNV.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void comboBoxTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenNV.SelectedValue != null)
            {
                string selectedMaNV = comboBoxTenNV.SelectedValue.ToString();
                DataTable dtMaNV = ((DataTable)bindingSourceMaNV.DataSource);
                for (int i = 0; i < dtMaNV.Rows.Count; i++)
                {
                    if (dtMaNV.Rows[i]["MaNV"].ToString() == selectedMaNV)
                    {
                        comboBoxMaNV.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
