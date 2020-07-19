using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment2_Winform.Classes
{
    class File
    {
        private string _path;

        public string Path { get => _path; set => _path = value; }

        public List<User> GetUserList(string path)
        {
            this.Path = path;
            List<User> userGroup = new List<User>();
            using (StreamReader sr = new StreamReader(Path))
            {
               
                    while (sr.Peek() >= 0)
                    {
                        string str = sr.ReadLine();
                        string[] strArray = str.Split(',');
                        User user = new User()
                        {
                            UserName = strArray[0],
                            PassWord = strArray[1],
                            Editable = strArray[2],
                            FirstName = strArray[3],
                            LastName = strArray[4],
                            DateOfBirth = strArray[5]
                        };
                        userGroup.Add(user);
                    }
                
               
                return userGroup;
            }
        }
    }
}
    


          

