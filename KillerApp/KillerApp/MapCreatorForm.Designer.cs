namespace MapGenerator
{
    partial class MapCreatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSize = new System.Windows.Forms.TrackBar();
            this.cbGroundType = new System.Windows.Forms.ComboBox();
            this.cbHasRivers = new System.Windows.Forms.CheckBox();
            this.cbHasLakes = new System.Windows.Forms.CheckBox();
            this.cbMapType = new System.Windows.Forms.ComboBox();
            this.btGenerateMap = new System.Windows.Forms.Button();
            this.pbPreviewMap = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.lbGroundType = new System.Windows.Forms.Label();
            this.lbMapType = new System.Windows.Forms.Label();
            this.lbSelectedSize = new System.Windows.Forms.Label();
            this.lbSeed = new System.Windows.Forms.Label();
            this.nudSeed = new System.Windows.Forms.NumericUpDown();
            this.pbTileMap = new System.Windows.Forms.PictureBox();
            this.tbName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileMap)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSize
            // 
            this.tbSize.LargeChange = 100;
            this.tbSize.Location = new System.Drawing.Point(153, 48);
            this.tbSize.Maximum = 800;
            this.tbSize.Minimum = 200;
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(167, 56);
            this.tbSize.SmallChange = 100;
            this.tbSize.TabIndex = 1;
            this.tbSize.TickFrequency = 100;
            this.tbSize.Value = 200;
            this.tbSize.Scroll += new System.EventHandler(this.tbSize_Scroll);
            // 
            // cbGroundType
            // 
            this.cbGroundType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGroundType.FormattingEnabled = true;
            this.cbGroundType.Items.AddRange(new object[] {
            "Grass",
            "Snow",
            "Desert"});
            this.cbGroundType.Location = new System.Drawing.Point(153, 92);
            this.cbGroundType.Name = "cbGroundType";
            this.cbGroundType.Size = new System.Drawing.Size(167, 33);
            this.cbGroundType.TabIndex = 2;
            // 
            // cbHasRivers
            // 
            this.cbHasRivers.AutoSize = true;
            this.cbHasRivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHasRivers.Location = new System.Drawing.Point(232, 206);
            this.cbHasRivers.Name = "cbHasRivers";
            this.cbHasRivers.Size = new System.Drawing.Size(88, 29);
            this.cbHasRivers.TabIndex = 3;
            this.cbHasRivers.Text = "Rivers";
            this.cbHasRivers.UseVisualStyleBackColor = true;
            // 
            // cbHasLakes
            // 
            this.cbHasLakes.AutoSize = true;
            this.cbHasLakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHasLakes.Location = new System.Drawing.Point(127, 206);
            this.cbHasLakes.Name = "cbHasLakes";
            this.cbHasLakes.Size = new System.Drawing.Size(87, 29);
            this.cbHasLakes.TabIndex = 4;
            this.cbHasLakes.Text = "Lakes";
            this.cbHasLakes.UseVisualStyleBackColor = true;
            // 
            // cbMapType
            // 
            this.cbMapType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMapType.FormattingEnabled = true;
            this.cbMapType.Items.AddRange(new object[] {
            "Continent",
            "Island"});
            this.cbMapType.Location = new System.Drawing.Point(153, 131);
            this.cbMapType.Name = "cbMapType";
            this.cbMapType.Size = new System.Drawing.Size(167, 33);
            this.cbMapType.TabIndex = 5;
            // 
            // btGenerateMap
            // 
            this.btGenerateMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenerateMap.Location = new System.Drawing.Point(33, 268);
            this.btGenerateMap.Name = "btGenerateMap";
            this.btGenerateMap.Size = new System.Drawing.Size(300, 36);
            this.btGenerateMap.TabIndex = 6;
            this.btGenerateMap.Text = "Generate Map";
            this.btGenerateMap.UseVisualStyleBackColor = true;
            this.btGenerateMap.Click += new System.EventHandler(this.btGenerateMap_Click);
            // 
            // pbPreviewMap
            // 
            this.pbPreviewMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreviewMap.Location = new System.Drawing.Point(33, 346);
            this.pbPreviewMap.Name = "pbPreviewMap";
            this.pbPreviewMap.Size = new System.Drawing.Size(300, 300);
            this.pbPreviewMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreviewMap.TabIndex = 9;
            this.pbPreviewMap.TabStop = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(77, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(70, 25);
            this.lbName.TabIndex = 11;
            this.lbName.Text = "Name:";
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSize.Location = new System.Drawing.Point(90, 48);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(57, 25);
            this.lbSize.TabIndex = 12;
            this.lbSize.Text = "Size:";
            // 
            // lbGroundType
            // 
            this.lbGroundType.AutoSize = true;
            this.lbGroundType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGroundType.Location = new System.Drawing.Point(14, 95);
            this.lbGroundType.Name = "lbGroundType";
            this.lbGroundType.Size = new System.Drawing.Size(133, 25);
            this.lbGroundType.TabIndex = 13;
            this.lbGroundType.Text = "Ground Type:";
            // 
            // lbMapType
            // 
            this.lbMapType.AutoSize = true;
            this.lbMapType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMapType.Location = new System.Drawing.Point(40, 134);
            this.lbMapType.Name = "lbMapType";
            this.lbMapType.Size = new System.Drawing.Size(107, 25);
            this.lbMapType.TabIndex = 15;
            this.lbMapType.Text = "Map Type:";
            // 
            // lbSelectedSize
            // 
            this.lbSelectedSize.AutoSize = true;
            this.lbSelectedSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectedSize.Location = new System.Drawing.Point(326, 48);
            this.lbSelectedSize.Name = "lbSelectedSize";
            this.lbSelectedSize.Size = new System.Drawing.Size(45, 25);
            this.lbSelectedSize.TabIndex = 16;
            this.lbSelectedSize.Text = "200";
            // 
            // lbSeed
            // 
            this.lbSeed.AutoSize = true;
            this.lbSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeed.Location = new System.Drawing.Point(82, 172);
            this.lbSeed.Name = "lbSeed";
            this.lbSeed.Size = new System.Drawing.Size(65, 25);
            this.lbSeed.TabIndex = 18;
            this.lbSeed.Text = "Seed:";
            // 
            // nudSeed
            // 
            this.nudSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSeed.Location = new System.Drawing.Point(153, 170);
            this.nudSeed.Name = "nudSeed";
            this.nudSeed.Size = new System.Drawing.Size(167, 30);
            this.nudSeed.TabIndex = 19;
            this.nudSeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pbTileMap
            // 
            this.pbTileMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTileMap.Location = new System.Drawing.Point(392, 12);
            this.pbTileMap.Name = "pbTileMap";
            this.pbTileMap.Size = new System.Drawing.Size(900, 900);
            this.pbTileMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTileMap.TabIndex = 20;
            this.pbTileMap.TabStop = false;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(153, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(167, 30);
            this.tbName.TabIndex = 0;
            // 
            // MapCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 928);
            this.Controls.Add(this.pbTileMap);
            this.Controls.Add(this.nudSeed);
            this.Controls.Add(this.lbSeed);
            this.Controls.Add(this.lbSelectedSize);
            this.Controls.Add(this.lbMapType);
            this.Controls.Add(this.lbGroundType);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pbPreviewMap);
            this.Controls.Add(this.btGenerateMap);
            this.Controls.Add(this.cbMapType);
            this.Controls.Add(this.cbHasLakes);
            this.Controls.Add(this.cbHasRivers);
            this.Controls.Add(this.cbGroundType);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.tbName);
            this.Name = "MapCreatorForm";
            this.ShowIcon = false;
            this.Text = "Map Creator";
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar tbSize;
        private System.Windows.Forms.ComboBox cbGroundType;
        private System.Windows.Forms.CheckBox cbHasRivers;
        private System.Windows.Forms.CheckBox cbHasLakes;
        private System.Windows.Forms.ComboBox cbMapType;
        private System.Windows.Forms.Button btGenerateMap;
        private System.Windows.Forms.PictureBox pbPreviewMap;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbGroundType;
        private System.Windows.Forms.Label lbMapType;
        private System.Windows.Forms.Label lbSelectedSize;
        private System.Windows.Forms.Label lbSeed;
        private System.Windows.Forms.NumericUpDown nudSeed;
        private System.Windows.Forms.PictureBox pbTileMap;
        private System.Windows.Forms.TextBox tbName;
    }
}

