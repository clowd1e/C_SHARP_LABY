using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Samochod
    {
        private string? marka;
        private string? model;
        private string? nadwozie;
        private string? kolor;
        private int rokProdukcji;
        private double? przebieg;
        protected const string noInfo = "Nie podano informacji";
        private double Przebieg { set { if (value >= 0) { przebieg = value; } else { przebieg = null; } } }

        public Samochod()
        {
            Console.WriteLine("Podaj markę: ");
            this.marka = Console.ReadLine();
            Console.WriteLine("Podaj model: ");
            this.model = Console.ReadLine();
            Console.WriteLine("Podaj nadwozie: ");
            this.nadwozie = Console.ReadLine();
            Console.WriteLine("Podaj kolor: ");
            this.kolor = Console.ReadLine();
            Console.WriteLine("Podaj rok produkcji: ");
            this.rokProdukcji = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj przebieg(wartość musi być większa lub równa 0): ");
            this.Przebieg = Convert.ToDouble(Console.ReadLine());
        } 
        public Samochod(string marka, string model, string nadwozie, string kolor, int rokProdukcji, double przebieg)
        {
            this.marka = marka;
            this.model = model;
            this.nadwozie = nadwozie;
            this.kolor = kolor;
            this.rokProdukcji = rokProdukcji;
            Przebieg = przebieg;
        }

        public virtual string Info() => $"Informacja o samochodzie: {marka} {model}, nadwozie: {nadwozie}, kolor: {kolor}, rok: {rokProdukcji}, przebieg: {(przebieg is null ? noInfo : przebieg)}.";
    }
}
