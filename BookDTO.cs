using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System

{
    class BookDTO
    {
        public string Id { get; }
        public string Title { get; }
        public string Author { get; }
        public bool IsIssued { get; }

        public BookDTO(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            IsIssued = book.IsIssued;
        }

    }
}


