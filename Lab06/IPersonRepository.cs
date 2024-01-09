using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IPersonRepository
    {
        public class Person
        {
            public int PersonId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Pesel { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
        }
        public void ShowAllRecords();
        public int GetLastIndex();
        public void AddNewRecord();
        public void SerializePeople();
    }
}
