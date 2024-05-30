using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class Member
    {
        public string UId { get; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public Member(string uid, string name, DateTime dateOfBirth, string email)
        {
            UId = uid;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
    }

    
}



