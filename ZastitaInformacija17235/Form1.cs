using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaInformacija17235
{
    public partial class Form1 : Form
    {
        public string StartFolder;
        public string OutputFolder;
        public string DebugFolder = @"C:\Users\Aleksandra\source\repos\ZastitaInformacija17235\ZastitaInformacija17235\zaenkripciju";
        public RailfenceCipher _rc;
        public bool Initialized { get; set; }
        public RSA _rsa;
        public Form1()
        {
            InitializeComponent();
            Initialized = false;
            fsw.EnableRaisingEvents = false;
             _rc = new RailfenceCipher();
           _rsa = new RSA();

        }

        private void btnSetOutput_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    if (fbd.SelectedPath.CompareTo(fsw.Path) == 0)
                    {
                        MessageBox.Show("Odredisni folder ne moze biti isti kao izvorni!","Postoji greska u ulazu!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                   OutputFolder = fbd.SelectedPath;

                  Podesavanja();
                }
            }
        }
        private void Podesavanja()
        {
            btnFSW.BackColor = fsw.EnableRaisingEvents ? Color.Green : Color.Red;
            btnFSW.Text= fsw.EnableRaisingEvents ? "File System Watcher: ON" : "File System Watcher: OFF";
            btnFSW.Enabled = !string.IsNullOrEmpty(OutputFolder) && !string.IsNullOrEmpty(fsw.Path) && fsw.Path.CompareTo(".") != 0;
            btnDekripcija.Enabled = (!fsw.EnableRaisingEvents);
            btnEnkripcija.Enabled = !fsw.EnableRaisingEvents && !string.IsNullOrEmpty(OutputFolder);
            btnSetOutput.Enabled = !fsw.EnableRaisingEvents;
            btnSetInput.Enabled = !fsw.EnableRaisingEvents;
        }
        private void btnEnkripcija_Click(object sender, EventArgs e)
        {
            if (OutputFolder != null)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))

                    {
                        StartFolder = Directory.GetParent(ofd.FileName).FullName;
                        Kodiranje(ofd.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Izaberite odredisni folder!!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void btnDekripcija_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
               
                int kljuc1;int kljuc2=0;
                string file = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                Directory.SetCurrentDirectory(DebugFolder);
                StreamReader fs = new StreamReader("Enkripcija.txt");
                while (true)
                {   string p = "rsa";
                    string algoritam;
                    string line = fs.ReadLine();
                    if (line.Equals(file + ".txt") == true)
                    {
                        if (p.Equals(algoritam = fs.ReadLine()))
                        {
                            kljuc1 = Convert.ToInt32(fs.ReadLine());
                            kljuc2 = Convert.ToInt32(fs.ReadLine());
                        }
                        else { kljuc1 = Convert.ToInt32(fs.ReadLine()); }
                        Directory.SetCurrentDirectory(System.IO.Path.GetDirectoryName(openFileDialog1.FileName));
                        byte[] bajtovi = File.ReadAllBytes(line);
                        byte[] noviniz = new byte[bajtovi.Length];
                        if (algoritam.Equals("rsa"))
                        {
                            for (int i = 0; i < bajtovi.Length; i++)
                            {
                                int y = (int)_rsa.Dekripcija(Convert.ToUInt32(bajtovi[i]),(uint)ShiftovanjeKljuca(kljuc1,false),(uint)ShiftovanjeKljuca( kljuc2,false));

                                noviniz[i] = (byte)y;
                            }
                        }
                        else { 
                        var bits = new BitArray(bajtovi);
                        noviniz = _rc.Dekripcija(bits, ShiftovanjeKljuca(kljuc1, false));}
                        upisidek(noviniz);
                        break;
                    }
                }
            }
        }
        static void upisidek(byte[] poruka)
        {
            SaveFileDialog sc = new SaveFileDialog();
            sc.Filter = "Text Document|*.txt";
            if (sc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllBytes(sc.FileName, poruka);

            }
        }
        private void Kodiranje(string filename)
        {
            
            
            string file = Path.GetFileNameWithoutExtension(filename);
            
            Directory.SetCurrentDirectory(StartFolder);
            FileStream fs = new FileStream(file+".txt", FileMode.Open, FileAccess.Read); ;
            byte[] bajtovi = File.ReadAllBytes(file+".txt"); 
            var bits = new BitArray(bajtovi);
            byte[] noviniz = new byte[bajtovi.Length];
            if (rbtnRFC.Checked == true)
            {
                _rc.Kljuc = Convert.ToInt32(numUD.Value);

                noviniz=_rc.Enkripcija(bits, Convert.ToInt32(numUD.Value));
                
            }
            else
            {
                for (int i = 0; i < bajtovi.Length; i++)
                {
                    int y = (int)_rsa.Enkripcija(Convert.ToUInt32(bajtovi[i]));
                     noviniz[i] = (byte)y;
                }
               
            }
            fsw.EnableRaisingEvents = false;
            Directory.SetCurrentDirectory(OutputFolder);
            String fff = "File" + $@"{DateTime.Now.Ticks}";
            fs = File.Create(fff+".txt");
            fs.Close();
            File.WriteAllBytes(fff+".txt", noviniz);
            fs.Close();
            Evidencija(fff);
        }
        private void Evidencija(string filename)
        {
            Directory.SetCurrentDirectory(DebugFolder);
            if (rbtnRFC.Checked == true)
                {
                SerializeSupport.Serialize(_rc, "kripto.xml");
                File.AppendAllText(DebugFolder+"/Enkripcija.txt", filename + ".txt" + Environment.NewLine +"rfc"+Environment.NewLine+ ShiftovanjeKljuca(_rc.Kljuc,true).ToString() + Environment.NewLine); }
            else
            {
                SerializeSupport.Serialize(_rsa, "kripto.xml");
                File.AppendAllText(DebugFolder+"/Enkripcija.txt", filename + ".txt" + Environment.NewLine + "rsa" + Environment.NewLine+ ShiftovanjeKljuca((int)_rsa.D,true).ToString()+ Environment.NewLine+ShiftovanjeKljuca((int)_rsa.N,true ).ToString()+ Environment.NewLine); 
        }

        }
        private void btnSetInput_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    if (fbd.SelectedPath.CompareTo(OutputFolder) == 0)
                    {
                        MessageBox.Show("Izvorni i odredisni folder ne mogu biti isti!", "Greska sa ulazom!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    fsw.Path =fbd.SelectedPath;
                    StartFolder = fsw.Path;
                    Podesavanja();
                }
            }
        }

        private void btnFSW_Click(object sender, EventArgs e)
        {
            if (!fsw.EnableRaisingEvents && (string.IsNullOrEmpty(fsw.Path) || fsw.Path.CompareTo(".") == 0))
            {
                MessageBox.Show("Izaberite izvorni folder!!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fsw.EnableRaisingEvents = !fsw.EnableRaisingEvents;
            btnFSW.BackColor = Color.Green;
            Podesavanja();
        }

        private void fsw_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            Kodiranje(e.FullPath);
        }

        private void rbtnRFC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRFC.Checked == true) { numUD.Visible = true; numUD.Enabled = true; }
            else { numUD.Visible = false; numUD.Enabled = false; }
        }
        public int ShiftovanjeKljuca(int kljuc, bool smer)
        {
            byte pom = 2;
            if (smer == true) return kljuc << pom;
            else return kljuc >> pom;
        }

        private void fsw_Created(object sender, FileSystemEventArgs e)
        {
            Kodiranje(e.FullPath);
        }
    }
}
