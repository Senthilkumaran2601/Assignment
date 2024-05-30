using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class Library
    {
        private List<Book> books;
        private List<Member> members;
        private List<Issue> issues;

        private int nextBookId;

        public Library()
        {
            books = new List<Book>();
            members = new List<Member>();
            issues = new List<Issue>();
            nextBookId = 1;
        }

        public BookDTO AddBook(string title, string author)
        {
            var book = new Book(nextBookId++.ToString(), title, author);
            books.Add(book);
            return new BookDTO(book);
        }

        public BookDTO RetrieveBookById(string id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            return book != null ? new BookDTO(book) : null;
        }

        public List<BookDTO> RetrieveBooksByName(string name)
        {
            return books.Where(b => b.Title.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                        .Select(b => new BookDTO(b)).ToList();
        }

        public List<BookDTO> RetrieveAllBooks()
        {
            return books.Select(b => new BookDTO(b)).ToList();
        }

        public List<BookDTO> RetrieveAvailableBooks()
        {
            return books.Where(b => !b.IsIssued)
                        .Select(b => new BookDTO(b)).ToList();
        }

        public void AddMember(Member member)
        {
            if (members.Any(m => m.UId == member.UId))
            {
                Console.WriteLine("Member with this UID already exists.");
            }
            else
            {
                members.Add(member);
            }
        }

        public bool UpdateBook(string id, string title, string author)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;
            book.Title = title;
            book.Author = author;
            return true;
        }

        public MemberDTO GetMemberByUId(string id)
        {
            var member = members.FirstOrDefault(m => m.UId == id);
            return member != null ? new MemberDTO(member) : null;
        }

        public List<MemberDTO> GetAllMembers()
        {
            return members.Select(m => new MemberDTO(m)).ToList();
        }

        public void UpdateMember(Member member)
        {
            var existingMember = members.FirstOrDefault(m => m.UId == member.UId);
            if (existingMember != null)
            {
                existingMember.Name = member.Name;
                existingMember.DateOfBirth = member.DateOfBirth;
                existingMember.Email = member.Email;
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        public void IssueBook(Issue issue)
        {
            var book = books.FirstOrDefault(b => b.Id == issue.BookId);
            if (book != null && !book.IsIssued)
            {
                issues.Add(issue);
                book.IsIssued = true;
            }
            else
            {
                Console.WriteLine("Book is already issued or not found.");
            }
        }

        public IssueDTO GetIssueByUId(string id)
        {
            var issue = issues.FirstOrDefault(i => i.UId == id);
            return issue != null ? new IssueDTO(issue) : null;
        }

        public void UpdateIssue(Issue issue)
        {
            var existingIssue = issues.FirstOrDefault(i => i.UId == issue.UId);
            if (existingIssue != null)
            {
                existingIssue.BookId = issue.BookId;
                existingIssue.MemberId = issue.MemberId;
                existingIssue.IssueDate = issue.IssueDate;
                existingIssue.ReturnDate = issue.ReturnDate;
                existingIssue.IsReturned = issue.IsReturned;

                var book = books.FirstOrDefault(b => b.Id == issue.BookId);
                if (book != null)
                {
                    book.IsIssued = !issue.IsReturned;
                }
            }
            else
            {
                Console.WriteLine("Issue not found.");
            }
        }
    }
}


