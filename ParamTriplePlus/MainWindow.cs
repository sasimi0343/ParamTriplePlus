using ParamTriplePlus.CustomComponent;
using ParamTriplePlus.Params;
using ParamTriplePlus.Params.AviUtl;
using ParamTriplePlus.Params.ExtremeTransition;
using ParamTriplePlus.Params.MoreShapes3D;
using ParamTriplePlus.Params.NotAviUtl;
using System.Diagnostics;

namespace ParamTriplePlus
{
    public partial class MainWindow : Form
    {
        public string AviUtlPath { get; set; }
        public string AquesTalkPlayerPath { get; set; }

        public MainWindow(string[] args)
        {
            InitializeComponent();
            CommandLineArgs = args;

            if (string.IsNullOrEmpty(Properties.Settings.Default.AviutlPath))
            {
                AviUtlPath = AviUtlExePath(Application.StartupPath);
                Properties.Settings.Default.AviutlPath = AviUtlPath;
            }
            else
            {
                AviUtlPath = Properties.Settings.Default.AviutlPath;
            }

            AquesTalkPlayerPath = Properties.Settings.Default.AquesTalkPlayerPath;

            treeView1.ExpandAll();

            InitializeAllEffects();
            InitializeAllObjects();

            var task = Task.Run(() =>
            {
                AviUtlLuaFile.LoadFolder(AviUtlPath);
                /*foreach (var item in AviUtlLuaFile.files)
                {
                    if (IsDisposed) return;
                    switch (item.LuaType)
                    {
                        case ScriptType.Animation:
                            foreach (var lua in item.luaList)
                            {
                                if (IsDisposed) return;
                                if (!IsDisposed) Invoke(() =>
                                {
                                    if (!IsDisposed) AddEffectTreeAnimation(lua.FullName, animationMenuItem);
                                });
                            }
                            break;
                        case ScriptType.CustomObject:
                            foreach (var lua in item.luaList)
                            {
                                if (IsDisposed) return;
                                if (!IsDisposed) Invoke(() =>
                                {
                                    if (!IsDisposed) AddCustomObjectTree(lua.FullName);
                                });
                            }
                            break;
                        case ScriptType.CameraControl:
                            break;
                        case ScriptType.SceneTransition:
                            break;
                        case ScriptType.Transion:
                            break;
                        default:
                            break;
                    }
                }*/
            });

            Disposed += (_, _) =>
            {
                task.Dispose();
            };

            if (args.Length > 0)
            {
                CurrentPath = args[0];
                File.WriteAllText(System.IO.Path.Combine(Application.StartupPath, "running"), CurrentPath);
                Open();
            }
        }

        private string AviUtlExePath(string path)
        {
            return string.IsNullOrEmpty(path) ? "" : (File.Exists(System.IO.Path.Combine(path, "aviutl.exe")) ? path : AviUtlExePath(System.IO.Path.GetDirectoryName(path)));
        }

        private ContextMenuStrip effectMenu_short;

        private void InitializeAllEffects()
        {
            effectMenu_short = new ContextMenuStrip();
            var blur = AddEffectTree("装飾");
            AddEffectTree(typeof(EFBorder), blur);
            AddEffectTree(typeof(EFShadow), blur);
            AddEffectTree(blur);
            AddEffectTree(typeof(EFFlatShadow), blur);
            AddEffectTree(typeof(EFInnerShadow), blur);
            AddEffectTree(typeof(EFOutline), blur);
            AddEffectTree(typeof(EFWorm), blur);
            blur = AddEffectTree("ぼかし+ブラー");
            AddEffectTree(typeof(EFBlur), blur);
            AddEffectTree(typeof(EFBorderBlur), blur);
            AddEffectTree(blur);
            AddEffectTree(typeof(EFLineBlur), blur);
            AddEffectTree(typeof(EFRadioBlur), blur);
            blur = AddEffectTree("切り抜き");
            AddEffectTree(typeof(EFClipping), blur);
            AddEffectTree(typeof(EFTendClipping), blur);
            AddEffectTree(typeof(EFMask), blur);
            blur = AddEffectTree("色変更");
            AddEffectTree(typeof(EFAdjustColor), blur);
            AddEffectTree(blur);
            AddEffectTree(typeof(EFColorlize), blur);
            AddEffectTree(typeof(EFGradient), blur);
            AddEffectTree(blur);
            AddEffectTree(typeof(EFNoise), blur);
            AddEffectTree(blur);
            AddEffectTree(typeof(EFChromaKey), blur);
            AddEffectTree(blur);
            AddEffectTree(typeof(EFAlphaContrast), blur);
            blur = AddEffectTree("変形");
            AddEffectTree(typeof(EFRaster), blur);
            AddEffectTree(typeof(EFPolarCoordinateTransform), blur);
            AddEffectTree(typeof(EFDisplacementMap), blur);
            AddEffectTree(typeof(EFScript));
            blur = AddEffectTree("基本効果");
            AddEffectTree(typeof(EFPosition), blur);
            AddEffectTree(typeof(EFRotation), blur);
            AddEffectTree(typeof(EFZoom), blur);
            AddEffectTree(typeof(EFAlpha), blur);
            AddEffectTree(typeof(EFExtend), blur);


            blur = AddEffectTree("ExtremeTransition");
            AddEffectTree(typeof(ETShowDelayed), blur);
            AddEffectTree(typeof(ETBlink), blur);
            AddEffectTree(typeof(ETMove), blur);
            AddEffectTree(typeof(ETRotate), blur);
            AddEffectTree(typeof(ETZoom), blur);

            animationMenuItem = AddEffectTree("アニメーション効果");
        }

        private void InitializeAllObjects()
        {
            AddNotAviutlObjectTree(typeof(Cross));
            AddNotAviutlObjectTree(typeof(Box));
            AddNotAviutlObjectTree(typeof(StopSign));
            AddNotAviutlObjectTree(typeof(Arrow1));
            AddNotAviutlObjectTree(typeof(Arrow2));
            AddNotAviutlObjectTree(typeof(CheckPattern));
            AddNotAviutlObjectTree(typeof(TriPoly));
            AddNotAviutlObjectTree(typeof(QuadPoly));
            AddNotAviutlObjectTree(typeof(Octagon));

            AddNotAviutlObjectTree(typeof(MS3D_Box), moreShapes3DToolStripMenuItem);
            AddNotAviutlObjectTree(typeof(MS3D_Sphere), moreShapes3DToolStripMenuItem);
            AddNotAviutlObjectTree(typeof(MS3D_Corn), moreShapes3DToolStripMenuItem);
            AddNotAviutlObjectTree(typeof(MS3D_Pillar), moreShapes3DToolStripMenuItem);
            AddNotAviutlObjectTree(typeof(MS3D_Ring), moreShapes3DToolStripMenuItem);
        }

        private ToolStripMenuItem animationMenuItem;

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
            //treeView1.ExpandAll();
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

        private void AddEffectTree(ToolStripMenuItem parent = null)
        {
            var itemlist = parent == null ? effectMenu.Items : parent.DropDownItems;
            itemlist.Add(new ToolStripSeparator());
        }

        private void AddEffectTree(Type type, ToolStripMenuItem parent = null)
        {
            var a = (AviutlEffect)type.GetConstructors()[0].Invoke(new object[] { });
            AddEffectTree(type, a.Name, parent);
        }

        private ToolStripMenuItem AddEffectTree(string name, ToolStripMenuItem parent = null)
        {
            var itemlist = parent == null ? effectMenu.Items : parent.DropDownItems;
            effectMenu_short.Items.Add(new ToolStripSeparator());
            return (ToolStripMenuItem)itemlist.Add(name);
        }

        private void AddEffectTree(Type type, string name, ToolStripMenuItem parent = null)
        {
            var itemlist = parent == null ? effectMenu.Items : parent.DropDownItems;
            var eff = (ToolStripMenuItem)itemlist.Add(name);
            var eff2 = (ToolStripMenuItem)effectMenu_short.Items.Add(name);
            eff.Click += (_, _) =>
            {
                AddEffect(tabList[tabControl1.SelectedTab], (AviutlEffect)type.GetConstructors()[0].Invoke(new object[] { }));
            };
            eff2.Click += (_, _) =>
            {
                AddEffect(tabList[tabControl1.SelectedTab], (AviutlEffect)type.GetConstructors()[0].Invoke(new object[] { }));
            };
        }

        private void AddEffectTreeAnimation(string name, ToolStripMenuItem parent = null)
        {
            var itemlist = parent == null ? effectMenu.Items : parent.DropDownItems;
            var eff = (ToolStripMenuItem)itemlist.Add(name);
            var eff2 = (ToolStripMenuItem)effectMenu_short.Items.Add(name);
            eff.Click += (_, _) =>
            {
                var animation = new EFAnimation();
                animation.SetAnimation(name);
                AddEffect(tabList[tabControl1.SelectedTab], animation);
            };
            eff2.Click += (_, _) =>
            {
                var animation = new EFAnimation();
                animation.SetAnimation(name);
                AddEffect(tabList[tabControl1.SelectedTab], animation);
            };
        }

        private void AddCustomObjectTree(string name, ToolStripMenuItem parent = null)
        {
            var itemlist = parent == null ? CustomObjectToolStripMenuItem.DropDownItems : parent.DropDownItems;
            var obj = (ToolStripMenuItem)itemlist.Add(name);
            obj.Click += (_, _) =>
            {
                var custom = new CustomObject();
                custom.SetCustomObject(name);


                AddObject(custom);
            };
        }

        private void AddNotAviutlObjectTree(Type t, ToolStripMenuItem parent = null)
        {
            var itemlist = parent == null ? notAviUtlobjectToolStripMenuItem.DropDownItems : parent.DropDownItems;
            var obj = (ToolStripMenuItem)itemlist.Add((string)t.GetProperty("Name").GetValue(t.GetConstructors()[0].Invoke(new object[0])));
            obj.Click += (_, _) =>
            {
                var custom = t.GetConstructors()[0].Invoke(new object[0]);

                AddObject((AviutlMediaObject)custom);
            };
        }

        public void AddObject(AviutlMediaObject obj)
        {
            obj.index = objects.Count;
            obj.mainwindow = this;
            objects.Add(obj);
            var tab = AddTab("[" + obj.index + "]" + obj.Name);
            tabList.Add(tab, obj);

            foreach (var item in obj.GetParams())
            {
                AddTrack(tab, item, obj);
            }

            var height = CalcHeight(tab);
            var btn = new Button();
            btn.Text = "エフェクトを追加";
            btn.Parent = tab;
            btn.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            btn.Location = new Point(3, height);
            btn.Width = tab.Width - 6;
            /*btn.Click += (_, _) =>
            {
                effectMenu.Show(btn.Parent, btn.Location);
            };*/
            btn.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    effectMenu_short.Show(btn.Parent, btn.Location.X + e.X, btn.Location.Y + e.Y);
                }
                else
                {
                    effectMenu.Show(btn.Parent, btn.Location.X + e.X, btn.Location.Y + e.Y);
                }
            };

            tab.AutoScroll = true;

            foreach (var item in obj.effects)
            {
                AddEffect(obj, item, true);
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

        public void AddEffect(AviutlMediaObject obj, AviutlEffect eff, bool onlyDisplay = false)
        {
            var tab = GetTab(obj);
            if (tab == null) return;
            var scrollvalue = tab.VerticalScroll.Value;
            tab.AutoScroll = false;
            var cont = new GroupBox();
            cont.Parent = tab;
            cont.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            cont.Width = tab.Width - 6;
            cont.Text = eff.Name;
            eff.groupbox = cont;
            eff.parent = obj;

            var btn = new Button();
            btn.Text = "削除";
            btn.Parent = cont;
            btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn.AutoSize = true;
            btn.Location = new Point(cont.Width - btn.Width - 3, 3);
            btn.Click += (_, _) =>
            {
                RemoveEffect(eff);
            };

            var btn2 = new Button();
            btn2.Text = "条件...";
            btn2.Parent = cont;
            btn2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn2.AutoSize = true;
            btn2.Location = new Point(cont.Width - btn.Width - btn2.Width - 6, 3);
            btn2.Click += (_, _) =>
            {
                var condwindow = new ConditionWindow(this, eff.condition);
                condwindow.ShowDialog();
            };

            foreach (var item in eff.GetParams())
            {
                AddTrack(cont, item, obj);
            }

            var height = CalcHeight(cont) + 6;

            cont.Height = height;

            height = CalcHeightStrictly(tab) + 9;

            cont.Location = new Point(3, height);

            tab.AutoScroll = true;

            tab.VerticalScroll.Value = scrollvalue;

            if (!onlyDisplay) obj.effects.Add(eff);
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
                    var textparam = (Param<string>)param;
                    var textText = new TextDecoratorTrackBar();
                    textText.TextValue = textparam.Value.initialValue;
                    textText.OnTextValueChanged += (a) =>
                    {
                        textparam.Value.sections[parambar.index].value = a;
                    };

                    textText.Height = 128;

                    parambar.Height = textText.Height;

                    parambar.SetPanel(textText);
                    break;
                case ParamType.Vector2:
                    var vec2param = (Param<Vector2>)param;
                    var vec2num = parambar.panelControl != null ? (Vector2TrackBar)parambar.panelControl : new Vector2TrackBar();
                    vec2num.Value = vec2param.Value.sections[index].value;
                    if (isnew) vec2num.OnValueChanged += (a) =>
                    {
                        vec2param.Value.sections[parambar.index].value = a;

                    };

                    if (isnew) parambar.Height = vec2num.Height;

                    parambar.SetPanel(vec2num);
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

        private int CalcHeight(Control tab)
        {
            var height = 3;
            foreach (var item in tab.Controls)
            {
                height += ((Control)item).Height;
            }
            return height;
        }

        public int CalcHeightStrictly(Panel tab)
        {
            var height = 0;
            foreach (var item in tab.Controls)
            {
                var cont = (Control)item;
                height = Math.Max(cont.Height + cont.Location.Y, height);
            }
            return height;
        }

        public Control CreateParamUI(object param)
        {
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

                    return num;
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

                    return floatnum;
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

                    return intnum;
                case ParamType.String:
                    var strparam = (Param<string>)param;
                    var strText = new TextBox();
                    strText.Text = strparam.Value.initialValue;
                    strText.TextChanged += (a, b) =>
                    {
                        strparam.Value.initialValue = strText.Text;
                    };

                    return strText;
                case ParamType.File:
                    var fileparam = (Param<string>)param;
                    var fileText = new PathTrackBar(this);
                    fileText.PathText = fileparam.Value.initialValue;
                    fileText.IsFolder = false;
                    fileText.OnValueChanged += (a) =>
                    {
                        fileparam.Value.initialValue = fileText.PathText;
                    };

                    return fileText;
                case ParamType.Folder:
                    var folderparam = (Param<string>)param;
                    var folderText = new PathTrackBar(this);
                    folderText.PathText = folderparam.Value.initialValue;
                    folderText.IsFolder = true;
                    folderText.OnValueChanged += (a) =>
                    {
                        folderparam.Value.initialValue = folderText.PathText;
                    };

                    return folderText;
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

                    return mlstrText;
                case ParamType.Font:
                    var fontparam = (Param<string>)param;
                    var fontText = new FontTrackBar();
                    fontText.FontName = fontparam.Value.initialValue;
                    fontText.OnValueChanged += (a) =>
                    {
                        fontparam.Value.initialValue = fontText.FontName;
                    };

                    return fontText;
                case ParamType.Color:
                    var colorparam = (Param<Params.Color>)param;
                    var colorTrack = new ColorTrackBar();
                    colorTrack.selectedColor = colorparam.Value.initialValue;
                    colorTrack.OnColorChanged += (a) =>
                    {
                        colorparam.Value.initialValue = colorTrack.selectedColor;
                    };

                    return colorTrack;
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

                    return comboBox;
                case ParamType.Boolean:
                    var boolparam = (Param<bool>)param;
                    var boolText = new CheckBox();
                    boolText.Checked = boolparam.Value.initialValue;
                    boolText.Text = boolparam.label;
                    boolText.CheckedChanged += (a, b) =>
                    {
                        boolparam.Value.initialValue = boolText.Checked;
                    };

                    return boolText;
                case ParamType.Text:
                    var textparam = (Param<string>)param;
                    var textText = new TextDecoratorTrackBar();
                    textText.TextValue = textparam.Value.initialValue;
                    textText.OnTextValueChanged += (a) =>
                    {
                        textparam.Value.initialValue = a;
                    };

                    textText.Height = 128;

                    return textText;
                case ParamType.Vector2:
                    var vec2param = (Param<Vector2>)param;
                    var vec2num = new Vector2TrackBar();
                    vec2num.Value = vec2param.Value.initialValue;
                    vec2num.OnValueChanged += (a) =>
                    {
                        ParamList.SetValue(param, a);
                    };

                    return vec2num;
                case ParamType.Vector3:
                    var vec3param = (Param<Vector3>)param;
                    var vec3num = new Vector3TrackBar();
                    vec3num.Value = vec3param.Value.initialValue;
                    vec3num.OnValueChanged += (a) =>
                    {
                        ParamList.SetValue(param, a);
                    };

                    return vec3num;
                case ParamType.Dialog:
                    break;
                case ParamType.Button:

                    break;
                default:
                    break;
            }
            return null;
        }

        public void AddTrack(Control tab, object param, AviutlMediaObject mediaobject)
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
                track.SetHasTransition(ParamList.GetProperty<int>(ParamList.GetField<object>(ParamList.GetProperty<object>(param, "Value"), "sections"), "Count") != 0);
            };
            track.DisableTransion = ParamList.GetField<bool>(param, "DisableTransion");

            var panel = CreateParamUI(param);
            track.Height = panel is ComboBox ? panel.Height + 6 : panel.Height;
            track.SetPanel(panel);
            track.SetHasTransition(ParamList.GetProperty<int>(ParamList.GetField<object>(ParamList.GetProperty<object>(param, "Value"), "sections"), "Count") != 0);
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

        public void RemoveEffect(AviutlEffect eff)
        {
            if (eff == null) return;
            var obj = eff.parent;
            if (obj == null) return;
            obj.effects.Remove(eff);
            eff.groupbox.Parent = null;
            eff.groupbox.Dispose();

            foreach (var item in obj.effects)
            {
                item.groupbox.Parent = null;
            }

            var tab = GetTab(obj);
            foreach (var item in obj.effects)
            {
                var height = CalcHeightStrictly(tab) + 9;
                item.groupbox.Parent = tab;
                item.groupbox.Location = new Point(3, height);
            }
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
            toolStripMenuItem1.Enabled = obj.Parent != null;
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
            if (obj.index >= obj.ParentList.Count - 1) return;
            var target = obj.ParentList[obj.index + 1];
            target.index--;
            obj.index++;
            UpdateTree();
            GetTab(target).Text = "[" + target.index + "]" + target.Name;
            GetTab(obj).Text = "[" + obj.index + "]" + obj.Name;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node == null) return;
            ChangeParent(node, null);
        }

        private void フレームバッファToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddObject(new FrameBufferObject());
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingDialog(this).ShowDialog();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.AviutlPath = AviUtlPath;
            Properties.Settings.Default.AquesTalkPlayerPath = AquesTalkPlayerPath;
            Properties.Settings.Default.Save();
        }

        private void Help_Version_Click(object sender, EventArgs e)
        {

        }
    }
}
