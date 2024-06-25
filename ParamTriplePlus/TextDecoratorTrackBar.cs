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
    public partial class TextDecoratorTrackBar : UserControl
    {
        public TextDecoratorTrackBar()
        {
            InitializeComponent();
        }

        public string TextValue
        {
            get => sourceTextBox.Text;
            set => sourceTextBox.Text = value;
        }

        private void sourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (OnTextValueChanged != null) OnTextValueChanged.Invoke(TextValue);
        }

        public delegate void TextChangedEvent(string text);
        public event TextChangedEvent OnTextValueChanged;
    }
}
