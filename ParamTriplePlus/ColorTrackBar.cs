using ParamTriplePlus.Params;
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
    public partial class ColorTrackBar : UserControl
    {
        public ColorTrackBar()
        {
            InitializeComponent();
        }

        public Params.Color selectedColor {
            get
            {
                return new Params.Color(panel1.BackColor);
            }
            set
            {
                panel1.BackColor = System.Drawing.Color.FromArgb(255, (int)value.r, (int)value.g, (int)value.b);
            }
        }

        public delegate void ColorChangedEvent(Params.Color c);
        public event ColorChangedEvent OnColorChanged;

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
            panel1.BackColor = colorDialog1.Color;
            CheckUpdate();
        }

        private void CheckUpdate()
        {
            if (OnColorChanged != null) OnColorChanged.Invoke(selectedColor);
        }
    }
}
