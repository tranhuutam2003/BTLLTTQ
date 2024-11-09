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
    public partial class DoanhThuReport : Form
    {
        public DoanhThuReport()
        {
            InitializeComponent();
        }

        private void DoanhThuReport_Load(object sender, EventArgs e)
        {
            DataSet rp = new DataSet();
            string query = @"SELECT NgayThang, DoanhThuBan, DoanhThuNhap, DoanhThuThuần
                            FROM DoanhThu;";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                // Điền dữ liệu vào DataTable
                adapter.Fill(rp.Tables["DoanhThuTable"]);
            }
            ReportDataSource rds = new ReportDataSource("DoanhThuDataSet", rp.Tables["DoanhThuTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.ReportPath = "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\DoanhThuReport.rdlc"; // Đường dẫn đến file RDLC của bạn

            // Làm mới ReportViewer để hiển thị dữ liệu
            reportViewer1.RefreshReport();
        }
    }
}
