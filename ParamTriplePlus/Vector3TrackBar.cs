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
    public partial class Vector3TrackBar : UserControl
    {
        public Vector3TrackBar()
        {
            InitializeComponent();
        }

        public delegate void TrackBarValueChanged(Vector3 a);
        public event TrackBarValueChanged OnValueChanged;



        public Vector3 Value
        {
            get
            {
                return new Vector3(xtrackbar.Value, yTrackBar.Value, zTrackBar.Value);
            }
            set
            {
                xtrackbar.Value = value.x;
                yTrackBar.Value = value.y;
                zTrackBar.Value = value.z;
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
