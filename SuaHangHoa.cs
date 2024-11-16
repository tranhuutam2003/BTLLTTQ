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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BTL_LTTQ_VIP
{
    public partial class SuaHangHoa : Form
    {
        private string maHang;
        private QuanLyDanhMucHangHoa parentForm;
        public SuaHangHoa()
        {
            InitializeComponent();
            
        }

        public SuaHangHoa(QuanLyDanhMucHangHoa parent, string maHang, string tenHang, string tenLoai, string tenLoaiGong, string tenDangMat,
                   string tenChatLieu, string tenDiop, string congDung, string tenDacDiem, string tenMau,
                   string tenNuocSX, int soLuong, decimal donGiaNhap, decimal donGiaBan,
                   int thoiGianBaoHanh, string ghiChu)
        {
            InitializeComponent();
            this.maHang = maHang;
            this.parentForm = parent;
            LoadLoaiGong();
            LoadCongDung();
            LoadLoaikinh();
            LoadHinhDangMat();
            LoadChatLieu();
            LoadNuocSanXuat();
            LoadMauSac();
            LoadDiop();
            LoadDacDiem();
            // Hiển thị thông tin vào các ô nhập liệu
            MaHH.Text = maHang;
            TenHH.Text = tenHang;
            Loaikinh.Text = tenLoai;
            Loaigong.Text = tenLoaiGong;
            Dangmat.Text = tenDangMat;
            Chatlieu.Text = tenChatLieu;
            Diop.Text = tenDiop;
            Congdung.Text = congDung;
            Dacdiem.Text = tenDacDiem;
            Mausac.Text = tenMau;
            Nuocsanxuat.Text = tenNuocSX;
            Soluong.Text = soLuong.ToString();
            Dongianhap.Text = donGiaNhap.ToString();
            Dongiaban.Text = donGiaBan.ToString();
            Thoigianbaohanh.Text = thoiGianBaoHanh.ToString();
            Ghichu.Text = ghiChu;
            
        }



        private void LoadLoaiGong()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaLoaiGong, TenLoaiGong FROM GongMat";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Loaigong.Items.Add(new { MaLoaiGong = reader["MaLoaiGong"], TenLoaiGong = reader["TenLoaiGong"].ToString() });
                    }

                    Loaigong.DisplayMember = "TenLoaiGong";
                    Loaigong.ValueMember = "MaLoaiGong"; // Lấy MaCongDung làm giá trị khi chọn
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách loại gọng: " + ex.Message);
                }
            }
        }

        private void LoadCongDung()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaCongDung, TenCongDung FROM CongDung";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Congdung.Items.Add(new { MaCongDung = reader["MaCongDung"], TenCongDung = reader["TenCongDung"].ToString() });
                    }

                    Congdung.DisplayMember = "TenCongDung";
                    Congdung.ValueMember = "MaCongDung"; // Lấy MaCongDung làm giá trị khi chọn
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách công dụng: " + ex.Message);
                }
            }
        }

        private void LoadLoaikinh()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaLoai, TenLoai FROM LoaiKinh";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Loaikinh.Items.Add(new { MaLoai = reader["MaLoai"], TenLoai = reader["TenLoai"].ToString() });
                    }

                    Loaikinh.DisplayMember = "TenLoai";
                    Loaikinh.ValueMember = "MaLoai"; // Lấy MaLoai làm giá trị khi chọn
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách loại kính: " + ex.Message);
                }
            }
        }

        private void LoadHinhDangMat()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaDangMat, TenDangMat FROM HinhDangMat";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Dangmat.Items.Add(new { MaDangMat = reader["MaDangMat"], TenDangMat = reader["TenDangMat"].ToString() });
                    }

                    Dangmat.DisplayMember = "TenDangMat";
                    Dangmat.ValueMember = "MaDangMat";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách hình dáng mắt: " + ex.Message);
                }
            }
        }

        private void LoadChatLieu()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaChatLieu, TenChatLieu FROM ChatLieu";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Chatlieu.Items.Add(new { MaChatLieu = reader["MaChatLieu"], TenChatLieu = reader["TenChatLieu"].ToString() });
                    }

                    Chatlieu.DisplayMember = "TenChatLieu";
                    Chatlieu.ValueMember = "MaChatLieu";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách chất liệu: " + ex.Message);
                }
            }
        }

        private void LoadNuocSanXuat()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaNuocSX, TenNuocSX FROM NuocSanXuat";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Nuocsanxuat.Items.Add(new { MaNuocSX = reader["MaNuocSX"], TenNuocSX = reader["TenNuocSX"].ToString() });
                    }

                    Nuocsanxuat.DisplayMember = "TenNuocSX";
                    Nuocsanxuat.ValueMember = "MaNuocSX";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách nước sản xuất: " + ex.Message);
                }
            }
        }

        private void LoadMauSac()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaMau, TenMau FROM MauSac";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Mausac.Items.Add(new { MaMau = reader["MaMau"], TenMau = reader["TenMau"].ToString() });
                    }

                    Mausac.DisplayMember = "TenMau";
                    Mausac.ValueMember = "MaMau";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách màu sắc: " + ex.Message);
                }
            }
        }

        private void LoadDiop()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaDiop, TenDiop FROM Diop";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Diop.Items.Add(new { MaDiop = reader["MaDiop"], TenDiop = reader["TenDiop"].ToString() });
                    }

                    Diop.DisplayMember = "TenDiop";
                    Diop.ValueMember = "MaDiop";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách diop: " + ex.Message);
                }
            }
        }

        private void LoadDacDiem()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaDacDiem, TenDacDiem FROM DacDiem";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Dacdiem.Items.Add(new { MaDacDiem = reader["MaDacDiem"], TenDacDiem = reader["TenDacDiem"].ToString() });
                    }

                    Dacdiem.DisplayMember = "TenDacDiem";
                    Dacdiem.ValueMember = "MaDacDiem";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách đặc điểm: " + ex.Message);
                }
            }
        }
        private void Xacnhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TenHH.Text))
            {
                MessageBox.Show("Tên hàng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(Soluong.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng không được để trống và phải là số lớn hơn hoặc bằng 0.");
                return;
            }

            if (!decimal.TryParse(Dongianhap.Text, out decimal donGiaNhap) || donGiaNhap < 0)
            {
                MessageBox.Show("Đơn giá nhập không được để trống và phải là số lớn hơn 0.");
                return;
            }

            if (!decimal.TryParse(Dongiaban.Text, out decimal donGiaBan) || donGiaBan < 0)
            {
                MessageBox.Show("Đơn giá bán không được để trống và phải là số lớn hơn 0.");
                return;
            }
            if (!int.TryParse(Thoigianbaohanh.Text, out int thoiGianBaoHanh) || thoiGianBaoHanh < 0)
            {
                MessageBox.Show("Thời gian bảo hành không được để trống và phải là số lớn hơn hoặc bằng 0.");
                return;
            }
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE DanhMucHangHoa SET 
                                TenHang = @TenHang,
                                MaLoai = @MaLoai,
                                MaLoaiGong = @MaLoaiGong,
                                MaDangMat = @MaDangMat,
                                MaChatLieu = @MaChatLieu,
                                MaDiop = @MaDiop,
                                MaCongDung = @MaCongDung,
                                MaDacDiem = @MaDacDiem,
                                MaMau = @MaMau,
                                MaNuocSX = @MaNuocSX,
                                SoLuong = @SoLuong,
                                DonGiaNhap = @DonGiaNhap,
                                DonGiaBan = @DonGiaBan,
                                ThoiGianBaoHanh = @ThoiGianBaoHanh,
                                GhiChu = @GhiChu
                            WHERE MaHang = @MaHang";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaHang", maHang);
                        command.Parameters.AddWithValue("@TenHang", TenHH.Text);
                        command.Parameters.AddWithValue("@MaLoai", ((dynamic)Loaikinh.SelectedItem).MaLoai);
                        command.Parameters.AddWithValue("@MaLoaiGong", ((dynamic)Loaigong.SelectedItem).MaLoaiGong);
                        command.Parameters.AddWithValue("@MaDangMat", ((dynamic)Dangmat.SelectedItem).MaDangMat);
                        command.Parameters.AddWithValue("@MaChatLieu", ((dynamic)Chatlieu.SelectedItem).MaChatLieu);
                        command.Parameters.AddWithValue("@MaDiop", ((dynamic)Diop.SelectedItem).MaDiop);
                        command.Parameters.AddWithValue("@MaCongDung", ((dynamic)Congdung.SelectedItem).MaCongDung);
                        command.Parameters.AddWithValue("@MaDacDiem", ((dynamic)Dacdiem.SelectedItem).MaDacDiem);
                        command.Parameters.AddWithValue("@MaMau", ((dynamic)Mausac.SelectedItem).MaMau);
                        command.Parameters.AddWithValue("@MaNuocSX", ((dynamic)Nuocsanxuat.SelectedItem).MaNuocSX);
                        command.Parameters.AddWithValue("@SoLuong", soLuong);
                        command.Parameters.AddWithValue("@DonGiaNhap", donGiaNhap);
                        command.Parameters.AddWithValue("@DonGiaBan", donGiaBan);
                        command.Parameters.AddWithValue("@ThoiGianBaoHanh", Convert.ToInt32(Thoigianbaohanh.Text));
                        command.Parameters.AddWithValue("@GhiChu", Ghichu.Text);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            parentForm.loadData();
                            MessageBox.Show("Sửa hàng hóa thành công!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sửa hàng hóa thất bại.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
