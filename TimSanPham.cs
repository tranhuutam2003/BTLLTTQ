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
    public partial class TimSanPham : Form
    {
        public TimSanPham()
        {
            InitializeComponent();
            LoadComboBoxData();
            // Thiết lập chế độ gợi ý cho ComboBox
            comboBoxTenHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxTenHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxMaHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxMaHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            // Thiết lập ListView
            listViewKetQua.View = View.Details;
            listViewKetQua.Columns.Add("Mã Hàng", 80);
            listViewKetQua.Columns.Add("Tên Hàng", 150);
            listViewKetQua.Columns.Add("Số Lượng Còn Lại", 70);
            listViewKetQua.Columns.Add("Đơn Giá Nhập", 100);
            listViewKetQua.Columns.Add("Đơn Giá Bán", 100);
            listViewKetQua.Columns.Add("Thời Gian Bảo Hành", 120);
        }
        private BindingSource bindingSourceMaHang = new BindingSource();
        private BindingSource bindingSourceTenHang = new BindingSource();



        private void LoadComboBoxData()
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();
                // Lấy dữ liệu cho ComboBox TenHang
                using (SqlCommand cmd = new SqlCommand("SELECT MaHang, TenHang FROM DanhMucHangHoa", conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    bindingSourceMaHang.DataSource = dt;
                    bindingSourceTenHang.DataSource = dt.Copy();
                    // Gán BindingSource vào ComboBox
                    comboBoxMaHang.DataSource = bindingSourceMaHang;
                    comboBoxMaHang.DisplayMember = "MaHang";
                    comboBoxMaHang.ValueMember = "MaHang";
                    comboBoxTenHang.DataSource = bindingSourceTenHang;
                    comboBoxTenHang.DisplayMember = "TenHang";
                    comboBoxTenHang.ValueMember = "MaHang";
                }
            }
            comboBoxMaHang.SelectedIndexChanged += comboBoxMaHang_SelectedIndexChanged;
            comboBoxTenHang.SelectedIndexChanged += comboBoxTenHang_SelectedIndexChanged;
        }

        private void buttonTim_Click(object sender, EventArgs e)
        {
            {
                string maHang = comboBoxMaHang.SelectedValue?.ToString();
                string tenHang = comboBoxTenHang.Text;
                using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
                {
                    conn.Open();
                    // Xây dựng câu lệnh truy vấn
                    string query = "SELECT MaHang, TenHang, SoLuong, DonGiaNhap, DonGiaBan, ThoiGianBaoHanh FROM DanhMucHangHoa WHERE 1=1";
                    if (!string.IsNullOrEmpty(maHang))
                    {
                        query += " AND MaHang = @MaHang";
                    }
                    if (!string.IsNullOrEmpty(tenHang))
                    {
                        query += " AND TenHang LIKE '%' + @TenHang + '%'";
                    }
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(maHang))
                        {
                            cmd.Parameters.AddWithValue("@MaHang", maHang);
                        }
                        if (!string.IsNullOrEmpty(tenHang))
                        {
                            cmd.Parameters.AddWithValue("@TenHang", tenHang);
                        }
                        SqlDataReader reader = cmd.ExecuteReader();
                        // Xóa dữ liệu cũ trong ListView
                        listViewKetQua.Items.Clear();
                        // Thêm dữ liệu mới vào ListView
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["MaHang"].ToString());
                            item.SubItems.Add(reader["TenHang"].ToString());
                            item.SubItems.Add(reader["SoLuong"].ToString());
                            item.SubItems.Add(reader["DonGiaNhap"].ToString());
                            item.SubItems.Add(reader["DonGiaBan"].ToString());
                            item.SubItems.Add(reader["ThoiGianBaoHanh"].ToString());
                            listViewKetQua.Items.Add(item);
                        }
                        reader.Close();
                    }
                }
            }
        }

        private void comboBoxTenHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenHang.SelectedValue != null)
            {
                // Lấy mã hàng hiện tại từ ComboBoxTenHang
                string selectedMaHang = comboBoxTenHang.SelectedValue.ToString();
                // Duyệt qua DataTable của BindingSource để tìm vị trí có MaHang tương ứng
                DataTable dtMaHang = ((DataTable)bindingSourceMaHang.DataSource);
                for (int i = 0; i < dtMaHang.Rows.Count; i++)
                {
                    if (dtMaHang.Rows[i]["MaHang"].ToString() == selectedMaHang)
                    {
                        comboBoxMaHang.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void comboBoxMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaHang.SelectedValue != null)
            {
                // Lấy mã hàng hiện tại từ ComboBoxMaHang
                string selectedMaHang = comboBoxMaHang.SelectedValue.ToString();
                // Duyệt qua DataTable của BindingSource để tìm vị trí có MaHang tương ứng
                DataTable dtTenHang = ((DataTable)bindingSourceTenHang.DataSource);
                for (int i = 0; i < dtTenHang.Rows.Count; i++)
                {
                    if (dtTenHang.Rows[i]["MaHang"].ToString() == selectedMaHang)
                    {
                        comboBoxTenHang.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}
