using ConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Address? Address { get; set; }
        public string? Pesel { get; set; }
        public string? Email { get; set; }

        public Person(string? FirstName, string? LastName, Address? Address, string? Pesel, string? Email)
        {
            CheckNullOrEmptyParams(FirstName, LastName, Address, Pesel);
            CheckEmail(Email);
            CheckPesel(Pesel);
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.Pesel = Pesel;
            this.Email = Email;
        }

        private void CheckNullOrEmptyParams(string? firstName, string? lastName, Address? address, string? pesel)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(pesel) || address is null)
            {
                throw new ArgumentNullException();
            }
        }
        public void CheckNullOrEmpty(string? item)
        {
            if (string.IsNullOrEmpty(item))
            {
                throw new ArgumentNullException();
            }
        }

        public void CheckEmail(string? email)
        {
            if (!email.Contains('@'))
            {
                throw new EmailException("Email musi zawierac znak \"@\".");
            }
        }

        public void CheckPesel(string? pesel)
        {
            if (pesel.Length != 11)
            {
                throw new PeselException("Dlugosc pesela ma byc 11 znakow.");
            }

            if (!new Regex("^[0-9]+$").IsMatch(pesel))
            {
                throw new PeselException("Pesel ma zawierac tylko cyfry.");
            }
        }
    }
}
