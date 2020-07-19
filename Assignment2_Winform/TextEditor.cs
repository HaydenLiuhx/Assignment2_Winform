using Assignment2_Winform.Classes;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment2_Winform;
using System.Globalization;
using System.IO;

namespace Assignment2_Winform
{
    public partial class Text_Editor : Form
    {
        private Operate operate;
        //private string string1;
        //public string String1
        //{
        //    get
        //    {
        //        return string1;
        //    }
        //    set
        //    {
        //        string1 = value;
        //    }
        //}
       
        //public User ThisUser { get; set; }
        public string TextValue
        {
            get
            {
                return toolStripLabel4.Text;
            }
            set
            {
                toolStripLabel4.Text = value;
            }
        }
        public void FontSizeChange(int size)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, size);
        }
        public Text_Editor()
        {
            InitializeComponent();
            addNum();
            richTextBox1.LoadFile("ZenOfPython.txt",RichTextBoxStreamType.PlainText);
            //toolStripLabel4.Text = string1;
        }

        //public Text_Editor(User user)
        //{
        //    InitializeComponent();
        //    this.thisuser = user;
        //}

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
             if(keys == (Keys.X | Keys.Control))
            {

                cutToolStripMenuItem_Click(this, null);
                return true;
                
            }
             else if (keys == (Keys.C | Keys.Control))
            {
                copyToolStripMenuItem_Click(this, null);
                return true;
            }
             else if(keys == (Keys.V | Keys.Control))
            {
                pasteToolStripMenuItem_Click(this, null);
                return true;
            }
            return base.ProcessCmdKey(ref message, keys);
        }
       

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog of = new OpenFileDialog();
            //of.ShowDialog();
            //richTextBox1.Text = of.FileName;
            if (MessageBox.Show("Please save your record before creating",
                "Ok", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Clear the editor
                operate = new Operate();
                richTextBox1.Rtf = string.Empty;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void addNum()
        {
            for(int i = 8; i < 21; i++)
            {
                toolStripComboBox1.Items.Add(i);
            }
        }
       
       
       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Text_Editor_Load(object sender, EventArgs e)
        {

        }

        private void TextEditor_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void openCtrlQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog GetData = new OpenFileDialog();
            GetData.Multiselect = false;
            GetData.Title = "Please choose file";
            GetData.InitialDirectory = @"C:\";
            GetData.Filter = "txt file(*.txt)|*.txt";
            string script = " ";
            if (GetData.ShowDialog() == DialogResult.OK)
            {
                script = GetData.FileName;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            //dialog.Description = "Please choose file path";

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    string foldPath = dialog.SelectedPath;
            //    DirectoryInfo theFolder = new DirectoryInfo(foldPath);

            //    //theFolder include folder path

            //    FileInfo[] dirInfo = theFolder.GetFiles();
            //    //retrieve folder                
            //    foreach (FileInfo file in dirInfo)
            //    {
            //        MessageBox.Show(file.ToString());
            //    }
            //}
            operate = new Operate();
            if (!String.IsNullOrEmpty(operate.Path))
            {
                operate.OperateSave();
            }
            else
            {
                // We don't know where to save the file, so execute the Save As process
                saveAsToolStripMenuItem_Click(this, null);
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Bold_Click(object sender, EventArgs e)
        {
            Font newFont;
            //get the current selected text
            Font oldFont = this.richTextBox1.SelectionFont;
            //judge whether the current is bold style
            if (oldFont.Bold)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            }
            else
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            }
            this.richTextBox1.SelectionFont = newFont;
            
        }

        private void Italic_Click(object sender, EventArgs e)
        {
            Font oldFont = this.richTextBox1.SelectionFont;
            Font newFont;
            if (oldFont.Italic)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            }
            else
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);
            }
            this.richTextBox1.SelectionFont = newFont;
        }

        private void UnderLine_Click(object sender, EventArgs e)
        {
            Font oldFont = this.richTextBox1.SelectionFont;
            Font newFont;
            if (oldFont.Underline)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            }
            else
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);
            }
            this.richTextBox1.SelectionFont = newFont;
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextEditor_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenu contextMenu = new ContextMenu();
                MenuItem menuItem = new MenuItem("Cut");
                menuItem.Click += new EventHandler(Cut);
                contextMenu.MenuItems.Add(menuItem);
            }
        }
        private void Cut(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        public void Paste()
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Text += Clipboard.GetText(TextDataFormat.Text).ToString();
            }
        }
        public void Copy()
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }
        

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton11_Click_1(object sender, EventArgs e)
        {
            About about = new About();
            about.FormClosed += TextEditor_FormClosing;
            
            about.Show();
            this.Hide();
        }
        private void TextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
        private void TextEditor_FormClosing(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.FormClosed += TextEditor_FormClosing;

            about.Show();
            this.Hide();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please choose file path";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                DirectoryInfo theFolder = new DirectoryInfo(foldPath);

                //theFolder include folder path

                FileInfo[] dirInfo = theFolder.GetFiles();
                //retrieve folder                
                foreach (FileInfo file in dirInfo)
                {
                    MessageBox.Show(file.ToString());
                }
            }
        }

        private void Text_Editor_TextChanged(object sender, EventArgs e)
        {
            //operate.ChangeSize(int.Parse(toolStripComboBox1.Text));
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, int.Parse(toolStripComboBox1.Text));
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem_Click(this, null);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1_Click(this, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(this, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openCtrlQToolStripMenuItem_Click(this, null);
        }
    }
}
