using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemHangHoa : Form
    {
        public event EventHandler HangHoaAdded;

        public ThemHangHoa()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            LoadLoaiGong();
            LoadCongDung();
            LoadLoaikinh();
            LoadHinhDangMat();
            LoadChatLieu();
            LoadNuocSanXuat();
            LoadMauSac();
            LoadDiop();
            LoadDacDiem();
        }
        private bool IsInputValid()
        {
            if (string.IsNullOrWhiteSpace(TenHH.Text) ||
                Loaikinh.SelectedItem == null ||
                Loaigong.SelectedItem == null ||
                Dangmat.SelectedItem == null ||
                Chatlieu.SelectedItem == null ||
                Diop.SelectedItem == null ||
                Congdung.SelectedItem == null ||
                Dacdiem.SelectedItem == null ||
                Mausac.SelectedItem == null ||
                Nuocsanxuat.SelectedItem == null ||
                string.IsNullOrWhiteSpace(Dongiaban.Text) ||
                string.IsNullOrWhiteSpace(Thoigianbaohanh.Text))
            {
                return false;
            }
            return true;
        }
        private void LoadLoaiGong()
        {
            Loaigong.Items.Clear();
            LoadComboBoxData("SELECT MaLoaiGong, TenLoaiGong FROM GongMat", Loaigong, "MaLoaiGong", "TenLoaiGong", "Lỗi khi lấy danh sách loại gọng");
        }

        private void LoadCongDung()
        {
            Congdung.Items.Clear();
            LoadComboBoxData("SELECT MaCongDung, TenCongDung FROM CongDung", Congdung, "MaCongDung", "TenCongDung", "Lỗi khi lấy danh sách công dụng");
        }

        private void LoadLoaikinh()
        {
            Loaikinh.Items.Clear();
            LoadComboBoxData("SELECT MaLoai, TenLoai FROM LoaiKinh", Loaikinh, "MaLoai", "TenLoai", "Lỗi khi lấy danh sách loại kính");
        }

        private void LoadHinhDangMat()
        {
            Dangmat.Items.Clear();
            LoadComboBoxData("SELECT MaDangMat, TenDangMat FROM HinhDangMat", Dangmat, "MaDangMat", "TenDangMat", "Lỗi khi lấy danh sách hình dáng mắt");
        }

        private void LoadChatLieu()
        {
            Chatlieu.Items.Clear();
            LoadComboBoxData("SELECT MaChatLieu, TenChatLieu FROM ChatLieu", Chatlieu, "MaChatLieu", "TenChatLieu", "Lỗi khi lấy danh sách chất liệu");
        }

        private void LoadNuocSanXuat()
        {
            Nuocsanxuat.Items.Clear();
            LoadComboBoxData("SELECT MaNuocSX, TenNuocSX FROM NuocSanXuat", Nuocsanxuat, "MaNuocSX", "TenNuocSX", "Lỗi khi lấy danh sách nước sản xuất");
        }

        private void LoadMauSac()
        {
            Mausac.Items.Clear();
            LoadComboBoxData("SELECT MaMau, TenMau FROM MauSac", Mausac, "MaMau", "TenMau", "Lỗi khi lấy danh sách màu sắc");
        }

        private void LoadDiop()
        {
            Diop.Items.Clear();
            LoadComboBoxData("SELECT MaDiop, TenDiop FROM Diop", Diop, "MaDiop", "TenDiop", "Lỗi khi lấy danh sách diop");
        }

        private void LoadDacDiem()
        {
            Dacdiem.Items.Clear();
            LoadComboBoxData("SELECT MaDacDiem, TenDacDiem FROM DacDiem", Dacdiem, "MaDacDiem", "TenDacDiem", "Lỗi khi lấy danh sách đặc điểm");
        }

        private void LoadComboBoxData(string query, ComboBox comboBox, string valueMember, string displayMember, string errorMessage)
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox.Items.Add(new ComboBoxItem
                        {
                            Value = reader[valueMember],
                            Text = reader[displayMember].ToString()
                        });
                    }

                    comboBox.DisplayMember = "Text";
                    comboBox.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(errorMessage + ": " + ex.Message);
                }
            }
        }

        private void Xacnhan_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO DanhMucHangHoa 
                            (MaHang, TenHang, MaLoai, MaLoaiGong, MaDangMat, MaChatLieu, 
                             MaDiop, MaCongDung, MaDacDiem, MaMau, MaNuocSX, SoLuong, 
                             DonGiaNhap, DonGiaBan, ThoiGianBaoHanh, GhiChu)
                            VALUES 
                            (@MaHang, @TenHang, @MaLoai, @MaLoaiGong, @MaDangMat, @MaChatLieu,
                             @MaDiop, @MaCongDung, @MaDacDiem, @MaMau, @MaNuocSX, 0, 
                             0, @DonGiaBan, @ThoiGianBaoHanh, @GhiChu)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaHang", Convert.ToInt32(MaHH.Text));
                        command.Parameters.AddWithValue("@TenHang", TenHH.Text);
                        command.Parameters.AddWithValue("@MaLoai", ((ComboBoxItem)Loaikinh.SelectedItem ).Value);
                        command.Parameters.AddWithValue("@MaLoaiGong", ((ComboBoxItem)Loaigong.SelectedItem).Value);
                        command.Parameters.AddWithValue("@MaDangMat", ((ComboBoxItem)Dangmat.SelectedItem).Value);
                        command.Parameters.AddWithValue("@MaChatLieu", ((ComboBoxItem)Chatlieu.SelectedItem).Value);
                        command.Parameters.AddWithValue("@MaDiop", ((ComboBoxItem)Diop.SelectedItem).Value);
                        command.Parameters.AddWithValue("@MaCongDung", ((ComboBoxItem)Congdung.SelectedItem).Value);
                        command.Parameters.AddWithValue("@MaDacDiem", ((ComboBoxItem)Dacdiem.SelectedItem).Value);
                        command.Parameters.AddWithValue("@MaMau", ((ComboBoxItem)Mausac.SelectedItem).Value);
                        command.Parameters.AddWithValue("@MaNuocSX", ((ComboBoxItem)Nuocsanxuat.SelectedItem).Value);
                        command.Parameters.AddWithValue("@DonGiaBan", Convert.ToDecimal(Dongiaban.Text));
                        command.Parameters.AddWithValue("@ThoiGianBaoHanh", Convert.ToInt32(Thoigianbaohanh.Text));
                        command.Parameters.AddWithValue("@GhiChu", Ghichu.Text);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Thêm hàng hóa thành công!");
                            HangHoaAdded?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("Thêm hàng hóa thất bại.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private int GenerateNewMaHang()
        {
            int newMaHang = 1; 

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(MaHang) FROM DanhMucHangHoa";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            newMaHang = Convert.ToInt32(result) + 1; 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo mã hàng mới: " + ex.Message);
                }
            }

            return newMaHang;
        }

        private void ThemHangHoa_Load(object sender, EventArgs e)
        {
            MaHH.Text = GenerateNewMaHang().ToString(); 
            Thoigianbaohanh.Text = "12"; 
        }
    }

    public class ComboBoxItem
    {
        public object Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
