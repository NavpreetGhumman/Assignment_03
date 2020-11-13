using Assignment_03Project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace Assignment_03Project.Controllers
{
    public class TeacherDataController : ApiController
    {
        //The database context class which allow us to access the MySQL database.
        private SchoolDbContext school = new SchoolDbContext();

        //The controller will access the teachers table of our school database
        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <example> Get api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of all information about teachers
        /// </returns>
        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection Conn = school.AccessDatabase();

            //OPen the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "Select * from teachers";

            // Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teacher Info
            List<Teacher> TeacherInfo = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal salary = (decimal)ResultSet["salary"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.teacherid = TeacherId;
                NewTeacher.teacherfname = TeacherFname;
                NewTeacher.teacherlname = TeacherLname;
                NewTeacher.employeenumber = EmployeeNumber;
                NewTeacher.hiredate = HireDate;
                NewTeacher.salary = salary;

                //Add teachers info to the list
                TeacherInfo.Add(NewTeacher);
            }


            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teacher's Information
            return TeacherInfo;
        }


        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = school.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers where Teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal salary = (decimal)ResultSet["salary"];


                NewTeacher.teacherid = TeacherId;
                NewTeacher.teacherfname = TeacherFname;
                NewTeacher.teacherlname = TeacherLname;
                NewTeacher.employeenumber = EmployeeNumber;
                NewTeacher.hiredate = HireDate:
                NewTeacher.salary = salary;
            }
            return NewTeacher;
        }
    }
}

        

    



