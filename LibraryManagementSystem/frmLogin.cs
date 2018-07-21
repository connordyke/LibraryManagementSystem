using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace LibraryManagementSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            Boolean canConnect = false;
            LibraryDB databaseConnection = new LibraryDB();
            canConnect = databaseConnection.CheckConnection();

            //If we can't connect to database, disable all login fields and display an error message
            if (!canConnect)
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                btnLogin.Enabled = false;
                MessageBox.Show("Cannot establish connection to database, please contact your Database Administrator", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Boolean loginSuccess = false;

            //Open the Library database (for checking if the user exists)
            LibraryDB loginUser = new LibraryDB();
            //Send username and password, check if it matches database records
            loginSuccess = loginUser.Login(txtUsername.Text, txtPassword.Text);
            

            if (loginSuccess)
            {
                frmDashboard dashboard = new frmDashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                //Tell the user they provided wrong username or password. Not telling them which avoids brute force attempts
                MessageBox.Show("Username and/or password provided was incorrect, please try again!", "Login Attempt Failed");
                //Clear username and password textbox
                txtUsername.Text = "";
                txtPassword.Text = "";
                //Give focus to username textbox
                txtUsername.Focus();
            }
            

        }
    }
}
