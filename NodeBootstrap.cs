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
    public partial class NodeBootstrap : Form
    {
        public NodeBootstrap()
        {
            InitializeComponent();
        }
        String folder = System.Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

        private void NodeBootstrap_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadFileTaskAsync("https://nodejs.org/dist/v20.15.0/node-v20.15.0-x64.msi", folder+ "\\node-installer.msi");
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
        }

        private void Wc_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            label2.Text = "Please follow the Node.js installer's instructions!";
            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = folder;
            proc.StartInfo.FileName = folder + "\\node-installer.msi";
            proc.EnableRaisingEvents = true;
            proc.Exited += Proc_Exited;
            proc.Start();
        }

        private void Proc_Exited(object? sender, EventArgs e)
        {
            Console.WriteLine("Node probably installed");
            this.Invoke((MethodInvoker)delegate
            {
                // close the form on the forms thread
                this.Close();
            });
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
