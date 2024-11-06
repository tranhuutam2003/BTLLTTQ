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
    public partial class Home : Form
    {
        public string TenNV { get; set; }
        public string CongViec { get; set; }
        public int MaNV { get; set; }
        public Home()
        {
            InitializeComponent();
            this.Load += Home_Load;
            QLNV.Visible = false;
            btndoanhthu.Visible = false;
        }

        private void QLNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien qlnv = new QuanLyNhanVien(TenNV, CongViec, MaNV);
            qlnv.Show();
            this.Hide();

        }

        private void QLNCC_Click(object sender, EventArgs e)
        {
            QuanLyNhaCungCap qlncc = new QuanLyNhaCungCap(TenNV, CongViec, MaNV);
            qlncc.Show();
            this.Hide();
        }

        private void QLKH_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang qlkh = new QuanLyKhachHang(TenNV, CongViec, MaNV);
            qlkh.Show();
            this.Hide();
        }

        private void QLHDN_Click(object sender, EventArgs e)
        {
            QuanLyHoaDonNhap quanLyHoaDonNhap = new QuanLyHoaDonNhap(TenNV, CongViec,MaNV);
            quanLyHoaDonNhap.Show();
            this.Hide();
        }

        private void QLDMHH_Click(object sender, EventArgs e)
        {
            QuanLyDanhMucHangHoa qlhh = new QuanLyDanhMucHangHoa(TenNV, CongViec, MaNV);
            qlhh.Show();
            this.Hide();
        }

        private void QLHDB_Click(object sender, EventArgs e)
        {
            QuanLyHoaDonBan qlhdb = new QuanLyHoaDonBan(TenNV, CongViec, MaNV);
            qlhdb.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
            this.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {

            UpdateUI();
            LoadThongBao();
        }

        public void UpdateUI()
        {

            lbTenNV.Text = TenNV ?? "Không có tên";
                lbCV.Text = CongViec ?? "Không có công việc";

            if (CongViec == "Nhân viên bán hàng")
            {
                QLNV.Visible = false;
                btndoanhthu.Visible = false;// Show sales staff menu
                
            }
            else if (CongViec == "Quản lý")
            {
                QLNV.Visible = true; // Hide sales staff menu
                btndoanhthu.Visible = true;
            }
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemHangHoa themHangHoa = new ThemHangHoa();
            themHangHoa.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            QuanLyDanhMucHangHoa qlhh = new QuanLyDanhMucHangHoa(TenNV, CongViec,MaNV);
            qlhh.Show();
            this.Hide();
        }

		private void button12_Click(object sender, EventArgs e)
		{
            QuanLyHoaDonBan quanLyHoaDonBan = new QuanLyHoaDonBan();
            quanLyHoaDonBan.Show();

		}

		private void button8_Click(object sender, EventArgs e)
		{
            QuanLyHoaDonNhap quanLyHoaDonNhap= new QuanLyHoaDonNhap(TenNV, CongViec, MaNV);
            quanLyHoaDonNhap.Show();
            this.Hide();
		}

        private void btndoanhthu_Click(object sender, EventArgs e)
        {
            DoanhThu dt = new DoanhThu(TenNV, CongViec, MaNV);
            dt.Show();
            this.Hide();
        }

        private void LoadThongBao()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
                {
                    conn.Open();

                    // Truy vấn để lấy thông tin nhân viên
                    string getUserInfoQuery = "SELECT nv.MaNV, cv.TenCV FROM NhanVien nv " +
                                               "JOIN CongViec cv ON nv.MaCV = cv.MaCV " +
                                               "WHERE nv.TenNV = @TenNV";

                    int maNV = -1;
                    bool isManager = false;

                    using (SqlCommand cmdGetInfo = new SqlCommand(getUserInfoQuery, conn))
                    {
                        // Khai báo tham số đúng cách
                        cmdGetInfo.Parameters.AddWithValue("@TenNV", TenNV);

                        using (SqlDataReader reader = cmdGetInfo.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                maNV = Convert.ToInt32(reader["MaNV"]);
                                isManager = reader["TenCV"].ToString().Equals("Quản lý", StringComparison.OrdinalIgnoreCase);
                            }
                        }
                    }

                    if (maNV == -1)
                    {
                        MessageBox.Show($"Không tìm thấy thông tin nhân viên: {TenNV}");
                        return;
                    }

                    // Câu truy vấn lấy thông báo
                    string notificationQuery;
                    if (isManager)
                    {
                        notificationQuery = "SELECT NoiDung, NgayTao FROM ThongBao ORDER BY NgayTao DESC";
                    }
                    else
                    {
                        notificationQuery = "SELECT NoiDung, NgayTao FROM ThongBao WHERE NguoiNhan = @MaNV OR NguoiNhan IS NULL ORDER BY NgayTao DESC";
                    }

                    using (SqlCommand cmd = new SqlCommand(notificationQuery, conn))
                    {
                        if (!isManager)
                        {
                            cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = maNV;
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            grbthongbao.Controls.Clear(); // Xóa các điều khiển hiện có
                            int yOffset = 20;

                            while (reader.Read())
                            {
                                string noiDung = reader["NoiDung"].ToString();
                                DateTime ngayTao = Convert.ToDateTime(reader["NgayTao"]);

                                Label lblThongBao = new Label
                                {
                                    Text = $"{noiDung} - Ngày: {ngayTao:dd/MM/yyyy HH:mm}",
                                    AutoSize = true,
                                    Location = new Point(10, yOffset),
                                    MaximumSize = new Size(grbthongbao.Width - 20, 0),
                                    AutoEllipsis = true
                                };

                                grbthongbao.Controls.Add(lblThongBao);
                                yOffset += lblThongBao.Height + 5; // Cập nhật vị trí Y cho thông báo tiếp theo
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TimNhanVien timNhanVien = new TimNhanVien();
            timNhanVien.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThemNV themNV = new ThemNV();
            themNV.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TimKhachHang timKhachHang = new TimKhachHang();
            timKhachHang.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimSanPham timSanPham = new TimSanPham();
            timSanPham.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TimHoaDon timHoaDon = new TimHoaDon();
            timHoaDon.Show();
        }

        private void plCV_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Home_Load_1(object sender, EventArgs e)
        {

        }

        private void MenuQL_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rspass_Click(object sender, EventArgs e)
        {

        }
    }
}
