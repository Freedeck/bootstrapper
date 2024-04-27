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
            richTextBox1.Text += "Welcome to the installer!";
        }

        private void Wc_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                ZipFile.ExtractToDirectory(folder + "\\fdtemp.zip", folder + "\\fdt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error while trying to extract: " + ex);
            }
            System.Diagnostics.Process.Start(folder + "\\fdt\\installer-win32-x64\\installer.exe");
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

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "Initializing install";
            richTextBox1.Text += "Checking for git..";
            if (!Directory.Exists("C:\\Program Files\\Git\\bin"))
            {
                richTextBox1.Text += "Couldn't find git; opening bootstrapper!";
                GitBootstrap bs = new GitBootstrap();
                bs.ShowDialog();
            }
            WebClient wc = new WebClient();
            wc.DownloadFileTaskAsync("https://freedeck.app/installer.zip", folder + "\\fdtemp.zip");
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
        }
    }
}
