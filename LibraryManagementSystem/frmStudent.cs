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
    public partial class frmStudent : Form
    {

        public String editOrAdd;
        public string id;
        public string name;
        public string gender;
        public string dob;
        public string dept;
        public string contactNum;

        public frmStudent()
        {
            InitializeComponent();

        }

        public frmStudent(String _editOrAdd, Student editStudent)
        {
            InitializeComponent();

            editOrAdd = _editOrAdd;

            //Take all student information and store in variables (to be put into textboxes to display information)
            id = editStudent.Student_id.ToString();
            name = editStudent.Student_name;
            gender = editStudent.Gender;
            dob = editStudent.Dob;
            dept = editStudent.Dept;
            contactNum = editStudent.ContactNum;
        }

        private void frmNewStudent_Load(object sender, EventArgs e)
        {

            //Load all the beginning form data 
            RefreshForm();

            //If the user is in edit mode
            if (editOrAdd == "Edit")
            {
                //Put get all the student information and put it in the text boxes
                txtID.Text = id;
                txtName.Text = name;
                cmbGender.Text = gender;
                dtpDOB.Text = dob;
                cmbDepartments.Text = dept;
                txtContactNum.Text = contactNum;
                //Set the form title
                this.Text = "Edit Student Information";
            }



        }

        //When the user changes the value of the date time picker
        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            //Customer date format
            dtpDOB.CustomFormat = "yyyy-MM-dd";
        }

        /// <summary>
        /// Button to submit information about a new student, or an existing student. Checks for input validity, and checks whether the user is editing or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            //Create variables and initialize them
            int id = 0;
            String name = "";
            String gender = "";
            String dob = "";
            String dept = "";
            string contactNum = "";

            //If the user is not editing (adding a new student, then collect their information)
            if (editOrAdd != "Edit")
            {

                //If input is correct, add the user
                if (checkInput())
                {


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
                    enterNewStudent.insertEditStudent(newStudent, "Add");

                    DialogResult dialogResult = MessageBox.Show("Student has been successfully added!\nWould you like to add another?", "Student Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
                id = Int32.Parse(txtID.Text);
                name = txtName.Text;
                gender = cmbGender.Text;
                dob = dtpDOB.Text;
                dept = cmbDepartments.Text;
                contactNum = txtContactNum.Text;

                //Insert all that information into a student object
                Student newInfo = new Student(id, name, gender, dob, dept, contactNum);

                //Insert the student into the databse
                LibraryDB editStudent = new LibraryDB();
                editStudent.insertEditStudent(newInfo, "Edit");

                DialogResult dialogResult = MessageBox.Show("Students information has successfully been updated!", "Student Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            List<String> departmentsList = new List<String>();
            //To store the new student ID calculated by database
            String newStudentID = "";

            //Get the new student ID
            newStudentID = dbInfo.getNewID("Student");
            //Set the textbox to display new student ID (Can't be modified by user)
            txtID.Text = newStudentID;

            //Put the list of departments into a list
            departmentsList = dbInfo.getDepartments();

            //Set the depart ment combo box datasource as the department list
            cmbDepartments.DataSource = departmentsList;

            //Makes it so there is no selected date when the user loads the form
            dtpDOB.CustomFormat = " ";
            //Clear the name data (for when the user wants to enter another student
            txtName.Text = "";
            txtContactNum.Text = "";
            //Makes it so there is no selected option starting off
            cmbGender.SelectedIndex = -1;
            cmbDepartments.SelectedIndex = -1;

            //Sets it so the maximum date is today. Technically no one can be born today and enter into the database, but its ok
            dtpDOB.MaxDate = DateTime.Now;
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

        private void frmStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
               OpenDash();
            }
 
        }
    }



}
