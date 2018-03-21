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
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(356, 272);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(337, 45);
            this.tbName.TabIndex = 0;
            // 
            // tbSize
            // 
            this.tbSize.LargeChange = 100;
            this.tbSize.Location = new System.Drawing.Point(356, 343);
            this.tbSize.Maximum = 800;
            this.tbSize.Minimum = 200;
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(337, 56);
            this.tbSize.SmallChange = 100;
            this.tbSize.TabIndex = 1;
            this.tbSize.TickFrequency = 100;
            this.tbSize.Value = 200;
            this.tbSize.Scroll += new System.EventHandler(this.tbSize_Scroll);
            // 
            // cbGroundType
            // 
            this.cbGroundType.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGroundType.FormattingEnabled = true;
            this.cbGroundType.Items.AddRange(new object[] {
            "Water",
            "Grass",
            "Snow",
            "Desert"});
            this.cbGroundType.Location = new System.Drawing.Point(356, 415);
            this.cbGroundType.Name = "cbGroundType";
            this.cbGroundType.Size = new System.Drawing.Size(337, 46);
            this.cbGroundType.TabIndex = 2;
            // 
            // cbRivers
            // 
            this.cbRivers.AutoSize = true;
            this.cbRivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRivers.Location = new System.Drawing.Point(560, 555);
            this.cbRivers.Name = "cbRivers";
            this.cbRivers.Size = new System.Drawing.Size(133, 42);
            this.cbRivers.TabIndex = 3;
            this.cbRivers.Text = "Rivers";
            this.cbRivers.UseVisualStyleBackColor = true;
            // 
            // cbLakes
            // 
            this.cbLakes.AutoSize = true;
            this.cbLakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLakes.Location = new System.Drawing.Point(356, 555);
            this.cbLakes.Name = "cbLakes";
            this.cbLakes.Size = new System.Drawing.Size(127, 42);
            this.cbLakes.TabIndex = 4;
            this.cbLakes.Text = "Lakes";
            this.cbLakes.UseVisualStyleBackColor = true;
            // 
            // cbMapType
            // 
            this.cbMapType.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMapType.FormattingEnabled = true;
            this.cbMapType.Items.AddRange(new object[] {
            "Continent",
            "Island"});
            this.cbMapType.Location = new System.Drawing.Point(356, 488);
            this.cbMapType.Name = "cbMapType";
            this.cbMapType.Size = new System.Drawing.Size(337, 46);
            this.cbMapType.TabIndex = 5;
            // 
            // btGenerateMap
            // 
            this.btGenerateMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenerateMap.Location = new System.Drawing.Point(35, 899);
            this.btGenerateMap.Name = "btGenerateMap";
            this.btGenerateMap.Size = new System.Drawing.Size(292, 100);
            this.btGenerateMap.TabIndex = 6;
            this.btGenerateMap.Text = "Generate Map";
            this.btGenerateMap.UseVisualStyleBackColor = true;
            this.btGenerateMap.Click += new System.EventHandler(this.btGenerateMap_Click);
            // 
            // btSaveMap
            // 
            this.btSaveMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveMap.Location = new System.Drawing.Point(376, 899);
            this.btSaveMap.Name = "btSaveMap";
            this.btSaveMap.Size = new System.Drawing.Size(292, 100);
            this.btSaveMap.TabIndex = 7;
            this.btSaveMap.Text = "Save Map";
            this.btSaveMap.UseVisualStyleBackColor = true;
            this.btSaveMap.Click += new System.EventHandler(this.btSaveMap_Click);
            // 
            // btDeleteMap
            // 
            this.btDeleteMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteMap.Location = new System.Drawing.Point(720, 899);
            this.btDeleteMap.Name = "btDeleteMap";
            this.btDeleteMap.Size = new System.Drawing.Size(292, 100);
            this.btDeleteMap.TabIndex = 8;
            this.btDeleteMap.Text = "Delete Map";
            this.btDeleteMap.UseVisualStyleBackColor = true;
            this.btDeleteMap.Click += new System.EventHandler(this.btDeleteMap_Click);
            // 
            // pbMap
            // 
            this.pbMap.Location = new System.Drawing.Point(1432, 12);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(450, 450);
            this.pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMap.TabIndex = 9;
            this.pbMap.TabStop = false;
            // 
            // lbMaps
            // 
            this.lbMaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaps.FormattingEnabled = true;
            this.lbMaps.ItemHeight = 31;
            this.lbMaps.Location = new System.Drawing.Point(1432, 468);
            this.lbMaps.Name = "lbMaps";
            this.lbMaps.Size = new System.Drawing.Size(450, 531);
            this.lbMaps.TabIndex = 10;
            this.lbMaps.SelectedIndexChanged += new System.EventHandler(this.lbMaps_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 38);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 38);
            this.label2.TabIndex = 12;
            this.label2.Text = "Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(110, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 38);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ground Type:";
            // 
            // btMenu
            // 
            this.btMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMenu.Location = new System.Drawing.Point(1060, 899);
            this.btMenu.Name = "btMenu";
            this.btMenu.Size = new System.Drawing.Size(292, 100);
            this.btMenu.TabIndex = 14;
            this.btMenu.Text = "Menu";
            this.btMenu.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(156, 491);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 38);
            this.label4.TabIndex = 15;
            this.label4.Text = "Map Type:";
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSize.Location = new System.Drawing.Point(713, 343);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(71, 38);
            this.lbSize.TabIndex = 16;
            this.lbSize.Text = "200";
            // 
            // MapCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
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
    }
}

