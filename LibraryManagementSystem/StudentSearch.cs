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
    public partial class StudentSearch : Form
    {
        public StudentSearch()
        {
            InitializeComponent();
        }

        private void StudentSearch_Load(object sender, EventArgs e)
        {
            //List of strings (departments in database)
            List<String> departmentsList = new List<String>();
            //Create a new database object to search from
            LibraryDB departments = new LibraryDB();

            //Retrieve list of departments from the library DB
            departmentsList = departments.getDepartments();
            
            //Fill the combo box with the list of departments
            cmbDepartments.DataSource = departmentsList;

        }
    }
}
