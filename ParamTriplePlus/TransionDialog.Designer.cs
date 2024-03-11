namespace ParamTriplePlus
{
    partial class TransionDialog
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
            addButton = new Button();
            listpanel = new Panel();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            addButton.Location = new Point(3, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(555, 23);
            addButton.TabIndex = 0;
            addButton.Text = "追加";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // listpanel
            // 
            listpanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listpanel.AutoScroll = true;
            listpanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            listpanel.Location = new Point(3, 32);
            listpanel.Name = "listpanel";
            listpanel.Size = new Size(555, 414);
            listpanel.TabIndex = 1;
            // 
            // TransionDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 450);
            Controls.Add(listpanel);
            Controls.Add(addButton);
            Name = "TransionDialog";
            Text = "TransionDialog";
            ResumeLayout(false);
        }

        #endregion

        private Button addButton;
        private Panel listpanel;
    }
}