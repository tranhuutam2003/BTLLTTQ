using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemChatLieu : Form
    {
        public ThemChatLieu()
        {
            InitializeComponent();
            LoadData();
            dgvChatLieu.CellClick += dgvChatLieu_CellClick; // Attach the CellClick event

            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            xacnhan.Enabled = true;
        }

        // Method to load data into the DataGridView
        public void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaChatLieu, TenChatLieu FROM ChatLieu";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvChatLieu.DataSource = dt; // Set DataGridView's data source to DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Chất Liệu: " + ex.Message);
                }
            }
        }

        // Button click event to add a new ChatLieu
        private void xacnhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ mã và tên Chất Liệu.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO ChatLieu (MaChatLieu, TenChatLieu) VALUES (@MaChatLieu, @TenChatLieu)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters for the query
                        command.Parameters.AddWithValue("@MaChatLieu", Ma.Text);
                        command.Parameters.AddWithValue("@TenChatLieu", Ten.Text);
                        // Execute the command
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm chất liệu thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm chất liệu: " + ex.Message);
                }
            }
        }

        // Event to handle row selection in DataGridView
        private void dgvChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                DataGridViewRow row = dgvChatLieu.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaChatLieu"].Value.ToString();
                Ten.Text = row.Cells["TenChatLieu"].Value.ToString();
            }
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            xacnhan.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng chọn một chất liệu để sửa và điền đầy đủ mã và tên.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE ChatLieu SET TenChatLieu = @TenChatLieu WHERE MaChatLieu = @MaChatLieu";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaChatLieu", Ma.Text);
                        command.Parameters.AddWithValue("@TenChatLieu", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa chất liệu thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();

                        btnsua.Enabled = false;
                        btnxoa.Enabled = false;
                        xacnhan.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa chất liệu: " + ex.Message);
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text))
            {
                MessageBox.Show("Vui lòng chọn một chất liệu để xóa.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa chất liệu này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM ChatLieu WHERE MaChatLieu = @MaChatLieu";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaChatLieu", Ma.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa chất liệu thành công!");

                            // Refresh DataGridView and clear text boxes
                            LoadData();
                            Ma.Clear();
                            Ten.Clear();

                            btnsua.Enabled = false;
                            btnxoa.Enabled = false;
                            xacnhan.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa chất liệu: " + ex.Message);
                    }
                }
            }
        }
    }
}
