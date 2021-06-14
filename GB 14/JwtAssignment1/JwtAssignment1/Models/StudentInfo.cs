using System;
using System.Collections.Generic;

namespace JwtAssignment1.Models
{
    public partial class StudentInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Skills { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public GenderMaster GenderNavigation { get; set; }
    }
}
