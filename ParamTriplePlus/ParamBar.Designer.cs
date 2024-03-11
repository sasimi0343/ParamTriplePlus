namespace ParamTriplePlus
{
    partial class ParamBar
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
            label1 = new Label();
            transionButton = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // transionButton
            // 
            transionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            transionButton.Location = new Point(729, 3);
            transionButton.Name = "transionButton";
            transionButton.Size = new Size(43, 23);
            transionButton.TabIndex = 1;
            transionButton.Text = "遷移";
            transionButton.UseVisualStyleBackColor = true;
            transionButton.Click += transionButton_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(133, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(590, 26);
            panel1.TabIndex = 2;
            // 
            // ParamBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(transionButton);
            Controls.Add(label1);
            Name = "ParamBar";
            Size = new Size(775, 32);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button transionButton;
        private Panel panel1;
    }
}
