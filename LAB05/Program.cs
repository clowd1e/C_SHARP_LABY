using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Zadanie 1
            //StringLength("I don't feel well");
            //try
            //{
            //    StringLength(null);
            //}
            //catch (ArgumentNullException ex)
            //{
            //    Console.WriteLine(ex.StackTrace);
            //}

            //try
            //{
            //    StringLength(null);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.StackTrace);
            //}


            // Zadanie 2
            //try
            //{
            //    NewRandomExceptions();
            //}
            //catch (FirstCustomException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (SecondCustomException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (ThirdCustomException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            // Zadanie 3
            //SomeClass someClassObj = new SomeClass();
            //try
            //{
            //    someClassObj.CanThrowException();
            //    someClassObj.CanThrowException();
            //    someClassObj.CanThrowException();
            //    someClassObj.CanThrowException();
            //    someClassObj.CanThrowException();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"Exception was thrown at line {new StackTrace(e, true).GetFrame(1).GetFileLineNumber()}");
            //}

            // Zadanie 4
            //try
            //{
            //    object obj = null;
            //    object newObj = CopyObject(obj);
            //}
            //catch (ArgumentNullException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            // Zadanie 5
            //Person person = new Person("Oleksandr", "Lobchenko", 23, 18);
            //Person person1 = (Person)person.Clone();

            //Person nullPerson = null;
            //Person copyNullPerson = (Person)person.Clone();

            // Zadanie 6
            bool taskFinished = false;
            var list = new MyList<int>();
            while (!taskFinished)
            {
                Console.WriteLine("Wybierz opcje\n" +
                    "1. Dodaj element na koncu\n" +
                    "2. Wstaw element na indeksie\n" +
                    "3. Usun element\n" +
                    "4. Usun element na indeksie\n" +
                    "5. Wypisz liczby parzyste\n" +
                    "6. Zakoncz program");
                string option = Console.ReadLine();
                int optionInt = 0;
                try
                {
                    optionInt = Convert.ToInt32(option);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    taskFinished = true;
                }
                switch (optionInt)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Wpisz liczbe calkowita:");
                        int num1 = 0;
                        try
                        {
                            num1 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        list.Add(num1);
                        PrintListElem(list);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Wpisz liczbe calkowita:");
                        int num2 = 0;
                        try
                        {
                            num2 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        Console.WriteLine("Wpisz indeks:");
                        int index2 = 0;
                        try
                        {
                            index2 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        try
                        {
                            list.Insert(index2, num2);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        PrintListElem(list);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Wpisz liczbe do usuniencia:");
                        int num3 = 0;
                        try
                        {
                            num3 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        if (list.Remove(num3))
                        {
                            Console.WriteLine("Usuninieto element");
                        }
                        else
                        {
                            Console.WriteLine("Element nie znaleziony");
                        }
                        PrintListElem(list);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Wpisz indeks:");
                        int index4 = 0;
                        try
                        {
                            index4 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        if (list.RemoveAt(index4))
                        {
                            Console.WriteLine("Usunieto element");
                        }
                        else
                        {
                            Console.WriteLine("Indeks zostal podany zle");
                        }
                        PrintListElem(list);
                        break;
                    case 5:
                        Console.Clear();
                        PrintEvenNumbers(list);
                        break;
                    case 6:
                        taskFinished = true;
                        break;
                    default:
                        Console.WriteLine("Opcja ma byc w zakresie od 1 do 6!");
                        break;
                }
            }
        }

        public static void PrintListElem<T>(MyList<T> list)
        {
            Console.Write("List: ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + (i == list.Count - 1 ? "" : ", "));
            }
            Console.WriteLine();
        }

        public static void PrintEvenNumbers(MyList<int> list)
        {
            Console.Write("Liczby parzyste: ");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    Console.Write(list[i] + (i == list.Count - 1 ? "" : ", "));
                }
            }
            Console.WriteLine();
        }

        public static object CopyObject(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), "Cloning object is null");
            }
            return obj.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(obj, null);
        }

        public static void StringLength(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException();
            }
            Console.WriteLine($"Dlugosc napisu: {str.Length}");
        }

        public static void NewRandomExceptions()
        {
            int i = new Random().Next(1, 4);
            switch (i)
            {
                case 1:
                    throw new FirstCustomException("First custom exception");
                case 2:
                    throw new SecondCustomException("Second custom exception");
                case 3:
                    throw new ThirdCustomException("Third custom exception");
            }
        }
    }
    class FirstCustomException : Exception
    {
        public FirstCustomException(string message) : base(message) { }
    }
    class SecondCustomException : Exception
    {
        public SecondCustomException(string message) : base(message) { }
    }
    class ThirdCustomException : Exception
    {
        public ThirdCustomException(string message) : base(message) { }
    }
    public class SomeClass
    {
        public void CanThrowException()
        {
            if (new Random().Next(5) == 0) throw new Exception();
        }
    }

    public class Person : ICloneable
    {
        public Person(string firstName, string surName, int id, int age)
        {
            FirstName = firstName;
            SurName = surName;
            Id = id;
            Age = age;
        }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
