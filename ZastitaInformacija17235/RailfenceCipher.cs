using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZastitaInformacija17235
{
    public class RailfenceCipher
    {
        private int kljuc;
        public int Kljuc { get; set; }
        public RailfenceCipher() { }
        public RailfenceCipher(int kljuc)
        {
            this.kljuc = kljuc;
        }
        
        public byte[] Dekripcija(BitArray bitovi, int kljuc)
        {
            if (kljuc < 0)
            {
                throw new ArithmeticException("Kljuc ne moze imati negativnu vrednost!");
            }

            BitArray poruka = new BitArray(bitovi.Length);
            int currPosition = 0;
            for (int red = 0; red < kljuc; red++)
            {
                int iter = 0;
                for (int i = red; i < bitovi.Length; i += getTerm(iter++, red, kljuc))
                {
                    poruka[i] = bitovi[currPosition++];

                }


            }
            return BajtKonvertor(poruka);

        }

        public byte[] Enkripcija(BitArray bitovi, int kljuc)
        {
            BitArray poruka = new BitArray(bitovi.Length);
            int l = 0;
            if (kljuc < 0)
            {
                throw new ArithmeticException("Kljuc ne moze imati negativnu vrednost");
            }
            else if (kljuc == 0)
            {
                kljuc = 1;
            }

            for (int red = 0; red < kljuc; red++)
            {
                int iter = 0;
                for (int i = red; i < bitovi.Length; i += getTerm(iter++, red, kljuc))
                {
                    poruka[l++] = bitovi[i];
                }

            }
            return BajtKonvertor(poruka);
        }
        public static byte[] BajtKonvertor(BitArray bitovi)
        {
            int bajtovin = bitovi.Count / 8;
            if (bitovi.Count % 8 != 0) bajtovin++;

            byte[] bajtovi = new byte[bajtovin];
            int bajtindex = bajtovin, bitindex = 0;

            for (int i = bitovi.Count - 1; i >= 0; i--)
            {
                if (bitovi[i])
                    bajtovi[bajtindex - 1] |= (byte)(1 << (7 - bitindex));

                bitindex++;
                if (bitindex == 8)
                {
                    bitindex = 0;
                    bajtindex--;
                }
            }
            for (int i = 0; i < bajtindex; i++)
                Console.WriteLine(bajtovi.Length);
            return bajtovi;

        }
        static int getTerm(int iter, int red, int n)
        {
            if ((n == 0) || (n == 1))
            {
                return 1;
            }
            if ((red == 0) || (red == n - 1))
            {
                return (n - 1) * 2;
            }

            if (iter % 2 == 0)
            {
                return (n - 1 - red) * 2;
            }
            return 2 * red;
        }



    }
}
