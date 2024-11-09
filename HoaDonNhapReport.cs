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
        public HoaDonNhapReport()
        {
            InitializeComponent();
        }

        private void HoaDonNhapReport_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string query = @"SELECT hdn.SoHDN, hdn.MaNV, hdn.NgayNhap, ncc.TenNCC, ncc.DiaChi, ncc.DienThoai, hdn.TongTien,
                                   cthdn.MaHang, cthdn.SoLuong, cthdn.DonGia, cthdn.GiamGia, cthdn.ThanhTien, dmh.TenHang, dmh.DonGiaNhap
                            FROM HoaDonNhap hdn
                            JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
                            JOIN ChiTietHoaDonNhap cthdn ON hdn.SoHDN = cthdn.SoHDN
                            JOIN DanhMucHangHoa dmh ON cthdn.MaHang = dmh.MaHang;
                            ";
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                // Điền dữ liệu vào DataTable
                adapter.Fill(ds.Tables["HoaDonNhapTable"]);
            }
            ReportDataSource rds = new ReportDataSource("HoaDonNhapDataSet", ds.Tables["HoaDonNhapTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Chỉ định đường dẫn đến file báo cáo RDLC
            reportViewer1.LocalReport.ReportPath = "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\HoaDonNhapReport.rdlc"; // Đường dẫn đến file RDLC của bạn

            // Làm mới ReportViewer để hiển thị dữ liệu
            reportViewer1.RefreshReport();
        }
    }
}
