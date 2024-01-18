using ConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public class DBclass
    {
        private const string connectionStr = "Data source=DESKTOP-G7VL8PD\\SQLEXPRESS;Initial catalog=Lab7_prog;Integrated Security=True";

        // SQL Queries
        private const string checkExistsPeopleTableQuery = @"select case when exists((select * from information_schema.tables where table_name = 'People')) then 1 else 0 end";
        private const string createPeopleTableQuery = @"
                                                    create table People(
                                                    Id int primary key identity,
                                                    FirstName nvarchar(30),
                                                    LastName nvarchar(40),
                                                    Street nvarchar(50),
                                                    City nvarchar(20),
                                                    PostalCode nvarchar(20),
                                                    Country nvarchar(20),
                                                    Pesel nvarchar(11),
                                                    Email nvarchar(30)
                                                    )";
        private const string selectAllPeopleQuery = @"select * from People";
        List<Person> basicPeople = new List<Person>() {
            new Person("Oleksandr", "Lobchenko", new Address("Mikołajczyka 12/93", "Rzeszów", "32-654", "Polska"), "01234567890", "alexlobchenko00@gmail.com"),
            new Person("Ivan", "Lobchenko", new Address("Illenka 7/30", "Cherkasy", "56-606", "Ukraina"), "09876543210", "ivan@gmail.com"),
            new Person("Nie", "Wiem", new Address("Gdzieś", "Tam", "43-765", "Polska"), "87656534217", "ktoś@gmail.com")
        };

        public DBclass()
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                bool exists = false;
                connection.Open();
                using (SqlCommand checkExistsPeopleTable = new SqlCommand(checkExistsPeopleTableQuery, connection))
                {
                    exists = (int)checkExistsPeopleTable.ExecuteScalar() == 1;
                }

                if (!exists)
                {
                    using (SqlCommand createPeopleTablecommand = new SqlCommand(createPeopleTableQuery, connection))
                    {
                        try
                        {
                            createPeopleTablecommand.ExecuteNonQuery();
                            Console.WriteLine("Tabela People utworzona.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Błąd przy tworzeniu tabeli: {ex.Message}");
                        }
                    }
                    for (int i = 0; i < basicPeople.Count; i++)
                    {
                        string insertBasicPeopleQuery = $@"insert into People values('{basicPeople[i].FirstName}',
                                                            '{basicPeople[i].LastName}',
                                                            '{basicPeople[i].Address.Street}',
                                                            '{basicPeople[i].Address.City}',
                                                            '{basicPeople[i].Address.PostalCode}',
                                                            '{basicPeople[i].Address.Country}',
                                                            '{basicPeople[i].Pesel}',
                                                            '{basicPeople[i].Email}'
                                                            )";
                        using (SqlCommand insertBasicPeopleCommand = new SqlCommand(insertBasicPeopleQuery, connection))
                        {
                            try
                            {
                                insertBasicPeopleCommand.ExecuteNonQuery();
                                Console.WriteLine("Bazowy rekord zostal dodany.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Błąd przy dodaniu rekordow: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }

        public void ShowAllRecords()
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                using (SqlCommand selectAllPeopleCommand = new SqlCommand(selectAllPeopleQuery, connection))
                using (SqlDataReader reader = selectAllPeopleCommand.ExecuteReader())
                {
                    Console.WriteLine("Dane odczytane z bazy danych:\n");
                    while (reader.Read())
                    {
                        string id = reader["Id"].ToString();
                        string firstName = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        string street = reader["Street"].ToString();
                        string city = reader["City"].ToString();
                        string postalCode = reader["PostalCode"].ToString();
                        string country = reader["Country"].ToString();
                        string pesel = reader["Pesel"].ToString();
                        string email = reader["Email"].ToString();

                        Console.WriteLine($"Id: {id}\n" +
                            $"Imię: {firstName},\n" +
                            $"Nazwisko: {lastName},\n" +
                            $"Pesel: {pesel},\n" +
                            $"Ulica: {street},\n" +
                            $"Miasto: {city}, \n" +
                            $"Kod pocztowy: {postalCode}, \n" +
                            $"Kraj: {country}\n" +
                            $"Email: {email}\n");
                    }
                }
            }
        }

        public void DeletePerson(string? searchItem)
        {
            if (string.IsNullOrEmpty(searchItem))
            {
                throw new RecordNotFoundException("Nie podales(-as) imienia i nazwiska");
            }

        }
    }
}
