using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagmentSystem.Models;

namespace StudentManagmentSystem.Controllers
{
    public class StudentController : Controller
    {
        private string _connectionString = @"Data Source=DESKTOP-6TTF900\SQLEXPRESS;Initial Catalog = School; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET: Student
        public ActionResult Index()
        {
            string queryString = "Select * From Students";
            // query code that selects from the dbo.Students table
            List<Student> students = new List<Student>();
            // creates list of Student which is a model that has the id, FirstName, LastName properties.
            using (SqlConnection connection = new SqlConnection(_connectionString))

            // code used to connect to the sql server making the property 
            // connection which is a SqlConnection object.

            {
                SqlCommand command = new SqlCommand(queryString, connection);
                // object command that takes in a string and, SqlConnection as paramters.
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                // creates an object that is of SqlDataReader type that is a command.executeReader()
                while (reader.Read())
                // reads each row
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(reader["Id"]);
                    // grabs the sql int in ID and converts into CS int
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    // grabs sql string and converts it to CS string
                    students.Add(student);
                    //adds it the list created earlier in Index()
                }
            }
            return View(students);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            string queryString = @"INSERT into Students (FirstName, LastName) Values (@FirstName, @LastName)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@LastName", SqlDbType.VarChar);

                command.Parameters["@FirstName"].Value = student.FirstName;
                command.Parameters["@LastName"].Value = student.LastName;

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }

            return RedirectToAction("Index");


        }
        public ActionResult Details(int id)
        {
            string queryString = "Select * From Student where id = @id";
            Student student = new Student();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.Int);

                command.Parameters["@id"].Value = id;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                }

                connection.Close();

            }

            return View(student);
        }

        public ActionResult Edit(int id)
        {
            string queryString = "Select * From Students where id = @id";
            Student student = new Student();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.Int);

                command.Parameters["@id"].Value = id;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                }

                connection.Close();

            }

            return View(student);
        }


        [HttpPost]
        public ActionResult Edit(Student student)
        {
            string queryString = @"INSERT into Students (FirstName, LastName) Values (@FirstName, @LastName)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@LastName", SqlDbType.VarChar);
                command.Parameters.Add("@Id", SqlDbType.VarChar);

                command.Parameters["Id"].Value = student.Id;
                command.Parameters["@FirstName"].Value = student.FirstName;
                command.Parameters["@LastName"].Value = student.LastName;

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }

            return RedirectToAction("Index");

        }
    }
}