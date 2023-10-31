using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Number
    {
        private char[] cyfry;

        public Number(int num)
        {
            char[] numS = Convert.ToString(num).ToCharArray();
            cyfry = new char[numS.Length];
            for (int i = 0; i < numS.Length; i++)
            {
                cyfry[i] = Convert.ToChar(numS[i]);
            }
        }

        public void WypiszLiczbe()
        {
            Console.WriteLine($"Liczba rowna sie: {string.Join("", cyfry)}");
        }

        public void PomnozRazy(int a)
        {
            ChangeArray(GetInt() * a);
        }

        public int Silnia(int n)
        {
            if (n < 0)
            {
                return -1;
            }
            else if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return Silnia(n - 1) * n;
            }
        }

        // Metody pomocnicze
        private string GetString() => string.Join("", cyfry);
        private int GetInt() => Convert.ToInt32(GetString());
        private void ChangeArray(int newNum)
        {
            string newNumS = Convert.ToString(newNum);
            if (newNumS.Length != cyfry.Length)
            {
                cyfry = new char[newNumS.Length];
            }
            for (int i = 0; i < newNumS.Length; i++)
            {
                cyfry[i] = Convert.ToChar(newNumS[i]);
            }
        }

    }
}
