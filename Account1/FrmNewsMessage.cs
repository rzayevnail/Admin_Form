using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account1
{
    public partial class FrmNewsMessage : Form
    {
        private string txtValue;

        public string TextBoxValue
        {
            get { return txtValue; }
            set { txtValue = value; }
        }

        public FrmNewsMessage()
        {
            InitializeComponent();
            TextBoxValue = textBox1.Text;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TextBoxValue = textBox1.Text;
            this.Close();
        }
    }
}
