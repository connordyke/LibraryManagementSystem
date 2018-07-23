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
    public partial class frmReturnInfo : Form
    {

        String isbn;
        String borrowerNum;


        public frmReturnInfo(Book issueBook, int studentID)
        {
            InitializeComponent();

            isbn = issueBook.Isbn.ToString();

            txtStudentID.Text = studentID.ToString();

            //Displays todays date
            dtpActualDate.Value = DateTime.Now;
            //Custom format
            dtpActualDate.CustomFormat = "yyyy-MM-dd";

            //Set the isbn code textbox
            txtISBN.Text = isbn;

            LibraryDB dateAndBorrow = new LibraryDB();

            List<String> dateAndBorrowNum = new List<string>();

            dateAndBorrowNum = dateAndBorrow.getReturnDateAndBorrowNum(Int32.Parse(isbn), studentID);


            //If there was no record found
            if (dateAndBorrowNum.Count == 0)
            {
                //Tell the user that the student has not taken this book out
                MessageBox.Show("Student #" + studentID + " has not taken out this book", "Wrong Student ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                
                //Goes through all the open forms and finds dashboard to show it again
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i].Name == "frmReturnIssueReturn")
                    {
                        Application.OpenForms[i].Show();
                    }
                }

                DelayClose();

            }
            else
            {
                //Get the borrower num
                borrowerNum = dateAndBorrowNum[1].ToString();
                //Set the return date
                dtpReturnDate.Text = dateAndBorrowNum[0].ToString();
            }

            //Custom format
            dtpReturnDate.CustomFormat = "yyyy-MM-dd";




        }


        public async void DelayClose()
        {
            await Task.Delay(100);
            this.Enabled = true;
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            LibraryDB returnBookDB = new LibraryDB();
            returnBookDB.returnBook(Int32.Parse(txtISBN.Text), Int32.Parse(txtStudentID.Text), Int32.Parse(borrowerNum), dtpActualDate.Text);

            //Tells the user they successfully issued the book
            MessageBox.Show("Book has successfully been returned.", "Successful Return", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
}
