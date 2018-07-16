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
        /// Gets a list of all genders
        /// </summary>
        /// <returns>List of genders in the database</returns>
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

        /// <summary>
        /// Gets a list of all languages in database
        /// </summary>
        /// <returns>List of languages in the database</returns>
        public List<String> getLanguages()
        {
            //Array to keep list of departments
            List<String> languages = new List<String>();

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //Query to get all departments in the system
            SqlCommand query = new SqlCommand("Select distinct Language from Book_Details;", conn);
            //Open database connection
            conn.Open();

            //Query database to get departments
            SqlDataReader reader = query.ExecuteReader();

            //Go through the retrieved rows
            while (reader.Read())
            {
                //Put the current department into the array
                languages.Add(reader[0].ToString());
            }

            //close DB connection
            conn.Close();

            //Return the list of departments
            return languages;
        }

        /// <summary>
        /// Gets a list of all categories
        /// </summary>
        /// <returns>List of categories in the database</returns>
        public List<String> getCategories()
        {
            //Array to keep list of departments
            List<String> categories = new List<String>();

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //Query to get all categories in the system
            SqlCommand query = new SqlCommand("Select distinct category_name from Book_Details JOIN Category_Details ON Book_Details.Category_ID = Category_Details.Category_ID;", conn);
            //Open database connection
            conn.Open();

            //Query database to get departments
            SqlDataReader reader = query.ExecuteReader();

            //Go through the retrieved rows
            while (reader.Read())
            {
                //Put the current department into the array
                categories.Add(reader[0].ToString());
            }

            //close DB connection
            conn.Close();

            //Return the list of departments
            return categories;
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
                whereClause = AddCondition(whereClause, " AND", " Student_name LIKE '%" + name + "%'");

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
                Student currentStudent = new Student(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString() );
                //Put the current student into the list
                students.Add(currentStudent);
            }

            //close DB connection
            conn.Close();

            //Return the list of departments
            return students;


        }

        /// <summary>
        /// Dyanmic query to search for the book the user is looking for
        /// </summary>
        /// <param name="book">Book the user is looking for (object with properties)</param>
        /// <returns>List of books that match the query</returns>
        public List<Book> BookSearch(Book book)
        {
            //Putting book information into variables to check whether they're empty or not
            int ISBN = book.Isbn;
            String bookTitle = book.BookTitle;
            String lang = book.Language;
            String pubYear = book.PubYear;
            String category = book.Category;
            String outOfStock = book.OutOfStock;

            string query = "SELECT ISBN_Code, Book_Title, Language, Binding_Name, No_Copies_Actual, No_Copies_Current, Category_Name, Publication_year, Shelf_no, Floor_no FROM Book_Details" +
                " JOIN Category_Details ON Book_Details.Category_ID = Category_Details.Category_ID" +
                " JOIN Binding_Details ON Book_Details.Binding_ID = Binding_Details.Binding_ID " +
                " JOIN Shelf_Details on Book_Details.Shelf_id = Shelf_Details.Shelf_id {0}";
            string whereClause = string.Empty;

            //Adding an AND onto the WHERE clause if the field isn't empty
            if (ISBN != 0)
                whereClause = AddCondition(whereClause, " AND", "ISBN_Code = " + ISBN);

            if (bookTitle != "")
                whereClause = AddCondition(whereClause, " AND", "Book_Title LIKE '%" + bookTitle + "%'");

            if (lang != "")
                whereClause = AddCondition(whereClause, " AND", "Language = '" + lang + "'");

            if (pubYear != "")
                whereClause = AddCondition(whereClause, " AND", "Publication_year = '" + pubYear + "'");

            if (category != "")
                whereClause = AddCondition(whereClause, " AND", "Category_Name = '" + category + "'");

            if (outOfStock != "")
                whereClause = AddCondition(whereClause, " AND", "OutOfStock = '" + outOfStock + "'");

            //Final query put together
            string finalQuery = String.Format(query, whereClause);

            //Array to keep list of departments
            List<Book> books = new List<Book>();

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
                Book currentBook = new Book(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Int32.Parse(reader[4].ToString()), Int32.Parse(reader[5].ToString()), reader[6].ToString(), reader[7].ToString(), "", Int32.Parse(reader[8].ToString()), Int32.Parse(reader[9].ToString()));
                //Put the current student into the list
                books.Add(currentBook);
            }

            //close DB connection
            conn.Close();

            //Return the list of departments
            return books;


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
