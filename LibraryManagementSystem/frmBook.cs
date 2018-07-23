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
    public partial class frmBook : Form
    {

        public String editOrAdd;
        private int isbn;
        private String bookTitle;
        private String language;
        private String bindingName;
        private int numCopies;
        private int numCopiesCurrent;
        private String category;
        private String pubYear;
        private String outOfStock;
        private int shelfNum;
        private int floorNum;

        public frmBook()
        {
            InitializeComponent();

        }

        public frmBook(String _editOrAdd, Book editBook)
        {
            InitializeComponent();

            //Used to determine whether the user is adding a book or editing a book
            editOrAdd = _editOrAdd;

            //Initialize all variables as the values given by the previous form
            isbn = editBook.Isbn;
            bookTitle = editBook.BookTitle;
            language = editBook.Language;
            bindingName = editBook.BindingName;
            numCopies = editBook.NumCopies;
            numCopiesCurrent = editBook.NumCopiesCurrent;
            category = editBook.Category;
            pubYear = editBook.PubYear;
            outOfStock = editBook.OutOfStock;
            shelfNum = editBook.ShelfNum;
            floorNum = editBook.FloorNum;

        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Create variables and initialize them
            int isbn = 0;
            String title = "";
            String language = "";
            String bindingName = "";
            int numCopies = 0;
            String category = "";
            String pubYear = "";
            int shelfNo = 0;
            int floorNo = 0;

            //If the user is not editing (adding a new student, then collect their information)
            if (editOrAdd != "Edit")
            {

                //If input is correct, add the user
                if (checkInput())
                {

                    //Collect all information from form
                    isbn = Int32.Parse(txtISBN.Text);
                    title = txtTitle.Text;
                    language = cmbLang.Text;
                    bindingName = cmbBinding.Text;
                    numCopies = (int)nudCopies.Value;
                    category = cmbCategory.Text;
                    pubYear = dtpPubYear.Text;
                    shelfNo = Int32.Parse(cmbShelfNo.Text);
                    floorNo = Int32.Parse(cmbFloorNo.Text);

                    //Insert all that information into a book object
                    Book newBook = new Book(isbn, title, language, bindingName, numCopies, numCopies, category, pubYear, "False", shelfNo, floorNo);

                    //Insert the book into the databse
                    LibraryDB enterNewBook = new LibraryDB();
                    enterNewBook.insertEditBook(newBook, "Add");

                    DialogResult dialogResult = MessageBox.Show("Book has been successfully added!\nWould you like to add another?", "Book Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    //if they choose yes, refresh the form
                    if (dialogResult == DialogResult.Yes)
                    {
                        RefreshForm();
                    }
                    else if (dialogResult == DialogResult.No) //If they choose no, exit the form
                    {
                        OpenDash();
                        this.Close();
                    }
                }

            }
            else //If user is editing information, use an UPDATE statement, not an INSERT statement
            {

                //Collect all information from form
                isbn = Int32.Parse(txtISBN.Text);
                title = txtTitle.Text;
                language = cmbLang.Text;
                bindingName = cmbBinding.Text;
                numCopies = (int)nudCopies.Value;
                category = cmbCategory.Text;
                pubYear = dtpPubYear.Text;
                shelfNo = Int32.Parse(cmbShelfNo.Text);
                floorNo = Int32.Parse(cmbFloorNo.Text);

                //Insert all that information into a book object
                Book newBook = new Book(isbn, title, language, bindingName, numCopies, 0, category, pubYear, "", shelfNo, floorNo);

                //Insert the book into the databse
                LibraryDB editBook = new LibraryDB();
                editBook.insertEditBook(newBook, "Edit");

                DialogResult dialogResult = MessageBox.Show("Book information has successfully been updated!", "Book Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenDash();
                this.Close();
                

            }
        }

        /// <summary>
        /// Check the form input for validity
        /// </summary>
        /// <returns></returns>
        private Boolean checkInput()
        {
            //String to hold a list of errors
            String errorList = "";

            //if they did not enter a name
            if (txtTitle.Text == "")
            {
                errorList += "- Empty Book Title\n";
            }

            //If they did not select a gender
            if (cmbLang.Text == "")
            {
                errorList += "- No Language Selected\n";
            }

            //If they did not select a gender
            if (cmbBinding.Text == "")
            {
                errorList += "- No Binding Name Selected\n";
            }

            //If they did not select a gender
            if (cmbBinding.Text == "")
            {
                errorList += "- No Category Selected\n";
            }

            //If they did not select a date of birth
            if (dtpPubYear.Text == " ")
            {
                errorList += "- No Publication Year Selected\n";
            }

            //if there are errors display them
            if (errorList != "")
            {
                MessageBox.Show("Errors with your submission:\n" + errorList, "Please Review Your Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                //Return false, input is bad
                return false; ;
            }
            else
            {
                //Return true, input is good
                return true;
            }

        }

        /// <summary>
        /// Refresh the form information
        /// </summary>
        private void RefreshForm()
        {
            //Create a database object to get the list of departments
            LibraryDB dbInfo = new LibraryDB();
            List<String> categoryList = new List<String>();
            List<String> languageList = new List<String>();
            List<String> bindingList = new List<String>();

            //To store the new student ID calculated by database
            String newBookID = "";

            //Get the new student ID
            newBookID = dbInfo.getNewID("Book");
            //Set the textbox to display new student ID (Can't be modified by user)
            txtISBN.Text = newBookID;

            //Put the list of categories into a list
            categoryList = dbInfo.getCategories();
            //Put the list of languages into a list
            languageList = dbInfo.getLanguages();
            //Put the list of binding names into a list
            bindingList = dbInfo.getBindings();

            //Set the depart ment combo box datasource as the department list
            cmbCategory.DataSource = categoryList;
            cmbLang.DataSource = languageList;
            cmbBinding.DataSource = bindingList;

            //Makes it so there is no selected date when the user loads the form
            dtpPubYear.CustomFormat = " ";

            //Clear the name data (for when the user wants to enter another student
            txtTitle.Text = "";


            //Makes it so there is no selected option starting off
            cmbLang.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbBinding.SelectedIndex = -1;
            //This one is selected to the first option
            cmbFloorNo.SelectedIndex = 0;

            //Sets it so the maximum date is today. Technically no one can be born today and enter into the database, but its ok
            dtpPubYear.MaxDate = DateTime.Now;
        }

        //Closes the current form and shows the dashboard again
        private void OpenDash()
        {
            //Goes through all the open forms and finds dashboard to show it again
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "frmDashboard")
                {
                    Application.OpenForms[i].Show();
                }
            }

        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            //Load all the beginning form data 
            RefreshForm();

            //If the user is in edit mode
            if (editOrAdd == "Edit")
            {
                //Put get all the student information and put it in the text boxes
                txtISBN.Text = isbn.ToString();
                txtTitle.Text = bookTitle;
                cmbLang.Text = language;
                cmbBinding.Text = bindingName;
                nudCopies.Value = numCopies;
                cmbCategory.Text = category;
                dtpPubYear.Text = pubYear;
                cmbFloorNo.Text = floorNum.ToString();

                //Set the form title
                this.Text = "Edit Book Information";
            }
        }

        //When the user changes the value of the date time picker
        private void dtpPubYear_ValueChanged(object sender, EventArgs e)
        {
            //Customer date format
            dtpPubYear.CustomFormat = "yyyy-MM-dd";
        }

        private void cmbFloorNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create a database object to get the list of departments
            LibraryDB dbInfo = new LibraryDB();
            List<String> shelfList = new List<String>();
            shelfList = dbInfo.getShelfNums(Int32.Parse(cmbFloorNo.Text));

            cmbShelfNo.DataSource = shelfList;

        }
    }
}
