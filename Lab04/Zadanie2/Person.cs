using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    abstract class Person
    {
        private string firstName;
        private string lastName;
        private string pesel;

        public string SetFirstName { set { firstName = value; } }
        public string SetLastName { set { lastName = value; } }
        public string SetPesel { set { pesel = value; } }
        
        private string AddZero(string value) => value.Length == 1 ? "0" + value : value;
        private string GetProperMonth(string value) => Convert.ToInt32(value) > 20 ? (Convert.ToInt32(value) - 20).ToString() : value;
        private string GetYear(string year, int decade) => decade == 20 ? "19" + year : "20" + year;
        public int GetAge(DateTime dateToCheck)
        {
            int result = 0;
            int decade = 20;
            if (Convert.ToInt32(pesel[2..4]) > 20)
            {
                decade = 21;
            }
            string buildDate = $"{AddZero(pesel[4..6])}/{AddZero(GetProperMonth(pesel[2..4]))}/{GetYear(pesel[0..2], decade)}";
            DateTime birth = DateTime.ParseExact(buildDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            result = dateToCheck.Year - birth.Year;
            if (dateToCheck.Month < birth.Month)
            {
                result--;
            }
            else if (dateToCheck.Month == birth.Month && dateToCheck.Day < birth.Day)
            {
                result--;
            }

            return result;
        }
        public string GetGender() => pesel[9] % 2 == 0 ? "Kobieta" : "Mezczyzna";
        public abstract string GetEducationInfo(DateTime dateToCheck);
        public string GetFullName() => $"{firstName} {lastName}";
        public abstract bool CanGoAloneToHome(DateTime dateToCheck);
    }
}
