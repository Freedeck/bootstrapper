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
    public partial class HandoffBootstrap : Form
    {
        public HandoffBootstrap()
        {
            InitializeComponent();
        }
        String folder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private void HandoffBootstrap_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadFileTaskAsync("https://github.com/Freedeck/handoff/releases/latest/download/handoff.exe", folder+"\\Freedeck\\handoff.exe");
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
        }

        private void Wc_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            label2.Text = "Setting up Handoff, please allow admin!";
            Process proc = new Process();
            proc.StartInfo.FileName = folder + "\\Freedeck\\handoff.exe";
            proc.StartInfo.Arguments = "--setup";
            proc.EnableRaisingEvents = true;
            proc.Exited += Proc_Exited;
            proc.Start();
        }

        private void Proc_Exited(object? sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.Close();
            });
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
