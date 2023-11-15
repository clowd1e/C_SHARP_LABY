using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Student : Person
    {
        public string School { get; set; }
        public bool CanGoHomeAlone { get; set; }
        public void SetSchool(string school) { School = school; }
        public void ChangeSchool(string school) { SetSchool(school); }
        public void SetCanGoHomeAlone(bool permision) { CanGoHomeAlone = permision; }

        public override bool CanGoAloneToHome(DateTime dateToCheck) => GetAge(dateToCheck) >= 12 || CanGoHomeAlone;
        public override string GetEducationInfo(DateTime dateToCheck) => $"{GetFullName()} sie uczy w szkole {School}, ma {GetAge(dateToCheck)} lat, {(CanGoAloneToHome(dateToCheck) ? "moze" : "nie moze")} sam wracac do domu.";
    }
}
