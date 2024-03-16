namespace ParamTriplePlus
{
    partial class ConditionWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            panel1 = new Panel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            オブジェクトToolStripMenuItem = new ToolStripMenuItem();
            インディックス単一ToolStripMenuItem = new ToolStripMenuItem();
            インディックス範囲ToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(776, 23);
            button1.TabIndex = 0;
            button1.Text = "条件を追加";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Location = new Point(7, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 406);
            panel1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { オブジェクトToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(127, 26);
            // 
            // オブジェクトToolStripMenuItem
            // 
            オブジェクトToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { インディックス単一ToolStripMenuItem, インディックス範囲ToolStripMenuItem });
            オブジェクトToolStripMenuItem.Name = "オブジェクトToolStripMenuItem";
            オブジェクトToolStripMenuItem.Size = new Size(126, 22);
            オブジェクトToolStripMenuItem.Text = "オブジェクト";
            // 
            // インディックス単一ToolStripMenuItem
            // 
            インディックス単一ToolStripMenuItem.Name = "インディックス単一ToolStripMenuItem";
            インディックス単一ToolStripMenuItem.Size = new Size(180, 22);
            インディックス単一ToolStripMenuItem.Text = "インディックス (単一)";
            インディックス単一ToolStripMenuItem.Click += インディックス単一ToolStripMenuItem_Click;
            // 
            // インディックス範囲ToolStripMenuItem
            // 
            インディックス範囲ToolStripMenuItem.Name = "インディックス範囲ToolStripMenuItem";
            インディックス範囲ToolStripMenuItem.Size = new Size(180, 22);
            インディックス範囲ToolStripMenuItem.Text = "インディックス (範囲)";
            インディックス範囲ToolStripMenuItem.Click += インディックス範囲ToolStripMenuItem_Click;
            // 
            // ConditionWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(button1);
            Name = "ConditionWindow";
            Text = "ParamTriplePlus - Condition";
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem オブジェクトToolStripMenuItem;
        private ToolStripMenuItem インディックス単一ToolStripMenuItem;
        private ToolStripMenuItem インディックス範囲ToolStripMenuItem;
    }
}