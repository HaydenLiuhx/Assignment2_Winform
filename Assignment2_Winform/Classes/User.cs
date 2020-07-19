using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Winform.Classes
{
    class User
    {
        public string editMode;
        public string viewMode;
        public List<User> userGroup = new List<User>();
        private string _userName;
        private string _passWord;
        private string _editable;
        private string _firstName;
        private string _lastName;
        private string _dateOfBirth;

        public string UserName { get => _userName; set => _userName = value; }
        public string PassWord { get => _passWord; set => _passWord = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public string Editable { get => _editable; set => _editable = value; }

        public bool IsVaild(string username, string password)
        {
            for (int i = 0; i < userGroup.Count; i++)
            {
                if ((userGroup[i].UserName == username) && (userGroup[i].PassWord == password))
                {
                    return true;
                }
            }
            return false;
            
        }

        public override string ToString()
        {
            return string.Format(UserName + "," + PassWord + "," + Editable + "," + FirstName + "," + LastName + "," + DateOfBirth);

        }
        



    }


}
