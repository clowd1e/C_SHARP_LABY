using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Student : IStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GetFullName() => $"{FirstName} {LastName}";
        public int CompareTo(IPerson other) => String.Compare(this.LastName, other.LastName);
        public string University { get; set; }
        public string Field { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }

        public virtual string GetFullUniversityName() => $"{GetFullName()} \u2014 {Semester}{Field} {Year} {University}";
    }
}
