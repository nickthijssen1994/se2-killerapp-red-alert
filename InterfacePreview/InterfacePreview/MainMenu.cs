using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfacePreview
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new LoginScreen().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AccountSettings().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MapCreator().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new StartGame().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new StartGame().Show();
            this.Hide();
        }
    }
}
