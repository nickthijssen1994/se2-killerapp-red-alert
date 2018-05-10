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
            pbTileMap.Image = new Bitmap(new MemoryStream(map.TileImage));
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
    }
}