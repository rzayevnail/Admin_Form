using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Windows.Controls.Primitives;
using ServiceStack;

namespace Account1
{
    public partial class FrmMessage : Form
    {
        public FrmMessage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                mailMessage.To.Add(textBox1.Text);
                mailMessage.From = new MailAddress("rzayevnail03@gmail.com");
                mailMessage.Subject = textBox2.Text;
                mailMessage.Body = textBox3.Text;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("rzayevnail03@gmail.com", "ikzcbpbkmmjkbvnj");

                smtp.Send(mailMessage);

                MessageBox.Show("E-posta başarıyla gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}



