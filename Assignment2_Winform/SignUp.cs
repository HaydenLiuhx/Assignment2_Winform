using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment2_Winform.Classes;
using System.IO;

namespace Assignment2_Winform
{
    public partial class SignUp : Form
    {
        Classes.File file = new Classes.File();
        public SignUp()
        {
            InitializeComponent();
            comboBox.Items.Add("View");
            comboBox.Items.Add("Edit");
            
        }
       

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private User CreateUser()
        {
            User user = new User();
            user.UserName = txtUsername.Text;
            user.PassWord = txtPassword.Text;

            user.FirstName = txtFirstname.Text;
            user.LastName = txtLastname.Text;
            user.DateOfBirth = dateTimePicker1.Value.ToString();
            user.Editable = comboBox.Text;
            return user;
        }
        private bool FormFinish()
        {
            foreach (Control txt in this.Controls)
            {
                if(txt is TextBox)
                {
                    if (String.IsNullOrEmpty(txt.Text))
                    {
                        throw new Exception("Please Check it again");
                    }
                }
               
            }
            if (!(txtPassword.Text == txtReEnter.Text))
            {
                throw new Exception("Please Check Re-Enter Password");
            }
            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (FormFinish())
                {
                    MessageBox.Show("Sign up Successfully", "New account created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<User> list = file.GetUserList("login.txt");
                    list.Add(CreateUser());
                    StreamWriter sw = new StreamWriter("login.txt", true, System.Text.Encoding.Default);
                    
                    string newText = list[list.Count-1].ToString();
                    sw.WriteLine(newText);
                    sw.Close();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed to create", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
