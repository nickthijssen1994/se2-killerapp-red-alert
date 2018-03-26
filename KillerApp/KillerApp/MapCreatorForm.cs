using System;
using System.Windows.Forms;
using KillerApp.LogicLayer;
using KillerApp.DomeinClasses;
using System.Drawing;

namespace KillerApp
{
    public partial class MapCreatorForm : Form
    {
        MapController controller = MapController.Instance;

        public MapCreatorForm()
        {
            InitializeComponent();
            LoadMaps();
        }

        private void btGenerateMap_Click(object sender, EventArgs e)
        {
            controller.GenerateMap(tbName.Text, tbSize.Value, cbGroundType.SelectedIndex, cbMapType.SelectedIndex, cbLakes.Checked, cbRivers.Checked, Convert.ToInt32(nudSeed.Value));
            Map map = controller.GetMap();
            pbMap.Image = map.Image;
        }

        private void btSaveMap_Click(object sender, EventArgs e)
        {
            controller.SaveMap();
            lbMaps.Items.Add(controller.GetMap());
        }

        private void btDeleteMap_Click(object sender, EventArgs e)
        {
            controller.DeleteMap(lbMaps.SelectedItem.ToString());
            lbMaps.Items.Remove(lbMaps.SelectedItem);
        }

        private void lbMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMaps.SelectedItem != null)
            {
                Map map = (Map)lbMaps.SelectedItem;
                pbMap.Image = map.Image;
            }
        }

        public void LoadMaps()
        {
            foreach (Map map in controller.GetMaps())
            {
                lbMaps.Items.Add(map);
            }
        }

        private void tbSize_Scroll(object sender, EventArgs e)
        {
            lbSize.Text = tbSize.Value.ToString();
        }
    }
}
