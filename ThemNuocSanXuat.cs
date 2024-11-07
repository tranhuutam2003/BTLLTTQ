using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemNuocSanXuat : Form
    {
        public ThemNuocSanXuat()
        {
            InitializeComponent();
            LoadData();
            dgvNuocSX.CellClick += dgvNuocSX_CellClick; // Attach the CellClick event
        }

        // Method to load data into the DataGridView
        public void LoadData()
        {
            // Clear any existing data in the DataGridView before reloading
            dgvNuocSX.Rows.Clear();

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaNuocSX, TenNuocSX FROM NuocSanXuat";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvNuocSX.DataSource = dt; // Set DataGridView's data source to DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Nước Sản Xuất: " + ex.Message);
                }
            }
        }

        // Button click event to add a new "NuocSanXuat"
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ mã và tên Nước Sản Xuất.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO NuocSanXuat (MaNuocSX, TenNuocSX) VALUES (@MaNuocSX, @TenNuocSX)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNuocSX", Ma.Text);
                        command.Parameters.AddWithValue("@TenNuocSX", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm Nước Sản Xuất thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm Nước Sản Xuất: " + ex.Message);
                }
            }
        }

        // Button click event to edit an existing "NuocSanXuat"
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng chọn một Nước Sản Xuất để sửa và điền đầy đủ mã và tên.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE NuocSanXuat SET TenNuocSX = @TenNuocSX WHERE MaNuocSX = @MaNuocSX";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNuocSX", Ma.Text);
                        command.Parameters.AddWithValue("@TenNuocSX", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa Nước Sản Xuất thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa Nước Sản Xuất: " + ex.Message);
                }
            }
        }

        // Button click event to delete a "NuocSanXuat"
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text))
            {
                MessageBox.Show("Vui lòng chọn một Nước Sản Xuất để xóa.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Nước Sản Xuất này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM NuocSanXuat WHERE MaNuocSX = @MaNuocSX";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaNuocSX", Ma.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa Nước Sản Xuất thành công!");

                            // Refresh DataGridView and clear text boxes
                            LoadData();
                            Ma.Clear();
                            Ten.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa Nước Sản Xuất: " + ex.Message);
                    }
                }
            }
        }

        // Event to handle row selection in DataGridView
        private void dgvNuocSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                DataGridViewRow row = dgvNuocSX.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaNuocSX"].Value.ToString();
                Ten.Text = row.Cells["TenNuocSX"].Value.ToString();
            }
        }
    }
}
