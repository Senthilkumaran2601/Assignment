using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class IssueDTO
    {
        public string UId { get; }
        public string BookId { get; }
        public string MemberId { get; }
        public DateTime IssueDate { get; }
        public DateTime? ReturnDate { get; }
        public bool IsReturned { get; }

        public IssueDTO(Issue issue)
        {
            UId = issue.UId;
            BookId = issue.BookId;
            MemberId = issue.MemberId;
            IssueDate = issue.IssueDate;
            ReturnDate = issue.ReturnDate;
            IsReturned = issue.IsReturned;
        }

    }
}
