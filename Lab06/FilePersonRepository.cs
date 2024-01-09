using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    public class FilePersonRepository : IPersonRepository
    {
        List<Person>? people;
        const string path = "../../../textFiles/myDb.json";
        public class Person
        {
            public int PersonId { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Pesel { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Address { get; set; }
            public Person(int personId, string? firstName, string? lastName, string? pesel, string? email, string? phoneNumber, string? address)
            {
                PersonId = personId;
                FirstName = firstName;
                LastName = lastName;
                Pesel = pesel;
                Email = email;
                PhoneNumber = phoneNumber;
                Address = address;
            }
            public Person() { }
        }
        public FilePersonRepository()
        {
            string myDb;
            using (StreamReader sw  = new StreamReader(path))
            {
                myDb = sw.ReadToEnd();
            }
            if (myDb.Length == 0)
                people = new List<Person>();
            else
                people = JsonConvert.DeserializeObject<List<Person>>(myDb);
        }
        public void ShowAllRecords()
        {
            foreach (Person person in people)
            {
                Console.WriteLine($"\nPerson Id: {person.PersonId}\n" +
                    $"First name: {person.FirstName}\n" +
                    $"Last name: {person.LastName}\n" +
                    $"Pesel: {person.Pesel}\n" +
                    $"Email: {person.Email}\n" +
                    $"Phone number: {person.PhoneNumber}\n" +
                    $"Address: {person.Address}\n");
            }
        }
        public int GetLastIndex()
        {
            if (people is null || people.Count == 0)
                return 0;
            return people[people.Count - 1].PersonId;
        }
        public bool Remove(int id)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].PersonId == id)
                {
                    people.RemoveAt(i);
                    SerializePeople();
                    return true;
                }
            }
            Console.WriteLine($"Couldn't find person with id {id}");

            return false;
        }
        public void SerializePeople()
        {
            string json = JsonConvert.SerializeObject(people);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(json);
            }
        }
        public void AddNewRecord()
        {
            Person person = new Person() { PersonId = GetLastIndex() + 1};
            Console.WriteLine("Type person's first name:");
            person.FirstName = Console.ReadLine();
            Console.WriteLine("Type person's last name:");
            person.LastName = Console.ReadLine();
            Console.WriteLine("Type person's pesel number:");
            person.Pesel = Console.ReadLine();
            Console.WriteLine("Type person's email:");
            person.Email = Console.ReadLine();
            Console.WriteLine("Type person's phone number:");
            person.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Type person's address:");
            person.Address = Console.ReadLine();

            people.Add(person);
            SerializePeople();
            Console.Clear();
            Console.WriteLine("Successfully added new record");
        }
    }
}
