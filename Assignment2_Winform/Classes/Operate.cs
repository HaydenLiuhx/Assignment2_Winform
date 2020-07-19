using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment2_Winform.Classes
{
    class Operate
    {
        private string content;
        private string path;
        private RichTextBox richTextBox;

        public string Content { get => content; set => content = value; }
        public string Path { get => path; set => path = value; }

        public void ChangeSize(int size)
        {
            richTextBox.SelectionFont = new System.Drawing.Font(richTextBox.SelectionFont.Name, size);
        }
        public void OperateSave()
        {
            System.IO.File.WriteAllText(this.Path, this.Content);
        }
    }
}
