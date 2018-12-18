using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF1.DAL;
using CodeFirstEF1.Models;

namespace CodeFirstEF1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new SchoolContext())
            {
                string check = "";

                while (check != "no")
                {
                    var temp = new Grade();
                    var stud = new Student();
                    Console.WriteLine("Enter New Student");
                    Console.Write("Name:");
                    stud.StudentName = Console.ReadLine();
                    Console.Write("Height:");
                    stud.Height = Console.ReadLine();
                    Console.Write("Weight:");
                    stud.Weight = Console.ReadLine();
                    Console.Write("What Grade:");
                    temp.GradeName = Console.ReadLine(); 
                    Console.Write("Section:");
                    temp.Section = Console.ReadLine();
                    Console.WriteLine("Saving to db....");
                    db.Students.Add(stud);
                    db.Grades.Add(temp);
                    db.SaveChanges();
                    Console.WriteLine("Success!");
                    Console.WriteLine("Add another student?(yes or no)");
                    check = Console.ReadLine();

                }
                foreach(var student in db.Students)
                {
                    Console.Write(student.StudentID + ". "+student.StudentName+" ");
                    foreach(var grade in db.Grades)
                    {
                        if (student.StudentID == grade.GradeId)
                        {
                            Console.Write("Grade: "+grade.GradeName);
                        }
                    }
                    Console.WriteLine();
                    
                }
                Console.ReadLine();
            }
        }
    }
}
