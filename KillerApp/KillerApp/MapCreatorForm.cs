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

            Map map = (Map)lbMaps.SelectedItem;
            pbMap.Image = map.Image;
            hsbMapView.Maximum = map.Size - 21;
            vsbMapView.Maximum = map.Size - 21;
            hsbMapView.Value = hsbMapView.Minimum;
            vsbMapView.Value = hsbMapView.Maximum;
            pbMapView.Image = BitmapViewGenerator.GenerateBitmapView((Map)lbMaps.SelectedItem, hsbMapView.Value, vsbMapView.Value);

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

        private void hsbMapView_Scroll(object sender, ScrollEventArgs e)
        {
            if (lbMaps.SelectedItem != null)
            {
                pbMapView.Image = BitmapViewGenerator.GenerateBitmapView((Map)lbMaps.SelectedItem, hsbMapView.Value, vsbMapView.Value);
            }
        }

        private void vsbMapView_Scroll(object sender, ScrollEventArgs e)
        {
            if (lbMaps.SelectedItem != null)
            {
                pbMapView.Image = BitmapViewGenerator.GenerateBitmapView((Map)lbMaps.SelectedItem, hsbMapView.Value, vsbMapView.Value);
            }
        }
    }
}
