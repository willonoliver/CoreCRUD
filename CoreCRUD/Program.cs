using System;
using System.Windows.Forms;

namespace CoreCRUD
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Produtos());
        }
    }
}
