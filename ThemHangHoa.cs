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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ghichu_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dongiaban_TextChanged(object sender, EventArgs e)
        {

        }
    }
}