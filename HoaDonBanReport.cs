using Microsoft.Reporting.WinForms;
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
    public partial class HoaDonBanReport : Form
    {
        private string TenNV;
        public HoaDonBanReport(string tenNV)
        {
            InitializeComponent();
            TenNV = tenNV;
        }

        private void HoaDonBanReport_Load(object sender, EventArgs e)
        {
            dtpdenngay.Value = DateTime.Now;
            dtptungay.Value = DateTime.Now.AddDays(-30);

            // Load report với khoảng thời gian mặc định
            LoadReportData(dtptungay.Value, dtpdenngay.Value);
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtptungay.Value;
            DateTime endDate = dtpdenngay.Value;

            // Kiểm tra nếu ngày bắt đầu lớn hơn ngày kết thúc
            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tải báo cáo theo khoảng ngày đã chọn
            LoadReportData(startDate, endDate);
        }

        private void LoadReportData(DateTime fromDate, DateTime toDate)
        {
            DataSet ds = new DataSet();

            // Truy vấn chính để lấy dữ liệu hóa đơn bán hàng trong khoảng thời gian
            string query = @"
                SELECT hdb.SoHDB, hdb.MaNV, hdb.NgayBan, kh.TenKhach, kh.DiaChi, kh.DienThoai, hdb.TongTien, 
                       cthdb.MaHang, cthdb.SoLuong, cthdb.GiamGia, cthdb.ThanhTien, dmh.TenHang, dmh.DonGiaBan
                FROM HoaDonBan hdb
                JOIN KhachHang kh ON hdb.MaKhach = kh.MaKhach
                JOIN ChiTietHoaDonBan cthdb ON hdb.SoHDB = cthdb.SoHDB
                JOIN DanhMucHangHoa dmh ON cthdb.MaHang = dmh.MaHang
                WHERE hdb.NgayBan BETWEEN @FromDate AND @ToDate
                ";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", fromDate);
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", toDate);

                adapter.Fill(ds, "HoaDonBanTable");
            }

            // Truy vấn để lấy các dữ liệu khác như sản phẩm bán nhiều nhất, ít nhất, nhân viên bán hàng nhiều nhất, v.v.
            string mostSoldProductQuery = @"
                SELECT TOP 1 dmh.TenHang, SUM(cthdb.SoLuong) AS TotalSold
                FROM ChiTietHoaDonBan cthdb
                JOIN DanhMucHangHoa dmh ON cthdb.MaHang = dmh.MaHang
                JOIN HoaDonBan hdb ON cthdb.SoHDB = hdb.SoHDB
                WHERE hdb.NgayBan BETWEEN @FromDate AND @ToDate
                GROUP BY dmh.TenHang
                ORDER BY TotalSold DESC
            ";

            string bestSalespersonQuery = @"
                SELECT TOP 1 hdb.MaNV, SUM(cthdb.SoLuong) AS TotalSold
                FROM ChiTietHoaDonBan cthdb
                JOIN HoaDonBan hdb ON cthdb.SoHDB = hdb.SoHDB
                WHERE hdb.NgayBan BETWEEN @FromDate AND @ToDate
                GROUP BY hdb.MaNV
                ORDER BY TotalSold DESC
            ";

            string highestInvoiceQuery = @"
                SELECT TOP 1 hdb.SoHDB, hdb.TongTien
                FROM HoaDonBan hdb
                WHERE hdb.NgayBan BETWEEN @FromDate AND @ToDate
                ORDER BY hdb.TongTien DESC
            ";


            // Thực hiện các truy vấn để lấy thông tin
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlCommand cmd;
                conn.Open();

                // Lấy dữ liệu sản phẩm bán nhiều nhất
                cmd = new SqlCommand(mostSoldProductQuery, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                var mostSoldProduct = cmd.ExecuteScalar()?.ToString() ?? "Không có sản phẩm bán chạy nhất";

                // Lấy nhân viên bán nhiều hàng nhất
                cmd = new SqlCommand(bestSalespersonQuery, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                var bestSalesperson = cmd.ExecuteScalar()?.ToString() ?? "Không có nhân viên bán hàng nhiều nhất";

                // Lấy hóa đơn có giá trị cao nhất
                cmd = new SqlCommand(highestInvoiceQuery, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                var highestInvoice = cmd.ExecuteScalar()?.ToString() ?? "Không có hóa đơn cao nhất";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        highestInvoice = $"Hóa đơn {reader["SoHDB"]} - Tổng tiền: {reader["TongTien"]}";
                    }
                    else
                    {
                        highestInvoice = "Không có hóa đơn cao nhất";
                    }
                }

                conn.Close();
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\HoaDonBanReport.rdlc";
                // Truyền tham số vào báo cáo
                ReportParameter[] reportParams = new ReportParameter[]
                {
                    new ReportParameter("NguoiTaoBaoCao",TenNV),
                    new ReportParameter("MostSoldProduct", mostSoldProduct),
                    new ReportParameter("BestSalesperson", bestSalesperson),
                    new ReportParameter("HighestInvoice", highestInvoice),

                };

                // Cập nhật tham số vào báo cáo
                reportViewer1.LocalReport.SetParameters(reportParams);
            }

            // Thiết lập nguồn dữ liệu cho báo cáo
            ReportDataSource rds = new ReportDataSource("HoaDonBanDataSet", ds.Tables["HoaDonBanTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Chỉ định đường dẫn đến file báo cáo RDLC
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\HoaDonBanReport.rdlc";

            // Làm mới báo cáo để hiển thị dữ liệu
            reportViewer1.RefreshReport();
        }
    }
}

