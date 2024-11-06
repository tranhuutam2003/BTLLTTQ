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
        public NhanVienReport()
        {
            InitializeComponent();
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

            reportViewer1.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ\\NhanVienReport.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
