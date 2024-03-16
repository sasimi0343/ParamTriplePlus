namespace ParamTriplePlus
{
    partial class Vector2TrackBar
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
            xtrackbar = new CustomizedTrackBar();
            yTrackBar = new CustomizedTrackBar();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // xtrackbar
            // 
            xtrackbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            xtrackbar.Location = new Point(58, 0);
            xtrackbar.Maximum = 2000F;
            xtrackbar.Minimum = -2000F;
            xtrackbar.Name = "xtrackbar";
            xtrackbar.NumRangeOut = true;
            xtrackbar.Size = new Size(777, 32);
            xtrackbar.TabIndex = 0;
            xtrackbar.Value = 0F;
            xtrackbar.OnValueChanged += xtrackbar_OnValueChanged;
            // 
            // yTrackBar
            // 
            yTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            yTrackBar.Location = new Point(58, 32);
            yTrackBar.Maximum = 2000F;
            yTrackBar.Minimum = -2000F;
            yTrackBar.Name = "yTrackBar";
            yTrackBar.NumRangeOut = true;
            yTrackBar.Size = new Size(777, 32);
            yTrackBar.TabIndex = 1;
            yTrackBar.Value = 0F;
            yTrackBar.OnValueChanged += yTrackBar_OnValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 8);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 3;
            label1.Text = "X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 40);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 4;
            label2.Text = "Y";
            // 
            // Vector2TrackBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(yTrackBar);
            Controls.Add(xtrackbar);
            Name = "Vector2TrackBar";
            Size = new Size(835, 64);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomizedTrackBar xtrackbar;
        private CustomizedTrackBar yTrackBar;
        private Label label1;
        private Label label2;
    }
}
