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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //Get the name from the logged in user and display it in the corner
            lblName.Text = "Welcome, " + LibraryDB.currentUser.Name + "!";
        }

        private void btnStudentSearch_Click(object sender, EventArgs e)
        {
            StudentSearch studentSearch = new StudentSearch();
            studentSearch.Show();
            this.Hide();
        }

        private void btnBookSeach_Click(object sender, EventArgs e)
        {
            BookSearch bookSearch = new BookSearch();
            bookSearch.Show();
            this.Hide();
        }

        private void btnAvail_Click(object sender, EventArgs e)
        {

        }
    }
}
