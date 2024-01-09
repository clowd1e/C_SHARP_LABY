using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CountryStat
    {
        public Dictionary<string, string> Indicator { get; set; }
        public Dictionary<string, string> Country { get; set; }
        public string Value { get; set; }
        public string Decimal { get; set; }
        public string Date { get; set; }
    }
}
