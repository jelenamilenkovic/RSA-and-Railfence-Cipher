using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZastitaInformacija17235
{
    public class RSA
    {
        private static Random random = new Random();

        public uint P { get; set; }
        public uint Q { get; set; }
        public uint N { get; set; }
        public uint D { get; set; }
        public uint E { get; set; }
        public RSA()
        {
            P = 7;
            Q = 29;
            //p i q su hardkodirani da bi aplikacija brze radila
            //u izracunavanju narednih funkcija
            //inace program radi i kada su promenljive P i Q veci brojevi
            N = NFunction();
            E = EFunction();
            D = DFunction();

        }
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
        public int RandomPrimeNumber()
        {
            int k=2 ;
            do
            {
                k = random.Next(1000);
            }
            while (!IsPrime(k));
            return k;
        }
        public uint NFunction()
        {
            return N=P * Q;
        }
        public uint gcd(uint a, uint b)
        {
          
        if (a == 0)
            return b;
        return gcd(b % a, a);
        }

        public uint EulerFunction()
        {
                uint result = 1;
                for (int i = 2; i < N; i++)
                    if (gcd((uint)i, N) == 1)
                        result++;
                return result;
        }
        public uint EFunction()
        {
            uint m ;
            int fi = (int)EulerFunction();
            do
            {
                m = (uint)random.Next(fi);
            }
            while (fi % m == 0 && m % fi == 0 && m!=0);
            return E = m;
        }
        public uint DFunction()
        {
            uint k = 0;
            uint l;
            uint x ;
            do
            {
                k = (uint)random.Next(100);
                l = EulerFunction();
                x = (l* k + 1) / E;
            
            } while ((l * k + 1)%E!=0);
            return D = x;
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
        public uint Enkripcija(uint M)
        {
        byte[] k = BitConverter.GetBytes(E);
        var bits = new BitArray(k);
        uint m = M;
        uint r = M;
        for (int i = (int)countBits(E)-1; i >=0; i--)
             if (bits[i]==true){
                 if (i == (int)countBits(E) - 1) {  m = m % N;}
                  else {    uint o = m;
                            uint s = m;
                            uint p = ((o *o)* r) % N;
                            m = p; }}
             else if(bits[i]==false)
                    { uint l ;
                        l = (m *m) % N;
                        m = l;}
            return m;
        }
        public uint countBits(uint number)
        {
            return (uint)Math.Log(number, 2.0) + 1;
        }
        public uint Dekripcija(uint C,uint DD,uint NN)
        {
            D = DD;
            N = NN;
            byte[] k = BitConverter.GetBytes(D);
            var bits = new BitArray(k);
            uint m = C;
            uint r = C;
            for (int i = (int)countBits(D)-1 ; i >= 0; i--)
                if (bits[i] == true)
                {
                    if (i == (int)countBits(D) - 1)
                    {
                        m = m % N;
                    }
                    else
                    {
                        uint o = m;
                        uint s = m;
                        uint p = ((o * o) * r) % N;
                        m = p;
                    }
                   

                }
                else if (bits[i] == false)
                {
                    uint l;
                    l = (m * m) % N;
                    m = l;
                

                }
            
            return m;
        
          }
    }
}
