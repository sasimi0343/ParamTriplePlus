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
    public partial class Vector2TrackBar : UserControl
    {
        public Vector2TrackBar()
        {
            InitializeComponent();
        }

        public delegate void TrackBarValueChanged(Vector2 a);
        public event TrackBarValueChanged OnValueChanged;



        public Vector2 Value
        {
            get
            {
                return new Vector2(xtrackbar.Value, yTrackBar.Value);
            }
            set
            {
                xtrackbar.Value = value.x;
                yTrackBar.Value = value.y;
            }
        }

        private void xtrackbar_OnValueChanged(float a)
        {
            if (OnValueChanged != null) OnValueChanged.Invoke(Value);
        }

        private void yTrackBar_OnValueChanged(float a)
        {
            if (OnValueChanged != null) OnValueChanged.Invoke(Value);
        }

        private void zTrackBar_OnValueChanged(float a)
        {
            if (OnValueChanged != null) OnValueChanged.Invoke(Value);
        }
    }
}
