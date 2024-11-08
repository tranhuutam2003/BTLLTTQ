using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemHinhDangMat : Form
    {
        public ThemHinhDangMat()
        {
            InitializeComponent();
            LoadData();
            dgvHinhDangMat.CellClick += dgvHinhDangMat_CellClick; // Attach the CellClick event

            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            button1.Enabled = true;
        }

        // Method to load data into the DataGridView
        public void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaDangMat, TenDangMat FROM HinhDangMat";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvHinhDangMat.DataSource = dt; // Set DataGridView's data source to DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Hình Dáng Mặt: " + ex.Message);
                }
            }
        }

        // Button click event to add a new HinhDangMat
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ mã và tên Hình Dáng Mặt.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO HinhDangMat (MaDangMat, TenDangMat) VALUES (@MaDangMat, @TenDangMat)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDangMat", Ma.Text);
                        command.Parameters.AddWithValue("@TenDangMat", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm Hình Dáng Mặt thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm Hình Dáng Mặt: " + ex.Message);
                }
            }
        }

        // Button click event to edit a HinhDangMat
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng chọn một Hình Dáng Mặt để sửa và điền đầy đủ mã và tên.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE HinhDangMat SET TenDangMat = @TenDangMat WHERE MaDangMat = @MaDangMat";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDangMat", Ma.Text);
                        command.Parameters.AddWithValue("@TenDangMat", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa Hình Dáng Mặt thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();

                        btnxoa.Enabled = false;
                        btnsua.Enabled = false;
                        button1.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa Hình Dáng Mặt: " + ex.Message);
                }
            }
        }

        // Button click event to delete a HinhDangMat
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text))
            {
                MessageBox.Show("Vui lòng chọn một Hình Dáng Mặt để xóa.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Hình Dáng Mặt này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM HinhDangMat WHERE MaDangMat = @MaDangMat";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaDangMat", Ma.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa Hình Dáng Mặt thành công!");

                            // Refresh DataGridView and clear text boxes
                            LoadData();
                            Ma.Clear();
                            Ten.Clear();

                            btnxoa.Enabled = false;
                            btnsua.Enabled = false;
                            button1.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa Hình Dáng Mặt: " + ex.Message);
                    }
                }
            }
        }

        // Event to handle row selection in DataGridView
        private void dgvHinhDangMat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                DataGridViewRow row = dgvHinhDangMat.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaDangMat"].Value.ToString();
                Ten.Text = row.Cells["TenDangMat"].Value.ToString();
            }

            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            button1.Enabled = false;
        }
    }
}
