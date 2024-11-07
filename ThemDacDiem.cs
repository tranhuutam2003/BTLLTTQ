using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemDacDiem : Form
    {
        public ThemDacDiem()
        {
            InitializeComponent();
            LoadData();
            dgvDacDiem.CellClick += dgvDacDiem_CellClick; // Attach the CellClick event
        }

        // Method to load data into the DataGridView
        public void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaDacDiem, TenDacDiem FROM DacDiem";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDacDiem.DataSource = dt; // Set DataGridView's data source to DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Đặc Điểm: " + ex.Message);
                }
            }
        }

        // Button click event to add a new DacDiem
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ mã và tên Đặc Điểm.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO DacDiem (MaDacDiem, TenDacDiem) VALUES (@MaDacDiem, @TenDacDiem)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters for the query
                        command.Parameters.AddWithValue("@MaDacDiem", Ma.Text);
                        command.Parameters.AddWithValue("@TenDacDiem", Ten.Text);
                        // Execute the command
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm đặc điểm thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm đặc điểm: " + ex.Message);
                }
            }
        }

        // Event to handle row selection in DataGridView
        private void dgvDacDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                DataGridViewRow row = dgvDacDiem.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaDacDiem"].Value.ToString();
                Ten.Text = row.Cells["TenDacDiem"].Value.ToString();
            }
        }

        // Button click event to edit an existing DacDiem
        private void button1_Click(object sender, EventArgs e) // btnSua
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng chọn một đặc điểm để sửa và điền đầy đủ mã và tên.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE DacDiem SET TenDacDiem = @TenDacDiem WHERE MaDacDiem = @MaDacDiem";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDacDiem", Ma.Text);
                        command.Parameters.AddWithValue("@TenDacDiem", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa đặc điểm thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa đặc điểm: " + ex.Message);
                }
            }
        }

        // Button click event to delete a DacDiem
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text))
            {
                MessageBox.Show("Vui lòng chọn một đặc điểm để xóa.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa đặc điểm này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM DacDiem WHERE MaDacDiem = @MaDacDiem";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaDacDiem", Ma.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa đặc điểm thành công!");

                            // Refresh DataGridView and clear text boxes
                            LoadData();
                            Ma.Clear();
                            Ten.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa đặc điểm: " + ex.Message);
                    }
                }
            }
        }
    }
}
