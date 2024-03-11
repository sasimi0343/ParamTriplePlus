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

        public string Label { get => label1.Text; set => label1.Text = value; }
        public object param;
        public delegate void TransionButtonClickedEvent();
        public event TransionButtonClickedEvent OnTransionButtonClicked;
        public bool DisableTransion { get => !transionButton.Enabled; set => transionButton.Enabled = !value; }

        private void transionButton_Click(object sender, EventArgs e)
        {
            if (OnTransionButtonClicked != null) OnTransionButtonClicked.Invoke();
        }
    }
}
