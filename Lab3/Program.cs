using System;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadanie 1a\n");

            Person[] people = new Person[] {
                new Person("Jan", "Nowak", 34),
                new Person("Marek", "Nowakowski", 52),
                new Person("Maira", "Nowak", 27),
                new Person("Adam", "Mickiewicz", 77),
                new Person("Ignacy", "Ladach", 29),
                new Person("Kiril", "Hutek", 56),
                new Person("Michał", "Pabian", 37)
            };

            Book[] books = new Book[]
            {
                new Book("Tytul", people[0], new DateTime(2023, 11, 07)),
                new Book("Tytul1", people[1], new DateTime(2022, 03, 07)),
                new Book("Tytul2", people[2], new DateTime(2021, 01, 13)),
                new Book("Tytul3", people[3], new DateTime(2021, 07, 17)),
                new Book("Tytul4", people[3], new DateTime(2013, 03, 06)),
                new Book("Tytul5", people[4], new DateTime(2017, 11, 15)),
                new Book("Tytul6", people[5], new DateTime(2020, 09, 02)),
                new Book("Tytul7", people[6], new DateTime(2005, 01, 30))
            };

            Console.WriteLine("Osoby:");
            foreach (Person person in people)
            {
                Console.WriteLine(person.View());
            }
            Console.WriteLine();

            Console.WriteLine("Książki");
            foreach (Book book in books)
            {
                Console.WriteLine(book.View());
                Console.WriteLine();
            }

            Console.WriteLine("Zadanie 1b\n");

            Reader[] readers = new Reader[]
            {
                new Reader("Kacper", "Daciuk", 17, new Book[] { books[2], books[1] } ),
                new Reader("David", "Nabagło", 23, new Book[] { books[1], books[3], books[4], books[0] } ),
                new Reader("Felix", "Kabot", 67, new Book[] { books[0], books[1], books[2], books[4], books[5] } ),
            };

            foreach (Reader reader in readers)
            {
                Console.WriteLine($"Czytelnik: {reader.View()}");
                reader.ViewBook();
                Console.WriteLine();
            }

            Console.WriteLine("Zadanie 1c\n");

            foreach (Reader reader in readers)
            {
                Console.WriteLine(reader.View());
            }

            Console.WriteLine("\nZadanie 2\n");

            Samochod samochod1 = new Samochod();
            Console.WriteLine(samochod1.Info());
            Samochod samochod2 = new Samochod("BMW", "GTX-500", "Trójbryłowe", "Czarny", 2019, -34);
            Console.WriteLine(samochod2.Info());
            SamochodOsobowy samochodOsobowy = new SamochodOsobowy();
            Console.WriteLine(samochodOsobowy.Info());
        }
    }
}