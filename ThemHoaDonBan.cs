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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL_LTTQ_VIP
{
	public partial class ThemHoaDonBan : Form
	{
		//co 1
		private bool isEditMode = false;
		private string editSoHDB = "";

		public ThemHoaDonBan( bool isEditMode)
		{
			InitializeComponent();
			LoadMaNVToComboBox();
			this.isEditMode = isEditMode;

			if (!isEditMode)
			{
				this.Text = "Thêm Hóa Đơn Bán";
			}
		}

		private void ThemHoaDonBan_Load(object sender, EventArgs e)
		{

		}
		public ThemHoaDonBan(string soHDB, string maNV, DateTime ngayBan, string maKhach, string tongTien)
		{
			InitializeComponent();

			textBox1.Text = soHDB; 
			comboBox2.Text= maNV;   
			dateTimePicker1.Value = ngayBan;  
			textBox4.Text = maKhach; 
			decimal tongTienDecimal;
			if (decimal.TryParse(tongTien, out tongTienDecimal))
			{
				if (tongTienDecimal % 1 == 0)
				{
					textBox5.Text = tongTienDecimal.ToString("0"); 
				}
				else
				{
					textBox5.Text = tongTienDecimal.ToString("0.##");  
				}
			}
			else
			{
				textBox5.Text = tongTien;  
			}
			editSoHDB = soHDB;
			this.Text = "Sửa Hóa Đơn Bán";
		}
		private bool XacNhanDuLieu(string soHDB, string maNV, string tongTien, string maKhach)
		{
			if (!int.TryParse(soHDB, out _))
			{
				MessageBox.Show("Số Hóa Đơn Bán phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (!int.TryParse(maNV, out _))
			{
				MessageBox.Show("Mã Nhân Viên phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (!int.TryParse(maKhach, out _))
			{
				MessageBox.Show("Mã Khách Hàng phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if (!double.TryParse(tongTien, out _))
			{
				MessageBox.Show("Tổng Tiền phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			string soHDB = textBox1.Text;  
			string maNV = comboBox2.Text;  
			DateTime ngayBan = dateTimePicker1.Value;  
			string tongTien = textBox5.Text; 
			string maKhach = textBox4.Text;   
											  //decimal tongTien = decimal.Parse(textBox5.Text);

			if (XacNhanDuLieu(soHDB, maNV, tongTien, maKhach))
			{
				if (isEditMode)  
				{
					UpdateHoaDonBan(soHDB, maNV, ngayBan, maKhach, tongTien);  
				}
				else  
				{
					decimal tongTienDecimal = decimal.Parse(tongTien);
					AddHoaDonBan(soHDB, maNV, ngayBan, maKhach, tongTienDecimal); 
				}
			}
			else
			{
				MessageBox.Show("Vui lòng kiểm tra lại dữ liệu nhập vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}



		private void btnBack_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void UpdateHoaDonBan(string soHDB, string maNV, DateTime ngayBan, string maKhach, string tongTien)
		{
			string query = "UPDATE HoaDonBan SET MaNV = @MaNV, NgayBan = @NgayBan, MaKhach = @MaKhach, TongTien = @TongTien WHERE SoHDB = @SoHDB";

			using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
			{
				try
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@SoHDB", soHDB);
						command.Parameters.AddWithValue("@MaNV", maNV);
						command.Parameters.AddWithValue("@NgayBan", ngayBan);
						command.Parameters.AddWithValue("@MaKhach", maKhach);
						command.Parameters.AddWithValue("@TongTien", tongTien);

						int rowsAffected = command.ExecuteNonQuery();
						if (rowsAffected > 0)
						{
							MessageBox.Show("Sửa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							MessageBox.Show("Không tìm thấy hóa đơn cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void ClearForm()
		{
			textBox1.Text = "";
			comboBox2.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			dateTimePicker1.Value = DateTime.Now;
		}
		private void AddHoaDonBan(string soHDB, string maNV, DateTime ngayBan, string maKhach, decimal tongTien)
		{
			if (CheckSoHDBExists(soHDB))
			{
				MessageBox.Show("Số Hóa Đơn Bán đã tồn tại. Vui lòng nhập số khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (!CheckMaNVExists(maNV))
			{
				MessageBox.Show("Mã Nhân Viên không tồn tại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (!CheckMaKhachExists(maKhach))
			{
				MessageBox.Show("Mã Khách Hàng không tồn tại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string query = "INSERT INTO HoaDonBan (SoHDB, MaNV, NgayBan, MaKhach, TongTien) VALUES (@SoHDB, @MaNV, @NgayBan, @MaKhach, @TongTien)";
			using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@SoHDB", soHDB);
					command.Parameters.AddWithValue("@MaNV", maNV);
					command.Parameters.AddWithValue("@NgayBan", ngayBan);
					command.Parameters.AddWithValue("@MaKhach", maKhach);
					command.Parameters.AddWithValue("@TongTien", tongTien);

					command.ExecuteNonQuery();
					MessageBox.Show("Thêm hóa đơn thành công!");
				}
			}
            AddNotification(maNV, "hóa đơn bán");
        }
		private bool CheckMaKhachExists(string maKhach)
		{
			string query = "SELECT COUNT(*) FROM KhachHang WHERE MaKhach = @MaKhach";
			using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@MaKhach", maKhach);
					int count = (int)command.ExecuteScalar();
					return count > 0;
				}
			}
		}

		private bool CheckMaNVExists(string maNV)
		{
			string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
			using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@MaNV", maNV);
					int count = (int)command.ExecuteScalar();
					return count > 0;
				}
			}
		}
		private void LoadMaNVToComboBox()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
				{
					connection.Open();

					// Câu lệnh SELECT để lấy dữ liệu từ cột MaNV của bảng NhanVien
					string query = "SELECT MaNV FROM NhanVien";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							// Xóa các item hiện tại trong ComboBox (nếu có)
							comboBox2.Items.Clear();

							// Duyệt qua từng hàng dữ liệu và thêm vào ComboBox
							while (reader.Read())
							{
								comboBox2.Items.Add(reader["MaNV"].ToString());
							}
						}
					}
				}
				//thu
				SetupComboBoxAutoComplete();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
			}


		}
		private void SetupComboBoxAutoComplete()
		{
			comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
		}
		private bool CheckSoHDBExists(string soHDB)
		{
			string query = "SELECT COUNT(*) FROM HoaDonBan WHERE SoHDB = @SoHDB";
			using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@SoHDB", soHDB);
					int count = (int)command.ExecuteScalar();
					return count > 0;  
				}
			}
		}

        private void AddNotification(string maNV, string action)
        {
            string query = "INSERT INTO ThongBao (NguoiNhan, NoiDung, NgayTao) VALUES (@NguoiNhan, @NoiDung, @NgayTao)";
            string noiDung = $"{maNV} đã tạo {action} vào ngày {DateTime.Now:dd/MM/yyyy HH:mm}";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NguoiNhan", maNV);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private int GenerateNewID()
        {
            int newID = 1;

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(MaCongDung) FROM CongDung";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            newID = Convert.ToInt32(result) + 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo mã hàng mới: " + ex.Message);
                }
            }

            return newID;
        }
        private void ThemHoaDonBan_Load_1(object sender, EventArgs e)
        {
            textBox1.Text = GenerateNewID().ToString();
        }
    }
}

