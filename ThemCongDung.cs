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
            dgvCongDung.CellClick += dgvCongDung_CellClick; 

            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            xacnhan.Enabled = true;
        }
        private int GenerateNewID()
        {
            int newID = 1;

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(MaCongDung) FROM CongDung";

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
                    dgvCongDung.DataSource = dt; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Công Dụng: " + ex.Message);
                }
            }
        }

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
                        command.Parameters.AddWithValue("@MaCongDung", Ma.Text);
                        command.Parameters.AddWithValue("@TenCongDung", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm công dụng thành công!");

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

        private void dgvCongDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvCongDung.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaCongDung"].Value.ToString();
                Ten.Text = row.Cells["TenCongDung"].Value.ToString();
            }
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            xacnhan.Enabled = false;
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

                        LoadData();
                        Ma.Clear();
                        Ten.Clear();

                        btnxoa.Enabled = false;
                        btnsua.Enabled = false;
                        xacnhan.Enabled = true;
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

                            btnxoa.Enabled = false;
                            btnsua.Enabled = false;
                            xacnhan.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Lỗi khi xóa công dụng: " + ex.Message);
                        MessageBox.Show("Công dụng này đã tồn tại trong hóa đơn! Không thể xóa.");
                    }
                }
            }
        }

        private void ThemCongDung_Load(object sender, EventArgs e)
        {
            Ma.Text= GenerateNewID().ToString();
        }
    }
}
