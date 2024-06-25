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
    public partial class SimpleParamBar : UserControl
    {
        public SimpleParamBar()
        {
            InitializeComponent();
            SetTransionType(typeof(FloatSection.TransionType), transion_number);
            SetTransionType(typeof(TextSection.TransionType), transion_string);
            SetTransionType(typeof(BaseTransionType), transion_any);
        }

        public void UpdateTransionTypes()
        {
            var tra = ParamList.GetProperty<object>(sectionList[index], "transiontype");
            UpdateTransionType(tra, transion_number);
            UpdateTransionType(tra, transion_string);
            UpdateTransionType(tra, transion_any);

            var shortName = "";
            if (tra is FloatSection.TransionType)
            {
                shortName = FloatSection.GetTransionTypeShortName((FloatSection.TransionType)tra);
            }
            else if (tra is TextSection.TransionType)
            {
                shortName = TextSection.GetTransionTypeShortName((TextSection.TransionType)tra);
            }
            else
            {
                shortName = TransionSection<object>.GetTransionTypeShortName((BaseTransionType)ParamList.GetField<object>(sectionList[index], "baseTransionType"));
            }

            transionButton.Text = shortName;
        }

        public void UpdateTransionType(object transion, ContextMenuStrip strip)
        {
            foreach (var item in strip.Items)
            {
                if (!(item is ToolStripMenuItem)) continue;
                var itm = (ToolStripMenuItem)item;
                if (!menuItemValue.ContainsKey(itm)) continue;
                if (transion == menuItemValue[itm])
                {
                    itm.Checked = true;
                }
                else
                {
                    itm.Checked = false;
                }
            }

        }

        public void SetTransionType(Type transionType, ContextMenuStrip strip)
        {
            var transions = Enum.GetValues(transionType);
            foreach (var transion in transions)
            {
                var dispName = "";
                var shortName = "";
                if (transion is FloatSection.TransionType)
                {
                    dispName = FloatSection.GetTransionTypeName((FloatSection.TransionType)transion);
                    shortName = FloatSection.GetTransionTypeShortName((FloatSection.TransionType)transion);
                }
                else if (transion is TextSection.TransionType)
                {
                    dispName = TextSection.GetTransionTypeName((TextSection.TransionType)transion);
                    shortName = TextSection.GetTransionTypeShortName((TextSection.TransionType)transion);
                }
                else
                {
                    dispName = TransionSection<object>.GetTransionTypeName((BaseTransionType)transion);
                    shortName = TransionSection<object>.GetTransionTypeShortName((BaseTransionType)transion);
                }

                var item = (ToolStripMenuItem)strip.Items.Add(dispName);
                item.Click += (a, b) =>
                {
                    foreach (var ite in strip.Items)
                    {
                        if (!(ite is ToolStripMenuItem)) continue;
                        var it = (ToolStripMenuItem)ite;
                        if (loopTypeMenuItems.Contains(it)) continue;
                        it.Checked = false;

                    }
                    ParamList.SetProperty(sectionList[index], "transiontype", transion, "baseTransionType");
                    transionButton.Text = shortName;
                    item.Checked = true;
                };

                menuItemValue.Add(item, transion);
            }

            strip.Items.Add(new ToolStripSeparator());

            var loops = Enum.GetValues(typeof(LoopType));
            foreach (var loop in loops)
            {
                var dispName = TransionSection<object>.GetLoopTypeName((LoopType)loop);
                var item = (ToolStripMenuItem)strip.Items.Add(dispName);

                item.Click += (a, b) =>
                {
                    looptype = (LoopType)loop;
                    foreach (var ite in strip.Items)
                    {
                        if (!(ite is ToolStripMenuItem)) continue;
                        var it = (ToolStripMenuItem)ite;
                        if (loopTypeMenuItems.Contains(it)) it.Checked = false;
                    }
                    ParamList.SetField(sectionList[index], "loopType", loop);
                    item.Checked = true;
                };

                loopTypeMenuItems.Add(item);
            }
        }

        public List<object> sectionList = new List<object>();
        private Dictionary<ToolStripMenuItem, object> menuItemValue = new Dictionary<ToolStripMenuItem, object>();
        private List<ToolStripMenuItem> loopTypeMenuItems = new List<ToolStripMenuItem>();
        public LoopType looptype;

        public void SetPanel(Control control)
        {
            control.Parent = panel1;
            control.Location = new Point(0, 0);
            control.Width = panel1.Width;
            control.Height = panel1.Height;
            control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        }

        public Control panelControl { get => panel1.Controls.Count > 0 ? panel1.Controls[0] : null; }

        public object param;
        public int index;

        public delegate void FrameChangedEvent(int frame);
        public event FrameChangedEvent OnFrameChanged;

        public delegate void DeletedEvent();
        public event DeletedEvent OnDeleted;

        private void transionButton_Click(object sender, EventArgs e)
        {
            if (
                param is Param<int> ||
                param is Param<float> ||
                param is Param<Vector2> ||
                param is Param<Vector3>
                )
            {
                transion_number.Show(transionButton.Parent, transionButton.Location);
            }
            else if (param is Param<string>)
            {
                transion_string.Show(transionButton.Parent, transionButton.Location);
            }
            else
            {
                //transion_any.Show(transionButton, transionButton.Location);
            }
        }

        public void RemoveFrameEvent() { OnFrameChanged = null; OnDeleted = null; }

        private bool MouseClicked = false;
        public bool IgnoreFrameEvent { get; set; }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (OnFrameChanged != null && !MouseClicked && !IgnoreFrameEvent) OnFrameChanged.Invoke(trackBar1.Value);
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (OnFrameChanged != null && !IgnoreFrameEvent) OnFrameChanged.Invoke(trackBar1.Value);
            MouseClicked = false;
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseClicked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnDeleted != null) OnDeleted.Invoke();
        }

        private void 値を設定するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new ValueSettingDialog(0, trackBar1.Maximum, 0, trackBar1.Value);
            if (dialog.ShowDialog() != DialogResult.OK) return;
            trackBar1.Value = (int)dialog.Value;
        }
    }
}
