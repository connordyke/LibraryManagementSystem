using System;
using System.Collections.Generic;
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
            SqlCommand query = new SqlCommand("SELECT password FROM Staff_Details WHERE username = @username", conn);
            query.Parameters.AddWithValue("@username", username);
            //Open database connection
            conn.Open();

            //Query database to see if user exists, if they do, get password
            SqlDataReader reader = query.ExecuteReader();

            //Go through the retrieved row
            while (reader.Read())
            {
                //Store the password in a temp variable
                String passwordDB = reader[0].ToString();

                //If the passwords match, then they successfully logged in
                if (passwordDB == password)
                {
                    loginSuccessful = true;
                }

            }

            //close DB connection
            conn.Close();

            return loginSuccessful;
        }

        public void StudentSearch()
        {

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

    }
}
