using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BTL_LTTQ_VIP
{
    public partial class KhachHangReport : Form
    {
        private string TenNV;
        public KhachHangReport(string tenNV)
        {
            InitializeComponent();
            TenNV = tenNV;
            LoadKhachHangToComboBox();
        }

        private void LoadKhachHangToComboBox()
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                string query = "SELECT MaKhach, TenKhach FROM KhachHang";  // Lấy mã khách và tên khách từ bảng KhachHang
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbbkhachhang.DataSource = dt;
                cbbkhachhang.DisplayMember = "TenKhach";  // Hiển thị tên khách hàng
                cbbkhachhang.ValueMember = "MaKhach";     // Giá trị là mã khách hàng
            }
        }

        private void KhachHangReport_Load(object sender, EventArgs e)
        {
            // Khởi tạo dataset cho báo cáo
            DataSet reportkh = new DataSet();

            // Câu truy vấn SQL để lấy dữ liệu khách hàng và hóa đơn
            string query = @"SELECT    KhachHang.MaKhach, KhachHang.TenKhach, KhachHang.DiaChi, KhachHang.DienThoai, 
                                      HoaDonBan.TongTien, HoaDonBan.SoHDB, HoaDonBan.NgayBan, 
                                      ChiTietHoaDonBan.MaHang, ChiTietHoaDonBan.SoLuong, ChiTietHoaDonBan.GiamGia, ChiTietHoaDonBan.ThanhTien, 
                                      DanhMucHangHoa.TenHang, DanhMucHangHoa.DonGiaBan
                             FROM ChiTietHoaDonBan 
                             INNER JOIN DanhMucHangHoa ON ChiTietHoaDonBan.MaHang = DanhMucHangHoa.MaHang 
                             INNER JOIN HoaDonBan ON ChiTietHoaDonBan.SoHDB = HoaDonBan.SoHDB 
                             INNER JOIN KhachHang ON HoaDonBan.MaKhach = KhachHang.MaKhach";

            // Thiết lập kết nối SQL
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                // Điền dữ liệu vào DataTable
                adapter.Fill(reportkh.Tables["KhachHangTable"]);
            }

            // Thiết lập nguồn dữ liệu cho báo cáo
            ReportDataSource rds = new ReportDataSource("KhachHangDataSet", reportkh.Tables["KhachHangTable"]);
            KhachHangRp.LocalReport.DataSources.Clear();
            KhachHangRp.LocalReport.DataSources.Add(rds);

            ReportParameter paramNguoiTao = new ReportParameter("NguoiTaoBaoCao", TenNV);
            KhachHangRp.LocalReport.SetParameters(new ReportParameter[] { paramNguoiTao });
            // Chỉ định đường dẫn đến file báo cáo RDLC
            KhachHangRp.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\KhachHangReport.rdlc"; // Đường dẫn đến file RDLC của bạn

            // Làm mới ReportViewer để hiển thị dữ liệu
            KhachHangRp.RefreshReport();
        }

        private void LoadReport(string maKhach)
        {
            DataSet reportkh = new DataSet();

            // Truy vấn dữ liệu chi tiết khách hàng
            string query = @"SELECT    KhachHang.MaKhach, KhachHang.TenKhach, KhachHang.DiaChi, KhachHang.DienThoai, 
                                        HoaDonBan.TongTien, HoaDonBan.SoHDB, HoaDonBan.NgayBan, 
                                        ChiTietHoaDonBan.MaHang, ChiTietHoaDonBan.SoLuong, ChiTietHoaDonBan.GiamGia, ChiTietHoaDonBan.ThanhTien, 
                                        DanhMucHangHoa.TenHang, DanhMucHangHoa.DonGiaBan
                             FROM ChiTietHoaDonBan 
                             INNER JOIN DanhMucHangHoa ON ChiTietHoaDonBan.MaHang = DanhMucHangHoa.MaHang 
                             INNER JOIN HoaDonBan ON ChiTietHoaDonBan.SoHDB = HoaDonBan.SoHDB 
                             INNER JOIN KhachHang ON HoaDonBan.MaKhach = KhachHang.MaKhach
                             WHERE KhachHang.MaKhach = @MaKhach";

            // Truy vấn để tính tổng tiền khách hàng đã chi tiêu
            string totalSpentQuery = @"SELECT SUM(TongTien) AS TotalSpent 
                                       FROM HoaDonBan 
                                       WHERE MaKhach = @MaKhach";

            // Truy vấn để tìm sản phẩm khách hàng mua nhiều nhất
            string mostPurchasedProductQuery = @"SELECT TOP 1 DanhMucHangHoa.TenHang, SUM(ChiTietHoaDonBan.SoLuong) AS TotalQuantity
                                                 FROM ChiTietHoaDonBan
                                                 INNER JOIN DanhMucHangHoa ON ChiTietHoaDonBan.MaHang = DanhMucHangHoa.MaHang
                                                 INNER JOIN HoaDonBan ON ChiTietHoaDonBan.SoHDB = HoaDonBan.SoHDB
                                                 WHERE HoaDonBan.MaKhach = @MaKhach
                                                 GROUP BY DanhMucHangHoa.TenHang
                                                 ORDER BY TotalQuantity DESC";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                // Lấy dữ liệu khách hàng và hóa đơn
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MaKhach", maKhach);

                if (!reportkh.Tables.Contains("KhachHangTable"))
                {
                    reportkh.Tables.Add("KhachHangTable");
                }
                adapter.Fill(reportkh.Tables["KhachHangTable"]);

                // Lấy tổng chi tiêu của khách hàng
                SqlCommand totalSpentCommand = new SqlCommand(totalSpentQuery, conn);
                totalSpentCommand.Parameters.AddWithValue("@MaKhach", maKhach);
                conn.Open();
                var totalSpent = totalSpentCommand.ExecuteScalar();
                conn.Close();

                // Lấy sản phẩm mua nhiều nhất của khách hàng
                SqlCommand mostPurchasedProductCommand = new SqlCommand(mostPurchasedProductQuery, conn);
                mostPurchasedProductCommand.Parameters.AddWithValue("@MaKhach", maKhach);
                conn.Open();
                var mostPurchasedProduct = mostPurchasedProductCommand.ExecuteScalar();
                conn.Close();

                // Thiết lập các tham số báo cáo
                ReportParameter[] reportParams = new ReportParameter[]
                {
                    new ReportParameter("NguoiTaoBaoCao", TenNV),
                    new ReportParameter("TotalSpent", totalSpent?.ToString() ?? "0"),
                    new ReportParameter("MostPurchasedProduct", mostPurchasedProduct?.ToString() ?? "Không có")
                };
                KhachHangRp.LocalReport.SetParameters(reportParams);
            }

            // Thiết lập nguồn dữ liệu cho báo cáo
            ReportDataSource rds = new ReportDataSource("KhachHangDataSet", reportkh.Tables["KhachHangTable"]);
            KhachHangRp.LocalReport.DataSources.Clear();
            KhachHangRp.LocalReport.DataSources.Add(rds);

            // Chỉ định đường dẫn đến file báo cáo RDLC
            KhachHangRp.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\KhachHangReport.rdlc";

            // Làm mới ReportViewer để hiển thị dữ liệu
            KhachHangRp.RefreshReport();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            // Tải báo cáo với mã khách hàng được chọn trong ComboBox
            if (cbbkhachhang.SelectedItem != null)
            {
                LoadReport(cbbkhachhang.SelectedValue.ToString());
            }
        }
    }

}
