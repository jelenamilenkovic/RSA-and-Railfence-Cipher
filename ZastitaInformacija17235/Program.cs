using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaInformacija17235
{
    static class Program
    {
        //static public RSA al = new RSA();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //f(true);
            // Console.WriteLine("wait");
            // Console.ReadLine();
        }
        /*static void f(bool g)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            if (g == true)
            {


                watcher.Path = @"C:\Users\Aleksandra\source\repos\ZastitaInformacija17235\ZastitaInformacija17235\zaenkripcija";
                watcher.EnableRaisingEvents = g;
                watcher.IncludeSubdirectories = true;
               // watcher.Created += watcher_Created;
                watcher.Changed += watcher_Changed;

              //  watcher.NotifyFilter = NotifyFilters.Size;
            }
            else
            {
                watcher.EnableRaisingEvents = false;

            }
        }*/
        /*   static void watcher_Changed(object sender, FileSystemEventArgs e)
           {


                   string filename = Path.GetFileName(e.FullPath);
                   Directory.SetCurrentDirectory(@"C:\Users\Aleksandra\source\repos\ZastitaInformacija17235\ZastitaInformacija17235\zaenkripcija");
                   byte[] bajtovi = File.ReadAllBytes(filename);
                   Console.WriteLine(bajtovi.Length);
                   //var bits = new BitArray(bajtovi);


                   f(false);
               flag(bajtovi);
                   f(false);


           }
           static void flag(byte[] l)
           {
               al.P= 7;
               al.Q = 29;
             al.N = al.NFunction();
               al.E = al.EFunction();
            al.D = al.DFunction();
              byte[] prevod=new byte[l.Length];
               byte[] v = new byte[l.Length];
               //BitArray b = new BitArray(8);
               //   string k= Console.ReadLine();
               uint h=0;
               for(int i=0;i<l.Length;i++)
               {    h = al.Enkripcija(Convert.ToUInt32(l[i]));
                  int y = (int)h;
                   prevod[i] =(byte)y;
                }
               Console.WriteLine( h.ToString());
               FileStream fs = File.Create("jelenaprevod.txt");
               fs.Close();
               File.WriteAllBytes("jelenaprevod.txt", prevod);
               fs.Close();
               // uint w = al.Dekripcija(h); 
               Console.WriteLine("p=" + al.P.ToString() + " q=" + al.Q.ToString() + " n=" + al.N.ToString() + " fi=" + al.EulerFunction().ToString() + " e=" + al.E.ToString() + " d=" + al.D.ToString()); 
               for(int i = 0; i < l.Length; i++) { 
                   h=al.Dekripcija(Convert.ToUInt32(prevod[i]));
               int y = (int)h;
               v[i] = (byte)y;
           }
           Console.WriteLine(h.ToString());
                fs = File.Create("jelenaprevod2.txt");
           fs.Close();
               File.WriteAllBytes("jelenaprevod2.txt", v);
               fs.Close();
               //int broj = 25;
               // al.Enkripcija();
              // int l = al.Dekripcija(m);
             //  Console.WriteLine("m " + m.ToString() + "l " + l.ToString());
           }
           static uint BitArrayToUnSignedInt(BitArray bitArray)
           {
               uint res = 0;
               for (int i = bitArray.Length - 1; i != 0; i--)
               {
                   if (bitArray[i])
                   {
                       res = (uint)(res + (uint)Math.Pow(2, bitArray.Length - i - 1));
                   }
               }
               return res;
           }


       }*/
    }
}