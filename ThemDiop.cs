using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemDiop : Form
    {
        public ThemDiop()
        {
            InitializeComponent();
            LoadExistingDiop(); 
        }

        // Hàm để tải và hiển thị các Diop hiện tại vào một danh sách
        private void LoadExistingDiop()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaDiop, TenDiop FROM Diop";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            listBoxDiop.Items.Add($"{reader["MaDiop"]} - {reader["TenDiop"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách Diop: " + ex.Message);
                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

                        // Cập nhật danh sách Diop và xóa dữ liệu form
                        listBoxDiop.Items.Add($"{Ma.Text} - {Ten.Text}");
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
    }
}
