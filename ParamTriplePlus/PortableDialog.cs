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
        public PortableDialog(SimpleParam[] simpleparams, MainWindow mainwindow = null)
        {
            this.mainwindow = mainwindow;
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
                        floatnum.Value = Convert.ToDecimal(item.value);
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
                        var str = new TextBox();
                        control = str;

                        str.Text = (string)item.value;
                        str.Multiline = false;

                        paramHold.Add(item, str.Text);

                        str.TextChanged += (a, b) => { paramHold[item] = str.Text; };
                        break;
                    case ParamType.File:
                        var fileText = new PathTrackBar(mainwindow);
                        control = fileText;

                        fileText.PathText = (string)item.value;
                        fileText.IsFolder = false;

                        paramHold.Add(item, fileText.PathText);

                        fileText.OnValueChanged += (a) =>
                        {
                            paramHold[item] = fileText.PathText;
                        };
                        break;
                    case ParamType.Folder:
                        var folderText = new PathTrackBar(mainwindow);
                        control = folderText;

                        folderText.PathText = (string)item.value;
                        folderText.IsFolder = true;

                        paramHold.Add(item, folderText.PathText);

                        folderText.OnValueChanged += (a) =>
                        {
                            paramHold[item] = folderText.PathText;
                        };
                        break;
                    case ParamType.MultiLine:
                        var strm = new TextBox();
                        control = strm;
                        control.Height = 48;
                        strm.Text = (string)item.value;
                        strm.Multiline = true;

                        paramHold.Add(item, strm.Text);

                        strm.TextChanged += (a, b) => { paramHold[item] = strm.Text; };
                        break;
                    case ParamType.Font:
                        var fontText = new FontTrackBar();
                        control = fontText;
                        fontText.FontName = (string)item.value;

                        paramHold.Add(item, fontText.FontName);

                        fontText.OnValueChanged += (a) =>
                        {
                            paramHold[item] = fontText.FontName;
                        };
                        break;
                    case ParamType.Color:
                        var colorTrack = new ColorTrackBar();
                        control = colorTrack;
                        colorTrack.selectedColor = (Params.Color)item.value;

                        paramHold.Add(item, colorTrack.selectedColor);

                        colorTrack.OnColorChanged += (a) =>
                        {
                            paramHold[item] = colorTrack.selectedColor;
                        };
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
                        var textText = new TextDecoratorTrackBar();
                        control = textText;
                        textText.TextValue = (string)item.value;

                        paramHold.Add(item, textText.TextValue);

                        textText.OnTextValueChanged += (a) =>
                        {
                            paramHold[item] = a;
                        };

                        textText.Height = 128;
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

        private MainWindow mainwindow;
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
