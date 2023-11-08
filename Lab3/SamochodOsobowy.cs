using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class SamochodOsobowy : Samochod
    {
        private double? waga;
        private double? pojemnoscSilnika;
        private int iloscOsob;
        private double Waga { set { if (value >= 2000 && value <= 4500) { waga = value; } else { waga = null; } } }
        private double PojemnoscSilnika { set { if (value >= 0.8 && value <= 3) { pojemnoscSilnika = value; } else { pojemnoscSilnika = null; } } }

        public SamochodOsobowy() : base()
        {
            Console.WriteLine("Podaj wagę(wartość od 2 000 do 4 500): ");
            Waga = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj pojemność silnika(wartość od 0,8 do 3): ");
            PojemnoscSilnika = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj ilość osób: ");
            iloscOsob = Convert.ToInt32(Console.ReadLine());
        }

        public override string Info() => base.Info().Substring(0, base.Info().Length - 1) + $", waga: {(waga is null ? noInfo : waga)}, pojemność silnika: {(pojemnoscSilnika is null ? noInfo : pojemnoscSilnika)}, ilość osób: {iloscOsob}.";
    }
}
