namespace ParamTriplePlus.ExoGenerator
{
    partial class ExoSettingDialog
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
            panel1 = new Panel();
            pathTrackBar1 = new PathTrackBar();
            addButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            SaveButton = new Button();
            SaveAsButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pathTrackBar1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 413);
            panel1.TabIndex = 0;
            // 
            // pathTrackBar1
            // 
            pathTrackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pathTrackBar1.Location = new Point(3, 3);
            pathTrackBar1.Name = "pathTrackBar1";
            pathTrackBar1.PathText = "";
            pathTrackBar1.Size = new Size(786, 64);
            pathTrackBar1.TabIndex = 0;
            pathTrackBar1.OnValueChanged += pathTrackBar1_OnValueChanged;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addButton.Location = new Point(3, 422);
            addButton.Name = "addButton";
            addButton.Size = new Size(382, 23);
            addButton.TabIndex = 0;
            addButton.Text = "追加";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.Location = new Point(713, 422);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "保存";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // SaveAsButton
            // 
            SaveAsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveAsButton.Location = new Point(603, 422);
            SaveAsButton.Name = "SaveAsButton";
            SaveAsButton.Size = new Size(104, 23);
            SaveAsButton.TabIndex = 2;
            SaveAsButton.Text = "名前をつけて保存";
            SaveAsButton.UseVisualStyleBackColor = true;
            SaveAsButton.Click += SaveAsButton_Click;
            // 
            // ExoSettingDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SaveAsButton);
            Controls.Add(SaveButton);
            Controls.Add(addButton);
            Controls.Add(panel1);
            Name = "ExoSettingDialog";
            Text = "ExoSettingDialog";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button addButton;
        private ContextMenuStrip contextMenuStrip1;
        private Button SaveButton;
        private Button SaveAsButton;
        private PathTrackBar pathTrackBar1;
    }
}