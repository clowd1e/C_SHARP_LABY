using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Reader : Person
    {
        private Book[] readBooks;

        public Reader(string firstName, string lastName, int age, Book[] readBooks) : base(firstName, lastName, age)
        {
            this.readBooks = readBooks;
        }

        public string ViewBook()
        {
            string result = "Przeczytane książki: \n";
            for (int i = 0; i < readBooks.Length; i++)
            {
                if (i == readBooks.Length - 1)
                {
                    result += readBooks[i].Title;
                }
                else
                {
                    result += (readBooks[i].Title + ", ");
                }
            }
            return result;
        }

        public override string View()
        {
            return base.View() + " " + ViewBook();
        }
    }
}
