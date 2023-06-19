namespace MouseTester
{
    partial class NumericInputDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericValue = new System.Windows.Forms.NumericUpDown();
            this.applyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Percentile:";
            // 
            // numericValue
            // 
            this.numericValue.DecimalPlaces = 3;
            this.numericValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericValue.Location = new System.Drawing.Point(16, 29);
            this.numericValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericValue.Name = "numericValue";
            this.numericValue.Size = new System.Drawing.Size(135, 20);
            this.numericValue.TabIndex = 1;
            this.numericValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(16, 55);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(135, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // NumericInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 93);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.numericValue);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "NumericInputDialog";
            this.Text = "Percentile";
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericValue;
        private System.Windows.Forms.Button applyButton;
    }
}