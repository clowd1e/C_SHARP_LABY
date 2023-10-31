using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Licz
    {
        private double _value;
        public double Value() => _value;
        public Licz(double value = 0)
        {
            _value = value;
        }

        public void Dodaj(double n)
        {
            _value += n;
        }
        public void Odejmij(double n)
        {
            _value -= n;
        }
    }
}
