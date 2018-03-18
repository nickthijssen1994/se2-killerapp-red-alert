using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KillerApp.DataLayer;
using KillerApp.DomeinClasses;
using KillerApp.LogicLayer;

namespace KillerApp
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
