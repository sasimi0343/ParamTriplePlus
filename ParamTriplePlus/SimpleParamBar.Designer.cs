namespace ParamTriplePlus
{
    partial class SimpleParamBar
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
            panel1 = new Panel();
            transionButton = new Button();
            transion_number = new ContextMenuStrip(components);
            transion_string = new ContextMenuStrip(components);
            transion_any = new ContextMenuStrip(components);
            trackBar1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(208, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(484, 26);
            panel1.TabIndex = 3;
            // 
            // transionButton
            // 
            transionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            transionButton.Location = new Point(698, 3);
            transionButton.Name = "transionButton";
            transionButton.Size = new Size(74, 23);
            transionButton.TabIndex = 2;
            transionButton.Text = "直線";
            transionButton.UseVisualStyleBackColor = true;
            transionButton.Click += transionButton_Click;
            // 
            // transion_number
            // 
            transion_number.Name = "transion_number";
            transion_number.Size = new Size(61, 4);
            // 
            // transion_string
            // 
            transion_string.Name = "transion_string";
            transion_string.Size = new Size(61, 4);
            // 
            // transion_any
            // 
            transion_any.Name = "transion_any";
            transion_any.Size = new Size(61, 4);
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            trackBar1.AutoSize = false;
            trackBar1.Location = new Point(0, 0);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(202, 32);
            trackBar1.TabIndex = 4;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            trackBar1.MouseDown += trackBar1_MouseDown;
            trackBar1.MouseUp += trackBar1_MouseUp;
            // 
            // SimpleParamBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(trackBar1);
            Controls.Add(transionButton);
            Controls.Add(panel1);
            Name = "SimpleParamBar";
            Size = new Size(775, 32);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button transionButton;
        private ContextMenuStrip transion_number;
        private ContextMenuStrip transion_string;
        private ContextMenuStrip transion_any;
        public TrackBar trackBar1;
    }
}
