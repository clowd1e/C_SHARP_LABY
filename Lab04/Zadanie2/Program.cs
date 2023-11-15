namespace Zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Today;

            Console.WriteLine("TEST:\n");
            Student student = new Student { SetFirstName = "Maksym", SetLastName = "Kamanin", SetPesel = "04322434558", School = "Numer 21", CanGoHomeAlone = false };
            Console.WriteLine(student.GetFullName());
            Console.WriteLine(student.GetAge(today));
            Console.WriteLine(student.GetGender());
            Console.WriteLine(student.GetEducationInfo(today));

            Console.WriteLine("\nZadanie 2:\n");
            Student student1 = new Student { SetFirstName = "Kacper", SetLastName = "Brzuch", SetPesel = "10301162752", School = "numer 21"};
            Student student2 = new Student { SetFirstName = "Olena", SetLastName = "Dachowska", SetPesel = "16301849341", School = "numer 21" };
            Student student3 = new Student { SetFirstName = "Patrycja", SetLastName = "Kabala", SetPesel = "17291291288", School = "numer 21", CanGoHomeAlone = true };
            Student student4 = new Student { SetFirstName = "Oleh", SetLastName = "Pabich", SetPesel = "08311439537", School = "numer 21" };
            Student student5 = new Student { SetFirstName = "Hubert", SetLastName = "Mak", SetPesel = "15312576532", School = "numer 22"};

            Teacher teacher = new Teacher {
                SetFirstName = "Rafal",
                SetLastName = "Lacek",
                SetPesel = "89053195549",
                School = "numer 21",
                ScienceDegree = "Doktor Habilitowany",
                Students = new List<Student> { student1, student2, student3, student4, student5 }
            };

            teacher.WhichStudentCanGoHomeAlone(today);

        }
    }

}
