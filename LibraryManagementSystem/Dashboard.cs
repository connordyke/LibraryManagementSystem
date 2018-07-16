using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class frmDashboard : Form
    {

        public static Boolean outOfStock = true;

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //Get the name from the logged in user and display it in the corner
            lblName.Text = "Welcome, " + LibraryDB.currentUser.Name + "!";

            //List of strings (departments in database)
            List<String> departmentsList = new List<String>();
            //List of strings (genders in database)
            List<String> gendersList = new List<String>();
            //Create a new database object to search from
            LibraryDB formInfo = new LibraryDB();

            //Retrieve list of departments from the library DB
            departmentsList = formInfo.getDepartments();
            //Retrieve list of genders from the library DB
            gendersList = formInfo.getGenders();

            //Fill the combo box with the list of departments
            cmbDepartment.DataSource = departmentsList;
            cmbGender.DataSource = gendersList;

            //Only way to make the date time picker empty
            dtpDOB.CustomFormat = " ";

            //Perform a search with no filter, just to show all students
            btnSearchStudent.PerformClick();

            //List of strings (departments in database)
            List<String> languagesList = new List<String>();
            //List of strings (genders in database)
            List<String> categoriesList = new List<String>();

            //Retrieve list of departments from the library DB
            languagesList = formInfo.getLanguages();
            //Retrieve list of genders from the library DB
            categoriesList = formInfo.getCategories();

            //Fill the combo box with the list of departments
            cmbLang.DataSource = languagesList;
            cmbCategory.DataSource = categoriesList;

            //Empty the combo boxes to give user a blank slate to search on
            cmbLang.Text = " ";
            cmbCategory.Text = " ";
            cmbDepartment.Text = " ";
            cmbGender.Text = " ";

            //Only way to make the date time picker empty
            dtpPubYear.CustomFormat = " ";

        }


        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            //Create a list of students to store result(s) in
            List<Student> studentSearchResult = new List<Student>();

            //Date of birth is empty
            String DOB = "";

            //Initially set id to 0 (nothing entered in textbox)
            int id = 0;

            //If ID text box has something in it, replace 0 with the ID input by user
            if (txtID.Text != "")
            {
                id = Int32.Parse(txtID.Text);

            }

            //If the date time picker is not empty, put the value in the variable
            if (dtpDOB.Text != " ")
            {
                DOB = dtpDOB.Text;
            }


            //All of user input into variables
            String name = txtName.Text;
            String gender = cmbGender.Text;
            String dept = cmbDepartment.Text;

            //Create a new student with properties set
            Student searchStudent = new Student(id, name, gender, DOB, dept, "");

            //Create a connection to the database and search for the student
            LibraryDB student = new LibraryDB();
            //Search for the student 
            studentSearchResult = student.StudentSearch(searchStudent);

            //Load the student data into the data grid view
            dgvStudent.DataSource = studentSearchResult;

            //Displays number of returned records to the user
            lblNumRecords.Text = studentSearchResult.Count + " Students match your filter.";

            //Column headers
            dgvStudent.Columns[0].HeaderText = "Student ID";
            dgvStudent.Columns[1].HeaderText = "Student Name";
            dgvStudent.Columns[2].HeaderText = "Gender";
            dgvStudent.Columns[3].HeaderText = "Date of Birth";
            dgvStudent.Columns[4].HeaderText = "Department";
            dgvStudent.Columns[5].HeaderText = "Contact Number";

            //Dynamically size the data grid view each time the user searches
            int width = 0;
            foreach (DataGridViewColumn col in dgvStudent.Columns)
            {
                width += col.Width;
            }
            width += dgvStudent.RowHeadersWidth;

            dgvStudent.ClientSize = new Size(width + 2, dgvStudent.Height);
            dgvStudent.BackgroundColor = System.Drawing.SystemColors.Control;
        }

        //Doesn't let the user enter in numbers
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtID.Text, "[^0-9]"))
            {
                txtID.Text = txtID.Text.Remove(txtID.Text.Length - 1);
            }
        }

        //When the user wants to clear all of the filter options
        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            //Clear all text boxes
            txtID.Text = "";
            txtName.Text = "";
            cmbGender.Text = "";
            dtpDOB.CustomFormat = " ";
            cmbDepartment.Text = "";

            //Initially doesn't display any date
            dtpPubYear.CustomFormat = " ";

            //Give focus to ID text box (first text box)
            txtID.Focus();
        }

        //When the user selects a date, display the correct format
        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            dtpDOB.CustomFormat = "yyyy-MM-dd";
        }

        //When the user wants to search for a book
        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            //Create a list of books to store result(s) in
            List<Book> bookSearchResult = new List<Book>();

            //pyb year and out of stock are empty
            String pubYear = "";
            String outOfStock = "";

            //Initially set id to 0 (nothing entered in textbox)
            int ISBN = 0;

            //If ISBN text box has something in it, replace 0 with the ID input by user
            if (txtISBN.Text != "")
            {
                ISBN = Int32.Parse(txtISBN.Text);

            }

            //If the date time picker isn't empty, put the value into the variable
            if (dtpPubYear.Text != " ")
            {
                pubYear = dtpPubYear.Text;
            }


            //All of user input into variables
            String title = txtTitle.Text;
            String lang = cmbLang.Text;
            String category = cmbCategory.Text;

            //Sets the variable to true/false (as string for the SQL statement) based on whether the user wants to see items out of stock or in stock
            if (cmbOutOfStock.Text == "Yes")
            {
                outOfStock = "True";
            }
            else if (cmbOutOfStock.Text == "No")
            {
                outOfStock = "False";
            }


            //Create a new book with properties set
            Book searchBook = new Book(ISBN, title, lang, "", 0, 0, category, pubYear, outOfStock, 0, 0);

            //Create a connection to the database and search for the student
            LibraryDB book = new LibraryDB();
            //Search for the student 
            bookSearchResult = book.BookSearch(searchBook);

            //Load the student data into the data grid view
            dgvBooks.DataSource = bookSearchResult;

            //Displays number of returned records to the user
            lblNumBooks.Text = bookSearchResult.Count + " Books match your filter.";

            //Remove the out of stock column
            dgvBooks.Columns.RemoveAt(8);

            //Column headers
            dgvBooks.Columns[0].HeaderText = "ISBN";
            dgvBooks.Columns[1].HeaderText = "Book\nTitle";
            dgvBooks.Columns[2].HeaderText = "Language";
            dgvBooks.Columns[3].HeaderText = "Binding\nName";
            dgvBooks.Columns[4].HeaderText = "Original\nStock";
            dgvBooks.Columns[5].HeaderText = "Current\nStock";
            dgvBooks.Columns[6].HeaderText = "Category";
            dgvBooks.Columns[7].HeaderText = "Publication\nYear";
            dgvBooks.Columns[8].HeaderText = "Shelf\nNumber";
            dgvBooks.Columns[9].HeaderText = "Floor\nNumber";

            //Dynamically size the data grid view each time the user searches
            int width = 0;
            foreach (DataGridViewColumn col in dgvBooks.Columns)
            {
                width += col.Width;
            }
            width += dgvBooks.RowHeadersWidth;

            dgvBooks.ClientSize = new Size(width + 2, dgvBooks.Height);
            dgvBooks.BackgroundColor = System.Drawing.SystemColors.Control;
        }

        //User cannot enter letters
        private void txtISBN_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtISBN.Text, "[^0-9]"))
            {
                txtISBN.Text = txtISBN.Text.Remove(txtISBN.Text.Length - 1);
            }
        }

        //When the user wants to clear the filters for the book search
        private void btnClearBook_Click(object sender, EventArgs e)
        {
            //Clear all text boxes
            txtISBN.Text = "";
            txtTitle.Text = "";
            cmbLang.Text = "";
            dtpPubYear.Text = "";
            cmbCategory.Text = "";
            cmbOutOfStock.Text = "";

            dtpPubYear.CustomFormat = " ";

            //Give focus to ISBN text box (first text box)
            txtISBN.Focus();
        }
        
        //When the user changes the value of the date time picker
        private void dtpPubYear_ValueChanged(object sender, EventArgs e)
        {
            dtpPubYear.CustomFormat = "yyyy-MM-dd";
        }

        private void tabDashboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabDashboard.SelectedIndex == 0)
            {
                this.Text = "xxx Library Dashboard";
            }
            else if (tabDashboard.SelectedIndex == 1)
            {
                this.Text = "xxx Library Student Information";
                cmbGender.Text = "";
                cmbDepartment.Text = "";
            }
            else if (tabDashboard.SelectedIndex == 2)
            {
                this.Text = "xxx Book Information";
                cmbLang.Text = "";
                cmbCategory.Text = "";
            }

        }
    }
}
