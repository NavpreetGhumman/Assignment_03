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
    public class ClassesDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext school = new SchoolDbContext();

        //This Controller Will access the classes table of our school database.
        /// <summary>
        /// Returns a list of classess taught by different teachers in the system
        /// </summary>
        /// <example>GET api/ClassesData/ListClasses</example>
        /// <returns>
        /// A list of class information
        /// </returns>
        [HttpGet]
        public IEnumerable<Classes> ListClasses()
        {
            //Create an instance of a connection
            MySqlConnection Conn = school.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Authors
            List<Classes> ClassInfo = new List<Classes> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = (int)ResultSet["classid"];
                string ClassCode = ResultSet["classcode"].ToString();
                long TeacherId = (long)ResultSet["teacherid"];
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = ResultSet["classname"].ToString();

                Classes NewClass = new Classes();
                NewClass.classid = ClassId;
                NewClass.classcode = ClassCode;
                NewClass.teacherid = TeacherId;
                NewClass.startdate = StartDate;
                NewClass.finishdate = FinishDate;
                NewClass.classname = ClassName;

                //Add the Author Name to the List
                ClassInfo.Add(NewClass);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Classes names
            return ClassInfo;
        }


        //Get: api/ClassesData/FindSubject/{id}
        [HttpGet]
        public Classes FindSubject(int id)
        {
            Classes Subject = new Classes();

            //Create an instance of a connection
            MySqlConnection Conn = school.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes where teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index

                int ClassId = (int)ResultSet["classid"];
                string ClassCode = ResultSet["classcode"].ToString();
                long TeacherId = (long)ResultSet["teacherid"];
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = ResultSet["classname"].ToString();

                Subject.classid = ClassId;
                Subject.classcode = ClassCode;
                Subject.teacherid = TeacherId;
                Subject.startdate = StartDate;
                Subject.finishdate = FinishDate;
                Subject.classname = ClassName;
            }
            return Subject;
        }
    }
}
