using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MapGenerator
{
    public partial class MapCreatorForm : Form
    {
        public Map map;

        public void GenerateMap()
        {
            map = MapGenerator.GenerateMap(tbName.Text, tbSize.Value, (int)nudSeed.Value, cbGroundType.SelectedIndex, cbMapType.SelectedIndex, cbHasLakes.Checked, cbHasRivers.Checked);
            pbPreviewMap.Image = new Bitmap(new MemoryStream(map.PreviewImage));
            pbTileMap.Image = new Bitmap(new MemoryStream(map.PreviewImage));
        }

        public MapCreatorForm()
        {
            InitializeComponent();
            GenerateMap();
        }

        private void pbTileMap_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            Image bitmap = pbTileMap.Image;
            bitmap.Save(@"C:\Users\Nick\Desktop\Tilemap.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void pbPreviewMap_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            Image bitmap = pbPreviewMap.Image;
            bitmap.Save(@"C:\Users\Nick\Desktop\Previewmap.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void tbSize_Scroll(object sender, EventArgs e)
        {
            lbSelectedSize.Text = tbSize.Value.ToString();
            GenerateMap();
        }

        private void btGenerateMap_Click(object sender, EventArgs e)
        {
            GenerateMap();
        }

        private void cbGroundType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateMap();
        }

        private void cbMapType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateMap();
        }

        private void nudSeed_ValueChanged(object sender, EventArgs e)
        {
            GenerateMap();
        }

        private void cbHasLakes_CheckedChanged(object sender, EventArgs e)
        {
            GenerateMap();
        }

        private void cbHasRivers_CheckedChanged(object sender, EventArgs e)
        {
            GenerateMap();
        }
    }
}