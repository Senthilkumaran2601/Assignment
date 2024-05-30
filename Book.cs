using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class Book
    {
        public string Id { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsIssued { get; set; }

        public Book(string id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
            IsIssued = false;
        }
    }
}


