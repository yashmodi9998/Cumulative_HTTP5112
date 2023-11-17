using Cumulative_HTTP5112.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cumulative_HTTP5112.Controllers
{
    public class TeacherDataController : ApiController

    {
        private DBContext DbCon = new DBContext();

        //This Controller Will access the teacher table of our school database.
        /// <summary>
        /// Returns a list of Teacher in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of Teachers (first names and last names)
        /// </returns>
        [HttpGet]
        public IEnumerable<Teacher> ListTeacher()
        {
            //Create an instance of a connection
            MySqlConnection Conn = DbCon.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teacher
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                string HireDate = ResultSet["hiredate"].ToString();
                string Salary = ResultSet["salary"].ToString();


                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;

                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;

                Teachers.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teacher names
            return Teachers;
        }


        /// <summary>
        /// Finds Teacher in the system given an ID
        /// </summary>
        /// <param name="id">The teacher primary key</param>
        /// <returns>A Student object</returns>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = DbCon.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers where teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
          

                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                string HireDate = ResultSet["hiredate"].ToString();
                string Salary = ResultSet["salary"].ToString();

                NewTeacher.TeacherId = TeacherId;

                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;

            
            }


            return NewTeacher;
        }

    }
}
