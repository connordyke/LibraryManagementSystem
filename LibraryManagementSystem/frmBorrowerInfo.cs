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
    public partial class frmBorrowerInfo : Form
    {

        String isbn;


        public frmBorrowerInfo(Book issueBook)
        {
            InitializeComponent();

            isbn = issueBook.Isbn.ToString();

            //Displays todays date
            dtpIssueDate.Value = DateTime.Now;
            //Custom format
            dtpIssueDate.CustomFormat = "yyyy-MM-dd";

            //Displays a week from todays date
            dtpReturnDate.MinDate = DateTime.Now.AddDays(7);
            dtpReturnDate.Value = DateTime.Now.AddDays(7);
            //Custom format
            dtpReturnDate.CustomFormat = "yyyy-MM-dd";

            //Set the issuedby textbox
            txtIssuedBy.Text = CurrentUser.Id.ToString();

            //Set the isbn code textbox
            txtISBN.Text = isbn;


        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            //If the student ID is empty or mask is not complete, show the error
            if (txtStudentID.Text == "" || !txtStudentID.MaskCompleted)
            {
                MessageBox.Show("Pleas enter a valid student ID", "Invalid Student ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //The data is good, enter it into the borrower table
            {
                //LibraryDB object to insert the new borrow book row
                LibraryDB borrowBook = new LibraryDB();
                borrowBook.insertNewBorrow(Int32.Parse(txtStudentID.Text), Int32.Parse(txtISBN.Text), dtpIssueDate.Text, dtpReturnDate.Text, Int32.Parse(txtIssuedBy.Text));

                //Tells the user they successfully issued the book
                MessageBox.Show("Book has successfully been issued.", "Successful Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Goes through all the open forms and finds dashboard to show it again
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Open the dashboard form
                    if (Application.OpenForms[i].Name == "frmDashboard")
                    {
                        Application.OpenForms[i].Show();
                    }

                    //Close the Issue book form
                    if (Application.OpenForms[i].Name == "frmIssueReturn")
                    {
                        Application.OpenForms[i].Close();
                    }
                }

                //Close 
                this.Close();
                    
                
            }
        }

        private void frmBorrowerInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
