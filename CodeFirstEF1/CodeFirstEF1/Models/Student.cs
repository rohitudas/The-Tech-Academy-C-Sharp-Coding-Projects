using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstEF1.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public Grade Grade { get; set; }
    }
}