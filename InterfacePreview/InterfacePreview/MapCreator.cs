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
    public partial class MapCreator : Form
    {
        public MapCreator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Map is Generated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Map is saved");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Map is deleted");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MainMenu().Show();
            this.Hide();
        }
    }
}
