namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            //Car car = new Car();
            //car.View();
            //car.name = "Audi";
            //car.rok = 2022;
            //car.View();

            //Car car1 = new Car("Toyota");
            //car1.View();
            //Car car2 = new Car("maluch", 1234);
            //car2.View();

            //Osoba osoba = new Osoba("Jan", "Nowak", 12, "Rzeszów");

            //osoba.View();
            //Console.WriteLine("Wywolanie metody ToString: ");
            //Console.WriteLine(osoba.ToString());
            #endregion

            Console.WriteLine("ZADANIE 1\n");
            Licz licz1 = new Licz(43);
            Console.WriteLine("Wartosc licz1 rowna sie: " + licz1.Value());
            licz1.Dodaj(32.54);
            Console.WriteLine("Wartosc licz1 po dodaniu: " + licz1.Value());
            licz1.Odejmij(21.2);
            Console.WriteLine("Wartosc licz1 po odejmowaniu: " + licz1.Value());
            Console.WriteLine();

            Console.WriteLine("ZADANIE 2\n");
            Sumator sum1 = new Sumator(new double[] { 3, 6.7, 87, 43 });
            Console.WriteLine(sum1.Suma() + " - suma elemntow");
            Console.WriteLine(sum1.SumaPodziel2() + " - suma elemntow przez 2");
            Console.WriteLine(sum1.IleElementow() + " - ilosc elementow");
            sum1.PokazElementy();
            sum1.PokazElementy(3, 5);
            sum1.PokazElementy(2, 1);
            sum1.PokazElementy(4, 19);
            sum1.PokazElementy(0, 4);
            Console.WriteLine();

            Console.WriteLine("ZADANIE 3\n");
            Date date1 = new Date(DateTime.ParseExact("01/02/2023 14:00", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture), "Zrob zadanie domowe!");
            Date date2 = new Date(DateTime.ParseExact("01/02/2023 09:30", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture), "Pojdz na silownie!");
            Date date3 = new Date(new DateTime(2023, 1, 2, 16, 30, 0), "Zadzwon do babci, przeciez tesknie za toba");
            date1.ShowDate();
            date2.ShowDate();
            date3.ShowDate();
            Console.WriteLine(date1.GetNowDate());
            Console.WriteLine(date1.GetNowDateOneWeekAfter());
            Console.WriteLine(date1.GetNowDateOneWeekBefore());
            Console.WriteLine();

            Console.WriteLine("ZADANIE 4\n");
            Number num1 = new Number(43254);
            num1.WypiszLiczbe();
            num1.PomnozRazy(0);
            num1.WypiszLiczbe();
            Number num2 = new Number(342089);
            num2.WypiszLiczbe();
            num2.PomnozRazy(-4);
            num2.WypiszLiczbe();
            Console.WriteLine("Silnia rowna sie: " + num2.Silnia(6));
        }
    }
}