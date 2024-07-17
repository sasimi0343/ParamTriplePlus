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
    public partial class ExoSettingDialog : Form
    {
        public ExoSettingDialog(MainWindow mainWindow, ExoSettings exos = null)
        {
            mainwindow = mainWindow;
            InitializeComponent();
            pathTrackBar1.SetMainWindow(mainWindow);
            if (exos == null)
            {
                IsNew = true;
                exoSettings = new ExoSettings();
                SaveAsButton.Hide();
            }
            else
                exoSettings = exos;
            foreach (var item in Enum.GetValues(typeof(ParamType)))
            {
                var tp = (ParamType)item;

                var ct = contextMenuStrip1.Items.Add(ParamTypeToString(tp));
                ct.Click += (_, _) =>
                {
                    var sec = new ExoSettingSection();
                    sec.paramtype = tp;
                    AddParam(sec);
                };
            }
        }

        public ExoSettings exoSettings;

        public void AddParam(ExoSettingSection section)
        {
            exoSettings.settings.Add(section);
            var type = section.paramtype;

            var height = mainwindow.CalcHeightStrictly(panel1);
            var group = new GroupBox();
            group.Text = type.ToString();
            group.Parent = panel1;
            group.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            group.Location = new Point(3, height);
            group.Width = panel1.Width - 6;

            var label = new Label();
            label.Location = new Point(3, 3);
            label.Parent = group;
            label.AutoSize = true;
            label.Text = type.ToString();

            var button = new Button();
            button.Parent = group;
            button.Location = new Point(group.Width - 195, 3);
            button.Text = "編集...";
            button.Width = 128;
            button.Height = 32;
            button.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            var removebutton = new Button();
            removebutton.Parent = group;
            removebutton.Location = new Point(group.Width - 131, 3);
            removebutton.Text = "削除";
            removebutton.Width = 64;
            removebutton.Height = 32;
            removebutton.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            group.Height = 48;

            button.Click += (_, _) =>
            {
                var paramlist = ParamTypeSetting(type);
                var param = new SimpleParam[paramlist.Length + 3];
                param[0] = new SimpleParam(ParamType.String, "変数名");
                param[1] = new SimpleParam(ParamType.String, "ラベル");
                param[2] = new SimpleParam(type, "初期値");
                param[2].value = TransionSection<object>.Default(ParamList.GetParamTypeType(type));
                for (var i = 0; i < paramlist.Length; i++)
                {
                    param[i + 3] = paramlist[i];
                }

                if (new PortableDialog(param, mainwindow).ShowDialog() == DialogResult.OK)
                {
                    section.initial = param[2].value;
                    section.Label = (string)param[1].value;
                    section.VariableName = (string)param[0].value;

                    label.Text = "(" + type.ToString() + ") " + section.Label;
                    group.Text = section.VariableName;

                    switch (type)
                    {
                        case ParamType.Number:
                            break;
                        case ParamType.Float:
                        case ParamType.Int:
                            section.maxvalue = (float)param[3].value;
                            section.minvalue = (float)param[3].value;
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
                }
            };

        }

        private SimpleParam[] ParamTypeSetting(ParamType type)
        {
            switch (type)
            {
                case ParamType.Number:
                    return [];
                case ParamType.Float:
                    return [new SimpleParam(ParamType.Float, "最小値"), new SimpleParam(ParamType.Float, "最大値")];
                case ParamType.Int:
                    return [new SimpleParam(ParamType.Int, "最小値"), new SimpleParam(ParamType.Int, "最大値")];
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
            return [];
        }

        public MainWindow mainwindow;

        public static string ParamTypeToString(ParamType type)
        {
            switch (type)
            {
                case ParamType.Number:
                    return "数値";
                case ParamType.Float:
                    return "小数";
                case ParamType.Int:
                    return "整数";
                case ParamType.String:
                    return "文字列";
                case ParamType.File:
                    return "ファイル";
                case ParamType.Folder:
                    return "フォルダ";
                case ParamType.MultiLine:
                    return "文字列 (複数行)";
                case ParamType.Font:
                    return "フォント";
                case ParamType.Color:
                    return "カラー";
                case ParamType.Point:
                    return "ポイント";
                case ParamType.List:
                    return "リスト";
                case ParamType.Combo:
                    return "コンボボックス";
                case ParamType.Boolean:
                    return "ブール値";
                case ParamType.Text:
                    return "テキスト";
                case ParamType.Vector2:
                    return "ベクトル (2次元)";
                case ParamType.Vector3:
                    return "ベクトル (3次元)";
                case ParamType.Dialog:
                    return "ダイアログ";
                case ParamType.Button:
                    return "ボタン";
                default:
                    break;
            }
            return "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(this, addButton.Location);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsNew)
            {
                SaveAs();
            }
            else
            {
                exoSettings.Save();
            }
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            var dialog = new StringSettingDialog("");
            if (dialog.ShowDialog() != DialogResult.OK) return;
            exoSettings.Save(dialog.Value);
            Close();
        }

        private bool IsNew = false;

        private void pathTrackBar1_OnValueChanged(string path)
        {
            exoSettings.PTPPath = path;
        }
    }
}
