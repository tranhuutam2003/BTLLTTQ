using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemGongMat : Form
    {
        public ThemGongMat()
        {
            InitializeComponent();
            LoadData();
            dgvGongMat.CellClick += dgvGongMat_CellClick; 

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
                    string query = "SELECT MaLoaiGong, TenLoaiGong FROM GongMat";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvGongMat.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách GongMat: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ mã và tên Loại Gong.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO GongMat (MaLoaiGong, TenLoaiGong) VALUES (@MaLoaiGong, @TenLoaiGong)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaLoaiGong", Ma.Text);
                        command.Parameters.AddWithValue("@TenLoaiGong", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm Loại Gong thành công!");

                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                        Ma.Text = GenerateNewID().ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm Loại Gong: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text) || string.IsNullOrWhiteSpace(Ten.Text))
            {
                MessageBox.Show("Vui lòng chọn một Loại Gong để sửa và điền đầy đủ mã và tên.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE GongMat SET TenLoaiGong = @TenLoaiGong WHERE MaLoaiGong = @MaLoaiGong";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaLoaiGong", Ma.Text);
                        command.Parameters.AddWithValue("@TenLoaiGong", Ten.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa Loại Gong thành công!");

                        LoadData();
                        Ma.Clear();
                        Ten.Clear();
                        Ma.Text = GenerateNewID().ToString();
                        btnxoa.Enabled = false;
                        btnsua.Enabled = false;
                        button2.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa Loại Gong: " + ex.Message);
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ma.Text))
            {
                MessageBox.Show("Vui lòng chọn một Loại Gong để xóa.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Loại Gong này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM GongMat WHERE MaLoaiGong = @MaLoaiGong";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaLoaiGong", Ma.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa Loại Gong thành công!");

                            LoadData();
                            Ma.Clear();
                            Ten.Clear();
                            Ma.Text = GenerateNewID().ToString();
                            btnxoa.Enabled = false;
                            btnsua.Enabled = false;
                            button2.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Lỗi khi xóa Loại Gong: " + ex.Message);
                        MessageBox.Show("Gọng mắt này đã tồn tại trong hóa đơn! Không thể xóa.");
                    }
                }
            }
        }

        private void dgvGongMat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvGongMat.Rows[e.RowIndex];
                Ma.Text = row.Cells["MaLoaiGong"].Value.ToString();
                Ten.Text = row.Cells["TenLoaiGong"].Value.ToString();
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
                    string query = "SELECT MAX(MaLoaiGong) FROM GongMat";

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
        private void ThemGongMat_Load(object sender, EventArgs e)
        {
            Ma.Text = GenerateNewID().ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
