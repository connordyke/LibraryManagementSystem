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
    public partial class frmNewStudent : Form
    {
        public frmNewStudent()
        {
            InitializeComponent();
        }

        private void frmNewStudent_Load(object sender, EventArgs e)
        {
            //Create a database object to get the list of departments
            LibraryDB dbInfo = new LibraryDB();
            List<String> departmentsList = new List<String>();
            //To store the new student ID calculated by database
            String newStudentID = "";

            //Get the new student ID
            newStudentID = dbInfo.getNewID();
            //Set the textbox to display new student ID (Can't be modified by user)
            txtID.Text = newStudentID;

            //Put the list of departments into a list
            departmentsList = dbInfo.getDepartments();

            //Set the depart ment combo box datasource as the department list
            cmbDepartments.DataSource = departmentsList;

            //Makes it so there is no selected date when the user loads the form
            dtpDOB.CustomFormat = " ";

            //Makes it so there is no selected department when the form is loaded
            cmbDepartments.SelectedIndex = -1;

            //Sets it so the maximum date is today. Technically no one can be born today and enter into the database, but its ok
            dtpDOB.MaxDate = DateTime.Now;

        }

        //When the user changes the value of the date time picker
        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            //Customer date format
            dtpDOB.CustomFormat = "yyyy-MM-dd";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = 0;
            String name = "";
            String gender = "";
            String dob = "";
            String dept = "";
            string contactNum = "";

            //String to hold a list of errors
            String errorList = "";

            //if they did not enter a name
            if (txtName.Text == "")
            {
                errorList += "- Empty Name\n";
            }

            //If they did not select a gender
            if (cmbGender.Text == "")
            {
                errorList += "- No Gender Selected\n";
            }

            //If they did not select a date of birth
            if (dtpDOB.Text == " ")
            {
                errorList += "- No Date of Birth Selected\n";
            }

            //If they did not select a department
            if (cmbDepartments.Text == "")
            {
                errorList += "- No Department Selected\n";
            }

            //If a contact number was not entered or the mask was not completed
            if (txtContactNum.Text == "" || !txtContactNum.MaskCompleted)
            {
                errorList += "- Incorrect Contact Number\n";
            }

            //if there are errors display them
            if (errorList != "")
            {
                MessageBox.Show("Errors with your submission:\n" + errorList, "Please Review Your Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else{ //Else, enter the new data into the database

                //Collect all information from form
                id = Int32.Parse(txtID.Text);
                name = txtName.Text;
                gender = cmbGender.Text;
                dob = dtpDOB.Text;
                dept = cmbDepartments.Text;
                contactNum = txtContactNum.Text;

                //Insert all that information into a student object
                Student newStudent = new Student(id, name, gender, dob, dept, contactNum);

                //Insert the student into the databse
                LibraryDB enterNewStudent = new LibraryDB();
                enterNewStudent.insertNewStudent(newStudent);

            }

        }

        private void frmNewStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
