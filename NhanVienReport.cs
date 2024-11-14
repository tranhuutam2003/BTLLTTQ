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
    public partial class NhanVienReport : Form
    {
        private string TenNV;
        public NhanVienReport(string tenNV)
        {
            InitializeComponent();
            TenNV = tenNV;
        }

        private void NhanVienReport_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string query = @"SELECT nv.MaNV, nv.TenNV, nv.GioiTinh, nv.NgaySinh, nv.DienThoai, nv.DiaChi, cv.TenCV, cv.MucLuong
                            FROM NhanVien nv
                            JOIN CongViec cv ON nv.MaCV = cv.MaCV;
                            ";
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(ds.Tables["NhanVienTable"]);
            }
            ReportDataSource rds = new ReportDataSource("NhanVienDataSet", ds.Tables["NhanVienTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.ReportPath = reportlink.nhanvienreportlink;
            ReportParameter paramNguoiTao = new ReportParameter("NguoiTaoBaoCao", TenNV);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paramNguoiTao });
            this.reportViewer1.RefreshReport();
        }
    }
}
