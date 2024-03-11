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
    public partial class PortableDialog : Form
    {
        public PortableDialog(SimpleParam[] simpleparams)
        {
            InitializeComponent();

            this.simpleparams = simpleparams;

            var height = 3;
            foreach (var item in simpleparams)
            {
                Control control = null;
                switch (item.paramtype)
                {
                    case ParamType.Number:
                        var num = new NumericUpDown();
                        control = num;

                        num.Minimum = int.MinValue;
                        num.Maximum = int.MaxValue;
                        num.Value = (decimal)item.value;
                        num.DecimalPlaces = 2;

                        paramHold.Add(item, (float)num.Value);

                        num.ValueChanged += (a, b) => { paramHold[item] = (float)num.Value; };
                        break;
                    case ParamType.Float:
                        var floatnum = new NumericUpDown();
                        control = floatnum;

                        floatnum.Minimum = int.MinValue;
                        floatnum.Maximum = int.MaxValue;
                        floatnum.Value = (decimal)item.value;
                        floatnum.DecimalPlaces = 2;

                        paramHold.Add(item, (float)floatnum.Value);

                        floatnum.ValueChanged += (a, b) => { paramHold[item] = (float)floatnum.Value; };
                        break;
                    case ParamType.Int:
                        var intnum = new NumericUpDown();
                        control = intnum;

                        intnum.Minimum = int.MinValue;
                        intnum.Maximum = int.MaxValue;
                        intnum.Value = item.value is int ? (int)item.value : (int)Math.Floor((float)item.value);

                        paramHold.Add(item, (int)intnum.Value);

                        intnum.ValueChanged += (a, b) => { paramHold[item] = (int)intnum.Value; };
                        break;
                    case ParamType.String:
                        break;
                    case ParamType.File:
                        break;
                    case ParamType.Folder:
                        break;
                    case ParamType.MultiLine:
                        break;
                    case ParamType.Font:
                        break;
                    case ParamType.Color:
                        break;
                    case ParamType.Point:
                        break;
                    case ParamType.List:
                        break;
                    case ParamType.Combo:
                        break;
                    case ParamType.Boolean:
                        break;
                    case ParamType.Text:
                        break;
                    case ParamType.Vector2:
                        break;
                    case ParamType.Vector3:
                        break;
                    case ParamType.Dialog:
                        break;
                    case ParamType.Button:
                        break;
                    default:
                        break;
                }
                if (control == null) continue;
                control.Parent = panel1;
                control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

                var label = new Label();
                label.Parent = panel1;
                label.Text = item.label;
                label.Location = new Point(3, height);
                label.AutoSize = true;

                control.Location = new Point(3 + label.Width, height);
                control.Width = panel1.Width - 6 - label.Width;

                height += control.Height;
            }
            DialogResult = DialogResult.Cancel;
        }

        private Dictionary<SimpleParam, object> paramHold = new Dictionary<SimpleParam, object>();
        public SimpleParam[] simpleparams;

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            foreach (var item in paramHold)
            {
                item.Key.value = item.Value;
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
