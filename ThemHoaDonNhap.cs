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
	public partial class ThemHoaDonNhap : Form
	{
		private bool isEditMode = false;
		private string editSoHDN = "";

		public ThemHoaDonNhap(bool isEditMode)
		{
			InitializeComponent();
			LoadMaNVToComboBox();
			//LoadMaNCCToComboBox();
			this.isEditMode = isEditMode;

			if (!isEditMode)
			{
				this.Text = "Thêm Hóa Đơn Nhập";
			}
		}

		private void ThemHoaDonNhap_Load(object sender, EventArgs e)
		{

		}

		public ThemHoaDonNhap(string soHDN, string maNV, DateTime ngayNhap, string maNCC, string tongTien)
		{
			InitializeComponent();

			textBox1.Text = soHDN;  // TextBox cho SoHDN
			comboBox2.Text = maNV;   // TextBox cho MaNV
			dateTimePicker1.Value = ngayNhap;  // DateTimePicker cho NgayNhap
			textBox4.Text = maNCC; // TextBox cho MaNCC
			decimal tongTienDecimal;
			if (decimal.TryParse(tongTien, out tongTienDecimal))
			{
				//textBox5.Text = tongTienDecimal.ToString("0.##");
				if (tongTienDecimal % 1 == 0)
				{
					textBox5.Text = tongTienDecimal.ToString("0");  // Hiển thị phần nguyên nếu không có phần thập phân
				}
				else
				{
					textBox5.Text = tongTienDecimal.ToString("0.##");  // Hiển thị cả phần thập phân nếu có
				}
			}
			else
			{
				textBox5.Text = tongTien;
			}
			editSoHDN = soHDN;
			this.Text = "Sửa Hóa Đơn Nhập";
		}

		public ThemHoaDonNhap()
		{
		}

		private bool XacNhanDuLieu(string soHDN, string maNV, string tongTien, string maNCC)
		{
			if (!int.TryParse(soHDN, out _))
			{
				MessageBox.Show("Số Hóa Đơn Nhập phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (!int.TryParse(maNV, out _))
			{
				MessageBox.Show("Mã Nhân Viên phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (!int.TryParse(maNCC, out _))
			{
				MessageBox.Show("Mã Nhà Cung Cấp phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if (!double.TryParse(tongTien, out _))
			{
				MessageBox.Show("Tổng Tiền phải là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}


		private void UpdateHoaDonNhap(string soHDN, string maNV, DateTime ngayNhap, string maNCC, string tongTien)
		{
			string query = "UPDATE HoaDonNhap SET MaNV = @MaNV, NgayNhap = @NgayNhap, MaNCC = @MaNCC, TongTien = @TongTien WHERE SoHDN = @SoHDN";

			using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
			{
				try
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@SoHDN", soHDN);
						command.Parameters.AddWithValue("@MaNV", maNV);
						command.Parameters.AddWithValue("@NgayNhap", ngayNhap);
						command.Parameters.AddWithValue("@MaNCC", maNCC);
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

		private void AddHoaDonNhap(string soHDN, string maNV, DateTime ngayNhap, string maNCC, decimal tongTien)
		{
			if (CheckSoHDNExists(soHDN))
			{
				MessageBox.Show("Số Hóa Đơn Nhập đã tồn tại. Vui lòng nhập số khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			//if (!CheckMaNVExists(maNV))
			//{
			//	MessageBox.Show("Mã Nhân Viên không tồn tại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}
			if (!CheckMaNCCExists(maNCC))
			{
				MessageBox.Show("Mã Nhà Cung Cấp không tồn tại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string query = "INSERT INTO HoaDonNhap (SoHDN, MaNV, NgayNhap, MaNCC, TongTien) VALUES (@SoHDN, @MaNV, @NgayNhap, @MaNCC, @TongTien)";
			using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@SoHDN", soHDN);
					command.Parameters.AddWithValue("@MaNV", maNV);
					command.Parameters.AddWithValue("@NgayNhap", ngayNhap);
					command.Parameters.AddWithValue("@MaNCC", maNCC);
					command.Parameters.AddWithValue("@TongTien", tongTien);

					command.ExecuteNonQuery();
					MessageBox.Show("Thêm hóa đơn thành công!");
				}
			}
		}

		private bool CheckMaNCCExists(string maNCC)
		{
			string query = "SELECT COUNT(*) FROM NhaCungCap WHERE MaNCC = @MaNCC";
			using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@MaNCC", maNCC);
					int count = (int)command.ExecuteScalar();
					return count > 0;
				}
			}
		}

		private bool CheckSoHDNExists(string soHDN)
		{
			// Khi ở chế độ sửa và số hóa đơn không thay đổi, bỏ qua kiểm tra
			if (isEditMode && soHDN == editSoHDN)
			{
				return false;  // Bỏ qua kiểm tra nếu đang sửa và số hóa đơn không thay đổi
			}

			// Kiểm tra xem số hóa đơn có tồn tại hay không trong trường hợp thêm mới
			string query = "SELECT COUNT(*) FROM HoaDonNhap WHERE SoHDN = @SoHDN";
			using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@SoHDN", soHDN);
					int count = (int)command.ExecuteScalar();
					return count > 0;  // Trả về true nếu SoHDN đã tồn tại
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
					string query = "SELECT MaNV FROM NhanVien";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							comboBox2.Items.Clear();
							while (reader.Read())
							{
								comboBox2.Items.Add(reader["MaNV"].ToString());
							}
						}
					}
				}
				SetupComboBoxAutoComplete();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
			}
		}

		private void LoadMaNCCToComboBox()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
				{
					connection.Open();
					string query = "SELECT MaNCC FROM NhaCungCap";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							comboBox2.Items.Clear();
							while (reader.Read())
							{
								comboBox2.Items.Add(reader["MaNCC"].ToString());
							}
						}
					}
				}
				SetupComboBoxAutoCompleteNCC();
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

		private void SetupComboBoxAutoCompleteNCC()
		{
			comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			string soHDN = textBox1.Text;  // TextBox cho SoHDN
			string maNV = comboBox2.Text;   // ComboBox cho MaNV
			DateTime ngayNhap = dateTimePicker1.Value;  // DateTimePicker cho NgayNhap
			string tongTien = textBox5.Text;  // TextBox cho TongTien
			string maNCC = textBox4.Text;   // TextBox cho MaNCC

			if (XacNhanDuLieu(soHDN, maNV, tongTien, maNCC))
			{
				if (!isEditMode)  // Nếu ở chế độ sửa
				{
				
					UpdateHoaDonNhap(soHDN, maNV, ngayNhap, maNCC, tongTien);
				}
				else  // Nếu ở chế độ thêm
				{
					// Chỉ kiểm tra số hóa đơn tồn tại khi thêm mới
					if (CheckSoHDNExists(soHDN))
					{
						MessageBox.Show("Số Hóa Đơn Nhập đã tồn tại. Vui lòng nhập số khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					decimal tongTienDecimal = decimal.Parse(tongTien);
					AddHoaDonNhap(soHDN, maNV, ngayNhap, maNCC, tongTienDecimal);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng kiểm tra lại dữ liệu nhập vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void btnBack_Click_1(object sender, EventArgs e)
		{
			this.Close();
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
        private void ThemHoaDonNhap_Load_1(object sender, EventArgs e)
        {
            //textBox1.Text = GenerateNewID().ToString();
        }
    }
}
