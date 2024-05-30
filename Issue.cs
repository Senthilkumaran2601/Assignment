using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class Issue
    {
        public string UId { get; }
        public string BookId { get; set; }
        public string MemberId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }

        public Issue(string uid, string bookId, string memberId, DateTime issueDate, DateTime? returnDate, bool isReturned = false)
        {
            UId = uid;
            BookId = bookId;
            MemberId = memberId;
            IssueDate = issueDate;
            ReturnDate = returnDate;
            IsReturned = isReturned;
        }
    }

}



