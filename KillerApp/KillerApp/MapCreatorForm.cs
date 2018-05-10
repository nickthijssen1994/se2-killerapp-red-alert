using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MapGenerator
{
    public partial class MapCreatorForm : Form
    {
        public Map map;

        public MapCreatorForm()
        {
            InitializeComponent();
        }

        private void tbSize_Scroll(object sender, EventArgs e)
        {
            lbSelectedSize.Text = tbSize.Value.ToString();
        }

        private void btGenerateMap_Click(object sender, EventArgs e)
        {
            map = MapGenerator.GenerateMap(tbName.Text, tbSize.Value, (int)nudSeed.Value, cbGroundType.SelectedIndex, cbMapType.SelectedIndex, cbHasLakes.Checked, cbHasRivers.Checked);
            pbPreviewMap.Image = new Bitmap(new MemoryStream(map.PreviewImage));
            pbTileMap.Image = new Bitmap(new MemoryStream(map.PreviewImage));
        }
    }
}
