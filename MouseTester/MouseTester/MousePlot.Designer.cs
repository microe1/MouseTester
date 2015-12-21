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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.checkBoxSize = new System.Windows.Forms.CheckBox();
            this.checkBoxBgnd = new System.Windows.Forms.CheckBox();
            this.checkBoxLines = new System.Windows.Forms.CheckBox();
            this.checkBoxStem = new System.Windows.Forms.CheckBox();
            this.buttonSavePNG = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownEnd = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxPlotType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxSize);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxBgnd);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numericUpDownDelay);
            this.groupBox4.Location = new System.Drawing.Point(360, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(100, 50);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input lag delay";
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.DecimalPlaces = 1;
            this.numericUpDownDelay.Location = new System.Drawing.Point(7, 20);
            this.numericUpDownDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownDelay.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(87, 20);
            this.numericUpDownDelay.TabIndex = 0;
            this.numericUpDownDelay.ValueChanged += new System.EventHandler(this.numericUpDownDelay_ValueChanged);
            // 
            // checkBoxSize
            // 
            this.checkBoxSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSize.AutoSize = true;
            this.checkBoxSize.Checked = true;
            this.checkBoxSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSize.Location = new System.Drawing.Point(600, 40);
            this.checkBoxSize.Name = "checkBoxSize";
            this.checkBoxSize.Size = new System.Drawing.Size(98, 17);
            this.checkBoxSize.TabIndex = 11;
            this.checkBoxSize.Text = "Fixed-size PNG";
            this.checkBoxSize.UseVisualStyleBackColor = true;
            // 
            // checkBoxBgnd
            // 
            this.checkBoxBgnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBgnd.AutoSize = true;
            this.checkBoxBgnd.Checked = true;
            this.checkBoxBgnd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBgnd.Location = new System.Drawing.Point(600, 17);
            this.checkBoxBgnd.Name = "checkBoxBgnd";
            this.checkBoxBgnd.Size = new System.Drawing.Size(109, 17);
            this.checkBoxBgnd.TabIndex = 10;
            this.checkBoxBgnd.Text = "Transparent PNG";
            this.checkBoxBgnd.UseVisualStyleBackColor = true;
            // 
            // checkBoxLines
            // 
            this.checkBoxLines.AutoSize = true;
            this.checkBoxLines.Location = new System.Drawing.Point(466, 17);
            this.checkBoxLines.Name = "checkBoxLines";
            this.checkBoxLines.Size = new System.Drawing.Size(51, 17);
            this.checkBoxLines.TabIndex = 9;
            this.checkBoxLines.Text = "Lines";
            this.checkBoxLines.UseVisualStyleBackColor = true;
            // 
            // checkBoxStem
            // 
            this.checkBoxStem.AutoSize = true;
            this.checkBoxStem.Location = new System.Drawing.Point(466, 40);
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
            this.groupBox3.Location = new System.Drawing.Point(254, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(100, 50);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Point End";
            // 
            // numericUpDownEnd
            // 
            this.numericUpDownEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownEnd.Location = new System.Drawing.Point(6, 20);
            this.numericUpDownEnd.Name = "numericUpDownEnd";
            this.numericUpDownEnd.Size = new System.Drawing.Size(88, 20);
            this.numericUpDownEnd.TabIndex = 2;
            this.numericUpDownEnd.ValueChanged += new System.EventHandler(this.numericUpDownEnd_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownStart);
            this.groupBox2.Location = new System.Drawing.Point(148, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 50);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Point Start";
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownStart.Location = new System.Drawing.Point(6, 20);
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(88, 20);
            this.numericUpDownStart.TabIndex = 3;
            this.numericUpDownStart.ValueChanged += new System.EventHandler(this.numericUpDownStart_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxPlotType);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plot Type";
            // 
            // comboBoxPlotType
            // 
            this.comboBoxPlotType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPlotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlotType.FormattingEnabled = true;
            this.comboBoxPlotType.Location = new System.Drawing.Point(6, 19);
            this.comboBoxPlotType.Name = "comboBoxPlotType";
            this.comboBoxPlotType.Size = new System.Drawing.Size(118, 21);
            this.comboBoxPlotType.TabIndex = 1;
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBoxSize;
        private System.Windows.Forms.CheckBox checkBoxBgnd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay;
    }
}