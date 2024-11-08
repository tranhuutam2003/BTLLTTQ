using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemDiop : Form
    {
        public ThemDiop()
        {
            InitializeComponent();
            LoadData();
            dgvDiop.CellClick += dgvDiop_CellClick; // Attach the CellClick event

            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            button2.Enabled = true;
        }

        // Method to load data into the DataGridView
        public void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaDiop, TenDiop FROM Diop";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDiop.DataSource = dt; // Set DataGridView's data source to DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Diop: " + ex.Message);
                }
            }
        }
        // Button click event to add a new Diop
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ mã và tên Diop.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Diop (MaDiop, TenDiop) VALUES (@MaDiop, @TenDiop)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDiop", Ma.Text);
                        command.Parameters.AddWithValue("@TenDiop", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm Diop thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm Diop: " + ex.Message);
                }
            }
        }

        // Event to handle row selection in DataGridView
        private void dgvDiop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                DataGridViewRow row = dgvDiop.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaDiop"].Value.ToString();
                Ten.Text = row.Cells["TenDiop"].Value.ToString();
            }

            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            button2.Enabled = false;
        }

        // Button click event to delete a Diop
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text))
            {
                MessageBox.Show("Vui lòng chọn một Diop để xóa.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Diop này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM Diop WHERE MaDiop = @MaDiop";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaDiop", Ma.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa Diop thành công!");

                            // Refresh DataGridView and clear text boxes
                            LoadData();
                            Ma.Clear();
                            Ten.Clear();

                            btnxoa.Enabled = false;
                            btnsua.Enabled = false;
                            button2.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa Diop: " + ex.Message);
                    }
                }
            }
        }

        // Button click event to edit an existing Diop
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng chọn một Diop để sửa và điền đầy đủ mã và tên.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Diop SET TenDiop = @TenDiop WHERE MaDiop = @MaDiop";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDiop", Ma.Text);
                        command.Parameters.AddWithValue("@TenDiop", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa Diop thành công!");

                        // Refresh DataGridView and clear text boxes
                        LoadData();
                        Ma.Clear();
                        Ten.Clear();

                        btnxoa.Enabled = false;
                        btnsua.Enabled = false;
                        button2.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa Diop: " + ex.Message);
                }
            }
        }
    }
}
