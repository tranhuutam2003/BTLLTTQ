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
	public partial class ThemHangHoa : Form
	{
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

        private void LoadLoaiGong()
        {
            LoadComboBoxData("SELECT MaLoaiGong, TenLoaiGong FROM GongMat", Loaigong, "MaLoaiGong", "TenLoaiGong", "Lỗi khi lấy danh sách loại gọng");
        }

        private void LoadCongDung()
        {
            LoadComboBoxData("SELECT MaCongDung, TenCongDung FROM CongDung", Congdung, "MaCongDung", "TenCongDung", "Lỗi khi lấy danh sách công dụng");
        }

        private void LoadLoaikinh()
        {
            LoadComboBoxData("SELECT MaLoai, TenLoai FROM LoaiKinh", Loaikinh, "MaLoai", "TenLoai", "Lỗi khi lấy danh sách loại kính");
        }

        private void LoadHinhDangMat()
        {
            LoadComboBoxData("SELECT MaDangMat, TenDangMat FROM HinhDangMat", Dangmat, "MaDangMat", "TenDangMat", "Lỗi khi lấy danh sách hình dáng mắt");
        }

        private void LoadChatLieu()
        {
            LoadComboBoxData("SELECT MaChatLieu, TenChatLieu FROM ChatLieu", Chatlieu, "MaChatLieu", "TenChatLieu", "Lỗi khi lấy danh sách chất liệu");
        }

        private void LoadNuocSanXuat()
        {
            LoadComboBoxData("SELECT MaNuocSX, TenNuocSX FROM NuocSanXuat", Nuocsanxuat, "MaNuocSX", "TenNuocSX", "Lỗi khi lấy danh sách nước sản xuất");
        }

        private void LoadMauSac()
        {
            LoadComboBoxData("SELECT MaMau, TenMau FROM MauSac", Mausac, "MaMau", "TenMau", "Lỗi khi lấy danh sách màu sắc");
        }

        private void LoadDiop()
        {
            LoadComboBoxData("SELECT MaDiop, TenDiop FROM Diop", Diop, "MaDiop", "TenDiop", "Lỗi khi lấy danh sách diop");
        }

        private void LoadDacDiem()
        {
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
                        comboBox.Items.Add(new { Value = reader[valueMember], Text = reader[displayMember].ToString() });
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
						command.Parameters.AddWithValue("@MaLoai", ((dynamic)Loaikinh.SelectedItem).MaLoai);
						command.Parameters.AddWithValue("@MaLoaiGong", ((dynamic)Loaigong.SelectedItem).MaLoaiGong);
						command.Parameters.AddWithValue("@MaDangMat", ((dynamic)Dangmat.SelectedItem).MaDangMat);
						command.Parameters.AddWithValue("@MaChatLieu", ((dynamic)Chatlieu.SelectedItem).MaChatLieu);
						command.Parameters.AddWithValue("@MaDiop", ((dynamic)Diop.SelectedItem).MaDiop);
						command.Parameters.AddWithValue("@MaCongDung", ((dynamic)Congdung.SelectedItem).MaCongDung);
						command.Parameters.AddWithValue("@MaDacDiem", ((dynamic)Dacdiem.SelectedItem).MaDacDiem);
						command.Parameters.AddWithValue("@MaMau", ((dynamic)Mausac.SelectedItem).MaMau);
						command.Parameters.AddWithValue("@MaNuocSX", ((dynamic)Nuocsanxuat.SelectedItem).MaNuocSX);
						command.Parameters.AddWithValue("@DonGiaBan", Convert.ToDecimal(Dongiaban.Text));
						command.Parameters.AddWithValue("@ThoiGianBaoHanh", Convert.ToInt32(Thoigianbaohanh.Text));
						command.Parameters.AddWithValue("@GhiChu", Ghichu.Text);

						int result = command.ExecuteNonQuery();

						if (result > 0)
						{
							MessageBox.Show("Thêm hàng hóa thành công!");
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

		private void themloaikinh_Click(object sender, EventArgs e)
		{
			ThemLoaiKinh tlk = new ThemLoaiKinh();
			tlk.Show();
			
		}

		private void themloaigong_Click(object sender, EventArgs e)
		{
			ThemGongMat tgm = new ThemGongMat();
			tgm.Show();
			
		}

		private void Themdangmat_Click(object sender, EventArgs e)
		{
			ThemHinhDangMat thdm = new ThemHinhDangMat();
			thdm.Show();
			
		}

		private void themchatlieu_Click(object sender, EventArgs e)
		{
			ThemChatLieu themChatLieu = new ThemChatLieu();
			themChatLieu.Show();
			
		}

		private void themdiop_Click(object sender, EventArgs e)
		{
			ThemDiop themDiop = new ThemDiop();
			themDiop.Show();
			
		}

		private void themcongdung_Click(object sender, EventArgs e)
		{
			ThemCongDung tcd = new ThemCongDung();
			tcd.Show();
			
		}

		private void themdacdiem_Click(object sender, EventArgs e)
		{
			ThemDacDiem tdd = new ThemDacDiem();
			tdd.Show();
		}

		private void themmausac_Click(object sender, EventArgs e)
		{
			ThemMauSac tms = new ThemMauSac();
			tms.Show();
		}

		private void themnuocsanxuat_Click(object sender, EventArgs e)
		{
			ThemNuocSanXuat tnsx = new ThemNuocSanXuat();
			tnsx.Show();
		}

        private void Exit_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}