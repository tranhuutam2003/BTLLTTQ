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
    public partial class ThemChiTietHoaDonNhap2 : Form
    {
        private int soHDN;
        private int MaNV;
        private string TenNV;
        public ThemChiTietHoaDonNhap2()
        {
            InitializeComponent();
            GenerateNewSoHDN();
            LoadComboBoxData();
            InitializeListView();
            dateTimePickerNgayNhap.Value = DateTime.Now;
        }

        public ThemChiTietHoaDonNhap2(string tenNV,int maNV)
        {
            InitializeComponent();
            this.TenNV = tenNV;
            lbtennhanvien.Text = tenNV;
            MaNV = maNV;
            GenerateNewSoHDN();
            LoadComboBoxData();
            InitializeListView();
            dateTimePickerNgayNhap.Value = DateTime.Now;
        }

        private void CalculateThanhTien()
        {
            if (int.TryParse(txtSoLuong.Text, out int soLuong) &&
                decimal.TryParse(txtDonGia.Text, out decimal donGia) &&
                decimal.TryParse(txtGiamGia.Text, out decimal giamGia))
            {
                decimal thanhTien = soLuong * donGia * (1 - giamGia / 100);
                txtThanhTien.Text = thanhTien.ToString("N2");
            }
            else
            {
                txtThanhTien.Text = "0";
            }
        }

        private void GenerateNewSoHDN()
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(SoHDN), 0) + 1 FROM HoaDonNhap", conn);
                soHDN = (int)cmd.ExecuteScalar();
                txtSoHDN.Text = soHDN.ToString();
                txtSoHDN.Enabled = false; // Không cho chỉnh sửa
            }
        }
        private void LoadComboBoxData()
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter daNCC = new SqlDataAdapter("SELECT MaNCC, TenNCC FROM NhaCungCap", conn);
                DataTable dtNCC = new DataTable();
                daNCC.Fill(dtNCC);
                cbMaNcc.DataSource = dtNCC;
                cbMaNcc.DisplayMember = "TenNCC";
                cbMaNcc.ValueMember = "MaNCC";
            }
        }
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            CalculateThanhTien() ;
        }
        private void ClearInputFields()
        {
            txtMaHang.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                return;
            }

            ListViewItem item = new ListViewItem(txtSoHDN.Text);
            item.SubItems.Add(txtSoLuong.Text);
            item.SubItems.Add(txtGiamGia.Text);
            item.SubItems.Add(txtMaHang.Text);
            item.SubItems.Add(txtDonGia.Text);
            item.SubItems.Add(lbtennhanvien.Text);
            item.SubItems.Add(cbMaNcc.SelectedValue.ToString());
            item.SubItems.Add(dateTimePickerNgayNhap.Value.ToString("dd/MM/yyyy"));
            item.SubItems.Add(txtThanhTien.Text);

            listView1.Items.Add(item);

            ClearInputFields();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtSoHDN.Text = item.SubItems[0].Text;
                txtSoLuong.Text = item.SubItems[1].Text;
                txtGiamGia.Text = item.SubItems[2].Text;
                txtMaHang.Text = item.SubItems[3].Text;
                txtDonGia.Text = item.SubItems[4].Text;
                lbtennhanvien.Text = item.SubItems[5].Text;
                cbMaNcc.SelectedValue = item.SubItems[6].Text;
                dateTimePickerNgayNhap.Value = DateTime.Parse(item.SubItems[7].Text);
                txtThanhTien.Text = item.SubItems[8].Text;
            }
        }
        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Số HĐN", 80);
            listView1.Columns.Add("Số Lượng", 80);
            listView1.Columns.Add("Giảm Giá (%)", 100);
            listView1.Columns.Add("Mã Hàng", 80);
            listView1.Columns.Add("Đơn Giá", 100);
            listView1.Columns.Add("Mã NV", 80);
            listView1.Columns.Add("Mã NCC", 80);
            listView1.Columns.Add("Ngày Nhập", 100);
            listView1.Columns.Add("Thành Tiền", 100);
        }
        private decimal CalculateTongTien()
        {
            decimal tongTien = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                tongTien += decimal.Parse(item.SubItems[4].Text);
            }
            return tongTien;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertHDNQuery = "INSERT INTO HoaDonNhap (SoHDN, MaNV, NgayNhap, MaNCC, TongTien) " +
                                            "VALUES (@SoHDN, @MaNV, @NgayNhap, @MaNCC, @TongTien)";
                    SqlCommand cmdHDN = new SqlCommand(insertHDNQuery, conn, transaction);
                    cmdHDN.Parameters.AddWithValue("@SoHDN", soHDN);
                    cmdHDN.Parameters.AddWithValue("@MaNV", MaNV);
                    cmdHDN.Parameters.AddWithValue("@NgayNhap", dateTimePickerNgayNhap.Value);
                    cmdHDN.Parameters.AddWithValue("@MaNCC", cbMaNcc.SelectedValue);
                    cmdHDN.Parameters.AddWithValue("@TongTien", CalculateTongTien());
                    cmdHDN.ExecuteNonQuery();

                    foreach (ListViewItem item in listView1.Items)
                    {
                        string maHang = item.SubItems[3].Text;
                        int soLuong = int.Parse(item.SubItems[1].Text);
                        decimal donGia = decimal.Parse(item.SubItems[4].Text);
                        decimal giamGia = decimal.Parse(item.SubItems[2].Text);
                        decimal thanhTien = decimal.Parse(item.SubItems[8].Text);

                        string insertCTHDNQuery = "INSERT INTO ChiTietHoaDonNhap (SoHDN, MaHang, SoLuong, GiamGia, DonGia, ThanhTien) " +
                                                  "VALUES (@SoHDN, @MaHang, @SoLuong, @GiamGia, @DonGia, @ThanhTien)";
                        SqlCommand cmdCTHDN = new SqlCommand(insertCTHDNQuery, conn, transaction);
                        cmdCTHDN.Parameters.AddWithValue("@SoHDN", soHDN);
                        cmdCTHDN.Parameters.AddWithValue("@MaHang", maHang);
                        cmdCTHDN.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdCTHDN.Parameters.AddWithValue("@GiamGia", giamGia);
                        cmdCTHDN.Parameters.AddWithValue("@DonGia", donGia);
                        cmdCTHDN.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        cmdCTHDN.ExecuteNonQuery();

                        // Cập nhật số lượng và đơn giá trong DanhMucHangHoa
                        string updateHangHoaQuery = "UPDATE DanhMucHangHoa SET SoLuong = SoLuong + @SoLuong, DonGiaNhap = @DonGia WHERE MaHang = @MaHang";
                        SqlCommand cmdUpdateHangHoa = new SqlCommand(updateHangHoaQuery, conn, transaction);
                        cmdUpdateHangHoa.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdUpdateHangHoa.Parameters.AddWithValue("@DonGia", donGia);
                        cmdUpdateHangHoa.Parameters.AddWithValue("@MaHang", maHang);
                        cmdUpdateHangHoa.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    AddNotification(TenNV, "hóa đơn nhập");
                    MessageBox.Show("Hóa đơn nhập đã được lưu thành công và số lượng hàng đã được cập nhật!");
                    listView1.Items.Clear();
                    GenerateNewSoHDN();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu hóa đơn nhập: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Xóa hàng được chọn
                listView1.Items.Remove(listView1.SelectedItems[0]);
                MessageBox.Show("Đã xóa hàng được chọn khỏi danh sách.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhaCungCap nhaCungCap = new NhaCungCap();
            nhaCungCap.Show();
        }

        private void AddNotification(string tenNV, string action)
        {
            string query = "INSERT INTO ThongBao (NguoiTao, NoiDung, NgayTao) VALUES (@NguoiTao, @NoiDung, @NgayTao)";
            string noiDung = $"{tenNV} đã tạo {action} vào ngày {DateTime.Now:dd/MM/yyyy HH:mm}";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NguoiTao", tenNV);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void txtSoHDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
