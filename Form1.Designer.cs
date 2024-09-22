namespace FreedeckLauncher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            progressBar1 = new ProgressBar();
            label2 = new Label();
            button1 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            textBox1 = new TextBox();
            button2 = new Button();
            label3 = new Label();
            richTextBox1 = new RichTextBox();
            label4 = new Label();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            checkBox2 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(2, 2);
            label1.Name = "label1";
            label1.Size = new Size(110, 32);
            label1.TabIndex = 0;
            label1.Text = "Freedeck";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(110, 171);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(266, 31);
            progressBar1.TabIndex = 1;
            progressBar1.Click += progressBar1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(4, 34);
            label2.Name = "label2";
            label2.Size = new Size(450, 15);
            label2.TabIndex = 2;
            label2.Text = "You're one click away from installing the FOSS alternative to the Elgato Stream Deck.";
            // 
            // button1
            // 
            button1.Location = new Point(379, 171);
            button1.Name = "button1";
            button1.Size = new Size(75, 31);
            button1.TabIndex = 3;
            button1.Text = "Install!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(100, 52);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(253, 23);
            textBox1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(359, 52);
            button2.Name = "button2";
            button2.Size = new Size(85, 23);
            button2.TabIndex = 5;
            button2.Text = "Change";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(2, 56);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 6;
            label3.Text = "Installation Path";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(4, 81);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(292, 84);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 115);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 8;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(4, 171);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(100, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Add Handoff?";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Freedeck_Installer.Properties.Resources.logo_big1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(300, 81);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(154, 84);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(4, 190);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(102, 19);
            checkBox2.TabIndex = 11;
            checkBox2.Text = "Make shortcut";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(461, 214);
            Controls.Add(checkBox2);
            Controls.Add(pictureBox1);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(richTextBox1);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Freedeck Installer";
            Load += Form1_Load;
            Shown += Form1_Ready;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ProgressBar progressBar1;
        private Label label2;
        private Button button1;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox textBox1;
        private Button button2;
        private Label label3;
        private RichTextBox richTextBox1;
        private Label label4;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
        private CheckBox checkBox2;
    }
}
