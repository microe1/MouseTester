namespace MouseTester
{
    partial class MousePlot
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.plot1 = new OxyPlot.WindowsForms.Plot();
            this.checkBoxStem = new System.Windows.Forms.CheckBox();
            this.buttonSavePNG = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownEnd = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxPlotType = new System.Windows.Forms.ComboBox();
            this.checkBoxLines = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.plot1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxLines);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxStem);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSavePNG);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 677);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.TabIndex = 0;
            // 
            // plot1
            // 
            this.plot1.BackColor = System.Drawing.Color.White;
            this.plot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot1.KeyboardPanHorizontalStep = 0.1D;
            this.plot1.KeyboardPanVerticalStep = 0.1D;
            this.plot1.Location = new System.Drawing.Point(0, 0);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(800, 600);
            this.plot1.TabIndex = 0;
            this.plot1.Text = "plot1";
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // checkBoxStem
            // 
            this.checkBoxStem.AutoSize = true;
            this.checkBoxStem.Location = new System.Drawing.Point(510, 40);
            this.checkBoxStem.Name = "checkBoxStem";
            this.checkBoxStem.Size = new System.Drawing.Size(50, 17);
            this.checkBoxStem.TabIndex = 8;
            this.checkBoxStem.Text = "Stem";
            this.checkBoxStem.UseVisualStyleBackColor = true;
            // 
            // buttonSavePNG
            // 
            this.buttonSavePNG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSavePNG.Location = new System.Drawing.Point(713, 24);
            this.buttonSavePNG.Name = "buttonSavePNG";
            this.buttonSavePNG.Size = new System.Drawing.Size(75, 23);
            this.buttonSavePNG.TabIndex = 7;
            this.buttonSavePNG.Text = "SavePNG";
            this.buttonSavePNG.UseVisualStyleBackColor = true;
            this.buttonSavePNG.Click += new System.EventHandler(this.buttonSavePNG_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownEnd);
            this.groupBox3.Location = new System.Drawing.Point(369, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 50);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Point End";
            // 
            // numericUpDownEnd
            // 
            this.numericUpDownEnd.Location = new System.Drawing.Point(6, 20);
            this.numericUpDownEnd.Name = "numericUpDownEnd";
            this.numericUpDownEnd.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownEnd.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownStart);
            this.groupBox2.Location = new System.Drawing.Point(228, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 50);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Point Start";
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.Location = new System.Drawing.Point(6, 20);
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStart.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxPlotType);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plot Type";
            // 
            // comboBoxPlotType
            // 
            this.comboBoxPlotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlotType.FormattingEnabled = true;
            this.comboBoxPlotType.Items.AddRange(new object[] {
            "xCount vs. Time",
            "yCount vs. Time",
            "xyCount vs. Time",
            "Interval vs. Time",
            "xVelocity vs. Time",
            "yVelocity vs. Time",
            "xyVelocity vs. Time",
            "X vs. Y"});
            this.comboBoxPlotType.Location = new System.Drawing.Point(6, 19);
            this.comboBoxPlotType.Name = "comboBoxPlotType";
            this.comboBoxPlotType.Size = new System.Drawing.Size(200, 21);
            this.comboBoxPlotType.TabIndex = 1;
            // 
            // checkBoxLines
            // 
            this.checkBoxLines.AutoSize = true;
            this.checkBoxLines.Location = new System.Drawing.Point(510, 17);
            this.checkBoxLines.Name = "checkBoxLines";
            this.checkBoxLines.Size = new System.Drawing.Size(51, 17);
            this.checkBoxLines.TabIndex = 9;
            this.checkBoxLines.Text = "Lines";
            this.checkBoxLines.UseVisualStyleBackColor = true;
            // 
            // MousePlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 677);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(808, 627);
            this.Name = "MousePlot";
            this.Text = "MousePlot";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private OxyPlot.WindowsForms.Plot plot1;
        private System.Windows.Forms.ComboBox comboBoxPlotType;
        private System.Windows.Forms.NumericUpDown numericUpDownStart;
        private System.Windows.Forms.NumericUpDown numericUpDownEnd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSavePNG;
        private System.Windows.Forms.CheckBox checkBoxStem;
        private System.Windows.Forms.CheckBox checkBoxLines;
    }
}