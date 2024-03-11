using ParamTriplePlus.Params;
using ParamTriplePlus.Params.AviUtl;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ParamTriplePlus
{
    public partial class MainWindow : Form
    {
        public MainWindow(string[] args)
        {
            InitializeComponent();
            CommandLineArgs = args;

            if (args.Length > 0)
            {
                CurrentPath = args[0];
                File.WriteAllText(Path.Combine(Application.StartupPath, "running"), CurrentPath);
                Open();
            }
        }

        public void UpdateTitle()
        {
            Text = "ParamTriplePlus " + CurrentPath;
        }

        public void UpdateTree()
        {
            Sort();
            UpdateTree(treeView1.Nodes[0], objects);
        }

        public void UpdateTree(TreeNode nodelist, List<AviutlMediaObject> objects)
        {
            var selection = treeView1.SelectedNode;
            nodelist.Nodes.Clear();
            foreach (var item in objects)
            {
                var node = nodelist.Nodes.Add("[" + item.index + "]" + item.Name);
                node.ContextMenuStrip = nodeTreeContext;

                if (selection != null && selection.Index == node.Index)
                {
                    treeView1.SelectedNode = node;
                }
                nodeList.Add(node, item);

                if (item is GroupObject)
                {
                    var group = (GroupObject)item;
                    UpdateTree(node, group.children);
                }
            }
        }

        public void Sort()
        {
            objects.Sort((a, b) => (a.index - b.index));
            for (var i = 0; i < objects.Count; i++)
            {
                var item = objects[i];
                item.index = i;
            }
        }

        public string CurrentPath { get; private set; }
        public string[] CommandLineArgs { get; set; }

        public List<AviutlMediaObject> objects = new List<AviutlMediaObject>();
        private Dictionary<TreeNode, AviutlMediaObject> nodeList = new Dictionary<TreeNode, AviutlMediaObject>();
        private Dictionary<TabPage, AviutlMediaObject> tabList = new Dictionary<TabPage, AviutlMediaObject>();
        private Dictionary<GroupObject, ToolStripMenuItem> groupmenuItems = new Dictionary<GroupObject, ToolStripMenuItem>();

        private TabPage GetTab(AviutlMediaObject obj)
        {
            foreach (var item in tabList)
            {
                if (item.Value == obj) return item.Key;
            }
            return null;
        }

        public TabPage AddTab(string title = "")
        {
            var tab = new TabPage(title);
            tabControl1.TabPages.Add(tab);

            return tab;
        }

        public void AddObject(AviutlMediaObject obj)
        {
            obj.index = objects.Count;
            obj.mainwindow = this;
            objects.Add(obj);
            var tab = AddTab("[" + obj.index + "]" + obj.Name);
            tabList.Add(tab, obj);

            tab.AutoScroll = true;

            foreach (var item in obj.GetParams())
            {
                AddTrack(tab, item, obj);
            }

            if (obj is GroupObject)
            {
                var toolitem = (ToolStripMenuItem)グループに移動ToolStripMenuItem.DropDownItems.Add(tab.Text);
                toolitem.Click += (a, b) =>
                {
                    var node = treeView1.SelectedNode;
                    if (node == null) return;
                    ChangeParent(node, (GroupObject)obj);
                };
                groupmenuItems.Add((GroupObject)obj, toolitem);
            }

            UpdateTree();

        }

        public void AddTransionParam(SimpleParamBar parambar, object param, int index)
        {
            //parambar.Label = ParamList.GetField<string>(param, "label");
            parambar.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            parambar.param = param;
            parambar.index = index;

            var paramtype = ParamList.GetField<ParamType>(param, "paramtype");
            var isnew = parambar.panelControl == null;

            switch (paramtype)
            {
                case ParamType.Number:
                    var numparam = (Param<int>)param;
                    var num = parambar.panelControl != null ? (NumericUpDown)parambar.panelControl : new NumericUpDown();
                    num.Maximum = numparam.maximum;
                    num.Minimum = numparam.minimum;
                    num.Value = (int)Math.Clamp(numparam.Value.sections[index].value, num.Minimum, num.Maximum);
                    if (isnew) num.ValueChanged += (a, b) =>
                    {
                        numparam.Value.sections[parambar.index].value = (int)num.Value;
                    };

                    parambar.SetPanel(num);
                    break;
                case ParamType.Float:
                    var floatparam = (Param<float>)param;
                    var floatnum = parambar.panelControl != null ? (CustomizedTrackBar)parambar.panelControl : new CustomizedTrackBar();
                    floatnum.Minimum = floatparam.minimum;
                    floatnum.Maximum = floatparam.maximum;
                    floatnum.Value = floatparam.Value.sections[index].value;
                    floatnum.NumRangeOut = floatparam.AllowOver;
                    if (isnew) floatnum.OnValueChanged += (a) =>
                    {
                        floatparam.Value.sections[parambar.index].value = a;
                    };

                    parambar.SetPanel(floatnum);
                    break;
                case ParamType.Int:
                    var intparam = (Param<int>)param;
                    var intnum = parambar.panelControl != null ? (CustomizedTrackBar)parambar.panelControl : new CustomizedTrackBar();
                    intnum.Minimum = intparam.minimum;
                    intnum.Maximum = intparam.maximum;
                    intnum.Value = intparam.Value.sections[index].value;
                    intnum.NumRangeOut = intparam.AllowOver;
                    if (isnew) intnum.OnValueChanged += (a) =>
                    {
                        intparam.Value.sections[parambar.index].value = (int)a;
                    };

                    parambar.SetPanel(intnum);
                    break;
                case ParamType.String:
                    var strparam = (Param<string>)param;
                    var strText = parambar.panelControl != null ? (TextBox)parambar.panelControl : new TextBox();
                    strText.Text = strparam.Value.sections[index].value;
                    if (isnew) strText.TextChanged += (a, b) =>
                    {
                        strparam.Value.sections[parambar.index].value = strText.Text;
                    };

                    parambar.SetPanel(strText);
                    break;
                case ParamType.File:
                    var fileparam = (Param<string>)param;
                    var fileText = parambar.panelControl != null ? (PathTrackBar)parambar.panelControl : new PathTrackBar(this);
                    fileText.PathText = fileparam.Value.sections[index].value;
                    fileText.IsFolder = false;
                    if (isnew) fileText.OnValueChanged += (a) =>
                    {
                        fileparam.Value.sections[parambar.index].value = fileText.PathText;
                    };

                    parambar.Height = fileText.Height;
                    parambar.SetPanel(fileText);
                    break;
                case ParamType.Folder:
                    var folderparam = (Param<string>)param;
                    var folderText = parambar.panelControl != null ? (PathTrackBar)parambar.panelControl : new PathTrackBar(this);
                    folderText.PathText = folderparam.Value.sections[index].value;
                    folderText.IsFolder = true;
                    if (isnew) folderText.OnValueChanged += (a) =>
                    {
                        folderparam.Value.sections[parambar.index].value = folderText.PathText;
                    };

                    parambar.Height = folderText.Height;
                    parambar.SetPanel(folderText);
                    break;
                case ParamType.MultiLine:
                    var mlstrparam = (Param<string>)param;
                    var mlstrText = parambar.panelControl != null ? (TextBox)parambar.panelControl : new TextBox();
                    mlstrText.Text = mlstrparam.Value.sections[index].value;
                    mlstrText.Multiline = true;
                    if (isnew) mlstrText.TextChanged += (a, b) =>
                    {
                        mlstrparam.Value.sections[parambar.index].value = mlstrText.Text;
                    };

                    mlstrText.Height = 96;

                    parambar.Height = mlstrText.Height;

                    parambar.SetPanel(mlstrText);
                    break;
                case ParamType.Font:
                    var fontparam = (Param<string>)param;
                    var fontText = parambar.panelControl != null ? (FontTrackBar)parambar.panelControl : new FontTrackBar();
                    fontText.FontName = fontparam.Value.sections[index].value;
                    if (isnew) fontText.OnValueChanged += (a) =>
                    {
                        fontparam.Value.sections[parambar.index].value = fontText.FontName;
                    };

                    parambar.SetPanel(fontText);
                    break;
                case ParamType.Color:
                    var colorparam = (Param<Params.Color>)param;
                    var colorTrack = parambar.panelControl != null ? (ColorTrackBar)parambar.panelControl : new ColorTrackBar();
                    colorTrack.selectedColor = colorparam.Value.sections[index].value;
                    if (isnew) colorTrack.OnColorChanged += (a) =>
                    {
                        colorparam.Value.sections[parambar.index].value = colorTrack.selectedColor;
                    };

                    parambar.SetPanel(colorTrack);
                    break;
                case ParamType.Point:
                    break;
                case ParamType.List:
                    break;
                case ParamType.Combo:
                    var comboBox = parambar.panelControl != null ? (ComboBox)parambar.panelControl : new ComboBox();
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    var type = param.GetType().GenericTypeArguments[0];
                    if (type.IsEnum)
                    {
                        if (isnew)
                        {
                            foreach (var item in ParamList.GetField<List<string>>(param, "options"))
                            {
                                comboBox.Items.Add(item);
                            }
                        }
                        comboBox.SelectedIndex = (int)ParamList.GetSectionValue(param, index);
                    }

                    if (isnew) comboBox.SelectedIndexChanged += (a, b) =>
                    {
                        ParamList.SetSectionValue(param, parambar.index, comboBox.SelectedIndex);
                    };

                    parambar.SetPanel(comboBox);
                    break;
                case ParamType.Boolean:
                    var boolparam = (Param<bool>)param;
                    var boolText = parambar.panelControl != null ? (CheckBox)parambar.panelControl : new CheckBox();
                    boolText.Checked = boolparam.Value.sections[index].value;
                    boolText.Text = boolparam.label;
                    if (isnew) boolText.CheckedChanged += (a, b) =>
                    {
                        boolparam.Value.sections[parambar.index].value = boolText.Checked;
                    };

                    parambar.SetPanel(boolText);
                    break;
                case ParamType.Text:
                    break;
                case ParamType.Vector2:
                    break;
                case ParamType.Vector3:
                    var vec3param = (Param<Vector3>)param;
                    var vec3num = parambar.panelControl != null ? (Vector3TrackBar)parambar.panelControl : new Vector3TrackBar();
                    vec3num.Value = vec3param.Value.sections[index].value;
                    if (isnew) vec3num.OnValueChanged += (a) =>
                    {
                        vec3param.Value.sections[parambar.index].value = a;

                    };

                    if (isnew) parambar.Height = vec3num.Height;

                    parambar.SetPanel(vec3num);
                    break;
                case ParamType.Dialog:
                    break;
                case ParamType.Button:

                    break;
                default:
                    break;
            }
        }

        public void AddTrack(Panel tab, object param, AviutlMediaObject mediaobject)
        {
            var height = 3;
            foreach (var item in tab.Controls)
            {
                height += ((Control)item).Height;
            }
            var track = new ParamBar();
            track.Label = ParamList.GetField<string>(param, "label");
            track.Parent = tab;
            track.Location = new Point(3, height);
            track.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            track.Width = tab.Width - 6;
            track.param = param;
            track.OnTransionButtonClicked += () =>
            {
                var tra = new TransionDialog(this, ParamList.GetProperty<object>(param, "Value"), param, mediaobject.length.Value.initialValue);
                tra.ShowDialog();
            };
            track.DisableTransion = ParamList.GetField<bool>(param, "DisableTransion");

            var paramtype = ParamList.GetField<ParamType>(param, "paramtype");
            switch (paramtype)
            {
                case ParamType.Number:
                    var numparam = (Param<int>)param;
                    var num = new NumericUpDown();
                    num.Maximum = numparam.maximum;
                    num.Minimum = numparam.minimum;
                    num.Value = (int)Math.Clamp(numparam.Value.initialValue, num.Minimum, num.Maximum);
                    num.ValueChanged += (a, b) =>
                    {
                        numparam.Value.initialValue = (int)num.Value;
                    };

                    track.SetPanel(num);
                    break;
                case ParamType.Float:
                    var floatparam = (Param<float>)param;
                    var floatnum = new CustomizedTrackBar();
                    floatnum.Minimum = floatparam.minimum;
                    floatnum.Maximum = floatparam.maximum;
                    floatnum.Value = floatparam.Value.initialValue;
                    floatnum.NumRangeOut = floatparam.AllowOver;
                    floatnum.OnValueChanged += (a) =>
                    {
                        floatparam.Value.initialValue = a;
                    };

                    track.SetPanel(floatnum);
                    break;
                case ParamType.Int:
                    var intparam = (Param<int>)param;
                    var intnum = new CustomizedTrackBar();
                    intnum.Minimum = intparam.minimum;
                    intnum.Maximum = intparam.maximum;
                    intnum.Value = intparam.Value.initialValue;
                    intnum.NumRangeOut = intparam.AllowOver;
                    intnum.OnValueChanged += (a) =>
                    {
                        intparam.Value.initialValue = (int)a;
                    };

                    track.SetPanel(intnum);
                    break;
                case ParamType.String:
                    var strparam = (Param<string>)param;
                    var strText = new TextBox();
                    strText.Text = strparam.Value.initialValue;
                    strText.TextChanged += (a, b) =>
                    {
                        strparam.Value.initialValue = strText.Text;
                    };

                    track.SetPanel(strText);
                    break;
                case ParamType.File:
                    var fileparam = (Param<string>)param;
                    var fileText = new PathTrackBar(this);
                    fileText.PathText = fileparam.Value.initialValue;
                    fileText.IsFolder = false;
                    fileText.OnValueChanged += (a) =>
                    {
                        fileparam.Value.initialValue = fileText.PathText;
                    };

                    track.Height = fileText.Height;
                    track.SetPanel(fileText);
                    break;
                case ParamType.Folder:
                    var folderparam = (Param<string>)param;
                    var folderText = new PathTrackBar(this);
                    folderText.PathText = folderparam.Value.initialValue;
                    folderText.IsFolder = true;
                    folderText.OnValueChanged += (a) =>
                    {
                        folderparam.Value.initialValue = folderText.PathText;
                    };

                    track.Height = folderText.Height;
                    track.SetPanel(folderText);
                    break;
                case ParamType.MultiLine:
                    var mlstrparam = (Param<string>)param;
                    var mlstrText = new TextBox();
                    mlstrText.Text = mlstrparam.Value.initialValue;
                    mlstrText.Multiline = true;
                    mlstrText.TextChanged += (a, b) =>
                    {
                        mlstrparam.Value.initialValue = mlstrText.Text;
                    };

                    mlstrText.Height = 96;

                    track.Height = mlstrText.Height;

                    track.SetPanel(mlstrText);
                    break;
                case ParamType.Font:
                    var fontparam = (Param<string>)param;
                    var fontText = new FontTrackBar();
                    fontText.FontName = fontparam.Value.initialValue;
                    fontText.OnValueChanged += (a) =>
                    {
                        fontparam.Value.initialValue = fontText.FontName;
                    };

                    track.SetPanel(fontText);
                    break;
                case ParamType.Color:
                    var colorparam = (Param<Params.Color>)param;
                    var colorTrack = new ColorTrackBar();
                    colorTrack.selectedColor = colorparam.Value.initialValue;
                    colorTrack.OnColorChanged += (a) =>
                    {
                        colorparam.Value.initialValue = colorTrack.selectedColor;
                    };

                    track.SetPanel(colorTrack);
                    break;
                case ParamType.Point:
                    break;
                case ParamType.List:
                    break;
                case ParamType.Combo:
                    var comboBox = new ComboBox();
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    var type = param.GetType().GenericTypeArguments[0];
                    if (type.IsEnum)
                    {
                        foreach (var item in ParamList.GetField<List<string>>(param, "options"))
                        {
                            comboBox.Items.Add(item);
                        }
                        comboBox.SelectedIndex = ParamList.GetValueProperty<int>(param, "initialValue");
                    }

                    comboBox.SelectedIndexChanged += (a, b) =>
                    {
                        ParamList.SetValue(param, comboBox.SelectedIndex);
                    };

                    track.SetPanel(comboBox);
                    break;
                case ParamType.Boolean:
                    var boolparam = (Param<bool>)param;
                    var boolText = new CheckBox();
                    boolText.Checked = boolparam.Value.initialValue;
                    boolText.Text = boolparam.label;
                    boolText.CheckedChanged += (a, b) =>
                    {
                        boolparam.Value.initialValue = boolText.Checked;
                    };

                    track.SetPanel(boolText);
                    break;
                case ParamType.Text:
                    break;
                case ParamType.Vector2:
                    break;
                case ParamType.Vector3:
                    var vec3param = (Param<Vector3>)param;
                    var vec3num = new Vector3TrackBar();
                    vec3num.Value = vec3param.Value.initialValue;
                    vec3num.OnValueChanged += (a) =>
                    {
                        ParamList.SetValue(param, a);
                    };

                    track.Height = vec3num.Height;

                    track.SetPanel(vec3num);
                    break;
                case ParamType.Dialog:
                    break;
                case ParamType.Button:

                    break;
                default:
                    break;
            }
        }

        private void AddObjectButton_Click(object sender, EventArgs e)
        {
            addObjectContext.Show(AddObjectButton.Parent, AddObjectButton.Location);
        }

        private void 図形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObject(new FigureObject());
        }

        private void テキストToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObject(new TextObject());
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Save();
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(CurrentPath))
            {
                var result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                CurrentPath = saveFileDialog1.FileName;
            }
            var str = PTPJsonSerializer.ToJson(objects);
            File.WriteAllText(CurrentPath, str);
        }

        public void Open()
        {
            UpdateTitle();
            if (!File.Exists(CurrentPath))
            {
                //MessageBox.Show("ファイルが存在しません。", "ParamTriplePlus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var str = File.ReadAllText(CurrentPath);
            var objs = PTPJsonSerializer.FromJSON(str);
            objects = new List<AviutlMediaObject>();
            foreach (var item in nodeList)
            {
                item.Key.Remove();
            }
            nodeList.Clear();
            foreach (var item in tabList)
            {
                tabControl1.TabPages.Remove(item.Key);
            }
            tabList.Clear();

            foreach (var item in objs)
            {
                //Trace.WriteLine(item);
                item.index = objects.Count;
                AddObject(item);

                /*var param = item.GetParams();
                foreach (var obj in param)
                {
                    Trace.WriteLine(obj);
                }*/
            }


        }

        public void OpenDialog()
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }

            CurrentPath = openFileDialog1.FileName;
            Open();
        }

        private void MainWindow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
        }

        private void Files_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Files_Open_Click(object sender, EventArgs e)
        {
            OpenDialog();
        }

        private void ndc_remove_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node == null) return;
            RemoveObject(node);
        }

        public void ChangeParent(TreeNode node, GroupObject destination)
        {
            if (node == null) return;
            var obj = nodeList[node];
            obj.Parent = destination;
            UpdateTree();
        }

        public void RemoveObject(TreeNode node)
        {
            if (node == null) return;
            var obj = nodeList[node];
            RemoveObject(obj);
        }

        public void RemoveObject(AviutlMediaObject obj)
        {
            if (obj == null) return;
            objects.Remove(obj);
            TreeNode key = null;
            foreach (var item in nodeList)
            {
                if (item.Value == obj)
                {
                    key = item.Key;
                    item.Key.Remove();
                }
            }
            if (key != null) nodeList.Remove(key);
            TabPage keytab = null;
            foreach (var item in tabList)
            {
                if (item.Value == obj)
                {
                    keytab = item.Key;
                    tabControl1.TabPages.Remove(item.Key);
                }
            }
            if (keytab != null) tabList.Remove(keytab);
            if (obj is GroupObject && groupmenuItems.TryGetValue((GroupObject)obj, out var a))
            {
                a.GetCurrentParent().Items.Remove(a);
            }
            UpdateTree();
        }

        private void 画像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObject(new ImageObject());
        }

        private void 動画ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObject(new VideoObject());
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var tree = e.Node;
            if (nodeList.TryGetValue(tree, out var node))
            {
                foreach (var item in tabList)
                {
                    if (item.Value == node)
                    {
                        tabControl1.SelectTab(item.Key);
                        break;
                    }
                }
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Trace.WriteLine(e.Data.GetData(DataFormats.UnicodeText));
        }

        private void 新規グループToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObject(new GroupObject());
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node == null) return;
            foreach (var item in groupmenuItems)
            {
                item.Value.Enabled = true;
            }
            if (!nodeList.TryGetValue(node, out var obj)) return;
            if (obj is GroupObject)
            {
                var toolitem = groupmenuItems[(GroupObject)obj];
                toolitem.Enabled = false;
            }
        }

        private void 上に移動ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node == null) return;
            if (!nodeList.TryGetValue(node, out var obj)) return;
            if (obj.index <= 0) return;
            var target = obj.ParentList[obj.index - 1];
            target.index++;
            obj.index--;
            UpdateTree();
            GetTab(target).Text = "[" + target.index + "]" + target.Name;
            GetTab(obj).Text = "[" + obj.index + "]" + obj.Name;
        }

        private void 下に移動ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node == null) return;
            if (!nodeList.TryGetValue(node, out var obj)) return;
            if (obj.index >= obj.ParentList.Count-1) return;
            var target = obj.ParentList[obj.index + 1];
            target.index--;
            obj.index++;
            UpdateTree();
            GetTab(target).Text = "[" + target.index + "]" + target.Name;
            GetTab(obj).Text = "[" + obj.index + "]" + obj.Name;
        }
    }
}
