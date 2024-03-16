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
    public partial class ConditionBar : UserControl
    {
        public ConditionBar()
        {
            InitializeComponent();
        }

        public void SetPanel(Control control)
        {
            control.Parent = panel1;
            control.Location = new Point(0, 0);
            control.Width = panel1.Width;
            control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DeleteButtonClicked != null) DeleteButtonClicked.Invoke();
        }

        public IConditionPattern pattern;
        public delegate void DeleteButtonClickedEvent();
        public event DeleteButtonClickedEvent DeleteButtonClicked;
    }
}
