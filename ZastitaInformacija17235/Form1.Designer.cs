
namespace ZastitaInformacija17235
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSetInput = new System.Windows.Forms.Button();
            this.btnSetOutput = new System.Windows.Forms.Button();
            this.btnEnkripcija = new System.Windows.Forms.Button();
            this.btnDekripcija = new System.Windows.Forms.Button();
            this.rbtnRSA = new System.Windows.Forms.RadioButton();
            this.rbtnRFC = new System.Windows.Forms.RadioButton();
            this.fsw = new System.IO.FileSystemWatcher();
            this.btnFSW = new System.Windows.Forms.Button();
            this.numUD = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetInput
            // 
            this.btnSetInput.Location = new System.Drawing.Point(491, 83);
            this.btnSetInput.Name = "btnSetInput";
            this.btnSetInput.Size = new System.Drawing.Size(121, 37);
            this.btnSetInput.TabIndex = 5;
            this.btnSetInput.Text = "Set Input Folder";
            this.btnSetInput.UseVisualStyleBackColor = true;
            this.btnSetInput.Click += new System.EventHandler(this.btnSetInput_Click);
            // 
            // btnSetOutput
            // 
            this.btnSetOutput.Location = new System.Drawing.Point(491, 147);
            this.btnSetOutput.Name = "btnSetOutput";
            this.btnSetOutput.Size = new System.Drawing.Size(121, 48);
            this.btnSetOutput.TabIndex = 6;
            this.btnSetOutput.Text = "Set Output Folder";
            this.btnSetOutput.UseVisualStyleBackColor = true;
            this.btnSetOutput.Click += new System.EventHandler(this.btnSetOutput_Click);
            // 
            // btnEnkripcija
            // 
            this.btnEnkripcija.Location = new System.Drawing.Point(291, 83);
            this.btnEnkripcija.Name = "btnEnkripcija";
            this.btnEnkripcija.Size = new System.Drawing.Size(111, 37);
            this.btnEnkripcija.TabIndex = 9;
            this.btnEnkripcija.Text = "Encryption";
            this.btnEnkripcija.UseVisualStyleBackColor = true;
            this.btnEnkripcija.Click += new System.EventHandler(this.btnEnkripcija_Click);
            // 
            // btnDekripcija
            // 
            this.btnDekripcija.Location = new System.Drawing.Point(291, 147);
            this.btnDekripcija.Name = "btnDekripcija";
            this.btnDekripcija.Size = new System.Drawing.Size(111, 48);
            this.btnDekripcija.TabIndex = 10;
            this.btnDekripcija.Text = "Decryption";
            this.btnDekripcija.UseVisualStyleBackColor = true;
            this.btnDekripcija.Click += new System.EventHandler(this.btnDekripcija_Click);
            // 
            // rbtnRSA
            // 
            this.rbtnRSA.AutoSize = true;
            this.rbtnRSA.Checked = true;
            this.rbtnRSA.Location = new System.Drawing.Point(52, 74);
            this.rbtnRSA.Name = "rbtnRSA";
            this.rbtnRSA.Size = new System.Drawing.Size(47, 17);
            this.rbtnRSA.TabIndex = 11;
            this.rbtnRSA.TabStop = true;
            this.rbtnRSA.Text = "RSA";
            this.rbtnRSA.UseVisualStyleBackColor = true;
            // 
            // rbtnRFC
            // 
            this.rbtnRFC.AutoSize = true;
            this.rbtnRFC.Location = new System.Drawing.Point(52, 163);
            this.rbtnRFC.Name = "rbtnRFC";
            this.rbtnRFC.Size = new System.Drawing.Size(46, 17);
            this.rbtnRFC.TabIndex = 12;
            this.rbtnRFC.Text = "RFC";
            this.rbtnRFC.UseVisualStyleBackColor = true;
            this.rbtnRFC.CheckedChanged += new System.EventHandler(this.rbtnRFC_CheckedChanged);
            // 
            // fsw
            // 
            this.fsw.EnableRaisingEvents = true;
            this.fsw.Filter = "*.txt*";
            this.fsw.IncludeSubdirectories = true;
            this.fsw.NotifyFilter = System.IO.NotifyFilters.Size;
            this.fsw.SynchronizingObject = this;
            this.fsw.Changed += new System.IO.FileSystemEventHandler(this.fsw_Changed);
            this.fsw.Created += new System.IO.FileSystemEventHandler(this.fsw_Created);
            // 
            // btnFSW
            // 
            this.btnFSW.BackColor = System.Drawing.Color.Red;
            this.btnFSW.Location = new System.Drawing.Point(390, 12);
            this.btnFSW.Name = "btnFSW";
            this.btnFSW.Size = new System.Drawing.Size(157, 36);
            this.btnFSW.TabIndex = 13;
            this.btnFSW.Text = "File System Watcher: OFF";
            this.btnFSW.UseVisualStyleBackColor = false;
            this.btnFSW.Click += new System.EventHandler(this.btnFSW_Click);
            // 
            // numUD
            // 
            this.numUD.Enabled = false;
            this.numUD.Location = new System.Drawing.Point(118, 163);
            this.numUD.Name = "numUD";
            this.numUD.Size = new System.Drawing.Size(87, 20);
            this.numUD.TabIndex = 14;
            this.numUD.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(722, 333);
            this.Controls.Add(this.numUD);
            this.Controls.Add(this.btnFSW);
            this.Controls.Add(this.rbtnRFC);
            this.Controls.Add(this.rbtnRSA);
            this.Controls.Add(this.btnDekripcija);
            this.Controls.Add(this.btnEnkripcija);
            this.Controls.Add(this.btnSetOutput);
            this.Controls.Add(this.btnSetInput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSetInput;
        private System.Windows.Forms.Button btnSetOutput;
        private System.Windows.Forms.Button btnEnkripcija;
        private System.Windows.Forms.Button btnDekripcija;
        private System.Windows.Forms.RadioButton rbtnRSA;
        private System.Windows.Forms.RadioButton rbtnRFC;
        private System.Windows.Forms.Button btnFSW;
        private System.Windows.Forms.NumericUpDown numUD;
        public System.IO.FileSystemWatcher fsw;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

