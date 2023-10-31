using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Osoba
    {
        private string firstName;
        private string lastName;
        private int age;
        private string city;

        public Osoba(string firstName, string lastName, int age, string city)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.city = city;
        }

        public override string? ToString()
        {
            return base.ToString() + " obiekt klasy: " + firstName.ToString();
        }

        public void View()
        {
            Console.WriteLine($"Imie: {firstName}, nazwisko: {lastName}, wiek: {age}, miasto: {city}");
        }
    }
}
