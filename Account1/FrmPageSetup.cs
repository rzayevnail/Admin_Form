using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using Google.Protobuf.WellKnownTypes;
using Emgu.Util;
using Kimtoo.ThemeProvider;
using System.Drawing.Drawing2D;
using System.Threading;

namespace Account1
{
    public partial class FrmPageSetup : Form
    {
        List<string> receivedMessages = new List<string>();
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private Image currentFrame;
        public FrmPageSetup()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedFilePath = openFileDialog.FileName;
                        Image selectedImage = Image.FromFile(selectedFilePath);
                        pictureBox8.Image = selectedImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim eklenirken hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.whatsapp.com/send?phone=xxxxxxxxxxxx");//whatsapp
        }

        private void button18_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox8.Image = null;
            pictureBox8.Image = Image.FromFile("C:\\Users\\nailr\\Downloads\\user.png");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, this.Font.Size * 1.2f, this.Font.Style);
            this.Scale(new SizeF(1.2f, 1.2f));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, this.Font.Size / 1.2f, this.Font.Style);
            this.Scale(new SizeF(0.8f, 0.8f));
        }
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
                return;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (videoSource == null || !videoSource.IsRunning)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();
            }

        }
        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            videoSource.Stop();
            if (currentFrame != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "JPEG Image|*.jpg";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveDialog.FileName;
                    currentFrame.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox8.Image = bitmap;
            currentFrame = bitmap;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
                videoSource.SignalToStop();

            base.OnFormClosing(e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.FileName = "Klasör Seç";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Seçilen dosyanın yolunu al
                    string selectedPath = System.IO.Path.GetDirectoryName(dialog.FileName);

                    // Windows Gezgini'ni belirtilen klasör yolunda aç
                    Process.Start("explorer.exe", selectedPath);
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            if (settingsForm.DialogResult == DialogResult.OK)
            {

            }
            settingsForm.Dispose();
        }
        public partial class SettingsForm : Form
        {
            private void btnSave_Click(object sender, EventArgs e)
            {
                // Ayarları kaydet
                SaveSettings();

                // Ayarlar formunu kapat ve DialogResult.OK döndür
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                // Ayarlar formunu kapat ve DialogResult.Cancel döndür
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            private void SaveSettings()
            {
                // Ayarları kaydetmek için burada gerekli kodu ekleyin
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmNewsMessage frmNewsMessage = new FrmNewsMessage();
            frmNewsMessage.ShowDialog();
            receivedMessages.Add(frmNewsMessage.TextBoxValue);
            lblMessageCount.Text = receivedMessages.Count.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panelEkran.Controls.Clear();
            FrmNews frmNews = new FrmNews(receivedMessages.ToArray()) { TopLevel = false, TopMost = true };
            frmNews.Font = new Font(frmNews.Font.FontFamily, frmNews.Font.Size / 1.1f, frmNews.Font.Style);
            frmNews.Scale(new SizeF(0.9f, 0.9f));
            frmNews.FormBorderStyle = FormBorderStyle.None;
            frmNews.Dock = DockStyle.Fill;
            panelEkran.Controls.Add(frmNews);
            frmNews.Show();
            lblMessageCount.Text = " ";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panelEkran.Controls.Clear();
            FrmMessage frmNews = new FrmMessage() { TopLevel = false, TopMost = true };
            frmNews.Scale(new SizeF(0.7f, 0.7f));
            frmNews.FormBorderStyle = FormBorderStyle.None;
            frmNews.Dock = DockStyle.Fill;
            panelEkran.Controls.Add(frmNews);
            frmNews.Show();
            frmNews.Show();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelEkran.Controls.Clear();
            FrmLogin frmLogin = new FrmLogin() { TopLevel = false, TopMost = true };
            frmLogin.Font = new Font(frmLogin.Font.FontFamily, frmLogin.Font.Size / 1.1f, frmLogin.Font.Style);
            frmLogin.FormBorderStyle = FormBorderStyle.None;
            frmLogin.Dock = DockStyle.Fill;
            panelEkran.Controls.Add(frmLogin);
            frmLogin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelEkran.Controls.Clear();
            FrmTask frmTask = new FrmTask() { TopLevel = false, TopMost = true };
            frmTask.FormBorderStyle = FormBorderStyle.None;
            frmTask.Dock = DockStyle.Fill;
            panelEkran.Controls.Add(frmTask);
            frmTask.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panelEkran.Controls.Clear();
            FrmInfo frmInfo = new FrmInfo() { TopLevel = false, TopMost = true };
            frmInfo.Scale(new SizeF(0.7f, 0.7f));
            frmInfo.Text = "Bilgilendirme: Bu uygulama, kullanıcıya bazı önemli bilgiler sunmak için tasarlanmıştır. Lütfen aşağıdaki bilgilere dikkatlice göz atın:\r\n\r\nGizlilik Politikası: Bu uygulama, kullanıcıların gizliliğine büyük önem verir. Kişisel verilerinizi toplamaz, depolamaz veya üçüncü taraflarla paylaşmaz. Uygulama sadece yerel olarak çalışır ve kullanıcının cihazında depolanan verileri kullanır. Gizlilik politikamızı okumak için lütfen \"Gizlilik Politikası\" bölümünü ziyaret edin.\r\n\r\nSorumluluk Reddi: Bu uygulamanın kullanımından kaynaklanan herhangi bir sorumluluk kabul edilmez. Geliştirici, uygulamanın doğruluğu, kesintisiz çalışması veya herhangi bir hata veya hasarın oluşmaması konusunda garanti vermez. Uygulamayı kullanmadan önce, kullanıcıların kendi sorumluluğunda olduğunu ve gerekli önlemleri almaları gerektiğini unutmayın.\r\n\r\nLisans: Bu uygulama sadece eğitim amaçlıdır ve ticari kullanım için uygun değildir. Telif hakkı ve diğer fikri mülkiyet hakları yasaları tarafından korunmaktadır. Uygulamanın kodu, tasarımı ve içeriği geliştiriciye aittir ve izin almadan kopyalanamaz, dağıtılamaz veya değiştirilemez.\r\n\r\nİletişim: Herhangi bir soru, öneri veya bildiriminiz varsa, lütfen iletişim bilgilerimizden bize ulaşın. Kullanıcı geri bildirimlerini önemsiyoruz ve uygulamayı daha iyi hale getirmek için kullanıcıların görüşlerini dikkate alıyoruz.\r\n\r\nGüncellemeler: Bu uygulamanın zaman zaman güncelleneceğini unutmayın. Güncellemeler, hata düzeltmeleri, yeni özellikler veya performans iyileştirmeleri içerebilir. Uygulamanın en son sürümünü kullanmanızı öneririz.\r\n\r\nLütfen bu bilgilere dikkat edin ve uygulamayı kullanmadan önce gerekli önlemleri alın. Uygulamayı kullanarak aşağıdaki kuralları kabul etmiş sayılırsınız:\r\n\r\nUygulamanın kullanımıyla ilgili tüm yasal gerekliliklere uymayı kabul ediyorsunuz.\r\nUygulamayı izinsiz olarak değiştirmeyeceğinizi veya kötüye kullanmayacağınızı taahhüt ediyorsunuz.\r\nGeliştirici, uygulamanın yanlış kullanımından kaynaklanan herhangi bir sorumluluğu kabul etmez.\r\nTeşekkürler!";
            frmInfo.Text = frmInfo.Text;
            frmInfo.FormBorderStyle = FormBorderStyle.None;
            frmInfo.Dock = DockStyle.Fill;
            panelEkran.Controls.Add(frmInfo);
            frmInfo.Show();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            panelEkran.Controls.Clear();
            FrmProfile frmProfile = new FrmProfile() { TopLevel = false, TopMost = true };
            frmProfile.Dock = DockStyle.Fill;
            frmProfile.Font = new Font(frmProfile.Font.FontFamily, frmProfile.Font.Size / 1.1f, frmProfile.Font.Style);
            frmProfile.Scale(new SizeF(0.9f, 0.9f));
            frmProfile.FormBorderStyle = FormBorderStyle.None;
            frmProfile.Dock = DockStyle.Fill;
            panelEkran.Controls.Add(frmProfile);
            frmProfile.Show();
        }
    }
}
