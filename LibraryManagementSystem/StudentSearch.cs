﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class StudentSearch : Form
    {

        //SQL Connection object
        SqlConnection conn = new SqlConnection();

        public StudentSearch()
        {
            InitializeComponent();
        }

        private void StudentSearch_Load(object sender, EventArgs e)
        {
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

            //Empty the combo boxes to give user a blank slate to search on
            cmbDepartment.Text = "";
            cmbGender.Text = "";


        }

        private void btnSearch_Click(object sender, EventArgs e)
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

            //If the user correctly input a date of birth, put it in the variable
            if (txtDOB.MaskCompleted)
            {
                DOB = txtDOB.Text;
            }

            //All of user input into variables
            String name = txtName.Text;
            String gender = cmbGender.Text;
            String dept = cmbDepartment.Text;

            //Create a new student with properties set
            Student searchStudent = new Student(id, name, gender, DOB, 0, dept, "");

            //Create a connection to the database and search for the student
            LibraryDB student = new LibraryDB();
            //Search for the student 
            studentSearchResult = student.StudentSearch(searchStudent);

            //Load the student data into the data grid view
            dgvStudent.DataSource = studentSearchResult;

            dgvStudent.Columns[0].HeaderText = "Student ID";
            dgvStudent.Columns[1].HeaderText = "Student Name";
            dgvStudent.Columns[3].HeaderText = "Date of Birth";
            dgvStudent.Columns[4].HeaderText = "Borrower ID";
            dgvStudent.Columns[5].HeaderText = "Department";
            dgvStudent.Columns[6].HeaderText = "Contact Number";
            dgvStudent.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy"; ;

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtID.Text, "[^0-9]"))
            {
                txtID.Text = txtID.Text.Remove(txtID.Text.Length - 1);
            }
        }

    }
}