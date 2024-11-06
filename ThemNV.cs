using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemNV : Form
    {
        private string verificationCode;
        public ThemNV()
        {
            InitializeComponent();
            LoadCongViec(); // Load danh sách công việc
            LoadGioiTinh(); // Load danh sách giới tính
        }

        // Hàm load danh sách công việc từ bảng CongViec vào ComboBox
        private void LoadCongViec()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaCV, TenCV FROM CongViec";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Hiển thị TenCV trong ComboBox, giá trị sẽ là MaCV
                        CongViec.Items.Add(new { MaCV = reader["MaCV"], TenCV = reader["TenCV"].ToString() });
                    }

                    CongViec.DisplayMember = "TenCV";
                    CongViec.ValueMember = "MaCV"; // Lấy MaCV làm giá trị khi chọn
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách công việc: " + ex.Message);
                }
            }
        }

        // Hàm load danh sách giới tính vào ComboBox
        private void LoadGioiTinh()
        {
            Sex.Items.Add("Nam");
            Sex.Items.Add("Nữ");

            // Lựa chọn mặc định (nếu cần)
            Sex.SelectedIndex = 0; // Mặc định chọn "Nam"
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Xacnhan_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra số điện thoại
            if (!Regex.IsMatch(Dienthoai.Text, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 số và bắt đầu bằng số 0.");
                return;
            }

            // Lấy ngày sinh từ DateTimePicker và kiểm tra tuổi
            DateTime ngaySinh = Ngaysinh.Value;
            int tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (ngaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--; // Kiểm tra nếu ngày sinh chưa qua trong năm nay

            if (tuoi < 18)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi trở lên.");
                return;
            }

            // Lấy mã công việc từ ComboBox
            if (CongViec.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn công việc cho nhân viên.");
                return;
            }
            int maCongViec = (int)((dynamic)CongViec.SelectedItem).MaCV;

            // Lấy giới tính từ ComboBox
            string gioiTinh = Sex.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DienThoai, DiaChi, MaCV) " +
                                   "VALUES (@MaNV, @TenNV, @GioiTinh, @NgaySinh, @DienThoai, @DiaChi, @MaCV)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@MaNV", MaNV.Text);
                        command.Parameters.AddWithValue("@TenNV", tenNV.Text);
                        command.Parameters.AddWithValue("@GioiTinh", gioiTinh); // Lấy từ ComboBox giới tính
                        command.Parameters.AddWithValue("@NgaySinh", Ngaysinh.Value); // Sử dụng DateTimePicker
                        command.Parameters.AddWithValue("@DienThoai", Dienthoai.Text);
                        command.Parameters.AddWithValue("@DiaChi", Diachi.Text);
                        command.Parameters.AddWithValue("@MaCV", maCongViec);
                        command.Parameters.AddWithValue("@Email", Email.Text);
                        // Thực thi câu lệnh
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm nhân viên thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
                }
            }
        }

		private void ThemNV_Load(object sender, EventArgs e)
		{

		}

        private void layma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email.Text))
            {
                MessageBox.Show("Vui lòng nhập email trước khi lấy mã xác nhận.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra định dạng email
                var addr = new System.Net.Mail.MailAddress(Email.Text);
                if (addr.Address != Email.Text)
                {
                    MessageBox.Show("Email không hợp lệ.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Email không hợp lệ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo mã xác nhận ngẫu nhiên
            verificationCode = GenerateVerificationCode();

            try
            {
                // Gửi email chứa mã xác nhận
                SendVerificationEmail(Email.Text, verificationCode);
                MessageBox.Show("Mã xác nhận đã được gửi đến email của bạn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi gửi email: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void SendVerificationEmail(string email, string code)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("tam62533@gmail.com", "dotnnpjevidbdxjr"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("tam62533@gmail.com"),
                Subject = "Mã xác nhận tài khoản nhân viên",
                Body = $@"Kính gửi nhân viên,

                Mã xác nhận của bạn là: {code}

                Vui lòng không chia sẻ mã này với người khác.
                Mã có hiệu lực trong vòng 5 phút.

                Trân trọng,
                [Tên công ty của bạn]",
                                IsBodyHtml = false
                            };

            mailMessage.To.Add(email);
            smtpClient.Send(mailMessage);
        }

        private void ThemNV_Load_1(object sender, EventArgs e)
        {

        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
