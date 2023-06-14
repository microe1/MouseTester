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
            this.varianceInterval = new System.Windows.Forms.Label();
            this.rangeInterval = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.stdevInterval = new System.Windows.Forms.Label();
            this.minInterval = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.avgInterval = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxInterval = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.splitContainer1.Size = new System.Drawing.Size(1084, 791);
            this.splitContainer1.SplitterDistance = 700;
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
            this.plot1.Size = new System.Drawing.Size(1084, 700);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1078, 72);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // statisticsGroupBox
            // 
            this.statisticsGroupBox.Controls.Add(this.varianceInterval);
            this.statisticsGroupBox.Controls.Add(this.rangeInterval);
            this.statisticsGroupBox.Controls.Add(this.label6);
            this.statisticsGroupBox.Controls.Add(this.label8);
            this.statisticsGroupBox.Controls.Add(this.stdevInterval);
            this.statisticsGroupBox.Controls.Add(this.minInterval);
            this.statisticsGroupBox.Controls.Add(this.label7);
            this.statisticsGroupBox.Controls.Add(this.label5);
            this.statisticsGroupBox.Controls.Add(this.avgInterval);
            this.statisticsGroupBox.Controls.Add(this.label3);
            this.statisticsGroupBox.Controls.Add(this.maxInterval);
            this.statisticsGroupBox.Controls.Add(this.label1);
            this.statisticsGroupBox.Location = new System.Drawing.Point(501, 3);
            this.statisticsGroupBox.Name = "statisticsGroupBox";
            this.statisticsGroupBox.Size = new System.Drawing.Size(348, 63);
            this.statisticsGroupBox.TabIndex = 6;
            this.statisticsGroupBox.TabStop = false;
            this.statisticsGroupBox.Text = "Statistics";
            // 
            // varianceInterval
            // 
            this.varianceInterval.AutoSize = true;
            this.varianceInterval.Location = new System.Drawing.Point(271, 41);
            this.varianceInterval.Name = "varianceInterval";
            this.varianceInterval.Size = new System.Drawing.Size(43, 13);
            this.varianceInterval.TabIndex = 11;
            this.varianceInterval.Text = "100000";
            // 
            // rangeInterval
            // 
            this.rangeInterval.AutoSize = true;
            this.rangeInterval.Location = new System.Drawing.Point(261, 18);
            this.rangeInterval.Name = "rangeInterval";
            this.rangeInterval.Size = new System.Drawing.Size(43, 13);
            this.rangeInterval.TabIndex = 9;
            this.rangeInterval.Text = "100000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Range:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(227, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Variance:";
            // 
            // stdevInterval
            // 
            this.stdevInterval.AutoSize = true;
            this.stdevInterval.Location = new System.Drawing.Point(153, 41);
            this.stdevInterval.Name = "stdevInterval";
            this.stdevInterval.Size = new System.Drawing.Size(43, 13);
            this.stdevInterval.TabIndex = 7;
            this.stdevInterval.Text = "100000";
            // 
            // minInterval
            // 
            this.minInterval.AutoSize = true;
            this.minInterval.Location = new System.Drawing.Point(134, 18);
            this.minInterval.Name = "minInterval";
            this.minInterval.Size = new System.Drawing.Size(43, 13);
            this.minInterval.TabIndex = 5;
            this.minInterval.Text = "100000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(112, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Min:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "STDEV:";
            // 
            // avgInterval
            // 
            this.avgInterval.AutoSize = true;
            this.avgInterval.Location = new System.Drawing.Point(33, 41);
            this.avgInterval.Name = "avgInterval";
            this.avgInterval.Size = new System.Drawing.Size(43, 13);
            this.avgInterval.TabIndex = 3;
            this.avgInterval.Text = "100000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Avg:";
            // 
            // maxInterval
            // 
            this.maxInterval.AutoSize = true;
            this.maxInterval.Location = new System.Drawing.Point(33, 18);
            this.maxInterval.Name = "maxInterval";
            this.maxInterval.Size = new System.Drawing.Size(43, 13);
            this.maxInterval.TabIndex = 1;
            this.maxInterval.Text = "100000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxPlotType);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 63);
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
            this.comboBoxPlotType.Location = new System.Drawing.Point(6, 26);
            this.comboBoxPlotType.Name = "comboBoxPlotType";
            this.comboBoxPlotType.Size = new System.Drawing.Size(200, 21);
            this.comboBoxPlotType.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownStart);
            this.groupBox2.Location = new System.Drawing.Point(219, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 63);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Point Start";
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.Location = new System.Drawing.Point(6, 26);
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStart.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownEnd);
            this.groupBox3.Location = new System.Drawing.Point(360, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 63);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Point End";
            // 
            // numericUpDownEnd
            // 
            this.numericUpDownEnd.Location = new System.Drawing.Point(6, 26);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(855, 3);
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
            this.buttonSavePNG.Location = new System.Drawing.Point(994, 24);
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
            this.ClientSize = new System.Drawing.Size(1084, 791);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1100, 830);
            this.Name = "MousePlot";
            this.Text = "MousePlot";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statisticsGroupBox.ResumeLayout(false);
            this.statisticsGroupBox.PerformLayout();
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
        private System.Windows.Forms.Label stdevInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label minInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label avgInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label maxInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label varianceInterval;
        private System.Windows.Forms.Label rangeInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}