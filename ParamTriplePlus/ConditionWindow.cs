using ParamTriplePlus.Params;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParamTriplePlus
{
    public partial class ConditionWindow : Form
    {
        public ConditionWindow(MainWindow mainWindow, Condition cond)
        {
            InitializeComponent();
            condition = cond;
            mainwindow = mainWindow;

            foreach (var item in condition.patterns)
            {
                AddConditionBar(item, true);
            }
        }

        public void AddConditionBar(IConditionPattern pattern, bool onlyui = false)
        {
            var scroll = panel1.VerticalScroll.Value;
            panel1.AutoScroll = false;

            var cond = new ConditionBar();
            var height = mainwindow.CalcHeightStrictly(panel1) + 3;
            cond.Parent = panel1;
            cond.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            cond.Location = new Point(3, height);
            cond.Width = panel1.Width - 6;
            cond.DeleteButtonClicked += () => { RemoveConditionBar(cond); };
            cond.pattern = pattern;

            height = 3;
            foreach (var item in pattern.GetParams())
            {
                var panel = mainwindow.CreateParamUI(item);
                cond.SetPanel(panel);
                panel.Location = new Point(3, height);

                height += panel.Height;
            }

            cond.Height = height + 3;

            barlist.Add(cond);

            panel1.AutoScroll = true;
            panel1.VerticalScroll.Value = scroll;

            if (!onlyui)
            {
                condition.patterns.Add(pattern);
            }
        }

        public void RemoveConditionBar(ConditionBar bar)
        {
            var scroll = panel1.VerticalScroll.Value;
            panel1.AutoScroll = false;

            barlist.Remove(bar);
            bar.Parent = null;
            bar.Dispose();

            foreach (var item in barlist)
            {
                item.Parent = null;
            }

            foreach (var item in barlist)
            {
                var height = mainwindow.CalcHeightStrictly(panel1) + 3;
                item.Parent = panel1;
                item.Location = new Point(3, height);
                item.Width = panel1.Width - 6;
            }

            condition.patterns.Remove(bar.pattern);

            panel1.AutoScroll = true;
            panel1.VerticalScroll.Value = scroll;
        }

        public List<ConditionBar> barlist = new List<ConditionBar>();
        public Condition condition;
        public MainWindow mainwindow;

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button1, new Point());
        }

        private void インディックス単一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionBar(new ObjectIndexCondition());
        }

        private void インディックス範囲ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddConditionBar(new ObjectIndexRangeCondition());
        }
    }
}
