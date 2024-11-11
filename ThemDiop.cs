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
            dgvDiop.CellClick += dgvDiop_CellClick; 

            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            button2.Enabled = true;
        }

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
                    dgvDiop.DataSource = dt; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Diop: " + ex.Message);
                }
            }
        }
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

        private void dgvDiop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvDiop.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaDiop"].Value.ToString();
                Ten.Text = row.Cells["TenDiop"].Value.ToString();
            }

            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            button2.Enabled = false;
        }

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
        private int GenerateNewID()
        {
            int newID = 1;

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(MaDiop) FROM Diop";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            newID = Convert.ToInt32(result) + 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo mã hàng mới: " + ex.Message);
                }
            }

            return newID;
        }
        private void ThemDiop_Load(object sender, EventArgs e)
        {
            Ma.Text = GenerateNewID().ToString();
        }
    }
}
