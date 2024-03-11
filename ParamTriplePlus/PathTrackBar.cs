using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParamTriplePlus
{
    public partial class PathTrackBar : UserControl
    {
        public PathTrackBar(MainWindow mainwindow)
        {
            InitializeComponent();
            this.mainWindow = mainwindow;
        }

        private MainWindow mainWindow;

        public delegate void ValueChangeEvent(string path);
        public event ValueChangeEvent OnValueChanged;
        public bool IsFolder;
        public string PathText { get => textBox1.Text; set => textBox1.Text = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsFolder)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) return;
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            }
            textBox1.Text = IsFolder ? folderBrowserDialog1.SelectedPath : openFileDialog1.FileName;
            CheckUpdate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        public void CheckUpdate()
        {
            var path = textBox1.Text;
            var ptppath = Path.GetDirectoryName(mainWindow.CurrentPath);
            var rela = CheckRelativePath(path, ptppath);
            if (rela == ptppath)
            {
                textBox2.Text = Path.GetRelativePath(ptppath, path);
            }
            else
            {
                textBox2.Text = "";
            }
            if (OnValueChanged != null) OnValueChanged.Invoke(textBox1.Text);
        }

        private string CheckRelativePath(string a, string b)
        {
            return string.IsNullOrEmpty(a) ? "" : (a == b ? b : CheckRelativePath(Path.GetDirectoryName(a), b));
        }
    }
}
