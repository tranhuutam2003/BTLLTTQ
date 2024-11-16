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
            dgvMauSac.CellClick += dgvMauSac_CellClick;

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
                    string query = "SELECT MaMau, TenMau FROM MauSac";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMauSac.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Màu Sắc: " + ex.Message);
                }
            }
        }

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

                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                        Ma.Text = GenerateNewID().ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm Màu Sắc: " + ex.Message);
                }
            }
        }

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
                    MessageBox.Show("Lỗi khi sửa Màu Sắc: " + ex.Message);
                }
            }
        }

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
                        //MessageBox.Show("Lỗi khi xóa Màu Sắc: " + ex.Message);
                        MessageBox.Show("Màu sắc này đã tồn tại trong hóa đơn! Không thể xóa.");
                    }
                }
            }
        }

        private void dgvMauSac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvMauSac.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaMau"].Value.ToString();
                Ten.Text = row.Cells["TenMau"].Value.ToString();
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
                    string query = "SELECT MAX(MaMau) FROM MauSac";

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
        private void ThemMauSac_Load(object sender, EventArgs e)
        {
            Ma.Text = GenerateNewID().ToString();
        }

        private void Ma_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
