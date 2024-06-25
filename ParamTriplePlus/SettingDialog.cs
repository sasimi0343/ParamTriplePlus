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
    public partial class SettingDialog : Form
    {
        public SettingDialog(MainWindow mainw)
        {
            InitializeComponent();
            pathTrackBar1.SetMainWindow(mainw);
            pathTrackBar1.IsFolder = true;
            pathTrackBar1.PathText = mainw.AviUtlPath;
            pathTrackBar2.SetMainWindow(mainw);
            pathTrackBar2.PathText = mainw.AquesTalkPlayerPath;
            mainWindow = mainw;
            isInitialized = true;
        }

        private bool isInitialized = false;
        private MainWindow mainWindow;

        private void pathTrackBar1_OnValueChanged(string path)
        {
            if (isInitialized) mainWindow.AviUtlPath = path;
        }

        private void pathTrackBar2_OnValueChanged(string path)
        {
            if (isInitialized) mainWindow.AquesTalkPlayerPath = path;
        }
    }
}
