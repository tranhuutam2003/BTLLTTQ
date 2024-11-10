using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class SuaKH : Form
    {
        private string maKH;
        public SuaKH()
        {
            InitializeComponent();
        }

        public SuaKH(string ma, string ten, string diaChi, string dienThoai)
        {
            InitializeComponent();
            this.maKH = ma;

            MaKH.Text = maKH;
            TenKH.Text = ten;
            SDTKH.Text = dienThoai;
            DiaChiKH.Text = diaChi;
        }

        private void Xacnhan_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(SDTKH.Text, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 số và bắt đầu bằng số 0.");
                return;
            }

            //string newMaKH = MaKH.Text.Trim();
            //if (string.IsNullOrEmpty(newMaKH))
            //{
            //    MessageBox.Show("Mã khách hàng không được để trống.");
            //    return;
            //}

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE KhachHang SET TenKhach=@TenKH, DiaChi=@DiaChi, DienThoai=@DienThoai WHERE MaKhach=@MaKH";
              
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaKH", MaKH.Text);
                        //command.Parameters.AddWithValue("@OldMaKH", maKH);
                        command.Parameters.AddWithValue("@TenKH", TenKH.Text);
                        command.Parameters.AddWithValue("@DiaChi", DiaChiKH.Text);
                        command.Parameters.AddWithValue("@DienThoai", SDTKH.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa thông tin khách hàng thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa thông tin khách hàng " + ex.Message);
                }
            }
            this.Close();
        }


        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
