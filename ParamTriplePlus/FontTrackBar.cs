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
    public partial class FontTrackBar : UserControl
    {
        public FontTrackBar()
        {
            InitializeComponent();
        }

        public string FontName { get => textBox1.Text; set => textBox1.Text = value; }
        public delegate void ValueChangedEvent(string font);
        public event ValueChangedEvent OnValueChanged;

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel) return;
            FontName = fontDialog1.Font.Name;
            CheckUpdate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        private void CheckUpdate()
        {
            if (OnValueChanged != null) OnValueChanged.Invoke(FontName);
        }
    }
}
