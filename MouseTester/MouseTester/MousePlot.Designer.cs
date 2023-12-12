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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statisticsGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxInterval = new System.Windows.Forms.Label();
            this.avgInterval = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rangeInterval = new System.Windows.Forms.Label();
            this.medianInterval = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.minInterval = new System.Windows.Forms.Label();
            this.stdevInterval = new System.Windows.Forms.Label();
            this.firstPercentileMetricLabel = new System.Windows.Forms.Label();
            this.secondPercentileMetricLabel = new System.Windows.Forms.Label();
            this.firstPercentileInterval = new System.Windows.Forms.Label();
            this.secondPercentileInterval = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxPlotType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownEnd = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxLines = new System.Windows.Forms.CheckBox();
            this.checkBoxStem = new System.Windows.Forms.CheckBox();
            this.buttonSavePNG = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statisticsGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1299, 791);
            this.splitContainer1.SplitterDistance = 699;
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
            this.plot1.Size = new System.Drawing.Size(1299, 699);
            this.plot1.TabIndex = 0;
            this.plot1.Text = "plot1";
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.statisticsGroupBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSavePNG, 6, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1293, 73);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // statisticsGroupBox
            // 
            this.statisticsGroupBox.AutoSize = true;
            this.statisticsGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.statisticsGroupBox.Location = new System.Drawing.Point(501, 3);
            this.statisticsGroupBox.Name = "statisticsGroupBox";
            this.statisticsGroupBox.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.statisticsGroupBox.Size = new System.Drawing.Size(337, 71);
            this.statisticsGroupBox.TabIndex = 6;
            this.statisticsGroupBox.TabStop = false;
            this.statisticsGroupBox.Text = "Statistics";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.maxInterval, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.avgInterval, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label12, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.rangeInterval, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.medianInterval, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.label14, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.label13, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.minInterval, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.stdevInterval, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.firstPercentileMetricLabel, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.secondPercentileMetricLabel, 6, 1);
            this.tableLayoutPanel3.Controls.Add(this.firstPercentileInterval, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.secondPercentileInterval, 7, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 17);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(326, 41);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Average:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Maximum:";
            // 
            // maxInterval
            // 
            this.maxInterval.AutoSize = true;
            this.maxInterval.Location = new System.Drawing.Point(54, 2);
            this.maxInterval.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.maxInterval.Name = "maxInterval";
            this.maxInterval.Size = new System.Drawing.Size(13, 13);
            this.maxInterval.TabIndex = 4;
            this.maxInterval.Text = "0";
            // 
            // avgInterval
            // 
            this.avgInterval.AutoSize = true;
            this.avgInterval.Location = new System.Drawing.Point(54, 25);
            this.avgInterval.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.avgInterval.Name = "avgInterval";
            this.avgInterval.Size = new System.Drawing.Size(13, 13);
            this.avgInterval.TabIndex = 5;
            this.avgInterval.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 2);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Minimum:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(77, 25);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "STDEV:";
            // 
            // rangeInterval
            // 
            this.rangeInterval.AutoSize = true;
            this.rangeInterval.Location = new System.Drawing.Point(196, 2);
            this.rangeInterval.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.rangeInterval.Name = "rangeInterval";
            this.rangeInterval.Size = new System.Drawing.Size(13, 13);
            this.rangeInterval.TabIndex = 12;
            this.rangeInterval.Text = "0";
            // 
            // medianInterval
            // 
            this.medianInterval.AutoSize = true;
            this.medianInterval.Location = new System.Drawing.Point(196, 25);
            this.medianInterval.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.medianInterval.Name = "medianInterval";
            this.medianInterval.Size = new System.Drawing.Size(13, 13);
            this.medianInterval.TabIndex = 13;
            this.medianInterval.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(151, 25);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Median:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(151, 2);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Range:";
            // 
            // minInterval
            // 
            this.minInterval.AutoSize = true;
            this.minInterval.Location = new System.Drawing.Point(128, 2);
            this.minInterval.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.minInterval.Name = "minInterval";
            this.minInterval.Size = new System.Drawing.Size(13, 13);
            this.minInterval.TabIndex = 14;
            this.minInterval.Text = "0";
            // 
            // stdevInterval
            // 
            this.stdevInterval.AutoSize = true;
            this.stdevInterval.Location = new System.Drawing.Point(128, 25);
            this.stdevInterval.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.stdevInterval.Name = "stdevInterval";
            this.stdevInterval.Size = new System.Drawing.Size(13, 13);
            this.stdevInterval.TabIndex = 15;
            this.stdevInterval.Text = "0";
            // 
            // firstPercentileMetricLabel
            // 
            this.firstPercentileMetricLabel.AutoSize = true;
            this.firstPercentileMetricLabel.Location = new System.Drawing.Point(219, 2);
            this.firstPercentileMetricLabel.Margin = new System.Windows.Forms.Padding(0);
            this.firstPercentileMetricLabel.Name = "firstPercentileMetricLabel";
            this.firstPercentileMetricLabel.Size = new System.Drawing.Size(72, 13);
            this.firstPercentileMetricLabel.TabIndex = 16;
            this.firstPercentileMetricLabel.Text = "99 Percentile:";
            // 
            // secondPercentileMetricLabel
            // 
            this.secondPercentileMetricLabel.AutoSize = true;
            this.secondPercentileMetricLabel.Location = new System.Drawing.Point(219, 25);
            this.secondPercentileMetricLabel.Margin = new System.Windows.Forms.Padding(0);
            this.secondPercentileMetricLabel.Name = "secondPercentileMetricLabel";
            this.secondPercentileMetricLabel.Size = new System.Drawing.Size(81, 13);
            this.secondPercentileMetricLabel.TabIndex = 17;
            this.secondPercentileMetricLabel.Text = "99.9 Percentile:";
            // 
            // firstPercentileInterval
            // 
            this.firstPercentileInterval.AutoSize = true;
            this.firstPercentileInterval.Location = new System.Drawing.Point(300, 2);
            this.firstPercentileInterval.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.firstPercentileInterval.Name = "firstPercentileInterval";
            this.firstPercentileInterval.Size = new System.Drawing.Size(13, 13);
            this.firstPercentileInterval.TabIndex = 18;
            this.firstPercentileInterval.Text = "0";
            // 
            // secondPercentileInterval
            // 
            this.secondPercentileInterval.AutoSize = true;
            this.secondPercentileInterval.Location = new System.Drawing.Point(300, 25);
            this.secondPercentileInterval.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.secondPercentileInterval.Name = "secondPercentileInterval";
            this.secondPercentileInterval.Size = new System.Drawing.Size(13, 13);
            this.secondPercentileInterval.TabIndex = 19;
            this.secondPercentileInterval.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxPlotType);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 71);
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
            "Frequency vs. Time",
            "xVelocity vs. Time",
            "yVelocity vs. Time",
            "xyVelocity vs. Time",
            "X vs. Y"});
            this.comboBoxPlotType.Location = new System.Drawing.Point(6, 30);
            this.comboBoxPlotType.Name = "comboBoxPlotType";
            this.comboBoxPlotType.Size = new System.Drawing.Size(200, 21);
            this.comboBoxPlotType.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownStart);
            this.groupBox2.Location = new System.Drawing.Point(219, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 71);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Point Start";
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.Location = new System.Drawing.Point(6, 30);
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStart.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownEnd);
            this.groupBox3.Location = new System.Drawing.Point(360, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 71);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Point End";
            // 
            // numericUpDownEnd
            // 
            this.numericUpDownEnd.Location = new System.Drawing.Point(6, 30);
            this.numericUpDownEnd.Name = "numericUpDownEnd";
            this.numericUpDownEnd.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownEnd.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.checkBoxLines, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxStem, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(844, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(66, 63);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // checkBoxLines
            // 
            this.checkBoxLines.AutoSize = true;
            this.checkBoxLines.Location = new System.Drawing.Point(3, 15);
            this.checkBoxLines.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.checkBoxLines.Name = "checkBoxLines";
            this.checkBoxLines.Size = new System.Drawing.Size(51, 17);
            this.checkBoxLines.TabIndex = 9;
            this.checkBoxLines.Text = "Lines";
            this.checkBoxLines.UseVisualStyleBackColor = true;
            // 
            // checkBoxStem
            // 
            this.checkBoxStem.AutoSize = true;
            this.checkBoxStem.Location = new System.Drawing.Point(3, 38);
            this.checkBoxStem.Name = "checkBoxStem";
            this.checkBoxStem.Size = new System.Drawing.Size(50, 17);
            this.checkBoxStem.TabIndex = 8;
            this.checkBoxStem.Text = "Stem";
            this.checkBoxStem.UseVisualStyleBackColor = true;
            // 
            // buttonSavePNG
            // 
            this.buttonSavePNG.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonSavePNG.Location = new System.Drawing.Point(1209, 27);
            this.buttonSavePNG.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.buttonSavePNG.Name = "buttonSavePNG";
            this.buttonSavePNG.Size = new System.Drawing.Size(75, 23);
            this.buttonSavePNG.TabIndex = 7;
            this.buttonSavePNG.Text = "SavePNG";
            this.buttonSavePNG.UseVisualStyleBackColor = true;
            this.buttonSavePNG.Click += new System.EventHandler(this.buttonSavePNG_Click);
            // 
            // MousePlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1299, 791);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1315, 830);
            this.Name = "MousePlot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statisticsGroupBox.ResumeLayout(false);
            this.statisticsGroupBox.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.GroupBox statisticsGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label maxInterval;
        private System.Windows.Forms.Label avgInterval;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label rangeInterval;
        private System.Windows.Forms.Label medianInterval;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label minInterval;
        private System.Windows.Forms.Label stdevInterval;
        private System.Windows.Forms.Label firstPercentileMetricLabel;
        private System.Windows.Forms.Label secondPercentileMetricLabel;
        private System.Windows.Forms.Label firstPercentileInterval;
        private System.Windows.Forms.Label secondPercentileInterval;
    }
}