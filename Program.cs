using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public static class databaselink
    {
        public static string ConnectionString = "Data Source=THUCVIVO;Initial Catalog=quanlybankinh;Integrated Security=True";
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Account());
        }
    }
}
