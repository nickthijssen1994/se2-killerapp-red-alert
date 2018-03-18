using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KillerApp.LogicLayer;
using KillerApp.DomeinClasses;

namespace KillerApp
{
    public partial class MapCreatorForm : Form
    {
        Controller controller = Controller.Instance;

        public MapCreatorForm()
        {
            InitializeComponent();
        }

        private void btGenerateMap_Click(object sender, EventArgs e)
        {
            controller.GenerateMap(tbName.Text, tbSize.Value, cbGroundType.SelectedIndex, cbMapType.SelectedIndex, cbLakes.Checked, cbRivers.Checked);
            lbMaps.Items.Add(controller.TemporaryMap);
            pbMap.Image = controller.TemporaryMap.Image; 
        }

        private void btSaveMap_Click(object sender, EventArgs e)
        {

        }

        private void btDeleteMap_Click(object sender, EventArgs e)
        {

        }
    }
}
