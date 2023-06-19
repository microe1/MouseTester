using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseTester
{
    public partial class NumericInputDialog : Form
    {
        public decimal value;
        public NumericInputDialog()
        {
            InitializeComponent();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            value = numericValue.Value;
            DialogResult = DialogResult.OK;
        }

        public void SetNumericValueText(decimal value)
        {
            numericValue.Value = value;
        }
    }
}
