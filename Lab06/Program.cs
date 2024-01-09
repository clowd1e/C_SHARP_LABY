using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Zadanie 1
            //string fileName = "../../../textFiles/test.txt";
            //if (!File.Exists(fileName))
            //{
            //    Console.WriteLine("Write your album number:");
            //    string album = Console.ReadLine();
            //    using (StreamWriter sw = File.CreateText(fileName))
            //    {
            //        sw.WriteLine(album);
            //    }
            //}
            //else
            //{
            //    using (StreamReader sr = new StreamReader(fileName))
            //    {
            //        string line = sr.ReadToEnd();
            //        Console.WriteLine($"Numer albumu uzytkownika: {line}");
            //    }
            //}


            // Zadanie 2
            //Console.WriteLine("Type file name: ");
            //string fileName = Console.ReadLine();
            //fileName = $"../../../textFiles/{fileName}.txt";
            //if (File.Exists(fileName))
            //{
            //    using (StreamReader sr = new StreamReader(fileName))
            //    {
            //        string line = sr.ReadToEnd();
            //        Console.WriteLine("File content:");
            //        Console.WriteLine(line);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Failed to find file");
            //}

            // Zadanie 3
            //List<string> pesels = new List<string>();
            //string path = "../../../textFiles/pesel.txt";
            //using (StreamReader sr = new StreamReader(path))
            //{
            //    while (!sr.EndOfStream)
            //    {
            //        pesels.Add(sr.ReadLine());
            //    }
            //}
            //Console.WriteLine($"There are {GetWomenCount(pesels)} women in file");


            // Zadanie 4
            //string dbPath = "../../../textFiles/db.json";
            //string db = new StreamReader(dbPath).ReadToEnd();
            //List<CountryStat> countryStats = JsonConvert.DeserializeObject<List<CountryStat>>(db);
            //Console.WriteLine($"Difference between 1970 and 2000 in India is {FirstMethod(countryStats, 2000, 1970, "IN")}");
            //Console.WriteLine($"Difference between 1965 and 2010 in USA is {FirstMethod(countryStats, 2010, 1965, "US")}");
            //Console.WriteLine($"Difference between 1980 and 2018 in China is {FirstMethod(countryStats, 2000, 1970, "CN")}");
            //try
            //{
            //    GetPopulation(countryStats);
            //    DifferenceBetweenYears(countryStats);
            //    PopulationPercentage(countryStats);
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            // Zadanie 5
            FilePersonRepository personRepository = new FilePersonRepository();
            bool isEnd = false;

            while (!isEnd)
            {
                int? option = Menu();
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        personRepository.ShowAllRecords();
                        break;
                    case 2:
                        personRepository.AddNewRecord();
                        break;
                    case 3:
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Type person's ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            personRepository.Remove(id);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Last person's ID is {personRepository.GetLastIndex()}");
                        break;
                    case 5:
                        Console.Clear();
                        isEnd = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            //personRepository.AddNewRecord();
            ////personRepository.Remove(6);
            //personRepository.ShowAllRecords();
        }

        public static int? Menu()
        {
            Console.WriteLine("Choose option:\n" +
                "1. Show all database records.\n" +
                "2. Add new record to database.\n" +
                "3. Remove record from database by ID.\n" +
                "4. Get last record's index.\n" +
                "5. Exit.");
            int? result = null;
            try
            {
                result = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public static int GetWomenCount(List<string> list)
        {
            int countWomen = 0;
            foreach (string elem in list)
            {
                if (Convert.ToInt32(elem[9]) % 2 == 0)
                {
                    countWomen++;
                }
            }
            return countWomen;
        }
        public static int FirstMethod(List<CountryStat> list, int startYear, int endYear, string countryId)
        {
            int stYr = 0;
            int enYr = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Country["Id"] == countryId && list[i].Date == startYear.ToString())
                {
                    stYr = Convert.ToInt32(list[i].Value);
                }
                if (list[i].Country["Id"] == countryId && list[i].Date == endYear.ToString())
                {
                    enYr = Convert.ToInt32(list[i].Value);
                }
            }
            return stYr - enYr;
        }
        public static void GetPopulation(List<CountryStat> list)
        {
            Console.WriteLine("Type country name: ");
            string countryName = Console.ReadLine();
            Console.WriteLine("Type year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            int? result = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Country["Value"] == countryName && list[i].Date == year.ToString())
                {
                    result = Convert.ToInt32(list[i].Value);
                }
            }
            if (result is null) 
                Console.WriteLine("Failed to find population");
            else
                Console.WriteLine($"Population in {countryName} in {year} year is {result}");
        }
        public static void DifferenceBetweenYears(List<CountryStat> list)
        {
            Console.WriteLine("Type country name: ");
            string countryName = Console.ReadLine();
            Console.WriteLine("Type base year: ");
            int baseYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type comparison year: ");
            int compYear = Convert.ToInt32(Console.ReadLine());
            int? bsYear = null;
            int? cmYear = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Country["Value"] == countryName && list[i].Date == baseYear.ToString() && list[i].Value is not null)
                {
                    bsYear = Convert.ToInt32(list[i].Value);
                }
                if (list[i].Country["Value"] == countryName && list[i].Date == compYear.ToString() && list[i].Value is not null)
                {
                    cmYear = Convert.ToInt32(list[i].Value);
                }
            }
            if (bsYear is null || cmYear is null)
            {
                if (bsYear is null) 
                    Console.WriteLine("Failed to find info about base year");
                if (cmYear is null) 
                    Console.WriteLine("Failed to find info about comparison year");
            }
            else 
                Console.WriteLine($"Result is {bsYear - cmYear}");
        }
        public static void PopulationPercentage(List<CountryStat> list)
        {
            Console.WriteLine("Type country name: ");
            string countryName = Console.ReadLine();
            Console.WriteLine("Type year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            double? yearPop = null;
            double? yearBef = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Country["Value"] == countryName && list[i].Date == year.ToString() && list[i].Value is not null)
                {
                    yearPop = Convert.ToInt32(list[i].Value);
                }
                if (list[i].Country["Value"] == countryName && list[i].Date == (year - 1).ToString() && list[i].Value is not null)
                {
                    yearBef = Convert.ToInt32(list[i].Value);
                }
            }
            if (yearPop is null || yearBef is null)
            {
                if (yearPop is null) 
                    Console.WriteLine("Failed to find info about year");
                if (yearBef is null) 
                    Console.WriteLine("Failed to find info about previous year");
            }
            else
            {
                double? result = yearBef * 100 / yearPop;
                Console.WriteLine($"{yearBef}, {yearPop}");
                Console.WriteLine($"Percentage result between {year} and {year - 1} years is {double.Round(Convert.ToDouble(result), 2)}%");
            }
        }
    }
}
