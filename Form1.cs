using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using IWshRuntimeLibrary;

namespace FreedeckLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String folder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        String where;
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text += "Welcome to the installer!\nAutofinding install location!\n";
            textBox1.Text = folder + "\\Freedeck";
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
            where = textBox1.Text;
            textBox1.Enabled = false;
            button1.Text = "Working...";
            button1.Enabled = false;
            richTextBox1.Text += "Initializing install\n";
            richTextBox1.Text += "Checking for git...\n";
            if (!Directory.Exists("C:\\Program Files\\Git\\bin"))
            {
                richTextBox1.Text += "Couldn't find git; opening bootstrapper!\n";
                GitBootstrap bs = new GitBootstrap();
                bs.ShowDialog();
                richTextBox1.Text += "Installed git!\n";
            }
            richTextBox1.Text += "Here we go!\n";
            richTextBox1.Text += "Step 1: Clone repository (github: freedeck/freedeck) to " + where + "\n";
            progressBar1.Value = 10;
            Process proc = new Process();
            proc.StartInfo.FileName = "git";
            proc.StartInfo.ArgumentList.Add("clone");
            proc.StartInfo.ArgumentList.Add("https://github.com/freedeck/freedeck");
            proc.StartInfo.ArgumentList.Add(where+"\\freedeck");
            proc.EnableRaisingEvents = true;
            proc.Exited += Proc_Exited;
            proc.Start();
        }

        private void Proc_Exited(object? sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
            richTextBox1.Text += "Cloned repository!\n";
                progressBar1.Value = 20;
                this.StepTwo();
            });
        }

        private void StepTwo()
        {
            richTextBox1.Text += "Step 2: Install npm dependencies\n";
            Process proc = new Process();
            proc.StartInfo.FileName = "npm";
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.ArgumentList.Add("i");
            proc.StartInfo.WorkingDirectory = where + "\\freedeck";
            proc.EnableRaisingEvents = true;
            proc.Exited += ProcTwo_Exited;
            proc.Start();
        }

        private void ProcTwo_Exited(object? sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                richTextBox1.Text += "Installed dependencies! Almost done!\n";
                progressBar1.Value = 50;
                this.StepThree();
            });
        }

        private void StepThree()
        {
            richTextBox1.Text += "Step 3: Creating desktop shortcuts!\n";
            CreateShortcut(
                "Freedeck",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                where + "\\freedeck\\init.bat", 
                where + "\\freedeck",
                where + "\\freedeck\\assets\\logo_big.ico"
            );
            CreateShortcut(
                "Freedeck",
                Environment.GetFolderPath(Environment.SpecialFolder.StartMenu),
                where + "\\freedeck\\init.bat",
                where + "\\freedeck",
                where + "\\freedeck\\assets\\logo_big.ico"
            );
            progressBar1.Value = 100;
            richTextBox1.Text += "Created shortcut on your Desktop!\n";
            richTextBox1.Text += "\n\nFreedeck is now installed!\nHave fun!\n";
            button1.Text = "Installed";
            label2.Text = "Freedeck is currently installed on your machine. Have fun!";
        }

        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation, string arg, string icon)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "The FOSS alternative to the Elgato Stream Deck.";   // The description of the shortcut
            shortcut.IconLocation = @icon;           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.Arguments = arg;
            shortcut.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
