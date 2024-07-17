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

namespace ParamTriplePlus.ExoGenerator
{
    public partial class ExoGenerator : Form
    {
        public ExoGenerator(MainWindow mainWindow)
        {
            mainwindow = mainWindow;
            InitializeComponent();
            foreach (var item in ExoSettings.files)
            {
                comboBox1.Items.Add(item.SettingName);
            }
        }

        private Dictionary<string, object> paramList = new Dictionary<string, object>();

        public void UpdateSettingUI(ExoSettings setting)
        {
            foreach (var item in panel1.Controls)
            {
                if (item != length && item != label1) ((Control)item).Parent = null;
            }
            paramList.Clear();

            foreach (var item in setting.settings)
            {
                var height = mainwindow.CalcHeightStrictly(panel1);
                var param = ParamList.CreateParam(item.paramtype, item.Label, item.initial);
                paramList.Add(item.VariableName, param);
                var track = new ParamBar();

                track.Label = item.Label;
                track.Parent = panel1;
                track.Location = new Point(3, height);
                track.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                track.Width = panel1.Width - 6;
                track.param = param;

                track.OnTransionButtonClicked += () =>
                {
                    var tra = new TransionDialog(mainwindow, ParamList.GetProperty<object>(param, "Value"), param, (int)length.Value);
                    tra.ShowDialog();
                    track.SetHasTransition(ParamList.GetProperty<int>(ParamList.GetField<object>(ParamList.GetProperty<object>(param, "Value"), "sections"), "Count") != 0);
                };
                track.DisableTransion = ParamList.GetField<bool>(param, "DisableTransion");

                var panel = mainwindow.CreateParamUI(param);
                track.Height = panel is ComboBox ? panel.Height + 12 : panel.Height + 6;
                track.SetPanel(panel);
                track.SetHasTransition(ParamList.GetProperty<int>(ParamList.GetField<object>(ParamList.GetProperty<object>(param, "Value"), "sections"), "Count") != 0);

            }
        }

        public MainWindow mainwindow;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ExoSettings.files.Count <= comboBox1.SelectedIndex)
            {
                return;
            }
            UpdateSettingUI(ExoSettings.files[comboBox1.SelectedIndex]);
        }

        private DataObject exodata;

        private void dragButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("./conptpcache"))
            {
                Directory.CreateDirectory("./conptpcache");
            }
            var sjis = Encoding.GetEncoding("shift-jis");
            var set = ExoSettings.files[comboBox1.SelectedIndex];
            var dataFile = "./" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ff") + ".conptp";
            var exo = "[exedit]\r\nwidth=1920\r\nheight=1080\r\nrate=30\r\nscale=1\r\nlength=" + (int)length.Value + "\r\naudio_rate=44100\r\naudio_ch=2\r\n[0]\r\nstart=1\r\nend=" + (int)length.Value + "\r\nlayer=1\r\noverlay=1\r\ncamera=0\r\n[0.0]\r\n_name=カスタムオブジェクト\r\ntrack0=0.00\r\ntrack1=0.00\r\ntrack2=0.00\r\ntrack3=0.00\r\ncheck0=1\r\ntype=0\r\nfilter=0\r\nname=[PTP] Test@ParamTriplePlus\r\nparam=file=\"" + set.PTPPath.Replace("\\", "\\\\") + "\";dd_data=\"" + Path.GetFullPath(dataFile).Replace("\\", "\\\\") + "\";\r\n[0.1]\r\n_name=標準描画\r\nX=0.0\r\nY=0.0\r\nZ=0.0\r\n拡大率=100.00\r\n透明度=0.0\r\n回転=0.00\r\nblend=0";
            File.WriteAllText("./cache.exo", exo, Encoding.GetEncoding("shift-jis"));
            File.WriteAllText(dataFile, PTPJsonSerializer.ToJson(paramList).Replace("\\", "\\\\").Replace("\"", "\\\""), sjis);
            exodata = new DataObject();
            exodata.SetFileDropList([Path.GetFullPath("./cache.exo")]);
            DoDragDrop(exodata, DragDropEffects.Copy);
        }

        private void dragButton_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (exodata != null) DoDragDrop(exodata, DragDropEffects.Copy);
        }

        private void dragButton_DragLeave(object sender, EventArgs e)
        {
            if (exodata != null) DoDragDrop(exodata, DragDropEffects.Copy);
        }

        private void dragButton_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (exodata != null) DoDragDrop(exodata, DragDropEffects.Copy);
        }

        private void dragButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && exodata != null)
            {
                DoDragDrop(exodata, DragDropEffects.Copy);
            }
        }
    }
}
