using System;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class MainHangHoa : Form
    {
        public MainHangHoa()
        {
            InitializeComponent();
            LoadFormsIntoTabControl();
        }

        private void LoadFormsIntoTabControl()
        {
            // Tạo instance của từng form con
            ThemDiop themDiopForm = new ThemDiop();
            ThemHangHoa themHangHoaForm = new ThemHangHoa();
            ThemHinhDangMat themHinhDangMatForm = new ThemHinhDangMat();
            ThemCongDung themCongDungForm = new ThemCongDung();
            ThemChatLieu themChatLieuForm = new ThemChatLieu();
            ThemDacDiem themDacDiemForm = new ThemDacDiem();
            ThemMauSac themMauSacForm = new ThemMauSac();
            ThemLoaiKinh themLoaiKinhForm = new ThemLoaiKinh();
            ThemNuocSanXuat themNuocSanXuatForm = new ThemNuocSanXuat();
            ThemGongMat themGongMatForm = new ThemGongMat();

            // Kiểm tra sự tồn tại của các TabPages trước khi thêm form vào
            TabPage tabThemDiop = tabControl1.TabPages["tabThemDiop"];
            TabPage tabThemHangHoa = tabControl1.TabPages["tabThemHangHoa"];
            TabPage tabThemHinhDangMat = tabControl1.TabPages["tabThemHinhDangMat"];
            TabPage tabThemCongDung = tabControl1.TabPages["tabThemCongDung"];
            TabPage tabThemChatLieu = tabControl1.TabPages["tabThemChatLieu"];
            TabPage tabThemDacDiem = tabControl1.TabPages["tabThemDacDiem"];
            TabPage tabThemMauSac = tabControl1.TabPages["tabThemMauSac"];
            TabPage tabThemLoaiKinh = tabControl1.TabPages["tabThemLoaiKinh"];
            TabPage tabThemNuocSanXuat = tabControl1.TabPages["tabThemNuocSanXuat"];
            TabPage tabThemGongMat = tabControl1.TabPages["tabThemGongMat"];

            if (tabThemDiop != null)
            {
                AddFormToTabPage(themDiopForm, tabThemDiop);
            }
            else
            {
                MessageBox.Show("Tab 'tabThemDiop' không tồn tại!");
            }

            if (tabThemGongMat != null)
            {
                AddFormToTabPage(themGongMatForm, tabThemGongMat);
            }
            else
            {
                MessageBox.Show("Tab 'tabThemGongMat' không tồn tại!");
            }

            if (tabThemHangHoa != null)
            {
                AddFormToTabPage(themHangHoaForm, tabThemHangHoa);
            }
            else
            {
                MessageBox.Show("Tab 'tabThemHangHoa' không tồn tại!");
            }

            if (tabThemHinhDangMat != null)
            {
                AddFormToTabPage(themHinhDangMatForm, tabThemHinhDangMat);
            }
            else
            {
                MessageBox.Show("Tab 'tabThemHinhDangMat' không tồn tại!");
            }

            if (tabThemCongDung != null)
            {
                AddFormToTabPage(themCongDungForm, tabThemCongDung);
            }
            else
            {
                MessageBox.Show("Tab 'tabThemCongDung' không tồn tại!");
            }

            if (tabThemChatLieu != null)
            {
                AddFormToTabPage(themChatLieuForm, tabThemChatLieu);
            }
            else
            {
                MessageBox.Show("Tab 'tabThemChatLieu' không tồn tại!");
            }

            if (tabThemDacDiem != null)
            {
                AddFormToTabPage(themDacDiemForm, tabThemDacDiem);
            }
            else
            {
                MessageBox.Show("Tab 'tabThemDacDiem' không tồn tại!");
            }

            if (tabThemMauSac != null)
            {
                AddFormToTabPage(themMauSacForm, tabThemMauSac);
            }
            else
            {
                MessageBox.Show("Tab 'tabThemMauSac' không tồn tại!");
            }

            if (tabThemLoaiKinh != null)
            {
                AddFormToTabPage(themLoaiKinhForm, tabThemLoaiKinh);
            }
            else
            {
                MessageBox.Show("Tab 'tabThemLoaiKinh' không tồn tại!");
            }

            if (tabThemNuocSanXuat != null)
            {
                AddFormToTabPage(themNuocSanXuatForm, tabThemNuocSanXuat);
            }
            else
            {
                MessageBox.Show("Tab 'tabThemNuocSanXuat' không tồn tại!");
            }
        }

        private void AddFormToTabPage(Form form, TabPage tabPage)
        {
            form.TopLevel = false; // Để form con hoạt động như một điều khiển
            form.FormBorderStyle = FormBorderStyle.None; // Ẩn viền form
            form.Dock = DockStyle.Fill; // Phủ kín TabPage
            tabPage.Controls.Add(form); // Thêm form vào TabPage
            form.Show(); // Hiển thị form con
        }

        private void tabThemHangHoa_Click(object sender, EventArgs e)
        {

        }

        private void MainHangHoa_Load(object sender, EventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected tab's name
            TabPage selectedTab = tabControl1.SelectedTab;

            // Call the corresponding LoadData method based on the selected tab
            if (selectedTab != null)
            {
                switch (selectedTab.Name)
                {
                    case "tabThemDiop":
                        ThemDiop themDiopForm = (ThemDiop)selectedTab.Controls[0];
                        themDiopForm.LoadData(); // Call LoadData for ThemDiop
                        break;
                    case "tabThemHangHoa":
                        ThemHangHoa themHangHoaForm = (ThemHangHoa)selectedTab.Controls[0];
                        themHangHoaForm.LoadData(); // Call LoadData for ThemHangHoa
                        break;
                    case "tabThemHinhDangMat":
                        ThemHinhDangMat themHinhDangMatForm = (ThemHinhDangMat)selectedTab.Controls[0];
                        themHinhDangMatForm.LoadData(); // Call LoadData for ThemHinhDangMat
                        break;
                    case "tabThemCongDung":
                        ThemCongDung themCongDungForm = (ThemCongDung)selectedTab.Controls[0];
                        themCongDungForm.LoadData(); // Call LoadData for ThemCongDung
                        break;
                    case "tabThemChatLieu":
                        ThemChatLieu themChatLieuForm = (ThemChatLieu)selectedTab.Controls[0];
                        themChatLieuForm.LoadData(); // Call LoadData for ThemChatLieu
                        break;
                    case "tabThemDacDiem":
                        ThemDacDiem themDacDiemForm = (ThemDacDiem)selectedTab.Controls[0];
                        themDacDiemForm.LoadData(); // Call LoadData for ThemDacDiem
                        break;
                    case "tabThemMauSac":
                        ThemMauSac themMauSacForm = (ThemMauSac)selectedTab.Controls[0];
                        themMauSacForm.LoadData(); // Call LoadData for ThemMauSac
                        break;
                    case "tabThemLoaiKinh":
                        ThemLoaiKinh themLoaiKinhForm = (ThemLoaiKinh)selectedTab.Controls[0];
                        themLoaiKinhForm.LoadData(); // Call LoadData for ThemLoaiKinh
                        break;
                    case "tabThemNuocSanXuat":
                        ThemNuocSanXuat themNuocSanXuatForm = (ThemNuocSanXuat)selectedTab.Controls[0];
                        themNuocSanXuatForm.LoadData(); // Call LoadData for ThemNuocSanXuat
                        break;
                    case "tabThemGongMat":
                        ThemGongMat themGongMatForm = (ThemGongMat)selectedTab.Controls[0];
                        themGongMatForm.LoadData(); // Call LoadData for ThemGongMat
                        break;
                }
            }
        }
    }
}
