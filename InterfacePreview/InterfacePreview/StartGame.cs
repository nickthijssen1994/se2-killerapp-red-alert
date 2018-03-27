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
    public partial class StartGame : Form
    {
        public StartGame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
                button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {    
                button2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new MainMenu().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new InGame().Show();
            this.Hide();
        }
    }
}
