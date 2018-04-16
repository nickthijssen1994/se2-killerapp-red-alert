namespace KillerApp
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TrackBar();
            this.cbGroundType = new System.Windows.Forms.ComboBox();
            this.cbRivers = new System.Windows.Forms.CheckBox();
            this.cbLakes = new System.Windows.Forms.CheckBox();
            this.cbMapType = new System.Windows.Forms.ComboBox();
            this.btGenerateMap = new System.Windows.Forms.Button();
            this.btSaveMap = new System.Windows.Forms.Button();
            this.btDeleteMap = new System.Windows.Forms.Button();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.lbMaps = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btMenu = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSeed = new System.Windows.Forms.NumericUpDown();
            this.pbMapView = new System.Windows.Forms.PictureBox();
            this.vsbMapView = new System.Windows.Forms.VScrollBar();
            this.hsbMapView = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapView)).BeginInit();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(153, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(167, 30);
            this.tbName.TabIndex = 0;
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
            "Water",
            "Grass",
            "Snow",
            "Desert"});
            this.cbGroundType.Location = new System.Drawing.Point(153, 92);
            this.cbGroundType.Name = "cbGroundType";
            this.cbGroundType.Size = new System.Drawing.Size(167, 33);
            this.cbGroundType.TabIndex = 2;
            // 
            // cbRivers
            // 
            this.cbRivers.AutoSize = true;
            this.cbRivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRivers.Location = new System.Drawing.Point(232, 206);
            this.cbRivers.Name = "cbRivers";
            this.cbRivers.Size = new System.Drawing.Size(88, 29);
            this.cbRivers.TabIndex = 3;
            this.cbRivers.Text = "Rivers";
            this.cbRivers.UseVisualStyleBackColor = true;
            // 
            // cbLakes
            // 
            this.cbLakes.AutoSize = true;
            this.cbLakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLakes.Location = new System.Drawing.Point(127, 206);
            this.cbLakes.Name = "cbLakes";
            this.cbLakes.Size = new System.Drawing.Size(87, 29);
            this.cbLakes.TabIndex = 4;
            this.cbLakes.Text = "Lakes";
            this.cbLakes.UseVisualStyleBackColor = true;
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
            this.btGenerateMap.Location = new System.Drawing.Point(24, 262);
            this.btGenerateMap.Name = "btGenerateMap";
            this.btGenerateMap.Size = new System.Drawing.Size(157, 36);
            this.btGenerateMap.TabIndex = 6;
            this.btGenerateMap.Text = "Generate Map";
            this.btGenerateMap.UseVisualStyleBackColor = true;
            this.btGenerateMap.Click += new System.EventHandler(this.btGenerateMap_Click);
            // 
            // btSaveMap
            // 
            this.btSaveMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveMap.Location = new System.Drawing.Point(187, 262);
            this.btSaveMap.Name = "btSaveMap";
            this.btSaveMap.Size = new System.Drawing.Size(157, 36);
            this.btSaveMap.TabIndex = 7;
            this.btSaveMap.Text = "Save Map";
            this.btSaveMap.UseVisualStyleBackColor = true;
            this.btSaveMap.Click += new System.EventHandler(this.btSaveMap_Click);
            // 
            // btDeleteMap
            // 
            this.btDeleteMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteMap.Location = new System.Drawing.Point(24, 304);
            this.btDeleteMap.Name = "btDeleteMap";
            this.btDeleteMap.Size = new System.Drawing.Size(157, 36);
            this.btDeleteMap.TabIndex = 8;
            this.btDeleteMap.Text = "Delete Map";
            this.btDeleteMap.UseVisualStyleBackColor = true;
            this.btDeleteMap.Click += new System.EventHandler(this.btDeleteMap_Click);
            // 
            // pbMap
            // 
            this.pbMap.Location = new System.Drawing.Point(33, 346);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(300, 300);
            this.pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMap.TabIndex = 9;
            this.pbMap.TabStop = false;
            // 
            // lbMaps
            // 
            this.lbMaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaps.FormattingEnabled = true;
            this.lbMaps.ItemHeight = 25;
            this.lbMaps.Location = new System.Drawing.Point(33, 653);
            this.lbMaps.Name = "lbMaps";
            this.lbMaps.Size = new System.Drawing.Size(300, 329);
            this.lbMaps.Sorted = true;
            this.lbMaps.TabIndex = 10;
            this.lbMaps.SelectedIndexChanged += new System.EventHandler(this.lbMaps_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ground Type:";
            // 
            // btMenu
            // 
            this.btMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMenu.Location = new System.Drawing.Point(187, 304);
            this.btMenu.Name = "btMenu";
            this.btMenu.Size = new System.Drawing.Size(157, 36);
            this.btMenu.TabIndex = 14;
            this.btMenu.Text = "Menu";
            this.btMenu.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Map Type:";
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSize.Location = new System.Drawing.Point(326, 48);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(45, 25);
            this.lbSize.TabIndex = 16;
            this.lbSize.Text = "200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(82, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Seed:";
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
            // pbMapView
            // 
            this.pbMapView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMapView.Location = new System.Drawing.Point(677, 12);
            this.pbMapView.Name = "pbMapView";
            this.pbMapView.Size = new System.Drawing.Size(900, 900);
            this.pbMapView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapView.TabIndex = 20;
            this.pbMapView.TabStop = false;
            // 
            // vsbMapView
            // 
            this.vsbMapView.Location = new System.Drawing.Point(1580, 12);
            this.vsbMapView.Name = "vsbMapView";
            this.vsbMapView.Size = new System.Drawing.Size(21, 900);
            this.vsbMapView.TabIndex = 21;
            this.vsbMapView.Value = 100;
            this.vsbMapView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbMapView_Scroll);
            // 
            // hsbMapView
            // 
            this.hsbMapView.Location = new System.Drawing.Point(677, 915);
            this.hsbMapView.Name = "hsbMapView";
            this.hsbMapView.Size = new System.Drawing.Size(900, 21);
            this.hsbMapView.TabIndex = 22;
            this.hsbMapView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbMapView_Scroll);
            // 
            // MapCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.hsbMapView);
            this.Controls.Add(this.vsbMapView);
            this.Controls.Add(this.pbMapView);
            this.Controls.Add(this.nudSeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btMenu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbMaps);
            this.Controls.Add(this.pbMap);
            this.Controls.Add(this.btDeleteMap);
            this.Controls.Add(this.btSaveMap);
            this.Controls.Add(this.btGenerateMap);
            this.Controls.Add(this.cbMapType);
            this.Controls.Add(this.cbLakes);
            this.Controls.Add(this.cbRivers);
            this.Controls.Add(this.cbGroundType);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.tbName);
            this.Name = "MapCreatorForm";
            this.ShowIcon = false;
            this.Text = "Map Creator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TrackBar tbSize;
        private System.Windows.Forms.ComboBox cbGroundType;
        private System.Windows.Forms.CheckBox cbRivers;
        private System.Windows.Forms.CheckBox cbLakes;
        private System.Windows.Forms.ComboBox cbMapType;
        private System.Windows.Forms.Button btGenerateMap;
        private System.Windows.Forms.Button btSaveMap;
        private System.Windows.Forms.Button btDeleteMap;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.ListBox lbMaps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btMenu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSeed;
        private System.Windows.Forms.PictureBox pbMapView;
        private System.Windows.Forms.VScrollBar vsbMapView;
        private System.Windows.Forms.HScrollBar hsbMapView;
    }
}

