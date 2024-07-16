using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Face;
using QRCoder;
using ServiceStack.OrmLite;
using Ubiety.Dns.Core.Records;
using System.Drawing.Printing;
using System.Xml.Linq;

namespace Account1
{
    public partial class FrmProfile : Form
    {
        public FrmProfile()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=NAILRZAYEV\\MSSQLSERVER01;Initial Catalog=Aycicegi;Integrated Security=True");
        private void verilerigoruntule()
        {
            sql.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into Profile values (@Name,@Surname,@Contact,@Users,@Password,@FtName,@MtName,@Gmail,@GmailPassword,@Gender,@Job,@Address)", sql);
            sqlCommand.Parameters.AddWithValue("@Name", TxtName.Text);
            sqlCommand.Parameters.AddWithValue("@Surname", TxtSurname.Text);
            sqlCommand.Parameters.AddWithValue("@Contact", int.Parse(TxtContact.Text));
            sqlCommand.Parameters.AddWithValue("@Users", TxtUser.Text);
            sqlCommand.Parameters.AddWithValue("@Gmail", TxtGmail.Text);
            sqlCommand.Parameters.AddWithValue("@Password", TxtPassword.Text);
            sqlCommand.Parameters.AddWithValue("@FtName", TxtFtName.Text);
            sqlCommand.Parameters.AddWithValue("@MtName", TxtMotherName.Text);
            sqlCommand.Parameters.AddWithValue("@GmailPassword", TxtGmailPassword.Text);
            sqlCommand.Parameters.AddWithValue("@Gender", TxtGender.Text);
            sqlCommand.Parameters.AddWithValue("@Job", TxtJob.Text);
            sqlCommand.Parameters.AddWithValue("@Address", TxtAddress.Text);
            sqlCommand.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Save");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator qR = new QRCoder.QRCodeGenerator();

            string[] qrTexts = new string[]
            {
                id_text.Text,
                TxtBirth.Text,
                TxtAddress.Text,
                TxtContact.Text,
                TxtFtName.Text,
                TxtGender.Text,
                TxtGmail.Text,
                TxtGmailPassword.Text,
                TxtJob.Text,
                TxtMotherName.Text,
                TxtSurname.Text,
                TxtUser.Text,
                TxtName.Text,
                TxtPassword.Text
            };
            QRCoder.QRCode[] qrCodes = new QRCoder.QRCode[qrTexts.Length];
            Image[] qrImages = new Image[qrTexts.Length];

            string combinedText = string.Join(",", qrTexts);
            for (int i = 0; i < qrTexts.Length; i++)
            {
                var data = qR.CreateQrCode(qrTexts[i], QRCoder.QRCodeGenerator.ECCLevel.H);
                qrCodes[i] = new QRCoder.QRCode(data);
                qrImages[i] = qrCodes[i].GetGraphic(100);
            }

            for (int i = 0; i < qrImages.Length; i++)
            {
                pictureBox2.Image = qrImages[i];
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(pictureBox2);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            verilerigoruntule();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Profil bilgilerini al
            string id = id_text.Text;
            string birth = TxtBirth.Text;
            string address = TxtAddress.Text;
            string contact = TxtContact.Text;
            string fatherName = TxtFtName.Text;
            string gender = TxtGender.Text;
            string email = TxtGmail.Text;
            string emailPassword = TxtGmailPassword.Text;
            string job = TxtJob.Text;
            string motherName = TxtMotherName.Text;
            string surname = TxtSurname.Text;
            string username = TxtUser.Text;
            string name = TxtName.Text;
            string password = TxtPassword.Text;

            // QR kodunu oluştur
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(id, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(5);

            // Yazdırma işlemi
            e.Graphics.DrawImage(qrCodeImage, new Point(10, 300));

            // Diğer profil bilgilerini yazdır
            e.Graphics.DrawString("ID: " + id, Font, Brushes.Black, new PointF(10, 10));
            e.Graphics.DrawString("Doğum Tarihi: " + birth, Font, Brushes.Black, new PointF(10, 30));
            e.Graphics.DrawString("Adres: " + address, Font, Brushes.Black, new PointF(10, 50));
            e.Graphics.DrawString("İletişim: " + contact, Font, Brushes.Black, new PointF(10, 70));
            e.Graphics.DrawString("Baba Adı: " + fatherName, Font, Brushes.Black, new PointF(10, 90));
            e.Graphics.DrawString("Cinsiyet: " + gender, Font, Brushes.Black, new PointF(10, 110));
            e.Graphics.DrawString("E-posta: " + email, Font, Brushes.Black, new PointF(10, 130));
            e.Graphics.DrawString("E-posta Şifresi: " + emailPassword, Font, Brushes.Black, new PointF(10, 150));
            e.Graphics.DrawString("Meslek: " + job, Font, Brushes.Black, new PointF(10, 170));
            e.Graphics.DrawString("Anne Adı: " + motherName, Font, Brushes.Black, new PointF(10, 190));
            e.Graphics.DrawString("Soyad: " + surname, Font, Brushes.Black, new PointF(10, 210));
            e.Graphics.DrawString("Kullanıcı Adı: " + username, Font, Brushes.Black, new PointF(10, 230));
            e.Graphics.DrawString("Ad: " + name, Font, Brushes.Black, new PointF(10, 250));
            e.Graphics.DrawString("Şifre: " + password, Font, Brushes.Black, new PointF(10, 270));
            MessageBox.Show("print hazir");
        }

    }
}