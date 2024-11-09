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
    public partial class HangHoaReport : Form
    {
        public HangHoaReport()
        {
            InitializeComponent();
        }

        private void HangHoaReport_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string query = @"SELECT dmh.MaHang, dmh.TenHang, lk.TenLoai, gm.TenLoaiGong, hdm.TenDangMat, cl.TenChatLieu, dp.TenDiop, 
                                   cd.TenCongDung, dd.TenDacDiem, ms.TenMau, nsx.TenNuocSX, dmh.SoLuong, dmh.DonGiaNhap, 
                                   dmh.DonGiaBan, dmh.ThoiGianBaoHanh, dmh.GhiChu
                            FROM DanhMucHangHoa dmh
                            JOIN LoaiKinh lk ON dmh.MaLoai = lk.MaLoai
                            JOIN GongMat gm ON dmh.MaLoaiGong = gm.MaLoaiGong
                            JOIN HinhDangMat hdm ON dmh.MaDangMat = hdm.MaDangMat
                            JOIN ChatLieu cl ON dmh.MaChatLieu = cl.MaChatLieu
                            JOIN Diop dp ON dmh.MaDiop = dp.MaDiop
                            JOIN CongDung cd ON dmh.MaCongDung = cd.MaCongDung
                            JOIN DacDiem dd ON dmh.MaDacDiem = dd.MaDacDiem
                            JOIN MauSac ms ON dmh.MaMau = ms.MaMau
                            JOIN NuocSanXuat nsx ON dmh.MaNuocSX = nsx.MaNuocSX;
                            ";
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(ds.Tables["HangHoaTable"]);
            }
            ReportDataSource rds = new ReportDataSource("HangHoaDataSet", ds.Tables["HangHoaTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.ReportPath = "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\HangHoaReport.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
