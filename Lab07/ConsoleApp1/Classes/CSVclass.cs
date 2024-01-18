using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Exceptions;
using CsvHelper;

namespace ConsoleApp1.Classes
{
    public static class CSVclass
    {
        private const string filePath = @"../../../FileBase.csv";

        public static void AddPerson(Person person)
        {
            using (StreamWriter sw = new StreamWriter(filePath, append: true))
            using (CsvWriter csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(person);
            }

            Console.WriteLine("Dodano osobe.");
        }

        public static void ReadAndDisplayDataFromCsv()
        {
            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                List<Person> records = csv.GetRecords<Person>().ToList();
                Console.WriteLine("\nDane odczytane z pliku CSV:\n");
                foreach (var person in records)
                {
                    Console.WriteLine($"Imię: {person.FirstName},\n" +
                        $"Nazwisko: {person.LastName},\n" +
                        $"Pesel: {person.Pesel},\n" +
                        $"Ulica: {person.Address.Street},\n" +
                        $"Miasto: {person.Address.City}, \n" +
                        $"Kod pocztowy: {person.Address.PostalCode}, \n" +
                        $"Kraj: {person.Address.Country}\n" +
                        $"Email: {person.Email}\n");
                }
            }
        }

        public static void DeletePerson(string? searchItem)
        {
            if (string.IsNullOrEmpty(searchItem))
            {
                throw new RecordNotFoundException("Nie podales(-as) imienia i nazwiska");
            }
            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csvr = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                bool isFound = false;
                List<Person> records = csvr.GetRecords<Person>().ToList();
                foreach (Person record in records)
                {
                    if (record.Pesel == searchItem)
                    {
                        records.Remove(record);
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    throw new RecordNotFoundException("Nie znaleziono rekordu.");
                }
                else
                {
                    sr.Close();
                    using (StreamWriter sw = new StreamWriter(filePath))
                    using (CsvWriter csvw = new CsvWriter(sw, CultureInfo.InvariantCulture))
                    {
                        csvw.WriteRecords(records);
                    }
                    Console.Clear();
                    Console.WriteLine("Usunieto osobe.");
                }
            }
        }

        public static void ModifyPerson(string? searchItem)
        {
            if (string.IsNullOrEmpty(searchItem))
            {
                throw new RecordNotFoundException("Nie podales(-as) imienia i nazwiska");
            }
            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csvr = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                bool isFound = false;
                List<Person> records = csvr.GetRecords<Person>().ToList();
                int personId = 0;
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].Pesel == searchItem)
                    {
                        personId = i;
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    throw new RecordNotFoundException("Nie znaleziono rekordu.");
                }
                else
                {
                    bool isEnd = false;

                    while (!isEnd)
                    {
                        sr.Close();
                        Console.WriteLine("Wpisz numer atrybutu ktory chcesz modyfikowac:\n" +
                            "1. Imie\n" +
                            "2. Nazwisko\n" +
                            "3. Ulica\n" +
                            "4. Miasto\n" +
                            "5. Kod pocztowy\n" +
                            "6. Kraj\n" +
                            "7. Pesel\n" +
                            "8. Email\n" +
                            "9. Zakoncz modyfikacje");
                        try
                        {
                            int result = Convert.ToInt32(Console.ReadLine());
                            string oldValue = string.Empty;
                            switch (result)
                            {
                                case 1:
                                    oldValue = records[personId].FirstName;
                                    break;
                                case 2:
                                    oldValue = records[personId].LastName;
                                    break;
                                case 3:
                                    oldValue = records[personId].Address.Street;
                                    break;
                                case 4:
                                    oldValue = records[personId].Address.City;
                                    break;
                                case 5:
                                    oldValue = records[personId].Address.PostalCode;
                                    break;
                                case 6:
                                    oldValue = records[personId].Address.Country;
                                    break;
                                case 7:
                                    oldValue = records[personId].Pesel;
                                    break;
                                case 8:
                                    oldValue = records[personId].Email;
                                    break;
                                case 9:
                                    isEnd = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Zle podano opcje");
                                    break;
                            }
                            if (result != 9)
                            {
                                Console.WriteLine($"Wpisz nowa wartosc (Stara warotsc: {oldValue})");
                                string newValue = Console.ReadLine();
                                switch (result)
                                {
                                    case 1:
                                        records[personId].CheckNullOrEmpty(newValue);
                                        records[personId].FirstName = newValue;
                                        break;
                                    case 2:
                                        records[personId].CheckNullOrEmpty(newValue);
                                        records[personId].LastName = newValue;
                                        break;
                                    case 3:
                                        records[personId].CheckNullOrEmpty(newValue);
                                        records[personId].Address.Street = newValue;
                                        break;
                                    case 4:
                                        records[personId].Address.City = newValue;
                                        break;
                                    case 5:
                                        records[personId].CheckNullOrEmpty(newValue);
                                        records[personId].Address.PostalCode = newValue;
                                        break;
                                    case 6:
                                        records[personId].CheckNullOrEmpty(newValue);
                                        records[personId].Address.Country = newValue;
                                        break;
                                    case 7:
                                        records[personId].CheckNullOrEmpty(newValue);
                                        records[personId].CheckPesel(newValue);
                                        records[personId].Pesel = newValue;
                                        break;
                                    case 8:
                                        records[personId].CheckNullOrEmpty(newValue);
                                        records[personId].CheckEmail(newValue);
                                        records[personId].Email = newValue;
                                        break;
                                }
                            }
                            Console.Clear();
                        }
                        catch (FormatException ex)
                        {
                            Console.Clear();
                            Console.WriteLine(ex.Message);
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
                    }
                    using (StreamWriter sw = new StreamWriter(filePath))
                    using (CsvWriter csvw = new CsvWriter(sw, CultureInfo.InvariantCulture))
                    {
                        csvw.WriteRecords(records);
                    }
                    Console.Clear();
                    Console.WriteLine("Modyfikowano osobe.");
                }
            }
        }
    }
}
