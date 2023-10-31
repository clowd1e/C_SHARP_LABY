using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Car
    {
        public string name;
        public int rok;

        public Car()
        {
            name = "Mersedes";
            rok = 2023;
        }
        public Car(string name)
        {
            this.name = name;
        }
        public Car(string name, int a)
        {
            this.name = name;
            rok = a;
        }
        public void View()
        {
            Console.WriteLine($"Samochod {name}, rok producji {rok}");
        }
    }
}
