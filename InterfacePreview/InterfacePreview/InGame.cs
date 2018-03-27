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
    public partial class InGame : Form
    {
        public InGame()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game is saved");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new StartGame().Show();
            this.Hide();
        }
    }
}
