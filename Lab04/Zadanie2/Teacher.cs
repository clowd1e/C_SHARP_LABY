using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Teacher : Student
    {
        public string ScienceDegree { get; set; }
        public List<Student> Students { get; set; }
        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        {
            foreach (Student student in Students)
            {
                if (student.CanGoAloneToHome(dateToCheck))
                {
                    Console.WriteLine(student.GetFullName());
                }
            }
        }
    }
}
