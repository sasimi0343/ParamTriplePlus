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
    public partial class ParamBar : UserControl
    {
        public ParamBar()
        {
            InitializeComponent();
        }

        public void SetPanel(Control control)
        {
            control.Parent = panel1;
            control.Location = new Point(0, 0);
            control.Width = panel1.Width;
            control.Height = panel1.Height;
            control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        }

        public void SetHasTransition(bool tra)
        {
            if (HasNoNativeValue)
            {
                if (tra)
                {
                    BackColor = System.Drawing.Color.FromArgb(255, 50, 150, 50);
                }
                else
                {
                    BackColor = SystemColors.Control;
                }
            }
            else
            {
                BackColor = System.Drawing.Color.FromArgb(255, 150, 50, 50);
            }
        }

        private bool HasNoNativeValue { get => string.IsNullOrEmpty(ParamList.GetField<string>(param, "NativeValue")); }
        public string Label { get => label1.Text; set => label1.Text = value; }
        public object param;
        public delegate void TransionButtonClickedEvent();
        public event TransionButtonClickedEvent OnTransionButtonClicked;
        public delegate void NativeValueSetEvent();
        public event NativeValueSetEvent OnNativeValueChanged;
        public bool DisableTransion { get => !transionButton.Enabled; set => transionButton.Enabled = !value; }

        private void transionButton_Click(object sender, EventArgs e)
        {
            if (OnTransionButtonClicked != null) OnTransionButtonClicked.Invoke();
        }

        private void ネイティブ値を設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var win = new StringSettingDialog(ParamList.GetField<string>(param, "NativeValue"));
            if (win.ShowDialog() == DialogResult.OK)
            {
                ParamList.SetField(param, "NativeValue", win.Value);
                if (!HasNoNativeValue)
                {
                    BackColor = System.Drawing.Color.FromArgb(255, 150, 50, 50);
                }
                else
                {
                    BackColor = SystemColors.Control;
                }
            }
        }
    }
}
