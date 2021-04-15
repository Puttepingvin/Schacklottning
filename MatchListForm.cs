using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schacklottning
{
    public partial class MatchListForm : Form
    {
        private List<Match> matches;
        private List<TextBox> boxes;
        MainForm mainWindow;
        public MatchListForm(object matches, MainForm opener)
        {
            InitializeComponent();
            this.matches = (List<Match>)matches;
            this.boxes = new List<TextBox>();
            mainWindow = opener;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int whiteX = 10;
            int blackX = 210;
            int boxX = 410;
            int currY = 10;
            foreach(Match m in matches)
            {
                Label lblName = new Label();
                lblName.Text = m.white.ToString();
                lblName.Location = new Point(whiteX, currY);
                this.Controls.Add(lblName);
                lblName = new Label();
                lblName.Text = m.black.ToString();
                lblName.Location = new Point(blackX, currY);
                this.Controls.Add(lblName);

                TextBox txtBox = new TextBox();
                txtBox.Width = 75;
                txtBox.Location = new Point(boxX, currY);
                txtBox.KeyDown += new KeyEventHandler((s, ev) => this.textBoxx_TextChanged(s, ev, 1));
                txtBox.TextChanged += new EventHandler((s, ev) => this.textBox1_TextChanged(s, ev));
                if(m.Result != -1)
                {
                    txtBox.Text = m.resToString();
                }
                else
                {
                    txtBox.Text = "";
                }
                this.Controls.Add(txtBox);
                boxes.Add(txtBox);

                currY += 50;
            }
            this.Height = currY + 100;
            btnOK.Height = 50;
            btnCancel.Height = 50;
            btnPrint.Height = 50;
            btnOK.Location = new Point(btnOK.Location.X, currY);
            btnCancel.Location = new Point(btnCancel.Location.X, currY);
            btnPrint.Location = new Point(btnPrint.Location.X, currY);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //These two eventhandlers make sure the textboxes have one of four values that are autofilled from the first character
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!(lastKeyPressed is null))
            {

                TextBox snd = (TextBox)sender;
                if(lastKeyPressed.CompareTo("D1") == 0 || lastKeyPressed.CompareTo("NumPad1") == 0)
                {
                    snd.Text = "1-0";
                }
                else if (lastKeyPressed.CompareTo("D0") == 0 || lastKeyPressed.CompareTo("NumPad0") == 0)
                {
                    snd.Text = "0-1";
                }
                else if (lastKeyPressed.CompareTo("R") == 0)
                {
                    snd.Text = "Remi";
                }
                else
                {
                    Console.WriteLine(lastKeyPressed);
                    snd.Text = "";
                }
            }

        }
        private void textBoxx_TextChanged(object sender, KeyEventArgs e,int n)
        {
            this.lastKeyPressed = e.KeyCode.ToString();
        }
        private string lastKeyPressed;

        //Sets the results in the match variables and returns to main windows
        //All the score/elo logic happens in the match class on the set action
        private void btnOK_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].Text.CompareTo("1-0") == 0)
                {
                    matches[i].Result = 1;
                }
                if (boxes[i].Text.CompareTo("0-1") == 0)
                {
                    matches[i].Result = 2;
                }
                if (boxes[i].Text.CompareTo("Remi") == 0)
                {
                    matches[i].Result = 3;
                }
            }
            mainWindow.Focus();
            mainWindow.UpdateLists();
            this.Close();
        }

        //This is a little hack to print something useful with minimal effort, placeholder
        private void btnPrint_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        //Close without saving
        private void btnCancel_Click(object sender, EventArgs e)
        {
            mainWindow.Focus();
            this.Close();
        }
    }
}
