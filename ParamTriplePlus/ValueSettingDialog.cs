using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParamTriplePlus
{
    public partial class ValueSettingDialog : Form
    {
        public ValueSettingDialog(decimal min, decimal max, int decimalplace, decimal value)
        {
            InitializeComponent();
            numberBar.Minimum = min;
            numberBar.Maximum = max;
            numberBar.DecimalPlaces = decimalplace;
            numberBar.Value = value;
            initialValue = value;
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numberBar.Value = initialValue;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private decimal initialValue;
        public decimal Value { get => numberBar.Value; }
    }
}
