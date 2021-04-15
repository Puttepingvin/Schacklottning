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
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 parent)
        {
            InitializeComponent();
            form1 = parent;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntAddPlayerConfirm_Click(object sender, EventArgs e)
        {
            String nameFirst = txtAddPlayerName1.Text;
            String nameLast = txtAddPlayerName2.Text;
            form1.AddPlayer(nameFirst, nameLast);
            this.Close();
        }
    }
}
