namespace ParamTriplePlus.ExoGenerator
{
    partial class ExoGenerator
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
            dragButton = new Button();
            panel1 = new Panel();
            label1 = new Label();
            length = new CustomizedTrackBar();
            comboBox1 = new ComboBox();
            editExoButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dragButton
            // 
            dragButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dragButton.Location = new Point(647, 405);
            dragButton.Name = "dragButton";
            dragButton.Size = new Size(150, 43);
            dragButton.TabIndex = 0;
            dragButton.Text = "ここをドラッグ&&ドロップして\r\nExoファイルを作成";
            dragButton.UseVisualStyleBackColor = true;
            dragButton.Click += dragButton_Click;
            dragButton.MouseMove += dragButton_MouseMove;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(length);
            panel1.Location = new Point(3, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 394);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 6);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 1;
            label1.Text = "オブジェクトの長さ";
            // 
            // length
            // 
            length.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            length.IsInt = true;
            length.Location = new Point(192, 6);
            length.Maximum = 100F;
            length.Minimum = 0F;
            length.Name = "length";
            length.NumRangeOut = true;
            length.Size = new Size(592, 32);
            length.TabIndex = 0;
            length.Value = 30F;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.ItemHeight = 15;
            comboBox1.Location = new Point(12, 415);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(394, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // editExoButton
            // 
            editExoButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            editExoButton.Location = new Point(412, 415);
            editExoButton.Name = "editExoButton";
            editExoButton.Size = new Size(75, 23);
            editExoButton.TabIndex = 3;
            editExoButton.Text = "編集";
            editExoButton.UseVisualStyleBackColor = true;
            // 
            // ExoGenerator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(editExoButton);
            Controls.Add(comboBox1);
            Controls.Add(panel1);
            Controls.Add(dragButton);
            Name = "ExoGenerator";
            Text = "ExoGenerator";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button dragButton;
        private Panel panel1;
        private ComboBox comboBox1;
        private Button editExoButton;
        private CustomizedTrackBar length;
        private Label label1;
    }
}