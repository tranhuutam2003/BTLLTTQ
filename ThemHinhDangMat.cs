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
            dgvHinhDangMat.CellClick += dgvHinhDangMat_CellClick; 

            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            button1.Enabled = true;
        }

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
                    dgvHinhDangMat.DataSource = dt; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Hình Dáng Mặt: " + ex.Message);
                }
            }
        }

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

                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                        Ma.Text = GenerateNewID().ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm Hình Dáng Mặt: " + ex.Message);
                }
            }
        }

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

                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                        Ma.Text = GenerateNewID().ToString();
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

                            LoadData();
                            Ma.Clear();
                            Ten.Clear();
                            Ma.Text = GenerateNewID().ToString();
                            btnxoa.Enabled = false;
                            btnsua.Enabled = false;
                            button1.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Lỗi khi xóa Hình Dáng Mặt: " + ex.Message);
                        MessageBox.Show("Hình dạng mắt này đã tồn tại trong hóa đơn! Không thể xóa.");
                    }
                }
            }
        }

        private void dgvHinhDangMat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvHinhDangMat.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaDangMat"].Value.ToString();
                Ten.Text = row.Cells["TenDangMat"].Value.ToString();
            }

            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            button1.Enabled = false;
        }
        private int GenerateNewID()
        {
            int newID = 1;

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(MaDangMat) FROM HinhDangMat";

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
        private void ThemHinhDangMat_Load(object sender, EventArgs e)
        {
            Ma.Text = GenerateNewID().ToString();
        }
    }
}
