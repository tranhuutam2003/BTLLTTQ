using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BTL_LTTQ_VIP
{
    public partial class KhachHangReport : Form
    {
        public KhachHangReport()
        {
            InitializeComponent();
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

            // Chỉ định đường dẫn đến file báo cáo RDLC
            KhachHangRp.LocalReport.ReportPath = "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\KhachHangReport.rdlc"; // Đường dẫn đến file RDLC của bạn

            // Làm mới ReportViewer để hiển thị dữ liệu
            KhachHangRp.RefreshReport();
        }
    }

}
