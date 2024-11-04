using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class NhaCungCap : Form
    {
        public string Mode { get; set; } 
        public int MaNCC { get; set; }
        public NhaCungCap()
        {
            InitializeComponent();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            if (Mode == "Sua")
            {
                // Khi ở chế độ sửa, khóa TextBox MaNCC và hiển thị thông tin nhà cung cấp
                txtMaNCC.Enabled = false;
                LoadNhaCungCap(MaNCC);
            }
            else
            {
                txtMaNCC.Enabled = true;
                txtMaNCC.Clear();
                txtTenNCC.Clear();
                txtDiaChi.Clear();
                txtDienThoai.Clear();
            }
        }

        private void LoadNhaCungCap(int maNCC)
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM NhaCungCap WHERE MaNCC = @MaNCC";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNCC", maNCC);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtMaNCC.Text = reader["MaNCC"].ToString();
                        txtTenNCC.Text = reader["TenNCC"].ToString();
                        txtDiaChi.Text = reader["DiaChi"].ToString();
                        txtDienThoai.Text = reader["DienThoai"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin nhà cung cấp: " + ex.Message);
                }
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (Mode == "Them" && string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã nhà cung cấp.");
                return;
            }
            if (Mode == "Them")
            {
                ThemNhaCungCap();
            }
            else if (Mode == "Sua")
            {
                // Thực hiện cập nhật thông tin nhà cung cấp
                SuaNhaCungCap(MaNCC);
            }

            this.Close();
        }

        private void ThemNhaCungCap()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Kiểm tra xem MaNCC hoặc TenNCC đã tồn tại hay chưa
                    string checkQuery = "SELECT COUNT(*) FROM NhaCungCap WHERE MaNCC = @MaNCC OR TenNCC = @TenNCC";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@MaNCC", Convert.ToInt32(txtMaNCC.Text)); // Lấy giá trị từ txtMaNCC
                    checkCommand.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã nhà cung cấp hoặc tên nhà cung cấp đã tồn tại. Vui lòng nhập lại.");
                        return; // Dừng lại nếu trùng
                    }

                    // Nếu không có trùng, thực hiện thêm nhà cung cấp
                    string query = "INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, DienThoai) VALUES (@MaNCC, @TenNCC, @DiaChi, @DienThoai)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNCC", Convert.ToInt32(txtMaNCC.Text));
                    command.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);
                    command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    command.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Thêm nhà cung cấp thành công!");
                    this.DialogResult = DialogResult.OK; // Đặt kết quả cho Dialog
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhà cung cấp: " + ex.Message);
                }
            }
        }


        private void SuaNhaCungCap(int maNCC)
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE NhaCungCap SET TenNCC = @TenNCC, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaNCC = @MaNCC";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);
                    command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    command.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text);
                    command.Parameters.AddWithValue("@MaNCC", maNCC);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin nhà cung cấp thành công!");
                    this.DialogResult = DialogResult.OK; // Đặt kết quả cho Dialog
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
