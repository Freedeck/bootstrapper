using System.IO.Compression;
using System.Net;

namespace FreedeckLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

String folder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadFileTaskAsync("https://github.com/freedeck/installer/releases/", folder+"\\fdtemp.zip");
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
        }

        private void Wc_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ZipFile.ExtractToDirectory(folder + "\\fdtemp.zip", folder+"\\fdt");
            System.Diagnostics.Process.Start(folder+"\\fdt\\installer.exe");
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Form1_Ready(object? sender, EventArgs e)
        {
            //this.Hide();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
