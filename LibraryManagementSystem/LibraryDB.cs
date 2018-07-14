using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class LibraryDB
    {
        //SQL Connection object
        SqlConnection conn = new SqlConnection();
        //To keep track of current user;
        public static User currentUser;

        //String for connecting to the database
        String strConnect = "Server =.\\SQLEXPRESS; Database = Library; Trusted_Connection = True; ";

        /// <summary>
        /// Method to check whether a user provided the correct password or not
        /// </summary>
        /// <param name="username"> Username provided by user </param>
        /// <param name="password"> Password provided by user </param>
        /// <returns> True if user provided correct password, false if they provided the wrong password </returns>
        public Boolean Login(String username, String password)
        {
            //boolean to determine whether the user successfully logged in or not
            bool loginSuccessful = false;

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //Query to get password for user sent
            SqlCommand query = new SqlCommand("SELECT * FROM Staff_Details WHERE username = @username", conn);
            query.Parameters.AddWithValue("@username", username);
            //Open database connection
            conn.Open();

            //Query database to see if user exists, if they do, get password
            SqlDataReader reader = query.ExecuteReader();

            //Go through the retrieved row
            while (reader.Read())
            {
                //Store the password in a temp variable
                String passwordDB = reader[3].ToString();

                //If the passwords match, then they successfully logged in
                if (passwordDB == password)
                {
                    //Collect the information about the user that logged in
                    currentUser = new User(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                    loginSuccessful = true;
                }

            }

            //close DB connection
            conn.Close();

            return loginSuccessful;
        }

        /// <summary>
        /// Gets a list of all departments in database
        /// </summary>
        /// <returns>List of departments in the database</returns>
        public List<String> getDepartments()
        {
            //Array to keep list of departments
            List<String> departments = new List<String>();

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //Query to get all departments in the system
            SqlCommand query = new SqlCommand("Select distinct department from Student_Details;", conn);
            //Open database connection
            conn.Open();

            //Query database to get departments
            SqlDataReader reader = query.ExecuteReader();

            //Go through the retrieved rows
            while (reader.Read())
            {
                //Put the current department into the array
                departments.Add(reader[0].ToString());
            }

            //close DB connection
            conn.Close();

            //Return the list of departments
            return departments;
        }

        /// <summary>
        /// Gets a list of all sexex/genders
        /// </summary>
        /// <returns>List of sexex/genders in the database</returns>
        public List<String> getGenders()
        {
            //Array to keep list of departments
            List<String> genders = new List<String>();

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //Query to get all departments in the system
            SqlCommand query = new SqlCommand("Select distinct Gender from Student_Details;", conn);
            //Open database connection
            conn.Open();

            //Query database to get departments
            SqlDataReader reader = query.ExecuteReader();

            //Go through the retrieved rows
            while (reader.Read())
            {
                //Put the current department into the array
                genders.Add(reader[0].ToString());
            }

            //close DB connection
            conn.Close();

            //Return the list of departments
            return genders;
        }

        public List<Student> StudentSearch(Student student)
        {
            //Putting student information into variables to check whether they're empty or not
            int id = student.Student_id;
            String name = student.Student_name;
            String gender = student.Gender;
            String DOB = student.Dob;
            String dept = student.Dept;

            string query = "SELECT * FROM Student_Details {0}";
            string whereClause = string.Empty;

            //Adding an AND onto the WHERE clause if the field isn't empty
            if (id != 0)
                whereClause = AddCondition(whereClause, " AND", "Student_Id = " + id);

            if (name != "")
                whereClause = AddCondition(whereClause, " AND", " Student_name = '" + name + "'");

            if (gender != "")
                whereClause = AddCondition(whereClause, " AND", " Gender = '" + gender + "'");

            if (DOB != "")
                whereClause = AddCondition(whereClause, " AND", " Date_Of_Birth = '" + DOB + "'");

            if (dept != "")
                whereClause = AddCondition(whereClause, " AND", " Department = '" + dept + "'");

            //Final query put together
            string finalQuery = String.Format(query, whereClause);

            //Array to keep list of departments
            List<Student> students = new List<Student>();

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //Query to get all departments in the system
            SqlCommand command = new SqlCommand(finalQuery, conn);
            //Open database connection
            conn.Open();

            //Query database to get departments
            SqlDataReader reader = command.ExecuteReader();

            //Go through the retrieved rows and add each column into students list
            while (reader.Read())
            {
                //Create the current student by getting their information from the database
                Student currentStudent = new Student(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Int32.Parse(reader[4].ToString()), reader[5].ToString(), reader[6].ToString() );
                //Put the current student into the list
                students.Add(currentStudent);
            }

            //close DB connection
            conn.Close();

            //Return the list of departments
            return students;


        }

        /// <summary>
        /// Adds a WHERE clause onto the SQL query for the dynamic query to search for students
        /// </summary>
        /// <param name="clause"></param>
        /// <param name="appender"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        string AddCondition(string clause, string appender, string condition)
        {
            if (clause.Length <= 0)
            {
                return String.Format("WHERE {0}", condition);
            }
            return string.Format("{0} {1} {2}", clause, appender, condition);
        }

    }
}
