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
            lblName.Text = "Welcome, " + CurrentUser.Name + "!";

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
            //Maximum date it today
            dtpDOB.MaxDate = DateTime.Now;

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
            cmbLang.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1;

            //Only way to make the date time picker empty
            dtpPubYear.CustomFormat = " ";
            //Maximum date it today
            dtpPubYear.MaxDate = DateTime.Now;

            if (CurrentUser.IsAdmin == "False")
            {
                tabDashboard.TabPages.Remove(tabAdmin);
            }

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
                if (txtID.MaskCompleted)
                {
                    id = Int32.Parse(txtID.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a valid Student ID", "Invalid Student ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
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
            if (studentSearchResult.Count == 1)
            {
                lblNumRecords.Text = studentSearchResult.Count + " Student matches your filter.";
            }
            else
            {
                lblNumRecords.Text = studentSearchResult.Count + " Students match your filter.";
            }

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

            //Disable the edit link label
            lblEditStudent.Enabled = false;
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
                if (txtISBN.MaskCompleted)
                {
                    ISBN = Int32.Parse(txtID.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a valid ISBN Code", "Invalid ISBN Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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

            //If there are no students to edit, disable the edit link
            if (bookSearchResult.Count == 0)
            {
                lblEditBook.Enabled = false;
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
            if (bookSearchResult.Count == 1)
            {
                lblNumBooks.Text = bookSearchResult.Count + " Book matches your filter.";
            }
            else
            {
                lblNumBooks.Text = bookSearchResult.Count + " Books match your filter.";
            }

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
            dgvBooks.Columns[8].HeaderText = "Shelf";
            dgvBooks.Columns[9].HeaderText = "Floor";

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
            //Clear all text boxes, and reset combo boxes
            txtISBN.Text = "";
            txtTitle.Text = "";
            cmbLang.SelectedIndex = -1;
            dtpPubYear.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbOutOfStock.SelectedIndex = -1;

            //Initial value of the date time picker is empty
            dtpPubYear.CustomFormat = " ";

            //Give focus to ISBN text box (first text box)
            txtISBN.Focus();

            //Disable the edit link label
            lblEditBook.Enabled = false;
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


        /// <summary>
        /// When the user clicks on a field to edit, it enables the edit button if the user is an Admin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrentUser.IsAdmin == "True")
            {
                lblEditStudent.Enabled = true;
            }

            //MessageBox.Show(dgvStudent.CurrentRow.Cells[0].Value.ToString());
        }

        /// <summary>
        /// When the user clicks on a field to edit, it enables the edit button if the user is an Admin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrentUser.IsAdmin == "True")
            {
                lblEditBook.Enabled = true;
            }

            //MessageBox.Show(dgvStudent.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            frmStudent newStudent = new frmStudent();
            newStudent.Show();
            this.Hide();
        }

        private void lblEditStudent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String edit = "Edit";


             DialogResult dialogResult = MessageBox.Show("Would you like to edit the student information for the student " + dgvStudent.CurrentRow.Cells[1].Value.ToString() + "?", "Edit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if they choose yes, refresh the form
            if (dialogResult == DialogResult.Yes)
            {
                Student editStudent = new Student(Int32.Parse(dgvStudent.CurrentRow.Cells[0].Value.ToString()), dgvStudent.CurrentRow.Cells[1].Value.ToString(), dgvStudent.CurrentRow.Cells[2].Value.ToString(),
                    dgvStudent.CurrentRow.Cells[3].Value.ToString(), dgvStudent.CurrentRow.Cells[4].Value.ToString(), dgvStudent.CurrentRow.Cells[5].Value.ToString());

                this.Hide();
                frmStudent frmStudent = new frmStudent(edit, editStudent);
                frmStudent.Show();
            }

            //MessageBox.Show(dgvStudent.CurrentRow.Cells[0].Value.ToString());
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }

            
        }

        private void lblEditBook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String edit = "Edit";


            DialogResult dialogResult = MessageBox.Show("Would you like to edit the book information for the book " + dgvBooks.CurrentRow.Cells[1].Value.ToString() + "?", "Edit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if they choose yes, refresh the form
            if (dialogResult == DialogResult.Yes)
            {
                Book editBook = new Book(Int32.Parse(dgvBooks.CurrentRow.Cells[0].Value.ToString()), dgvBooks.CurrentRow.Cells[1].Value.ToString(), dgvBooks.CurrentRow.Cells[2].Value.ToString(),
                    dgvBooks.CurrentRow.Cells[3].Value.ToString(), Int32.Parse(dgvBooks.CurrentRow.Cells[4].Value.ToString()), Int32.Parse(dgvBooks.CurrentRow.Cells[5].Value.ToString()), 
                    dgvBooks.CurrentRow.Cells[6].Value.ToString(), dgvBooks.CurrentRow.Cells[7].Value.ToString(), "", 
                    Int32.Parse(dgvBooks.CurrentRow.Cells[8].Value.ToString()), Int32.Parse(dgvBooks.CurrentRow.Cells[9].Value.ToString()));

                this.Hide();
                frmBook frmBook = new frmBook(edit, editBook);
                frmBook.Show();
            }
        }

        /// <summary>
        /// Sends the user to the new form to add a new book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmBook newBook = new frmBook();
            newBook.Show();
            this.Hide();
        }

        /// <summary>
        /// Sends the user to the new form to select a book to issue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIssue_Click(object sender, EventArgs e)
        {
            frmIssueReturn issueBook = new frmIssueReturn("Issue");
            issueBook.Show();
            this.Hide();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmIssueReturn returnBook = new frmIssueReturn("Return");
            returnBook.Show();
            this.Hide();
        }
    }
}
