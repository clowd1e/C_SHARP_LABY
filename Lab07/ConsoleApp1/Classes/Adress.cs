using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public class Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public Address(string Street, string City, string PostalCode, string Country)
        {
            this.Street = Street;
            this.City = City;
            this.PostalCode = PostalCode;
            this.Country = Country;
        }
    }
}
