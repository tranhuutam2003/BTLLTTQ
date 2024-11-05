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
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
            LoadSavedCredentials();
        }

        private void LoadSavedCredentials()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SaveUsername))
            {
                username.Text = Properties.Settings.Default.SaveUsername;
                password.Text = Properties.Settings.Default.SavePassword;
                checkBox1.Checked = true;
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string userInput = username.Text;
            string pass = password.Text;

            var (isAuthenticated, tenNV, tenCV, maNV) = AuthenticateUser(userInput, pass);

            if (isAuthenticated)
            {
                if (checkBox1.Checked)
                {
                    SaveCredentials(userInput, pass);
                }
                else
                {
                    ClearSavedCredentials();
                }

                Home homeForm = new Home
                {
                    TenNV = tenNV,
                    CongViec = tenCV,
                    MaNV = maNV
                };
                homeForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCredentials(string username,string password)
        {
            Properties.Settings.Default.SaveUsername = username;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.SavePassword = password;
            Properties.Settings.Default.Save();
        }

        private void ClearSavedCredentials()
        {
            Properties.Settings.Default.SaveUsername = string.Empty;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.SavePassword = string.Empty;
            Properties.Settings.Default.Save();
        }

        private string GetUserRole(string maNV)
        {
            // Thực hiện truy vấn để lấy công việc của nhân viên từ database
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();
                string query = "SELECT MaCV FROM NhanVien WHERE MaNV = @MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    return cmd.ExecuteScalar()?.ToString(); // Trả về công việc
                }
            }
        }
        private (bool isAuthenticated, string tenNV, string tenCV, int maNV) AuthenticateUser(string userInput, string password)
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT nv.MaNV, nv.TenNV, cv.TenCV 
                         FROM NhanVien nv 
                         JOIN CongViec cv ON nv.MaCV = cv.MaCV 
                         WHERE (nv.MaNV = @UserInput OR nv.emailNV = @UserInput) 
                         AND nv.MkNV = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserInput", userInput);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (true, reader["TenNV"].ToString(), reader["TenCV"].ToString(), Convert.ToInt32(reader["MaNV"]));
                        }
                        return (false, null, null, 0);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                ClearSavedCredentials();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassword rs = new ResetPassword();
            rs.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
