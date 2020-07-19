using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Assignment2_Winform.Classes;

namespace Assignment2_Winform
{
    public partial class Login : Form
    {
        Classes.File file = new Classes.File();
        public Login()
        {
            InitializeComponent();
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            List<User> list = file.GetUserList("login.txt");
            bool exist = false;
            foreach(User user in list)
            {
                if(((txtUsername.Text == user.UserName)&&(txtPassword.Text == user.PassWord)))
                {
                    Text_Editor textEditor = new Text_Editor();
                    textEditor.TextValue = txtUsername.Text;
                    //textEditor.String1 = txtUsername.Text;
                    textEditor.FormClosed += Login_FormClosing;
                    textEditor.Show();
                    this.Hide();
                    exist = true;

                    //textEditor.String1 = txtUsername.Text;
                    
                }
            }
            if (exist == false)
            {

                MessageBox.Show("check your username and password", "failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            String u = txtUsername.Text;
            Text_Editor text_Editor = new Text_Editor();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.FormClosing += Login_FormClosing;
            signUp.Show();
            this.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
        private void Login_FormClosing(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        
    }
    }

