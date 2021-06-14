using System;
using System.Collections.Generic;

namespace JwtAssignment1.Models
{
    public partial class GenderMaster
    {
        public GenderMaster()
        {
            StudentInfo = new HashSet<StudentInfo>();
        }

        public int Id { get; set; }
        public string GenderName { get; set; }

        public ICollection<StudentInfo> StudentInfo { get; set; }
    }
}
