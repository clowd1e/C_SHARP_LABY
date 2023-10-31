using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Date
    {
        private DateTime date;
        private string opis;

        public Date(DateTime date, string opis)
        {
            this.date = date;
            this.opis = opis;
        }
        public DateTime GetNowDate() => DateTime.Now;
        public DateTime GetNowDateOneWeekAfter() => DateTime.Now.AddDays(7);
        public DateTime GetNowDateOneWeekBefore() => DateTime.Now.AddDays(-7);

        private string FormatTime(int time) => Convert.ToString(time).Length == 1 ? "0" + time : Convert.ToString(time);
        public void ShowDate()
        {
            string day = FormatTime(date.Day);
            string month = FormatTime(date.Month);
            string hour = FormatTime(date.Hour);
            string minutes = FormatTime(date.Minute);
            Console.WriteLine($"W date {day}.{month}.{date.Year} o godzinie {hour}:{minutes} masz opis \"{opis}\"");
        }
    }
}
