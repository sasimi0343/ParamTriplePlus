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
    public partial class CustomizedTrackBar : UserControl
    {
        public CustomizedTrackBar()
        {
            InitializeComponent();
        }

        public delegate void TrackBarValueChanged(float a);

        public event TrackBarValueChanged OnValueChanged;

        private bool isInt = false;
        public bool IsInt
        {
            get => isInt;
            set
            {
                isInt = value;
                if (value)
                {
                    numericUpDown1.DecimalPlaces = 0;
                }
                else
                {
                    numericUpDown1.DecimalPlaces = 2;
                }
            }
        }

        private bool numRangeOut = false;
        public bool NumRangeOut
        {
            get => numRangeOut;
            set
            {
                numRangeOut = value;
                if (value)
                {
                    numericUpDown1.Maximum = decimal.MaxValue;
                    numericUpDown1.Minimum = decimal.MinValue;
                }
                else
                {
                    numericUpDown1.Maximum = (decimal)Maximum;
                    numericUpDown1.Minimum = (decimal)Minimum;
                }
            }
        }

        private float value;
        public float Value
        {
            get => value;
            set
            {
                this.value = value;
                var clampedvalue = this.value;
                if (value > Maximum)
                {
                    clampedvalue = Maximum;
                }
                else if (value < Minimum)
                {
                    clampedvalue = Minimum;
                }
                if (!IgnoreTrack)
                {
                    var valu = (int)(clampedvalue * 100);
                    if (valu >= trackBar1.Minimum && valu <= trackBar1.Maximum) trackBar1.Value = valu;
                }
                numericUpDown1.Value = (decimal)this.value;

                if (OnValueChanged != null)
                {
                    OnValueChanged.Invoke(this.value);
                }

                IgnoreTrack = false;
            }
        }

        private float maximum;
        public float Maximum
        {
            get => maximum;
            set
            {
                maximum = value;
                trackBar1.Maximum = (int)(value * 100);
                if (!NumRangeOut) numericUpDown1.Maximum = (decimal)value;
            }
        }

        private float minimum;

        public float Minimum
        {
            get => minimum;
            set
            {
                minimum = value;
                trackBar1.Minimum = (int)(value * 100);
                if (!NumRangeOut) numericUpDown1.Minimum = (decimal)value;
            }
        }

        private bool IgnoreTrack = false;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            IgnoreTrack = true;
            Value = trackBar1.Value / 100;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Value = (float)numericUpDown1.Value;
        }
    }
}
