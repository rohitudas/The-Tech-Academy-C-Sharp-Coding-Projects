using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstEF1.Models;
using System.Data.Entity;
namespace CodeFirstEF1.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}