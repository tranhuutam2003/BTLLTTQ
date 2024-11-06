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
        public HoaDonBanReport()
        {
            InitializeComponent();
        }

        private void HoaDonBanReport_Load(object sender, EventArgs e)
        {
            DataSet rp = new DataSet();
            string query = @"SELECT hdb.SoHDB, hdb.MaNV, hdb.NgayBan, kh.TenKhach, kh.DiaChi, kh.DienThoai, hdb.TongTien, 
                            cthdb.MaHang, cthdb.SoLuong, cthdb.GiamGia, cthdb.ThanhTien, dmh.TenHang, dmh.DonGiaBan
                            FROM HoaDonBan hdb
                            JOIN KhachHang kh ON hdb.MaKhach = kh.MaKhach
                            JOIN ChiTietHoaDonBan cthdb ON hdb.SoHDB = cthdb.SoHDB
                            JOIN DanhMucHangHoa dmh ON cthdb.MaHang = dmh.MaHang;
                            ";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                // Điền dữ liệu vào DataTable
                adapter.Fill(rp.Tables["HoaDonBanTable"]);
            }
            ReportDataSource rds = new ReportDataSource("HoaDonBanDataSet", rp.Tables["HoaDonBanTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Chỉ định đường dẫn đến file báo cáo RDLC
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ\\HoaDonBanReport.rdlc"; // Đường dẫn đến file RDLC của bạn

            // Làm mới ReportViewer để hiển thị dữ liệu
            reportViewer1.RefreshReport();
        }
    }
}
