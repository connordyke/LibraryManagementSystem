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
    public partial class BookSearch : Form
    {
        public BookSearch()
        {
            InitializeComponent();
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            //Create a list of books to store result(s) in
            List<Book> bookSearchResult = new List<Book>();

            //Publication year is empty
            String pubYear = "";

            //Initially set ISBN to 0 (nothing entered in textbox)
            int ISBN = 0;

            //If ISBN text box has something in it, replace 0 with the ISBN input by user
            if (txtISBN.Text != "")
            {
                ISBN = Int32.Parse(txtISBN.Text);

            }

            //If the user correctly input a publication date, put it in the variable
            if (txtPubYear.MaskCompleted)
            {
                pubYear = txtPubYear.Text;
            }

            //All of user input into variables
            String title = txtTitle.Text;
            String lang = cmbLang.Text;
            String category = cmbCategory.Text;

            //Create a new student with properties set
            Book searchBook = new Book(ISBN, title, lang, category, pubYear);

            //Create a connection to the database and search for the student
            LibraryDB book = new LibraryDB();
            //Search for the student 
            bookSearchResult = book.bookSearch(searchBook);

            //Load the student data into the data grid view
            dgvBooks.DataSource = bookSearchResult;

            dgvBooks.Columns[0].HeaderText = "ISBN";
            dgvBooks.Columns[1].HeaderText = "Book Title";
            dgvBooks.Columns[2].HeaderText = "Language";
            dgvBooks.Columns[3].HeaderText = "Binding Name";
            dgvBooks.Columns[4].HeaderText = "Number of Copies";
            dgvBooks.Columns[5].HeaderText = "Available Copies";
            dgvBooks.Columns[6].HeaderText = "Category";
            dgvBooks.Columns[7].HeaderText = "Publication Year";

        } 

        private void txtISBN_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtISBN.Text, "[^0-9]"))
            {
                txtISBN.Text = txtISBN.Text.Remove(txtISBN.Text.Length - 1);
            }
        }

        private void BookSearch_Load(object sender, EventArgs e)
        {
            //List of strings (departments in database)
            List<String> languagesList = new List<String>();
            //List of strings (genders in database)
            List<String> categoriesList = new List<String>();
            //Create a new database object to search from
            LibraryDB formInfo = new LibraryDB();

            //Retrieve list of departments from the library DB
            languagesList = formInfo.getLanguages();
            //Retrieve list of genders from the library DB
            categoriesList = formInfo.getCategories();

            //Fill the combo box with the list of departments
            cmbLang.DataSource = languagesList;
            cmbCategory.DataSource = categoriesList;

            //Empty the combo boxes to give user a blank slate to search on
            cmbLang.Text = "";
            cmbCategory.Text = "";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear all text boxes
            txtISBN.Text = "";
            txtTitle.Text = "";
            cmbLang.Text = "";
            txtPubYear.Text = "";
            cmbCategory.Text = "";

            //Give focus to ISBN text box (first text box)
            txtISBN.Focus();

            //Click search button to show all results
            btnSearch.PerformClick();
        }

        private void txtPubYear_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                tipYear.ToolTipTitle = "Invalid Date";
                tipYear.Show("The data you supplied must be a valid date in the format mm/dd/yyyy.", txtPubYear);
            }
        }

    }
    
}
