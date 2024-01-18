
using ConsoleApp1.Classes;
using ConsoleApp1.Exceptions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Czesc, czego uzywamy dzisiaj? (1 - pliku CSV, 2 - bazy danych)");
                int result = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (result)
                {
                    case 1:
                        StartCSV();
                        break;
                    case 2:
                        StartDB();
                        break;
                    default:
                        Console.WriteLine("Nie poprawnie wybrana opcja.");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Nie poprawnie wybrana opcja.");
            } 
        }

        public static void StartDB()
        {
            DBclass dataBase = new DBclass();
            bool isEnd = false;
            while (!isEnd)
            {
                Console.WriteLine("Wybierz opcje: \n" +
                    "1. Wyswietl dane. \n" +
                    "2. Dodaj osobe. \n" +
                    "3. Modyfikuj osobe. \n" +
                    "4. Usun osobe. \n" +
                    "5. Wyjscie.");
                try
                {
                    int result = Convert.ToInt32(Console.ReadLine());
                    switch (result)
                    {
                        case 1:
                            Console.Clear();
                            dataBase.ShowAllRecords();
                            break;
                        case 2:
                            
                            break;
                        case 3:

                            break;
                        case 4:
                            
                            break;
                        case 5:
                            isEnd = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opcja zostala wybrana zle");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Opcja zostala wybrana zle");
                }
            }
        }

        public static void StartCSV()
        {
            bool isEnd = false;
            while (!isEnd)
            {
                Console.WriteLine("Wybierz opcje: \n" +
                    "1. Wyswietl dane. \n" +
                    "2. Dodaj osobe. \n" +
                    "3. Modyfikuj osobe. \n" +
                    "4. Usun osobe. \n" +
                    "5. Wyjscie.");
                try
                {
                    int result = Convert.ToInt32(Console.ReadLine());
                    switch(result)
                    {
                        case 1:
                            Console.Clear();
                            CSVclass.ReadAndDisplayDataFromCsv();
                            break;
                        case 2:
                            try
                            {
                                AddPerson();
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                            }
                            catch (EmailException ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                            }
                            catch (PeselException ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 3:
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Wpisz pesel szukanej osoby:");
                                string searchStr = Console.ReadLine();
                                CSVclass.ModifyPerson(searchStr);
                            }
                            catch (RecordNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 4:
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Wpisz pesel szukanej osoby:");
                                string searchItem = Console.ReadLine();
                                CSVclass.DeletePerson(searchItem);
                            }
                            catch (RecordNotFoundException ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 5:
                            isEnd = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opcja zostala wybrana zle");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Opcja zostala wybrana zle");
                }
            }
        }

        public static void AddPerson()
        {
            Console.Clear();
            Console.WriteLine("Wpisz imie:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Wpisz nazwisko:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Wpisz ulice:");
            string street = Console.ReadLine();
            Console.WriteLine("Wpisz miasto:");
            string city = Console.ReadLine();
            Console.WriteLine("Wpisz kod pocztowy:");
            string postalCode = Console.ReadLine();
            postalCode = string.IsNullOrEmpty(postalCode) ? "00-000" : postalCode;
            Console.WriteLine("Wpisz kraj:");
            string country = Console.ReadLine();
            country = string.IsNullOrEmpty(country) ? "Polska" : country;
            Console.WriteLine("Wpisz pesel:");
            string pesel = Console.ReadLine();
            Console.WriteLine("Wpisz email:");
            string email = Console.ReadLine();
            Console.Clear();

            CSVclass.AddPerson(new Person(firstName, lastName,
                                new Address(street, city, postalCode, country), pesel, email));
        }
    }
}
