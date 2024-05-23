using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreedeckLauncher
{
    public partial class LauncherBootstrap : Form
    {
        public LauncherBootstrap()
        {
            InitializeComponent();
        }
        String folder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private void LauncherBootstrap_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadFileTaskAsync("https://github.com/Freedeck/launcher/releases/latest/download/Freedeck.Launcher.exe", folder+"\\Freedeck\\launcher.exe");
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
        }
        
        private void Wc_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            this.Close();
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
