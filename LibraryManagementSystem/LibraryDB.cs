﻿using System;
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

        //String for connecting to the database
        String strConnect = "Server =.\\SQLEXPRESS; Database = Library; Trusted_Connection = True;";

        /// <summary>
        /// Checks the connection to the database when the application is first loaded
        /// </summary>
        /// <returns> True or false based on whether the connection succeeded or not</returns>
        public Boolean CheckConnection()
        {

            //Using the connection
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                //Try to connect to the database server
                try
                {
                    //If the connection opens return true;
                    connection.Open();
                    return true;
                }catch (Exception e)
                {
                    //If it fails, return false
                    return false;
                }

            }

        }

        /// <summary>
        /// Gets a single row from the database to get the last student ID in database, then adds 1 onto that to create a new student ID
        /// </summary>
        /// <returns>The new student ID as a string (because its going into a text box)</returns>
        public string getNewID(String studentOrBook)
        {
            //String to store new  ID
            int newID = 0;

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //SQL query variable to be set
            SqlCommand query;

            if (studentOrBook == "Student")
            {
                //Query to get the ID's listed in the database
                query = new SqlCommand("Select Top(1) Student_id from Student_Details ORDER BY Student_id DESC;", conn);

            }
            else
            {
                //Query to get the ID's listed in the database
                query = new SqlCommand("Select Top(1) ISBN_Code from Book_Details ORDER BY ISBN_Code DESC;", conn);
            }

            //Open database connection
            conn.Open();

            //Query database to see if user exists, if they do, get password
            SqlDataReader reader = query.ExecuteReader();

            while(reader.Read())
            {
                //Store the 
                newID = Int32.Parse(reader[0].ToString());
            }

            conn.Close();

            newID++;

            return newID.ToString();

        }

        public void insertEditStudent(Student newStudent, String addOrEdit)
        {

            //Connection path for databse
            conn.ConnectionString = strConnect;

            SqlCommand query;

            if (addOrEdit == "Add")
            {
                //Query to get the ID's listed in the database
                query = new SqlCommand("INSERT INTO Student_Details (Student_id, Student_Name, Gender, Date_Of_Birth, Department, contact_Number)" +
                                                    "VALUES(@id, @name, @gender, @dob, @dept, @contact);",
                                                            conn);
            }
            else
            {
                //Query to get insert the new student
                query = new SqlCommand("UPDATE Student_Details " +
                                                    "SET Student_Name = @name, Gender = @gender, Date_of_Birth = @dob, Department = @dept, contact_Number = @contact" +
                                                    " WHERE Student_id = @id", conn);
            }

            //Open database connection
            conn.Open();

            //Add the values to the parameters for the insert statement
            query.Parameters.AddWithValue("@id", newStudent.Student_id);
            query.Parameters.AddWithValue("@name", newStudent.Student_name);
            query.Parameters.AddWithValue("@gender", newStudent.Gender);
            query.Parameters.AddWithValue("@dob", newStudent.Dob);
            query.Parameters.AddWithValue("@dept", newStudent.Dept);
            query.Parameters.AddWithValue("@contact", newStudent.ContactNum);

            query.ExecuteNonQuery();

            conn.Close();

        }


        public void insertEditBook(Book newBook, String addOrEdit)
        {

            //Connection path for databse
            conn.ConnectionString = strConnect;

            int categoryID = 0;
            int bindingID = 0;
            int shelfID = 0;
            int numCopies = 0;
            int currCopies = 0;

            //////////////////////////////GETTING THE CATEGORY ID////////////////////////////////////////////////////
            //Query to get the category ID to insert into the category_id column
            SqlCommand queryCategory = new SqlCommand("SELECT Category_Id FROM Category_Details WHERE Category_Name = @category;",
                                                        conn);

            queryCategory.Parameters.AddWithValue("@category", newBook.Category);

            //Open database connection
            conn.Open();

            //Query database to see if user exists, if they do, get password
            SqlDataReader readerCategory = queryCategory.ExecuteReader();

            //Gets the category ID and stores it in the variable
            while (readerCategory.Read())
            {
                categoryID = Int32.Parse(readerCategory[0].ToString());
            }

            //Close the connection
            conn.Close();
            //////////////////////////////GETTING THE CATEGORY ID////////////////////////////////////////////////////

            //////////////////////////////GETTING THE BINDING ID////////////////////////////////////////////////////
            //Query to get the category ID to insert into the category_id column
            SqlCommand queryBinding = new SqlCommand("SELECT Binding_Id FROM Binding_Details WHERE Binding_Name = @bindingName;",
                                                        conn);

            queryBinding.Parameters.AddWithValue("@bindingName", newBook.BindingName);

            //Open database connection
            conn.Open();

            //Query database to see if user exists, if they do, get password
            SqlDataReader readerBinding = queryBinding.ExecuteReader();

            //Gets the category ID and stores it in the variable
            while (readerBinding.Read())
            {
                bindingID = Int32.Parse(readerBinding[0].ToString());
            }

            //Close the connection
            conn.Close();
            //////////////////////////////GETTING THE BINDING ID////////////////////////////////////////////////////


            //////////////////////////////GETTING THE SHELF ID////////////////////////////////////////////////////
            //Query to get the category ID to insert into the category_id column
            SqlCommand queryShelf = new SqlCommand("SELECT Shelf_id FROM Shelf_Details WHERE Shelf_No = @shelfNo AND Floor_No = @floorNo;",
                                                        conn);

            queryShelf.Parameters.AddWithValue("@shelfNo", newBook.ShelfNum);
            queryShelf.Parameters.AddWithValue("@floorNo", newBook.FloorNum);

            //Open database connection
            conn.Open();

            //Query database to see if user exists, if they do, get password
            SqlDataReader readerShelf = queryShelf.ExecuteReader();

            //Gets the number of copies and current number of copies
            while (readerShelf.Read())
            {
                shelfID = Int32.Parse(readerShelf[0].ToString());
            }

            //If the number of copies is less than current number of copies, set them equal
            if (newBook.NumCopies < currCopies)
            {
                currCopies = numCopies;
            }

            //Close the connection
            conn.Close();
            //////////////////////////////GETTING THE SHELF ID////////////////////////////////////////////////////

            //////////////////////////////GETTING THE AMOUNT OF COPIES////////////////////////////////////////////////////
            //Query to get the category ID to insert into the category_id column
            SqlCommand queryCopies = new SqlCommand("SELECT No_Copies_Current FROM Book_Details WHERE ISBN_Code = @isbn;",
                                                        conn);

            //Add the variable to the query
            queryCopies.Parameters.AddWithValue("@isbn", newBook.Isbn);

            //Open database connection
            conn.Open();

            //Query database to see if user exists, if they do, get password
            SqlDataReader readerCopy = queryCopies.ExecuteReader();

            //Gets the number of copies and current number of copies
            while (readerCopy.Read())
            {
                currCopies = Int32.Parse(readerCopy[0].ToString());
            }

            //If the number of copies is less than current number of copies, set them equal
            if (newBook.NumCopies < currCopies)
            {
                currCopies = newBook.NumCopies;
            }

            //Close the connection
            conn.Close();
            //////////////////////////////GETTING THE AMOUNT OF COPIES////////////////////////////////////////////////////

            SqlCommand queryBook;

            if (addOrEdit == "Add")
            {
                //Query to get the insert the new book
                queryBook = new SqlCommand("INSERT INTO Book_Details (ISBN_Code, Book_Title, Language, Binding_Id, No_Copies_Actual, No_Copies_Current, Category_ID, Publication_year, Shelf_id, OutOfStock)" +
                                           " VALUES(@isbn, @title, @language, @bindingID, @numCopies, @currCopies, @categoryID, @pubYear, @shelfID, @outOfStock);",
                                           conn);

                /* Used to see the query in console 
                queryBook = new SqlCommand("INSERT INTO Book_Details (ISBN_Code, Book_Title, Language, Binding_Id, No_Copies_Actual, No_Copies_Current, Category_ID, Publication_year, Shelf_id, OutOfStock)" +
                                           " VALUES(" + newBook.Isbn + ",'" + newBook.BookTitle + "','" + newBook.Language + "'," + bindingID + "," + newBook.NumCopies + "," + newBook.NumCopiesCurrent + "," + categoryID + ",'" + newBook.PubYear + "'," + shelfID + ",'" + newBook.OutOfStock + "');",
                                           conn); */
            }
            else
            {
                /*
                queryBook = new SqlCommand("UPDATE Book_Details " +
                                                "SET ISBN_Code = @isbn, Book_Title = @title, Language = @language, Binding_Id = @bindingID, No_Copies_Actual = @numCopies, No_Copies_Current = @currCopies, " +
                                                "Category_ID = @categoryID, Publication_year = @pubYear, Shelf_id = @shelfID" +
                                                " WHERE ISBN_Code = @isbn", conn);
                                                */

                queryBook = new SqlCommand("UPDATE Book_Details " +
                                            "SET ISBN_Code = @isbn, Book_Title = @title, Language = @language, Binding_Id = @bindingID, No_Copies_Actual = @numCopies, No_Copies_Current = @currCopies, " +
                                            "Category_ID = @categoryID, Publication_year = @pubYear, Shelf_id = @shelfID" +
                                            " WHERE ISBN_Code = @isbn", conn);

            }

            //Open database connection
            conn.Open();

            //Add the values to the parameters for the insert statement
            queryBook.Parameters.AddWithValue("@isbn", newBook.Isbn);
            queryBook.Parameters.AddWithValue("@title", newBook.BookTitle);
            queryBook.Parameters.AddWithValue("@language", newBook.Language);
            queryBook.Parameters.AddWithValue("@bindingID", bindingID);
            queryBook.Parameters.AddWithValue("@numCopies", newBook.NumCopies);
            queryBook.Parameters.AddWithValue("@currCopies", currCopies);
            queryBook.Parameters.AddWithValue("@categoryID", categoryID);
            queryBook.Parameters.AddWithValue("@pubYear", newBook.PubYear);
            queryBook.Parameters.AddWithValue("@shelfID", shelfID);

            //Insert book or update book
            queryBook.ExecuteNonQuery();
            //Console.WriteLine(queryBook.CommandText);

            //Close connection
            conn.Close();

        }

        public void returnBook(int isbn, int studentID, int borrowerNum, String actualDate)
        {
            //Connection path for databse
            conn.ConnectionString = strConnect;

            int currentAmount = 0;
            int actualAmount = 0;
            String outOfStock = "";

            //Query to get see how many books are currently in stock for this current book
            SqlCommand selectQuery = new SqlCommand("SELECT No_Copies_Current, No_Copies_Actual, OutOfStock FROM Book_Details WHERE ISBN_Code = @isbn", conn);

            //Open the connection
            conn.Open();

            //Add the variable to the query
            selectQuery.Parameters.AddWithValue("@isbn", isbn);
            //Query database to see if user exists, if they do, get password
            SqlDataReader readerNumCopies = selectQuery.ExecuteReader();

            //Gets the number of copies and current number of copies
            while (readerNumCopies.Read())
            {
                currentAmount = Int32.Parse(readerNumCopies[0].ToString());
                actualAmount = Int32.Parse(readerNumCopies[1].ToString());
                outOfStock = readerNumCopies[2].ToString();
            }

            //Close the connection
            conn.Close();

            SqlCommand updateAmount = new SqlCommand("UPDATE Book_Details " +
                            "SET No_Copies_Current = @copies, OutOfStock = @outOfStock" +
                            " WHERE ISBN_Code = @isbn", conn);

            //Open the connection
            conn.Open();

            //If the book was out of stock, it is now in stock
            if (currentAmount == 0 || currentAmount < actualAmount)
            {
                outOfStock = "False";
                currentAmount++;
            }



            //Add the values to the parameters for the insert statement
            updateAmount.Parameters.AddWithValue("@isbn", isbn);
            updateAmount.Parameters.AddWithValue("@outOfStock", outOfStock); //Add one to the current amount
            updateAmount.Parameters.AddWithValue("@copies", currentAmount); //Add one to the current amount

            //Update the amount
            updateAmount.ExecuteNonQuery();

            //Close the connection
            conn.Close();

            SqlCommand updateDate = new SqlCommand("UPDATE Borrower_Details " +
                "SET Actual_Return_Date = @actualReturn" +
                " WHERE BorrowNum = @borrowerNum", conn);

            //Open the connection
            conn.Open();

            //Add the values to the parameters for the insert statement
            updateDate.Parameters.AddWithValue("@actualReturn", actualDate);
            updateDate.Parameters.AddWithValue("@borrowerNum", borrowerNum); //Add one to the current amount

            //Update the amount
            updateDate.ExecuteNonQuery();

            //Close the connection
            conn.Close();

        }

            public void insertNewBorrow(int studentID, int isbn, String issueDate, String returnDate, int issuedBy)
        {
            //Variable to see how many books are currently in stock
            int currentAmount = 0;

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //Query to insert the new borrow row
            SqlCommand insertQuery = new SqlCommand("INSERT INTO Borrower_Details (Borrower_Id, Book_Id, Borrowed_From, Borrowed_To, Issued_By)" +
                                                    "VALUES(@borrowerId, @bookId, @issueDate, @returnDate, @issuedBy);",
                                                            conn);

            //Add the values to the parameters for the insert statement
            insertQuery.Parameters.AddWithValue("@borrowerId", studentID);
            insertQuery.Parameters.AddWithValue("@bookId", isbn);
            insertQuery.Parameters.AddWithValue("@issueDate", issueDate);
            insertQuery.Parameters.AddWithValue("@returnDate", returnDate);
            insertQuery.Parameters.AddWithValue("@issuedBy", issuedBy);

            //Open database connection
            conn.Open();

            //Inserts the new row
            insertQuery.ExecuteNonQuery();

            //Close the connection
            conn.Close();




            //Query to get see how many books are currently in stock for this current book
            SqlCommand selectQuery = new SqlCommand("SELECT No_Copies_Current FROM Book_Details WHERE ISBN_Code = @isbn", conn);

            //Open the connection
            conn.Open();

            //Add the variable to the query
            selectQuery.Parameters.AddWithValue("@isbn", isbn);
            //Query database to see if user exists, if they do, get password
            SqlDataReader readerNumCopies = selectQuery.ExecuteReader();

            //Gets the number of copies and current number of copies
            while (readerNumCopies.Read())
            {
                currentAmount = Int32.Parse(readerNumCopies[0].ToString());
            }

            //Close the connection
            conn.Close();


            //Query to get the ID's listed in the database
            SqlCommand updateQuery = new SqlCommand("UPDATE Book_Details " +
                                                        "SET No_Copies_Current = @currcopies, OutOfStock = @outOfStock" +
                                                        " WHERE ISBN_Code = @isbn",
                                                            conn);

            //Open the connection
            conn.Open();

            //If the current amount of books is 1, its on the last book, set it to out of stock and subtract one
            if (currentAmount == 1)
            {
                updateQuery.Parameters.AddWithValue("@outOfStock", true);
                currentAmount--;

            }
            else //Else, its in stock
            {
                updateQuery.Parameters.AddWithValue("@outOfStock", false);
                //Subtract one from the current amount because the user just issued a book
                currentAmount--;
            }
            
            updateQuery.Parameters.AddWithValue("@currCopies", currentAmount);
            updateQuery.Parameters.AddWithValue("@isbn", isbn);

            //Execute the update statement
            updateQuery.ExecuteNonQuery();

            //Close the connection
            conn.Close();

        }



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
                    CurrentUser.Id = Int32.Parse(reader[0].ToString());
                    CurrentUser.Name = reader[1].ToString();
                    CurrentUser.Username = reader[2].ToString();
                    CurrentUser.IsAdmin = reader[4].ToString();
                    CurrentUser.Designation = reader[5].ToString();
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
        /// Gets a list of all bindings in database
        /// </summary>
        /// <returns>List of departments in the database</returns>
        public List<String> getBindings()
        {
            //Array to keep list of departments
            List<String> bindings = new List<String>();

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //Query to get all departments in the system
            SqlCommand query = new SqlCommand("Select distinct Binding_Name from Binding_Details;", conn);
            //Open database connection
            conn.Open();

            //Query database to get departments
            SqlDataReader reader = query.ExecuteReader();

            //Go through the retrieved rows
            while (reader.Read())
            {
                //Put the current department into the array
                bindings.Add(reader[0].ToString());
            }

            //close DB connection
            conn.Close();

            //Return the list of departments
            return bindings;
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

        /// <summary>
        /// Gets a list of all shelves on a specific floor in database
        /// </summary>
        /// <returns>List of languages in the database</returns>
        public List<String> getShelfNums(int floorNum)
        {
            //Array to keep list of departments
            List<String> shelves = new List<String>();

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //Query to get all departments in the system
            SqlCommand query = new SqlCommand("Select distinct Shelf_No from Shelf_Details WHERE Floor_No = @floorNum;", conn);

            //Add the values to the parameters for the insert statement
            query.Parameters.AddWithValue("@floorNum", floorNum);

            //Open database connection
            conn.Open();

            //Query database to get departments
            SqlDataReader reader = query.ExecuteReader();

            //Go through the retrieved rows
            while (reader.Read())
            {
                //Put the current department into the array
                shelves.Add(reader[0].ToString());
            }

            //close DB connection
            conn.Close();

            //Return the list of departments
            return shelves;
        }

        /// <summary>
        /// Gets a list of the return date for the specified book
        /// </summary>
        /// <returns>List of departments in the database</returns>
        public List<String> getReturnDateAndBorrowNum(int isbn, int studentID)
        {

            List<String> returnInfo = new List<String>();

            //Connection path for databse
            conn.ConnectionString = strConnect;

            //Query to get all departments in the system
            SqlCommand query = new SqlCommand("Select Borrowed_TO, BorrowNum from Borrower_Details WHERE Borrower_Id = @borrowerID AND Book_Id = @isbn AND Actual_Return_Date IS NULL;", conn);
            //Open database connection
            conn.Open();

            //Add the values to the parameters for the insert statement
            query.Parameters.AddWithValue("@borrowerID", studentID);
            query.Parameters.AddWithValue("@isbn", isbn);

            //Query database to get departments
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                returnInfo.Add(reader[0].ToString());
                returnInfo.Add(reader[1].ToString());
            }



            //close DB connection
            conn.Close();

            //Return the list of departments
            return returnInfo;
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
        /// Gets a list of all books that aren't out of stock
        /// </summary>
        /// <returns>List of departments in the database</returns>
        public List<Book> getInStockOutStockBooks(String outOfStock)
        {
            //Array to keep list of departments
            List<Book> books = new List<Book>();

            //Connection path for databse
            conn.ConnectionString = strConnect;

            string query = "";

            if (outOfStock == "True")
            {
                //Query to get all the in stock books in the database
                query = "SELECT ISBN_Code, Book_Title, Language, Binding_Name, No_Copies_Actual, No_Copies_Current, Category_Name, Publication_year, Shelf_no, Floor_no FROM Book_Details" +
                    " JOIN Category_Details ON Book_Details.Category_ID = Category_Details.Category_ID" +
                    " JOIN Binding_Details ON Book_Details.Binding_ID = Binding_Details.Binding_ID " +
                    " JOIN Shelf_Details on Book_Details.Shelf_id = Shelf_Details.Shelf_id " +
                    " WHERE OutOfStock = @outOfStock OR No_Copies_Current < No_Copies_Actual";
            }
            else
            {
                //Query to get all the in stock books in the database
                query = "SELECT ISBN_Code, Book_Title, Language, Binding_Name, No_Copies_Actual, No_Copies_Current, Category_Name, Publication_year, Shelf_no, Floor_no FROM Book_Details" +
                    " JOIN Category_Details ON Book_Details.Category_ID = Category_Details.Category_ID" +
                    " JOIN Binding_Details ON Book_Details.Binding_ID = Binding_Details.Binding_ID " +
                    " JOIN Shelf_Details on Book_Details.Shelf_id = Shelf_Details.Shelf_id " +
                    " WHERE OutOfStock = @outOfStock";
            }

            SqlCommand command = new SqlCommand(query, conn);

            if (outOfStock == "False")
            {
                //Add the values to the parameters for the insert statement
                command.Parameters.AddWithValue("@outOfStock", "False");
            }
            else
            {
                //Add the values to the parameters for the insert statement
                command.Parameters.AddWithValue("@outOfStock", "True");
            }

            //Open database connection
            conn.Open();

            //Query database to get departments
            SqlDataReader reader = command.ExecuteReader();

            //Go through the retrieved rows
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
