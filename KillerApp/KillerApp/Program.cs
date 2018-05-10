using System;
using System.Windows.Forms;

namespace MapGenerator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MapCreatorForm());
        }
    }
}
