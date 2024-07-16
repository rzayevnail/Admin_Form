using MaterialDesignThemes.Wpf.Internal;
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
    public partial class FrmWhatsapp : Form
    {
        public FrmWhatsapp()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendWhatsApp(txtNumber.Text, richTextMessage.Text);
            clear();
        }
        public void clear()
        {
            txtNumber.ResetText();
            richTextMessage.ResetText();
        }

        private void sendWhatsApp(string number, string message)
        {
            try
            {
                if (number.IsNullOrEmpty())
                {
                    MessageBox.Show("number added!!!");
                }
                if (number.Length <= 0)
                {
                    number = "+994" + number;
                }
                number = number.Replace(" ", "");
                System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone=" + number + "&text=" + message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
