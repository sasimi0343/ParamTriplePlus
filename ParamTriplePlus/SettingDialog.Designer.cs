namespace ParamTriplePlus
{
    partial class SettingDialog
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
            label1 = new Label();
            pathTrackBar1 = new PathTrackBar();
            label2 = new Label();
            pathTrackBar2 = new PathTrackBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "AviUtlのパス";
            // 
            // pathTrackBar1
            // 
            pathTrackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pathTrackBar1.Location = new Point(139, 9);
            pathTrackBar1.Name = "pathTrackBar1";
            pathTrackBar1.PathText = "";
            pathTrackBar1.Size = new Size(649, 64);
            pathTrackBar1.TabIndex = 1;
            pathTrackBar1.OnValueChanged += pathTrackBar1_OnValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 2;
            label2.Text = "AquesTalkPlayerのパス";
            // 
            // pathTrackBar2
            // 
            pathTrackBar2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pathTrackBar2.Location = new Point(139, 77);
            pathTrackBar2.Name = "pathTrackBar2";
            pathTrackBar2.PathText = "";
            pathTrackBar2.Size = new Size(649, 64);
            pathTrackBar2.TabIndex = 3;
            pathTrackBar2.OnValueChanged += pathTrackBar2_OnValueChanged;
            // 
            // SettingDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pathTrackBar2);
            Controls.Add(label2);
            Controls.Add(pathTrackBar1);
            Controls.Add(label1);
            Name = "SettingDialog";
            Text = "SettingDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PathTrackBar pathTrackBar1;
        private Label label2;
        private PathTrackBar pathTrackBar2;
    }
}