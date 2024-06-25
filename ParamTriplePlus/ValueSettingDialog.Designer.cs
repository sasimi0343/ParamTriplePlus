namespace ParamTriplePlus
{
    partial class ValueSettingDialog
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
            numberBar = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numberBar).BeginInit();
            SuspendLayout();
            // 
            // numberBar
            // 
            numberBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numberBar.Location = new Point(3, 3);
            numberBar.Name = "numberBar";
            numberBar.Size = new Size(186, 23);
            numberBar.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(3, 35);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "キャンセル";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(114, 35);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ValueSettingDialog
            // 
            AcceptButton = button2;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button1;
            ClientSize = new Size(191, 65);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(numberBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ValueSettingDialog";
            Text = "値を設定";
            ((System.ComponentModel.ISupportInitialize)numberBar).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        public NumericUpDown numberBar;
    }
}