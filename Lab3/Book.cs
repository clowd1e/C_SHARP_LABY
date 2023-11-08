using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Book
    {
        private string title;
        private Person author;
        private DateTime publicDate;

        public string Title { get { return title; } }

        public Book(string title, Person author, DateTime publicDate)
        {
            this.title = title;
            this.author = author;
            this.publicDate = publicDate;
        }

        public string View() => $"Tytuł: {title}\nAutor: {author.View()}\nData publikacji: {publicDate.ToShortDateString()}";
    }
}
