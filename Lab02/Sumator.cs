using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Sumator
    {
        private double[] liczby;

        public Sumator(double[] liczby)
        {
            this.liczby = liczby;
        }
        public double Suma()
        {
            double suma = 0;
            foreach (double item in liczby)
            {
                suma += item;
            }

            return suma;
        }
        public double SumaPodziel2()
        {
            double suma = 0;
            foreach (double item in liczby)
            {
                suma += (item / 2);
            }

            return suma;
        }
        public void PokazElementy()
        {
            foreach (double item in liczby)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("- elementy tablicy");
        }
        public void PokazElementy(int lowIndex, int highIndex)
        {
            lowIndex = lowIndex < 0 || lowIndex > liczby.Length - 1 || lowIndex > highIndex ? 0 : lowIndex;
            highIndex = highIndex >= liczby.Length || highIndex < 0 ? liczby.Length - 1 : lowIndex;
            int lowRem = lowIndex;
            int highRem = highIndex;

            for (; lowIndex <= highIndex; lowIndex++)
            {
                Console.Write(liczby[lowIndex] + " ");
            }
            Console.WriteLine($"- elementy tablicy z indeksa {lowRem} do {highRem}");
        }
        public int IleElementow() => liczby.Length;
    }
}
