namespace Kalkulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }
        static void MainMenu()
        {
            bool programWorks = true;
            while (programWorks)
            {
                mainView();
                int choice = InputInt();
                switch(choice)
                {
                    case 1: Console.Clear(); TrojmianKwadratowy(); break;
                    case 2: Console.Clear(); CalculatorMenu(); break;
                    case 3: Console.Clear(); TenNums(); break;
                    case 4: Console.Clear(); TwentyNums(); break;
                    case 5: Console.Clear(); InfiniteNums(); break;
                    case 6: Console.Clear(); Sortowanie(); break;
                    case 7: programWorks = false; break;
                    default: Console.WriteLine("Nastapil blad"); break; 
                }
            }
        }
        static void mainView()
        {
            Console.WriteLine("Wybierz jedna funkcje programu: ");
            Console.WriteLine("1 - oblicz trojmian kwadratowy");
            Console.WriteLine("2 - kalkulator");
            Console.WriteLine("3 - tablica z 10-cioma elementami");
            Console.WriteLine("4 - liczby od 0 do 20");
            Console.WriteLine("5 - nieskonczone liczby");
            Console.WriteLine("6 - tablica o n liczb + sortowanie");
            Console.WriteLine("7 - zamknij program");
        }
        static void TrojmianKwadratowy()
        {
            int a = InputInt("Podaj a: ");
            int b = InputInt("Podaj b: ");
            int c = InputInt("Podaj c: ");
            double d = Math.Pow(b, 2) + 4 * a * c;
            Console.WriteLine($"Wyroznik delta wynosi: {d}");
            Console.WriteLine($"Pierwszy pierwiastek wynosi: {(-b + Math.Sqrt(d)) / (2 * a)}");
            Console.WriteLine($"Drugi pierwiastek wynosi: {(-b - Math.Sqrt(d)) / (2 * a)}");
        }

        static void CalculatorMenu()
        {
            bool working = true;
            while (working)
            {
                View();
                int choice = InputInt();
                switch (choice)
                {
                    case 1: Console.Clear(); Suma(); break;
                    case 2: Console.Clear(); Roznica(); break;
                    case 3: Console.Clear(); Iloczyn(); break;
                    case 4: Console.Clear(); Iloraz(); break;
                    case 5: Console.Clear(); Potengowanie(); break;
                    case 6: Console.Clear(); Pierwiastek(); break;
                    case 7: Console.Clear(); Funkcje(); break;
                    case 8: Console.Clear(); working = false; break;
                    default: Console.Clear(); Console.WriteLine("Bledne dane sprobuj jeszcze raz"); break;
                }
            }
        }

        static void View()
        {
            Console.WriteLine("\tKalkulator");
            Console.WriteLine("1 - Suma");
            Console.WriteLine("2 - Roznica");
            Console.WriteLine("3 - Iloczyn");
            Console.WriteLine("4 - Iloraz");
            Console.WriteLine("5 - Potengowanie");
            Console.WriteLine("6 - Pierwiastek kwadratowy");
            Console.WriteLine("7 - Funkcje trygonometryczne");
            Console.WriteLine("8 - Wyjscie");
        }

        static int InputInt(string message = "Wpisz liczbe: ")
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        static (int, int) GetTwoNumbers()
        {
            return (InputInt("Wpisz pierwsza liczbe: "), InputInt("Wpisz druga liczbe: "));
        }

        static void Suma()
        {
            (int, int) nums = GetTwoNumbers();
            Console.WriteLine($"Suma wynosi: {nums.Item1 + nums.Item2}");
        }

        static void Roznica()
        {
            (int, int) nums = GetTwoNumbers();
            Console.WriteLine($"Roznica wynosi: {nums.Item1 - nums.Item2}");
        }

        static void Iloczyn()
        {
            (int, int) nums = GetTwoNumbers();
            Console.WriteLine($"Iloczyn wynosi: {nums.Item1 * nums.Item2}");
        }

        static void Iloraz()
        {
            (int, int) nums = GetTwoNumbers();
            Console.WriteLine($"Suma wynosi: {nums.Item1 / nums.Item2}");
        }

        static void Potengowanie()
        {
            int num = InputInt("Wpisz liczbe do potengowania: ");
            int pot = InputInt("Wpisz potenge: ");
            Console.WriteLine($"Potengowanie wynosi: {Math.Pow(num, pot)}");
        }

        static void Pierwiastek()
        {
            int num = InputInt();
            Console.WriteLine($"Pierwiastek wynosi: {Math.Sqrt(num)}");
        }

        static void Funkcje()
        {
            int a = InputInt("Wpisz kat: ");
            Console.WriteLine($"Sin wynosi: {double.Round(Math.Sin(a * Math.PI / 180), 5)}");
            Console.WriteLine($"Cos wynosi: {double.Round(Math.Cos(a * Math.PI / 180), 5)}");
        }

        static void TenNums()
        {
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = InputInt();
            }
            WyswietlElements(arr);
            WyswietlElements(arr, true);
            WyswietlElementsOIndeksach(arr);
            WyswietlElementsOIndeksach(arr, true);

            // Zadanie 4
            SumaElementow(arr);
            IloczynElementow(arr);
            Srednia(arr);
            Min(arr);
            Max(arr);
        }
        static void WyswietlElements(int[] arr, bool isReversed = false)
        {
            if (isReversed)
            {
                Array.Reverse(arr);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            if (isReversed)
            {
                Array.Reverse(arr);
            }
            Console.WriteLine(!isReversed ? " - wszystkie elementy" : " - wszystkie elementy w odwrotnym porządku");
        }
        static void WyswietlElementsOIndeksach(int[] arr, bool isOdd = false)
        {
            int i = 0;
            if (isOdd)
            {
                i = 1;
            }
            for (; i < arr.Length; i+= 2)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine(!isOdd ? " - wszystkie elementy o parzystych indeksach" : " - wszystkie elementy o nieparzystych indeksach");
        }
        static void SumaElementow(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            Console.WriteLine($"Suma elementow tablicy wynosi: {sum}");
        }
        static void IloczynElementow(int[] arr)
        {
            int product = 1;
            foreach (int i in arr)
            {
                product *= i;
            }
            Console.WriteLine($"Iloczyn elementow tablicy wynosi: {product}");
        }
        static void Srednia(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            Console.WriteLine($"Srednia elementow tablicy wynosi: {sum / arr.Length}");
        }
        static void Min(int[] arr)
        {
            int minElem = arr[0];
            for(int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < minElem)
                {
                    minElem = arr[i];
                }
            }
            Console.WriteLine($"Minimalna wartosc wynosi: {minElem}");
        }
        static void Max(int[] arr)
        {
            int maxElem = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxElem)
                {
                    maxElem = arr[i];
                }
            }
            Console.WriteLine($"Maksymalna wartosc wynosi: {maxElem}");
        }
        static void TwentyNums()
        {
            for (int i = 0; i <= 20; i++)
            {
                if (i == 2 || i == 6 || i == 9 || i == 15 || i == 19)
                {
                    continue;
                }
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void InfiniteNums()
        {
            while (true)
            {
                int a = InputInt();
                if (a < 0)
                {
                    break;
                }
            }
        }
        static void Sortowanie()
        {
            int n = InputInt("Wpisz ilosc elementow");
            int[] ints = new int[n];
            for (int i = 0; i < n; i++)
            {
                ints[i] = InputInt();
            }
            foreach (int i in ints)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(" - tablica przed sortowaniem");
            int k = n - 1;
            while (k >= 1)
            {
                int j = 0;
                while (j < k)
                {
                    if (ints[j] > ints[j + 1])
                    {
                        int temp = ints[j];
                        ints[j] = ints[j + 1];
                        ints[j + 1] = temp;
                    }
                    j++;
                }
                k--;
            }
            foreach (int i in ints)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(" - tablica po sortowaniu");
        }
    }
}