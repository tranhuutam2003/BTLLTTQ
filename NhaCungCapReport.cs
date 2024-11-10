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
    public partial class NhaCungCapReport : Form
    {
        public NhaCungCapReport()
        {
            InitializeComponent();
        }

        private void NhaCungCapReport_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string query = @"SELECT ncc.MaNCC, ncc.TenNCC, ncc.DiaChi, ncc.DienThoai, hdn.SoHDN, hdn.NgayNhap, hdn.TongTien
                            FROM NhaCungCap ncc
                            LEFT JOIN HoaDonNhap hdn ON ncc.MaNCC = hdn.MaNCC;
                            ";
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                // Điền dữ liệu vào DataTable
                adapter.Fill(ds.Tables["NhaCungCapTable"]);
            }

            // Thiết lập nguồn dữ liệu cho báo cáo
            ReportDataSource rds = new ReportDataSource("NhaCungCapDataSet", ds.Tables["NhaCungCapTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Chỉ định đường dẫn đến file báo cáo RDLC
            reportViewer1.LocalReport.ReportPath = "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\NhaCungCapReport.rdlc"; // Đường dẫn đến file RDLC của bạn

            // Làm mới ReportViewer để hiển thị dữ liệu
            reportViewer1.RefreshReport();
        }
    }
}
