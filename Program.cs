using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Xml.Linq;
using String = System.String;

namespace Library_Management_System
{
    class Program
    {
        static void Main()
        {
            Library lib = new Library();
            Console.WriteLine("Welcome to Indian Library");

            while (true)
            {
                Console.WriteLine("Choose Your Operation\n1. Book \n2. Member \n3. Issues \n4. Exit");
                int operation = Convert.ToInt32(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        BookOperations(lib);
                        break;
                    case 2:
                        MemberOperations(lib);
                        break;
                    case 3:
                        IssueOperations(lib);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Choose a valid operation");
                        break;
                }
            }
        }

        static void BookOperations(Library lib)
        {
            while (true)
            {
                Console.WriteLine("\n1. Add Book to the Library\n2. Retrieve a particular book by its UID\n3. Retrieve book by its name\n4. Retrieve all books\n5. Retrieve All Available Books\n6. Update book\n7. Exit");
                int bookOperation = Convert.ToInt32(Console.ReadLine());

                switch (bookOperation)
                {
                    case 1:
                        Console.WriteLine("Enter Book Title:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter Book Author:");
                        string author = Console.ReadLine();
                        lib.AddBook(title, author);
                        break;
                    case 2:
                        Console.WriteLine("Enter Book UID:");
                        string bookId = Console.ReadLine();
                        var book = lib.RetrieveBookById(bookId);
                        if (book != null)
                            Console.WriteLine($"Book: {book.Title}, {book.Author}");
                        else
                            Console.WriteLine("Book not found.");
                        break;
                    case 3:
                        Console.WriteLine("Enter Book Name:");
                        string bookName = Console.ReadLine();
                        var booksByName = lib.RetrieveBooksByName(bookName);
                        foreach (var b in booksByName)
                        {
                            Console.WriteLine($"{b.Title}, {b.Author}");
                        }
                        break;
                    case 4:
                        var allBooks = lib.RetrieveAllBooks();
                        foreach (var b in allBooks)
                        {
                            Console.WriteLine($"{b.Title}, {b.Author}");
                        }
                        break;
                    case 5:
                        var availableBooks = lib.RetrieveAvailableBooks();
                        foreach (var b in availableBooks)
                        {
                            Console.WriteLine($"{b.Title}, {b.Author}");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter Book UID:");
                        string updateId = Console.ReadLine();
                        Console.WriteLine("Enter New Title:");
                        string newTitle = Console.ReadLine();
                        Console.WriteLine("Enter New Author:");
                        string newAuthor = Console.ReadLine();
                        lib.UpdateBook(updateId, newTitle, newAuthor);
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Choose a valid operation.");
                        break;
                }
            }
        }

        static void MemberOperations(Library lib)
        {
            while (true)
            {
                Console.WriteLine("1. Add new member\n2. Retrieve member by UID\n3. Get all members\n4. Update member\n5. Exit");
                int memberOperation = Convert.ToInt32(Console.ReadLine());

                switch (memberOperation)
                {
                    case 1:
                        Console.WriteLine("Enter Member UID:");
                        string uid = Console.ReadLine();
                        Console.WriteLine("Enter Member Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Date of Birth (yyyy-mm-dd):");
                        DateTime dob = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Email:");
                        string email = Console.ReadLine();
                        lib.AddMember(new Member(uid, name, dob, email));
                        break;
                    case 2:
                        Console.WriteLine("Enter Member UID:");
                        uid = Console.ReadLine();
                        var member = lib.GetMemberByUId(uid);
                        if (member != null)
                            Console.WriteLine($"Member: {member.Name}, {member.Email}");
                        else
                            Console.WriteLine("Member not found.");
                        break;
                    case 3:
                        var members = lib.GetAllMembers();
                        foreach (var m in members)
                        {
                            Console.WriteLine($"{m.Name}, {m.Email}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Member UID:");
                        uid = Console.ReadLine();
                        Console.WriteLine("Enter New Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter New Date of Birth (yyyy-mm-dd):");
                        dob = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter New Email:");
                        email = Console.ReadLine();
                        lib.UpdateMember(new Member(uid, name, dob, email));
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Choose a valid operation.");
                        break;
                }
            }
        }

        static void IssueOperations(Library lib)
        {
            while (true)
            {
                Console.WriteLine("1. Issue Book\n2. Get Issue by UID\n3. Update Issue\n4. Exit");
                int issueOperation = Convert.ToInt32(Console.ReadLine());

                switch (issueOperation)
                {
                    case 1:
                        Console.WriteLine("Enter Issue UID:");
                        string issueUid = Console.ReadLine();
                        Console.WriteLine("Enter Book UID:");
                        string bookId = Console.ReadLine();
                        Console.WriteLine("Enter Member UID:");
                        string memberId = Console.ReadLine();
                        Console.WriteLine("Enter Issue Date (yyyy-mm-dd):");
                        DateTime issueDate = DateTime.Parse(Console.ReadLine());
                        lib.IssueBook(new Issue(issueUid, bookId, memberId, issueDate, null));
                        break;
                    case 2:
                        Console.WriteLine("Enter Issue UID:");
                        issueUid = Console.ReadLine();
                        var issue = lib.GetIssueByUId(issueUid);
                        if (issue != null)
                            Console.WriteLine($"Issue: BookID={issue.BookId}, MemberID={issue.MemberId}, IssueDate={issue.IssueDate}, ReturnDate={issue.ReturnDate}, IsReturned={issue.IsReturned}");
                        else
                            Console.WriteLine("Issue not found.");
                        break;
                    case 3:
                        Console.WriteLine("Enter Issue UID:");
                        issueUid = Console.ReadLine();
                        Console.WriteLine("Enter Book UID:");
                        bookId = Console.ReadLine();
                        Console.WriteLine("Enter Member UID:");
                        memberId = Console.ReadLine();
                        Console.WriteLine("Enter Issue Date (yyyy-mm-dd):");
                        issueDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Return Date (yyyy-mm-dd) or leave empty:");
                        string returnDateInput = Console.ReadLine();
                        DateTime? returnDate = string.IsNullOrEmpty(returnDateInput) ? (DateTime?)null : DateTime.Parse(returnDateInput);
                        bool isReturned = returnDate.HasValue;
                        lib.UpdateIssue(new Issue(issueUid, bookId, memberId, issueDate, returnDate, isReturned));
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Choose a valid operation.");
                        break;
                }
            }

        }
    }



}


