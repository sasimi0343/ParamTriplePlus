namespace ParamTriplePlus
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TreeNode treeNode2 = new TreeNode("Draw");
            menuStrip1 = new MenuStrip();
            Menu_Files = new ToolStripMenuItem();
            Files_NewObjectFile = new ToolStripMenuItem();
            Files_Open = new ToolStripMenuItem();
            Files_Save = new ToolStripMenuItem();
            Menu_Help = new ToolStripMenuItem();
            Help_Version = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            mainTab = new TabPage();
            AddObjectButton = new Button();
            treeView1 = new TreeView();
            addObjectContext = new ContextMenuStrip(components);
            動画ToolStripMenuItem = new ToolStripMenuItem();
            画像ToolStripMenuItem = new ToolStripMenuItem();
            図形ToolStripMenuItem = new ToolStripMenuItem();
            テキストToolStripMenuItem = new ToolStripMenuItem();
            フレームバッファToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            nodeTreeContext = new ContextMenuStrip(components);
            コピーToolStripMenuItem = new ToolStripMenuItem();
            切り取りToolStripMenuItem = new ToolStripMenuItem();
            貼りつけToolStripMenuItem = new ToolStripMenuItem();
            ndc_remove = new ToolStripMenuItem();
            名前の変更ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            グループに移動ToolStripMenuItem = new ToolStripMenuItem();
            新規グループToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            上に移動ToolStripMenuItem = new ToolStripMenuItem();
            下に移動ToolStripMenuItem = new ToolStripMenuItem();
            effectMenu = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            mainTab.SuspendLayout();
            addObjectContext.SuspendLayout();
            nodeTreeContext.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { Menu_Files, Menu_Help });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Menu_Files
            // 
            Menu_Files.DropDownItems.AddRange(new ToolStripItem[] { Files_NewObjectFile, Files_Open, Files_Save });
            Menu_Files.Name = "Menu_Files";
            Menu_Files.Size = new Size(53, 20);
            Menu_Files.Text = "ファイル";
            // 
            // Files_NewObjectFile
            // 
            Files_NewObjectFile.Name = "Files_NewObjectFile";
            Files_NewObjectFile.Size = new Size(184, 22);
            Files_NewObjectFile.Text = "新規オブジェクトファイル";
            // 
            // Files_Open
            // 
            Files_Open.Name = "Files_Open";
            Files_Open.Size = new Size(184, 22);
            Files_Open.Text = "開く";
            Files_Open.Click += Files_Open_Click;
            // 
            // Files_Save
            // 
            Files_Save.Name = "Files_Save";
            Files_Save.Size = new Size(184, 22);
            Files_Save.Text = "保存";
            Files_Save.Click += Files_Save_Click;
            // 
            // Menu_Help
            // 
            Menu_Help.DropDownItems.AddRange(new ToolStripItem[] { Help_Version });
            Menu_Help.Name = "Menu_Help";
            Menu_Help.Size = new Size(48, 20);
            Menu_Help.Text = "ヘルプ";
            // 
            // Help_Version
            // 
            Help_Version.Name = "Help_Version";
            Help_Version.Size = new Size(142, 22);
            Help_Version.Text = "バージョン情報";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(mainTab);
            tabControl1.Location = new Point(0, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 421);
            tabControl1.TabIndex = 1;
            // 
            // mainTab
            // 
            mainTab.Controls.Add(AddObjectButton);
            mainTab.Controls.Add(treeView1);
            mainTab.Location = new Point(4, 24);
            mainTab.Name = "mainTab";
            mainTab.Padding = new Padding(3);
            mainTab.Size = new Size(792, 393);
            mainTab.TabIndex = 0;
            mainTab.Text = "基本設定";
            mainTab.UseVisualStyleBackColor = true;
            // 
            // AddObjectButton
            // 
            AddObjectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddObjectButton.Location = new Point(612, 6);
            AddObjectButton.Name = "AddObjectButton";
            AddObjectButton.Size = new Size(172, 23);
            AddObjectButton.TabIndex = 1;
            AddObjectButton.Text = "オブジェクトを追加";
            AddObjectButton.UseVisualStyleBackColor = true;
            AddObjectButton.Click += AddObjectButton_Click;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView1.Location = new Point(3, 6);
            treeView1.Name = "treeView1";
            treeNode2.Name = "Root";
            treeNode2.Text = "Draw";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode2 });
            treeView1.Size = new Size(603, 384);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;
            treeView1.DragDrop += treeView1_DragDrop;
            // 
            // addObjectContext
            // 
            addObjectContext.Items.AddRange(new ToolStripItem[] { 動画ToolStripMenuItem, 画像ToolStripMenuItem, 図形ToolStripMenuItem, テキストToolStripMenuItem, フレームバッファToolStripMenuItem });
            addObjectContext.Name = "addObjectContext";
            addObjectContext.Size = new Size(142, 114);
            // 
            // 動画ToolStripMenuItem
            // 
            動画ToolStripMenuItem.Name = "動画ToolStripMenuItem";
            動画ToolStripMenuItem.Size = new Size(141, 22);
            動画ToolStripMenuItem.Text = "動画";
            動画ToolStripMenuItem.Click += 動画ToolStripMenuItem_Click;
            // 
            // 画像ToolStripMenuItem
            // 
            画像ToolStripMenuItem.Name = "画像ToolStripMenuItem";
            画像ToolStripMenuItem.Size = new Size(141, 22);
            画像ToolStripMenuItem.Text = "画像";
            画像ToolStripMenuItem.Click += 画像ToolStripMenuItem_Click;
            // 
            // 図形ToolStripMenuItem
            // 
            図形ToolStripMenuItem.Name = "図形ToolStripMenuItem";
            図形ToolStripMenuItem.Size = new Size(141, 22);
            図形ToolStripMenuItem.Text = "図形";
            図形ToolStripMenuItem.Click += 図形ToolStripMenuItem_Click;
            // 
            // テキストToolStripMenuItem
            // 
            テキストToolStripMenuItem.Name = "テキストToolStripMenuItem";
            テキストToolStripMenuItem.Size = new Size(141, 22);
            テキストToolStripMenuItem.Text = "テキスト";
            テキストToolStripMenuItem.Click += テキストToolStripMenuItem_Click;
            // 
            // フレームバッファToolStripMenuItem
            // 
            フレームバッファToolStripMenuItem.Name = "フレームバッファToolStripMenuItem";
            フレームバッファToolStripMenuItem.Size = new Size(141, 22);
            フレームバッファToolStripMenuItem.Text = "フレームバッファ";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "aulptp";
            saveFileDialog1.Filter = "AviUtl用パラメータファイル|*.aulptp";
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "aulptp";
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "AviUtl用パラメータファイル|*.aulptp";
            // 
            // nodeTreeContext
            // 
            nodeTreeContext.Items.AddRange(new ToolStripItem[] { コピーToolStripMenuItem, 切り取りToolStripMenuItem, 貼りつけToolStripMenuItem, ndc_remove, 名前の変更ToolStripMenuItem, toolStripSeparator1, グループに移動ToolStripMenuItem, 上に移動ToolStripMenuItem, 下に移動ToolStripMenuItem });
            nodeTreeContext.Name = "nodeTreeContext";
            nodeTreeContext.Size = new Size(181, 208);
            // 
            // コピーToolStripMenuItem
            // 
            コピーToolStripMenuItem.Name = "コピーToolStripMenuItem";
            コピーToolStripMenuItem.Size = new Size(180, 22);
            コピーToolStripMenuItem.Text = "コピー";
            // 
            // 切り取りToolStripMenuItem
            // 
            切り取りToolStripMenuItem.Name = "切り取りToolStripMenuItem";
            切り取りToolStripMenuItem.Size = new Size(180, 22);
            切り取りToolStripMenuItem.Text = "切り取り";
            // 
            // 貼りつけToolStripMenuItem
            // 
            貼りつけToolStripMenuItem.Name = "貼りつけToolStripMenuItem";
            貼りつけToolStripMenuItem.Size = new Size(180, 22);
            貼りつけToolStripMenuItem.Text = "貼りつけ";
            // 
            // ndc_remove
            // 
            ndc_remove.Name = "ndc_remove";
            ndc_remove.Size = new Size(180, 22);
            ndc_remove.Text = "削除";
            ndc_remove.Click += ndc_remove_Click;
            // 
            // 名前の変更ToolStripMenuItem
            // 
            名前の変更ToolStripMenuItem.Name = "名前の変更ToolStripMenuItem";
            名前の変更ToolStripMenuItem.Size = new Size(180, 22);
            名前の変更ToolStripMenuItem.Text = "名前の変更";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // グループに移動ToolStripMenuItem
            // 
            グループに移動ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 新規グループToolStripMenuItem, toolStripSeparator2, toolStripMenuItem1 });
            グループに移動ToolStripMenuItem.Name = "グループに移動ToolStripMenuItem";
            グループに移動ToolStripMenuItem.Size = new Size(180, 22);
            グループに移動ToolStripMenuItem.Text = "グループに移動";
            // 
            // 新規グループToolStripMenuItem
            // 
            新規グループToolStripMenuItem.Name = "新規グループToolStripMenuItem";
            新規グループToolStripMenuItem.Size = new Size(180, 22);
            新規グループToolStripMenuItem.Text = "新規グループ";
            新規グループToolStripMenuItem.Click += 新規グループToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // 上に移動ToolStripMenuItem
            // 
            上に移動ToolStripMenuItem.Name = "上に移動ToolStripMenuItem";
            上に移動ToolStripMenuItem.Size = new Size(180, 22);
            上に移動ToolStripMenuItem.Text = "上に移動";
            上に移動ToolStripMenuItem.Click += 上に移動ToolStripMenuItem_Click;
            // 
            // 下に移動ToolStripMenuItem
            // 
            下に移動ToolStripMenuItem.Name = "下に移動ToolStripMenuItem";
            下に移動ToolStripMenuItem.Size = new Size(180, 22);
            下に移動ToolStripMenuItem.Text = "下に移動";
            下に移動ToolStripMenuItem.Click += 下に移動ToolStripMenuItem_Click;
            // 
            // effectMenu
            // 
            effectMenu.Name = "effectMenu";
            effectMenu.Size = new Size(61, 4);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Enabled = false;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "ルート";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "ParamTriplePlus";
            KeyDown += MainWindow_KeyDown;
            PreviewKeyDown += MainWindow_PreviewKeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            mainTab.ResumeLayout(false);
            addObjectContext.ResumeLayout(false);
            nodeTreeContext.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem Menu_Files;
        private ToolStripMenuItem Files_NewObjectFile;
        private ToolStripMenuItem Menu_Help;
        private ToolStripMenuItem Help_Version;
        private TabControl tabControl1;
        private TabPage mainTab;
        private TreeView treeView1;
        private Button AddObjectButton;
        private ContextMenuStrip addObjectContext;
        private ToolStripMenuItem 動画ToolStripMenuItem;
        private ToolStripMenuItem 画像ToolStripMenuItem;
        private ToolStripMenuItem 図形ToolStripMenuItem;
        private ToolStripMenuItem フレームバッファToolStripMenuItem;
        private ToolStripMenuItem テキストToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem Files_Save;
        private ToolStripMenuItem Files_Open;
        private OpenFileDialog openFileDialog1;
        private ContextMenuStrip nodeTreeContext;
        private ToolStripMenuItem コピーToolStripMenuItem;
        private ToolStripMenuItem 切り取りToolStripMenuItem;
        private ToolStripMenuItem 貼りつけToolStripMenuItem;
        private ToolStripMenuItem ndc_remove;
        private ToolStripMenuItem 名前の変更ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem グループに移動ToolStripMenuItem;
        private ToolStripMenuItem 新規グループToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem 上に移動ToolStripMenuItem;
        private ToolStripMenuItem 下に移動ToolStripMenuItem;
        private ContextMenuStrip effectMenu;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}
