using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemCongDung : Form
    {
        public ThemCongDung()
        {
            InitializeComponent();
            LoadData();
            dgvCongDung.CellClick += dgvCongDung_CellClick; // Attach the CellClick event
        }

        // Method to load data into the DataGridView
        public void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaCongDung, TenCongDung FROM CongDung";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCongDung.DataSource = dt; // Set DataGridView's data source to DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Công Dụng: " + ex.Message);
                }
            }
        }

        // Button click event to add a new CongDung
        private void xacnhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ mã và tên Công Dụng.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO CongDung (MaCongDung, TenCongDung) VALUES (@MaCongDung, @TenCongDung)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters for the query
                        command.Parameters.AddWithValue("@MaCongDung", Ma.Text);
                        command.Parameters.AddWithValue("@TenCongDung", Ten.Text);
                        // Execute the command
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm công dụng thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm công dụng: " + ex.Message);
                }
            }
        }

        // Event to handle row selection in DataGridView
        private void dgvCongDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                DataGridViewRow row = dgvCongDung.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaCongDung"].Value.ToString();
                Ten.Text = row.Cells["TenCongDung"].Value.ToString();
            }
        }
        private void btnsua_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng chọn một công dụng để sửa và điền đầy đủ mã và tên.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE CongDung SET TenCongDung = @TenCongDung WHERE MaCongDung = @MaCongDung";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaCongDung", Ma.Text);
                        command.Parameters.AddWithValue("@TenCongDung", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa công dụng thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa công dụng: " + ex.Message);
                }
            }
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text))
            {
                MessageBox.Show("Vui lòng chọn một công dụng để xóa.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa công dụng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM CongDung WHERE MaCongDung = @MaCongDung";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaCongDung", Ma.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa công dụng thành công!");

                            // Refresh DataGridView and clear text boxes
                            LoadData();
                            Ma.Clear();
                            Ten.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa công dụng: " + ex.Message);
                    }
                }
            }
        }
    }
}
