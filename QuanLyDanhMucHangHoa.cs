using System;
using ClosedXML.Excel;
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
    public partial class QuanLyDanhMucHangHoa : Form
    {
        private string TenNV;
        private string CongViec;
        private int MaNV;
        public QuanLyDanhMucHangHoa()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            loadData();
        }

        public QuanLyDanhMucHangHoa(string tenNV, string congViec, int maNV)
        {
            InitializeComponent();
            TenNV = tenNV;   // Set user information
            CongViec = congViec;
            loadData();
            MaNV = maNV;
        }

        public void loadData()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    // Truy vấn kết hợp để lấy tên từ các bảng liên quan
                    string query = @"
                        SELECT 
                            dh.MaHang,
                            dh.TenHang,
                            lk.TenLoai AS TenLoai,
                            gm.TenLoaiGong AS TenLoaiGong,
                            hd.TenDangMat AS TenDangMat,
                            cl.TenChatLieu AS TenChatLieu,
                            di.TenDiop AS TenDiop,
                            cd.TenCongDung AS CongDung,
                            dc.TenDacDiem AS TenDacDiem,
                            ms.TenMau AS TenMau,
                            ns.TenNuocSX AS TenNuocSX,
                            dh.SoLuong,
                            dh.DonGiaNhap,
                            dh.DonGiaBan,
                            dh.ThoiGianBaoHanh,
                            dh.GhiChu
                        FROM 
                            DanhMucHangHoa dh
                        LEFT JOIN 
                            LoaiKinh lk ON dh.MaLoai = lk.MaLoai
                        LEFT JOIN 
                            GongMat gm ON dh.MaLoaiGong = gm.MaLoaiGong
                        LEFT JOIN 
                            HinhDangMat hd ON dh.MaDangMat = hd.MaDangMat
                        LEFT JOIN 
                            ChatLieu cl ON dh.MaChatLieu = cl.MaChatLieu
                        LEFT JOIN 
                            Diop di ON dh.MaDiop = di.MaDiop
                        LEFT JOIN 
                            CongDung cd ON dh.MaCongDung = cd.MaCongDung
                        LEFT JOIN 
                            DacDiem dc ON dh.MaDacDiem = dc.MaDacDiem
                        LEFT JOIN 
                            MauSac ms ON dh.MaMau = ms.MaMau
                        LEFT JOIN 
                            NuocSanXuat ns ON dh.MaNuocSX = ns.MaNuocSX";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Gán dữ liệu cho DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Đặt tên hiển thị cho các cột
                    dataGridView1.Columns["MaHang"].HeaderText = "Mã Sản Phẩm";
                    dataGridView1.Columns["TenHang"].HeaderText = "Tên Hàng";
                    dataGridView1.Columns["TenLoai"].HeaderText = "Loại Kính";
                    dataGridView1.Columns["TenLoaiGong"].HeaderText = "Loại Gọng";
                    dataGridView1.Columns["TenDangMat"].HeaderText = "Hình Dáng";
                    dataGridView1.Columns["TenChatLieu"].HeaderText = "Chất Liệu";
                    dataGridView1.Columns["TenDiop"].HeaderText = "Diop";
                    dataGridView1.Columns["CongDung"].HeaderText = "Công Dụng";
                    dataGridView1.Columns["TenDacDiem"].HeaderText = "Đặc Điểm";
                    dataGridView1.Columns["TenMau"].HeaderText = "Màu Sắc";
                    dataGridView1.Columns["TenNuocSX"].HeaderText = "Nước Sản Xuất";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
        }

        private void Them_Click(object sender, EventArgs e)
        {
            MainHangHoa thh = new MainHangHoa();
            thh.Show();
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ hàng được chọn trong DataGridView
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maHang = selectedRow.Cells["MaHang"].Value.ToString();
                string tenHang = selectedRow.Cells["TenHang"].Value.ToString();
                string tenLoai = selectedRow.Cells["TenLoai"].Value.ToString();
                string tenLoaiGong = selectedRow.Cells["TenLoaiGong"].Value.ToString();
                string tenDangMat = selectedRow.Cells["TenDangMat"].Value.ToString();
                string tenChatLieu = selectedRow.Cells["TenChatLieu"].Value.ToString();
                string tenDiop = selectedRow.Cells["TenDiop"].Value.ToString();
                string congDung = selectedRow.Cells["CongDung"].Value.ToString();
                string tenDacDiem = selectedRow.Cells["TenDacDiem"].Value.ToString();
                string tenMau = selectedRow.Cells["TenMau"].Value.ToString();
                string tenNuocSX = selectedRow.Cells["TenNuocSX"].Value.ToString();
                int soLuong = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value);
                decimal donGiaNhap = Convert.ToDecimal(selectedRow.Cells["DonGiaNhap"].Value);
                decimal donGiaBan = Convert.ToDecimal(selectedRow.Cells["DonGiaBan"].Value);
                int thoiGianBaoHanh = Convert.ToInt32(selectedRow.Cells["ThoiGianBaoHanh"].Value);
                string ghiChu = selectedRow.Cells["GhiChu"].Value.ToString();

                // Tạo và truyền dữ liệu vào form SuaHangHoa
                SuaHangHoa suaHangHoa = new SuaHangHoa(this,maHang, tenHang, tenLoai, tenLoaiGong, tenDangMat,
                                                        tenChatLieu, tenDiop, congDung, tenDacDiem, tenMau,
                                                        tenNuocSX, soLuong, donGiaNhap, donGiaBan,
                                                        thoiGianBaoHanh, ghiChu);

                // Hiển thị form SuaHangHoa
                suaHangHoa.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần sửa.");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home
            {
                TenNV = TenNV,
                CongViec = CongViec,
                MaNV = MaNV
            };
            homeForm.Show();
            this.Close();
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy mã hàng hóa từ hàng được chọn
                string maHang = dataGridView1.SelectedRows[0].Cells["MaHang"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                    {
                        try
                        {
                            connection.Open();
                            // Sử dụng câu lệnh UPDATE để thực hiện soft delete
                            string query = "DELETE FROM DanhMucHangHoa WHERE MaHang = @MaHang";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaHang", maHang);
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Hàng hóa đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Cập nhật lại DataGridView
                                    loadData();
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy hàng hóa để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa hàng hóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                Title = "Lưu file Quản lí Hàng Hóa"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        DataTable dataTable = (DataTable)dataGridView1.DataSource;

                        workbook.Worksheets.Add(dataTable, "DanhMucHangHoa");

                        workbook.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "DonGiaNhap" || dataGridView1.Columns[e.ColumnIndex].Name == "DonGiaBan")
            {
                if (e.Value != DBNull.Value && e.Value != null)
                {
                    decimal value = Convert.ToDecimal(e.Value);

                    // Kiểm tra nếu số không có phần thập phân khác 0
                    if (value % 1 == 0)
                    {
                        e.Value = value.ToString("0"); // Hiển thị chỉ phần nguyên nếu không có phần thập phân
                    }
                    else
                    {
                        e.Value = value.ToString("0.##");  // Hiển thị tối đa 2 chữ số thập phân nếu có phần lẻ
                    }
                    e.FormattingApplied = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HangHoaReport hhrp = new HangHoaReport();
            hhrp.Show();
        }
    }
}
