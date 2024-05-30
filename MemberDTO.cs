using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class MemberDTO
    {
        public string UId { get; }
        public string Name { get; }
        public DateTime DateOfBirth { get; }
        public string Email { get; }

        public MemberDTO(Member member)
        {
            UId = member.UId;
            Name = member.Name;
            DateOfBirth = member.DateOfBirth;
            Email = member.Email;
        }

    }

}
