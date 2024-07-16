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
    public partial class FrmInfo : Form
    {
        public FrmInfo()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Bilgilendirme: Bu uygulama, kullanıcıya bazı önemli bilgiler sunmak için tasarlanmıştır. Lütfen aşağıdaki bilgilere dikkatlice göz atın:\r\n\r\nGizlilik Politikası: Bu uygulama, kullanıcıların gizliliğine büyük önem verir. Kişisel verilerinizi toplamaz, depolamaz veya üçüncü taraflarla paylaşmaz. Uygulama sadece yerel olarak çalışır ve kullanıcının cihazında depolanan verileri kullanır. Gizlilik politikamızı okumak için lütfen \"Gizlilik Politikası\" bölümünü ziyaret edin.\r\n\r\nSorumluluk Reddi: Bu uygulamanın kullanımından kaynaklanan herhangi bir sorumluluk kabul edilmez. Geliştirici, uygulamanın doğruluğu, kesintisiz çalışması veya herhangi bir hata veya hasarın oluşmaması konusunda garanti vermez. Uygulamayı kullanmadan önce, kullanıcıların kendi sorumluluğunda olduğunu ve gerekli önlemleri almaları gerektiğini unutmayın.\r\n\r\nLisans: Bu uygulama sadece eğitim amaçlıdır ve ticari kullanım için uygun değildir. Telif hakkı ve diğer fikri mülkiyet hakları yasaları tarafından korunmaktadır. Uygulamanın kodu, tasarımı ve içeriği geliştiriciye aittir ve izin almadan kopyalanamaz, dağıtılamaz veya değiştirilemez.\r\n\r\nİletişim: Herhangi bir soru, öneri veya bildiriminiz varsa, lütfen iletişim bilgilerimizden bize ulaşın. Kullanıcı geri bildirimlerini önemsiyoruz ve uygulamayı daha iyi hale getirmek için kullanıcıların görüşlerini dikkate alıyoruz.\r\n\r\nGüncellemeler: Bu uygulamanın zaman zaman güncelleneceğini unutmayın. Güncellemeler, hata düzeltmeleri, yeni özellikler veya performans iyileştirmeleri içerebilir. Uygulamanın en son sürümünü kullanmanızı öneririz.\r\n\r\nLütfen bu bilgilere dikkat edin ve uygulamayı kullanmadan önce gerekli önlemleri alın. Uygulamayı kullanarak aşağıdaki kuralları kabul etmiş sayılırsınız:\r\n\r\nUygulamanın kullanımıyla ilgili tüm yasal gerekliliklere uymayı kabul ediyorsunuz.\r\nUygulamayı izinsiz olarak değiştirmeyeceğinizi veya kötüye kullanmayacağınızı taahhüt ediyorsunuz.\r\nGeliştirici, uygulamanın yanlış kullanımından kaynaklanan herhangi bir sorumluluğu kabul etmez.\r\nTeşekkürler!;";
        }
    }
}

