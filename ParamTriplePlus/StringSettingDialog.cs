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
    public partial class StringSettingDialog : Form
    {
        public StringSettingDialog(string value)
        {
            InitializeComponent();
            textBox1.Text = value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = initialValue;
            Close();
        }

        private string initialValue;
        public string Value { get => textBox1.Text; }
    }
}
