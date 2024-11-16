using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemLoaiKinh : Form
    {
        public ThemLoaiKinh()
        {
            InitializeComponent();
            LoadData();
            dgvLoaiKinh.CellClick += dgvLoaiKinh_CellClick; 

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
                    string query = "SELECT MaLoai, TenLoai FROM LoaiKinh";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvLoaiKinh.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Loại Kính: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ mã và tên Loại Kính.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO LoaiKinh (MaLoai, TenLoai) VALUES (@MaLoai, @TenLoai)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaLoai", Ma.Text);
                        command.Parameters.AddWithValue("@TenLoai", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm Loại Kính thành công!");

                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm Loại Kính: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng chọn một Loại Kính để sửa và điền đầy đủ mã và tên.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE LoaiKinh SET TenLoai = @TenLoai WHERE MaLoai = @MaLoai";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaLoai", Ma.Text);
                        command.Parameters.AddWithValue("@TenLoai", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa Loại Kính thành công!");

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
                    MessageBox.Show("Lỗi khi sửa Loại Kính: " + ex.Message);
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text))
            {
                MessageBox.Show("Vui lòng chọn một Loại Kính để xóa.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Loại Kính này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM LoaiKinh WHERE MaLoai = @MaLoai";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaLoai", Ma.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa Loại Kính thành công!");

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
                        //MessageBox.Show("Lỗi khi xóa Loại Kính: " + ex.Message);
                        MessageBox.Show("Loại kính này đã tồn tại trong hóa đơn! Không thể xóa.");
                    }
                }
            }
        }

        private void dgvLoaiKinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvLoaiKinh.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaLoai"].Value.ToString();
                Ten.Text = row.Cells["TenLoai"].Value.ToString();
            }
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            button2.Enabled = false;
        }
        private int GenerateNewID()
        {
            int newID = 1;

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(MaLoai) FROM LoaiKinh";

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
        private void ThemLoaiKinh_Load(object sender, EventArgs e)
        {
            Ma.Text = GenerateNewID().ToString();
        }
    }
}
