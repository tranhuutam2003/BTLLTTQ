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
    public partial class HoaDonNhapReport : Form
    {
        private string TenNV;
        public HoaDonNhapReport(string tenNV)
        {
            InitializeComponent();
            TenNV = tenNV;
        }

        private void HoaDonNhapReport_Load(object sender, EventArgs e)
        {
            dtpdenngay.Value = DateTime.Now;
            dtptungay.Value = DateTime.Now.AddDays(-30);

            // Load report with default date range
            LoadReportData(dtptungay.Value, dtpdenngay.Value);
        }

        private void LoadReportData(DateTime fromDate, DateTime toDate)
        {
            DataSet ds = new DataSet();
            string query = @"SELECT hdn.SoHDN, hdn.MaNV, hdn.NgayNhap, ncc.TenNCC, ncc.DiaChi, ncc.DienThoai, hdn.TongTien,
                   cthdn.MaHang, cthdn.SoLuong, cthdn.DonGia, cthdn.GiamGia, cthdn.ThanhTien, dmh.TenHang, dmh.DonGiaNhap
            FROM HoaDonNhap hdn
            JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
            JOIN ChiTietHoaDonNhap cthdn ON hdn.SoHDN = cthdn.SoHDN
            JOIN DanhMucHangHoa dmh ON cthdn.MaHang = dmh.MaHang
            WHERE hdn.NgayNhap BETWEEN @FromDate AND @ToDate;";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", fromDate);
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", toDate);
                adapter.Fill(ds, "HoaDonNhapTable");

                // Truy vấn thông tin sản phẩm nhập nhiều nhất
                SqlCommand cmdProduct = new SqlCommand(@"
            SELECT TOP 1 dmh.TenHang, SUM(cthdn.SoLuong) AS TotalQuantity
            FROM ChiTietHoaDonNhap cthdn
            JOIN HoaDonNhap hdn ON hdn.SoHDN = cthdn.SoHDN
            JOIN DanhMucHangHoa dmh ON cthdn.MaHang = dmh.MaHang
            WHERE hdn.NgayNhap BETWEEN @FromDate AND @ToDate
            GROUP BY dmh.TenHang
            ORDER BY TotalQuantity DESC", conn);
                cmdProduct.Parameters.AddWithValue("@FromDate", fromDate);
                cmdProduct.Parameters.AddWithValue("@ToDate", toDate);

                // Truy vấn thông tin nhà cung cấp nhập hàng nhiều nhất
                SqlCommand cmdSupplier = new SqlCommand(@"
            SELECT TOP 1 ncc.TenNCC, SUM(cthdn.SoLuong) AS TotalQuantity
            FROM ChiTietHoaDonNhap cthdn
            JOIN HoaDonNhap hdn ON hdn.SoHDN = cthdn.SoHDN
            JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
            WHERE hdn.NgayNhap BETWEEN @FromDate AND @ToDate
            GROUP BY ncc.TenNCC
            ORDER BY TotalQuantity DESC", conn);

                cmdSupplier.Parameters.AddWithValue("@FromDate", fromDate);
                cmdSupplier.Parameters.AddWithValue("@ToDate", toDate);

                conn.Open();

                // Đọc thông tin sản phẩm nhập nhiều nhất
                string productName = "";
                int productQuantity = 0;
                using (SqlDataReader reader = cmdProduct.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        productName = reader["TenHang"].ToString();
                        productQuantity = Convert.ToInt32(reader["TotalQuantity"]);
                    }
                }

                // Đọc thông tin nhà cung cấp nhập hàng nhiều nhất
                string supplierName = "";
                int supplierQuantity = 0;
                using (SqlDataReader reader = cmdSupplier.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        supplierName = reader["TenNCC"].ToString();
                        supplierQuantity = Convert.ToInt32(reader["TotalQuantity"]);
                    }
                }

                // Thiết lập đường dẫn cho báo cáo và truyền các tham số vào
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\HoaDonNhapReport.rdlc";
                ReportParameter[] reportParams = new ReportParameter[]
                {
            new ReportParameter("NguoiTaoBaoCao", TenNV),
            new ReportParameter("ProductMostQuantity", productName),
            new ReportParameter("TotalProductQuantity", productQuantity.ToString()),
            new ReportParameter("SupplierMostQuantity", supplierName),
            new ReportParameter("TotalSupplierQuantity", supplierQuantity.ToString())
                };
                reportViewer1.LocalReport.SetParameters(reportParams);

                conn.Close();
            }

            // Đưa dữ liệu vào nguồn dữ liệu của báo cáo
            ReportDataSource rds = new ReportDataSource("HoaDonNhapDataSet", ds.Tables["HoaDonNhapTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void btnxem_Click_1(object sender, EventArgs e)
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
    }
}
