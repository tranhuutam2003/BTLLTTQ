using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemMauSac : Form
    {
        public ThemMauSac()
        {
            InitializeComponent();
            LoadData();
            dgvMauSac.CellClick += dgvMauSac_CellClick; // Attach the CellClick event
        }

        // Method to load data into the DataGridView
        public void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaMau, TenMau FROM MauSac";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMauSac.DataSource = dt; // Set DataGridView's data source to DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Màu Sắc: " + ex.Message);
                }
            }
        }

        // Button click event to add a new MauSac
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ mã và tên Màu Sắc.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO MauSac (MaMau, TenMau) VALUES (@MaMau, @TenMau)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaMau", Ma.Text);
                        command.Parameters.AddWithValue("@TenMau", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm Màu Sắc thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm Màu Sắc: " + ex.Message);
                }
            }
        }

        // Button click event to edit a MauSac
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng chọn một Màu Sắc để sửa và điền đầy đủ mã và tên.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE MauSac SET TenMau = @TenMau WHERE MaMau = @MaMau";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaMau", Ma.Text);
                        command.Parameters.AddWithValue("@TenMau", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa Màu Sắc thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa Màu Sắc: " + ex.Message);
                }
            }
        }

        // Button click event to delete a MauSac
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text))
            {
                MessageBox.Show("Vui lòng chọn một Màu Sắc để xóa.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Màu Sắc này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM MauSac WHERE MaMau = @MaMau";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaMau", Ma.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa Màu Sắc thành công!");

                            // Refresh DataGridView and clear text boxes
                            LoadData();
                            Ma.Clear();
                            Ten.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa Màu Sắc: " + ex.Message);
                    }
                }
            }
        }

        // Event to handle row selection in DataGridView
        private void dgvMauSac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                DataGridViewRow row = dgvMauSac.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaMau"].Value.ToString();
                Ten.Text = row.Cells["TenMau"].Value.ToString();
            }
        }
    }
}
