namespace ParamTriplePlus
{
    partial class TextDecoratorTrackBar
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            codeTab = new TabPage();
            sourceTextBox = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            サイズフォント設定ToolStripMenuItem = new ToolStripMenuItem();
            色ToolStripMenuItem = new ToolStripMenuItem();
            座標ずらしToolStripMenuItem = new ToolStripMenuItem();
            スクリプトToolStripMenuItem = new ToolStripMenuItem();
            previewTab = new TabPage();
            previewBox = new RichTextBox();
            tabControl1.SuspendLayout();
            codeTab.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            previewTab.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(codeTab);
            tabControl1.Controls.Add(previewTab);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(357, 157);
            tabControl1.TabIndex = 1;
            // 
            // codeTab
            // 
            codeTab.BackColor = SystemColors.Control;
            codeTab.Controls.Add(sourceTextBox);
            codeTab.Location = new Point(4, 24);
            codeTab.Name = "codeTab";
            codeTab.Padding = new Padding(3);
            codeTab.Size = new Size(349, 129);
            codeTab.TabIndex = 0;
            codeTab.Text = "ソース表記";
            // 
            // sourceTextBox
            // 
            sourceTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sourceTextBox.ContextMenuStrip = contextMenuStrip1;
            sourceTextBox.Location = new Point(6, 6);
            sourceTextBox.Multiline = true;
            sourceTextBox.Name = "sourceTextBox";
            sourceTextBox.Size = new Size(340, 117);
            sourceTextBox.TabIndex = 0;
            sourceTextBox.TextChanged += sourceTextBox_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { サイズフォント設定ToolStripMenuItem, 色ToolStripMenuItem, 座標ずらしToolStripMenuItem, スクリプトToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(166, 92);
            // 
            // サイズフォント設定ToolStripMenuItem
            // 
            サイズフォント設定ToolStripMenuItem.Name = "サイズフォント設定ToolStripMenuItem";
            サイズフォント設定ToolStripMenuItem.Size = new Size(165, 22);
            サイズフォント設定ToolStripMenuItem.Text = "サイズ・フォント設定";
            // 
            // 色ToolStripMenuItem
            // 
            色ToolStripMenuItem.Name = "色ToolStripMenuItem";
            色ToolStripMenuItem.Size = new Size(165, 22);
            色ToolStripMenuItem.Text = "色";
            // 
            // 座標ずらしToolStripMenuItem
            // 
            座標ずらしToolStripMenuItem.Name = "座標ずらしToolStripMenuItem";
            座標ずらしToolStripMenuItem.Size = new Size(165, 22);
            座標ずらしToolStripMenuItem.Text = "座標ずらし";
            // 
            // スクリプトToolStripMenuItem
            // 
            スクリプトToolStripMenuItem.Name = "スクリプトToolStripMenuItem";
            スクリプトToolStripMenuItem.Size = new Size(165, 22);
            スクリプトToolStripMenuItem.Text = "スクリプト";
            // 
            // previewTab
            // 
            previewTab.BackColor = SystemColors.Control;
            previewTab.Controls.Add(previewBox);
            previewTab.Location = new Point(4, 24);
            previewTab.Name = "previewTab";
            previewTab.Padding = new Padding(3);
            previewTab.Size = new Size(349, 129);
            previewTab.TabIndex = 1;
            previewTab.Text = "プレビュー";
            // 
            // previewBox
            // 
            previewBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            previewBox.Location = new Point(6, 6);
            previewBox.Name = "previewBox";
            previewBox.ReadOnly = true;
            previewBox.Size = new Size(337, 117);
            previewBox.TabIndex = 0;
            previewBox.Text = "";
            // 
            // TextDecoratorTrackBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "TextDecoratorTrackBar";
            Size = new Size(360, 160);
            tabControl1.ResumeLayout(false);
            codeTab.ResumeLayout(false);
            codeTab.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            previewTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage codeTab;
        private TextBox sourceTextBox;
        private TabPage previewTab;
        private RichTextBox previewBox;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem サイズフォント設定ToolStripMenuItem;
        private ToolStripMenuItem 色ToolStripMenuItem;
        private ToolStripMenuItem 座標ずらしToolStripMenuItem;
        private ToolStripMenuItem スクリプトToolStripMenuItem;
    }
}
