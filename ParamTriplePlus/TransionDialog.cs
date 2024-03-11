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
    public partial class TransionDialog : Form
    {
        public TransionDialog(MainWindow mainwindow, object transion, object param, int length) //Transion<object>, Param<object>
        {
            InitializeComponent();

            this.transion = transion;
            this.mainwindow = mainwindow;
            this.param = param;
            this.length = length;

            UpdateList();
        }

        public void UpdateList()
        {
            listpanel.Controls.Clear();
            var transionlist = transion.GetType().GetField("sections").GetValue(transion);
            var array = (Array)transionlist.GetType().GetMethod("ToArray").Invoke(transionlist, new object[0]);

            var list = new List<object>();
            foreach (var item in array)
            {
                list.Add(item);
            }

            list.Sort((a, b) =>
            {
                return ParamList.GetField<int>(a, "frame") - ParamList.GetField<int>(b, "frame");
            });

            transionlist.GetType().GetMethod("Clear").Invoke(transionlist, new object[0]);

            var i = 0;
            var height = 3;
            foreach (var item in list)
            {
                transionlist.GetType().GetMethod("Add").Invoke(transionlist, new object[] { item });
                var parambar = new SimpleParamBar();
                parambar.trackBar1.Maximum = length;
                parambar.trackBar1.Value = ParamList.GetField<int>(item, "frame");
                parambar.OnFrameChanged += (a) => { ParamList.SetField(list[parambar.index], "frame", a); UpdateOnly(); };
                parambar.Parent = listpanel;
                parambar.Width = listpanel.Width;
                parambar.Location = new Point(3, height);
                pairs.Add(parambar);
                mainwindow.AddTransionParam(parambar, param, i);
                parambar.sectionList = list;
                parambar.UpdateTransionTypes();
                height += parambar.Height;
                i++;
            }
        }

        public void UpdateOnly()
        {
            var transionlist = transion.GetType().GetField("sections").GetValue(transion);
            var array = (Array)transionlist.GetType().GetMethod("ToArray").Invoke(transionlist, new object[0]);

            var list = new List<object>();
            foreach (var item in array)
            {
                list.Add(item);
            }

            list.Sort((a, b) =>
            {
                return ParamList.GetField<int>(a, "frame") - ParamList.GetField<int>(b, "frame");
            });

            transionlist.GetType().GetMethod("Clear").Invoke(transionlist, new object[0]);

            var spbs = new List<SimpleParamBar>();
            foreach (var spb in pairs)
            {
                spbs.Add(spb);
            }

            pairs.Clear();
            var i = 0;
            var height = 3;
            foreach (var item in list)
            {
                transionlist.GetType().GetMethod("Add").Invoke(transionlist, new object[] { item });
                SimpleParamBar parambar = null;
                if (spbs.Count > i)
                {
                    parambar = spbs[i];
                    parambar.RemoveFrameEvent();
                    parambar.IgnoreFrameEvent = true;
                    parambar.trackBar1.Value = ParamList.GetField<int>(item, "frame");
                    parambar.IgnoreFrameEvent = false;
                    parambar.OnFrameChanged += (a) => { ParamList.SetField(list[parambar.index], "frame", a); UpdateOnly(); };
                    parambar.Parent = listpanel;
                    mainwindow.AddTransionParam(parambar, param, i);
                }
                else
                {
                    parambar = new SimpleParamBar();
                    parambar.trackBar1.Maximum = length;
                    parambar.trackBar1.Value = ParamList.GetField<int>(item, "frame");
                    parambar.OnFrameChanged += (a) => { ParamList.SetField(list[parambar.index], "frame", a); UpdateOnly(); };
                    parambar.Parent = listpanel;
                    mainwindow.AddTransionParam(parambar, param, i);
                }
                parambar.sectionList = list;
                parambar.UpdateTransionTypes();
                parambar.Width = listpanel.Width;
                parambar.Location = new Point(3, height);
                height += parambar.Height;
                pairs.Add(parambar);
                i++;
            }
        }

        public List<SimpleParamBar> pairs = new List<SimpleParamBar>();
        public MainWindow mainwindow;
        public object transion;
        public object param;
        public int length;

        private void addButton_Click(object sender, EventArgs e)
        {
            var transionlist = transion.GetType().GetField("sections").GetValue(transion);
            transionlist.GetType().GetMethod("Add").Invoke(transionlist, new object[] { TransionSection<object>.Create(TransionSection<object>.Default(transion.GetType().GenericTypeArguments[0])) });
            UpdateOnly();
        }
    }
}
