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
    public partial class frmIssueReturn : Form
    {

        String issueReturn;

        public frmIssueReturn(String _issueReturn)
        {
            InitializeComponent();

            //Checks whether the user wants to issue a book or return a book
            issueReturn = _issueReturn;

        }

        private void frmIssue_Load(object sender, EventArgs e)
        {

            RefreshForm();

        }

        private void dgvIssue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //When the user clicks a cell, enable the issue button
            btnIssueReturn.Enabled = true;

            if (issueReturn == "Return")
            {
                //Make the student ID form controls show
                lblStudentID.Visible = true;
                txtStudentID.Visible = true;
            }


        }

        public void RefreshForm()
        {
            //Create a list of books to store in stock books
            List<Book> issueReturnBooks = new List<Book>();

            //Database object to use the method to get in stock books
            LibraryDB issueBook = new LibraryDB();

            //If the user wants to a book, show all the books that are in stock
            if (issueReturn == "Issue")
            {
                //Get the in stock books and put them in the list
                issueReturnBooks = issueBook.getInStockOutStockBooks("False");

                //Shows all the books in the datagrid view
                dgvIssueReturn.DataSource = issueReturnBooks;

                //Change the form text
                this.Text = "Issue a Book";

                //Change button text
                btnIssueReturn.Text = "Issue a Book";
            }
            else
            {
                //Get the in stock books and put them in the list
                issueReturnBooks = issueBook.getInStockOutStockBooks("True");

                //Shows all the books in the datagrid view
                dgvIssueReturn.DataSource = issueReturnBooks;

                //Change the form text
                this.Text = "Return a Book";

                //Change button text
                btnIssueReturn.Text = "Return a Book";


            }



            //Remove the out of stock column
            dgvIssueReturn.Columns.RemoveAt(8);

            //Column headers
            dgvIssueReturn.Columns[0].HeaderText = "ISBN";
            dgvIssueReturn.Columns[1].HeaderText = "Book\nTitle";
            dgvIssueReturn.Columns[2].HeaderText = "Language";
            dgvIssueReturn.Columns[3].HeaderText = "Binding\nName";
            dgvIssueReturn.Columns[4].HeaderText = "Original\nStock";
            dgvIssueReturn.Columns[5].HeaderText = "Current\nStock";
            dgvIssueReturn.Columns[6].HeaderText = "Category";
            dgvIssueReturn.Columns[7].HeaderText = "Publication\nYear";
            dgvIssueReturn.Columns[8].HeaderText = "Shelf";
            dgvIssueReturn.Columns[9].HeaderText = "Floor";

            //Dynamically size the data grid view each time the user searches
            int width = 0;
            foreach (DataGridViewColumn col in dgvIssueReturn.Columns)
            {
                width += col.Width;
            }
            width += dgvIssueReturn.RowHeadersWidth;

            dgvIssueReturn.ClientSize = new Size(width - 10, dgvIssueReturn.Height);
            dgvIssueReturn.BackgroundColor = System.Drawing.SystemColors.Control;

            btnIssueReturn.Enabled = false;
        }

        private void btnIssueReturn_Click(object sender, EventArgs e)
        {
            int studentID = 0;

                if (issueReturn == "Return")
                {

                    //If the user entered valid student ID let them return or issue a book
                    if (txtStudentID.Text != "" && txtStudentID.MaskCompleted)
                    {
                        studentID = Int32.Parse(txtStudentID.Text);

                        DialogResult dialogResult = MessageBox.Show("Is Student #" + studentID + " returning the book " + dgvIssueReturn.CurrentRow.Cells[1].Value.ToString() + "?", "Book Return Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        //if they choose yes, refresh the form
                        if (dialogResult == DialogResult.Yes)
                        {
                            Book returnBook = new Book(Int32.Parse(dgvIssueReturn.CurrentRow.Cells[0].Value.ToString()));

                            frmReturnInfo frmReturnInfo = new frmReturnInfo(returnBook, studentID);
                            frmReturnInfo.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Student ID", "Invalid Student ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Would you like to issue the book " + dgvIssueReturn.CurrentRow.Cells[1].Value.ToString() + "?", "Book Issue Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //if they choose yes, refresh the form
                    if (dialogResult == DialogResult.Yes)
                    {
                        Book issueBook = new Book(Int32.Parse(dgvIssueReturn.CurrentRow.Cells[0].Value.ToString()));

                        frmBorrowerInfo frmBorrowerInfo = new frmBorrowerInfo(issueBook);
                        frmBorrowerInfo.ShowDialog();
                    }
                }
        
        }

        private void frmIssueReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if the user closed the form, open dashboard
            if (e.CloseReason == CloseReason.UserClosing)
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
        }
    }
}
